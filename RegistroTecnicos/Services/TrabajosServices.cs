using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services;

public class TrabajosServices
{
    private readonly Context _context;

    public TrabajosServices(Context context)
    {
        _context = context;
    }

    public async Task<bool> Existe(int TrabajoId)
    {
        return await _context.Trabajos.AnyAsync(tr => tr.TrabajoId == TrabajoId);
    }

    public async Task<bool> Insertar(Trabajos trabajos)
    {
        _context.Trabajos.Add(trabajos);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Trabajos trabajos)
    {
        _context.Update(trabajos);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Trabajos trabajos)
    {
        if (!await Existe(trabajos.TrabajoId))
            return await Insertar(trabajos);
        else
            return await Modificar(trabajos);
    }

    public async Task<bool> Eliminar(int TrabajoId)
    {
        var trabajos = await _context.Trabajos.Where(tr => tr.TrabajoId == TrabajoId).ExecuteDeleteAsync();
        return trabajos > 0;
    }

    public async Task<Trabajos?> Buscar(int TrabajoId)
    {
        return await _context.Trabajos.AsNoTracking().FirstOrDefaultAsync(tr => tr.TrabajoId == TrabajoId);
    }

    public async Task<List<Trabajos>> Listar(Expression<Func<Trabajos, bool>> criterio)
    {
        return await _context.Trabajos.AsNoTracking().Where(criterio).ToListAsync();
    }
}
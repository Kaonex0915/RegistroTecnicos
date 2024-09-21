using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services;

public class PrioridadesServices
{
    private readonly Context _context;

    public PrioridadesServices(Context context)
    {
        _context = context;
    }

    public async Task<bool> Existe(int PrioridadId)
    {
        return await _context.Prioridades.AnyAsync(p => p.PrioridadId == PrioridadId);
    }

    public async Task<bool> Insertar(Prioridades prioridades)
    {
        _context.Prioridades.Add(prioridades);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Prioridades prioridades)
    {
        _context.Update(prioridades);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Prioridades prioridades)
    {
        if (!await Existe(prioridades.PrioridadId))
            return await Insertar(prioridades);
        else
            return await Modificar(prioridades);
    }

    public async Task<bool> Eliminar(int PrioridadId)
    {
        var clientes = await _context.Prioridades.Where(p => p.PrioridadId == PrioridadId).ExecuteDeleteAsync();
        return clientes > 0;
    }

    public async Task<Prioridades?> Buscar(int PrioridadId)
    {
        return await _context.Prioridades.AsNoTracking().FirstOrDefaultAsync(p => p.PrioridadId == PrioridadId);
    }

    public async Task<List<Prioridades>> Listar(Expression<Func<Prioridades, bool>> criterio)
    {
        return await _context.Prioridades.AsNoTracking().Where(criterio).ToListAsync();
    }

}
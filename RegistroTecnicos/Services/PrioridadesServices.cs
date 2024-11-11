using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services;

public class PrioridadesServices(IDbContextFactory<Context> DbFactory)
{
    private readonly Context _context;

    public async Task<bool> Existe(int PrioridadId)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.Prioridades.AnyAsync(p => p.PrioridadId == PrioridadId);
    }

    public async Task<bool> Insertar(Prioridades prioridades)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        _context.Prioridades.Add(prioridades);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Prioridades prioridades)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        _context.Update(prioridades);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Prioridades prioridades)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        if (!await Existe(prioridades.PrioridadId))
            return await Insertar(prioridades);
        else
            return await Modificar(prioridades);
    }

    public async Task<bool> Eliminar(int PrioridadId)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        var clientes = await _context.Prioridades.Where(p => p.PrioridadId == PrioridadId).ExecuteDeleteAsync();
        return clientes > 0;
    }

    public async Task<Prioridades?> Buscar(int PrioridadId)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.Prioridades.AsNoTracking().FirstOrDefaultAsync(p => p.PrioridadId == PrioridadId);
    }

    public async Task<List<Prioridades>> Listar(Expression<Func<Prioridades, bool>> criterio)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.Prioridades.AsNoTracking().Where(criterio).ToListAsync();
    }
    public async Task<List<Prioridades>> GetPrioridades()
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.Prioridades.ToListAsync();
    }
}
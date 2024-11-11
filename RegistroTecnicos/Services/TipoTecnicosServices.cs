using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services;

public class TipoTecnicosServices(IDbContextFactory<Context> DbFactory)
{
    private readonly Context _context;

    public async Task<bool> Existe(int TipoTecnicoId)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.TipoTecnicos.AnyAsync(t => t.TipoTecnicosId == TipoTecnicoId);
    }

    public async Task<List<TipoTecnicos>> ObtenerTipoTecnicos()
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.TipoTecnicos.ToListAsync();
    }

    public async Task<bool> Insertar(TipoTecnicos tipotecnicos)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        _context.TipoTecnicos.Add(tipotecnicos);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(TipoTecnicos tipotecnicos)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        _context.Update(tipotecnicos);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(TipoTecnicos tipotecnicos)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        if (!await Existe(tipotecnicos.TipoTecnicosId))
            return await Insertar(tipotecnicos);
        else
            return await Modificar(tipotecnicos);
    }

    public async Task<bool> Eliminar(int TipoTecnicosId)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        var tipotecnicos = await _context.TipoTecnicos.Where(t => t.TipoTecnicosId == TipoTecnicosId).ExecuteDeleteAsync();
        return tipotecnicos > 0;
    }

    public async Task<TipoTecnicos?> Buscar(int TipoTecnicoId)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.TipoTecnicos.AsNoTracking().FirstOrDefaultAsync(t => t.TipoTecnicosId == TipoTecnicoId);
    }

    public async Task<List<TipoTecnicos>> Listar(Expression<Func<TipoTecnicos, bool>> criterio)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.TipoTecnicos.AsNoTracking().Where(criterio).ToListAsync();
    }
}

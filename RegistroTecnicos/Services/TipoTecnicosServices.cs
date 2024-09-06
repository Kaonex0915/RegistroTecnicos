using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services;

public class TipoTecnicosServices
{

    private readonly Context _context;

    public TipoTecnicosServices(Context context)
    {
        _context = context;
    }

    public async Task<bool> Existe(int TipoTecnicoId)
    {
        return await _context.TipoTecnicos.AnyAsync(t => t.TipoTecnicoId == TipoTecnicoId);
    }

    public async Task<bool> Insertar(TipoTecnicos tipotecnicos)
    {
        _context.TipoTecnicos.Add(tipotecnicos);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(TipoTecnicos tipotecnicos)
    {
        _context.Update(tipotecnicos);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(TipoTecnicos tipotecnicos)
    {
        if (!await Existe(tipotecnicos.TipoTecnicosId))
            return await Insertar(tipotecnicos);
        else
            return await Modificar(tipotecnicos);
    }

    public async Task<bool> Eliminar(int TipoTecnicosId)
    {
        var tipotecnicos = await _context.TipoTecnicos.Where(t => t.TipoTecnicosId == TipoTecnicosId).ExecuteDeleteAsync();
        return tipotecnicos > 0;
    }

    public async Task<TipoTecnicos?> Buscar(int TipoTecnicoId)
    {
        return await _context.TipoTecnicos.AsNoTracking().FirstOrDefaultAsync(t => t.TipoTecnicoId == TipoTecnicoId);
    }

    public async Task<List<TipoTecnicos>> Listar(Expression<Func<TipoTecnicos, bool>> criterio)
    {
        return await _context.Tecnicos.AsNoTracking().Where(criterio).ToListAsync();
    }
}

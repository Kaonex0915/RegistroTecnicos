using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services;

public class ClientesServices(IDbContextFactory<Context> DbFactory)
{
    private readonly Context _context;

    public async Task<bool> Existe(int ClientesId)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.Clientes.AnyAsync(c => c.ClienteId == ClientesId);
    }

    public async Task<bool> Insertar(Clientes clientes)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        _context.Clientes.Add(clientes);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Clientes clientes)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        _context.Update(clientes);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Clientes clientes)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        if (!await Existe(clientes.ClienteId))
            return await Insertar(clientes);
        else
            return await Modificar(clientes);
    }

    public async Task<bool> Eliminar(int ClientesId)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        var clientes = await _context.Clientes.Where(c => c.ClienteId == ClientesId).ExecuteDeleteAsync();
        return clientes > 0;
    }

    public async Task<Clientes?> Buscar(int ClientesId)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.Clientes.AsNoTracking().FirstOrDefaultAsync(c => c.ClienteId == ClientesId);
    }

    public async Task<List<Clientes>> Listar(Expression<Func<Clientes, bool>> criterio)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.Clientes.AsNoTracking().Where(criterio).ToListAsync();
    }
    public async Task<List<Clientes>> GetClientes()
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.Clientes.ToListAsync();
    }

}
using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services;

public class ClientesServices
{
    private readonly Context _context;

    public ClientesServices(Context context)
    {
        _context = context;
    }

    public async Task<bool> Existe(int ClientesId)
    {
        return await _context.Clientes.AnyAsync(c => c.ClienteId == ClientesId);
    }

    public async Task<bool> Insertar(Clientes clientes)
    {
        _context.Clientes.Add(clientes);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Clientes clientes)
    {
        _context.Update(clientes);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Clientes clientes)
    {
        if (!await Existe(clientes.ClienteId))
            return await Insertar(clientes);
        else
            return await Modificar(clientes);
    }

    public async Task<bool> Eliminar(int ClientesId)
    {
        var clientes = await _context.Clientes.Where(c => c.ClienteId == ClientesId).ExecuteDeleteAsync();
        return clientes > 0;
    }

    public async Task<Clientes?> Buscar(int ClientesId)
    {
        return await _context.Clientes.AsNoTracking().FirstOrDefaultAsync(c => c.ClienteId == ClientesId);
    }

    public async Task<List<Clientes>> Listar(Expression<Func<Clientes, bool>> criterio)
    {
        return await _context.Clientes.AsNoTracking().Where(criterio).ToListAsync();
    }
}
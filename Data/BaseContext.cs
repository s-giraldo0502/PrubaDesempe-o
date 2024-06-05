using Microsoft.EntityFrameworkCore;
using Filtro.Models;

namespace Filtro.Data;

public class BaseContext : DbContext
{
    public BaseContext(DbContextOptions<BaseContext> options) :base(options)
    {

    }

    //Conexion con los Modelos
    public DbSet<Owner> Owners { get; set;}
    public DbSet<Pet> Pets { get; set;}
    public DbSet<Qoute> Qoutes { get; set;}
    public DbSet<Vet> Vets { get; set;}
}
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using TrabalhoFinalAcademiaNet.Models;

namespace TrabalhoFinalAcademiaNet
{
    public class Contexto : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }       

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Entrega> Entregas { get; set; }

        public Contexto(DbContextOptions<Contexto> options): base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-J8B2L40;  Initial Catalog=GasDB;User ID=alex23; Password=senha1234; Integrated Security=False; TrustServerCertificate=True");            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().HasKey(e => e.Id); 
                       //.HasMany(e => e.Vendas)
                       //.WithOne(e => e.Cliente)
                       //.HasForeignKey(e => e.ClienteId)
                       //.HasPrincipalKey(e => e.Id);

            modelBuilder.Entity<Venda>().HasKey(e => e.Id); 
                        //.HasOne(e => e.Produto)
                        //.WithMany(e => e.Vendas);

            modelBuilder.Entity<Produto>().HasKey(e => e.Id);
                        //.HasMany(e => e.Vendas)
                        //.WithOne(e => e.Produto);

            //base.OnModelCreating(modelBuilder);
        }
        //public DbSet<TrabalhoFinalAcademiaNet.Models.CarrinhoCompra> CarrinhoCompra { get; set; } = default!;
    }
}

using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using TrabalhoFinalAcademiaNet.Models;

namespace TrabalhoFinalAcademiaNet
{
    public class Contexto : DbContext
    {
        private readonly IConfiguration _configuration;

        public Contexto(DbContextOptions<Contexto> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Entrega> Entregas { get; set; }

        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);

            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
             .HasOne(c => c.Endereco)
             .WithOne(e => e.Cliente)
              .HasForeignKey<Endereco>(e => e.ClienteId);

            modelBuilder.Entity<Venda>().HasKey(e => e.Id);

            modelBuilder.Entity<Produto>().HasKey(e => e.Id);

            modelBuilder.Entity<Entrega>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Entrega>()
            .HasOne(e => e.Venda) // Definindo a relação com a Venda
            .WithMany(v => v.Entrega) // Uma venda pode ter várias entregas
            .HasForeignKey(e => e.IdVenda); // Chave estrangeira de Entrega referenciando a Venda
            //base.OnModelCreating(modelBuilder);
        }
        //public DbSet<TrabalhoFinalAcademiaNet.Models.CarrinhoCompra> CarrinhoCompra { get; set; } = default!;
    }
}

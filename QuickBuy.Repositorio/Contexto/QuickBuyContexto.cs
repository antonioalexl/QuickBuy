using Microsoft.EntityFrameworkCore;
using QuickBuy.Dominio.Entidades;
using QuickBuy.Dominio.ObjetoDeValor;
using QuickBuy.Repositorio.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.Repositorio.Contexto
{
    public class QuickBuyContexto : DbContext
    {
        public QuickBuyContexto(DbContextOptions options) : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
            modelBuilder.ApplyConfiguration(new PedidoConfiguration());
            modelBuilder.ApplyConfiguration(new ItemPedidoConfiguration());
            modelBuilder.ApplyConfiguration(new FormaPagamentoConfiguration());

            modelBuilder.Entity<FormaPagamento>().HasData(new FormaPagamento() { Id = 0, Descricao = "Nao Definido" },
                new FormaPagamento() { Id = 1, Descricao = "Boleto" },
                new FormaPagamento() { Id = 2, Descricao = "Cartao Credito" },
                new FormaPagamento() { Id = 3, Descricao = "Boleto" });




            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<ItemPedido> ItensPedidos { get; set; }

        public DbSet<FormaPagamento> FormaPagamento { get; set; }




    }
}

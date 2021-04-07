using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WeCommerce.Models;
using Microsoft.Extensions.Configuration;

namespace WeCommerce.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            InitContext();
        }

        public ApplicationDbContext() : base()
        {
            InitContext();

        }


        private string connectionString;
        private void InitContext()
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: false);
            var config = builder.Build();
            connectionString = config.GetConnectionString("DefaultConnection").ToString();

        }
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlServer(connectionString);

        public DbSet<WeCommerce.Models.Product> Product { get; set; }
        public DbSet<WeCommerce.Models.Category> Category { get; set; }
        public DbSet<WeCommerce.Models.VentaCabecera> VentaCabecera { get; set; }

        public DbSet<WeCommerce.Models.VentaDetalle> VentasDetalles { get; set; }

        public DbSet<WeCommerce.Models.Marca> Marca { get; set; }
    }
}

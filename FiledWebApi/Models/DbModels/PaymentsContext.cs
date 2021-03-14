using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiledWebApi.Models.DbModels
{
    public class PaymentsContext : DbContext
    {
            public PaymentsContext(DbContextOptions options)
                : base(options)
            {
            }
            public DbSet<Payments> Payments { get; set; }
            public DbSet<PaymentStatuses> PaymentStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaymentStatuses>().HasData(new PaymentStatuses
            {
                PaymentStatusID = 1,
                Name = "pending",
                CreatedDate = DateTime.Now,
                UpdatedDate=null,
                IsActive = true
            }, new PaymentStatuses
            {
                PaymentStatusID = 2,
                Name = "processed",
                CreatedDate = DateTime.Now,
                UpdatedDate = null,
                IsActive = true
            }, new PaymentStatuses
            {
                PaymentStatusID = 3,
                Name = "failed",
                CreatedDate = DateTime.Now,
                UpdatedDate = null,
                IsActive = true
            });
        }
    }
}

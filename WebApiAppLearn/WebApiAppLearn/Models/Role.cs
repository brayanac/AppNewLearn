
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiAppLearn.Models
{
    public class Role
    {
        public int id { get; set; }
        public string name { get; set; }


        public List<User> Users { get; set; }
    }
    public class RoleMap : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("role");
            builder.HasKey(q => q.id);
            builder.Property(e => e.id).IsRequired().UseMySqlIdentityColumn();
            builder.Property(e => e.name).HasColumnType("nvarchar(150)").IsRequired();

        }
    }
}

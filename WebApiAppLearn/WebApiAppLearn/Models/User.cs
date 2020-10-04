using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiAppLearn.Models
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }

        public string email { get; set; }

        public string phone { get; set; }


        public int institute_Id { get; set; }

        public int role_Id { get; set; }


        public Role Role { get; set; }

        public Institute Institute { get; set; }
    }
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");
            builder.HasKey(q => q.id);
            builder.Property(e => e.id).IsRequired().UseMySqlIdentityColumn();
            builder.Property(e => e.name).HasColumnType("nvarchar(150)").IsRequired();
            builder.Property(e => e.email).HasColumnType("nvarchar(150)").IsRequired();
            builder.Property(e => e.phone).HasColumnType("nvarchar(150)").IsRequired();


            builder.HasOne(e => e.Role).WithMany(e => e.Users).HasForeignKey(e => e.role_Id).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.Institute).WithMany(e => e.Users).HasForeignKey(e => e.institute_Id).OnDelete(DeleteBehavior.Cascade);
        }
    }
}

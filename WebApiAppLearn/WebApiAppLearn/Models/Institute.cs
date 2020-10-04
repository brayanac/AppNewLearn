using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiAppLearn.Models
{
    public class Institute
    {
        public int id { get; set; }
        public string name { get; set; }

        public List<User> Users { get; set; }
        public List<Course> Courses { get; set; }
    }
    public class InstituteMap : IEntityTypeConfiguration<Institute>
    {
        public void Configure(EntityTypeBuilder<Institute> builder)
        {
            builder.ToTable("institute");
            builder.HasKey(q => q.id);
            builder.Property(e => e.id).IsRequired().UseMySqlIdentityColumn();
            builder.Property(e => e.name).HasColumnType("nvarchar(150)").IsRequired();

        }
    }
}

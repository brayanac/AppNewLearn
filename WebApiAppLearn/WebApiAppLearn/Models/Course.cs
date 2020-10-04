
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiAppLearn.Models
{
    public class Course
    {
        public int id { get; set; }
        public string description { get; set; }
        public string schedule { get; set; }
        public int institute_Id { get; set; }
        public int teacher_Id { get; set; }

        public Teacher Teacher { get; set; }

        public Institute Institute { get; set; }
     

    }
    public class CourseMap : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("course");
            builder.HasKey(q => q.id);
            builder.Property(e => e.id).IsRequired().UseMySqlIdentityColumn();
            builder.Property(e => e.description).HasColumnType("nvarchar(150)").IsRequired();
            builder.Property(e => e.schedule).HasColumnType("nvarchar(150)").IsRequired();

            builder.HasOne(e => e.Institute).WithMany(e => e.Courses).HasForeignKey(e => e.institute_Id).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.Teacher).WithMany(e => e.Courses).HasForeignKey(e => e.teacher_Id).OnDelete(DeleteBehavior.Cascade);
        }
    }
}

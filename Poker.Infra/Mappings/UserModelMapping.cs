using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Poker.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Infra.Mappings
{
    public class UserModelMapping : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.ToTable("User");

            builder.HasKey(d => d.Id);

            //builder.Property(d => d.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(d => d.Email).IsRequired().HasColumnType("varchar(150)").HasMaxLength(150);
            builder.Property(d => d.Password).IsRequired().HasColumnType("varchar(30)").HasMaxLength(30);
            builder.Property(d => d.Name).IsRequired().HasColumnType("varchar(80)").HasMaxLength(80);
        }
    }
}

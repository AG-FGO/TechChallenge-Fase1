using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechChallenge_Fase1.Model;

namespace TechChallenge_Fase1.Configurations
{
    public class AtivosConfiguration : IEntityTypeConfiguration<Ativos>
    {
        public void Configure(EntityTypeBuilder<Ativos> builder)
        {
            builder.ToTable("Ativos");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).HasColumnType("INT").UseIdentityColumn();
            builder.Property(a => a.IdCarteira).HasColumnType("INT").IsRequired();
            builder.Property(a => a.Quantidade).HasColumnType("INT").IsRequired();
            builder.Property(a => a.DataCompra).HasColumnType("DATETIME").IsRequired();
            builder.HasOne(a => a.Acao);
            builder.HasOne(c => c.Carteira).WithMany(c => c.Acoes).HasForeignKey(a => a.IdCarteira);

        }
    }
}

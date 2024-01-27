using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechChallenge_Fase1.Model;

namespace TechChallenge_Fase1.Configurations
{
    public class AcaoConfiguration : IEntityTypeConfiguration<Acao>
    {
        public void Configure(EntityTypeBuilder<Acao> builder)
        {
            builder.ToTable("Acao");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).HasColumnType("INT").UseIdentityColumn();
            builder.Property(a => a.Nome).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(a => a.Valor).HasColumnType("DECIMAL(18,2)").IsRequired();
        }
    }
}

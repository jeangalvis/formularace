using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;
public class TeamConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("team");

            builder.HasIndex(e => e.Name, "team_name_IDX").IsUnique();

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");

            builder.HasMany(p => p.Drivers)
            .WithMany(p => p.Teams)
            .UsingEntity<TeamDriver>(
                j => j
                .HasOne(p => p.Driver)
                .WithMany(p => p.TeamDrivers)
                .HasForeignKey(p => p.IdDriver),

                j => j
                .HasOne(p => p.Team)
                .WithMany(p => p.TeamDrivers)
                .HasForeignKey(p => p.IdTeam),

                j =>
                {
                    j.ToTable("teamdriver");
                    j.HasKey(p => new {p.IdDriver,p.IdTeam});
                }
            );
    }
}

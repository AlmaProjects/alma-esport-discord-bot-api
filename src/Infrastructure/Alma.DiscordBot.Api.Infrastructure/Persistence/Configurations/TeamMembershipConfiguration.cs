// -----------------------------------------------------------------------------
// <copyright file="AppDbContext.cs" company="Alma.DiscordBot.Api.Infrastructure">
//   Copyright (c) Alma.DiscordBot.Api.Infrastructure All rights reserved.
// </copyright>
// <author>iMeanBkli</author>
// <created>15/03/2026</created>
// -----------------------------------------------------------------------------

using Alma.DiscordBot.Api.Core.Domain.Entities;
using Alma.DiscordBot.Api.Core.Domain.Enums;
using Alma.DiscordBot.Api.Infrastructure.Persistence.Converters;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alma.DiscordBot.Api.Infrastructure.Persistence.Configurations;

/// <summary>
/// Configures the EF Core mapping for the <see cref="TeamMembership"/> entity.
/// </summary>
public sealed class TeamMembershipConfiguration : IEntityTypeConfiguration<TeamMembership>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<TeamMembership> builder)
    {
        // -------------------------------------------------------------------------
        // Table
        // -------------------------------------------------------------------------

        builder.ToTable("team_memberships");

        // -------------------------------------------------------------------------
        // Primary key
        // -------------------------------------------------------------------------

        builder.HasKey(tm => tm.Id);

        builder.Property(tm => tm.Id)
            .HasConversion<UuidConverter>()
            .HasColumnName("id")
            .IsRequired();

        // -------------------------------------------------------------------------
        // Properties
        // -------------------------------------------------------------------------

        builder.Property(tm => tm.TeamId)
            .HasConversion<UuidConverter>()
            .HasColumnName("team_id")
            .IsRequired();

        builder.Property(tm => tm.PlayerId)
            .HasConversion<UuidConverter>()
            .HasColumnName("player_id")
            .IsRequired();

        builder.Property(tm => tm.Status)
            .HasColumnName("status")
            .HasConversion<string>()
            .IsRequired();

        builder.Property(tm => tm.Role)
            .HasColumnName("role")
            .HasConversion<string>()
            .IsRequired();

        builder.Property(tm => tm.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(tm => tm.UpdatedAt)
            .HasColumnName("updated_at")
            .IsRequired(false);

        builder.Property(tm => tm.LeftAt)
            .HasColumnName("left_at")
            .IsRequired(false);

        // -------------------------------------------------------------------------
        // Relations
        // -------------------------------------------------------------------------

        builder.HasOne<Team>()
            .WithMany()
            .HasForeignKey(tm => tm.TeamId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Player>()
            .WithMany()
            .HasForeignKey(tm => tm.PlayerId)
            .OnDelete(DeleteBehavior.Restrict);

        // -------------------------------------------------------------------------
        // Indexes
        // -------------------------------------------------------------------------

        builder.HasIndex(tm => new { tm.PlayerId, tm.LeftAt })
            .HasDatabaseName("ix_team_memberships_player_id_left_at");
    }
}

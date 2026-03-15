// -----------------------------------------------------------------------------
// <copyright file="AppDbContext.cs" company="Alma.DiscordBot.Api.Infrastructure">
//   Copyright (c) Alma.DiscordBot.Api.Infrastructure All rights reserved.
// </copyright>
// <author>iMeanBkli</author>
// <created>15/03/2026</created>
// -----------------------------------------------------------------------------

using Alma.DiscordBot.Api.Core.Domain.Entities;
using Alma.DiscordBot.Api.Infrastructure.Persistence.Converters;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alma.DiscordBot.Api.Infrastructure.Persistence.Configurations;

/// <summary>
/// Configures the EF Core mapping for the <see cref="Player"/> entity.
/// </summary>
public sealed class PlayerConfiguration : IEntityTypeConfiguration<Player>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<Player> builder)
    {
        // -------------------------------------------------------------------------
        // Table
        // -------------------------------------------------------------------------

        builder.ToTable("players");

        // -------------------------------------------------------------------------
        // Primary key
        // -------------------------------------------------------------------------

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasConversion<UuidConverter>()
            .HasColumnName("id")
            .IsRequired();

        // -------------------------------------------------------------------------
        // Properties
        // -------------------------------------------------------------------------

        builder.Property(p => p.UserId)
            .HasConversion<UuidConverter>()
            .HasColumnName("user_id")
            .IsRequired();

        builder.Property(p => p.RiotId)
            .HasConversion<RiotIdConverter>()
            .HasColumnName("riot_id")
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(p => p.Puuid)
            .HasColumnName("puuid")
            .HasMaxLength(78)
            .IsRequired(false);

        builder.Property(p => p.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(p => p.UpdatedAt)
            .HasColumnName("updated_at")
            .IsRequired(false);

        builder.Property(p => p.IsActive)
            .HasColumnName("is_active")
            .IsRequired()
            .HasDefaultValue(true);

        builder.Property(p => p.DeletedAt)
            .HasColumnName("deleted_at")
            .IsRequired(false);

        // -------------------------------------------------------------------------
        // Relations
        // -------------------------------------------------------------------------

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        // -------------------------------------------------------------------------
        // Global query filter
        // -------------------------------------------------------------------------

        builder.HasQueryFilter(p => p.IsActive);
    }
}

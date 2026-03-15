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
/// Configures the EF Core mapping for the <see cref="Team"/> entity.
/// </summary>
public sealed class TeamConfiguration : IEntityTypeConfiguration<Team>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        // -------------------------------------------------------------------------
        // Table
        // -------------------------------------------------------------------------

        builder.ToTable("teams");

        // -------------------------------------------------------------------------
        // Primary key
        // -------------------------------------------------------------------------

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
            .HasConversion<UuidConverter>()
            .HasColumnName("id")
            .IsRequired();

        // -------------------------------------------------------------------------
        // Properties
        // -------------------------------------------------------------------------

        builder.Property(t => t.GuildId)
            .HasConversion<SnowflakeConverter>()
            .HasColumnName("guild_id")
            .IsRequired();

        builder.Property(t => t.Name)
            .HasColumnName("name")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(t => t.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(t => t.UpdatedAt)
            .HasColumnName("updated_at")
            .IsRequired(false);

        builder.Property(t => t.IsActive)
            .HasColumnName("is_active")
            .IsRequired()
            .HasDefaultValue(true);

        builder.Property(t => t.DeletedAt)
            .HasColumnName("deleted_at")
            .IsRequired(false);

        // -------------------------------------------------------------------------
        // Global query filter
        // -------------------------------------------------------------------------

        builder.HasQueryFilter(t => t.IsActive);
    }
}

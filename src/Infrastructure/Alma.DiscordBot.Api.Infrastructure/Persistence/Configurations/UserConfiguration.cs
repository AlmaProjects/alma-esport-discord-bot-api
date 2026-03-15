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
/// Configures the EF Core mapping for the <see cref="User"/> entity.
/// </summary>
public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // -------------------------------------------------------------------------
        // Table
        // -------------------------------------------------------------------------

        builder.ToTable("users");

        // -------------------------------------------------------------------------
        // Primary key
        // -------------------------------------------------------------------------

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .HasConversion<UuidConverter>()
            .HasColumnName("id")
            .IsRequired();

        // -------------------------------------------------------------------------
        // Properties
        // -------------------------------------------------------------------------

        builder.Property(u => u.DiscordId)
            .HasConversion<SnowflakeConverter>()
            .HasColumnName("discord_id")
            .IsRequired();

        builder.Property(u => u.GuildId)
            .HasConversion<SnowflakeConverter>()
            .HasColumnName("guild_id")
            .IsRequired();

        builder.Property(u => u.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(u => u.UpdatedAt)
            .HasColumnName("updated_at")
            .IsRequired(false);

        builder.Property(u => u.IsActive)
            .HasColumnName("is_active")
            .IsRequired()
            .HasDefaultValue(true);

        builder.Property(u => u.DeletedAt)
            .HasColumnName("deleted_at")
            .IsRequired(false);

        builder.Property(u => u.LeftAt)
            .HasColumnName("left_at")
            .IsRequired(false);

        // -------------------------------------------------------------------------
        // Indexes
        // -------------------------------------------------------------------------

        builder.HasIndex(u => new { u.DiscordId, u.GuildId })
            .IsUnique()
            .HasDatabaseName("ix_users_discord_id_guild_id");

        // -------------------------------------------------------------------------
        // Global query filter
        // -------------------------------------------------------------------------

        builder.HasQueryFilter(u => u.IsActive);
    }
}

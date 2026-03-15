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
/// Configures the EF Core mapping for the <see cref="GuildConfiguration"/> entity.
/// </summary>
public sealed class GuildConfigurationConfiguration
    : IEntityTypeConfiguration<GuildConfiguration>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<GuildConfiguration> builder)
    {
        // -------------------------------------------------------------------------
        // Table
        // -------------------------------------------------------------------------

        builder.ToTable("guild_configurations");

        // -------------------------------------------------------------------------
        // Primary key
        // -------------------------------------------------------------------------

        builder.HasKey(gc => gc.Id);

        builder.Property(gc => gc.Id)
            .HasConversion<SnowflakeConverter>()
            .HasColumnName("id")
            .IsRequired();

        // -------------------------------------------------------------------------
        // Properties
        // -------------------------------------------------------------------------

        builder.Property(gc => gc.CommandPrefix)
            .HasColumnName("command_prefix")
            .HasMaxLength(10)
            .IsRequired();

        // -------------------------------------------------------------------------
        // Relations
        // -------------------------------------------------------------------------

        builder.HasMany(gc => gc.AllowedRoles)
            .WithOne()
            .HasForeignKey(r => r.GuildId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(gc => gc.AllowedChannels)
            .WithOne()
            .HasForeignKey(c => c.GuildId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

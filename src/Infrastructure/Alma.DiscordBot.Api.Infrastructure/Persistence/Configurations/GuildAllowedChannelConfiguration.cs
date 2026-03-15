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
/// Configures the EF Core mapping for the <see cref="GuildAllowedChannel"/> entity.
/// </summary>
public sealed class GuildAllowedChannelConfiguration
    : IEntityTypeConfiguration<GuildAllowedChannel>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<GuildAllowedChannel> builder)
    {
        // -------------------------------------------------------------------------
        // Table
        // -------------------------------------------------------------------------

        builder.ToTable("guild_allowed_channels");

        // -------------------------------------------------------------------------
        // Primary key
        // -------------------------------------------------------------------------

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasConversion<SurrogateIdConverter>()
            .HasColumnName("id")
            .ValueGeneratedOnAdd()
            .IsRequired();

        // -------------------------------------------------------------------------
        // Properties
        // -------------------------------------------------------------------------

        builder.Property(c => c.GuildId)
            .HasConversion<SnowflakeConverter>()
            .HasColumnName("guild_id")
            .IsRequired();

        builder.Property(c => c.ChannelId)
            .HasConversion<SnowflakeConverter>()
            .HasColumnName("channel_id")
            .IsRequired();
    }
}

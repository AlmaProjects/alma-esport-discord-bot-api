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
/// Configures the EF Core mapping for the <see cref="GuildAllowedRole"/> entity.
/// </summary>
public sealed class GuildAllowedRoleConfiguration
    : IEntityTypeConfiguration<GuildAllowedRole>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<GuildAllowedRole> builder)
    {
        // -------------------------------------------------------------------------
        // Table
        // -------------------------------------------------------------------------

        builder.ToTable("guild_allowed_roles");

        // -------------------------------------------------------------------------
        // Primary key
        // -------------------------------------------------------------------------

        builder.HasKey(r => r.Id);

        builder.Property(r => r.Id)
            .HasConversion<SurrogateIdConverter>()
            .HasColumnName("id")
            .ValueGeneratedOnAdd()
            .IsRequired();

        // -------------------------------------------------------------------------
        // Properties
        // -------------------------------------------------------------------------

        builder.Property(r => r.GuildId)
            .HasConversion<SnowflakeConverter>()
            .HasColumnName("guild_id")
            .IsRequired();

        builder.Property(r => r.RoleId)
            .HasConversion<SnowflakeConverter>()
            .HasColumnName("role_id")
            .IsRequired();
    }
}

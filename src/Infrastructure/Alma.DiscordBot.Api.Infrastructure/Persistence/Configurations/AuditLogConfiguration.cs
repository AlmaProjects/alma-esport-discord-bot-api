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
/// Configures the EF Core mapping for the <see cref="AuditLog"/> entity.
/// </summary>
public sealed class AuditLogConfiguration : IEntityTypeConfiguration<AuditLog>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<AuditLog> builder)
    {
        // -------------------------------------------------------------------------
        // Table
        // -------------------------------------------------------------------------

        builder.ToTable("audit_logs");

        // -------------------------------------------------------------------------
        // Primary key
        // -------------------------------------------------------------------------

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id)
            .HasConversion<SurrogateIdConverter>()
            .HasColumnName("id")
            .ValueGeneratedOnAdd()
            .IsRequired();

        // -------------------------------------------------------------------------
        // Properties
        // -------------------------------------------------------------------------

        builder.Property(a => a.GuildId)
            .HasConversion<SnowflakeConverter>()
            .HasColumnName("guild_id")
            .IsRequired();

        builder.Property(a => a.ActorId)
            .HasConversion<SnowflakeConverter>()
            .HasColumnName("actor_id")
            .IsRequired();

        builder.Property(a => a.Action)
            .HasColumnName("action")
            .HasConversion<string>()
            .IsRequired();

        builder.Property(a => a.EntityType)
            .HasColumnName("entity_type")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(a => a.EntityId)
            .HasColumnName("entity_id")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(a => a.Payload)
            .HasColumnName("payload")
            .HasColumnType("jsonb")
            .IsRequired();

        builder.Property(a => a.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        // -------------------------------------------------------------------------
        // Indexes
        // -------------------------------------------------------------------------

        builder.HasIndex(a => a.GuildId)
            .HasDatabaseName("ix_audit_logs_guild_id");

        builder.HasIndex(a => a.CreatedAt)
            .HasDatabaseName("ix_audit_logs_created_at");
    }
}

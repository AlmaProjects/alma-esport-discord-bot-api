// -----------------------------------------------------------------------------
// <copyright file="AppDbContext.cs" company="Alma.DiscordBot.Api.Infrastructure">
//   Copyright (c) Alma.DiscordBot.Api.Infrastructure All rights reserved.
// </copyright>
// <author>iMeanBkli</author>
// <created>15/03/2026</created>
// -----------------------------------------------------------------------------

using Alma.DiscordBot.Api.Core.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace Alma.DiscordBot.Api.Infrastructure.Persistence;

/// <summary>
/// Represents the Entity Framework Core database context
/// for the Alma Discord Bot application.
/// </summary>
public sealed class AppDbContext : DbContext
{
    // -------------------------------------------------------------------------
    // Constructor
    // -------------------------------------------------------------------------

    /// <summary>
    /// Initializes a new instance of <see cref="AppDbContext"/>
    /// with the specified options.
    /// </summary>
    /// <param name="options">
    /// The options to configure this context.
    /// </param>
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    // -------------------------------------------------------------------------
    // DbSets
    // -------------------------------------------------------------------------

    /// <summary>
    /// Gets or sets the <see cref="User"/> entities.
    /// </summary>
    public DbSet<User> Users => Set<User>();

    /// <summary>
    /// Gets or sets the <see cref="Player"/> entities.
    /// </summary>
    public DbSet<Player> Players => Set<Player>();

    /// <summary>
    /// Gets or sets the <see cref="Team"/> entities.
    /// </summary>
    public DbSet<Team> Teams => Set<Team>();

    /// <summary>
    /// Gets or sets the <see cref="TeamMembership"/> entities.
    /// </summary>
    public DbSet<TeamMembership> TeamMemberships => Set<TeamMembership>();

    /// <summary>
    /// Gets or sets the <see cref="GuildConfiguration"/> entities.
    /// </summary>
    public DbSet<GuildConfiguration> GuildConfigurations => Set<GuildConfiguration>();

    /// <summary>
    /// Gets or sets the <see cref="GuildAllowedRole"/> entities.
    /// </summary>
    public DbSet<GuildAllowedRole> GuildAllowedRoles => Set<GuildAllowedRole>();

    /// <summary>
    /// Gets or sets the <see cref="GuildAllowedChannel"/> entities.
    /// </summary>
    public DbSet<GuildAllowedChannel> GuildAllowedChannels => Set<GuildAllowedChannel>();

    /// <summary>
    /// Gets or sets the <see cref="AuditLog"/> entities.
    /// </summary>
    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();

    // -------------------------------------------------------------------------
    // Configuration
    // -------------------------------------------------------------------------

    /// <inheritdoc/>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Apply all entity configurations from this assembly
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}

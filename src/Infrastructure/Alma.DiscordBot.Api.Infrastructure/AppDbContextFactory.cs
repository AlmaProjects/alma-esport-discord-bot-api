// -----------------------------------------------------------------------------
// <copyright file="AppDbContext.cs" company="Alma.DiscordBot.Api.Infrastructure">
//   Copyright (c) Alma.DiscordBot.Api.Infrastructure All rights reserved.
// </copyright>
// <author>iMeanBkli</author>
// <created>15/03/2026</created>
// -----------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Alma.DiscordBot.Api.Infrastructure.Persistence;

/// <summary>
/// Provides a design-time factory for creating <see cref="AppDbContext"/>
/// instances during EF Core tooling operations such as migrations.
/// </summary>
/// <remarks>
/// <para>
/// This factory is used exclusively by EF Core design-time tools
/// (e.g., <c>dotnet ef migrations add</c>) and is never instantiated
/// at runtime.
/// </para>
/// <para>
/// The connection string defined here is intended for local development
/// only. Production connection strings must be provided via environment
/// variables or a secrets manager.
/// </para>
/// </remarks>
public sealed class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    /// <summary>
    /// Creates a new instance of <see cref="AppDbContext"/>
    /// configured for design-time operations.
    /// </summary>
    /// <param name="args">
    /// Arguments passed by the EF Core tooling. Not used.
    /// </param>
    /// <returns>
    /// A new <see cref="AppDbContext"/> instance configured
    /// with the local development connection string.
    /// </returns>
    public AppDbContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<AppDbContext> optionsBuilder = new();

        optionsBuilder.UseNpgsql(
            "Host=localhost;" +
            "Port=5432;" +
            "Database=alma_discordbot_dev;" +
            "Username=alma;" +
            "Password=alma_dev_password");

        return new AppDbContext(optionsBuilder.Options);
    }
}

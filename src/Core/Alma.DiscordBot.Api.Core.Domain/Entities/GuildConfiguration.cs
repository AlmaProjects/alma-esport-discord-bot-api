// -----------------------------------------------------------------------------
// <copyright file="AuditLog.cs" company="Alma.DiscordBot.Api.Core.Domain">
//   Copyright (c) Alma.DiscordBot.Api.Core.Domain All rights reserved.
// </copyright>
// <author>iMeanBkli</author>
// <created>13/03/2026</created>
// -----------------------------------------------------------------------------

using Alma.DiscordBot.Api.Core.Abstractions.Interfaces;
using Alma.DiscordBot.Api.Core.Abstractions.ValueObjects;

namespace Alma.DiscordBot.Api.Core.Domain.Entities
{
    /// <summary>
    /// Represents the configuration of a Discord guild in the system.
    /// </summary>
    /// <remarks>
    /// <para>
    /// A <see cref="GuildConfiguration"/> is uniquely identified by its
    /// <see cref="Id"/>, which corresponds directly to the Discord guild ID,
    /// making it a natural key in the system.
    /// </para>
    /// <para>
    /// It defines the command prefix and the allowed roles and channels
    /// through which the bot can be interacted with.
    /// </para>
    /// </remarks>
    /// <seealso cref="IIdentifiable{TId}"/>
    /// <seealso cref="GuildAllowedRole"/>
    /// <seealso cref="GuildAllowedChannel"/>
    public sealed class GuildConfiguration : IIdentifiable<Snowflake>
    {
        // -------------------------------------------------------------------------
        // Identity
        // -------------------------------------------------------------------------

        /// <inheritdoc/>
        public Snowflake Id { get; init; }

        /// <summary>
        /// Gets the command prefix used to interact with the bot in this guild.
        /// </summary>
        /// <value>
        /// A <see cref="string"/> representing the command prefix.
        /// </value>
        public string CommandPrefix { get; private set; } = string.Empty;

        // -------------------------------------------------------------------------
        // Navigation properties
        // -------------------------------------------------------------------------

        /// <summary>
        /// Gets the roles allowed to interact with the bot in this guild.
        /// </summary>
        /// <value>
        /// A collection of <see cref="GuildAllowedRole"/> instances associated
        /// with this guild configuration.
        /// </value>
        public IReadOnlyCollection<GuildAllowedRole> AllowedRoles { get; init; }
            = Array.Empty<GuildAllowedRole>();

        /// <summary>
        /// Gets the channels allowed to interact with the bot in this guild.
        /// </summary>
        /// <value>
        /// A collection of <see cref="GuildAllowedChannel"/> instances associated
        /// with this guild configuration.
        /// </value>
        public IReadOnlyCollection<GuildAllowedChannel> AllowedChannels { get; init; }
            = Array.Empty<GuildAllowedChannel>();
    }
}

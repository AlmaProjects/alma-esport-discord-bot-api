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
    /// Represents a Discord role allowed to interact with the bot in a guild.
    /// </summary>
    /// <remarks>
    /// <para>
    /// A <see cref="GuildAllowedRole"/> is scoped to a specific guild via
    /// <see cref="GuildId"/> and references a Discord role via <see cref="RoleId"/>.
    /// </para>
    /// </remarks>
    /// <seealso cref="IIdentifiable{TId}"/>
    /// <seealso cref="GuildConfiguration"/>
    public sealed class GuildAllowedRole : IIdentifiable<SurrogateId>
    {
        // -------------------------------------------------------------------------
        // Identity
        // -------------------------------------------------------------------------

        /// <inheritdoc/>
        public SurrogateId Id { get; init; }

        /// <summary>
        /// Gets the Discord identifier of the guild this allowed role belongs to.
        /// </summary>
        /// <value>
        /// A <see cref="Snowflake"/> representing the Discord-assigned guild ID.
        /// </value>
        public Snowflake GuildId { get; init; }

        /// <summary>
        /// Gets the Discord identifier of the allowed role.
        /// </summary>
        /// <value>
        /// A <see cref="Snowflake"/> representing the Discord-assigned role ID.
        /// </value>
        public Snowflake RoleId { get; init; }
    }
}

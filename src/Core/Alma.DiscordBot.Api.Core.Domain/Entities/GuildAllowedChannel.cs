// -----------------------------------------------------------------------------
// <copyright file="GuildAllowedChannel.cs" company="$projectname$">
//   Copyright (c) $projectname$. All rights reserved.
// </copyright>
// <author>$author$</author>
// <created>13/03/2026 16:14:39</created>
// -----------------------------------------------------------------------------

using Alma.DiscordBot.Api.Core.Abstractions.Interfaces;
using Alma.DiscordBot.Api.Core.Abstractions.ValueObjects;

namespace Alma.DiscordBot.Api.Core.Domain.Entities
{
    /// <summary>
    /// Represents a Discord channel allowed to interact with the bot in a guild.
    /// </summary>
    /// <remarks>
    /// <para>
    /// A <see cref="GuildAllowedChannel"/> is scoped to a specific guild via
    /// <see cref="GuildId"/> and references a Discord channel via
    /// <see cref="ChannelId"/>.
    /// </para>
    /// </remarks>
    /// <seealso cref="IIdentifiable{TId}"/>
    /// <seealso cref="GuildConfiguration"/>
    public sealed class GuildAllowedChannel : IIdentifiable<SurrogateId>
    {
        // -------------------------------------------------------------------------
        // Identity
        // -------------------------------------------------------------------------

        /// <inheritdoc/>
        public SurrogateId Id { get; init; }

        /// <summary>
        /// Gets the Discord identifier of the guild this allowed channel belongs to.
        /// </summary>
        /// <value>
        /// A <see cref="Snowflake"/> representing the Discord-assigned guild ID.
        /// </value>
        public Snowflake GuildId { get; init; }

        /// <summary>
        /// Gets the Discord identifier of the allowed channel.
        /// </summary>
        /// <value>
        /// A <see cref="Snowflake"/> representing the Discord-assigned channel ID.
        /// </value>
        public Snowflake ChannelId { get; init; }
    }
}

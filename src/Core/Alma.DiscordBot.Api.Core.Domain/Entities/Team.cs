// -----------------------------------------------------------------------------
// <copyright file="Team.cs" company="$projectname$">
//   Copyright (c) $projectname$. All rights reserved.
// </copyright>
// <author>$author$</author>
// <created>13/03/2026 16:11:31</created>
// -----------------------------------------------------------------------------

using Alma.DiscordBot.Api.Core.Abstractions.Interfaces;
using Alma.DiscordBot.Api.Core.Abstractions.ValueObjects;

namespace Alma.DiscordBot.Api.Core.Domain.Entities
{
    /// <summary>
    /// Represents a League of Legends team registered in a guild.
    /// </summary>
    /// <remarks>
    /// <para>
    /// A <see cref="Team"/> is scoped to a specific guild via <see cref="GuildId"/>,
    /// ensuring that teams from different guilds are fully isolated.
    /// </para>
    /// <para>
    /// Instances of this entity are never permanently deleted.
    /// Activation and deactivation are performed via
    /// <see cref="ISoftDeletable.Activate"/> and
    /// <see cref="ISoftDeletable.Deactivate"/> methods.
    /// Deactivation history is tracked via <c>AuditLog</c>.
    /// </para>
    /// </remarks>
    /// <seealso cref="IIdentifiable{TId}"/>
    /// <seealso cref="IAuditable"/>
    /// <seealso cref="ISoftDeletable"/>
    public sealed class Team : IIdentifiable<Uuid>, IAuditable, ISoftDeletable
    {
        // -------------------------------------------------------------------------
        // Identity
        // -------------------------------------------------------------------------

        /// <inheritdoc/>
        public Uuid Id { get; init; }

        /// <summary>
        /// Gets the Discord identifier of the guild this team belongs to.
        /// </summary>
        /// <value>
        /// A <see cref="Snowflake"/> representing the Discord-assigned guild ID.
        /// </value>
        public Snowflake GuildId { get; init; }

        /// <summary>
        /// Gets the name of this team.
        /// </summary>
        /// <value>
        /// A <see cref="string"/> representing the team name.
        /// </value>
        public string Name { get; init; } = string.Empty;

        // -------------------------------------------------------------------------
        // Audit
        // -------------------------------------------------------------------------

        /// <inheritdoc/>
        public DateTime CreatedAt { get; init; }

        /// <inheritdoc/>
        public DateTime? UpdatedAt { get; private set; }

        // -------------------------------------------------------------------------
        // Soft delete
        // -------------------------------------------------------------------------

        /// <inheritdoc/>
        public bool IsActive { get; private set; } = true;

        /// <inheritdoc/>
        public DateTime? DeletedAt { get; private set; }

        // -------------------------------------------------------------------------
        // Domain behaviour
        // -------------------------------------------------------------------------

        /// <inheritdoc/>
        public void Activate()
        {
        }

        /// <inheritdoc/>
        public void Deactivate()
        {
        }
    }
}

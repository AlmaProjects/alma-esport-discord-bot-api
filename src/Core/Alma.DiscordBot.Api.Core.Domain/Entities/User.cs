// -----------------------------------------------------------------------------
// <copyright file="User.cs" company="$projectname$">
//   Copyright (c) $projectname$. All rights reserved.
// </copyright>
// <author>$author$</author>
// <created>13/03/2026 15:57:56</created>
// -----------------------------------------------------------------------------

using Alma.DiscordBot.Api.Core.Abstractions.Interfaces;
using Alma.DiscordBot.Api.Core.Abstractions.ValueObjects;

namespace Alma.DiscordBot.Api.Core.Domain.Entities
{
    /// <summary>
    /// Represents a Discord user registered in a guild.
    /// </summary>
    /// <remarks>
    /// <para>
    /// A <see cref="User"/> is uniquely identified by the combination of
    /// <see cref="DiscordId"/> and <see cref="GuildId"/>, ensuring that the same
    /// Discord account can be registered in multiple guilds as distinct users.
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
    public sealed class User : IIdentifiable<Uuid>, IAuditable, ISoftDeletable
    {
        // -------------------------------------------------------------------------
        // Identity
        // -------------------------------------------------------------------------

        /// <inheritdoc/>
        public Uuid Id { get; init; }

        /// <summary>
        /// Gets the Discord identifier of this user.
        /// </summary>
        /// <value>
        /// A <see cref="Snowflake"/> representing the Discord-assigned user ID.
        /// </value>
        public Snowflake DiscordId { get; init; }

        /// <summary>
        /// Gets the Discord identifier of the guild this user belongs to.
        /// </summary>
        /// <value>
        /// A <see cref="Snowflake"/> representing the Discord-assigned guild ID.
        /// </value>
        public Snowflake GuildId { get; init; }

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

        /// <summary>
        /// Gets the UTC timestamp at which the user left the guild.
        /// </summary>
        /// <value>
        /// The UTC timestamp if the user has left the guild;
        /// otherwise <see langword="null"/>.
        /// </value>
        public DateTime? LeftAt { get; private set; }

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

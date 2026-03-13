// -----------------------------------------------------------------------------
// <copyright file="Player.cs" company="$projectname$">
//   Copyright (c) $projectname$. All rights reserved.
// </copyright>
// <author>$author$</author>
// <created>13/03/2026 16:12:06</created>
// -----------------------------------------------------------------------------

using Alma.DiscordBot.Api.Core.Abstractions.Interfaces;
using Alma.DiscordBot.Api.Core.Abstractions.ValueObjects;

namespace Alma.DiscordBot.Api.Core.Domain.Entities
{
    /// <summary>
    /// Represents a League of Legends player associated with a user in the system.
    /// </summary>
    /// <remarks>
    /// <para>
    /// A <see cref="Player"/> is linked to a <see cref="User"/> via
    /// <see cref="UserId"/>. Only one <see cref="Player"/> can be active
    /// per <see cref="User"/> at a time, enforced by business logic.
    /// </para>
    /// <para>
    /// The <see cref="RiotId"/> is initially provided as free text in the format
    /// <c>Pseudo#TAG</c>. The <see cref="Puuid"/> is populated upon successful
    /// validation against the Riot Games API.
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
    /// <seealso cref="User"/>
    public sealed class Player : IIdentifiable<Uuid>, IAuditable, ISoftDeletable
    {
        // -------------------------------------------------------------------------
        // Identity
        // -------------------------------------------------------------------------

        /// <inheritdoc/>
        public Uuid Id { get; init; }

        /// <summary>
        /// Gets the identifier of the user this player is associated with.
        /// </summary>
        /// <value>
        /// A <see cref="Uuid"/> representing the associated <see cref="User"/> ID.
        /// </value>
        public Uuid UserId { get; init; }

        /// <summary>
        /// Gets the Riot Games identifier of this player.
        /// </summary>
        /// <value>
        /// A <see cref="string"/> in the format <c>Pseudo#TAG</c> representing
        /// the player's Riot ID.
        /// </value>
        public string RiotId { get; init; } = string.Empty;

        /// <summary>
        /// Gets the Riot Games PUUID of this player.
        /// </summary>
        /// <value>
        /// A <see cref="string"/> representing the player's PUUID if validated
        /// against the Riot Games API; otherwise <see langword="null"/>.
        /// </value>
        public string? Puuid { get; private set; }

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

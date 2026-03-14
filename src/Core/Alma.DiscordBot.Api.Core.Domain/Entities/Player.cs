// -----------------------------------------------------------------------------
// <copyright file="AuditLog.cs" company="Alma.DiscordBot.Api.Core.Domain">
//   Copyright (c) Alma.DiscordBot.Api.Core.Domain All rights reserved.
// </copyright>
// <author>iMeanBkli</author>
// <created>13/03/2026</created>
// -----------------------------------------------------------------------------

using Alma.DiscordBot.Api.Core.Abstractions.Interfaces;
using Alma.DiscordBot.Api.Core.Abstractions.ValueObjects;
using Alma.DiscordBot.Api.Core.Domain.ValueObjects;

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
    /// <seealso cref="RiotId"/>
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
        /// A <see cref="RiotId"/> representing the player's Riot ID
        /// in the format <c>GameName#TagLine</c>.
        /// </value>
        public RiotId RiotId { get; init; }

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

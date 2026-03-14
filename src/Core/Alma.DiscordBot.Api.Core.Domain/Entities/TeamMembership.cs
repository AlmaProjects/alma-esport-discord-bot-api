// -----------------------------------------------------------------------------
// <copyright file="AuditLog.cs" company="Alma.DiscordBot.Api.Core.Domain">
//   Copyright (c) Alma.DiscordBot.Api.Core.Domain All rights reserved.
// </copyright>
// <author>iMeanBkli</author>
// <created>13/03/2026</created>
// -----------------------------------------------------------------------------

using Alma.DiscordBot.Api.Core.Abstractions.Interfaces;
using Alma.DiscordBot.Api.Core.Abstractions.ValueObjects;
using Alma.DiscordBot.Api.Core.Domain.Enums;

namespace Alma.DiscordBot.Api.Core.Domain.Entities
{
    /// <summary>
    /// Represents the membership of a player in a team.
    /// </summary>
    /// <remarks>
    /// <para>
    /// A <see cref="TeamMembership"/> records the association between a
    /// <see cref="Player"/> and a <see cref="Team"/>, along with the player's
    /// <see cref="TeamStatus"/> and <see cref="TeamRole"/> within that team.
    /// </para>
    /// <para>
    /// Status transitions are performed by closing the current membership
    /// and creating a new one, preserving the full membership history.
    /// </para>
    /// <para>
    /// A membership is considered active when <see cref="LeftAt"/> is
    /// <see langword="null"/>.
    /// </para>
    /// </remarks>
    /// <seealso cref="IIdentifiable{TId}"/>
    /// <seealso cref="IAuditable"/>
    /// <seealso cref="Player"/>
    /// <seealso cref="Team"/>
    /// <seealso cref="TeamStatus"/>
    /// <seealso cref="TeamRole"/>
    public sealed class TeamMembership : IIdentifiable<Uuid>, IAuditable
    {
        // -------------------------------------------------------------------------
        // Identity
        // -------------------------------------------------------------------------

        /// <inheritdoc/>
        public Uuid Id { get; init; }

        /// <summary>
        /// Gets the identifier of the team this membership belongs to.
        /// </summary>
        /// <value>
        /// A <see cref="Uuid"/> representing the associated <see cref="Team"/> ID.
        /// </value>
        public Uuid TeamId { get; init; }

        /// <summary>
        /// Gets the identifier of the player this membership belongs to.
        /// </summary>
        /// <value>
        /// A <see cref="Uuid"/> representing the associated <see cref="Player"/> ID.
        /// </value>
        public Uuid PlayerId { get; init; }

        /// <summary>
        /// Gets the status of the player within this team membership.
        /// </summary>
        /// <value>
        /// A <see cref="TeamStatus"/> representing the player's current status.
        /// </value>
        public TeamStatus Status { get; init; }

        /// <summary>
        /// Gets the role of the player within this team membership.
        /// </summary>
        /// <value>
        /// A <see cref="TeamRole"/> representing the player's role in the team.
        /// </value>
        public TeamRole Role { get; init; }

        // -------------------------------------------------------------------------
        // Audit
        // -------------------------------------------------------------------------

        /// <inheritdoc/>
        public DateTime CreatedAt { get; init; }

        /// <inheritdoc/>
        public DateTime? UpdatedAt { get; private set; }

        /// <summary>
        /// Gets the UTC timestamp at which this membership ended.
        /// </summary>
        /// <value>
        /// The UTC timestamp if the membership is closed;
        /// otherwise <see langword="null"/> if the membership is active.
        /// </value>
        public DateTime? LeftAt { get; private set; }
    }
}

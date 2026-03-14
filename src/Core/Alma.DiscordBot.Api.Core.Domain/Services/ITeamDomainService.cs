// -----------------------------------------------------------------------------
// <copyright file="AuditLog.cs" company="Alma.DiscordBot.Api.Core.Domain">
//   Copyright (c) Alma.DiscordBot.Api.Core.Domain All rights reserved.
// </copyright>
// <author>iMeanBkli</author>
// <created>14/03/2026</created>
// -----------------------------------------------------------------------------

using Alma.DiscordBot.Api.Core.Domain.Entities;
using Alma.DiscordBot.Api.Core.Domain.Enums;

namespace Alma.DiscordBot.Api.Core.Domain.Services
{
    /// <summary>
    /// Defines the contract for team domain operations.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Encapsulates the business rules governing team membership lifecycle,
    /// including status transitions, role assignments, and membership constraints.
    /// </para>
    /// <para>
    /// The following constraints are enforced by this service:
    /// <list type="bullet">
    /// <item>
    /// A team cannot have more than 5 active <see cref="TeamStatus.Lock"/> players
    /// simultaneously.
    /// </item>
    /// <item>
    /// A player cannot hold the <see cref="TeamStatus.Lock"/> status
    /// in more than one team within the same guild simultaneously.
    /// </item>
    /// <item>
    /// A player cannot be <see cref="TeamStatus.Lock"/> in a team while being
    /// <see cref="TeamStatus.Tryout"/> in another team.
    /// </item>
    /// <item>
    /// Status transitions are performed by closing the current
    /// <see cref="TeamMembership"/> and creating a new one,
    /// preserving the full membership history.
    /// </item>
    /// </list>
    /// </para>
    /// </remarks>
    /// <seealso cref="TeamMembership"/>
    /// <seealso cref="TeamStatus"/>
    /// <seealso cref="TeamRole"/>
    public interface ITeamDomainService
    {
        // -------------------------------------------------------------------------
        // Methods
        // -------------------------------------------------------------------------

        /// <summary>
        /// Adds a player to a team with the specified status and role.
        /// </summary>
        /// <param name="team">
        /// The <see cref="Team"/> to add the player to.
        /// </param>
        /// <param name="player">
        /// The <see cref="Player"/> to add to the team.
        /// </param>
        /// <param name="status">
        /// The initial <see cref="TeamStatus"/> of the player in the team.
        /// </param>
        /// <param name="role">
        /// The <see cref="TeamRole"/> of the player in the team.
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> to observe while waiting for
        /// the asynchronous operation to complete. Defaults to
        /// <see cref="CancellationToken.None"/> if not specified.
        /// </param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation,
        /// containing the newly created <see cref="TeamMembership"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the team already has 5 active
        /// <see cref="TeamStatus.Lock"/> players, or when the player
        /// already holds an incompatible status in another team.
        /// </exception>
        public Task<TeamMembership> AddMemberAsync(Team team, Player player, TeamStatus status, TeamRole role,
            CancellationToken cancellationToken);

        /// <summary>
        /// Promotes a player to a new status within a team.
        /// </summary>
        /// <param name="membership">
        /// The current <see cref="TeamMembership"/> to close.
        /// </param>
        /// <param name="newStatus">
        /// The new <see cref="TeamStatus"/> to assign to the player.
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> to observe while waiting for
        /// the asynchronous operation to complete. Defaults to
        /// <see cref="CancellationToken.None"/> if not specified.
        /// </param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation,
        /// containing the newly created <see cref="TeamMembership"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the status transition is not permitted,
        /// or when the team constraints would be violated.
        /// </exception>
        public Task<TeamMembership> PromoteMemberAsync(TeamMembership membership, TeamStatus newStatus,
            CancellationToken cancellationToken);

        /// <summary>
        /// Removes a player from a team by closing their active membership.
        /// </summary>
        /// <param name="membership">
        /// The active <see cref="TeamMembership"/> to close.
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> to observe while waiting for
        /// the asynchronous operation to complete. Defaults to
        /// <see cref="CancellationToken.None"/> if not specified.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> representing the asynchronous operation.
        /// </returns>
        public Task RemoveMemberAsync(TeamMembership membership, CancellationToken cancellationToken);
    }
}

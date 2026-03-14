// -----------------------------------------------------------------------------
// <copyright file="AuditLog.cs" company="Alma.DiscordBot.Api.Core.Domain">
//   Copyright (c) Alma.DiscordBot.Api.Core.Domain All rights reserved.
// </copyright>
// <author>iMeanBkli</author>
// <created>14/03/2026</created>
// -----------------------------------------------------------------------------

using Alma.DiscordBot.Api.Core.Domain.Entities;

namespace Alma.DiscordBot.Api.Core.Domain.Services
{
    /// <summary>
    /// Defines the contract for player domain operations.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Encapsulates the business rules governing player lifecycle,
    /// including creation, activation, deactivation, and Riot Games
    /// account validation.
    /// </para>
    /// <para>
    /// The following constraints are enforced by this service:
    /// <list type="bullet">
    /// <item>
    /// Only one <see cref="Player"/> can be active per <see cref="User"/>
    /// at a time.
    /// </item>
    /// <item>
    /// A <see cref="Player"/> is linked to a <see cref="User"/> and cannot
    /// exist independently.
    /// </item>
    /// </list>
    /// </para>
    /// </remarks>
    /// <seealso cref="Player"/>
    /// <seealso cref="User"/>
    public interface IPlayerService
    {
        // -------------------------------------------------------------------------
        // Methods
        // -------------------------------------------------------------------------

        /// <summary>
        /// Creates a new player associated with the specified user.
        /// </summary>
        /// <param name="user">
        /// The <see cref="User"/> to associate the player with.
        /// </param>
        /// <param name="riotId">
        /// The Riot Games identifier of the player in the format
        /// <c>Pseudo#TAG</c>.
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> to observe while waiting for
        /// the asynchronous operation to complete.
        /// </param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation,
        /// containing the newly created <see cref="Player"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the user already has an active player.
        /// </exception>
        public Task<Player> CreatePlayerAsync(User user, string riotId, CancellationToken cancellationToken);

        /// <summary>
        /// Links a validated Riot Games PUUID to the specified player.
        /// </summary>
        /// <param name="player">
        /// The <see cref="Player"/> to link the PUUID to.
        /// </param>
        /// <param name="puuid">
        /// The Riot Games PUUID to assign to the player.
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> to observe while waiting for
        /// the asynchronous operation to complete.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> representing the asynchronous operation.
        /// </returns>
        public Task LinkPuuidAsync(Player player, string puuid, CancellationToken cancellationToken);
    }
}

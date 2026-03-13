// -----------------------------------------------------------------------------
// <copyright file="TeamStatus.cs" company="Alma.DiscordBot.Api.Core.Domain">
//   Copyright (c) Alma.DiscordBot.Api.Core.Domain All rights reserved.
// </copyright>
// <author>iMeanBkli</author>
// <created>13/03/2026</created>
// -----------------------------------------------------------------------------

namespace Alma.DiscordBot.Api.Core.Domain.Enums
{
    /// <summary>
    /// Defines the possible status values for a player in a team.
    /// </summary>
    /// <remarks>
    /// <para>
    /// <list type="bullet">
    /// <item>
    /// A player applying for a team is assigned to the <see cref="Tryout"/> status.
    /// </item>
    /// <item>
    /// A player who successfully completed their <see cref="Tryout"/> is set to
    /// <see cref="Lock"/> status.
    /// </item>
    /// <item>
    /// A player with the <see cref="Sub"/> status can replace unavailable players
    /// in a team.
    /// </item>
    /// </list>
    /// </para>
    /// <para>
    /// A player can be <see cref="Lock"/> in a team while being <see cref="Sub"/>
    /// in several teams.
    /// </para>
    /// <para>
    /// A player cannot be <see cref="Lock"/> in a team while being <see cref="Tryout"/>
    /// in another team.
    /// </para>
    /// <para>
    /// A team cannot have more than 5 <see cref="Lock"/> players.
    /// </para>
    /// </remarks>
    /// <seealso cref="TeamMembership"/>
    public enum TeamStatus
    {
        /// <summary>
        /// Represents a player currently on trial within the team.
        /// </summary>
        /// <remarks>
        /// A player with this status is under evaluation by the team staff.
        /// A <see cref="Tryout"/> player may only be promoted to
        /// <see cref="Lock"/> — direct promotion to <see cref="Sub"/>
        /// is not permitted.
        /// Promotion history is preserved via membership lifecycle records.
        /// </remarks>
        Tryout = 0,

        /// <summary>
        /// Represents a confirmed starting player within the team.
        /// </summary>
        /// <remarks>
        /// A team may have at most 5 active <see cref="Lock"/> players
        /// simultaneously.
        /// A <see cref="Lock"/> player may optionally be set to
        /// <see cref="Sub"/> to become available as a substitute
        /// in other teams.
        /// </remarks>
        Lock = 1,

        /// <summary>
        /// Represents a substitute player available to replace
        /// an unavailable <see cref="Lock"/> player in another team.
        /// </summary>
        /// <remarks>
        /// A player may hold the <see cref="Sub"/> status
        /// in multiple teams simultaneously.
        /// A <see cref="Sub"/> player retains their <see cref="Lock"/>
        /// status in their primary team.
        /// </remarks>
        Sub = 2
    }
}

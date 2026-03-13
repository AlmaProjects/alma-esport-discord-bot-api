// -----------------------------------------------------------------------------
// <copyright file="TeamRole.cs" company="Alma.DiscordBot.Api.Core.Domain">
//   Copyright (c) Alma.DiscordBot.Api.Core.Domain All rights reserved.
// </copyright>
// <author>iMeanBkli</author>
// <created>13/03/2026</created>
// -----------------------------------------------------------------------------

namespace Alma.DiscordBot.Api.Core.Domain.Enums
{
    /// <summary>
    /// Defines the possible League of Legends roles for a player in a team.
    /// </summary>
    /// <remarks>
    /// <para>
    /// In League of Legends each role is assigned to a specific lane and function
    /// during the game. Roles are defined as follows:
    /// <list type="bullet">
    /// <item>
    /// Toplaner (Top)
    /// </item>
    /// <item>
    /// Jungler (Jungle)
    /// </item>
    /// <item>
    /// Midlaner (Mid)
    /// </item>
    /// <item>
    /// AD Carry (Adc)
    /// </item>
    /// <item>
    /// Supporter (Support)
    /// </item>
    /// </list>
    /// </para>
    /// <para>
    /// A player can be assigned to one role in their main team.
    /// </para>
    /// <para>
    /// A player can play a different role as a <see cref="TeamStatus.Sub"/> in other
    /// teams.
    /// </para>
    /// </remarks>
    /// <seealso cref="TeamMembership"/>
    public enum TeamRole
    {
        /// <summary>
        /// Represents a player with the Toplaner role.
        /// </summary>
        Top = 0,

        /// <summary>
        /// Represents a player with the Jungler role.
        /// </summary>
        Jungle = 1,

        /// <summary>
        /// Represents a player with the Midlaner role.
        /// </summary>
        Mid = 2,

        /// <summary>
        /// Represents a player with the AD Carry role.
        /// </summary>
        Adc = 3,

        /// <summary>
        /// Represents a player with the Supporter role.
        /// </summary>
        Support = 4
    }
}

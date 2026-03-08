// -----------------------------------------------------------------------------
// <copyright file="Snowflake.cs" company="ALMA Esports Discord Bot Api">
//   Copyright (c) ALMA Esports Discord Bot Api. All rights reserved.
// </copyright>
// <author>iMeanBkli</author>
// <created>2026-03-08</created>
// -----------------------------------------------------------------------------

namespace Alma.DiscordBot.Api.Core.Abstractions.Interfaces
{
    /// <summary>
    /// Defines the contract for
    /// </summary>
    public interface IAuditable
    {
        /// <summary>
        /// Gets or inits
        /// </summary>
        public DateTime CreatedAt { get; init; }

        /// <summary>
        /// Gets or sets
        /// </summary>
        public DateTime? UpdatedAt { get; set; }
    }
}

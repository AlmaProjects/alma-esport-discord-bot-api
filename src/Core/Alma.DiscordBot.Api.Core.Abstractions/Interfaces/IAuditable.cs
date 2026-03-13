// -----------------------------------------------------------------------------
// <copyright file="IAuditable.cs" company="Alma.DiscordBot.Api.Core.Abstractions">
//   Copyright (c) Alma.DiscordBot.Api.Core.Abstractions All rights reserved.
// </copyright>
// <author>iMeanBkli</author>
// <created>2026-03-08</created>
// -----------------------------------------------------------------------------

namespace Alma.DiscordBot.Api.Core.Abstractions.Interfaces
{
    /// <summary>
    /// Defines the contract for auditable entities, tracking UTC timestamps
    /// for creation and last update.
    /// </summary>
    /// <remarks>
    /// Entities implementing this interface expose two temporal markers -
    /// <see cref="CreatedAt"/> which is set once at creation and never modified,
    /// and <see cref="UpdatedAt"/> which is automatically maintained by EF Core
    /// on every update operation.
    /// </remarks>
    /// <seealso cref="IIdentifiable{TId}"/>
    /// <see cref="ISoftDeletable"/>
    public interface IAuditable
    {
        /// <summary>
        /// Gets the entity's creation UTC timestamp.
        /// </summary>
        /// <value>
        /// A <see cref="DateTime"/> representing the UTC timestamp at which
        /// the entity was created. This value is set once and never modified.
        /// </value>
        public DateTime CreatedAt { get; }

        /// <summary>
        /// Gets the entity's last update UTC timestamp.
        /// </summary>
        /// <value>
        /// A <see cref="DateTime"/> representing the UTC timestamp at which
        /// the entity was last updated, or <see langword="null"/> if the
        /// entity has never been updated.
        /// otherwise <see langword="null" />.
        /// </value>
        public DateTime? UpdatedAt { get; }
    }
}

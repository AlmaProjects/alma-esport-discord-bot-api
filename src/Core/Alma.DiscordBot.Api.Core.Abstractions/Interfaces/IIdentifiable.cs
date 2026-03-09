// -----------------------------------------------------------------------------
// <copyright file="IIdentifiable.cs" company="Alma.DiscordBot.Api.Core.Abstractions">
//   Copyright (c) Alma.DiscordBot.Api.Core.Abstractions All rights reserved.
// </copyright>
// <author>iMeanBkli</author>
// <created>2026-03-07</created>
// -----------------------------------------------------------------------------

using Alma.DiscordBot.Api.Core.Abstractions.ValueObjects;

namespace Alma.DiscordBot.Api.Core.Abstractions.Interfaces
{
    /// <summary>
    /// Defines the contract for entities that carry a strongly-typed identifier.
    /// </summary>
    /// <typeparam name="TId">
    /// The type of the identifier. Must implement <see cref="IId"/>.
    /// </typeparam>
    /// <remarks>
    /// All domain entities must implement this interface to ensure consistent
    /// identity management across the system.
    /// </remarks>
    public interface IIdentifiable<TId> where TId : IId
    {
        /// <summary>
        /// Gets or inits the unique identifier of the entity.
        /// </summary>
        public TId Id { get; init; }
    }
}

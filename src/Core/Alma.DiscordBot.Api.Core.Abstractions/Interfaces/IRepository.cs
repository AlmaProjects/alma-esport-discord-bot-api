// -----------------------------------------------------------------------------
// <copyright file="IRepository.cs" company="Alma.DiscordBot.Api.Core.Abstractions">
//   Copyright (c) Alma.DiscordBot.Api.Core.Abstractions All rights reserved.
// </copyright>
// <author>iMeanBkli</author>
// <created>2026-03-08</created>
// -----------------------------------------------------------------------------

using Alma.DiscordBot.Api.Core.Abstractions.ValueObjects;

namespace Alma.DiscordBot.Api.Core.Abstractions.Interfaces
{
    /// <summary>
    /// Defines the contract for generic repository operations
    /// providing basic persistence capabilities for domain entities.
    /// </summary>
    /// <typeparam name="TEntity">
    /// The type of the entity managed by this repository.
    /// Must implement <see cref="IIdentifiable{TId}"/> to guarantee
    /// the presence of a strongly-typed identifier.
    /// </typeparam>
    /// <typeparam name="TId">
    /// The type of the entity identifier.
    /// Must implement <see cref="IId"/> to ensure only domain-approved
    /// identifier types are used.
    /// </typeparam>
    /// <remarks>
    /// This interface defines the minimum persistence contract shared accross
    /// all repositories in the system. Infrastructure-specific query methods
    /// must be declared in dedicated repository interfaces extending this contract.
    /// </remarks>
    /// <seealso cref="IIdentifiable{TId}"/>
    /// <seealso cref="IId"/>
    public interface IRepository<TEntity, TId>
        where TEntity : IIdentifiable<TId>
        where TId : IId
    {
        /// <summary>
        /// Retrieves an entity by its unique identifier.
        /// </summary>
        /// <param name="id">
        /// The unique identifier of the entity to retrieve.
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> to observe while waiting for
        /// the asynchronous operation to complete. Defaults to
        /// <see cref="CancellationToken.None"/> if not specified.
        /// </param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation,
        /// containing the matching <typeparamref name="TEntity"/> if found;
        /// otherwise <see langword="null"/>
        /// </returns>
        public Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken);
    }
}

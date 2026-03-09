// -----------------------------------------------------------------------------
// <copyright file="ISoftDeletable.cs" company="Alma.DiscordBot.Api.Core.Abstractions">
//   Copyright (c) Alma.DiscordBot.Api.Core.Abstractions All rights reserved.
// </copyright>
// <author>iMeanBkli</author>
// <created>2026-03-08</created>
// -----------------------------------------------------------------------------

namespace Alma.DiscordBot.Api.Core.Abstractions.Interfaces
{
    /// <summary>
    /// Defines the contract for soft deletable entities.
    /// </summary>
    /// <remarks>
    /// A soft delete marks an entity as inactive without physically removing it
    /// from the database, allowing deactivated data to be recovered if necessary.
    /// <para>
    /// Soft deletion is performed by setting <see cref="IsActive"/> to <see langword="false"/>
    /// and <see cref="DeletedAt"/> to the current UTC timestamp.
    /// </para>
    /// <para>
    /// Entities implementing this interface are automatically excluded from query
    /// results via the global query filter defined in <c>AppDbContext</c>.
    /// </para>
    /// </remarks>
    /// <seealso cref="IIdentifiable{TId}"/>
    /// <seealso cref="IAuditable"/>
    public interface ISoftDeletable
    {
        /// <summary>
        /// Gets a value indicating whether the entity is active.
        /// </summary>
        /// <value>
        /// <see langword="true"/> if the entity is active, making it visible in
        /// query results; otherwise <see langword="false"/>, making it invisible
        /// in query results.
        /// </value>
        public bool IsActive { get; }

        /// <summary>
        /// Gets the entity's deactivation UTC timestamp.
        /// </summary>
        /// <value>
        /// The UTC timestamp if <see cref="IsActive"/> is <see langword="false"/>;
        /// otherwise <see langword="null"/>.
        /// </value>
        public DateTime? DeletedAt { get; }

        /// <summary>
        /// Reactivates the entity.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Calling this method on a inactive entity sets <see cref="IsActive"/>
        /// to <see langword="true"/> and <see cref="DeletedAt" /> to <see langword="null"/>
        /// making it visible again in query results.
        /// </para>
        /// <para>
        /// Calling this method on an already active entity has no effect.
        /// </para>
        /// <para>
        /// Reactivation history is tracked via <see cref="AuditLog"/>.
        /// </para>
        /// </remarks>
        /// <seealso cref="Deactivate" />
        public void Activate();

        /// <summary>
        /// Deactivates the entity.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Calling this method on an active entity sets <see cref="IsActive"/>
        /// to <see langword="false"/> and <see cref="DeletedAt"/> to the current
        /// UTC timestamp, making it invisible in query results.
        /// </para>
        /// <para>
        /// Calling this method on an already inactive entity has no effect.
        /// </para>
        /// <para>
        /// Deactivation history is tracked via <see cref="AuditLog"/>.
        /// </para>
        /// </remarks>
        /// <seealso cref="Activate"/>
        public void Deactivate();
    }
}

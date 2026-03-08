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
    /// Defines the contract for soft deletable entities.
    /// </summary>
    /// <remarks>
    /// A soft delete marks a record as no longer active without actually deleting
    /// it from the database, allowing deactivated data to be recovered if necessary.
    /// <para>
    /// Soft deletion is performed by setting <see cref="IsActive" /> to <see langword="false" />
    /// and <see cref="DeletedAt" /> to the current UTC timestamp.
    /// </para>
    /// <para>
    /// Entities implementing this interface are automatically excluded from query
    /// results via the global query filter defined in <c>AppDbContext</c>.
    /// </para>
    /// </remarks>
    /// <seealso cref="IIdentifiable{TId}" />
    /// <seealso cref="IAuditable" />
    public interface ISoftDeletable
    {
        /// <summary>
        /// 
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? DeletedAt { get; set; }
    }
}

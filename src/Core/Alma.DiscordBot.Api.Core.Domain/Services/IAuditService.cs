// -----------------------------------------------------------------------------
// <copyright file="AuditLog.cs" company="Alma.DiscordBot.Api.Core.Domain">
//   Copyright (c) Alma.DiscordBot.Api.Core.Domain All rights reserved.
// </copyright>
// <author>iMeanBkli</author>
// <created>14/03/2026</created>
// -----------------------------------------------------------------------------

using Alma.DiscordBot.Api.Core.Abstractions.ValueObjects;
using Alma.DiscordBot.Api.Core.Domain.Entities;
using Alma.DiscordBot.Api.Core.Domain.Enums;

namespace Alma.DiscordBot.Api.Core.Domain.Services
{
    /// <summary>
    /// Defines the contract for audit trail operations.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Encapsulates the creation of <see cref="AuditLog"/> entries whenever
    /// a significant domain event occurs in the system.
    /// </para>
    /// <para>
    /// Audit log entries are immutable — they are never modified or deleted
    /// after creation.
    /// </para>
    /// </remarks>
    /// <seealso cref="AuditLog"/>
    /// <seealso cref="AuditAction"/>
    public interface IAuditService
    {
        // -------------------------------------------------------------------------
        // Methods
        // -------------------------------------------------------------------------

        /// <summary>
        /// Records a domain event in the audit trail.
        /// </summary>
        /// <param name="guildId">
        /// The <see cref="Snowflake"/> identifier of the guild
        /// in which the event occurred.
        /// </param>
        /// <param name="actorId">
        /// The <see cref="Snowflake"/> identifier of the actor
        /// who triggered the event.
        /// </param>
        /// <param name="action">
        /// The <see cref="AuditAction"/> value representing the type
        /// of event that occurred.
        /// </param>
        /// <param name="entityType">
        /// The type name of the entity affected by the action.
        /// </param>
        /// <param name="entityId">
        /// The identifier of the affected entity, serialized as a string.
        /// </param>
        /// <param name="payload">
        /// A JSON snapshot of the entity state before and after the action.
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> to observe while waiting for
        /// the asynchronous operation to complete.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> representing the asynchronous operation.
        /// </returns>
        public Task RecordAsync(Snowflake guildId, Snowflake actorId, AuditAction action, string entityType, string entityId, string payload, CancellationToken cancellationToken);
    }
}

// -----------------------------------------------------------------------------
// <copyright file="AuditLog.cs" company="$projectname$">
//   Copyright (c) $projectname$. All rights reserved.
// </copyright>
// <author>$author$</author>
// <created>13/03/2026 16:15:04</created>
// -----------------------------------------------------------------------------

using Alma.DiscordBot.Api.Core.Abstractions.Interfaces;
using Alma.DiscordBot.Api.Core.Abstractions.ValueObjects;

using Alma.DiscordBot.Api.Core.Domain.Enums;

namespace Alma.DiscordBot.Api.Core.Domain.Entities
{
    /// <summary>
    /// Represents an audit trail entry recording a significant domain event.
    /// </summary>
    /// <remarks>
    /// <para>
    /// An <see cref="AuditLog"/> entry is created whenever a significant domain
    /// event occurs in the system. It records who triggered the action, on which
    /// entity, and captures a JSON snapshot of the state before and after
    /// the action.
    /// </para>
    /// <para>
    /// Audit log entries are immutable — they are never modified or deleted
    /// after creation.
    /// </para>
    /// </remarks>
    /// <seealso cref="IIdentifiable{TId}"/>
    /// <seealso cref="AuditAction"/>
    public sealed class AuditLog : IIdentifiable<SurrogateId>
    {
        // -------------------------------------------------------------------------
        // Identity
        // -------------------------------------------------------------------------

        /// <inheritdoc/>
        public SurrogateId Id { get; init; }

        /// <summary>
        /// Gets the Discord identifier of the guild in which the event occurred.
        /// </summary>
        /// <value>
        /// A <see cref="Snowflake"/> representing the Discord-assigned guild ID.
        /// </value>
        public Snowflake GuildId { get; init; }

        /// <summary>
        /// Gets the Discord identifier of the actor who triggered the event.
        /// </summary>
        /// <value>
        /// A <see cref="Snowflake"/> representing the Discord-assigned user ID
        /// of the actor.
        /// </value>
        public Snowflake ActorId { get; init; }

        /// <summary>
        /// Gets the action that was performed.
        /// </summary>
        /// <value>
        /// An <see cref="AuditAction"/> value representing the type of event
        /// that occurred.
        /// </value>
        public AuditAction Action { get; init; }

        /// <summary>
        /// Gets the type name of the entity affected by the action.
        /// </summary>
        /// <value>
        /// A <see cref="string"/> representing the fully qualified or simple
        /// type name of the affected entity.
        /// </value>
        public string EntityType { get; init; } = string.Empty;

        /// <summary>
        /// Gets the identifier of the entity affected by the action.
        /// </summary>
        /// <value>
        /// A <see cref="string"/> representing the affected entity's ID,
        /// serialized as a string regardless of its underlying type.
        /// </value>
        public string EntityId { get; init; } = string.Empty;

        /// <summary>
        /// Gets the JSON snapshot of the entity state before and after the action.
        /// </summary>
        /// <value>
        /// A <see cref="string"/> containing a JSON representation of the entity
        /// state at the time of the event.
        /// </value>
        public string Payload { get; init; } = string.Empty;

        // -------------------------------------------------------------------------
        // Audit
        // -------------------------------------------------------------------------

        /// <summary>
        /// Gets the UTC timestamp at which this audit entry was created.
        /// </summary>
        /// <value>
        /// A <see cref="DateTime"/> representing the UTC timestamp
        /// at which the event was recorded.
        /// </value>
        public DateTime CreatedAt { get; init; }
    }
}

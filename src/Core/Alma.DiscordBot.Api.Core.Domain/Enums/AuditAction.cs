// -----------------------------------------------------------------------------
// <copyright file="AuditAction.cs" company="Alma.DiscordBot.Api.Core.Domain">
//   Copyright (c) Alma.DiscordBot.Api.Core.Domain All rights reserved.
// </copyright>
// <author>iMeanBkli</author>
// <created>13/03/2026</created>
// -----------------------------------------------------------------------------

namespace Alma.DiscordBot.Api.Core.Domain.Enums
{
    /// <summary>
    /// Defines the possible action values recorded in the audit trail.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Each value represents a significant domain event that occurred in the system.
    /// When a domain event is triggered, an <see cref="AuditLog"/> entry is created
    /// with the corresponding <see cref="AuditAction"/> value, the actor who triggered
    /// it, the affected entity, and a JSON snapshot of the state before and after
    /// the action.
    /// </para>
    /// </remarks>
    /// <seealso cref="AuditLog"/>
    public enum AuditAction
    {
    }
}

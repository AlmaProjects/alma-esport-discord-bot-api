// -----------------------------------------------------------------------------
// <copyright file="IId.cs" company="Alma.DiscordBot.Api.Core.Abstractions">
//   Copyright (c) Alma.DiscordBot.Api.Core.Abstractions All rights reserved.
// </copyright>
// <author>iMeanBkli</author>
// <created>2026-03-07</created>
// -----------------------------------------------------------------------------

namespace Alma.DiscordBot.Api.Core.Abstractions.ValueObjects
{
    /// <summary>
    /// Defines the marker contract for strongly-typed identifier value objects.
    /// </summary>
    /// <remarks>
    /// This interface acts as a type constraint ensuring that only domain-approved
    /// identifier types are accepted where an identifier is expected.
    /// </remarks>
    /// <seealso cref="Uuid"/>
    /// <seealso cref="Snowflake"/>
    public interface IId;
}

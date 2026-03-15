// -----------------------------------------------------------------------------
// <copyright file="AppDbContext.cs" company="Alma.DiscordBot.Api.Infrastructure">
//   Copyright (c) Alma.DiscordBot.Api.Infrastructure All rights reserved.
// </copyright>
// <author>iMeanBkli</author>
// <created>15/03/2026</created>
// -----------------------------------------------------------------------------

using Alma.DiscordBot.Api.Core.Abstractions.ValueObjects;

using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Alma.DiscordBot.Api.Infrastructure.Persistence.Converters;

/// <summary>
/// Converts a <see cref="Uuid"/> value object to and from
/// its underlying <see cref="Guid"/> representation for persistence.
/// </summary>
public sealed class UuidConverter : ValueConverter<Uuid, Guid>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UuidConverter"/> class.
    /// </summary>
    public UuidConverter()
        : base(uuid => uuid.Value, value => new Uuid(value))
    {
    }
}

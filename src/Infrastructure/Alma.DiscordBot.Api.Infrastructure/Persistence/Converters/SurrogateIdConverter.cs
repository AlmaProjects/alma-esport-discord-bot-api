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
/// Converts a <see cref="SurrogateId"/> value object to and from
/// its underlying <see cref="int"/> representation for persistence.
/// </summary>
public sealed class SurrogateIdConverter : ValueConverter<SurrogateId, int>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SurrogateIdConverter"/> class.
    /// </summary>
    public SurrogateIdConverter()
        : base(surrogateId => surrogateId.Value, value => new SurrogateId(value))
    {
    }
}

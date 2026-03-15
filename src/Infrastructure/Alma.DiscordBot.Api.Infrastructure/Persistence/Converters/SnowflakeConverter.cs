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
/// Converts a <see cref="Snowflake"/> value object to and from
/// its underlying <see cref="long"/> representation for persistence.
/// </summary>
public sealed class SnowflakeConverter : ValueConverter<Snowflake, long>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SnowflakeConverter"/> class.
    /// </summary>
    public SnowflakeConverter()
        : base(snowflake => snowflake.Value, value => new Snowflake(value))
    {
    }
}

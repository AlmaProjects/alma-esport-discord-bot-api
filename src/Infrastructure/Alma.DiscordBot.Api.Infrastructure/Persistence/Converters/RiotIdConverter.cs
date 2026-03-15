// -----------------------------------------------------------------------------
// <copyright file="AppDbContext.cs" company="Alma.DiscordBot.Api.Infrastructure">
//   Copyright (c) Alma.DiscordBot.Api.Infrastructure All rights reserved.
// </copyright>
// <author>iMeanBkli</author>
// <created>15/03/2026</created>
// -----------------------------------------------------------------------------

using Alma.DiscordBot.Api.Core.Domain.ValueObjects;

using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Alma.DiscordBot.Api.Infrastructure.Persistence.Converters;

/// <summary>
/// Converts a <see cref="RiotId"/> value object to and from
/// its underlying <see cref="string"/> representation for persistence.
/// </summary>
/// <remarks>
/// <para>
/// A <see cref="RiotId"/> is persisted as a single <see cref="string"/>
/// in the format <c>GameName#TagLine</c>.
/// </para>
/// <para>
/// The conversion back from <see cref="string"/> uses
/// <see cref="RiotId.From"/> to ensure structural validation
/// is applied on read.
/// </para>
/// </remarks>
public sealed class RiotIdConverter : ValueConverter<RiotId, string>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RiotIdConverter"/> class.
    /// </summary>
    public RiotIdConverter()
        : base(riotId => riotId.ToString(), value => RiotId.From(value))
    {
    }
}

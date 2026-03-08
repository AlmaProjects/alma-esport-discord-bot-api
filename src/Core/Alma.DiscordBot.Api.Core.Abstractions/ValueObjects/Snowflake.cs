// -----------------------------------------------------------------------------
// <copyright file="Snowflake.cs" company="ALMA Esports Discord Bot Api">
//   Copyright (c) ALMA Esports Discord Bot Api. All rights reserved.
// </copyright>
// <author>iMeanBkli</author>
// <created>2026-03-07</created>
// -----------------------------------------------------------------------------

namespace Alma.DiscordBot.Api.Core.Abstractions.ValueObjects
{
    /// <summary>
    /// Represents a Discord Snowflake identifier - a 64-bit unique ID
    /// used by Discord to identify users, guilds, channels, and messages.
    /// </summary>
    /// <remarks>
    /// A Snowflake is guaranteed to be positive and non-zero.
    /// It encodes a timestamp, worker ID, and sequence number,
    /// making it both unique and time-sortable.
    /// See <see href="https://discord.com/developers/docs/reference#snowflakes">Discord Documentation</see>
    /// </remarks>
    /// <example>
    /// Creating a Snowflake from a Discord user ID:
    /// <code>
    /// var userId = new Snowflake(123456789012345678L);
    /// long raw = userId; // implicit conversion
    /// </code>
    /// </example>
    public readonly struct Snowflake : IId, IEquatable<Snowflake>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Snowflake" /> struct
        /// with the specified raw value.
        /// </summary>
        /// <param name="value">
        /// The raw 64-bit Discord Snowflake value. Must be strictly positive.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="value" /> is zero or negative.
        /// </exception>
        public Snowflake(long value) 
        {
            if (value <= 0)
            {
                throw new ArgumentException("Snowflake value must be positive.", nameof(value));
            }

            Value = value;
        }

        /// <summary>
        /// Gets the raw 64-bit value of the Snowflake identifier.
        /// </summary>
        /// <value>
        /// A positive <see cref="long" /> representing the Discord-assigned ID.
        /// </value>
        public long Value { get; }

        /// <summary>
        /// Determines whether the current Snowflake is equal to another Snowflake.
        /// </summary>
        /// <param name="other">
        /// The <see cref="Snowflake"/> to compare with the current instance.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if both Snowflakes share the same value;
        /// otherwise <see langword="false" />.
        /// </returns>
        public bool Equals(Snowflake other) => Value == other.Value;

        public override bool Equals(object? obj) => obj is Snowflake other && Equals(other);

        public override int GetHashCode() => Value.GetHashCode();

        public override string ToString() => Value.ToString();

        public static implicit operator long(Snowflake snowflake) => snowflake.Value;

        public static explicit operator Snowflake(long value) => new(value);

        public static bool operator ==(Snowflake left, Snowflake right) => left.Equals(right);

        public static bool operator !=(Snowflake left, Snowflake right) => !left.Equals(right);
    }
}

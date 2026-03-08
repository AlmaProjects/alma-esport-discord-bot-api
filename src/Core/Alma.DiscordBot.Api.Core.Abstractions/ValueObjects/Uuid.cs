// -----------------------------------------------------------------------------
// <copyright file="Snowflake.cs" company="ALMA Esports Discord Bot Api">
//   Copyright (c) ALMA Esports Discord Bot Api. All rights reserved.
// </copyright>
// <author>iMeanBkli</author>
// <created>2026-03-08</created>
// -----------------------------------------------------------------------------

namespace Alma.DiscordBot.Api.Core.Abstractions.ValueObjects
{
    /// <summary>
    /// Represents a Universal Unique IDentifier.
    /// </summary>
    /// <remarks>
    /// A Uuid
    /// </remarks>
    /// <example>
    /// Creating a Uuid from <see cref="Guid.NewGuid()"/>:
    /// <code>
    /// var uuid = new Uuid(Guid.NewGuid());
    /// Guid raw = uuid;
    /// </code>
    /// </example>
    public readonly struct Uuid : IId, IEquatable<Uuid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Uuid"/> struct
        /// with a generated raw value.
        /// </summary>
        public Uuid() : this(Guid.NewGuid())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Uuid" /> struct
        /// with the specified raw value.
        /// </summary>
        /// <param name="value">
        /// The raw <see cref="Guid" /> value.
        /// </param>
        public Uuid(Guid value)
        {
            Value = value;
        }

        /// <summary>
        /// Gets the raw Guid value of the Uuid identifier.
        /// </summary>
        /// <value>
        /// A <see cref="Guid"/> representing the Uuid.
        /// </value>
        public Guid Value { get; }

        /// <summary>
        /// Determines whether the current Uuid is equal to another Uuid.
        /// </summary>
        /// <param name="other">
        /// The <see cref="Uuid" /> to compare with the current instance.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if both Uuids share the same value;
        /// otherwise <see langword="false" />.
        /// </returns>
        public bool Equals(Uuid other) => Value == other.Value;

        public override bool Equals(object? obj) => obj is Uuid other && Equals(other);

        public override int GetHashCode() => Value.GetHashCode();

        public override string ToString() => Value.ToString();

        public static implicit operator Guid(Uuid value) => value.Value;

        public static explicit operator Uuid(Guid value) => new(value);

        public static bool operator ==(Uuid left, Uuid right) => left.Equals(right);

        public static bool operator !=(Uuid left, Uuid right) => !left.Equals(right);
    }
}

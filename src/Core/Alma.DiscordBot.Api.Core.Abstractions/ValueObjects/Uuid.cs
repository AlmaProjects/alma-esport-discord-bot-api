// -----------------------------------------------------------------------------
// <copyright file="Uuid.cs" company="Alma.DiscordBot.Api.Core.Abstractions">
//   Copyright (c) Alma.DiscordBot.Api.Core.Abstractions All rights reserved.
// </copyright>
// <author>iMeanBkli</author>
// <created>2026-03-08</created>
// -----------------------------------------------------------------------------

namespace Alma.DiscordBot.Api.Core.Abstractions.ValueObjects
{
    /// <summary>
    /// Represents a UUID v4 identifier - a randomly generated 128-bit
    /// universally unique identifier.
    /// </summary>
    /// <remarks>
    /// A Uuid wraps a <see cref="Guid"/> value generated via <see cref="Guid.NewGuid"/>,
    /// which produces a RFC 4122 compliant UUID v4 identifier. It is compatible with JSON
    /// schema validators expecting a standard UUID format.
    /// <para>
    /// See the RFC 4122 specification:
    /// <see href="https://www.rfc-editor.org/rfc/rfc4122"/>
    /// </para>
    /// </remarks>
    /// <example>
    /// Creating a Uuid with an auto-generated value:
    /// <code>
    /// var uuid = new Uuid();
    /// Guid raw = uuid; // implicit conversion
    /// </code>
    /// Creating a Uuid from an existing <see cref="Guid"/>:
    /// <code>
    /// var uuid = new Uuid(existingGuid);
    /// </code>
    /// </example>
    /// <seealso cref="IId"/>
    /// <seealso cref="Snowflake"/>
    /// <seealso cref="SurrogateId"/>
    public readonly struct Uuid : IId, IEquatable<Uuid>
    {
        // -------------------------------------------------------------------------
        // Constructor
        // -------------------------------------------------------------------------

        /// <summary>
        /// Initializes a new instance of the <see cref="Uuid"/> struct
        /// with a randomly generated value.
        /// </summary>
        /// <remarks>
        /// Equivalent to calling <c>new Uuid(<see cref="Guid.NewGuid"/>())</c>.
        /// </remarks>
        public Uuid() : this(Guid.NewGuid())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Uuid"/> struct
        /// with the specified raw value.
        /// </summary>
        /// <param name="value">
        /// The raw <see cref="Guid"/> value to wrap.
        /// </param>
        public Uuid(Guid value)
        {
            Value = value;
        }

        // -------------------------------------------------------------------------
        // Properties
        // -------------------------------------------------------------------------

        /// <summary>
        /// Gets the raw value of this <see cref="Uuid"/> identifier.
        /// </summary>
        /// <value>
        /// A <see cref="Guid"/> representing the underlying UUID v4 value.
        /// </value>
        public Guid Value { get; }

        // -------------------------------------------------------------------------
        // Equality
        // -------------------------------------------------------------------------

        /// <summary>
        /// Determines whether the current <see cref="Uuid"/> is equal to another <see cref="Uuid"/>.
        /// </summary>
        /// <param name="other">
        /// The <see cref="Uuid"/> to compare with the current instance.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if both instances share the same value;
        /// otherwise <see langword="false"/>.
        /// </returns>
        public bool Equals(Uuid other) => Value == other.Value;

        /// <inheritdoc/>
        public override bool Equals(object? obj) => obj is Uuid other && Equals(other);

        /// <inheritdoc/>
        public override int GetHashCode() => Value.GetHashCode();

        /// <inheritdoc/>
        public override string ToString() => Value.ToString();

        // -------------------------------------------------------------------------
        // Operators
        // -------------------------------------------------------------------------

        /// <summary>
        /// Implicitly converts a <see cref="Uuid"/> to its raw <see cref="Guid"/> value.
        /// </summary>
        /// <param name="value">The <see cref="Uuid"/> to convert.</param>
        /// <returns>The raw underlying <see cref="Guid"/> value.</returns>
        public static implicit operator Guid(Uuid value) => value.Value;

        /// <summary>
        /// Explicitly converts a <see cref="Guid"/> to a <see cref="Uuid"/>.
        /// </summary>
        /// <param name="value">The raw <see cref="Guid"/> value to convert.</param>
        /// <returns>A new <see cref="Uuid"/> wrapping the provided value.</returns>
        public static explicit operator Uuid(Guid value) => new(value);

        /// <summary>
        /// Determines whether two <see cref="Uuid"/> instances are equal.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// <see langword="true"/> if both instances are equal;
        /// otherwise <see langword="false"/>.
        /// </returns>
        public static bool operator ==(Uuid left, Uuid right) => left.Equals(right);

        /// <summary>
        /// Determines whether two <see cref="Uuid"/> instances are not equal.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// <see langword="true"/> if both instances differ;
        /// otherwise <see langword="false"/>.
        /// </returns>
        public static bool operator !=(Uuid left, Uuid right) => !left.Equals(right);
    }
}

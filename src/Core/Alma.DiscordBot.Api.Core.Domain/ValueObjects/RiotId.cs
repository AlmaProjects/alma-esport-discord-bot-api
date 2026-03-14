// -----------------------------------------------------------------------------
// <copyright file="RiotId.cs" company="Alma.DiscordBot.Api.Core.Domain">
//   Copyright (c) Alma.DiscordBot.Api.Core.Domain All rights reserved.
// </copyright>
// <author>iMeanBkli</author>
// <created>14/03/2026</created>
// -----------------------------------------------------------------------------

using Alma.DiscordBot.Api.Core.Domain.Entities;
using Alma.DiscordBot.Api.Framework.Patterns.Behavioral;

namespace Alma.DiscordBot.Api.Core.Domain.ValueObjects
{
    /// <summary>
    /// Represents a Riot Games identifier for a League of Legends player.
    /// </summary>
    /// <remarks>
    /// <para>
    /// A <see cref="RiotId"/> is composed of a game name and a tag line,
    /// separated by a <c>#</c> character, following the format
    /// <c>GameName#TagLine</c>.
    /// </para>
    /// <para>
    /// The following constraints are enforced at instantiation:
    /// <list type="bullet">
    /// <item>
    /// The game name must be between 3 and 16 Unicode characters.
    /// </item>
    /// <item>
    /// The tag line must be between 3 and 5 Unicode characters.
    /// </item>
    /// <item>
    /// The <c>#</c> separator must be present.
    /// </item>
    /// </list>
    /// </para>
    /// <para>
    /// Charset conformance and uniqueness are not validated locally —
    /// they are delegated to the Riot Games API upon PUUID validation.
    /// </para>
    /// </remarks>
    /// <example>
    /// Creating a RiotId from a game name and tag line:
    /// <code>
    /// var riotId = new RiotId("Faker", "KR1");
    /// string raw = riotId; // implicit conversion → "Faker#KR1"
    /// </code>
    /// </example>
    /// <seealso cref="Player"/>
    public readonly struct RiotId : IEquatable<RiotId>, IParser<string, RiotId>
    {
        // -------------------------------------------------------------------------
        // Constants
        // -------------------------------------------------------------------------

        /// <summary>
        /// Represents the minimum number of Unicode characters allowed
        /// for the game name.
        /// </summary>
        public const int GAME_NAME_MIN_LENGTH = 3;

        /// <summary>
        /// Represents the maximum number of Unicode characters allowed
        /// for the game name.
        /// </summary>
        public const int GAME_NAME_MAX_LENGTH = 16;

        /// <summary>
        /// Represents the minimum number of Unicode characters allowed
        /// for the tag line.
        /// </summary>
        public const int TAG_LINE_MIN_LENGTH = 3;

        /// <summary>
        /// Represents the maximum number of Unicode characters allowed
        /// for the tag line.
        /// </summary>
        public const int TAG_LINE_MAX_LENGTH = 5;

        /// <summary>
        /// Represents the separator character between the game name
        /// and the tag line.
        /// </summary>
        public const char SEPARATOR = '#';

        // -------------------------------------------------------------------------
        // Constructor
        // -------------------------------------------------------------------------

        /// <summary>
        /// Initializes a new instance of the <see cref="RiotId"/> struct
        /// with the specified game name and tag line.
        /// </summary>
        /// <param name="gameName">
        /// The game name part of the Riot ID. Must be between
        /// <see cref="GAME_NAME_MIN_LENGTH"/> and
        /// <see cref="GAME_NAME_MAX_LENGTH"/> Unicode characters.
        /// </param>
        /// <param name="tagLine">
        /// The tag line part of the Riot ID. Must be between
        /// <see cref="TAG_LINE_MIN_LENGTH"/> and
        /// <see cref="TAG_LINE_MAX_LENGTH"/> Unicode characters.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="gameName"/> or <paramref name="tagLine"/>
        /// does not meet the length constraints.
        /// </exception>
        public RiotId(string gameName, string tagLine)
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(gameName, nameof(gameName));
            ArgumentNullException.ThrowIfNullOrWhiteSpace(tagLine, nameof(tagLine));

            if (gameName.Length < GAME_NAME_MIN_LENGTH)
            {
                throw new ArgumentException(ErrorMessages.GameNameTooShort(gameName.Length), nameof(gameName));
            }

            if (gameName.Length > GAME_NAME_MAX_LENGTH)
            {
                throw new ArgumentException(ErrorMessages.GameNameTooShort(gameName.Length), nameof(gameName));
            }

            if (tagLine.Length < TAG_LINE_MIN_LENGTH)
            {
                throw new ArgumentException(ErrorMessages.TagLineTooShort(tagLine.Length), nameof(tagLine));
            }

            if (tagLine.Length > TAG_LINE_MAX_LENGTH)
            {
                throw new ArgumentException(ErrorMessages.TagLineTooLong(tagLine.Length), nameof(tagLine));
            }

            GameName = gameName;
            TagLine = tagLine;
        }

        // -------------------------------------------------------------------------
        // Properties
        // -------------------------------------------------------------------------

        /// <summary>
        /// Gets the game name part of this <see cref="RiotId"/>.
        /// </summary>
        /// <value>
        /// A <see cref="string"/> representing the game name.
        /// </value>
        public string GameName { get; }

        /// <summary>
        /// Gets the tag line part of this <see cref="RiotId"/>.
        /// </summary>
        /// <value>
        /// A <see cref="string"/> representing the tag line.
        /// </value>
        public string TagLine { get; }

        // -------------------------------------------------------------------------
        // Equality
        // -------------------------------------------------------------------------

        /// <summary>
        /// Determines whether the current <see cref="RiotId"/> is equal
        /// to another <see cref="RiotId"/>.
        /// </summary>
        /// <param name="other">
        /// The <see cref="RiotId"/> to compare with the current instance.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if both instances share the same game name
        /// and tag line; otherwise <see langword="false"/>.
        /// </returns>
        public bool Equals(RiotId other) => string.Equals(GameName, other.GameName, StringComparison.OrdinalIgnoreCase)
            && string.Equals(TagLine, other.TagLine, StringComparison.OrdinalIgnoreCase);

        /// <inheritdoc/>
        public override bool Equals(object? obj) => obj is RiotId other && Equals(other);

        /// <inheritdoc/>
        public override int GetHashCode() => HashCode.Combine(GameName.ToUpperInvariant(), TagLine.ToUpperInvariant());

        /// <inheritdoc/>
        public override string ToString() => $"{GameName}{SEPARATOR}{TagLine}";

        // -------------------------------------------------------------------------
        // IParser
        // -------------------------------------------------------------------------

        /// <summary>
        /// Creates a new instance of <see cref="RiotId"/> from the specified
        /// string representation.
        /// </summary>
        /// <param name="input">
        /// A <see cref="string"/> in the format <c>GameName#TagLine</c>
        /// representing the Riot ID to parse.
        /// </param>
        /// <returns>
        /// A new <see cref="RiotId"/> instance constructed from the parsed
        /// game name and tag line.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="input"/> does not contain exactly one
        /// <see cref="SEPARATOR"/> character.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when the game name length is not between
        /// <see cref="GAME_NAME_MIN_LENGTH"/> and <see cref="GAME_NAME_MAX_LENGTH"/>,
        /// or when the tag line length is not between
        /// <see cref="TAG_LINE_MIN_LENGTH"/> and <see cref="TAG_LINE_MAX_LENGTH"/>.
        /// </exception>
        /// <example>
        /// Creating a <see cref="RiotId"/> from a string representation:
        /// <code>
        /// RiotId riotId = RiotId.From("Faker#KR1");
        /// </code>
        /// </example>
        public static RiotId From(string input)
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(input, nameof(input));

            if (!input.Contains(SEPARATOR))
            {
                throw new ArgumentException(ErrorMessages.InvalidSeparatorCount(0), nameof(input));
            }

            string[] parts = input.Split(SEPARATOR);

            return parts.Length != 2
                ? throw new ArgumentException(ErrorMessages.InvalidSeparatorCount(parts.Length), nameof(input))
                : new RiotId(parts[0], parts[1]);
        }

        // -------------------------------------------------------------------------
        // Operators
        // -------------------------------------------------------------------------

        /// <summary>
        /// Implicitly converts a <see cref="RiotId"/> to its
        /// <see cref="string"/> representation.
        /// </summary>
        /// <param name="value">The <see cref="RiotId"/> to convert.</param>
        /// <returns>
        /// A <see cref="string"/> in the format <c>GameName#TagLine</c>.
        /// </returns>
        public static implicit operator string(RiotId value) => value.ToString();

        /// <summary>
        /// Determines whether two <see cref="RiotId"/> instances are equal.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// <see langword="true"/> if both instances are equal;
        /// otherwise <see langword="false"/>.
        /// </returns>
        public static bool operator ==(RiotId left, RiotId right) => left.Equals(right);

        /// <summary>
        /// Determines whether two <see cref="RiotId"/> instances are not equal.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// <see langword="true"/> if both instances differ;
        /// otherwise <see langword="false"/>.
        /// </returns>
        public static bool operator !=(RiotId left, RiotId right) => !left.Equals(right);

        // -------------------------------------------------------------------------
        // Messages
        // -------------------------------------------------------------------------

        /// <summary>
        /// Provides error messages for <see cref="RiotId"/> validation failures.
        /// </summary>
        private static class ErrorMessages
        {
            /// <summary>
            /// Returns an error message indicating that the input does not contain
            /// exactly one <see cref="SEPARATOR"/> character.
            /// </summary>
            /// <param name="count">
            /// The number of <see cref="SEPARATOR"/> characters found in the input.
            /// </param>
            /// <returns>
            /// A <see cref="string"/> describing the separator violation.
            /// </returns>
            internal static string InvalidSeparatorCount(int count) => $"RiotId must contain exactly one '{SEPARATOR}' "
                + $"separator, but {(count == 0 ? "none was" : $"{count} were")} found.";

            /// <summary>
            /// Returns an error message indicating that the game name is too short.
            /// </summary>
            /// <param name="length">
            /// The actual length of the game name provided.
            /// </param>
            /// <returns>
            /// A <see cref="string"/> describing the game name minimum length violation.
            /// </returns>
            internal static string GameNameTooShort(int length)
                => $"RiotId game name must be at least {GAME_NAME_MIN_LENGTH} characters, " +
                   $"but {length} were provided.";

            /// <summary>
            /// Returns an error message indicating that the game name is too long.
            /// </summary>
            /// <param name="length">
            /// The actual length of the game name provided.
            /// </param>
            /// <returns>
            /// A <see cref="string"/> describing the game name maximum length violation.
            /// </returns>
            internal static string GameNameTooLong(int length) => $"RiotId game name must be at most " +
                $"{GAME_NAME_MAX_LENGTH} characters, but {length} were provided.";

            /// <summary>
            /// Returns an error message indicating that the tag line is too short.
            /// </summary>
            /// <param name="length">
            /// The actual length of the tag line provided.
            /// </param>
            /// <returns>
            /// A <see cref="string"/> describing the tag line minimum length violation.
            /// </returns>
            internal static string TagLineTooShort(int length) => $"RiotId tag line must be at least " +
                $"{TAG_LINE_MIN_LENGTH} characters, but {length} were provided.";

            /// <summary>
            /// Returns an error message indicating that the tag line is too long.
            /// </summary>
            /// <param name="length">
            /// The actual length of the tag line provided.
            /// </param>
            /// <returns>
            /// A <see cref="string"/> describing the tag line maximum length violation.
            /// </returns>
            internal static string TagLineTooLong(int length) => $"RiotId tag line must be at most " +
                $"{TAG_LINE_MAX_LENGTH} characters, but {length} were provided.";
        }
    }
}

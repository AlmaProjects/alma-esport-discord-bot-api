// -----------------------------------------------------------------------------
// <copyright file="SnowflakeTests.cs" company="Alma.DiscordBot.Api.Core.Abstractions.Tests">
//   Copyright (c) Alma.DiscordBot.Api.Core.Abstractions.Tests All rights reserved.
// </copyright>
// <author>iMeanBkli</author>
// <created>2026-03-07</created>
// -----------------------------------------------------------------------------

using Alma.DiscordBot.Api.Core.Abstractions.ValueObjects;
using FluentAssertions;

namespace Alma.DiscordBot.Api.Core.Abstractions.Tests.ValueObjects
{
    public sealed class SnowflakeTests
    {
        private const long VALID_SNOWFLAKE_VALUE = 123_456_789L;
        private const long ANOTHER_VALID_SNOWFLAKE_VALUE = 987_654_321L;

        // -------------------------------------------------------------------------
        // Constructor
        // -------------------------------------------------------------------------

        [Fact]
        public void Snowflake_WhenCreatedFromNegativeValue_ShouldThrowArgumentException()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            // -------------------------------------
            // Act
            // -------------------------------------

            Action act = () => new Snowflake(-1L);

            // -------------------------------------
            // Assert
            // -------------------------------------

            act.Should().Throw<ArgumentException>().WithParameterName("value");
        }

        [Fact]
        public void Snowflake_WhenCreatedFromZero_ShouldThrowArgumentException()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            // -------------------------------------
            // Act
            // -------------------------------------

            Action act = () => new Snowflake(0L);

            // -------------------------------------
            // Assert
            // -------------------------------------

            act.Should().Throw<ArgumentException>().WithParameterName("value");
        }

        [Fact]
        public void Snowflake_WhenCreatedFromValueBelowMinimum_ShouldThrowArgumentException()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            const long HIGHEST_INVALID_SNOWFLAKE_ID_VALUE = Snowflake.DISCORD_FIRST_SNOWFLAKE_ID - 1;

            // -------------------------------------
            // Act
            // -------------------------------------

            Action act = () => new Snowflake(HIGHEST_INVALID_SNOWFLAKE_ID_VALUE);

            // -------------------------------------
            // Assert
            // -------------------------------------

            act.Should().Throw<ArgumentException>().WithParameterName("value");
        }

        [Fact]
        public void Snowflake_WhenCreatedFromFirstValidValue_ShouldStoreValue()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            // -------------------------------------
            // Act
            // -------------------------------------

            Snowflake target = new(Snowflake.DISCORD_FIRST_SNOWFLAKE_ID);

            // -------------------------------------
            // Assert
            // -------------------------------------

            target.Value.Should().Be(Snowflake.DISCORD_FIRST_SNOWFLAKE_ID);
        }

        [Fact]
        public void Snowflake_WhenCreatedFromValidLong_ShouldStoreValue()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            // -------------------------------------
            // Act
            // -------------------------------------

            Snowflake target = new(VALID_SNOWFLAKE_VALUE);

            // -------------------------------------
            // Assert
            // -------------------------------------

            target.Value.Should().Be(VALID_SNOWFLAKE_VALUE);
        }

        // -------------------------------------------------------------------------
        // Operators
        // -------------------------------------------------------------------------

        [Fact]
        public void Snowflake_WhenImplicitlyConvertedToLong_ShouldReturnValue()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            Snowflake target = new(VALID_SNOWFLAKE_VALUE);

            // -------------------------------------
            // Act
            // -------------------------------------

            long result = target;

            // -------------------------------------
            // Assert
            // -------------------------------------

            result.Should().Be(VALID_SNOWFLAKE_VALUE);
        }

        [Fact]
        public void Snowflake_WhenExplicitlyConvertedFromLong_ShouldReturnValue()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            // -------------------------------------
            // Act
            // -------------------------------------

            var target = (Snowflake)VALID_SNOWFLAKE_VALUE;

            // -------------------------------------
            // Assert
            // -------------------------------------

            target.Value.Should().Be(VALID_SNOWFLAKE_VALUE);
        }

        // -------------------------------------------------------------------------
        // Equality
        // -------------------------------------------------------------------------

        [Fact]
        public void Snowflake_WhenComparedToSameValue_ShouldBeEqual()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            Snowflake first = new(VALID_SNOWFLAKE_VALUE);
            Snowflake second = new(VALID_SNOWFLAKE_VALUE);

            // -------------------------------------
            // Act
            // -------------------------------------

            bool result = first.Equals(second);

            // -------------------------------------
            // Assert
            // -------------------------------------

            result.Should().BeTrue();
        }

        [Fact]
        public void Snowflake_WhenComparedToDifferentValue_ShouldNotBeEqual()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            Snowflake first = new(VALID_SNOWFLAKE_VALUE);
            Snowflake second = new(ANOTHER_VALID_SNOWFLAKE_VALUE);

            // -------------------------------------
            // Act
            // -------------------------------------

            bool result = first.Equals(second);

            // -------------------------------------
            // Assert
            // -------------------------------------

            result.Should().BeFalse();
        }

        [Fact]
        public void Snowflake_WhenComparedToSameValueUsingEqualityOperator_ShouldBeTrue()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            Snowflake first = new(VALID_SNOWFLAKE_VALUE);
            Snowflake second = new(VALID_SNOWFLAKE_VALUE);

            // -------------------------------------
            // Act
            // -------------------------------------

            bool result = first == second;

            // -------------------------------------
            // Assert
            // -------------------------------------

            result.Should().BeTrue();
        }

        [Fact]
        public void Snowflake_WhenComparedToDifferentValueUsingEqualityOperator_ShouldBeFalse()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            Snowflake first = new(VALID_SNOWFLAKE_VALUE);
            Snowflake second = new(ANOTHER_VALID_SNOWFLAKE_VALUE);

            // -------------------------------------
            // Act
            // -------------------------------------

            bool result = first == second;

            // -------------------------------------
            // Assert
            // -------------------------------------

            result.Should().BeFalse();
        }

        [Fact]
        public void Snowflake_WhenComparedToSameValueUsingInequalityOperator_ShouldBeFalse()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            Snowflake first = new(VALID_SNOWFLAKE_VALUE);
            Snowflake second = new(VALID_SNOWFLAKE_VALUE);

            // -------------------------------------
            // Act
            // -------------------------------------

            bool result = first != second;

            // -------------------------------------
            // Assert
            // -------------------------------------

            result.Should().BeFalse();
        }

        [Fact]
        public void Snowflake_WhenComparedToDifferentValueUsingInequalityOperator_ShouldBeTrue()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            Snowflake first = new(VALID_SNOWFLAKE_VALUE);
            Snowflake second = new(ANOTHER_VALID_SNOWFLAKE_VALUE);

            // -------------------------------------
            // Act
            // -------------------------------------

            bool result = first != second;

            // -------------------------------------
            // Assert
            // -------------------------------------

            result.Should().BeTrue();
        }

        // -------------------------------------------------------------------------
        // Equals
        // -------------------------------------------------------------------------

        [Fact]
        public void Snowflake_WhenComparedToNullUsingEquals_ShouldBeFalse()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            Snowflake target = new(VALID_SNOWFLAKE_VALUE);

            // -------------------------------------
            // Act
            // -------------------------------------

            bool result = target.Equals(null);

            // -------------------------------------
            // Assert
            // -------------------------------------

            result.Should().BeFalse();
        }

        [Fact]
        public void Snowflake_WhenComparedToDifferentObjectTypeUsingEquals_ShouldBeFalse()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            Snowflake target = new(VALID_SNOWFLAKE_VALUE);
            object obj = new();

            // -------------------------------------
            // Act
            // -------------------------------------

            bool result = target.Equals(obj);

            // -------------------------------------
            // Assert
            // -------------------------------------

            result.Should().BeFalse();
        }

        [Fact]
        public void Snowflake_WhenComparedToSameSnowflakeUsingEquals_ShouldBeTrue()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            Snowflake target = new(VALID_SNOWFLAKE_VALUE);
            object obj = new Snowflake(VALID_SNOWFLAKE_VALUE);

            // -------------------------------------
            // Act
            // -------------------------------------

            bool result = target.Equals(obj);

            // -------------------------------------
            // Assert
            // -------------------------------------

            result.Should().BeTrue();
        }

        [Fact]
        public void Snowflake_WhenComparedToDifferentSnowflakeUsingEquals_ShouldBeFalse()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            Snowflake target = new(VALID_SNOWFLAKE_VALUE);
            object obj = new Snowflake(ANOTHER_VALID_SNOWFLAKE_VALUE);

            // -------------------------------------
            // Act
            // -------------------------------------

            bool result = target.Equals(obj);

            // -------------------------------------
            // Assert
            // -------------------------------------

            result.Should().BeFalse();
        }

        // -------------------------------------------------------------------------
        // GetHashCode
        // -------------------------------------------------------------------------

        [Fact]
        public void Snowflake_WhenHashCodeCalledTwiceOnSameInstance_ShouldReturnSameValue()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            Snowflake target = new(VALID_SNOWFLAKE_VALUE);

            // -------------------------------------
            // Act
            // -------------------------------------

            int firstCall = target.GetHashCode();
            int secondCall = target.GetHashCode();

            // -------------------------------------
            // Assert
            // -------------------------------------

            firstCall.Should().Be(secondCall);
        }

        [Fact]
        public void Snowflake_WhenTwoEqualSnowflakes_ShouldReturnSameHashCode()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            Snowflake first = new(VALID_SNOWFLAKE_VALUE);
            Snowflake second = new(VALID_SNOWFLAKE_VALUE);

            // -------------------------------------
            // Act
            // -------------------------------------

            int firstHashCode = first.GetHashCode();
            int secondHashCode = second.GetHashCode();

            // -------------------------------------
            // Assert
            // -------------------------------------

            firstHashCode.Should().Be(secondHashCode);
        }

        // -------------------------------------------------------------------------
        // ToString
        // -------------------------------------------------------------------------

        [Fact]
        public void Snowflake_WhenConvertedToString_ShouldReturnRawValueString()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            Snowflake target = new(VALID_SNOWFLAKE_VALUE);
            string expected = VALID_SNOWFLAKE_VALUE.ToString();

            // -------------------------------------
            // Act
            // -------------------------------------

            string result = target.ToString();

            // -------------------------------------
            // Assert
            // -------------------------------------

            result.Should().Be(expected);
        }
    }
}


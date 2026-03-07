// -----------------------------------------------------------------------------
// <copyright file="Snowflake.cs" company="ALMA Esports Discord Bot Api">
// Copyright (c) ALMA Esports Discord Bot Api. All rights reserved.
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
        // -------------------------------------------------------------------------
        // Construction
        // -------------------------------------------------------------------------

        [Fact]
        public void Snowflake_WhenCreatedFromValidLong_ShouldStoreValue()
        {
            var target = new Snowflake(123456789L);
            target.Value.Should().Be(123456789L);
        }

        [Fact]
        public void Snowflake_WhenCreatedFromZero_ShouldThrowArgumentException()
        {
            Action act = () => new Snowflake(0L);

            act.Should().Throw<ArgumentException>().WithParameterName("value");
        }

        [Fact]
        public void Snowflake_WhenCreatedFromNegativeValue_ShouldThrowArgumentException()
        {
            Action act = () => new Snowflake(-1L);

            act.Should().Throw<ArgumentException>().WithParameterName("value");
        }

        // -------------------------------------------------------------------------
        // Égalité
        // -------------------------------------------------------------------------

        [Fact]
        public void Snowflake_WhenComparedToSameValue_ShouldBeEqual()
        {
            Snowflake first = new(123456789L);
            Snowflake second = new(123456789L);

            first.Should().Be(second);
        }

        [Fact]
        public void Snowflake_WhenComparedToDifferentValue_ShouldNotBeEqual()
        {
            Snowflake first = new(123456789L);
            Snowflake second = new(987654321L);

            first.Should().NotBe(second);
        }

        [Fact]
        public void Snowflake_WhenComparedUsingEqualityOperator_ShouldBeEqual()
        {
            Snowflake first = new(123456789L);
            Snowflake second = new(123456789L);

            (first == second).Should().BeTrue();
        }

        [Fact]
        public void Snowflake_WhenComparedUsingInequalityOperator_ShouldNotBeEqual()
        {
            Snowflake first = new(123456789L);
            Snowflake second = new(987654321L);

            (first != second).Should().BeTrue();
        }

        // -------------------------------------------------------------------------
        // Conversions
        // -------------------------------------------------------------------------

        [Fact]
        public void Snowflake_WhenImplicitlyConvertedToLong_ShouldReturnValue()
        {
            Snowflake target = new(123456789L);

            long value = target;

            value.Should().Be(123456789L);
        }

        [Fact]
        public void Snowflake_WhenExplicitlyConvertedToLong_ShouldReturnValue()
        {
            var target = (Snowflake)123456789L;

            target.Value.Should().Be(123456789L);
        }

        // -------------------------------------------------------------------------
        // ToString
        // -------------------------------------------------------------------------

        [Fact]
        public void Snowflake_WhenExplicitlyConvertedToString_ShouldReturnRawValue()
        {
            Snowflake target = new(123456789L);

            target.ToString().Should().Be("123456789");
        }
    }
}

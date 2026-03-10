// -----------------------------------------------------------------------------
// <copyright file="UuidTests.cs" company="Alma.DiscordBot.Api.Core.Abstractions.Tests">
//   Copyright (c) Alma.DiscordBot.Api.Core.Abstractions.Tests All rights reserved.
// </copyright>
// <author>iMeanBkli</author>
// <created>2026-03-08</created>
// -----------------------------------------------------------------------------

using Alma.DiscordBot.Api.Core.Abstractions.ValueObjects;
using FluentAssertions;

namespace Alma.DiscordBot.Api.Core.Abstractions.Tests.ValueObjects
{
    public sealed class UuidTests
    {
        // -------------------------------------------------------------------------
        // Constructor
        // -------------------------------------------------------------------------

        [Fact]
        public void Uuid_WhenCreated_ShouldStoreValue()
        {
            var guid = Guid.NewGuid();

            var target = new Uuid(guid);

            target.Value.Should().Be(guid);
        }

        // -------------------------------------------------------------------------
        // Equality
        // -------------------------------------------------------------------------

        [Fact]
        public void Uuid_WhenComparedToSameValue_ShouldBeEqual()
        {
            var guid = Guid.NewGuid();

            Uuid first = new(guid);
            Uuid second = new(guid);

            first.Should().Be(second);
        }

        [Fact]
        public void Uuid_WhenComparedToDifferentValue_ShouldNotBeEqual()
        {
            Uuid first = new();
            Uuid second = new();

            first.Should().NotBe(second);
        }

        [Fact]
        public void Uuid_WhenComparedUsingEqualityOperator_ShouldBeEqual()
        {
            var guid = Guid.NewGuid();

            Uuid first = new(guid);
            Uuid second = new(guid);

            (first == second).Should().BeTrue();
        }

        [Fact]
        public void Uuid_WhenComparedUsingInequalityOperator_ShouldNotBeEqual()
        {
            Uuid first = new();
            Uuid second = new();

            (first != second).Should().BeTrue();
        }

        // -------------------------------------------------------------------------
        // Operators
        // -------------------------------------------------------------------------

        [Fact]
        public void Uuid_WhenImplicitlyConvertedToGuid_ShouldReturnValue()
        {
            Uuid target = new();

            Guid value = target;

            target.Value.Should().Be(value);
        }

        [Fact]
        public void Uuid_WhenExplicitlyConvertedFromGuid_ShouldReturnValue()
        {
            var guid = Guid.NewGuid();

            var target = (Uuid)guid;

            target.Value.Should().Be(guid);
        }

        // -------------------------------------------------------------------------
        // ToString
        // -------------------------------------------------------------------------

        [Fact]
        public void Uuid_WhenExplicitlyConvertedToString_ShouldReturnRawValue()
        {
            var guid = Guid.NewGuid();

            Uuid target = new(guid);

            target.ToString().Should().Be(guid.ToString());
        }
    }
}

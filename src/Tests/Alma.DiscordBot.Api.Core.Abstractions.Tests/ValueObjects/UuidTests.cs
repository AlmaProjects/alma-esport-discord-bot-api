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
        private static readonly Guid VALID_GUID_VALUE = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234567890");
        private static readonly Guid ANOTHER_VALID_GUID_VALUE = Guid.Parse("b2c3d4e5-f6a7-8901-bcde-f12345678901");

        // -------------------------------------------------------------------------
        // Constructor
        // -------------------------------------------------------------------------

        [Fact]
        public void Uuid_WhenCreatedWithoutParameter_ShouldStoreGeneratedValue()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            // -------------------------------------
            // Act
            // -------------------------------------

            Uuid target = new();

            // -------------------------------------
            // Assert
            // -------------------------------------

            target.Value.Should().NotBe(Guid.Empty);
        }

        [Fact]
        public void Uuid_WhenCreatedWithoutParameterTwice_ShouldGenerateDifferentValues()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            // -------------------------------------
            // Act
            // -------------------------------------

            Uuid first = new();
            Uuid second = new();

            // -------------------------------------
            // Assert
            // -------------------------------------

            first.Value.Should().NotBe(second.Value);
        }

        [Fact]
        public void Uuid_WhenCreatedFromValidGuid_ShouldStoreValue()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            // -------------------------------------
            // Act
            // -------------------------------------

            Uuid target = new(VALID_GUID_VALUE);

            // -------------------------------------
            // Assert
            // -------------------------------------

            target.Value.Should().Be(VALID_GUID_VALUE);
        }

        // -------------------------------------------------------------------------
        // Operators
        // -------------------------------------------------------------------------

        [Fact]
        public void Uuid_WhenImplicitlyConvertedToGuid_ShouldReturnValue()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            Uuid target = new(VALID_GUID_VALUE);

            // -------------------------------------
            // Act
            // -------------------------------------

            Guid result = target;

            // -------------------------------------
            // Assert
            // -------------------------------------

            result.Should().Be(VALID_GUID_VALUE);
        }

        [Fact]
        public void Uuid_WhenExplicitlyConvertedFromGuid_ShouldReturnValue()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            // -------------------------------------
            // Act
            // -------------------------------------

            var target = (Uuid)VALID_GUID_VALUE;

            // -------------------------------------
            // Assert
            // -------------------------------------

            target.Value.Should().Be(VALID_GUID_VALUE);
        }

        // -------------------------------------------------------------------------
        // Equality
        // -------------------------------------------------------------------------

        [Fact]
        public void Uuid_WhenComparedToSameValue_ShouldBeEqual()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            Uuid first = new(VALID_GUID_VALUE);
            Uuid second = new(VALID_GUID_VALUE);

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
        public void Uuid_WhenComparedToDifferentValue_ShouldNotBeEqual()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            Uuid first = new(VALID_GUID_VALUE);
            Uuid second = new(ANOTHER_VALID_GUID_VALUE);

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
        public void Uuid_WhenComparedToSameValueUsingEqualityOperator_ShouldBeTrue()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            Uuid first = new(VALID_GUID_VALUE);
            Uuid second = new(VALID_GUID_VALUE);

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
        public void Uuid_WhenComparedToDifferentValueUsingEqualityOperator_ShouldBeFalse()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            Uuid first = new(VALID_GUID_VALUE);
            Uuid second = new(ANOTHER_VALID_GUID_VALUE);

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
        public void Uuid_WhenComparedToSameValueUsingInequalityOperator_ShouldBeFalse()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            Uuid first = new(VALID_GUID_VALUE);
            Uuid second = new(VALID_GUID_VALUE);

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
        public void Uuid_WhenComparedToDifferentValueUsingInequalityOperator_ShouldBeTrue()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            Uuid first = new(VALID_GUID_VALUE);
            Uuid second = new(ANOTHER_VALID_GUID_VALUE);

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
        public void Uuid_WhenComparedToNullUsingEquals_ShouldBeFalse()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            Uuid target = new(VALID_GUID_VALUE);

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
        public void Uuid_WhenComparedToDifferentObjectTypeUsingEquals_ShouldBeFalse()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            Uuid target = new(VALID_GUID_VALUE);
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
        public void Uuid_WhenComparedToSameUuidUsingEquals_ShouldBeTrue()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            Uuid target = new(VALID_GUID_VALUE);
            object obj = new Uuid(VALID_GUID_VALUE);

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
        public void Uuid_WhenComparedToDifferentUuidUsingEquals_ShouldBeFalse()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            Uuid target = new(VALID_GUID_VALUE);
            object obj = new Uuid(ANOTHER_VALID_GUID_VALUE);

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
        public void Uuid_WhenHashCodeCalledTwiceOnSameInstance_ShouldReturnSameValue()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            Uuid target = new(VALID_GUID_VALUE);

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
        public void Uuid_WhenTwoEqualUuids_ShouldReturnSameHashCode()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            Uuid first = new(VALID_GUID_VALUE);
            Uuid second = new(VALID_GUID_VALUE);

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
        public void Uuid_WhenConvertedToString_ShouldReturnRawValueString()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            Uuid target = new(VALID_GUID_VALUE);
            string expected = VALID_GUID_VALUE.ToString();

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

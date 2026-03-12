// -----------------------------------------------------------------------------
// <copyright file="SurrogateIdTests.cs" company="$projectname$">
//   Copyright (c) $projectname$. All rights reserved.
// </copyright>
// <author>$author$</author>
// <created>12/03/2026</created>
// -----------------------------------------------------------------------------

using Alma.DiscordBot.Api.Core.Abstractions.ValueObjects;

using FluentAssertions;

namespace Alma.DiscordBot.Api.Core.Abstractions.Tests.ValueObjects
{
    public sealed class SurrogateIdTests
    {
        private const int VALID_SURROGATE_ID_VALUE = 1;
        private const int ANOTHER_VALID_SURROGATE_ID_VALUE = 2;

        // -------------------------------------------------------------------------
        // Constructor
        // -------------------------------------------------------------------------

        [Fact]
        public void SurrogateId_WhenCreatedFromNegativeValue_ShouldThrowArgumentException()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            // -------------------------------------
            // Act
            // -------------------------------------

            Action act = () => new SurrogateId(-1);

            // -------------------------------------
            // Assert
            // -------------------------------------

            act.Should().Throw<ArgumentException>().WithParameterName("value");
        }

        [Fact]
        public void SurrogateId_WhenCreatedFromZero_ShouldThrowArgumentException()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            // -------------------------------------
            // Act
            // -------------------------------------

            Action act = () => new SurrogateId(0);

            // -------------------------------------
            // Assert
            // -------------------------------------

            act.Should().Throw<ArgumentException>().WithParameterName("value");
        }

        [Fact]
        public void SurrogateId_WhenCreatedFromValidInt_ShouldStoreValue()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            // -------------------------------------
            // Act
            // -------------------------------------

            SurrogateId target = new(VALID_SURROGATE_ID_VALUE);

            // -------------------------------------
            // Assert
            // -------------------------------------

            target.Value.Should().Be(VALID_SURROGATE_ID_VALUE);
        }

        [Fact]
        public void SurrogateId_WhenCreatedFromIntMaxValue_ShouldStoreValue()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            // -------------------------------------
            // Act
            // -------------------------------------

            SurrogateId target = new(int.MaxValue);

            // -------------------------------------
            // Assert
            // -------------------------------------

            target.Value.Should().Be(int.MaxValue);
        }

        // -------------------------------------------------------------------------
        // Operators
        // -------------------------------------------------------------------------

        [Fact]
        public void SurrogateId_WhenImplicitlyConvertedToInt_ShouldReturnValue()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            SurrogateId source = new(VALID_SURROGATE_ID_VALUE);

            // -------------------------------------
            // Act
            // -------------------------------------

            int target = source;

            // -------------------------------------
            // Assert
            // -------------------------------------

            target.Should().Be(VALID_SURROGATE_ID_VALUE);
        }

        [Fact]
        public void SurrogateId_WhenExplicitlyConvertedFromInt_ShouldReturnValue()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            // -------------------------------------
            // Act
            // -------------------------------------

            var target = (SurrogateId)VALID_SURROGATE_ID_VALUE;

            // -------------------------------------
            // Assert
            // -------------------------------------

            target.Value.Should().Be(VALID_SURROGATE_ID_VALUE);
        }

        // -------------------------------------------------------------------------
        // Equality
        // -------------------------------------------------------------------------

        [Fact]
        public void SurrogateId_WhenComparedToSameValue_ShouldBeEqual()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            SurrogateId first = new(VALID_SURROGATE_ID_VALUE);
            SurrogateId second = new(VALID_SURROGATE_ID_VALUE);

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
        public void SurrogateId_WhenComparedToDifferentValue_ShouldNotBeEqual()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            SurrogateId first = new(VALID_SURROGATE_ID_VALUE);
            SurrogateId second = new(ANOTHER_VALID_SURROGATE_ID_VALUE);

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
        public void SurrogateId_WhenComparedToSameValueUsingEqualityOperator_ShouldBeTrue()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            SurrogateId first = new(VALID_SURROGATE_ID_VALUE);
            SurrogateId second = new(VALID_SURROGATE_ID_VALUE);

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
        public void SurrogateId_WhenComparedToDifferentValueUsingEqualityOperator_ShouldBeFalse()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            SurrogateId first = new(VALID_SURROGATE_ID_VALUE);
            SurrogateId second = new(ANOTHER_VALID_SURROGATE_ID_VALUE);

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
        public void SurrogateId_WhenComparedToSameValueUsingInequalityOperator_ShouldBeFalse()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            SurrogateId first = new(VALID_SURROGATE_ID_VALUE);
            SurrogateId second = new(VALID_SURROGATE_ID_VALUE);

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
        public void SurrogateId_WhenComparedToDifferentValueUsingInequalityOperator_ShouldBeTrue()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            SurrogateId first = new(VALID_SURROGATE_ID_VALUE);
            SurrogateId second = new(ANOTHER_VALID_SURROGATE_ID_VALUE);

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
        public void SurrogateId_WhenComparedToNullUsingEquals_ShouldBeFalse()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            SurrogateId target = new(VALID_SURROGATE_ID_VALUE);

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
        public void SurrogateId_WhenComparedToDifferentObjectTypeUsingEquals_ShouldBeFalse()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            SurrogateId target = new(VALID_SURROGATE_ID_VALUE);
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
        public void SurrogateId_WhenComparedToSameSurrogateIdUsingEquals_ShouldBeTrue()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            SurrogateId target = new(VALID_SURROGATE_ID_VALUE);
            object obj = new SurrogateId(VALID_SURROGATE_ID_VALUE);

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
        public void SurrogateId_WhenComparedToDifferentSurrogateIdUsingEquals_ShouldBeFalse()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            SurrogateId target = new(VALID_SURROGATE_ID_VALUE);
            object obj = new SurrogateId(ANOTHER_VALID_SURROGATE_ID_VALUE);

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
        public void SurrogateId_WhenHashCodeCalledTwiceOnSameInstance_ShouldReturnSameValue()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            SurrogateId target = new(VALID_SURROGATE_ID_VALUE);

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
        public void SurrogateId_WhenTwoEqualSurrogateIds_ShouldReturnSameHashCode()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            SurrogateId first = new(VALID_SURROGATE_ID_VALUE);
            SurrogateId second = new(VALID_SURROGATE_ID_VALUE);

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
        public void SurrogateId_WhenConvertedToString_ShouldReturnRawValueString()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            SurrogateId target = new(VALID_SURROGATE_ID_VALUE);
            string expected = VALID_SURROGATE_ID_VALUE.ToString();

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

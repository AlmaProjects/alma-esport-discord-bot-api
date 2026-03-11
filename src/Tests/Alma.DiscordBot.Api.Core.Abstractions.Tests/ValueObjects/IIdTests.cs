using Alma.DiscordBot.Api.Core.Abstractions.ValueObjects;

using FluentAssertions;

namespace Alma.DiscordBot.Api.Core.Abstractions.Tests.ValueObjects
{
    public sealed class IIdTests
    {
        // -------------------------------------------------------------------------
        // Contract
        // -------------------------------------------------------------------------

        [Fact]
        public void IId_WhenImplementedByUuid_ShouldBeAssignable()
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

            target.Should().BeAssignableTo<IId>();
        }

        [Fact]
        public void IId_WhenImplementedBySnowflake_ShouldBeAssignable()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            // -------------------------------------
            // Act
            // -------------------------------------

            Snowflake target = new(123_456_789L);

            // -------------------------------------
            // Assert
            // -------------------------------------

            target.Should().BeAssignableTo<IId>();
        }
    }
}

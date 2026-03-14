using Alma.DiscordBot.Api.Core.Abstractions.ValueObjects;
using Alma.DiscordBot.Api.Core.Domain.Entities;
using Alma.DiscordBot.Api.Core.Domain.ValueObjects;

using FluentAssertions;

namespace Alma.DiscordBot.Api.Core.Domain.Tests.Entities
{
    public sealed class PlayerTests
    {
        private static readonly RiotId VALID_RIOT_ID = new("Faker", "KR1");
        private static readonly RiotId ANOTHER_VALID_RIOT_ID = new("Caps", "EUW");

        // -------------------------------------------------------------------------
        // Identity
        // -------------------------------------------------------------------------

        [Fact]
        public void Player_WhenCreated_ShouldExposeRiotId()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            Uuid userId = new();

            // -------------------------------------
            // Act
            // -------------------------------------

            Player target = new()
            {
                Id = new Uuid(),
                UserId = userId,
                RiotId = VALID_RIOT_ID,
                CreatedAt = DateTime.UtcNow
            };

            // -------------------------------------
            // Assert
            // -------------------------------------

            target.RiotId.Should().Be(VALID_RIOT_ID);
        }

        [Fact]
        public void Player_WhenCreated_ShouldExposeUserId()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            Uuid userId = new();

            // -------------------------------------
            // Act
            // -------------------------------------

            Player target = new()
            {
                Id = new Uuid(),
                UserId = userId,
                RiotId = VALID_RIOT_ID,
                CreatedAt = DateTime.UtcNow
            };

            // -------------------------------------
            // Assert
            // -------------------------------------

            target.UserId.Should().Be(userId);
        }

        [Fact]
        public void Player_WhenCreated_PuuidShouldBeNull()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            // -------------------------------------
            // Act
            // -------------------------------------

            Player target = new()
            {
                Id = new Uuid(),
                UserId = new Uuid(),
                RiotId = VALID_RIOT_ID,
                CreatedAt = DateTime.UtcNow
            };

            // -------------------------------------
            // Assert
            // -------------------------------------

            target.Puuid.Should().BeNull();
        }

        // -------------------------------------------------------------------------
        // Soft delete
        // -------------------------------------------------------------------------

        [Fact]
        public void Player_WhenCreated_ShouldBeActive()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            // -------------------------------------
            // Act
            // -------------------------------------

            Player target = new()
            {
                Id = new Uuid(),
                UserId = new Uuid(),
                RiotId = VALID_RIOT_ID,
                CreatedAt = DateTime.UtcNow
            };

            // -------------------------------------
            // Assert
            // -------------------------------------

            target.IsActive.Should().BeTrue();
            target.DeletedAt.Should().BeNull();
        }

        [Fact]
        public void Player_WhenDeactivated_ShouldBeInactive()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            Player target = new()
            {
                Id = new Uuid(),
                UserId = new Uuid(),
                RiotId = VALID_RIOT_ID,
                CreatedAt = DateTime.UtcNow
            };

            DateTime beforeDeactivation = DateTime.UtcNow;

            // -------------------------------------
            // Act
            // -------------------------------------

            target.Deactivate();

            // -------------------------------------
            // Assert
            // -------------------------------------

            target.IsActive.Should().BeFalse();
            target.DeletedAt.Should().NotBeNull();
            target.DeletedAt.Should().BeOnOrAfter(beforeDeactivation);
        }

        [Fact]
        public void Player_WhenDeactivatedWhileAlreadyInactive_ShouldHaveNoEffect()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            Player target = new()
            {
                Id = new Uuid(),
                UserId = new Uuid(),
                RiotId = VALID_RIOT_ID,
                CreatedAt = DateTime.UtcNow
            };

            target.Deactivate();
            DateTime? firstDeletedAt = target.DeletedAt;

            // -------------------------------------
            // Act
            // -------------------------------------

            target.Deactivate();

            // -------------------------------------
            // Assert
            // -------------------------------------

            target.IsActive.Should().BeFalse();
            target.DeletedAt.Should().Be(firstDeletedAt);
        }

        [Fact]
        public void Player_WhenActivatedAfterDeactivation_ShouldBeActive()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            Player target = new()
            {
                Id = new Uuid(),
                UserId = new Uuid(),
                RiotId = VALID_RIOT_ID,
                CreatedAt = DateTime.UtcNow
            };

            target.Deactivate();

            // -------------------------------------
            // Act
            // -------------------------------------

            target.Activate();

            // -------------------------------------
            // Assert
            // -------------------------------------

            target.IsActive.Should().BeTrue();
            target.DeletedAt.Should().BeNull();
        }

        [Fact]
        public void Player_WhenActivatedWhileAlreadyActive_ShouldHaveNoEffect()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            Player target = new()
            {
                Id = new Uuid(),
                UserId = new Uuid(),
                RiotId = VALID_RIOT_ID,
                CreatedAt = DateTime.UtcNow
            };

            // -------------------------------------
            // Act
            // -------------------------------------

            target.Activate();

            // -------------------------------------
            // Assert
            // -------------------------------------

            target.IsActive.Should().BeTrue();
            target.DeletedAt.Should().BeNull();
        }
    }
}

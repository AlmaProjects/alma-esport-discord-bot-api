// -----------------------------------------------------------------------------
// <copyright file="IAuditableTests.cs" company="Alma.DiscordBot.Api.Core.Abstractions.Tests">
//   Copyright (c) Alma.DiscordBot.Api.Core.Abstractions.Tests All rights reserved.
// </copyright>
// <author>iMeanBkli</author>
// <created>2026-03-08</created>
// -----------------------------------------------------------------------------

using Alma.DiscordBot.Api.Core.Abstractions.Interfaces;

using FluentAssertions;

namespace Alma.DiscordBot.Api.Core.Abstractions.Tests.Interfaces
{
    public sealed class IAuditableTests
    {
        private sealed class FakeAuditableEntity : IAuditable
        {
            public DateTime CreatedAt { get; init; }

            public DateTime? UpdatedAt { get; set; }
        }

        // -------------------------------------------------------------------------
        // CreatedAt
        // -------------------------------------------------------------------------

        [Fact]
        public void IAuditable_WhenCreated_ShouldExposeCreatedAt()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            DateTime expectedCreatedAt = DateTime.UtcNow;

            // -------------------------------------
            // Act
            // -------------------------------------

            FakeAuditableEntity target = new() { CreatedAt = expectedCreatedAt };

            // -------------------------------------
            // Assert
            // -------------------------------------

            target.CreatedAt.Should().Be(expectedCreatedAt);
        }

        // -------------------------------------------------------------------------
        // UpdatedAt
        // -------------------------------------------------------------------------

        [Fact]
        public void IAuditable_WhenCreated_CreatedAtShouldBeBeforeOrEqualUpdatedAt()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            DateTime createdAt = DateTime.UtcNow;
            DateTime updatedAt = createdAt.AddSeconds(1);

            // -------------------------------------
            // Act
            // -------------------------------------

            FakeAuditableEntity target = new()
            {
                CreatedAt = createdAt,
                UpdatedAt = updatedAt
            };

            // -------------------------------------
            // Assert
            // -------------------------------------

            target.CreatedAt.Should().BeOnOrBefore(target.UpdatedAt!.Value);
        }

        [Fact]
        public void IAuditable_WhenNeverUpdated_UpdatedAtShouldBeNull()
        {
            // -------------------------------------
            // Assert
            // -------------------------------------

            // -------------------------------------
            // Act
            // -------------------------------------

            FakeAuditableEntity target = new() { CreatedAt = DateTime.UtcNow };

            // -------------------------------------
            // Assert
            // -------------------------------------

            target.UpdatedAt.Should().BeNull();
        }

        [Fact]
        public void IAuditable_WhenUpdated_ShouldExposeUpdatedAt()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            DateTime expectedUpdatedAt = DateTime.UtcNow;

            // -------------------------------------
            // Act
            // -------------------------------------

            FakeAuditableEntity entity = new()
            {
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = expectedUpdatedAt
            };

            // -------------------------------------
            // Assert
            // -------------------------------------

            entity.UpdatedAt.Should().Be(expectedUpdatedAt);
        }
    }
}

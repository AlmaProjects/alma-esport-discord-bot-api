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
        // Constructor
        // -------------------------------------------------------------------------

        [Fact]
        public void IAuditable_WhenCreated_ShouldHaveCreatedAt()
        {
            DateTime now = DateTime.UtcNow;

            FakeAuditableEntity entity = new() { CreatedAt = now };

            entity.CreatedAt.Should().Be(now);
        }

        // -------------------------------------------------------------------------
        // Properties
        // -------------------------------------------------------------------------

        [Fact]
        public void IAuditable_WhenNotUpdated_ShouldHaveNullUpdatedAt()
        {
            FakeAuditableEntity entity = new() { CreatedAt = DateTime.UtcNow };

            entity.UpdatedAt.Should().BeNull();
        }

        [Fact]
        public void IAuditable_WhenUpdated_ShouldHaveUpdatedAt()
        {
            DateTime updatedAt = DateTime.UtcNow.AddHours(1);

            FakeAuditableEntity entity = new()
            {
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = updatedAt
            };

            entity.UpdatedAt.Should().Be(updatedAt);
        }
    }
}

// -----------------------------------------------------------------------------
// <copyright file="Snowflake.cs" company="ALMA Esports Discord Bot Api">
//   Copyright (c) ALMA Esports Discord Bot Api. All rights reserved.
// </copyright>
// <author>iMeanBkli</author>
// <created>2026-03-08</created>
// -----------------------------------------------------------------------------

using Alma.DiscordBot.Api.Core.Abstractions.Interfaces;

using FluentAssertions;

namespace Alma.DiscordBot.Api.Core.Abstractions.Tests.Interfaces
{
    public sealed class ISoftDeletableTests
    {
        private sealed class FakeSoftDeletableEntity : ISoftDeletable
        {
            public bool IsActive { get; set; }

            public DateTime? DeletedAt { get; set; }
        }

        [Fact]
        public void ISoftDeletable_WhenCreated_ShouldBeActive()
        {
            FakeSoftDeletableEntity entity = new()
            {
                IsActive = true,
            };

            entity.IsActive.Should().BeTrue();
        }

        [Fact]
        public void ISoftDeletable_WhenCreated_ShouldHaveNullDeletedAt()
        {
            FakeSoftDeletableEntity entity = new()
            {
                IsActive = true,
            };

            entity.DeletedAt.Should().BeNull();
        }

        [Fact]
        public void ISoftDeletable_WhenDeleted_ShouldBeInactive()
        {
            FakeSoftDeletableEntity entity = new()
            {
                IsActive = true,
            };

            entity.IsActive = false;
            entity.DeletedAt = DateTime.UtcNow;

            entity.IsActive.Should().BeFalse();
        }

        [Fact]
        public void ISoftDeletable_WhenDeleted_ShouldNotHaveNullDeletedAt()
        {
            FakeSoftDeletableEntity entity = new()
            {
                IsActive = true,
            };

            entity.IsActive = false;
            entity.DeletedAt = DateTime.UtcNow;

            entity.DeletedAt.Should().NotBeNull();
        }
    }
}

// -----------------------------------------------------------------------------
// <copyright file="ISoftDeletableTests.cs" company="Alma.DiscordBot.Api.Core.Abstractions.Tests">
//   Copyright (c) Alma.DiscordBot.Api.Core.Abstractions.Tests All rights reserved.
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
            public bool IsActive { get; private set; }

            public DateTime? DeletedAt { get; private set; }

            public void Activate()
            {
                if (IsActive)
                {
                    return;
                }

                IsActive = true;
            }

            public void Deactivate()
            {
                if (!IsActive)
                {
                    return;
                }

                IsActive = false;
                DeletedAt = DateTime.UtcNow;
            }
        }

        // -------------------------------------------------------------------------
        // Constructor
        // -------------------------------------------------------------------------

        [Fact]
        public void ISoftDeletable_WhenCreated_ShouldBeActive()
        {
            FakeSoftDeletableEntity entity = new();

            entity.IsActive.Should().BeTrue();
        }

        [Fact]
        public void ISoftDeletable_WhenCreated_ShouldHaveNullDeletedAt()
        {
            FakeSoftDeletableEntity entity = new();

            entity.Activate();

            entity.DeletedAt.Should().BeNull();
        }

        // -------------------------------------------------------------------------
        // Soft delete
        // -------------------------------------------------------------------------

        [Fact]
        public void ISoftDeletable_WhenDeleted_ShouldBeInactive()
        {
            FakeSoftDeletableEntity entity = new();

            entity.Activate();
            entity.Deactivate();

            entity.IsActive.Should().BeFalse();
        }

        [Fact]
        public void ISoftDeletable_WhenDeleted_ShouldNotHaveNullDeletedAt()
        {
            FakeSoftDeletableEntity entity = new();

            entity.Activate();
            entity.Deactivate();

            entity.DeletedAt.Should().NotBeNull();
        }
    }
}

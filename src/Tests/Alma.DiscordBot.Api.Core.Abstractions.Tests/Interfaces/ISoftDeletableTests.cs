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
        internal sealed class FakeSoftDeletableEntity : ISoftDeletable
        {
            public bool IsActive { get; private set; } = true;

            public DateTime? DeletedAt { get; private set; }

            public void Activate()
            {
                if (IsActive)
                {
                    return;
                }

                IsActive = true;
                DeletedAt = null;
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
        // Activate
        // -------------------------------------------------------------------------

        [Fact]
        public void ISoftDeletable_WhenCreated_ShouldBeActive()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            // -------------------------------------
            // Act
            // -------------------------------------

            ISoftDeletable target = new FakeSoftDeletableEntity();

            // -------------------------------------
            // Assert
            // -------------------------------------

            target.IsActive.Should().BeTrue();
            target.DeletedAt.Should().BeNull();
        }

        [Fact]
        public void ISoftDeletable_WhenActivatedWhileAlreadyActive_ShouldHaveNoEffect()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            ISoftDeletable target = new FakeSoftDeletableEntity();

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
        public void ISoftDeletable_WhenActivatedAfterDeactivation_ShouldBeActive()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            ISoftDeletable target = new FakeSoftDeletableEntity();
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

        // -------------------------------------------------------------------------
        // Deactivate
        // -------------------------------------------------------------------------

        [Fact]
        public void ISoftDeletable_WhenDeactivated_ShouldBeInactive()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            ISoftDeletable target = new FakeSoftDeletableEntity();
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
        public void ISoftDeletable_WhenDeactivatedWhileAlreadyInactive_ShouldHaveNoEffect()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            ISoftDeletable target = new FakeSoftDeletableEntity();
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
    }
}

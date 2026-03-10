// -----------------------------------------------------------------------------
// <copyright file="IIdentifiableTests.cs" company="Alma.DiscordBot.Api.Core.Abstractions.Tests">
//   Copyright (c) Alma.DiscordBot.Api.Core.Abstractions.Tests All rights reserved.
// </copyright>
// <author>iMeanBkli</author>
// <created>2026-03-07</created>
// -----------------------------------------------------------------------------

using Alma.DiscordBot.Api.Core.Abstractions.Interfaces;
using Alma.DiscordBot.Api.Core.Abstractions.ValueObjects;

using FluentAssertions;

namespace Alma.DiscordBot.Api.Core.Abstractions.Tests.Interfaces
{
    public sealed class IIdentifiableTests
    {
        private sealed class FakeSnowflakeEntity(Snowflake id) : IIdentifiable<Snowflake>
        {
            public Snowflake Id { get; init; } = id;
        }

        private sealed class FakeUuidEntity(Uuid uuid) : IIdentifiable<Uuid>
        {
            public Uuid Id { get; init; } = uuid;
        }

        // -------------------------------------------------------------------------
        // Constructor
        // -------------------------------------------------------------------------

        [Fact]
        public void IIdentifiable_WhenImplementedWithSnowflake_ShouldExposeId()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            Snowflake expectedId = new(123456789L);

            // -------------------------------------
            // Act
            // -------------------------------------

            IIdentifiable<Snowflake> target = new FakeSnowflakeEntity(expectedId);

            // -------------------------------------
            // Assert
            // -------------------------------------

            target.Id.Should().Be(expectedId);
        }

        [Fact]
        public void IIdentifiable_WhenImplementedWithGuid_ShouldExposeId()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            Uuid expectedId = new();

            // -------------------------------------
            // Act
            // -------------------------------------

             IIdentifiable<Uuid> target = new FakeUuidEntity(expectedId);

            // -------------------------------------
            // Assert
            // -------------------------------------

            target.Id.Should().Be(expectedId);
        }
    }
}

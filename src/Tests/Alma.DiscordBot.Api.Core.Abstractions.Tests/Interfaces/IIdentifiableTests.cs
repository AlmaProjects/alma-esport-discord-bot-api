// -----------------------------------------------------------------------------
// <copyright file="Snowflake.cs" company="ALMA Esports Discord Bot Api">
//   Copyright (c) ALMA Esports Discord Bot Api. All rights reserved.
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
        // -------------------------------------------------------------------------
        // Construction
        // -------------------------------------------------------------------------

        private sealed class FakeSnowflakeEntity(Snowflake id) : IIdentifiable<Snowflake>
        {
            public Snowflake Id { get; init; } = id;
        }

        [Fact]
        public void IIdentifiable_WhenImplementedWithSnowflake_ShouldExposeId()
        {
            Snowflake expectedId = new(123456789L);
            FakeSnowflakeEntity entity = new(expectedId);

            entity.Id.Should().Be(expectedId);
        }

        private sealed class FakeUuidEntity(Uuid uuid) : IIdentifiable<Uuid>
        {
            public Uuid Id { get; init; } = uuid;
        }

        [Fact]
        public void IIdentifiable_WhenImplementedWithGuid_ShouldExposeId()
        {
            var expectedId = new Uuid();
            FakeUuidEntity entity = new(expectedId);

            entity.Id.Should().Be(expectedId);
        }
    }
}

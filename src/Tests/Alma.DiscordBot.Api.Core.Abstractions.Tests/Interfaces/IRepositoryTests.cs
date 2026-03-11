// -----------------------------------------------------------------------------
// <copyright file="IRepositoryTests.cs" company="Alma.DiscordBot.Api.Core.Abstractions.Tests">
//   Copyright (c) Alma.DiscordBot.Api.Core.Abstractions.Tests All rights reserved.
// </copyright>
// <author>iMeanBkli</author>
// <created>2026-03-08</created>
// -----------------------------------------------------------------------------

using Alma.DiscordBot.Api.Core.Abstractions.Interfaces;
using Alma.DiscordBot.Api.Core.Abstractions.ValueObjects;

using FluentAssertions;

using NSubstitute;

#pragma warning disable IDE1006 // Styles d'affectation de noms - Async test methods do not require Async suffix
namespace Alma.DiscordBot.Api.Core.Abstractions.Tests.Interfaces
{
    public sealed class IRepositoryTests
    {
        internal sealed class FakeEntity(Uuid id) : IIdentifiable<Uuid>
        {
            public Uuid Id { get; init; } = id;
        }

        // -------------------------------------------------------------------------
        // GetByIdAsync
        // -------------------------------------------------------------------------

        [Fact]
        public async Task Repository_WhenEntityExists_GetByIdAsyncShouldReturnEntity()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            FakeEntity entity = new(new Uuid());

            IRepository<FakeEntity, Uuid> repository = Substitute.For<IRepository<FakeEntity, Uuid>>();

            repository.GetByIdAsync(entity.Id, Arg.Any<CancellationToken>()).Returns(entity);

            // -------------------------------------
            // Act
            // -------------------------------------

            FakeEntity? result = await repository.GetByIdAsync(entity.Id, TestContext.Current.CancellationToken);

            // -------------------------------------
            // Assert
            // -------------------------------------

            result.Should().NotBeNull();
            result.Should().Be(entity);
        }

        [Fact]
        public async Task Repository_WhenEntityDoesNotExist_GetByIdAsyncShouldReturnNull()
        {
            // -------------------------------------
            // Arrange
            // -------------------------------------

            Uuid nonExistentId = new();
            IRepository<FakeEntity, Uuid> repository = Substitute.For<IRepository<FakeEntity, Uuid>>();
            repository.GetByIdAsync(nonExistentId, Arg.Any<CancellationToken>()).Returns((FakeEntity?)null);

            // -------------------------------------
            // Act
            // -------------------------------------

            FakeEntity? result = await repository.GetByIdAsync(nonExistentId, Arg.Any<CancellationToken>());

            // -------------------------------------
            // Assert
            // -------------------------------------

            result.Should().BeNull();
        }
    }
}
#pragma warning restore IDE1006 // Styles d'affectation de noms - Async test methods do not require Async suffix.

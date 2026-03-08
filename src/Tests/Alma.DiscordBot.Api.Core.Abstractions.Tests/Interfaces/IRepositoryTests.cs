// -----------------------------------------------------------------------------
// <copyright file="Snowflake.cs" company="ALMA Esports Discord Bot Api">
//   Copyright (c) ALMA Esports Discord Bot Api. All rights reserved.
// </copyright>
// <author>iMeanBkli</author>
// <created>2026-03-08</created>
// -----------------------------------------------------------------------------

using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

using Alma.DiscordBot.Api.Core.Abstractions.Interfaces;
using Alma.DiscordBot.Api.Core.Abstractions.ValueObjects;

using FluentAssertions;

using NSubstitute;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace Alma.DiscordBot.Api.Core.Abstractions.Tests.Interfaces
{
    public sealed class IRepositoryTests
    {
        internal sealed class FakeEntity : IIdentifiable<Uuid>
        {
            public Uuid Id { get; init; }

            public FakeEntity(Uuid id)
            {
                Id = id;
            }
        }

        private readonly IRepository<FakeEntity, Uuid> _repository;

        public IRepositoryTests()
        {
            _repository = Substitute.For<IRepository<FakeEntity, Uuid>>();
        }

        [SuppressMessage("Style", "IDE1006:Styles d'affectation de noms", Justification = "Unnecessary naming rule for async methods unit test.")]
        [Fact]
        public async Task GetByIdAsync_WhenEntityExists_ShouldReturnEntity()
        {
            var guid = Guid.NewGuid();
            Uuid expectedId = new(guid);
            FakeEntity expectedEntity = new(expectedId);

            _repository.GetByIdAsync(expectedId).Returns(expectedEntity);

            FakeEntity? result = await _repository.GetByIdAsync(expectedId);

            result.Should().Be(expectedEntity);
        }

        [SuppressMessage("Style", "IDE1006:Styles d'affectation de noms", Justification = "Unnecessary naming rule for async methods unit test.")]
        [Fact]
        public async Task GetByIdAsync_WhenEntityDoesNotExists_ShouldReturnNull()
        {
            Uuid nonExistentId = new();

            _repository.GetByIdAsync(nonExistentId).Returns((FakeEntity?)null);

            FakeEntity? result = await _repository.GetByIdAsync(nonExistentId);

            result.Should().BeNull();
        }
    }
}

using Alma.DiscordBot.Api.Core.Abstractions.ValueObjects;

namespace Alma.DiscordBot.Api.Core.Domain.Tests.Entities
{
    public sealed class TeamMembershipTests
    {
        private static readonly Uuid VALID_TEAM_ID = new();
        private static readonly Uuid VALID_PLAYER_ID = new();

        // -------------------------------------------------------------------------
        // Identity
        // -------------------------------------------------------------------------

        // Cas : TeamId exposé correctement
        [Fact]
        public void TeamMembership_WhenCreated_ShouldExposeTeamId()
            => throw new NotImplementedException();

        // Cas : PlayerId exposé correctement
        [Fact]
        public void TeamMembership_WhenCreated_ShouldExposePlayerId()
            => throw new NotImplementedException();

        // Cas : Status exposé correctement
        [Fact]
        public void TeamMembership_WhenCreated_ShouldExposeStatus()
            => throw new NotImplementedException();

        // Cas : Role exposé correctement
        [Fact]
        public void TeamMembership_WhenCreated_ShouldExposeRole()
            => throw new NotImplementedException();

        // -------------------------------------------------------------------------
        // Audit
        // -------------------------------------------------------------------------

        // Cas : LeftAt null à la création — membership actif
        [Fact]
        public void TeamMembership_WhenCreated_LeftAtShouldBeNull()
            => throw new NotImplementedException();

        // Cas : CreatedAt exposé correctement
        [Fact]
        public void TeamMembership_WhenCreated_ShouldExposeCreatedAt()
            => throw new NotImplementedException();
    }
}

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
        [Fact(Skip = "Not implemented yet")]
        public void TeamMembership_WhenCreated_ShouldExposeTeamId()
        {
        }

        // Cas : PlayerId exposé correctement
        [Fact(Skip = "Not implemented yet")]
        public void TeamMembership_WhenCreated_ShouldExposePlayerId()
        {
        }

        // Cas : Status exposé correctement
        [Fact(Skip = "Not implemented yet")]
        public void TeamMembership_WhenCreated_ShouldExposeStatus()
        {
        }

        // Cas : Role exposé correctement
        [Fact(Skip = "Not implemented yet")]
        public void TeamMembership_WhenCreated_ShouldExposeRole()
        {
        }

        // -------------------------------------------------------------------------
        // Audit
        // -------------------------------------------------------------------------

        // Cas : LeftAt null à la création — membership actif
        [Fact(Skip = "Not implemented yet")]
        public void TeamMembership_WhenCreated_LeftAtShouldBeNull()
        {
        }

        // Cas : CreatedAt exposé correctement
        [Fact(Skip = "Not implemented yet")]
        public void TeamMembership_WhenCreated_ShouldExposeCreatedAt()
        {
        }
    }
}

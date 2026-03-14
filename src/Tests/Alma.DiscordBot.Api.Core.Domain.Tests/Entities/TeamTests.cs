using Alma.DiscordBot.Api.Core.Abstractions.ValueObjects;

namespace Alma.DiscordBot.Api.Core.Domain.Tests.Entities
{
    public sealed class TeamTests
    {
        private static readonly Snowflake VALID_GUILD_ID = new(123_456_789L);
        private const string VALID_TEAM_NAME = "Team Liquid";

        // -------------------------------------------------------------------------
        // Identity
        // -------------------------------------------------------------------------

        // Cas : GuildId exposé correctement
        [Fact]
        public void Team_WhenCreated_ShouldExposeGuildId()
            => throw new NotImplementedException();

        // Cas : Name exposé correctement
        [Fact]
        public void Team_WhenCreated_ShouldExposeName()
            => throw new NotImplementedException();

        // -------------------------------------------------------------------------
        // Soft delete
        // -------------------------------------------------------------------------

        // Cas : IsActive true à la création
        [Fact]
        public void Team_WhenCreated_ShouldBeActive()
            => throw new NotImplementedException();

        // Cas : Deactivate → IsActive false + DeletedAt non null
        [Fact]
        public void Team_WhenDeactivated_ShouldBeInactive()
            => throw new NotImplementedException();

        // Cas : Deactivate idempotent
        [Fact]
        public void Team_WhenDeactivatedWhileAlreadyInactive_ShouldHaveNoEffect()
            => throw new NotImplementedException();

        // Cas : Activate après Deactivate → IsActive true + DeletedAt null
        [Fact]
        public void Team_WhenActivatedAfterDeactivation_ShouldBeActive()
            => throw new NotImplementedException();

        // Cas : Activate idempotent
        [Fact]
        public void Team_WhenActivatedWhileAlreadyActive_ShouldHaveNoEffect()
            => throw new NotImplementedException();
    }
}

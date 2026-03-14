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
        [Fact(Skip = "Not implemented yet")]
        public void Team_WhenCreated_ShouldExposeGuildId()
        {
        }

        // Cas : Name exposé correctement
        [Fact(Skip = "Not implemented yet")]
        public void Team_WhenCreated_ShouldExposeName()
        {
        }

        // -------------------------------------------------------------------------
        // Soft delete
        // -------------------------------------------------------------------------

        // Cas : IsActive true à la création
        [Fact(Skip = "Not implemented yet")]
        public void Team_WhenCreated_ShouldBeActive()
        {
        }

        // Cas : Deactivate → IsActive false + DeletedAt non null
        [Fact(Skip = "Not implemented yet")]
        public void Team_WhenDeactivated_ShouldBeInactive()
        {
        }

        // Cas : Deactivate idempotent
        [Fact(Skip = "Not implemented yet")]
        public void Team_WhenDeactivatedWhileAlreadyInactive_ShouldHaveNoEffect()
        {
        }

        // Cas : Activate après Deactivate → IsActive true + DeletedAt null
        [Fact(Skip = "Not implemented yet")]
        public void Team_WhenActivatedAfterDeactivation_ShouldBeActive()
        {
        }

        // Cas : Activate idempotent
        [Fact(Skip = "Not implemented yet")]
        public void Team_WhenActivatedWhileAlreadyActive_ShouldHaveNoEffect()
        {
        }
    }
}

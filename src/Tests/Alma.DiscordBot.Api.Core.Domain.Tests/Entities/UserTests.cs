using Alma.DiscordBot.Api.Core.Abstractions.ValueObjects;

namespace Alma.DiscordBot.Api.Core.Domain.Tests.Entities
{
    public sealed class UserTests
    {
        private static readonly Snowflake VALID_DISCORD_ID = new(123_456_789L);
        private static readonly Snowflake VALID_GUILD_ID = new(987_654_321L);

        // -------------------------------------------------------------------------
        // Identity
        // -------------------------------------------------------------------------

        // Cas : création avec valeurs valides → propriétés stockées
        [Fact(Skip = "Not implemented yet")]
        public void User_WhenCreated_ShouldExposeDiscordId()
        {
        }

        // Cas : GuildId exposé correctement
        [Fact(Skip = "Not implemented yet")]
        public void User_WhenCreated_ShouldExposeGuildId()
        {
        }

        // -------------------------------------------------------------------------
        // Audit
        // -------------------------------------------------------------------------

        // Cas : CreatedAt exposé correctement
        [Fact(Skip = "Not implemented yet")]
        public void User_WhenCreated_ShouldExposeCreatedAt()
        {
        }

        // Cas : UpdatedAt null à la création
        [Fact(Skip = "Not implemented yet")]
        public void User_WhenCreated_UpdatedAtShouldBeNull()
        {
        }

        // -------------------------------------------------------------------------
        // Soft delete
        // -------------------------------------------------------------------------

        // Cas : IsActive true à la création
        [Fact(Skip = "Not implemented yet")]
        public void User_WhenCreated_ShouldBeActive()
        {
        }

        // Cas : DeletedAt null à la création
        [Fact(Skip = "Not implemented yet")]
        public void User_WhenCreated_DeletedAtShouldBeNull()
        {
        }

        // Cas : LeftAt null à la création
        [Fact(Skip = "Not implemented yet")]
        public void User_WhenCreated_LeftAtShouldBeNull()
        {
        }

        // Cas : Deactivate → IsActive false + DeletedAt non null
        [Fact(Skip = "Not implemented yet")]
        public void User_WhenDeactivated_ShouldBeInactive()
        {
        }

        // Cas : Deactivate idempotent → second appel sans effet
        [Fact(Skip = "Not implemented yet")]
        public void User_WhenDeactivatedWhileAlreadyInactive_ShouldHaveNoEffect()
        {
        }

        // Cas : Activate après Deactivate → IsActive true + DeletedAt null
        [Fact(Skip = "Not implemented yet")]
        public void User_WhenActivatedAfterDeactivation_ShouldBeActive()
        {
        }

        // Cas : Activate idempotent → second appel sans effet
        [Fact(Skip = "Not implemented yet")]
        public void User_WhenActivatedWhileAlreadyActive_ShouldHaveNoEffect()
        {
        }
    }
}

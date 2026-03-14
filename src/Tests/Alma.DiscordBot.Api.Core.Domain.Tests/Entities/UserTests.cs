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
        [Fact]
        public void User_WhenCreated_ShouldExposeDiscordId()
            => throw new NotImplementedException();

        // Cas : GuildId exposé correctement
        [Fact]
        public void User_WhenCreated_ShouldExposeGuildId()
            => throw new NotImplementedException();

        // -------------------------------------------------------------------------
        // Audit
        // -------------------------------------------------------------------------

        // Cas : CreatedAt exposé correctement
        [Fact]
        public void User_WhenCreated_ShouldExposeCreatedAt()
            => throw new NotImplementedException();

        // Cas : UpdatedAt null à la création
        [Fact]
        public void User_WhenCreated_UpdatedAtShouldBeNull()
            => throw new NotImplementedException();

        // -------------------------------------------------------------------------
        // Soft delete
        // -------------------------------------------------------------------------

        // Cas : IsActive true à la création
        [Fact]
        public void User_WhenCreated_ShouldBeActive()
            => throw new NotImplementedException();

        // Cas : DeletedAt null à la création
        [Fact]
        public void User_WhenCreated_DeletedAtShouldBeNull()
            => throw new NotImplementedException();

        // Cas : LeftAt null à la création
        [Fact]
        public void User_WhenCreated_LeftAtShouldBeNull()
            => throw new NotImplementedException();

        // Cas : Deactivate → IsActive false + DeletedAt non null
        [Fact]
        public void User_WhenDeactivated_ShouldBeInactive()
            => throw new NotImplementedException();

        // Cas : Deactivate idempotent → second appel sans effet
        [Fact]
        public void User_WhenDeactivatedWhileAlreadyInactive_ShouldHaveNoEffect()
            => throw new NotImplementedException();

        // Cas : Activate après Deactivate → IsActive true + DeletedAt null
        [Fact]
        public void User_WhenActivatedAfterDeactivation_ShouldBeActive()
            => throw new NotImplementedException();

        // Cas : Activate idempotent → second appel sans effet
        [Fact]
        public void User_WhenActivatedWhileAlreadyActive_ShouldHaveNoEffect()
            => throw new NotImplementedException();
    }
}

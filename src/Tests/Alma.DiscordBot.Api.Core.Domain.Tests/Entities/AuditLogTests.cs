using Alma.DiscordBot.Api.Core.Abstractions.ValueObjects;

namespace Alma.DiscordBot.Api.Core.Domain.Tests.Entities
{
    public sealed class AuditLogTests
    {
        private static readonly Snowflake VALID_GUILD_ID = new(123_456_789L);
        private static readonly Snowflake VALID_ACTOR_ID = new(987_654_321L);
        private const string VALID_ENTITY_TYPE = "User";
        private const string VALID_ENTITY_ID = "a1b2c3d4-e5f6-7890-abcd-ef1234567890";
        private const string VALID_PAYLOAD = "{}";

        // -------------------------------------------------------------------------
        // Identity
        // -------------------------------------------------------------------------

        // Cas : GuildId exposé correctement
        [Fact(Skip = "Not implemented yet")]
        public void AuditLog_WhenCreated_ShouldExposeGuildId()
        {
        }

        // Cas : ActorId exposé correctement
        [Fact(Skip = "Not implemented yet")]
        public void AuditLog_WhenCreated_ShouldExposeActorId()
        {
        }

        // Cas : Action exposée correctement
        [Fact(Skip = "Not implemented yet")]
        public void AuditLog_WhenCreated_ShouldExposeAction()
        {
        }

        // Cas : EntityType exposé correctement
        [Fact(Skip = "Not implemented yet")]
        public void AuditLog_WhenCreated_ShouldExposeEntityType()
        {
        }

        // Cas : EntityId exposé correctement
        [Fact(Skip = "Not implemented yet")]
        public void AuditLog_WhenCreated_ShouldExposeEntityId()
        {
        }

        // Cas : Payload exposé correctement
        [Fact(Skip = "Not implemented yet")]
        public void AuditLog_WhenCreated_ShouldExposePayload()
        {
        }

        // -------------------------------------------------------------------------
        // Audit
        // -------------------------------------------------------------------------

        // Cas : CreatedAt exposé correctement
        [Fact(Skip = "Not implemented yet")]
        public void AuditLog_WhenCreated_ShouldExposeCreatedAt()
        {
        }

        // Cas : AuditLog est immuable — aucune mutation possible après création
        [Fact(Skip = "Not implemented yet")]
        public void AuditLog_WhenCreated_ShouldBeImmutable()
        {
        }
    }
}

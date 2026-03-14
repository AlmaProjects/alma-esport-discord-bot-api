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
        [Fact]
        public void AuditLog_WhenCreated_ShouldExposeGuildId()
            => throw new NotImplementedException();

        // Cas : ActorId exposé correctement
        [Fact]
        public void AuditLog_WhenCreated_ShouldExposeActorId()
            => throw new NotImplementedException();

        // Cas : Action exposée correctement
        [Fact]
        public void AuditLog_WhenCreated_ShouldExposeAction()
            => throw new NotImplementedException();

        // Cas : EntityType exposé correctement
        [Fact]
        public void AuditLog_WhenCreated_ShouldExposeEntityType()
            => throw new NotImplementedException();

        // Cas : EntityId exposé correctement
        [Fact]
        public void AuditLog_WhenCreated_ShouldExposeEntityId()
            => throw new NotImplementedException();

        // Cas : Payload exposé correctement
        [Fact]
        public void AuditLog_WhenCreated_ShouldExposePayload()
            => throw new NotImplementedException();

        // -------------------------------------------------------------------------
        // Audit
        // -------------------------------------------------------------------------

        // Cas : CreatedAt exposé correctement
        [Fact]
        public void AuditLog_WhenCreated_ShouldExposeCreatedAt()
            => throw new NotImplementedException();

        // Cas : AuditLog est immuable — aucune mutation possible après création
        [Fact]
        public void AuditLog_WhenCreated_ShouldBeImmutable()
            => throw new NotImplementedException();
    }
}

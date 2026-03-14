using Alma.DiscordBot.Api.Core.Abstractions.ValueObjects;

namespace Alma.DiscordBot.Api.Core.Domain.Tests.Entities
{
    public sealed class GuildAllowedRoleTests
    {
        private static readonly Snowflake VALID_GUILD_ID = new(123_456_789L);
        private static readonly Snowflake VALID_ROLE_ID = new(987_654_321L);

        // -------------------------------------------------------------------------
        // Identity
        // -------------------------------------------------------------------------

        // Cas : GuildId exposé correctement
        [Fact(Skip = "Not implemented yet")]
        public void GuildAllowedRole_WhenCreated_ShouldExposeGuildId()
        {
        }

        // Cas : RoleId exposé correctement
        [Fact(Skip = "Not implemented yet")]
        public void GuildAllowedRole_WhenCreated_ShouldExposeRoleId()
        {
        }
    }
}

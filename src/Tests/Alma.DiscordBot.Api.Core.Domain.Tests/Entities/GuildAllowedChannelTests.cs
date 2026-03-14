using Alma.DiscordBot.Api.Core.Abstractions.ValueObjects;

namespace Alma.DiscordBot.Api.Core.Domain.Tests.Entities
{
    public sealed class GuildAllowedChannelTests
    {
        private static readonly Snowflake VALID_GUILD_ID = new(123_456_789L);
        private static readonly Snowflake VALID_CHANNEL_ID = new(987_654_321L);

        // -------------------------------------------------------------------------
        // Identity
        // -------------------------------------------------------------------------

        // Cas : GuildId exposé correctement
        [Fact]
        public void GuildAllowedChannel_WhenCreated_ShouldExposeGuildId()
            => throw new NotImplementedException();

        // Cas : ChannelId exposé correctement
        [Fact]
        public void GuildAllowedChannel_WhenCreated_ShouldExposeChannelId()
            => throw new NotImplementedException();
    }
}

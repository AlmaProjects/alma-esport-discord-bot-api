using System;
using System.Collections.Generic;
using System.Text;

using Alma.DiscordBot.Api.Core.Abstractions.ValueObjects;

namespace Alma.DiscordBot.Api.Core.Domain.Tests.Entities
{
    public sealed class GuildConfigurationTests
    {
        private static readonly Snowflake VALID_GUILD_ID = new(123_456_789L);
        private const string VALID_COMMAND_PREFIX = "!";

        // -------------------------------------------------------------------------
        // Identity
        // -------------------------------------------------------------------------

        // Cas : Id exposé correctement
        [Fact(Skip = "Not implemented yet")]
        public void GuildConfiguration_WhenCreated_ShouldExposeId()
        {
        }

        // Cas : CommandPrefix exposé correctement
        [Fact(Skip = "Not implemented yet")]
        public void GuildConfiguration_WhenCreated_ShouldExposeCommandPrefix()
        { 
        }

        // -------------------------------------------------------------------------
        // Navigation properties
        // -------------------------------------------------------------------------

        // Cas : AllowedRoles vide à la création
        [Fact(Skip = "Not implemented yet")]
        public void GuildConfiguration_WhenCreated_AllowedRolesShouldBeEmpty()
        {
        }

        // Cas : AllowedChannels vide à la création
        [Fact(Skip = "Not implemented yet")]
        public void GuildConfiguration_WhenCreated_AllowedChannelsShouldBeEmpty()
        {
        }
    }
}

namespace Alma.DiscordBot.Api.Core.Domain.Tests.ValueObjects
{
    public sealed class RiotIdTests
    {
        private const string VALID_GAME_NAME = "Faker";
        private const string VALID_TAG_LINE = "KR1";
        private const string VALID_RIOT_ID_STRING = "Faker#KR1";

        private const string GAME_NAME_TOO_SHORT = "Ab";
        private const string GAME_NAME_TOO_LONG = "ThisNameIsTooLongForRiot";
        private const string TAG_LINE_TOO_SHORT = "Ab";
        private const string TAG_LINE_TOO_LONG = "TooLong";

        // -------------------------------------------------------------------------
        // Constructor
        // -------------------------------------------------------------------------

        // Cas : création avec GameName et TagLine valides → propriétés stockées
        [Fact(Skip = "Not implemented yet")]
        public void RiotId_WhenCreatedFromValidGameNameAndTagLine_ShouldStoreValues()
        {
        }

        // Cas : GameName trop court → ArgumentOutOfRangeException
        [Fact(Skip = "Not implemented yet")]
        public void RiotId_WhenGameNameIsTooShort_ShouldThrowArgumentOutOfRangeException()
        {
        }

        // Cas : GameName trop long → ArgumentOutOfRangeException
        [Fact(Skip = "Not implemented yet")]
        public void RiotId_WhenGameNameIsTooLong_ShouldThrowArgumentOutOfRangeException()
        {
        }

        // Cas : TagLine trop courte → ArgumentOutOfRangeException
        [Fact(Skip = "Not implemented yet")]
        public void RiotId_WhenTagLineIsTooShort_ShouldThrowArgumentOutOfRangeException()
        {
        }

        // Cas : TagLine trop longue → ArgumentOutOfRangeException
        [Fact(Skip = "Not implemented yet")]
        public void RiotId_WhenTagLineIsTooLong_ShouldThrowArgumentOutOfRangeException()
        {
        }

        // Cas : GameName à la longueur minimale → valide
        [Fact(Skip = "Not implemented yet")]
        public void RiotId_WhenGameNameIsAtMinimumLength_ShouldStoreValue()
        {
        }

        // Cas : GameName à la longueur maximale → valide
        [Fact(Skip = "Not implemented yet")]
        public void RiotId_WhenGameNameIsAtMaximumLength_ShouldStoreValue()
        {
        }

        // Cas : TagLine à la longueur minimale → valide
        [Fact(Skip = "Not implemented yet")]
        public void RiotId_WhenTagLineIsAtMinimumLength_ShouldStoreValue()
        {
        }

        // Cas : TagLine à la longueur maximale → valide
        [Fact(Skip = "Not implemented yet")]
        public void RiotId_WhenTagLineIsAtMaximumLength_ShouldStoreValue()
        {
        }

        // -------------------------------------------------------------------------
        // From
        // -------------------------------------------------------------------------

        // Cas : parsing d'une string valide → RiotId créé
        [Fact(Skip = "Not implemented yet")]
        public void RiotId_WhenCreatedFromValidString_ShouldStoreValues()
        {
        }

        // Cas : string sans séparateur → ArgumentException
        [Fact(Skip = "Not implemented yet")]
        public void RiotId_WhenInputHasNoSeparator_ShouldThrowArgumentException()
        {
        }

        // Cas : string avec plusieurs séparateurs → ArgumentException
        [Fact(Skip = "Not implemented yet")]
        public void RiotId_WhenInputHasMultipleSeparators_ShouldThrowArgumentException()
        {
        }

        // Cas : GameName invalide dans la string → ArgumentOutOfRangeException
        [Fact(Skip = "Not implemented yet")]
        public void RiotId_WhenInputGameNameIsTooShort_ShouldThrowArgumentOutOfRangeException()
        {
        }

        // Cas : TagLine invalide dans la string → ArgumentOutOfRangeException
        [Fact(Skip = "Not implemented yet")]
        public void RiotId_WhenInputTagLineIsTooShort_ShouldThrowArgumentOutOfRangeException()
        {
        }

        // -------------------------------------------------------------------------
        // Equality
        // -------------------------------------------------------------------------

        // Cas : deux RiotId avec mêmes valeurs → égaux
        [Fact(Skip = "Not implemented yet")]
        public void RiotId_WhenComparedToSameValue_ShouldBeEqual()
        {
        }

        // Cas : deux RiotId avec valeurs différentes → non égaux
        [Fact(Skip = "Not implemented yet")]
        public void RiotId_WhenComparedToDifferentValue_ShouldNotBeEqual()
        {
        }

        // Cas : comparaison insensible à la casse → égaux
        [Fact(Skip = "Not implemented yet")]
        public void RiotId_WhenComparedWithDifferentCase_ShouldBeEqual()
        {
        }

        // Cas : opérateur == avec mêmes valeurs → true
        [Fact(Skip = "Not implemented yet")]
        public void RiotId_WhenComparedToSameValueUsingEqualityOperator_ShouldBeTrue()
        {
        }

        // Cas : opérateur == avec valeurs différentes → false
        [Fact(Skip = "Not implemented yet")]
        public void RiotId_WhenComparedToDifferentValueUsingEqualityOperator_ShouldBeFalse()
        {
        }

        // Cas : opérateur != avec mêmes valeurs → false
        [Fact(Skip = "Not implemented yet")]
        public void RiotId_WhenComparedToSameValueUsingInequalityOperator_ShouldBeFalse()
        {
        }

        // Cas : opérateur != avec valeurs différentes → true
        [Fact(Skip = "Not implemented yet")]
        public void RiotId_WhenComparedToDifferentValueUsingInequalityOperator_ShouldBeTrue()
        {
        }

        // Cas : comparaison avec null via Equals → false
        [Fact(Skip = "Not implemented yet")]
        public void RiotId_WhenComparedToNullUsingEquals_ShouldBeFalse()
        {
        }

        // Cas : comparaison avec objet différent via Equals → false
        [Fact(Skip = "Not implemented yet")]
        public void RiotId_WhenComparedToDifferentObjectTypeUsingEquals_ShouldBeFalse()
        {
        }

        // -------------------------------------------------------------------------
        // GetHashCode
        // -------------------------------------------------------------------------

        // Cas : même instance appelée deux fois → même hashcode
        [Fact(Skip = "Not implemented yet")]
        public void RiotId_WhenHashCodeCalledTwiceOnSameInstance_ShouldReturnSameValue()
        {
        }

        // Cas : deux instances égales → même hashcode
        [Fact(Skip = "Not implemented yet")]
        public void RiotId_WhenTwoEqualRiotIds_ShouldReturnSameHashCode()
        {
        }

        // Cas : hashcode insensible à la casse → même hashcode
        [Fact(Skip = "Not implemented yet")]
        public void RiotId_WhenTwoRiotIdsWithDifferentCase_ShouldReturnSameHashCode()
        {
        }

        // -------------------------------------------------------------------------
        // ToString
        // -------------------------------------------------------------------------

        // Cas : ToString → "GameName#TagLine"
        [Fact(Skip = "Not implemented yet")]
        public void RiotId_WhenConvertedToString_ShouldReturnFormattedValue()
        {
        }

        // -------------------------------------------------------------------------
        // Operators
        // -------------------------------------------------------------------------

        // Cas : conversion implicite vers string → "GameName#TagLine"
        [Fact(Skip = "Not implemented yet")]
        public void RiotId_WhenImplicitlyConvertedToString_ShouldReturnFormattedValue()
        {
        }

        // -------------------------------------------------------------------------
        // IParser
        // -------------------------------------------------------------------------

        // Cas : RiotId implémente IParser<string, RiotId>
        [Fact(Skip = "Not implemented yet")]
        public void RiotId_ShouldImplementIParser()
        {
        }
    }
}

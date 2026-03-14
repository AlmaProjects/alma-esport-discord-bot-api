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
        [Fact]
        public void RiotId_WhenCreatedFromValidGameNameAndTagLine_ShouldStoreValues()
            => throw new NotImplementedException();

        // Cas : GameName trop court → ArgumentOutOfRangeException
        [Fact]
        public void RiotId_WhenGameNameIsTooShort_ShouldThrowArgumentOutOfRangeException()
            => throw new NotImplementedException();

        // Cas : GameName trop long → ArgumentOutOfRangeException
        [Fact]
        public void RiotId_WhenGameNameIsTooLong_ShouldThrowArgumentOutOfRangeException()
            => throw new NotImplementedException();

        // Cas : TagLine trop courte → ArgumentOutOfRangeException
        [Fact]
        public void RiotId_WhenTagLineIsTooShort_ShouldThrowArgumentOutOfRangeException()
            => throw new NotImplementedException();

        // Cas : TagLine trop longue → ArgumentOutOfRangeException
        [Fact]
        public void RiotId_WhenTagLineIsTooLong_ShouldThrowArgumentOutOfRangeException()
            => throw new NotImplementedException();

        // Cas : GameName à la longueur minimale → valide
        [Fact]
        public void RiotId_WhenGameNameIsAtMinimumLength_ShouldStoreValue()
            => throw new NotImplementedException();

        // Cas : GameName à la longueur maximale → valide
        [Fact]
        public void RiotId_WhenGameNameIsAtMaximumLength_ShouldStoreValue()
            => throw new NotImplementedException();

        // Cas : TagLine à la longueur minimale → valide
        [Fact]
        public void RiotId_WhenTagLineIsAtMinimumLength_ShouldStoreValue()
            => throw new NotImplementedException();

        // Cas : TagLine à la longueur maximale → valide
        [Fact]
        public void RiotId_WhenTagLineIsAtMaximumLength_ShouldStoreValue()
            => throw new NotImplementedException();

        // -------------------------------------------------------------------------
        // From
        // -------------------------------------------------------------------------

        // Cas : parsing d'une string valide → RiotId créé
        [Fact]
        public void RiotId_WhenCreatedFromValidString_ShouldStoreValues()
            => throw new NotImplementedException();

        // Cas : string sans séparateur → ArgumentException
        [Fact]
        public void RiotId_WhenInputHasNoSeparator_ShouldThrowArgumentException()
            => throw new NotImplementedException();

        // Cas : string avec plusieurs séparateurs → ArgumentException
        [Fact]
        public void RiotId_WhenInputHasMultipleSeparators_ShouldThrowArgumentException()
            => throw new NotImplementedException();

        // Cas : GameName invalide dans la string → ArgumentOutOfRangeException
        [Fact]
        public void RiotId_WhenInputGameNameIsTooShort_ShouldThrowArgumentOutOfRangeException()
            => throw new NotImplementedException();

        // Cas : TagLine invalide dans la string → ArgumentOutOfRangeException
        [Fact]
        public void RiotId_WhenInputTagLineIsTooShort_ShouldThrowArgumentOutOfRangeException()
            => throw new NotImplementedException();

        // -------------------------------------------------------------------------
        // Equality
        // -------------------------------------------------------------------------

        // Cas : deux RiotId avec mêmes valeurs → égaux
        [Fact]
        public void RiotId_WhenComparedToSameValue_ShouldBeEqual()
            => throw new NotImplementedException();

        // Cas : deux RiotId avec valeurs différentes → non égaux
        [Fact]
        public void RiotId_WhenComparedToDifferentValue_ShouldNotBeEqual()
            => throw new NotImplementedException();

        // Cas : comparaison insensible à la casse → égaux
        [Fact]
        public void RiotId_WhenComparedWithDifferentCase_ShouldBeEqual()
            => throw new NotImplementedException();

        // Cas : opérateur == avec mêmes valeurs → true
        [Fact]
        public void RiotId_WhenComparedToSameValueUsingEqualityOperator_ShouldBeTrue()
            => throw new NotImplementedException();

        // Cas : opérateur == avec valeurs différentes → false
        [Fact]
        public void RiotId_WhenComparedToDifferentValueUsingEqualityOperator_ShouldBeFalse()
            => throw new NotImplementedException();

        // Cas : opérateur != avec mêmes valeurs → false
        [Fact]
        public void RiotId_WhenComparedToSameValueUsingInequalityOperator_ShouldBeFalse()
            => throw new NotImplementedException();

        // Cas : opérateur != avec valeurs différentes → true
        [Fact]
        public void RiotId_WhenComparedToDifferentValueUsingInequalityOperator_ShouldBeTrue()
            => throw new NotImplementedException();

        // Cas : comparaison avec null via Equals → false
        [Fact]
        public void RiotId_WhenComparedToNullUsingEquals_ShouldBeFalse()
            => throw new NotImplementedException();

        // Cas : comparaison avec objet différent via Equals → false
        [Fact]
        public void RiotId_WhenComparedToDifferentObjectTypeUsingEquals_ShouldBeFalse()
            => throw new NotImplementedException();

        // -------------------------------------------------------------------------
        // GetHashCode
        // -------------------------------------------------------------------------

        // Cas : même instance appelée deux fois → même hashcode
        [Fact]
        public void RiotId_WhenHashCodeCalledTwiceOnSameInstance_ShouldReturnSameValue()
            => throw new NotImplementedException();

        // Cas : deux instances égales → même hashcode
        [Fact]
        public void RiotId_WhenTwoEqualRiotIds_ShouldReturnSameHashCode()
            => throw new NotImplementedException();

        // Cas : hashcode insensible à la casse → même hashcode
        [Fact]
        public void RiotId_WhenTwoRiotIdsWithDifferentCase_ShouldReturnSameHashCode()
            => throw new NotImplementedException();

        // -------------------------------------------------------------------------
        // ToString
        // -------------------------------------------------------------------------

        // Cas : ToString → "GameName#TagLine"
        [Fact]
        public void RiotId_WhenConvertedToString_ShouldReturnFormattedValue()
            => throw new NotImplementedException();

        // -------------------------------------------------------------------------
        // Operators
        // -------------------------------------------------------------------------

        // Cas : conversion implicite vers string → "GameName#TagLine"
        [Fact]
        public void RiotId_WhenImplicitlyConvertedToString_ShouldReturnFormattedValue()
            => throw new NotImplementedException();

        // -------------------------------------------------------------------------
        // IParser
        // -------------------------------------------------------------------------

        // Cas : RiotId implémente IParser<string, RiotId>
        [Fact]
        public void RiotId_ShouldImplementIParser()
            => throw new NotImplementedException();
    }
}

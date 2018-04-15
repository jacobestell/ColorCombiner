using System.Collections.Generic;
using ColorCombinationKata;
using Xunit;

namespace ColorCombinationKataTests
{
    public class UnlockVerifierTests
    {
        [Theory]
        [ClassData(typeof(InvalidTestData))]
        public void CanUnlock_NotAbleToUnlock_ReturnsFalse(string startColor, string finalColor,
            IList<Chip<string>> inputColors)
        {
            var verifyUnlockable = new UnlockVerifier<string>();
            Assert.False(verifyUnlockable.CanUnlock(startColor, finalColor, inputColors));
        }

        [Theory]
        [ClassData(typeof(ValidTestData))]
        public void CanUnlock_AbleToUnlock_ReturnsTrue(string startColor, string finalColor,
            IList<Chip<string>> inputColors)
        {
            var verifyUnlockable = new UnlockVerifier<string>();
            Assert.True(verifyUnlockable.CanUnlock(startColor, finalColor, inputColors));
        }
    }
}
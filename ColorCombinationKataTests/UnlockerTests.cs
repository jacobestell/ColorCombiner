using System.Collections.Generic;
using ColorCombinationKata;
using Xunit;

namespace ColorCombinationKataTests
{
    public class UnlockerTests
    {
        [Theory]
        [ClassData(typeof(ValidTestData))]
        [ClassData(typeof(ScrambledValidTestData))]
        public void Unlock_CanBeUnlocked_ReturnsUnlockedResult(string startColor, string finalColor,
            List<Chip<string>> inputColors)
        {
            var unlocker = new Unlocker<string>(startColor, finalColor, new UnlockVerifier<string>());

            var result = unlocker.Unlock(inputColors);

            Assert.DoesNotMatch("Cannot unlock master panel", result);
        }

        [Theory]
        [ClassData(typeof(ScrambledInvalidTestData))]
        public void Unlock_CannotBeUnlocked_ReturnsInvalidResult(string startColor, string finalColor,
            List<Chip<string>> inputColors)
        {
            var unlocker = new Unlocker<string>(startColor, finalColor, new UnlockVerifier<string>());

            var result = unlocker.Unlock(inputColors);

            Assert.Matches("Cannot unlock master panel", result);
        }
    }
}
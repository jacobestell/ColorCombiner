using System;
using System.Collections.Generic;
using System.Linq;

namespace ColorCombinationKata
{
    public class UnlockVerifier<T> : IUnlockVerifier<T> where T : IEquatable<T>
    {
        public bool CanUnlock(T startValue, T finalValue, IList<Chip<T>> inputValues)
        {
            if (inputValues.Count == 0)
            {
                return startValue.Equals(finalValue);
            }

            if (!startValue.Equals(inputValues.First().Head)
                || !finalValue.Equals(inputValues.Last().Tail))
            {
                return false;
            }

            for (var i = 1; i < inputValues.Count; i++)
            {
                if (!AreChipsSynced(inputValues[i - 1], inputValues[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool AreChipsSynced(Chip<T> previousChip, Chip<T> currentChip)
        {
            return previousChip.Tail.Equals(currentChip.Head);
        }
    }
}
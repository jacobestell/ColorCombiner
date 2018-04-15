using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColorCombinationKata
{
    /// <summary>
    ///     Class for Unlocking of The Control Panel
    /// </summary>
    /// <typeparam name="T">Any equatable type for chips</typeparam>
    public class Unlocker<T> where T : IEquatable<T>
    {
        /// <summary>
        ///     Result set to manage state in recrusive logic
        /// </summary>
        private readonly List<Chip<T>> _resultList = new List<Chip<T>>();
        private readonly IUnlockVerifier<T> _verifier;

        /// <summary>
        ///     This class tries to generate an unlock code using brute force to unlock the panel
        /// </summary>
        /// <param name="startValue">The beginning value of the control panel</param>
        /// <param name="finalValue">The final value of the control panel</param>
        /// <param name="verifier">The verifier for unlocking the control panel</param>
        public Unlocker(T startValue, T finalValue, IUnlockVerifier<T> verifier)
        {
            _startValue = startValue;
            _finalValue = finalValue;
            _verifier = verifier;
        }

        private T _startValue { get; }
        private T _finalValue { get; }

        /// <summary>
        ///     This is a brute force method that tries to build unlocking combinations
        /// </summary>
        /// <param name="input">The list of chips which you have to unlock the panel</param>
        /// <returns>A valid output or a messgae that you are not able to unlock the panel</returns>
        public string Unlock(List<Chip<T>> input)
        {
            DoUnlocking(_startValue, input);

            if (!_verifier.CanUnlock(_startValue, _finalValue, _resultList))
            {
                return "Cannot unlock master panel";
            }

            var stringBuilder = new StringBuilder();
            foreach (var item in _resultList)
            {
                stringBuilder.Append(item);
                stringBuilder.AppendLine();
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        ///     This is a recursive method that takes a value and builds a chain from all values
        /// </summary>
        /// <param name="valueToMatch">The previous chips tail or starting value</param>
        /// <param name="remainingChips">The remaining chips to match</param>
        public void DoUnlocking(T valueToMatch, List<Chip<T>> remainingChips)
        {
            var tempChipList = remainingChips.ToList();
            foreach (var chip in tempChipList)
            {
                remainingChips.Remove(chip);

                if (IsNextChipValidAndUpdateResult(valueToMatch, chip, remainingChips))
                {
                    break;
                }

                var flipped = chip.Flip();

                if (IsNextChipValidAndUpdateResult(valueToMatch, flipped, remainingChips))
                {
                    break;
                }

                remainingChips.Add(chip);
            }
        }

        //TODO Remove method side-effects
        private bool IsNextChipValidAndUpdateResult(T valueToMatch, Chip<T> nextChip, List<Chip<T>> remainingChipList)
        {
            if (!valueToMatch.Equals(nextChip.Head))
            {
                return false;
            }

            _resultList.Add(nextChip);
            DoUnlocking(nextChip.Tail, remainingChipList);

            if (remainingChipList.Any())
            {
                _resultList.Remove(nextChip);
            }

            return !remainingChipList.Any();
        }
    }
}
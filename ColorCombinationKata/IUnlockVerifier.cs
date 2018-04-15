using System;
using System.Collections.Generic;

namespace ColorCombinationKata
{
    public interface IUnlockVerifier<T> where T : IEquatable<T>
    {
        bool CanUnlock(T startValue, T finalValue, IList<Chip<T>> inputValues);
    }
}
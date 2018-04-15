using System;

namespace ColorCombinationKata
{
    public class Chip<T> where T : IEquatable<T>
    {
        public Chip()
        {
        }

        public Chip(T head, T tail)
        {
            Head = head;
            Tail = tail;
        }

        public T Head { get; set; }
        public T Tail { get; set; }

        public Chip<T> Flip()
        {
            return new Chip<T>(Tail, Head);
        }

        public override string ToString()
        {
            return $"{Head},{Tail}";
        }
    }
}
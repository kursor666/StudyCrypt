using System.Diagnostics.CodeAnalysis;

namespace Chezar.Models
{
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class EvklidNodModel
    {
        public int GetNod(int a, int b)
        {
            return b == 0 ? a : GetNod(b, a % b);
        }

        public int? GetReverseNod(int firstNumber, int secondNumber)
        {
            if (GetNod(firstNumber, secondNumber) != 1) return null;
            var u = new Vector {First = 0, Second = 1, Third = secondNumber};
            var v = new Vector {First = 1, Second = 0, Third = firstNumber};
            while (u.Third != 1)
            {
                var q = u.Third / v.Third;
                var T = new Vector
                {
                    First = u.First - q * v.First,
                    Second = u.Second - q * v.Second,
                    Third = u.Third - q * v.Third
                };
                u = v;
                v = T;
            }

            return u.First < 0 ? (u.First + secondNumber) : u.First;
        }
    }

    struct Vector
    {
        public int First, Second, Third;
    };
}
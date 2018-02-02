using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Chezar.Models
{
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    [SuppressMessage("ReSharper", "MemberCanBeMadeStatic.Global")]
    public class EntropyModel
    {
        public double GetEntropy(string text)
        {
            var map = new Dictionary<char, int>();
            foreach (var c in text)
            {
                if (!map.ContainsKey(c))
                    map.Add(c, 1);
                else
                    map[c] += 1;
            }
            var result = 0.0;
            var len = text.Length;
            foreach (var item in map)
            {
                var frequency = (double)item.Value / len;
                result -= frequency * (Math.Log(frequency) / Math.Log(2));
            }
            return result;
        }
    }
}
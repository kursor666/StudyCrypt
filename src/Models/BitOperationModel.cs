using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Chezar.Models
{
    [SuppressMessage("ReSharper", "MemberCanBeMadeStatic.Local")]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public class BitOperationModel
    {
        public bool IsEncode { get; set; }
        public string InputBinary { get; set; }
        public string OutputBinary { get; set; }

        private char CharCodeSwap(char ch)
        {
            var left = (byte) (ch >> 8);
            var right = (byte) ch;
            return (char) (left | right << 8);
        }

        private char CyclicShift(char ch, int shift)
        {
            for (var i = 0; i < shift; i++)
                ch = (char) (IsEncode ? (ch >> 1 | ch << 15) : (ch >> 15 | ch << 1));
            return ch;
        }

        public string Transform(string text)
        {
            var result = "";
            InputBinary = "";
            OutputBinary = "";
            for (var i = 0; i < text.Length; i++)
            {
                InputBinary += $"{Convert.ToString(text[i], 2).PadLeft(16, '0').Insert(8, " ")} ";
                var symbol = IsEncode ? CyclicShift(CharCodeSwap(text[i]), i) : CharCodeSwap(CyclicShift(text[i], i));
                result += symbol;
                OutputBinary += $"{Convert.ToString(symbol, 2).PadLeft(16, '0').Insert(8, " ")} ";
            }

            return result;
        }
    }
}
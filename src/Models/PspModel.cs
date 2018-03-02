using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Chezar.Utils;

namespace Chezar.Models
{
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class PspModel
    {
        private static readonly Dictionary<int, uint> Bits =
            new Dictionary<int, uint>()
            {
                {31, 0x80000000},
                {24, 0x0100000},
                {11, 0x0800},
                {1, 0x02}
            };

        public PspModel()
        {
            PspTempItems = new List<PspTempItem>();
        }

        public List<PspTempItem> PspTempItems { get; }

        public uint GetPsp(uint inputNumber)
        {
            PspTempItems.Clear();
            uint outputBits = 0;
            for (var i = 0; i < 48; i++)
            {
                uint currentSourceValue = inputNumber;
                uint zeroBit = inputNumber & 0x01;
                inputNumber >>= 1;
                outputBits = (outputBits << 1) | zeroBit;
                var pspItem = new PspTempItem()
                {
                    Bit0 = GetCharBit(zeroBit),
                    Bit2 = GetCharBit(GetCurrentBit(currentSourceValue, 1)),
                    Bit12 = GetCharBit(GetCurrentBit(currentSourceValue, 11)),
                    Bit25 = GetCharBit(GetCurrentBit(currentSourceValue, 24)),
                    Bit32 = GetCharBit(GetCurrentBit(currentSourceValue, 31)),
                    SourceValue = Convert.ToString(currentSourceValue, 2).PadLeft(32, '0')
                };
                PspTempItems.Add(pspItem);
                uint resultBit = (GetCurrentBit(currentSourceValue, 1) ^ GetCurrentBit(currentSourceValue, 11) ^
                                  GetCurrentBit(currentSourceValue, 24) ^ GetCurrentBit(currentSourceValue, 31) ^
                                  zeroBit) << 31;
                inputNumber |= resultBit;
            }

            return outputBits;
        }

        private uint GetCurrentBit(uint number, int bitPosition)
        {
            if (Bits.ContainsKey(bitPosition))
                return (number & Bits[bitPosition]) >> bitPosition;
            else
                return 0;
        }

        private char GetCharBit(uint number) => number.ToString().Last();
    }
}
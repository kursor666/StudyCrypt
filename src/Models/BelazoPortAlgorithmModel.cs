using System;
using System.Diagnostics.CodeAnalysis;

namespace Chezar.Models
{
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class BelazoPortAlgorithmModel
    {
        private const int CharsAlphabetCount = 32;

        private const int HalfCharsAlphabetCount = CharsAlphabetCount / 2;

        private const int FirstCharCode = 1072;

        private const int HalfAplhabetCharCode = FirstCharCode + HalfCharsAlphabetCount - 1;

        public string Key { get; set; }

        public string Transform(string text)
        {
            var result = "";
            for (var i = 0; i < text.Length; i++)
            {
                var charCode = (int) text[i];
                var keyCode = (int) Key[i % Key.Length];
                var margin = keyCode - FirstCharCode;
                margin = (charCode - FirstCharCode) < HalfCharsAlphabetCount ? margin : -margin;
                margin = (int) Math.Truncate(margin / 2.0);

                var shift = charCode + margin;

                margin = margin != 0
                    ? margin > 0
                        ? (shift > HalfAplhabetCharCode
                            ? margin
                            : margin + HalfCharsAlphabetCount)
                        : (shift > HalfAplhabetCharCode ? margin - HalfCharsAlphabetCount : margin)
                    : charCode <= HalfAplhabetCharCode
                        ? HalfCharsAlphabetCount
                        : -HalfCharsAlphabetCount;

                result += text[i] == ' ' ? text[i] : (char) (charCode + margin);
            }


            return result;
        }
    }
}


//говно залупа пенис хер давалка хуй блядина головка шлюха жопа член еблан петух мудила
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Chezar.Models
{
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public class ChezarAlgorithmModel
    {
        private const int CharsAlphabetCount = 32;

        public bool IsDecode { get; set; }

        public int MarginShift { get; set; }

        public string Transform(string text)
        {
            var result = "";
            text.ToList().ForEach(c =>
            {
                var step = IsDecode ? -MarginShift : MarginShift;
                
                result += c == ' '
                    ? c
                    : (char) ((c - 'а' + step + (((int) c - 'а' + step) < 0 ? CharsAlphabetCount : 0)) %
                              CharsAlphabetCount + 'а');
            });

            return result;
        }
    }
}
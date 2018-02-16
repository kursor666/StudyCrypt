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
    }
}
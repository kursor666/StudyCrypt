namespace Chezar.Utils
{
    public class PspTempItem
    {
        private string _sourceValue;

        public string SourceValue
        {
            get => _sourceValue;
            set => _sourceValue = value.PadLeft(32, '0');
        }

        public char Bit32 { get; set; }
        public char Bit25 { get; set; }
        public char Bit12 { get; set; }
        public char Bit2 { get; set; }
        public char Bit0 { get; set; }
    }
}
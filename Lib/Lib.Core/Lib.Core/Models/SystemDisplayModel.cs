namespace Lib.Core
{
    public class SystemDisplayModel
    {
        public int Width { get; set; }

        public int Height { get; set; }

        public int BitCount { get; set; }

        public SystemDisplayModel(int width, int height, int bitCount)
        {
            Width = width;
            Height = height;
            BitCount = bitCount;
        }

        public override string ToString()
        {
            return $"{Width} x {Height} ({BitCount} bits)";
        }
    }
}
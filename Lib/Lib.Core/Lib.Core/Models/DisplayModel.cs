namespace Lib.Core
{
    public class DisplayModel
    {
        public int Width { get; set; }

        public int Height { get; set; }

        public int BitCount { get; set; }

        public DisplayModel(int width, int height, int bitCount)
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
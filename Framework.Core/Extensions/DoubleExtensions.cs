
namespace Framework.Core.Extensions
{
    public static class DoubleExtensions
    {
        public static string GetSizeFileToMegaBayt(this double size)
        {
            double sizefile = (double)size / 1000000;
            string sizeToMegabayt = sizefile.ToString("0.##");
            return sizeToMegabayt;
        }
    }
}

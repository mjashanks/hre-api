namespace Hre.Api.Extensions
{
    public static class StringExtensions
    {
        public static string Fmt(this string str, params object[] prms)
        {
            return string.Format(str, prms);
        }

        public static string SqlWhere(this string str, string clause)
        {
            return str + " where " + clause;
        }

        public static string AsContentType(this string ext)
        {
            switch (ext)
            {
                case "jpg":
                    return "image/jpeg";
                case "gif":
                    return "image/gif";
                case "png":
                    return "image/png";
                case "bmp":
                    return "image/bmp";
                default:
                    return "image/jpg";
            }
        }
    }
}
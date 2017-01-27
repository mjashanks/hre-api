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
    }
}
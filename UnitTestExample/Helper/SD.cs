using System.Globalization;

namespace UnitTestExample.Helper
{
    public static class SD
    {
        public static DateTime? ToDateTime(string dateTime)
        {
            string[] formats = { "MM/dd/yyyy" };
            DateTime parsedDateTime;
            var result = DateTime.TryParseExact(dateTime, formats, new CultureInfo("en-US"),
                                           DateTimeStyles.None, out parsedDateTime);
            if (result)
                return parsedDateTime;
            else
                return null;
        }
    }
}

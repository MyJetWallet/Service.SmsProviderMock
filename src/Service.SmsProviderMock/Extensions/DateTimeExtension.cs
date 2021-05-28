using System;

namespace Service.SmsProviderMock.Extensions
{
    public static class DateTimeExtension
    {
        public static long ToTimestamp(this DateTime value)
        {
            var epoch = (value.Ticks - 621355968000000000) / 10000000;
            return epoch;
        }

        public static DateTime ToDateTime(double timestamp)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp);
        }

        public static DateTime ToDateTime(long timestamp)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp);
        }
    }
}

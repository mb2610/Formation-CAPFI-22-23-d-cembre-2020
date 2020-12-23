namespace LeapYearTest
{
    public static class LeapYear
    {
        public static bool IsLeap(int year)
        {
            return year.IsDivisible(4) && !(year.IsDivisible(100) && !year.IsDivisible(400));
        }

        private static bool IsDivisible(this int year, int modulo)
        {
            return year % modulo == 0;
        }
    }
}
namespace StringCalculatorTest
{
    public static class StringCalculator
    {
        public static int Add(string stringNumbers)
        {
            return new StringCalculatorBuilder(stringNumbers)
                .ExtractNumbers()
                .HandleNegativesNumbers()
                .ExcludeNumberGreaterThan(1000)
                .Sum();
        }
    }
}
namespace WordWrapTest
{
    public static class Wrapper
    {
        public static string Wrap(string text, int columnNumber)
        {
            if (text.NothingToWrap(columnNumber)) return text;

            var spaceIndex = text.LookForLastSpaceIndexFromZeroToColumnNumber(columnNumber);

            return NoSpaceFound(spaceIndex)
                ? text.WrapBreakLinesAtColumnNumber(columnNumber)
                : text.WrapBreakLinesAtWordBoundaries(columnNumber, spaceIndex);
        }

        private static bool NothingToWrap(this string text, int columnNumber)
        {
            return text.Length <= columnNumber;
        }

        private static int LookForLastSpaceIndexFromZeroToColumnNumber(this string text, int columnNumber)
        {
            return text.LastIndexOf(' ', columnNumber);
        }

        private static string WrapBreakLinesAtWordBoundaries(this string text, int columnNumber, int spaceIndex)
        {
            return text.Substring(0, spaceIndex) + "\n" +
                   Wrap(text.Substring(spaceIndex + (int) SpaceWrapping.RemoveSpace), columnNumber);
        }

        private static string WrapBreakLinesAtColumnNumber(this string text, int columnNumber)
        {
            return text.Substring(0, columnNumber) + "\n" + Wrap(text.Substring(columnNumber), columnNumber);
        }

        private static bool NoSpaceFound(int spaceIndex)
        {
            return spaceIndex == -1;
        }

        private enum SpaceWrapping
        {
            KeepSpace = 0,
            RemoveSpace = 1
        }
    }
}
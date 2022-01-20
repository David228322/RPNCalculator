namespace BLL
{
    /// <summary>
    /// Extensions for diff types.
    /// </summary>
    internal static class Extensions
    {
        /// <summary>
        /// return whether char in string is digit.
        /// </summary>
        /// <param name="str">input string for check.</param>
        /// <param name="index">check char using his position.</param>
        /// <returns>return boolean value true if char in string is digit. Else - false</returns>
        public static bool IsDigit(this string str, int index)
        {
            return char.IsDigit(str, index);
        }
    }
}

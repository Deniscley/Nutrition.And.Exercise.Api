namespace Nutrition.And.Exercise.Core.Utils
{
    public static class StringUtils
    {
        //Apenas Números
        public static string OnlyNumbers(this string str, string input)
           => new string(input.Where(char.IsDigit).ToArray());
    }
}

using System.Runtime.CompilerServices;

namespace CSharpWebApp
{
    public static class Extensions
    {
        public static string ToTitleCase(this string str)
        {
            bool init = true;
            string output = "";
            foreach (char chr in str)
            {
                if (init)
                {
                    output += chr.ToString().ToUpper();
                    init = false;
                }
                else
                {
                    output += chr.ToString();
                }
            }
            return output;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageUtilities.Extentions
{
    static class StringExtention
    {
        public static bool HasPrefix(this string str, string prefix)
        {
            if (str.Length < prefix.Length)
                return false;
            for (int i = 0; i < prefix.Length; i++)
            {
                if(str[i] != prefix[i])
                    return false;
            }
            return true;
        }

        public static string RemoveStrangeCharacters(this string str) {
            string removed = str;
            removed = removed.Replace('ç', 'c')
                .Replace('é', 'e')
                .Replace('á', 'a')
                .Replace('ã', 'a')
                .Replace('õ', 'o')
                .Replace('ó', 'o')
                .Replace('Ã', 'A')
                .Replace('Á', 'A')
                .Replace('É', 'E')
                .Replace('Õ', 'O')
                .Replace('Ó', 'O');

            return removed;
        }

        /// <summary>
        /// Returns a string w/o prefix and in camel case
        /// </summary>
        /// <returns>The category std.</returns>
        /// <param name="category">Category.</param>
        public static string ToCategoryStd(this string category) {
            return RemoveNonLetterPrefix(category.ToCamelCase());
        }

        public static string ToCamelCase(this string str) {
            if(str == "")
                return "";

            string camel = "";
            camel += CapitaliseChar(str[0]);
            for(int i = 1; i< str.Length; i++) {
                if(str[i-1] == ' ')
                    camel += CapitaliseChar(str[i]);
                else
                    camel += str[i];
            }

            return camel;
        }

        /// <summary>
        /// Removes the prefix of a word.
        /// </summary>
        /// <returns>The word without the prefix.</returns>
        /// <param name="str">String.</param>
        public static string RemoveNonLetterPrefix(this string str) {
            if(str == "")
                return "";
            string removed = "";
            int i = 0;
            while(!IsLetter(str[i])) {
                i++;
                if(i >= str.Length)
                    return str;
            }

            while(i < str.Length)
                removed += str[i++];

            return removed;
        }

        static bool IsLetter(char c) {
            return (c  >= 65 && c <= 90) || (c  >= 97 && c <= 122);
        }

        static char CapitaliseChar(char c) {
            if(c >= 97 && c <= 122)
                return (char)(c -32);
            return c;
        }

        /// <summary>
        /// Turns a directory of the form "dir\rec\tory" into "dir/rec/tory"
        /// </summary>
        /// <returns>The std directory form.</returns>
        /// <param name="str">String.</param>
        public static string ToForwardSlashForm(this string str) {
            return str.Replace('\\', '/');
        }

        public static string SurroundWithQuotes(this string str) {
            return "\""+str+"\"";
        }

        public static void Swap(this string[] strs, int i, int j) {
            string temp = strs[i];
            strs[i] = strs[j];
            strs[j] = temp;
        }

        public static string RemoveExtention(this string str) {
            int dotIndex = 0;
            string removed = "";
            for(int i = 0; i<str.Length; i++) {
                if(str[i] == '.')
                    dotIndex = i;
            }
            for(int i = 0; i<dotIndex; i++)
                removed += str[i];

            return removed;
        }

        public static string GetFileName(this string str) {
            int slashIndex = 0;
            string fileName = "";
            for(int i = 0; i<str.Length; i++) {
                if(str[i] == '/' || str[i] == '\\')
                    slashIndex = i;
            }

            for(int i = slashIndex+1; i<str.Length; i++)
                fileName += str[i];

            return fileName;
        }
    }
}

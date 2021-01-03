using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patriano.Core.Extensions
{
    public static class StringExtension
    {
        public static bool IsNullOrEmpty(this string input) => string.IsNullOrEmpty(input);

        public static bool IsNullOrWhiteSpace(this string input) => string.IsNullOrWhiteSpace(input);

        public static bool ContainsAll(this string input, IEnumerable<string> items)
        {
            if (input == null)
            {
                throw new NullReferenceException("string is null");
            }

            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            if (items.Any() != true)
            {
                return true;
            }

            return items.All(input.Contains);
        }

        public static bool ContainsAllInOrder(this string input, string[] items)
        {
            if (!ContainsAll(input, items))
            {
                return false;
            }

            var tmpInput = input;
            foreach (var item in items)
            {
                var newIndex = tmpInput.IndexOf(item);
                if (newIndex < 0)
                {
                    return false;
                }

                tmpInput = tmpInput.Substring(Math.Min(newIndex + item.Length, tmpInput.Length - 1));
            }

            return true;
        }
    }
}
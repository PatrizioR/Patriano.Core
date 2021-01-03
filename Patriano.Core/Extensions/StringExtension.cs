using System;
using System.Collections.Generic;
using System.Text;

namespace Patriano.Core.Extensions
{
    public static class StringExtension
    {
        public static bool IsNullOrEmpty(this string input) => string.IsNullOrEmpty(input);

        public static bool IsNullOrWhiteSpace(this string input) => string.IsNullOrWhiteSpace(input);
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Engine.Util
{
    public static class StringUtil
    {
        public static string Left(this string @this, int count) {
            return @this.Length > count ? @this.Substring(0, count) : @this;
        }

        public static Stream ToStream(this string @this) {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(@this);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}

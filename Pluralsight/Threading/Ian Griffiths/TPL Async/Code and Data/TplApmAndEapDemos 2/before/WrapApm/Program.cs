using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace WrapApm
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public static class StreamAsyncExtensions
    {
        public static Task<int> ReadAsync(
           this Stream s, byte[] data, int offset, int count)
        {
            return Task<int>.Factory.FromAsync(
              s.BeginRead, s.EndRead, data, offset, count, null);
        }
    }
}

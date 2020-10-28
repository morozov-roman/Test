using System;
using System.IO;

namespace Test
{
    interface IConvertable
    {
        /// <summary>
        /// Convert some data from Stream
        /// </summary>
        string Convert(Stream stream);
        /// <summary>
        /// Convert some data from file
        /// </summary>
        string ConvertByFile(String path);

    }
}
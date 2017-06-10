using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWork
{
    class Writer
    {
        public async Task WriteListToFile(IEnumerable<string> list, string filename) =>
            await Task.Run(() =>
            {
                File.WriteAllLines(filename, list);
            }
            );

    }
}

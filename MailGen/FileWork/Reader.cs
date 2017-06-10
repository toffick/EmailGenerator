using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWork
{
    class Reader
    {
        public string GetFileName()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            return ofd.FileName;
        }
        public async Task<IEnumerable<string>> GetListFroFile()
        {
            List<string> list = new List<string>();
            string filename = GetFileName();
            using (StreamReader sr = new StreamReader(File.Open(filename, FileMode.Open)))
            {
                while (sr.Peek() >= 0)
                {
                    string srt = await sr.ReadLineAsync();

                    if (srt.Length != 0)
                        list.Add(srt);
                }
            }

            return list;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace VDelStr
{
    class Log
    {
        string pathLogLocation = Directory.GetCurrentDirectory() + "\\logs.txt";

        public void Add(FileInfo item)
        {
            using (StreamWriter sWr = new StreamWriter(pathLogLocation, true, Encoding.UTF8))
            {
                sWr.WriteLine("Файл: {0}\nЧас та дата: {1}\n", item.Name, DateTime.Now);
            }
        }
    }
}
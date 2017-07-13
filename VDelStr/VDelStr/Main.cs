using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace VDelStr
{
    class Program
    {
        static List<int> list;
        static void Main(string[] args)
        {
            #region Work program
            string pathTextLocation = Directory.GetCurrentDirectory() + "\\paths.txt";
            string[] locations = File.ReadAllLines(pathTextLocation).ToArray();

            //string[] p1StartFile;
            IEnumerable<string> p2Skip1File;

            string P1 = locations[0];
            string P2 = locations[1];

            DirectoryInfo dirP1 = new DirectoryInfo(P1);
            Log log = new Log();

            CheckDirectory(P2);
            #region ReadFileOnebyOne
            foreach (var item in dirP1.GetFiles())
            {
                string varName = item.Name.Substring(0, item.Name.IndexOf('@'));
                string P2FullDirectory = P2 + varName + "\\";
                //p1StartFile = File.ReadAllLines(item.FullName);

                if (CheckUTF(item) == true)
                {
                    p2Skip1File = File.ReadLines(item.FullName).Skip(1);
                    File.WriteAllLines(P2FullDirectory + "members", p2Skip1File);
                }
                else {
                    log.Add(item);
                }
                CheckFolder(P2FullDirectory, varName);
                #region Add&Del Spaces;

                #endregion
            }
            #endregion

            Console.ReadKey();
            #endregion
        }

        static void CheckDirectory(string P2)
        {
            if (!Directory.Exists(P2))
                Directory.CreateDirectory(P2);
            else
                Console.WriteLine("Директорiя: \"{0}\", уже iснує", P2);
        }

        static void CheckFolder(string P2FullDirectory, string varName)
        {
            if (!Directory.Exists(P2FullDirectory))
            {
                Directory.CreateDirectory(P2FullDirectory);
            }
            else
                Console.WriteLine("Папка: {0}; уже створена", varName);
        }
        
        static bool CheckUTF(FileInfo item)
        {
            StreamReader strReader = new StreamReader(item.FullName);
            var encoding = strReader.CurrentEncoding.ToString();
            if (encoding == "System.Text.UTF8Encoding") {
                return true;
            }
            else {
                return false;
            }
        } 

        static void replaceSpaces (string[] liness, int beginS, int endS)
        {
            //string tempSpaces = liness[i].Substring(list.First(), list.Count());
            //liness[i] = liness[i].Replace(tempSpaces, ";");

        }

        static void FindSpaces(string[] liness)
        {
            int beginS, endS, k = 1;
            for (int i = 0; i < liness.Length; i++)
            {
                for (int j = 0; j < liness[i].Length; j++)
                {
                    if (liness[j] == " ")
                    {
                        beginS = endS = j;
                        while (isNextSymbolSpace(j + k, liness) == true)
                        {
                            endS++;
                            k++;
                        }

                        replaceSpaces(liness, beginS, endS);
                        //list = new List<int>();
                        //list.Insert(index, i);
                    }
                }
            }
        }

        static bool isNextSymbolSpace (int j, string[] liness)
        {
            if (liness[j] == " ")
                return true;
            else
                return false;
        }
    }
}
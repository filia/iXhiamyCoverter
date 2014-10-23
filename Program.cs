using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace liutab
{
    public class Program
    {
        private static string[] filename = { "liu-uni.txt", "liu-uni2.txt", "liu-uni3.txt", "liu-uni4.txt", };
        private static string result = "sample_mappings.txt";
        private static void failure()
        {
            Environment.Exit(-1);
        }
        public static void Main(string[] args)
        {
            File.Delete(result);
            for (int i = 0; i < 4; i++)
            {
                if (!File.Exists(filename[i])) Environment.Exit(-99);
            }
            StreamWriter target = new StreamWriter(result);
            for (int i = 0; i < 4; i++)
            {
                StreamReader source = new StreamReader(filename[i]);
                while (!source.EndOfStream)
                {
                    string temp = source.ReadLine();
                    temp = temp.Replace("\t*+", "");
                    temp = temp.Replace("\t*", "");
                    temp = temp.Replace("\t +", "");
                    temp = temp.Replace("\t", "->");
                    target.WriteLine(temp);
                }
                source.Close();

            }
            target.Close();
        }
    }
}

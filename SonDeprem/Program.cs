using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Text.RegularExpressions;

namespace SonDeprem
{
    class Program
    {

        static void Main(string[] args)
        {

            string VeriCek(string url, string etiket)
            {
                
                var startTag = "<" + etiket + ">"; 
                int startIndex = url.IndexOf(startTag) + startTag.Length;
                int endIndex = url.IndexOf("</" + etiket + ">", startIndex);
                return url.Substring(startIndex, endIndex - startIndex);
            }

            WebClient client = new WebClient();
            string boun = client.DownloadString("http://www.koeri.boun.edu.tr/scripts/lst4.asp");

            string result = VeriCek(boun, "pre").Remove(0, 250);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}

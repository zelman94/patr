using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace ConsoleApp1
{


    public class Program
    {
        public static void Main(string[] args)
        {
            
            
            try {
                string[] theArgs;
                if (args.Length != 0){
                    theArgs = args;

                }
                else
                {
                    theArgs = Environment.GetCommandLineArgs();
                }
                Console.WriteLine(theArgs[0]);
                string pattern = @"c:(\[a-z0-9]*)*";
                string pattern2 = @"(/[a-z0-9]*)*";
                MatchCollection matches = Regex.Matches(theArgs[0], pattern, RegexOptions.IgnorePatternWhitespace);
                MatchCollection matches2 = Regex.Matches(theArgs[0], pattern2, RegexOptions.IgnorePatternWhitespace);
                if (matches.Count>0 || matches2.Count > 0)
                {
                    Console.WriteLine("katalog istnieje");
                    
                    string path = Directory.GetCurrentDirectory();

                    DirectoryInfo di = new DirectoryInfo(path);

                    DirectoryInfo[] diArr = di.GetDirectories();
                    
                  
                    int count = 0;
                    foreach (DirectoryInfo dri in diArr) {
                        count++;
                        FileInfo fi2 = new FileInfo(dri.Name);
                        Console.WriteLine("{0} : {1}, \tostatnio zapisany : {2}", count, path +"\\"+ dri.Name, fi2.LastWriteTime);
                        
                    }
                   
                    string[] dirs = Directory.GetFiles(di.ToString());

                    foreach (string dri in dirs)
                    {
                        count++;
                        FileInfo fi2 = new FileInfo(dri);
                        Console.WriteLine("{0} : {1}, \tostatnio zapisany : {2}", count, dri, fi2.LastWriteTime);
                    }
                }
                else {
                    Console.WriteLine("katalog nie istnieje");
                    Environment.Exit(0);
                }
                
            }



            catch {
                Console.WriteLine("brak uprawnień do sciezki");
            }
             
            
        }
        }
    }

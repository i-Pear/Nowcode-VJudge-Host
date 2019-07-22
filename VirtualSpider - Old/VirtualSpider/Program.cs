using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;

namespace VirtualSpider
{
    class Program
    {
        static string GetProblemURL(string ContestURLBase,int countdown)
        {
            string result = ContestURLBase + ('A' + countdown - 1);
            return result;
        }
        static void Main(string[] args)
        {
            Console.Write("Enter contest id:");
            int ContestID = Convert.ToInt32(Console.ReadLine());
            string ConsterURLBase = "https://ac.nowcoder.com/acm/contest/" + ContestID + "/";
            Console.Write("Enter problem count:");
            int ContestProblemCount = Convert.ToInt32(Console.ReadLine());

            ChromeOptions chromeOptions = new ChromeOptions
            {
                BinaryLocation = Environment.GetEnvironmentVariable("ChromeDriverPath")
            };

            IWebDriver browser = new ChromeDriver(chromeOptions);

            browser.Url = "https://www.nowcoder.com/login";
            Console.WriteLine("\n----------------------------\n" +
                "Press enter after logining in...");
            Console.ReadKey();

            Console.WriteLine("\n----------------------------\n");
            Console.WriteLine("Saving contest info...");
            // Save Problems to file
            for(int i = 1; i <= ContestProblemCount; i++)
            {
                string ProblemURL = GetProblemURL(ConsterURLBase, i);
                browser.Url = ProblemURL;
                
            }

        }
    }
}

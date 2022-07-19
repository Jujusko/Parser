using BLL.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace A2TZ
{
    public class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();

            string test_url = "https://www.lesegais.ru/open-area/deal";

            driver.Url = test_url;

            var goToNextPage = driver.FindElement(By.XPath(XPaths.NextPage));
            IWebElement pages = driver.FindElement(By.XPath(XPaths.Pagination));

            //время на запуск браузера и прогрузку страницы
            Thread.Sleep(5000);//подумать, как убрать
            var pagination = pages.Text;

            int amountOfPages = GetAmountOfPages(pagination);

            DataTransferService dataTransferService = new DataTransferService();
            for (int i = 0; i < amountOfPages; i++)
            {
                var b = driver.FindElement(By.CssSelector(XPaths.Data));
                var qw = b.Text;
                var splitted = qw.Split('\n');
                goToNextPage.Click();
                dataTransferService.SortData(splitted);
                Thread.Sleep(2500);

            }

        }
        public static int GetAmountOfPages(string str)
        {
            string number = "";

            for (int i = str.Length - 1; i > 0; i--)
            {
                if (!Char.IsDigit(str[i]))
                    break;
                number += str[i];
            }

            char[] charArray = number.ToCharArray();
            Array.Reverse(charArray);
            number = "";

            foreach (var c in charArray)
                number += c;

            return Convert.ToInt32(number);
        }
    }
}

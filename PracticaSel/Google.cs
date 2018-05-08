using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace STQA
{
    class Google
    {
        IWebDriver Chrome;
        string url = "https://google.com";
        string search = "coche";

        [OneTimeSetUp]
        public void StartBrowser()
        {
            Chrome = new ChromeDriver();
            Chrome.Manage().Window.Maximize();
            Chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            
        }
        [Test,Order(0)]
        public void CarImage()
        {
            try
            {
                Console.WriteLine("✔ Navegando a "+ url);
                Chrome.Navigate().GoToUrl(url);

                Console.WriteLine("✔ Introduce el texto: " + search);
                IWebElement searchBar = Chrome.FindElement(By.Id("lst-ib"));
                searchBar.SendKeys(search);
                searchBar.SendKeys(Keys.Enter);
                //IWebElement searchButton = Chrome.FindElement(By.XPath("//*[@id='tsf']/div[2]/div[3]/center/input[1]"));
                //searchButton.Click();

                Console.WriteLine("✔ Entra en imagenes");
                IWebElement ImageButton = Chrome.FindElement(By.XPath("//*[@id='hdtb-msb-vis']/div[2]/a"));
                ImageButton.Click();

                Console.WriteLine("✔ Abre la primera imagen");
                //ReadOnlyCollection<IWebElement> images = Chrome.FindElements(By.ClassName("rg_ic rg_i"));
                //IWebElement firstImage = images[0];
                //firstImage.Click();

                IWebElement firstImage = Chrome.FindElement(By.XPath("//*[@id='7dj-g34dvR3RWM:']"));
                firstImage.Click();


                //Console.WriteLine("✔ Saca la url de la imagen");
                //IWebElement image = Chrome.FindElement(By.ClassName("irc_cc"));
                //Chrome.Navigate().GoToUrl(image.GetAttribute("src"));

                //var Wait = new WebDriverWait(Chrome, TimeSpan.FromSeconds(10));
                //Wait.Until(x => x.Title.Contains(Email));



            }
            catch (Exception ex) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("✘Ha ocurrido un error\r\n" + ex.Message);
                Assert.Fail("Ha ocurrido un error");
            }

        }
        [OneTimeTearDown]
        public void CloseBrowser()
        {
            Chrome.Quit();
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Data;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        public TestContext TestContext { get; set; }
        [TestMethod]
        public void TestMethod1()
        {

        }
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\data.csv", "data#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void DataDrivenTestingUsingCSVFile()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://www.network.com.tr");
            IWebElement element = driver.FindElement(By.Name("searchKey"));
            System.Threading.Thread.Sleep(100);
            element.Click();
            element.SendKeys("Ceket");
            System.Threading.Thread.Sleep(100);
            element.SendKeys(OpenQA.Selenium.Keys.Enter);
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            System.Threading.Thread.Sleep(100);
            js.ExecuteScript("window.scrollBy(1000,17500);");
            System.Threading.Thread.Sleep(1000);
            IWebElement elementt = driver.FindElement(By.CssSelector(".productList__moreContent .button"));
            System.Threading.Thread.Sleep(100);
            elementt.Click();
            System.Threading.Thread.Sleep(100);
            driver.Navigate().GoToUrl("https://www.network.com.tr/search?searchKey=Ceket&page=3");
            IWebElement elementtt = driver.FindElement(By.CssSelector(".product__discountPercent"));
            Actions action = new Actions(driver);
            action.MoveToElement(elementtt).Perform();
            IWebElement elements = driver.FindElement(By.Name("size"));
            System.Threading.Thread.Sleep(100);
            gerigit:
            Random rnd = new Random();
            int rastgelesayi = rnd.Next(1, 6);
            Console.WriteLine(rastgelesayi);
            System.Threading.Thread.Sleep(300);
            IWebElement elementsa = driver.FindElement(By.XPath("/html/body/div[3]/div/div[2]/div[2]/div[2]/div[2]/div[1]/div/div[1]/div/div/div/div[" + rastgelesayi + "]/label"));
            string beden = elementsa.Text;
            elementsa.Click();
            System.Threading.Thread.Sleep(300);
            if (elementsa.GetAttribute("class") == "radio-box__label -disabled")
            {
                goto gerigit;
            }
            System.Threading.Thread.Sleep(1000);
            IWebElement elementsar = driver.FindElement(By.XPath("/html/body/div[2]/header/div/div/div[3]/div[2]/div/div/div[2]/div/div[2]/span[1]"));
            Console.WriteLine(elementsar.Text);
            string fiyat = elementsar.Text;
            System.Threading.Thread.Sleep(1000);
            IWebElement elementsaa = driver.FindElement(By.CssSelector(".header__basketModal.-checkout"));
            elementsaa.Click();
            System.Threading.Thread.Sleep(3000);

            IWebElement elementsr = driver.FindElement(By.ClassName("cartItem__price"));
            Console.WriteLine(elementsr.Text);
            string fiyat2 = elementsr.Text;
            IWebElement elementsra = driver.FindElement(By.ClassName("cartItem__attrValue"));
            Console.WriteLine(elementsra.Text);
            string beden2 = elementsra.Text;
            if (fiyat == fiyat2 && beden == beden2)
            {
                Console.WriteLine("İşlem Başarılı");
                IWebElement element10 = driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div[1]/div[1]/div[2]/section/div[3]/div/div/div[1]/div[3]/span[2]"));
                Console.WriteLine(element10.Text);
                string indirimsizf = element10.Text;
                System.Threading.Thread.Sleep(1000);
                string yindirimsizfiyat = indirimsizf.Replace("TL", "");
                string yindirimsizfiyat2 = yindirimsizfiyat.Trim(' ');
                string yindirimsizfiyat3 = yindirimsizfiyat2.Replace(",", "");
                string yindirimsizfiyat4 = yindirimsizfiyat3.Replace(".", "");
                int yindirimsizfiyat5 = Int32.Parse(yindirimsizfiyat4);
                Console.WriteLine(yindirimsizfiyat2);
                Console.WriteLine(yindirimsizfiyat5);
                string yindirimlifiyat = fiyat2.Replace("TL", "");
                string yindirimlifiyat2 = yindirimlifiyat.Trim(' ');
                string yindirimlifiyat3 = yindirimlifiyat2.Replace(",", "");
                string yindirimlifiyat4 = yindirimlifiyat3.Replace(".", "");
                int yindirimlifiyat5 = Int32.Parse(yindirimlifiyat4);
                Console.WriteLine(yindirimlifiyat5);
                if (yindirimsizfiyat5 > yindirimlifiyat5)
                {
                    Console.WriteLine("Doğru");
                    System.Threading.Thread.Sleep(500);
                    IWebElement devam = driver.FindElement(By.ClassName("continueButton"));

                    devam.Click();
                    System.Threading.Thread.Sleep(500);
                    driver.FindElement(By.Id("n-input-email")).SendKeys(TestContext.DataRow[0].ToString());
                    driver.FindElement(By.Id("n-input-password")).SendKeys(TestContext.DataRow[1].ToString());
                    System.Threading.Thread.Sleep(1000);
                    driver.FindElement(By.XPath("/html/body/div[4]/div/div/div/div/div[1]/div[1]/form/button")).Click();
                    System.Threading.Thread.Sleep(1000);
                    IWebElement element11 = driver.FindElement(By.CssSelector(".img-fluid"));
                    element11.Click();
                    System.Threading.Thread.Sleep(1000);
                    IWebElement element12 = driver.FindElement(By.CssSelector(".header__icon"));
                    element12.Click();
                    System.Threading.Thread.Sleep(1000);
                    IWebElement element13 = driver.FindElement(By.XPath("/html/body/div[2]/header/div/div/div[3]/div[2]/div/div/div[2]/div/div[3]"));
                    element13.Click();
                    System.Threading.Thread.Sleep(1000);
                    IWebElement element14 = driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div/div[2]/button[2]"));
                    element14.Click();
                    System.Threading.Thread.Sleep(2000);
                    element12.Click();
                    System.Threading.Thread.Sleep(1000);
                    IWebElement elementsarrr = driver.FindElement(By.ClassName("header__emptyBasketText"));

                    if (elementsarrr.Text != "")
                    {
                        Console.WriteLine("Sepet boş");
                    }
                }
            }
            else
            {
                Console.WriteLine("İşlem Başarısız");
            }





        }
    }
}

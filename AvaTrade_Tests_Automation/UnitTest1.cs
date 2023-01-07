using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.Globalization;
using OpenQA.Selenium.Support.UI;

/*
 * install packages
 * 1- NUnit
 * 2- NUnitTestAdapter
 * 3- Selenium.WebDriver
 * 4- Selenium.Support
 * */



namespace AvaTrade_Tests_Automation
{
    [TestFixture]
    public class UnitTest1
    {
        IWebDriver driver;
        [SetUp]
        public void setup()
        {
            driver = new ChromeDriver(@"C:\Users\97252");
            driver.Url = "https://www.avatrade.com/";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }
        [TearDown]
        public void teardown()
        {
            driver.Close();
        }

        /*
         * TC001
          This test goes to the www.avatrade.com website
          Click on the login button
          Enter email and password in the appropriate fields and click SUBMIT
          (Sometimes recognizes an automation action so displays a button that asks to be pressed and held)
          Going to the login page
          Checks that after the word WELCOME the first name of the account holder "rami"
         */

        [Test]
        public void TC001_test_login_name()
        {
            driver.Manage().Window.Size = new System.Drawing.Size(1552, 832);
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            driver.FindElement(By.CssSelector(".log-in-desktop > .link-btn")).Click();
            driver.FindElement(By.Id("logEmailInput")).Click();
            String email = "rami19shehk@gmail.com";
            driver.FindElement(By.Id("logEmailInput")).SendKeys(email);
            driver.FindElement(By.Id("password")).Click();
            driver.FindElement(By.Id("password")).SendKeys("Rami1992sh!@#");
            driver.FindElement(By.Id("password")).SendKeys(Keys.Enter);
            //After logging in to the website, a window pops up from the website that fails the test,
            //did sleep for a few seconds to close the window before it fails the test
            Thread.Sleep(9000);
            driver.FindElement(By.CssSelector("#menuItem2 > .logo-text-table:nth-child(2) .contetn")).Click();
            string name_account = driver.FindElement(By.XPath("//*[@id=\"welcomeText\"]")).Text;
            Assert.IsTrue(name_account.Contains("rami shehk"));
        }


        /*
         * TC002
         * This test goes to the www.avatrade.com website and clicks on one of the trading list
         * checks if the percentage written on the high side is really greater than the percentage on the low side
         * the possibility to check on which trade number the test will be performed
         * if the TRADE number entered is not within the range then the test fails
         
         */

        [Test]
        [TestCase(2)]
        public void TC002_test_high_low_in_tranding_list(int index_of_trade)
        {
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            int cnt = driver.FindElements(By.ClassName("instrument-title")).Count;
            if (index_of_trade > 0 && index_of_trade <= cnt)
            {

                driver.FindElements(By.ClassName("instrument-title"))[index_of_trade - 1].Click();
                Thread.Sleep(4000);
                string high = driver.FindElement(By.CssSelector("#ws_bind_ph > div > div.instrument-hight-low > div.hight-low-wrap > span.high-value.ws-bind-high")).Text;
                string low = driver.FindElement(By.CssSelector("#ws_bind_ph > div > div.instrument-hight-low > div.hight-low-wrap > span.low-value.ws-bind-low")).Text;
                float f_high = float.Parse(high, CultureInfo.InvariantCulture.NumberFormat);
                float f_low = float.Parse(low, CultureInfo.InvariantCulture.NumberFormat);
                Assert.Greater(f_high, f_low);
            }
            else Assert.Fail();
        }

        /*
         * TC003
         Click on hamburger list on the left edge of the screen
         Click on the search field and type "what is forex"
         Click on the first result
         Check if the page title is the same as the search
        */

        [Test]
        public void TC003_hamburger_list_and_search()
        {
            driver.FindElement(By.CssSelector(".hamburger")).Click();
            driver.FindElement(By.Name("s")).Click();
            string search = "what is forex";
            driver.FindElement(By.Name("s")).SendKeys(search);
            driver.FindElement(By.Name("s")).SendKeys(Keys.Enter);
            driver.FindElement(By.LinkText("What is Forex")).Click();
            string page_title = driver.FindElement(By.CssSelector("#post-775 > div.art_head_cont > header > h1")).Text;
            Assert.IsTrue(search==page_title.ToLower());
        }

        




    }
}

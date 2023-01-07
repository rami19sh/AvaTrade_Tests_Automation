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
          Clicks on the login button.
          Enters the email and password in the appropriate fields and clicks SUBMIT
          (Sometimes, the website's system detects the automation process and tries to prevent it by displaying a button that needs to be pressed and held as some kind of Captcha to make sure “a human is using it”)
          Navigates to the login page 
          After logging in, the test validates that the username used to login is indeed the relevant one,
          by checking the name after the word WELCOME, in this example it checks if it’s “rami”  
         */

        [Test]
        public void TC001_test_login_name()
        {
            driver.Manage().Window.Size = new System.Drawing.Size(1552, 832);
            driver.FindElement(By.CssSelector(".log-in-desktop > .link-btn")).Click();
            driver.FindElement(By.Id("logEmailInput")).Click();
            String email = "rami19shehk@gmail.com";
            driver.FindElement(By.Id("logEmailInput")).SendKeys(email);
            driver.FindElement(By.Id("password")).Click();
            driver.FindElement(By.Id("password")).SendKeys("Rami1992sh!@#");
            driver.FindElement(By.Id("password")).SendKeys(Keys.Enter);
            /*
            Sometimes after logging in, a pop-up window appears and it blocks the elements that the automation test
             checks in order to work correctly. To solve this issue, a delay (sleep) of a few seconds is added
             in order to close this pop-up window, and prevent any issue caused by it
            */
            Thread.Sleep(9000);
            driver.FindElement(By.CssSelector("#menuItem2 > .logo-text-table:nth-child(2) .contetn")).Click();
            string name_account = driver.FindElement(By.XPath("//*[@id=\"welcomeText\"]")).Text;
            Assert.IsTrue(name_account.Contains("rami shehk"));
        }


        /*
         * TC002
         This test goes to the www.avatrade.com website and clicks on one of the trading lists
         Compares the values of the sections high/low, and checks if the value of the section “high”
         is indeed greater than the value “low”

        There is also in a function that allows the user to choose in which trade he wants
        to compare the high-low values(TestCase). The user can do so by counting from top to bottom
        in ascending order to choose the trade he wants for example, If the user wants to compare the high/low sections
        of Tesla’s trade for example, he clicks “5” 
         
         */

        [Test]
        [TestCase(2)]
        public void TC002_test_high_low_in_tranding_list(int index_of_trade)
        {
            int cnt = driver.FindElements(By.ClassName("instrument-title")).Count;
            if (index_of_trade > 0 && index_of_trade <= cnt)
            {

                driver.FindElements(By.ClassName("instrument-title"))[index_of_trade - 1].Click();
                /*
                   At the entrance of the page the data will be 0
                   You have to wait about 2 seconds until the data is updated
                */
                Thread.Sleep(3000);
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
         The test clicks on the “Hamburger menu"
         Navigates to the search field, types “what is forex”
         Clicks on the first result, after the page loads,
         compares that the title of this page is indeed the one searched for.
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

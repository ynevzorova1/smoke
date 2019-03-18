using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Smoke
{
    public class OldQaLight
            {

                IWebDriver driver;
        
                    [SetUp]
                public void SetUp()
                {
                    driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://old.qalight.com.ua/zapisatsya-na-kursy.html");
            }

                    [Category("Smoke")]

                    [Test]

                    public void SmokeTest()
                {

            IWebElement course = driver.FindElement(By.CssSelector("[name='_7c8289bf6b8e80c1749ef54ab01b92b8']"));
            SelectElement courseDropdown = new SelectElement(course);
            courseDropdown.SelectByIndex(3);

                    IWebElement surnameField = driver.FindElement(By.Id("z_sender0"));
                    surnameField.SendKeys("Surname");

                    IWebElement nameField = driver.FindElement(By.Id("z_text1"));
                    nameField.SendKeys("Name");

            IWebElement phoneNumber = driver.FindElement(By.Id("z_text0"));
            phoneNumber.SendKeys("80503322587");

            Thread.Sleep(2000);
                }

        public bool IsElementPresent(string cssSelector,IWebDriver driver)
        {

           var elements = driver.FindElement(By.CssSelector(cssSelector)); 
            if (elements.Count ==1)
            {
                return true;
            }
            else if (elements.Count == 0)
            {
                return false;
            }
            else
            {
                throw new Exception ;
            }

            Assert.True(IsElementPresent(driver, expectedElementLocator),
        }
                }
            }
        

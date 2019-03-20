﻿using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using Smoke;

namespace QaLight
{
    public class UnitTest1
    {
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("http://old.qalight.com.ua/zapisatsya-na-kursy.html");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Category("Smoke")]

        [Test]

        public void SmokeTestWithPageObject_Negative()
        {

            //Arrange

            //Act
            OldQaLightPage oldQaLightPage = new OldQaLightPage(driver);
            var course = oldQaLightPage.course;
           
            SelectElement courseDropdown = new SelectElement(course);
            courseDropdown.SelectByIndex(3);

            oldQaLightPage.surnameField.SendKeys("Surname");

            oldQaLightPage.NameField.SendKeys("Name");


            // Assert

            Assert.True(IsElementPresent(oldQaLightPage.errorRegistrationPopup),
                $"Element  {nameof  (oldQaLightPage.errorRegistrationPopup)} is not present on the page");

        }

        public bool IsElementPresent (IWebElement element)
       
            {
            try
            {
                var result = element.Displayed;
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            throw new Exception("Unexpected Exeption");
        }

              [Category("Smoke")]
        [Test]
        public void SmokeTest()
        {
            string expectedElementLocator = ".alert.alert-error";

            IWebElement course = driver.FindElement(By.CssSelector("[name = '_7c8289bf6b8e80c1749ef54ab01b92b8']"));
            SelectElement courseDropdown = new SelectElement(course);
            courseDropdown.SelectByIndex(3);

            IWebElement surnameField = driver.FindElement(By.Id("z_sender0"));
            surnameField.SendKeys("Surname");

            IWebElement nameField = driver.FindElement(By.Id("z_text1"));
            nameField.SendKeys("Name");

            IWebElement phoneNumber = driver.FindElement(By.Id("z_text0"));
            phoneNumber.SendKeys("067112233");

            IWebElement emailField = driver.FindElement(By.Id("z_sender1"));
            emailField.SendKeys("afdsafsa@ukr.net");

            IWebElement skypeField = driver.FindElement(By.Id("z_text2"));
            skypeField.SendKeys("dsafasfassf");

            IWebElement sourceInfo = driver.FindElement(By.CssSelector("[name = '_e926ba2b2813f56de8fc13877057e908']"));
            SelectElement sourceInfoDropdown = new SelectElement(sourceInfo);
            sourceInfoDropdown.SelectByIndex(4);

            IWebElement submit = driver.FindElement(By.CssSelector("[type = submit]"));
            submit.Click();

            //IWebElement successElement = driver.FindElement(By.CssSelector(".alert.alert-success"));

            //IWebElement errorElement = driver.FindElement(By.CssSelector(".alert.alert-error"));

            Assert.True(IsElementPresent(driver, expectedElementLocator),
                $"Element with locator {expectedElementLocator} is not present on the page");

        }

        public bool IsElementPresent(IWebDriver driver, string cssSelector)
        {
            var elements = driver.FindElements(By.CssSelector(cssSelector));

            if (elements.Count == 1)
            {
                return true;
            }
            else if (elements.Count == 0)
            {
                return false;
            }
            else
            {
                throw new Exception("Unexpected exception");
            }
        }
    }
}

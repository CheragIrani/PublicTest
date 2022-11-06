using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Easyjet.Helper
{
    public static class Element
    {
        public static void ScrollToElement(IWebDriver driver, By element)
        {
            String scrollElementIntoMiddle = "var viewPortHeight = Math.max(document.documentElement.clientHeight, window.innerHeight || 0);"
                                                        + "var elementTop = arguments[0].getBoundingClientRect().top;"
                                                        + "window.scrollBy(0, elementTop-(viewPortHeight/2));";
            ((IJavaScriptExecutor)driver).ExecuteScript(scrollElementIntoMiddle, driver.FindElement(element));
        }

        public static bool IsElementDisplayed(this IWebDriver driver, By element)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            try
            {
                return driver.FindElement(element).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public static void VerifyPageElementsAreDisplayed(IWebDriver driver, IEnumerable<By> pageElements)
        {
            foreach (var pageElement in pageElements)
            {
                Assert.IsTrue(Element.IsElementDisplayed(driver, pageElement), $"{pageElement} is not displayed");
            }
        }

        public static bool IsElementEnabled(IWebDriver driver, By element)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            try
            {
                return driver.FindElement(element).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }

        }

        public static void Click(this IWebDriver driver, By element)
        {
            if (IsElementDisplayed(driver, element))
            {
                ScrollToElement(driver, element);
                driver.FindElement(element).Click();
                Thread.Sleep(500);
            }
            else
            {
                throw new Exception($"Element by {element} is not displayed.");
            }

        }

        public static void SendKeys(this IWebDriver driver, By element, string keys)
        {
            if (IsElementDisplayed(driver, element))
            {
                ScrollToElement(driver, element);
                driver.FindElement(element).SendKeys(keys);
                Thread.Sleep(500);
            }
            else
            {
                throw new Exception($"Element by {element} is not displayed.");
            }
        }

        public static string GetText(IWebDriver driver, By element)
        {
            return IsElementDisplayed(driver, element) ? driver.FindElement(element).Text : throw new Exception($"Element by {element} is not displayed.");
        }

    }
}

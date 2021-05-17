using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Support.UI;


namespace QA_Automation_Assessment
{
     public class Actions
    {
        public static IWebDriver webDriver;
        public Actions(ScenarioContext scenarioContext)
        {
            webDriver = scenarioContext["WEB_DRIVER"] as IWebDriver;
        }

        public Actions()
        {
        }

        public static IJavaScriptExecutor getExecutor()
        {
            return (IJavaScriptExecutor)webDriver;
        }
            public void waitForClickable(IWebElement element)
        {
            var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, 5));

            var catalog = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }
            public void click(IWebElement element)
        {
            waitForClickable(element);
            try
            {
                element.Click();
            }
            catch (ElementClickInterceptedException e)
            {
                Console.WriteLine("Clicking with JS");
                clickWithJS(element);
            }
        }
        public void clickWithJS(IWebElement element)
        {
            getExecutor().ExecuteScript("arguments[0].click();", element);
        }

    }
}

using OpenQA.Selenium;
using TechTalk.SpecFlow;
using NUnit.Framework;
using SeleniumExtras;
using OpenQA.Selenium.Support.UI;
using System;


namespace QA_Automation_Assessment
{
    [Binding]
    public class StepDefs : Actions
    {  
        public StepDefs(ScenarioContext scenarioContext)
        {
            webDriver = scenarioContext["WEB_DRIVER"] as IWebDriver;
        }
      
        [Given(@"I have navigated to the ""(.*)"" environment")]
        public void GivenIHaveNavigatedToThePage(string environment)
        {
            switch (environment)
            {
                case "staging":
                    webDriver.Url = $"https://stage-v3.egifter.com/";
                    break;
            }
        }
        
        [When(@"I click ""(.*)"" menu option")]
        public void WhenIClickMenuOption(string menuOption)
        {
            var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, 5));
            _ = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//ul[contains(@class,'navigationList')]")));
            IWebElement Option = webDriver.FindElement(By.XPath("//ul[contains(@class,'navigationList')]//span[@token='" + menuOption + "']"));
            click(Option);
            
        }

        [When(@"I choose the category ""(.*)""")]
        public void WhenIChooseTheCategory(string category)
        { 
            var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, 5));
            _ = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[@data-testid='Giftcards_CategoriesMenu_Category_" + category + "']")));
            IWebElement submitButton = webDriver.FindElement(By.XPath("//a[@data-testid='Giftcards_CategoriesMenu_Category_" + category + "']"));
            click(submitButton);
              
        }

        [When(@"I choose the brand ""(.*)"" from the catalog")]
        public void WhenIChooseTheBrandFromTheCatalog(string brand)
        {
            var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, 5));
            _ = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//title[contains(text(),'" + brand + "')]/..")));
            IWebElement brandOption = webDriver.FindElement(By.XPath("//title[contains(text(),'" + brand + "')]/.."));
            click(brandOption);
            
        }
        
        [When(@"I choose the (.*) dollar value")]
        public void WhenIChooseDollarValue(int dollarValue)
        {
            var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, 5));
            _ = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[@data-testid='DenominationQuickSelect_SelectAmountButton_" + dollarValue + "']")));
            IWebElement valueOption = webDriver.FindElement(By.XPath("//button[@data-testid='DenominationQuickSelect_SelectAmountButton_" + dollarValue + "']"));
            click(valueOption);

        }

        [When(@"I add the item to the cart using the ""(.*)"" button")]
        public void WhenIAddTheItemToTheCartUsingTheButton(string button)
        {
            var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, 5));
            _ = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//span[contains(@token,'GiftCardCatalog_CardDetails')][text()='" + button + "']")));
            IWebElement buttonOption = webDriver.FindElement(By.XPath("//span[contains(@token,'GiftCardCatalog_CardDetails')][text()='" + button + "']"));
            click(buttonOption);
        }
        
        [When(@"I navigate to the checkout page using the ""(.*)"" button")]
        public void WhenINavigateToTheCheckoutPageUsingTheButton(string buttonName)
        {
            var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, 5));
            IWebElement buttonType = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@data-testid,'Cart_CartActions')]//span[contains(text(),'" + buttonName + "')]")));
            IWebElement buttonOption = webDriver.FindElement(By.XPath("//button[contains(@data-testid,'Cart_CartActions')]//span[contains(text(),'" + buttonName + "')]"));
            click(buttonOption);
        }
        
        [When(@"I click the button ""(.*)""")]
        public void WhenIClickTheButton(string buttonName)
        {
            var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, 5));
            IWebElement buttonType = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//span[@token='" + buttonName + "']")));
            IWebElement button = webDriver.FindElement(By.XPath("//span[@token='" + buttonName + "']"));
            click(button);
        }
        
        [When(@"I choose the ""(.*)"" payment method")]
        public void WhenIChooseThePaymentMethod(string paymentMethod)
        {
         
            var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, 5));
            _ = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[@data-testid='PaymentTilesContainer_PaymentMethodButton_" + paymentMethod + "']")));
            IWebElement option = webDriver.FindElement(By.XPath("//button[@data-testid='PaymentTilesContainer_PaymentMethodButton_" + paymentMethod + "']"));
            click(option);
        }

        [When(@"I verify my phone number")]
        public void WhenIVerifyMyPhoneNumber()
        {
            var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, 5));
            IWebElement buttonType = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//input[@name='PhoneVerification.Phone']")));
            webDriver.FindElement(By.XPath("//input[@name='PhoneVerification.Phone']")).SendKeys("5555555555");
            IWebElement button = webDriver.FindElement(By.XPath("//span[@token='PhoneVerification_SendCodeButton']/.."));
            click(button);
            var phoneVerification = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//input[@name='PhoneVerification.Token']")));
            phoneVerification.SendKeys("11111");
            //button[@data-testid='PhoneVerification_VerifyPhoneNumberButton']
            IWebElement submit = webDriver.FindElement(By.XPath("//button[@data-testid='PhoneVerification_VerifyPhoneNumberButton']"));
            click(submit);
        }

        [When(@"I fill out my card information")]
        public void WhenIFillOutMyCardInformation()
        {
            //input[@placeholder='Checkout_Form_CardNamePlaceholder']
            var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, 10));
            var Name = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//input[@placeholder='Checkout_Form_CardNamePlaceholder']")));
            Name.SendKeys("Test Candidate");
            webDriver.FindElement(By.XPath("//input[@data-testid='CreditCardFormPartial_CardNumberInputField']")).SendKeys("4111 1111 1111 1111");
            webDriver.FindElement(By.XPath("//select[@data-testid='CreditCardFormPartial_CardExpirationMonthSelect']/option[@value='1']")).Click();
            webDriver.FindElement(By.XPath("//select[@data-testid='CreditCardFormPartial_CardExpirationYearSelect']/option[contains(text(),'2030')]")).Click();
            webDriver.FindElement(By.XPath("//input[@data-testid='CreditCardFormPartial_CardCVVInputField']")).SendKeys("123");
            webDriver.FindElement(By.XPath("//input[@data-testid='AddressFormPartial_AddressLine1InputField']")).SendKeys("315 Main Street");
            webDriver.FindElement(By.XPath("//input[@data-testid='AddressFormPartial_CityInputField']")).SendKeys("Huntington");
            webDriver.FindElement(By.XPath("//select[@data-testid='AddressFormPartial_StateSelect']/option[@value='NY']")).Click();
            webDriver.FindElement(By.XPath("//input[@data-testid='AddressFormPartial_ZipCodeInputField']")).SendKeys("11743");
            webDriver.FindElement(By.XPath("//input[@data-testid='ConfirmEmailInput_FirstEmailInputField']")).SendKeys("test@egifter.com");
            webDriver.FindElement(By.XPath("//input[@data-testid='ConfirmEmailInput_SecondEmailInputField']")).SendKeys("test@egifter.com");

        }

        [When(@"I click ""(.*)""")]
        public void WhenIClick(string buttonName)
        {
            var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, 5));
            var button = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//span[@token='Checkout_Form_CheckoutButton']")));
            IWebElement CheckoutButton = webDriver.FindElement(By.XPath("//span[@token='Checkout_Form_CheckoutButton']"));
            click(CheckoutButton);
        }
        
        [Then(@"I wait for the gift catalog to load")]
        public void ThenIWaitForTheGiftCatalogToLoad()
        {
            var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, 5));

            var catalog = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='categoriesMenuComponent']")));
        }

        [Then(@"I ensure cart page has loaded correctly and displays the item and the total amount due")]
        public void ThenIEnsureCartPageHasLoadedCorrectlyAndDisplaysTheItemAndTheTotalAmountDue()
        {
            var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, 5));
            var page = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//main[@id='main-content']")));
            var total = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@data-testid='Cart_Summary_TotalItemsCost']")));

            String result = webDriver.FindElement(By.XPath("//div[@data-testid='Cart_Summary_TotalItemsCost']")).Text;

            Assert.That((result).Contains("$50.00"));
        }
        
        [Then(@"I ensure the page has loaded correctly and a summary of items is shown on the left")]
        public void ThenIEnsureThePageHasLoadedCorrectlyAndASummaryOfItemsIsShownOnTheLeft()
        { 
            //verify the page has loaded correctly
            var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, 50));
            var spinner = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//svg[@class='spinner']")));
            var page = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='checkoutSummaryComponent panel panel-stroke']")));
            
            // verify summary of items is shown on the left side
            IWebElement summary = webDriver.FindElement(By.XPath("//div[@class='checkoutSummaryComponent panel panel-stroke']"));
            
            //get window size
            int winWidth = webDriver.Manage().Window.Size.Width;

            //get x and y location of the element
            int x = summary.Location.X;
            int y = summary.Location.Y;

            //verify the x axis of the element is less than the width of the whole window divided by 2 

            int elementWidth = summary.Size.Width;
            Assert.IsTrue((x + elementWidth) < winWidth / 2);

        }
        
        [Then(@"I ensure payment methods are shown properly")]
        public void ThenIEnsurePaymentMethodsAreShownProperly()
        {
            
            var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, 5));
            var paymentMethod = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[@class='paymentMethodTile']")));
           
        }
        
        [Then(@"I Ensure that the Order Confirmation page loads and displays the order details properly")]
        public void ThenEnsureThatTheOrderConfirmationPageLoadsAndDisplaysTheOrderDetailsProperly()
        {
            //Work with iframe
            var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, 20));
            var iframe = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//iframe[@id='Cardinal-CCA-IFrame']")));
            webDriver.SwitchTo().Frame(webDriver.FindElement(By.XPath("//iframe[@id='Cardinal-CCA-IFrame']")));
            webDriver.FindElement(By.XPath("//input[@name='challengeDataEntry']")).SendKeys("1234");
            webDriver.FindElement(By.XPath("//input[@value='SUBMIT']")).Click(); 
            
            //Verify the details
            var summary = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[@data-testid='OrderSummary_OrderSummaryComponent']")));
            String result = webDriver.FindElement(By.XPath("//div[@data-testid='OrderSummary_OrderSummaryComponent']")).Text;
            Assert.That((result).Contains("Test Candidate"));
            Assert.That((result).Contains("5555555555"));
            Assert.That((result).Contains("315 Main Street"));
            Assert.That((result).Contains("Huntington"));
            Assert.That((result).Contains("NY"));
            Assert.That((result).Contains("11743"));
            Assert.That((result).Contains("test@egifter.com"));
        }
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace dotnet_selenium_worker
{
    public class EtsyCracker
    {
        public void FindProduct(ChromeDriver driver)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                string searchKeyword = "christmas stocking";
                string searchListingId = "listing-title-1588887551";
                var searchBox = driver.FindElement(By.Name("search_query"));
                searchBox.SendKeys(searchKeyword);
                searchBox.SendKeys(Keys.Return);

                bool found = false;

                while (!found)
                {
                    var listings = driver.FindElements(By.XPath("//div[@class='wt-grid wt-pl-xs-0 wt-pr-xs-0 search-listings-group']//h3[@id]"));
                    foreach (var listing in listings)
                    {
                        if (listing.GetAttribute("id") == searchListingId)
                        {

                            new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                            string pageNumber = driver.Url.Substring(Math.Max(0, driver.Url.Length - 6));
                            Console.WriteLine(pageNumber);
                            listing.Click();
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        var nextButton = driver.FindElement(By.XPath("//div//nav//ul//li[@class='wt-action-group__item-container']//following::span[text()='Next'][2]//following::span[@class='wt-icon--smaller etsy-icon']"));
                        nextButton.Click();
                        new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                    }
                    new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                }
                driver.Quit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                driver.Quit();
            }
        }
    }
}
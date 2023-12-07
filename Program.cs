using OpenQA.Selenium.Chrome;
var chromeOptions = new ChromeOptions();
chromeOptions.AddArgument("--headless");

using (var driver = new ChromeDriver(chromeOptions))
{
    driver.Navigate().GoToUrl("https://demo3.kodzip.com/");
    Console.WriteLine("Page Title: " + driver.Title);
}

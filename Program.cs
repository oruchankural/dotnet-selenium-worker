
using dotnet_selenium_worker;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

var chromeOptions = new ChromeOptions();
var proxy = new Proxy();
proxy.Kind = ProxyKind.Manual;
proxy.HttpProxy = "https://proxymesh.com/account/proxy_status/us-fl:31280";
proxy.SslProxy = "https://proxymesh.com/account/proxy_status/us-fl:31280";
//chromeOptions.Proxy = proxy;

var driverService = ChromeDriverService.CreateDefaultService();
driverService.HideCommandPromptWindow = true;

var driver = new ChromeDriver(driverService, chromeOptions, TimeSpan.FromSeconds(80));
string etsyUrl = "https://www.etsy.com";
driver.Navigate().GoToUrl(etsyUrl);


EtsyCracker etsyCracker = new EtsyCracker();
etsyCracker.FindProduct(driver);

/*driver.Navigate().GoToUrl("http://support.cloudsupporttest.con.tc/");

string email = "x";
string password = "x";

var inputEmail = driver.FindElement(By.Id("inputEmail"));
inputEmail.SendKeys(email);

var inputPassword = driver.FindElement(By.Id("inputPassword"));
inputPassword.SendKeys(password);

var loginButton = driver.FindElement(By.XPath("//button[contains(text(),'Giriş')]"));
loginButton.Click();

for (int i = 0; i < 100; i++)
{
    driver.Navigate().GoToUrl("http://support.cloudsupporttest.con.tc/new-ticket/");

    var receiverSelect = new SelectElement(driver.FindElement(By.Id("ReceiverId")));
    var receiverOptions = receiverSelect.Options;
    var selectedReceiver = receiverOptions[new Random().Next(1, receiverOptions.Count)];
    receiverSelect.SelectByText(selectedReceiver.Text);

    var senderSelect = new SelectElement(driver.FindElement(By.Id("senderFirm")));
    senderSelect.SelectByValue("FEY");

    var importanceSelect = new SelectElement(driver.FindElement(By.Id("ImportanceLevel")));
    var importanceOptions = importanceSelect.Options;
    var selectedImportance = importanceOptions[new Random().Next(1, importanceOptions.Count)];
    importanceSelect.SelectByText(selectedImportance.Text);

    var ticketTypeSelect = new SelectElement(driver.FindElement(By.Id("TicketTypeCode")));
    var ticketTypeOptions = ticketTypeSelect.Options;
    var selectedTicketType = ticketTypeOptions[new Random().Next(1, ticketTypeOptions.Count)];
    ticketTypeSelect.SelectByValue(selectedTicketType.GetAttribute("value"));

    string randomSubject = new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz", 10)
        .Select(s => s[new Random().Next(s.Length)]).ToArray());

    var subjectInput = driver.FindElement(By.Id("Subject"));
    subjectInput.SendKeys(randomSubject);

    string randomDescription = new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz", 20)
        .Select(s => s[new Random().Next(s.Length)]).ToArray());

    var descriptionInput = driver.FindElement(By.XPath("//div[@class='note-editable']"));
    descriptionInput.SendKeys(randomDescription);

    var createButton = driver.FindElement(By.XPath("//button[contains(text(),'Talep Oluştur')]"));
    createButton.Click();

    Thread.Sleep(5000);

    var talepBilgileri = driver.FindElement(By.XPath("//div[@class='text-left']"));
    var bilgiler = talepBilgileri.FindElements(By.XPath("a"));

    foreach (var bilgi in bilgiler)
    {
        string bilgiText = bilgi.Text;
        Console.WriteLine(bilgiText);
    }
}

<<<<<<< HEAD
driver.Quit();*/
=======
driver.Quit();
>>>>>>> 363b72c6c21060e4038c57523cee8d289cc9ffc9

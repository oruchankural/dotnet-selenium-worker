
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using OpenQA.Selenium.Support.UI;

var chromeOptions = new ChromeOptions();
chromeOptions.AddArgument("--headless");
chromeOptions.AddArgument("--disable-gpu");
chromeOptions.AddArgument("--no-sandbox");
chromeOptions.AddArgument("--disable-dev-shm-usage");

var driverService = ChromeDriverService.CreateDefaultService();
driverService.HideCommandPromptWindow = true;

var driver = new ChromeDriver(driverService, chromeOptions, TimeSpan.FromSeconds(60));
// Web sayfasına gidin
driver.Navigate().GoToUrl("http://support.cloudsupporttest.con.tc/");

string email = "oruchan@feysoft.com.tr";
string password = "123123";

// Email ve şifre girişi
var inputEmail = driver.FindElement(By.Id("inputEmail"));
inputEmail.SendKeys(email);

var inputPassword = driver.FindElement(By.Id("inputPassword"));
inputPassword.SendKeys(password);

var loginButton = driver.FindElement(By.XPath("//button[contains(text(),'Giriş')]"));
loginButton.Click();

// Rastgele veriler
for (int i = 0; i < 100; i++)
{
    // Yeni bilet sayfasına gidin
    driver.Navigate().GoToUrl("http://support.cloudsupporttest.con.tc/new-ticket/");

    // Alıcı seçimi
    var receiverSelect = new SelectElement(driver.FindElement(By.Id("ReceiverId")));
    var receiverOptions = receiverSelect.Options;
    var selectedReceiver = receiverOptions[new Random().Next(1, receiverOptions.Count)];
    receiverSelect.SelectByText(selectedReceiver.Text);

    // Gönderen seçimi
    var senderSelect = new SelectElement(driver.FindElement(By.Id("senderFirm")));
    senderSelect.SelectByValue("FEY");

    // Önem seviyesi seçimi
    var importanceSelect = new SelectElement(driver.FindElement(By.Id("ImportanceLevel")));
    var importanceOptions = importanceSelect.Options;
    var selectedImportance = importanceOptions[new Random().Next(1, importanceOptions.Count)];
    importanceSelect.SelectByText(selectedImportance.Text);

    // Bilet tipi seçimi
    var ticketTypeSelect = new SelectElement(driver.FindElement(By.Id("TicketTypeCode")));
    var ticketTypeOptions = ticketTypeSelect.Options;
    var selectedTicketType = ticketTypeOptions[new Random().Next(1, ticketTypeOptions.Count)];
    ticketTypeSelect.SelectByValue(selectedTicketType.GetAttribute("value"));

    // Rastgele konu ve açıklama oluşturun
    string randomSubject = new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz", 10)
        .Select(s => s[new Random().Next(s.Length)]).ToArray());

    var subjectInput = driver.FindElement(By.Id("Subject"));
    subjectInput.SendKeys(randomSubject);

    string randomDescription = new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz", 20)
        .Select(s => s[new Random().Next(s.Length)]).ToArray());

    var descriptionInput = driver.FindElement(By.XPath("//div[@class='note-editable']"));
    descriptionInput.SendKeys(randomDescription);

    // Talep oluştur
    var createButton = driver.FindElement(By.XPath("//button[contains(text(),'Talep Oluştur')]"));
    createButton.Click();

    Thread.Sleep(5000); // Bekleme süresi

    // Talep bilgilerini al
    var talepBilgileri = driver.FindElement(By.XPath("//div[@class='text-left']"));
    var bilgiler = talepBilgileri.FindElements(By.XPath("a"));

    // Bilgileri dosyaya yaz

    foreach (var bilgi in bilgiler)
    {
        string bilgiText = bilgi.Text;
        Console.WriteLine(bilgiText);
    }
}

driver.Quit();
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text.RegularExpressions;

namespace LordsAPI_GiftActivator
{
    public class LordsMobileGift
    {
        public enum Methods
        {
            IGG_ID,
            Nickname,
        }
        public class UserInfo
        {
            public Results Result;
            public string Power;
            public int Kingdom;
        }
        public enum Results
        {
            Invalid_Code,
            Expired_Code,
            Invalid_Nickname,
            Invalid_IGG_ID,
            Sucess,
            System_Error,
            Already_Activated,
        }
        public static UserInfo Activate(Methods method, string igg_id, string promo)
        {
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;

            var options = new ChromeOptions();
            options.AddArgument("--window-position=-32000,-32000,performance");
            options.AddArgument("--headless");

            IWebDriver driver = new OpenQA.Selenium.Chrome.ChromeDriver(service, options);
            if (method == Methods.IGG_ID)
            {
                try
                {
                    driver.Manage().Window.Minimize();
                    driver.Navigate().GoToUrl("https://lordsmobile.igg.com/gifts/");

                    By igg_idInputElement = By.XPath("//input[@class='myname']");
                    By codeInputElement = By.XPath("//input[@class='mycode']");
                    By claimButton = By.Id("btn_claim_1");
                    By doneMessageElement = By.Id("msg");

                    var igg = driver.FindElement(igg_idInputElement);
                    var code = driver.FindElement(codeInputElement);
                    var submit = driver.FindElement(claimButton);

                    igg.Click();
                    igg.SendKeys(igg_id);
                    code.Click();
                    code.SendKeys(promo);
                    submit.Click();

                    var donemsg = driver.FindElement(doneMessageElement);
                    if (donemsg.Text != "Время действия кода истекло.[base]" && donemsg.Text != "Этот код уже был активирован!" && donemsg.Text != "Вы ввели неверный код.[C02]")
                    {
                        driver.Close();
                        driver.Quit();
                        return new UserInfo() { Kingdom = 0, Power = "0", Result = Results.Sucess };
                    }
                    else if (donemsg.Text == "Вы ввели неверный код.[C02]")
                    {
                        driver.Close();
                        driver.Quit();
                        return new UserInfo() { Kingdom = 0, Power = "0", Result = Results.Invalid_Code };
                    }
                    else if (donemsg.Text == "Время действия кода истекло.[base]")
                    {
                        driver.Close();
                        driver.Quit();
                        return new UserInfo() { Kingdom = 0, Power = "0", Result = Results.Expired_Code };
                    }
                    else if (donemsg.Text == "Этот код уже был активирован!")
                    {
                        driver.Close();
                        driver.Quit();
                        return new UserInfo() { Kingdom = 0, Power = "0", Result = Results.Already_Activated };
                    }
                    else
                    {
                        driver.Close();
                        driver.Quit();
                        return new UserInfo() { Kingdom = 0, Power = "0", Result = Results.System_Error };
                    }
                }
                catch
                {
                    return new UserInfo() { Kingdom = 0, Power = "0", Result = Results.System_Error };
                }
            }
            else if (method == Methods.Nickname)
            {
                try
                {
                    driver.Manage().Window.Minimize();
                    driver.Navigate().GoToUrl("https://lordsmobile.igg.com/gifts/");

                    var methodfind = driver.FindElement(By.ClassName("tab-list-2"));
                    methodfind.Click();
                    var nicknameInputfind = driver.FindElement(By.XPath("//input[@id='charname']"));
                    nicknameInputfind.Click();
                    nicknameInputfind.SendKeys(igg_id);
                    var code = driver.FindElement(By.XPath("//input[@id='cdkey_2']"));
                    code.Click();
                    code.SendKeys(promo);
                    var submit = driver.FindElement(By.Id("btn_claim_2"));
                    submit.Click();
                    var donemsg = driver.FindElement(By.Id("msg"));
                    if (donemsg.Text != "Игрок с таким именем не существует")
                    {
                        var extramsg = driver.FindElement(By.Id("extra_msg"));
                        int king = int.Parse(Regex.Match(extramsg.Text, "Королевство: #(.*)").Groups[1].Value);
                        string pow = (Regex.Match(extramsg.Text, "Сила: (.*)").Groups[1].Value);
                        var submit2 = driver.FindElement(By.Id("btn_confirm"));
                        submit2.Click();

                        var donemsg2 = driver.FindElement(By.Id("msg"));
                        if (donemsg2.Text != "Время действия кода истекло.[base]" && donemsg2.Text != "Этот код уже был активирован!" && donemsg2.Text != "Вы ввели неверный код.[C02]")
                        {
                            driver.Close();
                            driver.Quit();
                            return new UserInfo() { Kingdom = king, Power = pow, Result = Results.Sucess };
                        }
                        else if (donemsg2.Text == "Вы ввели неверный код.[C02]")
                        {
                            driver.Close();
                            driver.Quit();
                            return new UserInfo() { Kingdom = 0, Power = "0", Result = Results.Invalid_Code };
                        }
                        else if (donemsg2.Text == "Время действия кода истекло.[base]")
                        {
                            driver.Close();
                            driver.Quit();
                            return new UserInfo() { Kingdom = 0, Power = "0", Result = Results.Expired_Code };
                        }
                        else if (donemsg2.Text == "Этот код уже был активирован!")
                        {
                            driver.Close();
                            driver.Quit();
                            return new UserInfo() { Kingdom = king, Power = pow, Result = Results.Already_Activated };
                        }
                        else
                        {
                            driver.Close();
                            driver.Quit();
                            return new UserInfo() { Kingdom = 0, Power = "0", Result = Results.System_Error };
                        }
                    }
                    else
                    {
                        driver.Close();
                        driver.Quit();
                        return new UserInfo() { Kingdom = 0, Power = "0", Result = Results.Invalid_Nickname };
                    }
                }
                catch
                {
                    driver.Close();
                    driver.Quit();
                    return new UserInfo() { Kingdom = 0, Power = "0", Result = Results.System_Error };
                }
            }
            else
            {
                driver.Close();
                driver.Quit();
                return new UserInfo() { Kingdom = 0, Power = "0", Result = Results.System_Error };
            }
        }
    }
}

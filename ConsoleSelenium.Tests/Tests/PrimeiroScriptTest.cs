using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace ConsoleSelenium.Tests.Tests
{
    [TestClass]
    public class PrimeiroScriptTest
    {
        [TestMethod]
        public void TestAutomatizar_Envio_Texto_ComSucesso()
        {
            IWebDriver driver = new EdgeDriver();
            driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/web-form.html");

            var titulo = driver.Title;
            Assert.AreEqual("Web form", titulo);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            var textoBox = driver.FindElement(By.Name("my-text"));
            textoBox.SendKeys("Guilherme Navais");

            var submitButton = driver.FindElement(By.TagName("button"));
            submitButton.Click();

            var mensagemSucesso = driver.FindElement(By.Id("message"));
            Assert.AreEqual("Received!", mensagemSucesso.Text);

            driver.Quit();
        }
    }
}
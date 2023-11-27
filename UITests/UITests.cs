using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;
using System.Xml.Linq;
using Xunit;
using P05Shop.API;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore;

namespace UITests
{
    public class UITests
    {
        private readonly IWebDriver _driver;

        public UITests()
        {
            _driver = new ChromeDriver();
        }

        [Fact]
        public void TestCreate()
        {
            _driver.Navigate().GoToUrl("http://localhost:5123/CarBrands/create");
            WaitForLoad();
            // Fill out the form with test data
            var nameInput = _driver.FindElement(By.Id("Name"));
            nameInput.SendKeys("TestBrand");

            var originCountryInput = _driver.FindElement(By.Id("OriginCountry"));
            originCountryInput.SendKeys("TestCountry");

            // Click the "Save" button
            var saveButton = _driver.FindElement(By.ClassName("btn"));
            saveButton.Click();
           
            _driver.Navigate().GoToUrl("http://localhost:5123/CarBrands");
            WaitForLoad();

            var elements = _driver.FindElement(By.XPath("//table[@name='CarBrands']")).FindElements(By.XPath(".//tr"));
            Assert.NotNull(elements);
            Assert.Contains("TestBrand", elements.Last().Text);
            Assert.Contains("TestCountry", elements.Last().Text);
            _driver.Quit();
        }

        [Fact]
        public void TestRead()
        {
            // Assuming there is an existing entry for testing read operation
            _driver.Navigate().GoToUrl("http://localhost:5123/CarBrands");
            WaitForLoad();

            // Locate and click on an existing entry in the list
            var entery = _driver.FindElement(By.XPath("//tr"));

            Assert.NotNull(entery);
            _driver.Quit();
        }

        [Fact]
        public void TestUpdate()
        {
            // Assuming there is an existing entry for testing update operation
            _driver.Navigate().GoToUrl("http://localhost:5123/CarBrands");
            WaitForLoad();

            // Locate and click on an existing entry in the list
            var firstEntry = _driver.FindElement(By.XPath("//table[@Name='CarBrands'][1]"));
            var id = firstEntry.FindElement(By.XPath(".//td[1]")).Text;

            _driver.Navigate().GoToUrl($"http://localhost:5123/CarBrands/Edit/{id}");
            WaitForLoad();

            var nameInput = _driver.FindElement(By.Id("Name"));
            nameInput.SendKeys("TestBrand");

            var originCountryInput = _driver.FindElement(By.Id("OriginCountry"));
            originCountryInput.SendKeys("TestCountry");

            // Click the "Save" button
            var saveButton = _driver.FindElement(By.ClassName("btn"));
            saveButton.Click();
            WaitForLoad();

            var elements = _driver.FindElements(By.XPath(".//tr"));
            Assert.Contains("TestBrand", elements.Last().Text);
            Assert.Contains("TestCountry", elements.Last().Text);
            _driver.Quit();
        }

        [Fact]
        public void TestDelete()
        {
            // Assuming there is an existing entry for testing delete operation
            _driver.Navigate().GoToUrl("http://localhost:5123/CarBrands");
            WaitForLoad();

            // Locate and click on an existing entry in the list
            var firstEntry = _driver.FindElement(By.XPath("//table[@Name='CarBrands'][1]"));
            var id = firstEntry.FindElement(By.XPath(".//td[1]")).Text;

            _driver.Navigate().GoToUrl($"http://localhost:5123/CarBrands/Delete/{id}");
            WaitForLoad();

            // Click the "Delete" button
            var deleteButton = _driver.FindElement(By.ClassName("btn"));
            deleteButton.Click();

            WaitForLoad();

            Assert.DoesNotContain(_driver.FindElements(By.XPath("//table[@Name='CarBrands']")), e => e.Text.Contains($" {id} "));
            _driver.Quit();
        }

        private void WaitForLoad()
        {
            Thread.Sleep(5000);
        }
    }
}

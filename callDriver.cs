using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V122.Database;

namespace Crawl_Test
{
	public class callDriver
	{
		IWebDriver driver = new ChromeDriver();
		public List<Phone> CrawlPhone()
		{
			List<Phone> items = new List<Phone>();
			driver.Navigate().GoToUrl("https://bstackdemo.com/");
			IReadOnlyCollection<IWebElement> productElements = driver.FindElements(By.CssSelector("ul.products"));

			// Loop through the product elements and extract the desired information
			foreach (IWebElement productElement in productElements)
			{
				// Extract the name and price of the product
				string name = productElement.FindElement(By.ClassName("shelf-item__title")).Text;
				string price = productElement.FindElement(By.ClassName("val")).Text;
				var imagePath = productElement.FindElement((By.ClassName("shelf-item__thumb"))).FindElement((By.TagName("img"))).Text;
				Phone phone = new Phone();
				// Add the item details to the list
				phone.Name = name;
				phone.Price = price;
				
				items.Add(phone);
			}
			return items;
		} 
		public  List<Conference> crawlConference()
		{
			List<Conference> items = new List<Conference>();
			for(int i = 1; i <= 3; i++)
			{
				 driver.Navigate().GoToUrl($"https://www.conferenceineurope.org/information_technology.php?page={i}");
				IReadOnlyCollection<IWebElement> productElements = driver.FindElements(By.ClassName("data1"));
				foreach (IWebElement productElement in productElements)
				{
					// Extract the name and price of the product
					string date = productElement.FindElement(By.TagName("span")).Text;
					string name = productElement.FindElement(By.CssSelector("td:nth-child(2) a")).Text;
					string location = productElement.FindElement(By.CssSelector("td:nth-child(3) strong a")).Text;
					var URLtemp = productElement.FindElement(By.CssSelector("td:nth-child(2) a"));
					string URL = URLtemp.GetAttribute("href");
					//IWebDriver driver2 = new ChromeDriver();
					//driver2.Navigate().GoToUrl($"{URL}");
					//var container = driver2.FindElement(By.ClassName("serchsingle-box"));
					//string title = container.FindElement(By.TagName("h1")).Text;
					Conference conference = new Conference();
					// Add the item details to the list
					conference.Date = date;
					conference.Name = name;
					conference.Location = location;
					conference.URLnextPage = URL;
					items.Add(conference);
					//driver2.Quit();
				}
				
			}
			driver.Quit();
			return items;
		}
	}
}

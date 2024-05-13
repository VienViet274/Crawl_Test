// See https://aka.ms/new-console-template for more information
using Crawl_Test;

Console.WriteLine("Hello, World!");
callDriver callDriver = new callDriver();
var nswer = callDriver.crawlConference();
foreach(var con in nswer)
{
	Console.Write($"{con.Name}, {con.Date}, {con.Location}, {con.URLnextPage}");
	Console.WriteLine();
}
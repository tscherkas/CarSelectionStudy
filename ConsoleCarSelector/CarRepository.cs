using Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading;

namespace ConsoleCarSelector
{
    public class CarRepository
    {
        private string root_url;

        public CarRepository(string root_url)
        {
            this.root_url = root_url;
        }

        public IEnumerable<CarListItem> GetCarsByPrice(int priceFrom, int priceTo, string currency)
        {
            var cookieContainer = new CookieContainer();
            var handler = new HttpClientHandler() { CookieContainer = cookieContainer };
            var httpClient = new HttpClient(handler);
            httpClient.DefaultRequestHeaders
  .Accept
  .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            cookieContainer.SetCookies(new Uri("https://ab.onliner.by"), "_ym_uid=1567090664171264365; _ga_185301277=GS1.1.1574328149.1.1.1574328527.0; ouid=snyBDF4Yi5+eJDLlXHU6Ag==; onl_session=SENNMlVUU2packxHVytscW5Cdkc5R0xjMEZrbkczZ1M0U3kvYzdlckJ4bnZYUzhrZURWRngvL3RSY0l2MkhCN214cGI4YTkvR0hEYzkyS3cvNlZJZkw2R0tzYVJ5and6dm13Vjl5VjcyOE1kOExIUmZYZGU5ZTk1OUdTMUkvcU96a2VPSnEwL094cERJTmFwblp1bWJ3PT0=; logged_in=1; refresh_token=cjN3RWhDeDA1OTBiZy85cXV6ZWwrT3dZWm5EcWcvUUpoVGRSMW12eWpvV2hPNGQ5V1lEeTBYU1JHQitIcDFKag==; __io=16ee46e59.6176789e9_1583912711661; oss=eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJ1c2VyX2lkIjo1NDc2MTAsInVzZXJfdHlwZSI6InVzZXIiLCJmaW5nZXJwcmludCI6IjIwMjBhMDE3OTI3NWUyODEzMGI1ZDZlZDEzNjg4ZDZmIiwiZXhwIjoxODk5NzI2MDg5LCJpYXQiOjE1ODQzNjYwODl9.0NdNT7Ry6iWx7IEnF8mTBDvAA6U2ja1J2Z5jVxm-gzwa_u-QtLX5HLKtbiB0S7awdktwGxzFMhzAwfWBTUylfw; fingerprint=6c2b3ee5ea43d4b8dd6782fa99180a4d; tmr_lvid=f26c1af881ac0affe0a9dc0263f7d72a; tmr_lvidTS=1567090663685; __gads=ID=1e930ff2d48ab058:T=1602509555:S=ALNI_MbM3XwaV49VyiaO3tKgiiT2kEacpg; fpestid=EU6H15z8bh2xG66ruCfrh9w3gNsFZzBVLGTKkh1YynQuXn--_awK3h41WgnAyPlIpvwfcw; _gcl_au=1.1.131040571.1612960035; _ym_d=1615534874; _ga_64XDN24MMX=GS1.1.1615823981.1.1.1615824119.0; __io_pr_utm_campaign={\"referrerHostname\":\"l.facebook.com\"}; _gaexp=GAX1.2.HOGNV003QxyXSHU6D6wR_A.18804.0; _ga_SMLMFQCWFM=GS1.1.1616947680.1.0.1616947686.0; _ga_9DJMZ0LZRD=GS1.1.1617266549.26.0.1617266549.0; _ga_5ET8V1N9SR=GS1.1.1617281184.9.1.1617282569.0; _ga_5HNFCB8DR9=GS1.1.1617284660.30.1.1617284734.0; __io_unique_12862=2; tmr_reqNum=2821; _ga_4Y6NQKE48G=GS1.1.1617356267.136.0.1617356267.60; _ga=GA1.2.1840953472.1567090664; _gid=GA1.2.492175910.1617559676; _ym_isad=1; _ga_NG54S9EFTD=GS1.1.1617559674.100.1.1617559852.0; _ga_BT7DBB79XJ=GS1.1.1617559675.23.1.1617559852.0");
            var a = new List<CarListItem>();
            for (int i = 1; i < 100; i++)
            {
                Thread.Sleep(2000);
                var gs = httpClient.GetStringAsync($"https://ab.onliner.by/sdapi/ab.api/search/vehicles?price%5Bfrom%5D=1000&price%5Bto%5D=3000&price%5Bcurrency%5D=usd&order=created_at%3Adesc&page={i}&extended=true&limit=50").GetAwaiter().GetResult();
                var r = JsonSerializer.Deserialize<Models.CarsListResult>(gs);
                if (r.adverts == null || r.adverts.Count == 0)
                    break;
                a.AddRange(r.adverts);
            }
            return a;
        }

        public string GetCarsDescription(string url)
        {
            Thread.Sleep(500);
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders
  .Accept
  .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var gs = httpClient.GetStringAsync(url).GetAwaiter().GetResult();
            var r = JsonSerializer.Deserialize<Models.CarResult>(gs);
            return r.description;
        }
    }
}
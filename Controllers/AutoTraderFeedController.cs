using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using AutotraderFeed.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AutotraderFeed.Controllers
{
    [ApiController]
    [Route("autotrader")]
    public class AutoTraderFeedController : ControllerBase
    {
        private readonly ILogger<AutoTraderFeedController> _logger;
        private static string _baseHost = @"https://www.autotrader.com/rest/searchresults/base";
        private HttpClient _httpClient = new HttpClient();

        public AutoTraderFeedController(ILogger<AutoTraderFeedController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("health")]
        public string HealthCheck()
        {
            return "OK";
        }

        [HttpGet]
        public async Task<Listing[]> Get([FromQuery(Name = "searchQuery")] string searchQuery)
        {
            string result = string.Empty;

            _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko; Google Page Speed Insights) Chrome/27.0.1453 Safari/537.36");

            // string apiUrl = $"{_baseHost}?{searchQuery}";
            string apiUrl = @"https://www.autotrader.com/rest/searchresults/base?makeCodeList=DODGE&searchRadius=0&modelCodeList=MAGNUM&zip=60188&marketExtension=off&trimCodeList=MAGNUM%7CSRT8&isNewSearch=true&sortBy=relevance&numRecords=25&firstRecord=0";
            try 
            {
                // var response = await _httpClient.GetStringAsync(apiUrl);
                // return response;

                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                     result = await response.Content.ReadAsStringAsync();
                     var models = JsonSerializer.Deserialize<Listing[]>(result);
                     return models;
                }
                return null;
            }
            catch(Exception ex)
            {
                return null;
            }
            // HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            // if (response.IsSuccessStatusCode)
            // {
            //      result = await response.Content.ReadAsStringAsync();
            // }
            // return result;
        }

        //https://www.autotrader.com/rest/searchresults/base?makeCodeList=DODGE
        //&searchRadius=0
        //&modelCodeList=MAGNUM
        //&zip=60188
        //&marketExtension=off
        //&trimCodeList=MAGNUM%7CSRT
        //8&isNewSearch=true
        //&sortBy=relevance
        //&numRecords=25
        //&firstRecord=0
    }
}

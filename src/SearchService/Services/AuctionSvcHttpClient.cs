using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Entities;
using SearchService.Models;

namespace SearchService.Services;

public class AuctionSvcHttpClient
{
  private readonly HttpClient _httpClient;
  private readonly IConfiguration _config;
  public AuctionSvcHttpClient(HttpClient httpClient, IConfiguration config)
  {
    _httpClient = httpClient;
    _config = config;
  }

  public async Task<List<Item>> GetItemsForSearchDb()
  {
    var lastUpdated = await DB.Find<Item, string>()
    .Sort(x => x.Descending(y => y.UpdatedAt))
    .Project(x => x.UpdatedAt.ToString())
    .ExecuteFirstAsync();

    var response = await _httpClient.GetAsync(_config["AuctionServiceUrl"] + "/api/auctions?date=" + lastUpdated);

    if (response.IsSuccessStatusCode)
    {
      var items = await response.Content.ReadFromJsonAsync<List<Item>>();

      return items;
    }
    else
    {
      throw new Exception("Error getting items from Auction Service");
    }






  }
}

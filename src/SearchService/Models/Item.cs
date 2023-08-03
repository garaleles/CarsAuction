using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Entities;

namespace SearchService.Models;

public class Item: Entity
{
  public decimal ReservePrice { get; set; }
  public string Seller { get; set; }
  public string Winner { get; set; }
  public decimal SoldAmount { get; set; }
  public decimal CurrentHighBid { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public DateTime AuctionEnd { get; set; }
  public string Status { get; set; }
  public string Make { get; set; }
  public string Model { get; set; }
  public int Year { get; set; }
  public string Color { get; set; }
  public int Km { get; set; }
  public string ImageUrl { get; set; }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using GTANetworkAPI;
using Newtonsoft.Json;


namespace ServerSide.Database.Models;

public class Market : BusinessBase
{
    [NotMapped]
    public List<MarketItem> Items
    {
        get { return JsonConvert.DeserializeObject<List<MarketItem>>(ItemsJson); }
        set { ItemsJson = JsonConvert.SerializeObject(value); }
    }
    public string ItemsJson { get; private set; }

    public Market()
    {
        
    }
    public Market(int gosPrice, List<MarketItem> marketItems, Vector3 positionManagementBusiness) : base(gosPrice,positionManagementBusiness)
    {
        Items = marketItems;
    }
}
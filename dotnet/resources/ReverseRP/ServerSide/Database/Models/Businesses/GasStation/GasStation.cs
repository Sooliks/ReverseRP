using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using GTANetworkAPI;
using Newtonsoft.Json;

namespace ServerSide.Database.Models.GasStation;

public class GasStation : BusinessBase
{
    [NotMapped]
    public List<GasItem> GasItems
    {
        get { return JsonConvert.DeserializeObject<List<GasItem>>(GasItemsJson); }
        set { GasItemsJson = JsonConvert.SerializeObject(value); }
    }
    public string GasItemsJson { get; private set; }
    

    public GasStation()
    {
        
    }

    public GasStation(int gosPrice, List<GasItem> gasItems, Vector3 positionManagementBusiness): base(gosPrice,positionManagementBusiness)
    {
        GasItems = gasItems;
    }
}
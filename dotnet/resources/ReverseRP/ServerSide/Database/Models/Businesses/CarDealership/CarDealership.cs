using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using GTANetworkAPI;
using Newtonsoft.Json;

namespace ServerSide.Database.Models.CarDealership;

public class CarDealership : BusinessBase
{
    [NotMapped]
    public List<CarItem> CarItems
    {
        get { return JsonConvert.DeserializeObject<List<CarItem>>(CarItemsJson); }
        set { CarItemsJson = JsonConvert.SerializeObject(value); }
    }
    public string CarItemsJson { get; private set; }
    
    public CarDealership()
    {
        
    }
    public CarDealership(int gosPrice, List<CarItem> carItems, Vector3 positionManagementBusiness) : base(gosPrice,positionManagementBusiness)
    {
        CarItems = carItems;
    }
}
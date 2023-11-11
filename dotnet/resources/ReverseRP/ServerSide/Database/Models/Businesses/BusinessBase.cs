
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using GTANetworkAPI;
using Newtonsoft.Json;
using ServerSide.Database.Models.Businesses;

namespace ServerSide.Database.Models;

public class BusinessBase
{
    public int Id { get; set; }
    public int OwnerCharacterId { get; set; }
    public int Bank { get; set; }
    public int GosPrice { get; set; }
    [NotMapped]
    public Vector3 PositionManagementBusiness 
    {
        get { return JsonConvert.DeserializeObject<Vector3>(PositionManagementBusinessJson); }
        set { PositionManagementBusinessJson = JsonConvert.SerializeObject(value); }
    }
    public string PositionManagementBusinessJson { get; private set; }
    public List<StatisticBusiness>? StatisticBusinesses { get; set; } = new List<StatisticBusiness>();
    [NotMapped]
    public List<ItemBusiness> Items
    {
        get { return JsonConvert.DeserializeObject<List<ItemBusiness>>(ItemsJson); }
        set { ItemsJson = JsonConvert.SerializeObject(value); }
    }
    public string ItemsJson { get; private set; }
    public string BusinessType { get; set; }
    public List<OrderBusiness>? OrderBusinesses { get; set; }

    public BusinessBase(int gosPrice, Vector3 positionManagementBusiness, List<ItemBusiness> items, string businessType)
    {
        Bank = 1000;
        GosPrice = gosPrice;
        PositionManagementBusiness = positionManagementBusiness;
        OwnerCharacterId = 0;
        Items = items;
        BusinessType = businessType;
    }

    public BusinessBase()
    {
        
    }
}
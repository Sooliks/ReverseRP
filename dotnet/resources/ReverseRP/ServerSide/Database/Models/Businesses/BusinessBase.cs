using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GTANetworkAPI;
using Newtonsoft.Json;

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
    public BusinessBase(int gosPrice, Vector3 positionManagementBusiness)
    {
        Bank = 1000;
        GosPrice = gosPrice;
        PositionManagementBusiness = positionManagementBusiness;
        OwnerCharacterId = 0;
    }

    public BusinessBase()
    {
        
    }
    
}
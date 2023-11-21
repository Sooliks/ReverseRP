using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using NLog.Config;

namespace ServerSide.Database.Models;

public class Vehicle : ModelWithInventory<Vehicle>
{
    public VehicleType VehicleType { get; set; }
    public float FuelTank { get; set; }
    public float Mileage { get; set; }
    public Character? Character { get; set; }
    [NotMapped]
    public GTANetworkAPI.Vehicle VehicleRage 
    {
        get { return JsonConvert.DeserializeObject<GTANetworkAPI.Vehicle>(VehicleRageJson); }
        set { VehicleRageJson = JsonConvert.SerializeObject(value); }
    }
    public string VehicleRageJson { get; private set; } 
    public string RegisterNumber { get; set; }
    public override int MaxCountItems { get; set; } = 20;

    public Vehicle()
    {
        
    }

    public Vehicle(VehicleType vehicleType, float fuelTank, float mileage, GTANetworkAPI.Vehicle vehicleRage)
    {
        VehicleType = vehicleType;
        FuelTank = fuelTank;
        Mileage = mileage;
        VehicleRage = vehicleRage;
        RegisterNumber = vehicleRage.NumberPlate;
    }

    public void MinusFuel()
    {
        using Context db = new Context();
        if ((FuelTank - VehicleType.FuelConsumption) < 0.3f)
        {
            this.FuelTank = 0;
            db.Vehicles.Update(this);
            db.SaveChanges();
            return;
        }
        this.FuelTank -= this.VehicleType.FuelConsumption;
        db.Vehicles.Update(this);
        db.SaveChanges();
    }
    
}
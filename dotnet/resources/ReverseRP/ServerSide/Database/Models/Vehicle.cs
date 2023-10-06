namespace ServerSide.Database.Models;

public class Vehicle
{
    public int Id { get; set; }
    public VehicleType VehicleType { get; set; }
    public float FuelTank { get; set; }
    public float Mileage { get; set; }

    public Vehicle()
    {
        
    }

    public Vehicle(VehicleType vehicleType, float fuelTank, float mileage)
    {
        VehicleType = vehicleType;
        FuelTank = fuelTank;
        Mileage = mileage;
    }
}
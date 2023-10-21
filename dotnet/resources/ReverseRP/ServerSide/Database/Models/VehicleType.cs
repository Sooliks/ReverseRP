using ServerSide.Enums;

namespace ServerSide.Database.Models;

public class VehicleType
{
    public int Id { get; set; }
    public string ModelHash { get; set; }
    public string Mark { get; set; }
    public string Model { get; set; }
    public int FuelTankCapacity { get; set; }
    public string Class { get; set; }
    public int BaggageHoldCapacity { get; set; }
    public float FuelConsumption { get; set; }
    public GasType GasType { get; set; }
    public int CountPassengersCapacity { get; set; }

    public VehicleType()
    {
        
    }

    public VehicleType(string modelHash, string mark, string model,int fuelTankCapacity, string _class, int baggageHoldCapacity, float fuelConsumption, GasType gasType, int countPassengersCapacity)
    {
        ModelHash = modelHash;
        Mark = mark;
        Model = model;
        FuelTankCapacity = fuelTankCapacity;
        Class = _class;
        BaggageHoldCapacity = baggageHoldCapacity;
        FuelConsumption = fuelConsumption;
        GasType = gasType;
        CountPassengersCapacity = countPassengersCapacity;
    }
}
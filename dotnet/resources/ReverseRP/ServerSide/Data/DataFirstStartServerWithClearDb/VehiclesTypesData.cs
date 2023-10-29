using System.Collections.Generic;
using ServerSide.Database.Models;
using ServerSide.Enums;

namespace ServerSide.Data;

public class VehiclesTypesData
{
    public static readonly List<VehicleType> VehiclesDefault = new List<VehicleType>()
    {
        new VehicleType("c63w205", "Mercedes", "C63", 70, "Luxury", 50, 0.5f, GasType.Lux, 4),
        new VehicleType("cookiers6a", "Audi", "RS6 Sport", 60, "Luxury", 50, 0.7f, GasType.Lux, 4)
    };
}
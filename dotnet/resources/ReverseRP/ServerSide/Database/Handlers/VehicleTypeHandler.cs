using System.Collections.Generic;
using System.Linq;
using ServerSide.Database.Models;

namespace ServerSide.Database.Handlers;

public class VehicleTypeHandler
{
    public static List<VehicleType> GetVehicleTypes()
    {
        using Context db = new Context();
        return db.VehicleTypes.ToList();
    }

    public static VehicleType GetVehicleTypeById(int id)
    {
        using Context db = new Context();
        return db.VehicleTypes.FirstOrDefault(v => v.Id == id);
    }
}
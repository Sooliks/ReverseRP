using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.EntityFrameworkCore;
using ServerSide.Database.Models;
using ServerSide.Extensions.VehicleExtensions;

namespace ServerSide.Database.Handlers;

public class VehicleHandler
{
    public static void AddNewVehicle(Character character,VehicleType vehicleType, GTANetworkAPI.Vehicle vehicleRage)
    {
        using Context db = new Context();
        //db.Entry(character).Collection(c=>c.Vehicles).Load();
        character = db.Character.Include(c=>c.Vehicles).FirstOrDefault(c => c.Id == character.Id);
        var vehicleModel = new Vehicle(vehicleType, 30, 0, vehicleRage);
        vehicleRage.SetVehicleModel(vehicleModel);
        character.Vehicles.Add(vehicleModel);
        db.Character.Update(character);
        db.SaveChanges();
    }

    public static Vehicle GetVehicleModelById(int id)
    {
        using Context db = new Context();
        return db.Vehicles.Include(v=>v.Character).Include(v=>v.VehicleType).FirstOrDefault(v => v.Id == id);
    }

    public static void AddFuel(Vehicle vehicle,int count)
    {
        using Context db = new Context();
        if (vehicle.FuelTank + count >= vehicle.VehicleType.FuelTankCapacity)
        {
            vehicle.FuelTank = vehicle.VehicleType.FuelTankCapacity;
            db.Vehicles.Update(vehicle);
            db.SaveChanges();
            return;
        }
        vehicle.FuelTank += count;
        db.Vehicles.Update(vehicle);
        db.SaveChanges();
    }
}
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ServerSide.Database.Models;

namespace ServerSide.Database.Handlers;

public class VehicleHandler
{
    public static void AddNewVehicle(Character character,VehicleType vehicleType)
    {
        using Context db = new Context();
        //db.Entry(character).Collection(c=>c.Vehicles).Load();
        character = db.Character.Include(c=>c.Vehicles).FirstOrDefault(c => c.Id == character.Id);
        character.Vehicles.Add(new Vehicle(vehicleType, 30, 0));
        db.Character.Update(character);
        db.SaveChanges();
    }
}
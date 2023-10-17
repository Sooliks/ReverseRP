namespace ServerSide.Database.Models.CarDealership;

public class CarItem : ItemBusiness
{
    public int VehicleTypeId { get; set; }
    
    public CarItem(int vehicleTypeId, int count, int price)
    {
        VehicleTypeId = vehicleTypeId;
        Count = count;
        Price = price;
    }
}
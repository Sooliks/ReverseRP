using ServerSide.Enums;

namespace ServerSide.Database.Models.GasStation;

public class GasItem : ItemBusiness
{
    public GasType GasType { get; set; }

    public GasItem(GasType gasType, int count, int price)
    {
        GasType = gasType;
        Count = count;
        Price = price;
    }
}
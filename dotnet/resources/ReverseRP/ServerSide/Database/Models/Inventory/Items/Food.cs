using GTANetworkAPI;
using ServerSide.Database.Models;
using ServerSide.Enums;
using ServerSide.Extensions;

namespace ServerSide.Inventory.Items;

public class Food : ItemBase
{
    public byte CountSatiety { get; set; }
    public Food(int count, Item item, byte countSatiety): base(count, item)
    {
        CountSatiety = countSatiety;
    }

    public Food()
    {
        
    }
    public void Use(Player player)
    {
        byte countSatiety = player.GetCharacter().CountSatiety += CountSatiety;
        player.SendNotify(NotifyType.Info, $"Cытость восстановлена на {countSatiety}%");
    }
}
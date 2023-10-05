using GTANetworkAPI;
using ServerSide.Database.Models;
using ServerSide.Enums;
using ServerSide.Extensions;

namespace ServerSide.Inventory.Items;

public class Food : ItemType
{
    public byte CountSatiety { get; set; }
    public Food(string name, string description, int hash, int idItem, byte countSatiety): base(name, description, hash, idItem)
    {
        CountSatiety = countSatiety;
    }

    public Food()
    {
        
    }
    public void Use(Player player)
    {
        player.SendNotify(NotifyType.Info, $"Cытость восстановлена на {player.GetCharacter().CountSatiety+CountSatiety}%");
    }
}
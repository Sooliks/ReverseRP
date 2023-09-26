using System.Collections.Generic;
using GTANetworkAPI;
using ServerSide.Database.Handlers;
using ServerSide.Database.Models;

namespace ServerSide.Extensions;

public static class PlayerExtensionsData
{
    public static void SetAccount(this Player player, Account account) => player.SetData("account",account);
    public static void SetCharacter(this Player player, Character character) => player.SetData("character", character);
    public static Account GetAccount(this Player player)
    {
        if (player.HasData("account"))
        {
            return player.GetData<Account>("account");
        }
        return null;
    }
    public static Character GetCharacter(this Player player)
    {
        if (player.HasData("character"))
        {
            return player.GetData<Character>("character");
        }
        return null;
    }
    public static List<ItemBase> GetInventory(this Player player) => InventoryHandler.GetInventory(player.GetCharacter());
    
}
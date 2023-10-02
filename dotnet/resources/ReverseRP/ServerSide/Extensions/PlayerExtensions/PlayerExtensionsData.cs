using System.Collections.Generic;
using GTANetworkAPI;
using ServerSide.Database.Handlers;
using ServerSide.Database.Models;
using ServerSide.Enums;
using ServerSide.Services.AdminService;

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
            var c = player.GetData<Character>("character");
            return CharacterHandler.GetCharacterById(c.Id);
        }
        return null;
    }
    public static List<ItemBase> GetInventory(this Player player) => InventoryHandler.GetInventory(player.GetCharacter());
    public static bool IsHaveAdminRank(this Player player, AdminLevels adminLevels) => AdminManager.IsPlayerHaveAdminRank(player, adminLevels);
    public static void AddItem(this Player player, ItemBase itemBase) =>
        InventoryHandler.AddItem(player.GetCharacter(), itemBase);
    

}
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GTANetworkAPI;
using Newtonsoft.Json;
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
    public static List<ItemBase> GetInventory(this Player player) => player.GetCharacter().Inventory;
    public static bool IsHaveAdminRank(this Player player, AdminLevels adminLevels) => AdminManager.IsPlayerHaveAdminRank(player, adminLevels);
    public static void UpdateInventoryCef(this Player player)
    {
        var inventory = player.GetInventory().Select(i => new
        {
            count = i.Count, name = i.ItemType.Name, description = i.ItemType.Description, idItem = i.ItemType.IdItem, hash = i.ItemType.Hash, type = i.GetType().Name
        }).ToList();
        player.TriggerCefEvent("SERVER::CEF:UPDATE_INVENTORY_PLAYER",inventory);
    }
    public static async Task<bool> IsAnimPlaying(this Player player,string animDict, string animName, int flag) =>
        (bool) await player.TriggerProcedure("RPC::SERVER::CLIENT:IsPlayerAnimPlaying", animDict, animName, flag);

    public static bool IsAuthorized(this Player player)
    {
        if (player.HasData("authorized"))
        {
            return player.GetData<bool>("authorized");
        }

        return false;
    }
    public static void SetAuthorized(this Player player, bool isAuthorized)
    {
        player.SetData("authorized", isAuthorized);
    }
    public static void SetPlayerIsExitInterior(this Player player, bool toggle)
    {
        player.SetData("exitinterior", toggle);
    }
    public static bool IsExitInterior(this Player player)
    {
        if (player.HasData("exitinterior"))
        {
            return player.GetData<bool>("exitinterior");
        }

        return false;
    }
    public static async Task<string> GetCurrentCefPath(this Player player) =>
        (string) await player.TriggerProcedure("RPC::SERVER::CLIENT:GetCurrentCefPath");
}
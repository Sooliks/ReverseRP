using System;
using System.Collections.Generic;
using System.Linq;
using GTANetworkAPI;
using ServerSide.Database.Handlers;
using ServerSide.Enums;
using ServerSide.Extensions;
using ServerSide.Services;

namespace ServerSide.EventsHandlers.Authorization;

public class EventsUploadCode : Script
{
    [RemoteProc("RPC::CEF::SERVER:CONFIRM_ACCOUNT_EMAIL")]
    public string OnUploadConfirmationCodeAccount(Player player, string verificationCode)
    {
        var account = player.GetAccount();
        if (AccountsHandler.IsConfirmationCodeValid(account, verificationCode, ConfirmationCodeType.ConfirmEmail))
        {
            AccountsHandler.SetConfirmAccount(account);
            player.ChangeCefWindow(CefWindowsPaths.SelectCharacters);
            var list = CharacterHandler.GetCharactersByAccount(account);
            var newList = list.Select(c => new
            {
                Id = c.Id, FirstName = c.FirstName, LastName = c.LastName, Lvl = c.Lvl, Money = c.Money,
                MoneyBank = c.MoneyBank
            }).ToList();
            player.TriggerCefEvent("SERVER::CEF::ADD_CHARACTERS_LIST",newList);
            return "true";
        }
        return "false";
    }
}
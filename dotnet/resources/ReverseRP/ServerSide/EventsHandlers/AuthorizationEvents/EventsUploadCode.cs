using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GTANetworkAPI;
using ServerSide.Database.Handlers;
using ServerSide.Database.Models;
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
        var confirmationCode =
            AccountsHandler.GetConfirmationCode(account, verificationCode, ConfirmationCodeType.ConfirmEmail);
        if (confirmationCode != null)
        {
            if (AccountsHandler.IsConfirmationCodeHasNotExpired(confirmationCode))
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
                GeneralHandler.Remove<ConfirmationCode>(confirmationCode);
                return "success";
            }
            AccountsHandler.AddConfirmationCodeAsync(account, ConfirmationCodeType.ConfirmEmail);
            GeneralHandler.Remove<ConfirmationCode>(confirmationCode);
            return "expired";
        }
        return "notfound";
    }
}
using System;
using System.Collections.Generic;
using GTANetworkAPI;
using ServerSide.Database.Handlers;
using ServerSide.Enums;
using ServerSide.Extensions;
using ServerSide.Services;

namespace ServerSide.EventsHandlers.Authorization;

public class EventsUploadCode : Script
{
    [RemoteProc("RPC::CEF::SERVER:CONFIRM_ACCOUNT_EMAIL")]
    public bool OnUploadConfirmationCodeAccount(Player player, string verificationCode)
    {
        var account = player.GetAccount();
        if (AccountsHandler.IsConfirmationCodeValid(account, verificationCode, ConfirmationCodeType.ConfirmEmail))
        {
            AccountsHandler.SetConfirmAccount(account);
            player.ChangeCefWindow(CefWindowsPaths.SelectCharacters);
            player.TriggerCefEvent("SERVER::CEF::ADD_CHARACTERS_LIST",new List<string>());
            return true;
        }
        return false;
    }
}
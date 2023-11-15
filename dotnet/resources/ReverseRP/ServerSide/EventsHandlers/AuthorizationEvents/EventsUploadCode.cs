using System;
using GTANetworkAPI;
using ServerSide.Database.Handlers;
using ServerSide.Enums;
using ServerSide.Extensions;

namespace ServerSide.EventsHandlers.Authorization;

public class EventsUploadCode : Script
{
    [RemoteProc("RPC::CEF::SERVER:CONFIRM_ACCOUNT_EMAIL")]
    public bool OnUploadConfirmationCode(Player player, string verificationCode)
    {
        if (!player.IsAuthorized()) return false;
        var account = player.GetAccount();
        if (AccountsHandler.IsConfirmationCodeValid(account, verificationCode, ConfirmationCodeType.ConfirmEmail))
        {
            AccountsHandler.SetConfirmAccount(account);
            return true;
        }

        return false;
    }
}
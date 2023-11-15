using System;
using GTANetworkAPI;
using ServerSide.Database.Handlers;
using ServerSide.Enums;
using ServerSide.Extensions;

namespace ServerSide.EventsHandlers.Authorization;

public class EventsUploadCode : Script
{
    [RemoteProc("RPC::CEF::SERVER:UPLOAD_CONFIRMATION_CODE")]
    public bool OnUploadConfirmationCode(Player player, ConfirmationCodeType confirmationCodeType, string verificationCode)
    {
        if (!player.IsAuthorized()) return false;
        var account = player.GetAccount();
        if (AccountsHandler.IsConfirmationCodeValid(account, verificationCode, confirmationCodeType))
        {
            AccountsHandler.SetConfirmAccount(account);
            return true;
        }

        return false;
    }
}
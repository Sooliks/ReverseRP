using System;
using GTANetworkAPI;
using ServerSide.Database.Handlers;
using ServerSide.Extensions;
using ServerSide.Services;

namespace ServerSide.EventsHandlers.Authorization;

public class Login : Script
{
    [RemoteEvent("CEF::SERVER::ON_FINISH_LOGIN")]
    public async void OnFinishLogin(Player player, string login, string password, bool remember)
    {
        var account = AccountsHandler.GetAccountBySocialClubId(Convert.ToInt64(player.SocialClubId));
        if (account != null)
        {
            if (account.IsBanned)
            {
                player.TriggerCefEvent("SERVER::CEF::ERROR_LOGIN","Ваш аккаунт в бане");
                return;
            }
        }
        if (AccountsHandler.IsLoginExist(login) && AccountsHandler.IsPasswordValid(login, password))
        {
            player.ChangeCefWindow(CefWindowsPaths.CreateCharacter);
        }
        else
        {
            player.TriggerCefEvent("SERVER::CEF::ERROR_LOGIN","Неверный логин или пароль");
        }
    }
}
using System;
using GTANetworkAPI;
using ServerSide.Database.Handlers;
using ServerSide.Extensions;
using ServerSide.Services;

namespace ServerSide.EventsHandlers.Authorization;

public class Registration : Script
{
    [RemoteEvent("CEF::SERVER::ON_FINISH_REGISTRATION")]
    public async void OnFinishRegistration(Player player, string login, string email, string password)
    {
        try
        {
            if (AccountsHandler.IsEmailExist(email))
            {
                player.TriggerCefEvent("SERVER::CEF::ERROR_REGISTRATION","Аккаунт с таким email уже существует");
                return;
            }

            if (AccountsHandler.IsLoginExist(login))
            {
                player.TriggerCefEvent("SERVER::CEF::ERROR_REGISTRATION","Аккаунт с таким логином уже существует");
                return;
            }

            var account = AccountsHandler.GetAccountBySocialClubId(Convert.ToInt64(player.SocialClubId));
            if (account != null)
            {
                if (account.IsBanned)
                {
                    player.TriggerCefEvent("SERVER::CEF::ERROR_REGISTRATION","Ваш Social Club Id забанен");
                    return;
                }
            }
            AccountsHandler.Register(login, email, password, player.Address,player.SocialClubId);
            player.ChangeCefWindow(CefWindowsPaths.CreateCharacter);
        }
        catch (Exception e)
        {
            return;
        }
    }
}
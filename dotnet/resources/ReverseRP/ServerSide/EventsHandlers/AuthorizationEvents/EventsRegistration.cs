using System;
using System.Collections.Generic;
using GTANetworkAPI;
using ServerSide.Database.Handlers;
using ServerSide.Discord;
using ServerSide.Enums;
using ServerSide.Extensions;
using ServerSide.Services;

namespace ServerSide.EventsHandlers.Authorization;

public class EventsRegistration : Script
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
            var regAccount = AccountsHandler.Register(login, email, password, player.Address,player.SocialClubId);
            player.SetAccount(regAccount);
            AccountsHandler.AddConfirmationCodeAsync(regAccount, ConfirmationCodeType.ConfirmEmail);
            player.ChangeCefWindow(CefWindowsPaths.ConfirmationCode);
            await Logs.SendGameLogAsync($"Игрок с логином: \"{player.GetAccount().Login}\" и socClubId: \"{player.SocialClubId}\" и IP: \"{player.Address}\" зарегистрировался на сервере!");
        }
        catch (Exception e)
        {
            player.TriggerCefEvent("SERVER::CEF::ERROR_REGISTRATION","Неизвестная ошибка");
            return;
        }
    }
    
}
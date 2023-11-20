using System;
using ServerSide.Database.Models.Interfaces;
using ServerSide.Enums;

namespace ServerSide.Database.Models;

public class ConfirmationCode : IBaseModel
{
    public int Id { get; set; }
    public ConfirmationCodeType ConfirmationCodeType { get; set; }
    public Account? Account { get; set; }
    public string VerificationCode { get; set; }
    public DateTime ExpirationTime { get; set; }
    public ConfirmationCode()
    {
        
    }

    public ConfirmationCode(ConfirmationCodeType confirmationCodeType, string verificationCode)
    {
        ConfirmationCodeType = confirmationCodeType;
        VerificationCode = verificationCode;
        ExpirationTime = DateTime.Now.AddMinutes(1);
    }
}
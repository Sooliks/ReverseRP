using ServerSide.Enums;

namespace ServerSide.Database.Models;

public class ConfirmationCode
{
    public int Id { get; set; }
    public ConfirmationCodeType ConfirmationCodeType { get; set; }
    public Account? Account { get; set; }
    public string VerificationCode { get; set; }
    public bool Active { get; set; }

    public ConfirmationCode()
    {
        
    }

    public ConfirmationCode(ConfirmationCodeType confirmationCodeType, string verificationCode)
    {
        ConfirmationCodeType = confirmationCodeType;
        VerificationCode = verificationCode;
        Active = true;
    }
}
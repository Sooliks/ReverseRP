using System;

namespace ServerSide.Services.OtherServices;

public class AuthService
{
    public static string GenerateVerificationCode(int min = 100000, int max = 999999)
    {
        Random random = new Random();
        return random.Next(min, max).ToString();
    }
}
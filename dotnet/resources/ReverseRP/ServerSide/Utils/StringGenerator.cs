using System;
using System.Text;

namespace Utils;

public class StringGenerator
{
    private const string Characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

    public static string GenerateUpperCaseString(int length)
    {
        Random random = new Random();
        StringBuilder stringBuilder = new StringBuilder();

        for (int i = 0; i < length; i++)
        {
            int index = random.Next(Characters.Length);
            stringBuilder.Append(Characters[index]);
        }

        return stringBuilder.ToString();
    }
}
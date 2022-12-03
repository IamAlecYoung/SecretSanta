using System;
using System.Linq;

namespace SecretSanta.Core.Services;

public static class Password
{
    private static Random random = new Random();
    private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    public static string Generate()
    {
        return new string(Enumerable.Repeat(chars, 5)
            .Select(s => s[random.Next(s.Length)])
            .ToArray());
    }
}
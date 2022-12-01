using System;
using System.Collections.Generic;
using System.Linq;
using Google.Protobuf;

namespace SecretSanta.Core.Domain.Contexts.Seeds;

public class Seeder
{
    public static List<Peeps> Peeps()
    {
        return NamesOutTheHat.Select(s => new Peeps()
        {
            name = s,
            uniquePass = "QWERTY",
            Year = "2022"
        }).ToList();
    }

    public static Domain.Settings Settings()
    {
        return new Domain.settings()
        {
            currentyear = DateTime.Now.ToString("yyyy"),
            admin = "PASSWORD!"
        };
    }

    private static string[] NamesOutTheHat = new[]
    {
        "Jerry", "Lisa", "Patrick", "Joffrey", "Larry"
    };
}
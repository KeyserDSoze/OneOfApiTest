﻿// See https://aka.ms/new-console-template for more information
using ConsoleApp1;
using System.Text.Json;
using System.Text.Json.Serialization;

Console.WriteLine("Hello, World!");

var alof1 = new Alof
{
    Sarlu = new Porlo { Value = "Porlo.Value", Selfish = "Porlo.Selfish" },
    Settings = new Farlo
    {
        Text = "Farlo.Text",
        RandomX = "Farlo.RandomX"
    },
    Felicina = "Felicina",
    Numbers = 3,
    Camerun = true,
    SalutiEBaci = 3,
    Fakam = 4
};
var alof2 = new Alof
{
    Sarlu = new Porlo { Value = "Porlo.Value", Selfish = "Porlo.Selfish" },
    Settings = new Farlo
    {
        Text = "Farlo.Text",
        RandomX = "Farlo.RandomX"
    },
    Felicina = "Felicina",
    Numbers = 3,
    Camerun = true,
    SalutiEBaci = new Porlo { Selfish = "Saluti.Porlo.Selfish", Value = "Saluti.Porlo.Value" },
    Fakam = new Fakam
    {
        Olaf = "Fakam.Olaf",
        Farlo = new Farlo { RandomX = "Fakam.Farlo.RandomX", Text = "Fakam.Farlo.Text" },
        FarloList = [new Farlo { RandomX = "tt", Text = "xx" }],
        Makko = new Dictionary<string, string> { ["key"] = "value", ["key2"] = "value" },
        Molest = ["a", "b", "c"],
        FarloDictionary = new Dictionary<string, Farlo>
        {
            ["key"] = new Farlo { Text = "value", RandomX = "value" },
            ["key2"] = new Farlo { Text = "value2", RandomX = "value2" },
        }
    }
};
var alof3 = new Alof
{
    Sarlu = new Porlo { Value = "Hello", Selfish = "World" },
    Settings = new Farlo
    {
        Text = "Hello",
        RandomX = "World"
    },
    Felicina = "dalkdsa",
    Numbers = 3,
    Camerun = true
};

var json = alof1.ToJson(new JsonSerializerOptions
{
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
});
var json2 = alof2.ToJson();
var json3 = alof3.ToJson();
Console.WriteLine(json);
Console.WriteLine(json2);
var fromJson = json.FromJson<Alof>();
Console.WriteLine(fromJson.Sarlu?.AsT0?.Value);
Console.WriteLine(fromJson.Felicina?.AsT1);
Console.WriteLine(fromJson.Numbers.AsT1);
Console.WriteLine(fromJson.Camerun.AsT1);
Console.WriteLine(fromJson.Sarlu);
Console.WriteLine(fromJson.Settings);
Console.WriteLine(fromJson.Felicina);
Console.WriteLine(fromJson.Numbers);
Console.WriteLine(fromJson.Camerun);
Console.WriteLine(fromJson.SalutiEBaci.Index);
Console.WriteLine(fromJson.SalutiEBaci.Value);
Console.WriteLine();
var fromJson2 = json2.FromJson<Alof>();
Console.WriteLine(fromJson2.SalutiEBaci.Index);
Console.WriteLine(fromJson2.SalutiEBaci.Value);
Console.WriteLine(fromJson2.SalutiEBaci.AsT0.Selfish);
Console.WriteLine(fromJson2.Fakam.AsT3.Olaf);
Console.WriteLine(fromJson2.Fakam.AsT3.Farlo.RandomX);
Console.WriteLine(fromJson2.Fakam.AsT3.FarloDictionary.First().Key);
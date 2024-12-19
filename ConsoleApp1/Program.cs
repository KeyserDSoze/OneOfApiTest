using ConsoleApp1;
using System.Text.Json;
using System.Text.Json.Serialization;

var firstTestClass = new CurrentTestClass
{
    OneClass_String = new FirstClass { FirstProperty = "OneClass_String.FirstProperty", SecondProperty = "OneClass_String.SecondProperty" },
    SecondClass_OneClass = new SecondClass
    {
        FirstProperty = "SecondClass_OneClass.FirstProperty",
        SecondProperty = "SecondClass_OneClass.SecondProperty"
    },
    OneClass_string__2 = "OneClass_string__2.string",
    Bool_Int = 3,
    Decimal_Bool = true,
    OneCLass_SecondClass_Int = 3,
    FirstClass_SecondClass_Int_ThirdClass = 4
};
var secondTestClass = new CurrentTestClass
{
    OneClass_String = new FirstClass { FirstProperty = "OneClass_String.FirstProperty", SecondProperty = "OneClass_String.SecondProperty" },
    SecondClass_OneClass = new SecondClass
    {
        FirstProperty = "SecondClass_OneClass.FirstProperty",
        SecondProperty = "SecondClass_OneClass.SecondProperty"
    },
    OneClass_string__2 = "OneClass_string__2.string",
    Bool_Int = 3,
    Decimal_Bool = true,
    Test = 4,
    OneCLass_SecondClass_Int = new FirstClass { SecondProperty = "OneCLass_SecondClass_Int.FirstClass.SecondProperty", FirstProperty = "OneCLass_SecondClass_Int.FirstClass.FirstProperty" },
    FirstClass_SecondClass_Int_ThirdClass = new ThirdClass
    {
        Stringable = "ThirdClass.Stringable",
        SecondClass = new SecondClass { SecondProperty = "FirstClass_SecondClass_Int_ThirdClass.SecondClass.SecondProperty", FirstProperty = "FirstClass_SecondClass_Int_ThirdClass.SecondClass.FirstProperty" },
        ListOfSecondClasses = [new SecondClass { SecondProperty = "ListOfSecondClasses.SecondClass.SecondProperty[0]", FirstProperty = "ListOfSecondClasses.SecondClass.FirstProperty[0]" }],
        DictionaryItems = new Dictionary<string, string> { ["key"] = "FirstClass_SecondClass_Int_ThirdClass.DictionaryItems.key", ["key2"] = "FirstClass_SecondClass_Int_ThirdClass.DictionaryItems.key2" },
        ArrayOfStrings = ["FirstClass_SecondClass_Int_ThirdClass.ArrayOfStrings[0]", "FirstClass_SecondClass_Int_ThirdClass.ArrayOfStrings[1]", "FirstClass_SecondClass_Int_ThirdClass.ArrayOfStrings[2]"],
        ObjectDictionary = new Dictionary<string, SecondClass>
        {
            ["key"] = new SecondClass { FirstProperty = "FirstClass_SecondClass_Int_ThirdClass.ObjectDictionary.FirstProperty.key", SecondProperty = "FirstClass_SecondClass_Int_ThirdClass.ObjectDictionary.SecondProperty.key" },
            ["key2"] = new SecondClass { FirstProperty = "FirstClass_SecondClass_Int_ThirdClass.ObjectDictionary.FirstProperty.key2", SecondProperty = "FirstClass_SecondClass_Int_ThirdClass.ObjectDictionary.SecondProperty.key2" },
        }
    }
};
var thirdTestClass = new CurrentTestClass
{
    OneClass_String = new FirstClass { FirstProperty = "OneClass_String.FirstProperty", SecondProperty = "OneClass_String.SecondProperty" },
    SecondClass_OneClass = new SecondClass
    {
        FirstProperty = "SecondClass_OneClass.FirstProperty",
        SecondProperty = "SecondClass_OneClass.SecondProperty"
    },
    OneClass_string__2 = "OneClass_string__2.string",
    Bool_Int = 3,
    Decimal_Bool = true,
    Test = 4,
    OneCLass_SecondClass_Int = new FirstClass { SecondProperty = "OneCLass_SecondClass_Int.FirstClass.SecondProperty", FirstProperty = "OneCLass_SecondClass_Int.FirstClass.FirstProperty" },
    FirstClass_SecondClass_Int_ThirdClass = new ThirdClass
    {
        Stringable = "ThirdClass.Stringable",
        SecondClass = new SecondClass { SecondProperty = "FirstClass_SecondClass_Int_ThirdClass.SecondClass.SecondProperty", FirstProperty = "FirstClass_SecondClass_Int_ThirdClass.SecondClass.FirstProperty" },
        ListOfSecondClasses = [new SecondClass { SecondProperty = "ListOfSecondClasses.SecondClass.SecondProperty[0]", FirstProperty = "ListOfSecondClasses.SecondClass.FirstProperty[0]" }],
        DictionaryItems = new Dictionary<string, string> { ["key"] = "FirstClass_SecondClass_Int_ThirdClass.DictionaryItems.key", ["key2"] = "FirstClass_SecondClass_Int_ThirdClass.DictionaryItems.key2" },
        ArrayOfStrings = ["FirstClass_SecondClass_Int_ThirdClass.ArrayOfStrings[0]", "FirstClass_SecondClass_Int_ThirdClass.ArrayOfStrings[1]", "FirstClass_SecondClass_Int_ThirdClass.ArrayOfStrings[2]"],
        ObjectDictionary = new Dictionary<string, SecondClass>
        {
            ["key"] = new SecondClass { FirstProperty = "FirstClass_SecondClass_Int_ThirdClass.ObjectDictionary.FirstProperty.key", SecondProperty = "FirstClass_SecondClass_Int_ThirdClass.ObjectDictionary.SecondProperty.key" },
            ["key2"] = new SecondClass { FirstProperty = "FirstClass_SecondClass_Int_ThirdClass.ObjectDictionary.FirstProperty.key2", SecondProperty = "FirstClass_SecondClass_Int_ThirdClass.ObjectDictionary.SecondProperty.key2" },
        }
    }
};
thirdTestClass.FirstClass_SecondClass_Int_ThirdClass = new SecondClass { SecondProperty = "Rewritten.FirstClass_SecondClass_Int_ThirdClass.SecondProperty", FirstProperty = "Rewritten.FirstClass_SecondClass_Int_ThirdClass.FirstProperty" };

var json = firstTestClass.ToJson(new JsonSerializerOptions
{
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
});
var json2 = secondTestClass.ToJson();
var json3 = thirdTestClass.ToJson();
Console.WriteLine(json);
Console.WriteLine();
var fromJson = json.FromJson<CurrentTestClass>();
Console.WriteLine(fromJson.OneClass_String?.AsT0?.FirstProperty);
Console.WriteLine(fromJson.OneClass_string__2?.AsT1);
Console.WriteLine(fromJson.Bool_Int!.AsT1);
Console.WriteLine(fromJson.Decimal_Bool!.AsT1);
Console.WriteLine(fromJson.OneClass_String);
Console.WriteLine(fromJson.SecondClass_OneClass);
Console.WriteLine(fromJson.OneClass_string__2);
Console.WriteLine(fromJson.Bool_Int);
Console.WriteLine(fromJson.Decimal_Bool);
Console.WriteLine(fromJson.OneCLass_SecondClass_Int.Index);
Console.WriteLine(fromJson.OneCLass_SecondClass_Int.Value);
Console.WriteLine();
Console.WriteLine(json2);
Console.WriteLine();
var fromJson2 = json2.FromJson<CurrentTestClass>();
Console.WriteLine(fromJson2.OneCLass_SecondClass_Int.Index);
Console.WriteLine(fromJson2.OneCLass_SecondClass_Int.Value);
Console.WriteLine(fromJson2.OneCLass_SecondClass_Int.AsT0!.SecondProperty);
Console.WriteLine(fromJson2.FirstClass_SecondClass_Int_ThirdClass.AsT3!.Stringable);
Console.WriteLine(fromJson2.FirstClass_SecondClass_Int_ThirdClass.AsT3.SecondClass.SecondProperty);
Console.WriteLine(fromJson2.FirstClass_SecondClass_Int_ThirdClass.AsT3.ObjectDictionary.First().Key);
Console.WriteLine();
Console.WriteLine(json3);
Console.WriteLine();
var fromJson3 = json3.FromJson<CurrentTestClass>();
Console.WriteLine(fromJson3.FirstClass_SecondClass_Int_ThirdClass.AsT1!.SecondProperty);
Console.WriteLine(fromJson3.FirstClass_SecondClass_Int_ThirdClass.Get<SecondClass>()!.SecondProperty);
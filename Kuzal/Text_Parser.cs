using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

public class Parser
{
	public static string ReadAll(string target)
    {
        string rawInput = File.ReadAllText(target);
        return rawInput;
    }

	public static List<String> ReadList(string target)
    {
		var rawFile = File.ReadAllLines(target);
		return new List<string>(rawFile);
    }

	public static JObject Input(string target)
	{
		string inputText = ReadAll(target);
		return JObject.Parse(inputText);
	}
}

using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

public class Page
{
	public static void Builder(JObject input)
	{
		List<String> html = Parser.ReadList($"..\\templates\\{input["template"]}.html");
		List<String> css = Parser.ReadList($"..\\templates\\{input["template"]}.css");

		foreach (var i in html) {
			string line = i;
			int index = html.IndexOf(i);
			if (line.Contains("kuzal"))
            {
				int sIndex = line.IndexOf("mod=\"") + "mod=\"".Length;
				int eIndex = line.IndexOf("\">") - sIndex;

				string id = string.Concat(line.Substring(sIndex, eIndex));

				var moduleData = ModuleGetter(id);
				List<string> contentData = moduleData.Item1;
				List<string> styleData = moduleData.Item2;

				string ContentInjection = "<div>";
				foreach (var f in contentData) { ContentInjection += $"\t {f}"; }
				ContentInjection += "\t <div>";

				//html[index] = ContentInjection;
			}
        }
	}

	private static (List<string>, List<string>) ModuleGetter(string template)
	{
		List<string> fullTemplate = Parser.ReadList($"../modules/{template}.kzl");
		List<string> contentContent = new List<string>();
		List<string> styleContent = new List<string>();

		int sBodyIndex = fullTemplate.IndexOf("<content>") + 1;
		int eBodyIndex = fullTemplate.IndexOf("</content>");
		int sStyleIndex = fullTemplate.IndexOf("<style>") + 1;
		int eStyleIndex = fullTemplate.IndexOf("</style>");

		for (int m = sBodyIndex; m < eBodyIndex; m++)
        {
			contentContent.Add(fullTemplate[m]);
        }

		for (int c = sStyleIndex; c < eStyleIndex; c++)
        {
			styleContent.Add(fullTemplate[c]);
        }

		return (contentContent, styleContent);

	}
}

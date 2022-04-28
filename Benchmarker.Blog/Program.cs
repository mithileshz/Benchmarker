using System.Text;
using System.Text.RegularExpressions;

var benchmarksNamespace = "Benchmarks.Benchmarks";

IEnumerable<Type> benchmarks = typeof(Benchmarks.Benchmarks.InitialisingEmptyArray).Assembly.GetTypes().Where(t => t.Namespace != null && t.Namespace.Equals(benchmarksNamespace));

foreach(var t in benchmarks)
{
    //Console.WriteLine(t.FullName);

    //var titleAttr = t.GetCustomAttributes(typeof(Benchmarker.Core.TitleAttribute), true);

    //if (titleAttr.Any())
    //{
    //    Console.WriteLine(((Benchmarker.Core.TitleAttribute)titleAttr.First()).Text);
    //}

    //var introductionAttr = t.GetCustomAttributes(typeof(Benchmarker.Core.IntroductionAttribute), true);

    //if (introductionAttr.Any())
    //{
    //    Console.WriteLine(((Benchmarker.Core.IntroductionAttribute)introductionAttr.First()).Text);
    //}

    //var summaryAttr = t.GetCustomAttributes(typeof(Benchmarker.Core.SummaryAttribute), true);

    //if (summaryAttr.Any())
    //{
    //    Console.WriteLine(((Benchmarker.Core.SummaryAttribute)summaryAttr.First()).Text);
    //}

    var fileLocation = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @$"..\..\..\..\Benchmarker-net6\Benchmarks\{t.Name}.cs"));

    if (!File.Exists(fileLocation))
        continue;

    string fileInfo = System.IO.File.ReadAllText(fileLocation);

    string startOfClass = $"public class {t.Name}";

    var indexOfStartingOfClass = fileInfo.IndexOf(startOfClass);

    var indentLevel = GetIndentationLevel(fileInfo);

    StringBuilder sb = new StringBuilder();

    sb.Append(fileInfo.Trim().Skip(indexOfStartingOfClass).ToArray());

    sb.Remove(sb.Length - 1, 1);

    var ret = sb.ToString().Trim().Split(Environment.NewLine);

    for(int i = 1; i < ret.Length; i++)
    {
        if (ret[i].Length == 0) continue;

        ret[i] = ret[i].Remove(0, indentLevel);
    }

    Console.WriteLine(String.Join(Environment.NewLine, ret));
}

int GetIndentationLevel(string fileInfo)
{
    string pattern = @"[ +]*public class";

    return Regex.Match(fileInfo, pattern).Value.Replace("public class", "").Length;
}

Console.Read();
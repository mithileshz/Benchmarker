var benchmarksNamespace = "Benchmarks.Benchmarks";

IEnumerable<Type> benchmarks = typeof(Benchmarks.Benchmarks.InitialisingEmptyArray).Assembly.GetTypes().Where(t => t.Namespace != null && t.Namespace.Equals(benchmarksNamespace));

foreach(var t in benchmarks)
{
    Console.WriteLine(t.FullName);

    var titleAttr = t.GetCustomAttributes(typeof(Benchmarker.Core.TitleAttribute), true);

    if (titleAttr.Any())
    {
        Console.WriteLine(((Benchmarker.Core.TitleAttribute)titleAttr.First()).Text);
    }

    var introductionAttr = t.GetCustomAttributes(typeof(Benchmarker.Core.IntroductionAttribute), true);

    if (introductionAttr.Any())
    {
        Console.WriteLine(((Benchmarker.Core.IntroductionAttribute)introductionAttr.First()).Text);
    }

    var summaryAttr = t.GetCustomAttributes(typeof(Benchmarker.Core.SummaryAttribute), true);

    if (summaryAttr.Any())
    {
        Console.WriteLine(((Benchmarker.Core.SummaryAttribute)summaryAttr.First()).Text);
    }
}
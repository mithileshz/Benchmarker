using System;

namespace Benchmarker.Core
{
    public sealed class TitleAttribute : TextAttribute
    {
        public TitleAttribute(string text) : base(text) { }
    }

    public sealed class IntroductionAttribute : TextAttribute
    {
        public IntroductionAttribute(string text) : base(text) { }
    }

    public sealed class SummaryAttribute : TextAttribute
    {
        public SummaryAttribute(string text) : base(text) { }
    }

    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class TextAttribute : Attribute
    {
        public string Text { get; set; }

        public TextAttribute(string text)
        {
            this.Text = text;
        }
    }
}

namespace HappyCalc.Domain.Math
{
    public class SolutionStep
    {
        public SolutionStep(string expression, string text, string image = "")
        {
            Expression = expression;
            Text = text;
            Image = image;
        }

        public string Expression { get; set; } = string.Empty;

        public string Text { get; set; } = string.Empty;

        public string Image { get; set; } = string.Empty;
    }
}

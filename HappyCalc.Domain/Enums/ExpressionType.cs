using System.ComponentModel;

namespace HappyCalc.Domain.Enums
{
    public enum ExpressionType
    {
        [Description("Nieznany")]
        Unknown = 0,
        [Description("Równanie")]
        Equation = 1,       
    }
}

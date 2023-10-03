using System.ComponentModel;

namespace HappyCalc.Domain.Enums
{
    public enum ProblemType
    {
        [Description("Nieznany")]
        Unknown = 0,

        [Description("Układ równań")]
        SystemOfEquations = 1
    }
}

using HappyCalc.Domain.Enums;
using HappyCalc.Common.Extensions;

namespace HappyCalc.Domain.Math
{
    public class Problem
    {
        #region Properties

        public List<Expression> Expressions { get; set; } = new();

        public List<Parameter> Parameters { get; set; } = new();

        public ProblemType ProblemType { get; set; } = ProblemType.Unknown;
        
        public int SelectedSolvingMethod { get; set; } = 0;

        public Type? SelectedSolvingMethodType = null;

        public string ProblemTypeDescription
        {
            get
            {
                return ProblemType.GetEnumDescription();
            }
        }

        #endregion Properties

        #region Methods

        public void AddExpression(Expression expression)
        {
            Expressions.Add(expression);
            DetermineProblemType();
        }

        private void DetermineProblemType()
        {
            if (Expressions.Count == 0)
            {
                return;
            }

            if (DetermineSystemOfEquationsType())
            {
                ProblemType = ProblemType.SystemOfEquations;
                SelectedSolvingMethodType = typeof(SystemOfEquationsSolvingMethod);
                SelectedSolvingMethod = (int)SystemOfEquationsSolvingMethod.Substitution;
                return;
            }            
        }

        private bool DetermineSystemOfEquationsType()
        {
            if (Expressions.Count < 2)
            {
                return false;
            }

            foreach (Expression expression in Expressions)
            {
                List<Parameter> otherVariables = Expressions
                    .Where(x => x != expression)
                    .Select(x => x.Variables)
                    .SelectMany(x => x)
                    .Distinct()
                    .ToList();

                if (expression.Type != ExpressionType.Equation)
                {
                    return false;
                }

                bool found = false;

                foreach(Parameter variable in expression.Variables)
                {
                    if (otherVariables.Contains(variable))
                    {
                        found = true;
                        break;
                    }                    
                }

                if (!found)
                {
                    return false;
                }
            }

            return true;
        }

        #endregion Methods
    }
}

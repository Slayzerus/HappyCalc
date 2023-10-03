using HappyCalc.Domain.Enums;
using HappyCalc.Domain.Math;

namespace HappyCalc.Application.Services
{
    public class SolverService
    {
        public Solution Solve(Problem problem)
        {
            Solution solution = new Solution();

            if (problem.ProblemType == ProblemType.SystemOfEquations && problem.SelectedSolvingMethodType == typeof(SystemOfEquationsSolvingMethod))
            {
                SolveSystemOfEquations(problem);
            }
            else
            {
                foreach(Expression expression in problem.Expressions)
                {
                    solution.Steps.Add(new SolutionStep(expression.Text, $"Nie jestem w stanie rozwiązać tego wyrażenia: {expression.Text}"));
                }                
            }

            return solution;
        }

        private void SolveSystemOfEquations(Problem problem)
        {
            var solvingMethod = (SystemOfEquationsSolvingMethod)problem.SelectedSolvingMethod;
            if (solvingMethod == SystemOfEquationsSolvingMethod.Substitution)
            {

            }
            else if(solvingMethod == SystemOfEquationsSolvingMethod.Determinants)
            {

            }
            else if(solvingMethod == SystemOfEquationsSolvingMethod.GaussianElimination)
            {

            }
        }
    }
}

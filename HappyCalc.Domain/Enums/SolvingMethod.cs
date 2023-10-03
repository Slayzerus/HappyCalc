using System;
using System.ComponentModel;

namespace HappyCalc.Domain.Enums
{
    public enum SystemOfEquationsSolvingMethod
    {
        None,
        [Description("Podstawianie")]
        Substitution = 1,
        [Description("Metoda wyznaczników")]
        Determinants = 2,
        [Description("Eliminacja Gaussa")]
        GaussianElimination = 3,
        [Description("Eliminacja Gaussa-Jordana")]
        GaussJordanElimination = 4,
        [Description("Metoda Cramera")]
        CramersRule = 5,
        /*
        [Description("Metoda macierzy odwrotnej")]
        InverseMatrix = 6,
        [Description("Metoda macierzy rozszerzonej")]
        AugmentedMatrix = 7,
        [Description("Metoda macierzy odwrotnej i rozszerzonej")]
        InverseAndAugmentedMatrix = 8,
        [Description("Metoda macierzy odwrotnej i wyznaczników")]
        InverseAndDeterminants = 9,
        [Description("Metoda macierzy rozszerzonej i wyznaczników")]
        AugmentedMatrixAndDeterminants = 10,
        [Description("Metoda macierzy odwrotnej, rozszerzonej i wyznaczników")]
        InverseAndAugmentedMatrixAndDeterminants = 11,
        [Description("Metoda macierzy odwrotnej i Cramera")]
        InverseAndCramersRule = 12,
        [Description("Metoda macierzy rozszerzonej i Cramera")]
AugmentedMatrixAndCramersRule = 13,
        [Description("Metoda macierzy odwrotnej, rozszerzonej i Cramera")]
        InverseAndAugmentedMatrixAndCramersRule = 14,

        SystemOfEquations,
        QuadraticEquation,
        LinearEquation,
        ExponentialEquation,
        LogarithmicEquation,
        TrigonometricEquation,
        Inequality,
        SystemOfInequalities,
        Derivative,
        Integral,
        Limit,
        Series,
        Matrix,
        Vector,
        ComplexNumber,
        Probability,
        Statistics,
        Geometry,
        Physics,
        Chemistry,
        Finance,
        Other*/
    }
}

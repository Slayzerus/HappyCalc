using HappyCalc.Common.Extensions;
using HappyCalc.Domain.Enums;

namespace HappyCalc.Domain.Math
{
    public class Expression
    {
        public Expression(string text)
        {
            Text = text;
            Parse();
        }

        #region Properties

        public ExpressionType Type { get; set; }

        public string TypeDescription
        {
            get
            {
                return Type.GetEnumDescription();
            }
        }

        public string Text { get; set; }

        public List<Expression> Arguments { get; set; } = new();

        public Parameter? Parameter { get; set; }

        public char Operator { get; set; }

        public List<Expression> AllArguments
        {
            get
            {
                List<Expression> result = new();

                if (Arguments.Count == 0)
                {
                    result.Add(this);
                    return result;
                }

                foreach (Expression argument in Arguments)
                {
                    result.AddRange(argument.AllArguments);
                }


                return result;
            }
        }

        public List<Parameter> Variables
        {
            get
            {
                List<Parameter> result = new();
                
                if (Parameter != null)
                {
                    result.Add(Parameter);
                }

                foreach (Expression argument in Arguments)
                {
                    result.AddRange(argument.Variables);
                }

                return result.Where(x => x.IsVariable).GroupBy(x => x.Name).Select(x => x.First()).ToList();
            }
        }

        #endregion Properties

        #region Methods (public)

        public object? Calculate(List<Parameter> variableValues)
        {
            if (Arguments.Count == 0)
            {
                if (Parameter != null)
                {
                    if (Parameter.IsVariable)
                    {
                        Parameter? variableValue = variableValues.FirstOrDefault(x => x.Name == Parameter.Name);
                        return variableValue?.Value;
                    }
                    else
                    {
                        return Parameter.Value;
                    }
                }
            }
            else
            {
                decimal? total = null;                

                foreach (Expression argument in Arguments)
                {
                    object? result = argument.Calculate(variableValues);
                    if (result != null)
                    {
                        if (!total.HasValue)
                        {
                            total = (decimal)result;
                        }
                        else
                        {
                            if (Operator == '+')
                            {
                                total = total + (decimal)result;
                            }
                            else if (Operator == '-')
                            {
                                total = total - (decimal)result;
                            }
                            else if (Operator == '*')
                            {
                                total = total * (decimal)result;
                            }
                            else if (Operator == '/')
                            {
                                total = total / (decimal)result;
                            }
                        }                        
                    }                    
                }

                return total;
            }
            return null;
        }

        public override string ToString()
        {
            string result = "";

            if (Arguments.Count > 0)
            {
                foreach (Expression argument in Arguments)
                {
                    result += argument.ToString();
                }
            }
            else
            {
                result += Parameter;
            }

            return result;
        }

        #endregion Methods (public)

        #region Methods (private)

        private void Parse()
        {
            Arguments = new List<Expression>();
            Parameter = null;

            var text = Text.Trim();
            if (text.Length == 0)
            {
                return;
            }

            int operatorIndex = GetOperatorIndex(text);

            if (operatorIndex == -1)
            {
                if (text[0] == '(' && text[^1] == ')')
                {
                    Text = text[1..^1];
                    Parse();
                }
                else
                {
                    ParseParameter(text);
                }
            }
            else
            {
                Operator = text[operatorIndex];
                ExtractArguments(text, operatorIndex);
            }

            GetExpressionType();
        }

        private void ParseParameter(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                if (Char.IsNumber(c) || c == '.' || c == ',')
                {
                    continue;
                }
                else
                {
                    if (i > 0)
                    {
                        Arguments.Add(new Expression(text[..i]));
                        Arguments.Add(new Expression(text[i..]));
                        Operator = '*';
                        return;
                    }
                    else
                    {
                        Parameter = new Parameter(text, typeof(string));
                        return;
                    }
                }
            }

            Parameter = new Parameter(text, typeof(decimal), Convert.ToDecimal(text));
        }

        private void GetExpressionType()
        {
            if (Operator == '=')
            {
                Type = ExpressionType.Equation;
            }
        }

        private int Evaluate(int left, int right, char op)
        {
            return op switch
            {
                '+' => left + right,
                '-' => left - right,
                '*' => left * right,
                '/' => left / right,
                _ => throw new System.Exception("Invalid operator"),
            };
        }

        private int GetOperatorIndex(string text)
        {
            int bracketOpen = 0;
            int bracketClose = 0;
            int operatorIndex = -1;

            char[] order = new char[] { '=', '*', '/', '+', '-' };

            foreach(char op in order)
            {
                for (int i = 0; i < text.Length; i++)
                {
                    var c = text[i];
                    if (c == '(')
                    {
                        bracketOpen++;
                    }
                    else if (c == ')')
                    {
                        bracketClose++;
                    }
                    else if (bracketOpen == bracketClose)
                    {
                        if (c == op)
                        {
                            return i;                            
                        }
                    }
                }
            }            

            return operatorIndex;
        }

        private void ExtractArguments(string text, int operatorIndex)
        {
            string left = text[..operatorIndex];
            string right = text[(operatorIndex + 1)..];

            if (left[0] == '(' && left[^1] == ')')
            {
                left = left[1..^1];
            }

            if (right[0] == '(' && right[^1] == ')')
            {
                right = right[1..^1];
            }

            Arguments.Add(new Expression(left));
            Arguments.Add(new Expression(right));
        }

        #endregion Methods (private)
    }
}

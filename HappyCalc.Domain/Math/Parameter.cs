namespace HappyCalc.Domain.Math
{
    public class Parameter : IComparable
    {
        public Parameter(string name, Type valueType, object? value = null)
        {
            Name = name;
            ValueType = valueType;
            Value = value;
        }

        public string Name { get; set; } = string.Empty;

        public Type ValueType { get; set; } = typeof(int);

        public object? Value { get; set; } = null;

        public bool IsVariable
        {
            get
            {
                return ValueType == typeof(string);
            }
        }

        public int CompareTo(object? obj)
        {
            if (obj == null || !(obj is Parameter))
            {
                throw new ArgumentException("Object is not a Parameter");
            }

            return Name.CompareTo(((Parameter)obj).Name);            
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is Parameter))
            {
                return false;
            }

            return ((Parameter)obj).Name == Name;
        }

        public override string ToString()
        {
            if (Value != null)
            {
                return $"{Name}={Value}";
            }
            else
            {
                return Name;
            }
        }
    }
}

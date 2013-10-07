using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Custom
{
    public abstract class Enum
    {
        private static readonly Dictionary<string, Dictionary<string, Enum>> _cache;

        static Enum()
        {
            _cache = new Dictionary<string, Dictionary<string, Enum>>();
        }

        public static bool TryParse<TEnum>(string value, out TEnum result)
            where TEnum : Enum, new()
        {
            var enumType = typeof(TEnum);

            var enumName = enumType.Namespace + '.' + enumType.Name;

            Dictionary<string, Enum> enumMembers;

            if (!_cache.TryGetValue(enumName, out enumMembers))
            {
                var staticFields = enumType.GetFields(BindingFlags.Public | BindingFlags.Static);

                enumMembers = new Dictionary<string, Enum>();

                foreach (var field in staticFields)
                {
                    var fieldName = field.Name;
                    var fieldValue = field.GetValue(null);

                    Debug.Assert(enumType.Equals(fieldValue.GetType()));

                    var enumValue = (TEnum)fieldValue;

                    Debug.Assert(enumValue._name == fieldName);

                    enumMembers.Add(fieldName.ToLower(), enumValue);
                }

                _cache.Add(enumName, enumMembers);
            }

            Enum match;
            
            if (enumMembers.TryGetValue(value.ToLower(), out match))
            {
                result = match as TEnum;
                return true;
            }

            result = null;
            return false;
        }

        private string _name;

        protected Enum(string name)
        {
            _name = name;
        }

        public string Name
        {
            get { return _name; }
        }

        public override string ToString()
        {
            return _name ?? base.ToString();
        }
    }

    public abstract class Enum<TEnum> : Enum, IEnumerable<TEnum>
        where TEnum : Enum<TEnum>
    {
        protected static TEnum[] GetMembers()
        {
            var enumType = typeof(TEnum);
            var enumMembers = new List<TEnum>();
            var staticFields = enumType.GetFields(BindingFlags.Public | BindingFlags.Static);

            foreach (var field in staticFields)
            {
                var fieldName = field.Name;
                var fieldValue = field.GetValue(null);

                Debug.Assert(enumType.Equals(fieldValue.GetType()));

                var enumValue = (TEnum)fieldValue;

                Debug.Assert(enumValue.Name == fieldName);

                enumMembers.Add(enumValue);
            }

            return enumMembers.ToArray();
        }

        protected Enum(string name)
            : base(name)
        {
        }

        protected abstract TEnum[] Members
        {
            get;
        }

        public IEnumerator<TEnum> GetEnumerator()
        {
            return Array.AsReadOnly(Members ?? new TEnum[0]).GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return Array.AsReadOnly(Members ?? new TEnum[0]).GetEnumerator();
        }
    }

    public abstract class Enum<TEnum, TValue> : Enum<TEnum>
        where TEnum : Enum<TEnum>
    {
        protected Enum(string name)
            : base(name)
        {
        }
    }
}

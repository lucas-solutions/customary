using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Custom.Data.Metadata
{
    [Service]
    public static class Factory
    {
        public static ModelDefinition DescribeObject<TObject>()
            where TObject : class
        {
            return DescribeObject(typeof(TObject));
        }

        public static ModelDefinition DescribeObject(System.Type type)
        {
            var attribute = type.GetCustomAttribute<ModelAttribute>(false);

            if (attribute == null)
                return DescribeComplex(type, null);
            
            if (attribute is ModelAttribute)
                return DescribeEntity(type, attribute as ModelAttribute);
            
            return DescribeComplex(type, attribute as ModelAttribute);
        }

        public static ModelDefinition DescribeEntity<TEntity>()
            where TEntity : class
        {
            return DescribeEntity(typeof(TEntity));
        }

        public static ModelDefinition DescribeEntity(System.Type type)
        {
            var attribute = type.GetCustomAttribute<ModelAttribute>(false);

            return DescribeEntity(type, attribute);
        }

        public static ModelDefinition DescribeComplex<TComplex>()
            where TComplex : class
        {
            return DescribeComplex(typeof(TComplex));
        }

        public static ModelDefinition DescribeComplex(System.Type type)
        {
            var attribute = type.GetCustomAttribute<ModelAttribute>(false);

            return DescribeComplex(type, attribute);
        }

        public static ModelDefinition DescribeComplex(System.Type type, ModelAttribute attribute)
        {
            var descriptor = new ModelDefinition();
            
            DescribeObject(descriptor, type);

            if (type.IsGenericTypeDefinition)
            {
                var genericArguments = type.GetGenericArguments();
                var complexArguments = new List<string>();

                for(int i = 0, count = genericArguments.Length; i < count; i++)
                {
                    var arg = genericArguments[i];

                    if (!arg.IsAssignableFrom(typeof(Custom.Enum)))
                        throw new InvalidOperationException("Arguent must implement Enum");

                    if (arg.IsGenericTypeDefinition && !arg.IsAbstract)
                        throw new InvalidOperationException("Arguments but be concrete definition or abstract (in case of generic)");

                    complexArguments.Add(arg.Namespace + '.' + arg.Name);
                }

                //descriptor.Arguments = complexArguments;
            }

            if (attribute != null)
                DescribeObject(descriptor, attribute);

            DescribeObject(descriptor, type.GetProperties(BindingFlags.Public | BindingFlags.Instance));

            return descriptor;
        }

        private static ModelDefinition DescribeEntity(System.Type type, ModelAttribute attribute)
        {
            if (type.IsGenericTypeDefinition)
                throw new InvalidOperationException("An entity should not be generic definition");

            var descriptor = new ModelDefinition();

            DescribeObject(descriptor, type);

            if (attribute != null)
            {
                DescribeObject(descriptor, attribute);
            }

            DescribeObject(descriptor, type.GetProperties(BindingFlags.Public | BindingFlags.Instance));

            return descriptor;
        }

        private static void DescribeObject(ModelDefinition descriptor, System.Type type)
        {
            DescribeType(descriptor, type);
        }

        private static void DescribeObject(ModelDefinition descriptor, ModelAttribute attribute)
        {
            DescribeType(descriptor, attribute);
        }

        private static void DescribeType(TypeDefinition descriptor, System.Type type)
        {
            var name = type.Namespace + '.' + type.Name;

            descriptor.Name = name;

            descriptor.Runtime = type.AssemblyQualifiedName;
        }

        private static void DescribeType(TypeDefinition descriptor, TypeAttribute attribute)
        {
            descriptor.Id = attribute.Id;

            if (!string.IsNullOrWhiteSpace(attribute.Name))
                descriptor.Name = attribute.Name.Trim();
        }

        private static void DescribeObject(ModelDefinition descriptor, PropertyInfo[] properties)
        {
            for (int i = 0, count = properties.Length; i < count; i++)
            {
                var info = properties[i];
                var property = new PropertyDefinition();

                var name = info.Name;

                var attribute = info.GetCustomAttribute<PropertyAttribute>();

                property.Name = info.Name;

                if (attribute != null)
                {
                    if (attribute.Ignore)
                        continue;

                    if (attribute.Default != null)
                        property.Default = attribute.Default;

                    if (attribute.Name != null)
                        property.Name = attribute.Name;
                }

                var propertyType = info.PropertyType;

                if (info.PropertyType.IsAssignableFrom(typeof(System.Collections.IEnumerable)))
                {
                    property.Role = PropertyRoles.HasMany;

                    Debug.Assert(propertyType.IsGenericType);

                    propertyType = propertyType.GetGenericArguments().Single();
                }

                property.Type = GetName(propertyType);

                descriptor.Properties.Add(property);
            }
        }

        public static string GetName(System.Type type)
        {
            return type.FullName;
        }
    }
}
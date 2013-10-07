﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Custom.Metadata
{
    [Service]
    public static class Factory
    {
        public static ObjectDescriptor DescribeObject<TObject>()
            where TObject : class
        {
            return DescribeObject(typeof(TObject));
        }

        public static ObjectDescriptor DescribeObject(Type type)
        {
            var attribute = type.GetCustomAttribute<ObjectAttribute>(false);

            if (attribute == null)
                return DescribeComplex(type, null);
            
            if (attribute is EntityAttribute)
                return DescribeEntity(type, attribute as EntityAttribute);
            
            return DescribeComplex(type, attribute as ComplexAttribute);
        }

        public static EntityDescriptor DescribeEntity<TEntity>()
            where TEntity : class
        {
            return DescribeEntity(typeof(TEntity));
        }

        public static EntityDescriptor DescribeEntity(Type type)
        {
            var attribute = type.GetCustomAttribute<EntityAttribute>(false);

            return DescribeEntity(type, attribute);
        }

        public static ComplexDescriptor DescribeComplex<TComplex>()
            where TComplex : class
        {
            return DescribeComplex(typeof(TComplex));
        }

        public static ComplexDescriptor DescribeComplex(Type type)
        {
            var attribute = type.GetCustomAttribute<ComplexAttribute>(false);

            return DescribeComplex(type, attribute);
        }

        public static ComplexDescriptor DescribeComplex(Type type, ComplexAttribute attribute)
        {
            var descriptor = new ComplexDescriptor();
            
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

                descriptor.Arguments = complexArguments;
            }

            if (attribute != null)
                DescribeObject(descriptor, attribute);

            DescribeObject(descriptor, type.GetProperties(BindingFlags.Public | BindingFlags.Instance));

            return descriptor;
        }

        private static EntityDescriptor DescribeEntity(Type type, EntityAttribute attribute)
        {
            if (type.IsGenericTypeDefinition)
                throw new InvalidOperationException("An entity should not be generic definition");

            var descriptor = new EntityDescriptor();

            DescribeObject(descriptor, type);

            if (attribute != null)
            {
                DescribeObject(descriptor, attribute);
            }

            DescribeObject(descriptor, type.GetProperties(BindingFlags.Public | BindingFlags.Instance));

            return descriptor;
        }

        private static void DescribeObject(ObjectDescriptor descriptor, Type type)
        {
            DescribeType(descriptor, type);
        }

        private static void DescribeObject(ObjectDescriptor descriptor, ObjectAttribute attribute)
        {
            DescribeType(descriptor, attribute);
        }

        private static void DescribeType(TypeDescriptor descriptor, Type type)
        {
            var name = type.Namespace + '.' + type.Name;

            descriptor.Name = name;

            descriptor.Runtime = type.AssemblyQualifiedName;
        }

        private static void DescribeType(TypeDescriptor descriptor, TypeAttribute attribute)
        {
            descriptor.Id = attribute.Id;

            if (!string.IsNullOrWhiteSpace(attribute.Name))
                descriptor.Name = attribute.Name.Trim();
        }

        private static void DescribeObject(ObjectDescriptor descriptor, PropertyInfo[] properties)
        {
            for (int i = 0, count = properties.Length; i < count; i++)
            {
                var info = properties[i];
                var property = new PropertyDescriptor();

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

                property.PropertyType = GetName(propertyType);

                descriptor.Properties.Add(property);
            }
        }

        public static string GetName(Type type)
        {
            return type.FullName;
        }
    }
}
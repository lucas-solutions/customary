{
    Type: [
        {
            Name: "Dynamic",
            Namespace: "System",
            MemberType: "Primitive",
            Title: {
                en: "Dynamic"
            }
        },
        {
            Name: "String",
            Namespace: "System",
            MemberType: "Primitive",
            Runtime: "System.String",
            Title: {
                en: "String"
            }
        },
        {
            Name: "Boolean",
            Namespace: "System",
            MemberType: "Primitive",
            Runtime: "System.Boolean",
            Title: {
                en: "True/False"
            }
        },
        {
            Name: "Number",
            Namespace: "System",
            MemberType: "Primitive",
            Runtime: "System.Decimal",
            Title: {
                en: "Number"
            }
        },
        {
            Name: "Integer",
            Namespace: "System",
            MemberType: "Primitive",
            Runtime: "System.Int32",
            Title: {
                en: "Integer"
            }
        },
        {
            Name: "Time",
            Namespace: "System",
            MemberType: "Primitive",
            Title: {
                en: "Time"
            }
        },
        {
            Name: "Date",
            Namespace: "System",
            MemberType: "Primitive",
            Title: {
                en: "Date"
            }
        },
        {
            Name: "DateTime",
            Namespace: "System",
            MemberType: "Primitive",
            Runtime: "System.DateTime",
            Title: {
                en: "Date and Time"
            }
        },
        {
            Name: "Email",
            Namespace: "System",
            MemberType: "Primitive",
            Title: {
                en: "e-Mail"
            }
        },
        {
            Name: "Username",
            Namespace: "System",
            MemberType: "Primitive",
            Title: {
                en: "User name"
            }
        },
        {
            Name: "Member",
            Namespace: "Custom.Metadata",
            MemberType: "Complex",
            Runtime: "Custom.Metadata.MemberDescriptor",
            Label: "Title",
            Properties: [
                {
                    Name: "ID",
                    MemberType: "Property",
                    PropertyType: "Guid",
                    Attributes: 8
                },
                {
                    Name: "Name",
                    MemberType: "Property",
                    PropertyType: "String",
                    Attributes: 4
                },
                {
                    Name: "MemberType",
                    MemberType: "Property",
                    PropertyType: "MemberTypes",
                    Attributes: 1
                },
                {
                    Name: "Title",
                    MemberType: "Property",
                    PropertyType: "Text"
                },
                {
                    Name: "Summary",
                    MemberType: "Property",
                    PropertyType: "Text"
                }
            ],
            Title: {
                en: "Member"
            }
        },
        {
            Name: "MemberTypes",
            Namespace: "Custom.Metadata",
            MemberType: "Enum",
            Runtime: "Custom.Metadata.MemberTypes",
            Members: [
                {
                    Name: "Constant",
                    Value: 0
                },
                {
                    Name: "Property",
                    Value: 1
                },
                {
                    Name: "Method",
                    Value: 2
                },
                {
                    Name: "Constructor",
                    Value: 3
                },
                {
                    Name: "Event",
                    Value: 4
                },
                {
                    Name: "Primitive",
                    Value: 8
                },
                {
                    Name: "Enum",
                    Value: 9
                },
                {
                    Name: "Unit",
                    Value: 10
                },
                {
                    Name: "Text",
                    Value: 11
                },
                {
                    Name: "Complex",
                    Value: 12
                },
                {
                    Name: "Entity",
                    Value: 13
                }
            ],
            Title: {
                en: "Member Types"
            }
        },
        {
            Name: "PropertyAttributes",
            Namespace: "Custom.Metadata",
            MemberType: "Enum",
            Runtime: "Custom.Metadata.PropertyAttributes",
            Members: [
                {
                    Name: "Optional",
                    Value: 0
                },
                {
                    Name: "Required",
                    Value: 1
                },
                {
                    Name: "Index",
                    Value: 2
                },
                {
                    Name: "Identity",
                    Value: 4
                },
                {
                    Name: "Collection",
                    Value: 8
                },
            ],
            Title: {
                en: "Property Attributes"
            }
        },
        {
            Name: "Constant",
            Namespace: "Custom.Metadata",
            MemberType: "Complex",
            Extend: "Custom.Metadata.Member",
            Runtime: "Custom.Metadata.ValueDescriptor",
            Properties: [
                {
                    Name: "Value",
                    MemberType: "Property",
                    PropertyType: "Dynamic",
                    Attributes: 1
                }
            ],
            Title: {
                en: "Constant"
            }
        },
        {
            Name: "Property",
            Namespace: "Custom.Metadata",
            MemberType: "Complex",
            Extend: "Custom.Metadata.Member",
            Runtime: "Custom.Metadata.PropertyDescriptor",
            Properties: [
                {
                    Name: "Defatul",
                    MemberType: "Property",
                    PropertyType: "Dynamic"
                },
                {
                    Name: "PropertyType",
                    MemberType: "Property",
                    PropertyType: "Type",
                    Attributes: 1
                }
            ],
            Title: {
                en: "Property"
            }
        },
        {
            Name: "Method",
            Namespace: "Custom.Metadata",
            MemberType: "Complex",
            Extend: "Custom.Metadata.Member",
            Runtime: "Custom.Metadata.MethodDescriptor",
            Properties: [
            ],
            Title: {
                en: "Method"
            }
        },
        {
            Name: "Type",
            Namespace: "Custom.Metadata",
            MemberType: "Entity",
            Extend: "Custom.Metadata.Member",
            Runtime: "Custom.Metadata.TypeDescriptor",
            Properties: [
                {
                    Name: "Namespace",
                    MemberType: "Property",
                    PropertyType: "String"
                },
                {
                    Name: "Members",
                    MemberType: "Property",
                    PropertyType: "Member",
                    Attributes: 16
                }
            ],
            Title: {
                en: "Type"
            }
        },
        {
            Name: "Primitive",
            Namespace: "Custom.Metadata",
            Extend: "Custom.Metadata.Type",
            MemberType: "Entity",
            Runtime: "Custom.Metadata.PrimitiveDescriptor",
            Properties: [
            ],
            Title: {
                en: "Primitive"
            }
        },
        {
            Name: "Enum",
            Namespace: "Custom.Metadata",
            Extend: "Custom.Metadata.Type",
            MemberType: "Entity",
            Runtime: "Custom.Metadata.EnumDescriptor",
            Properties: [
            ],
            Title: {
                en: "Enum"
            }
        },
        {
            Name: "Unit",
            Namespace: "Custom.Metadata",
            Extend: "Type",
            MemberType: "Entity",
            Runtime: "Custom.Metadata.UnitDescriptor",
            Properties: [
            ],
            Title: {
                en: "Unit"
            }
        },
        {
            Name: "Object",
            Namespace: "Custom.Metadata",
            Extend: "Custom.Metadata.Type",
            MemberType: "Entity",
            Runtime: "Custom.Metadata.ObjectDescriptor",
            Properties: [
            ],
            Title: {
                en: "Object",
                es: "Objeto"
            }
        },
        {
            Name: "Entity",
            Namespace: "Custom.Metadata",
            Extend: "Custom.Metadata.Object",
            MemberType: "Entity",
            Runtime: "Custom.Metadata.EntityDescriptor",
            Properties: [
            ],
            Title: {
                en: "Entity",
                es: "Entidad"
            }
        },
    ]
}
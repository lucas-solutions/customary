{
    Domain: [
        {
            Id: "customary.com",
            Segments: [
                {
                    Name: "Home",
                    Controller: "Home",
                    Action: "Default",
                    Resource: "~/Views/Home/GetStarted.cshtml",
                    Text: {
                        "en": "Start Page",
                        "es": "Pagina de Inicio"
                    }
                },
                {
                }
                ]
        }
        ],
    Type: [
        {
            Name: "String",
            MemberType: "Primitive"
        },
        {
            Name: "Boolean",
            MemberType: "Primitive"
        },
        {
            Name: "Number",
            MemberType: "Primitive"
        },
        {
            Name: "Integer",
            MemberType: "Primitive"
        },
        {
            Name: "Time",
            MemberType: "Primitive"
        },
        {
            Name: "Date",
            MemberType: "Primitive"
        },
        {
            Name: "DateTime",
            MemberType: "Primitive"
        },
        {
            Name: "Email",
            MemberType: "Primitive"
        },
        {
            Name: "Username",
            MemberType: "Primitive"
        },
        {
            Name: "Second",
            MemberType: "Unit",
            Measure: "Time",
            Factor: 1,
            Suffix: "s",
            Title: {
                "en": "Second",
                "es": "Segundos"
            }
        },
        {
            Name: "Gram",
            MemberType: "Unit",
            Measure: "Mass",
            Factor: 1,
            Suffix: "g",
            Title: {
                "en": "Second",
                "es": "Segundos"
            }
        },
        {
            Name: "Time",
            MemberType: "Measure",
            Title: {
                "en": "Time",
                "es": "Tiempo"
            }
        },
        {
            Name: "Money",
            MemberType: "Measure",
            Title: {
                "en": "Money",
                "es": "Moneda"
            }
        },
        {
            Name: "USD",
            MemberType: "Unit",
            Measure: "Money",
            Factor: 1,
            Symbol: "$",
            Suffix: "USD",
            Title: {
                "en": "United States Dollar",
                "es": "Dolar Estado Unidense"
            }
        },
        {
            Name: "Countries",
            MemberType: "Enum",
            Title: {
                'en': "Countries",
                'es': "Paices"
            },
            Members: [
                {
                    Name: "US",
                    Title: {
                        'en': "United States of America",
                        'es': "Estados Unidos de America"
                    }
                },
                {
                    Name: "CU",
                    Title: {
                        'en': "Cuba",
                        'es': "Cuba"
                    }
                },
                {
                    Name: "CR",
                    Title: {
                        'en': "Costa Rica",
                        'es': "Costa Rica"
                    }
                }],
        },
        {
            Name: "SalesDocument",
            MemberType: "Entity",
            Title: {
                'en': "Sales Document",
                'es': "Proforma"
            },
            Members: [
                {
                    Name: "SalesDocumentID",
                    MemberType: "Property",
                    PropertyType: "String",
                    Role: "Identity"
                },
                {
                    Name: "Items",
                    MemberType: "Property",
                    PropertyType: "SalesDocumentItem",
                    Role: "Collection",
                    Dependant: "SalesDocument"/* ForeignKey */
                },
            ]
        },
        {
            Name: "SalesDocumentItem",
            MemberType: "Entity",
            Title: {
                'en': "Sales Document",
                'es': "Proforma"
            },
            Members: [
                {
                    Name: "SalesDocumentItemID",
                    MemberType: "Property",
                    PropertyType: "String",
                    Role: "Identity"
                },
                {
                    Name: "SalesDocument",
                    MemberType: "Property",
                    PropertyType: "SalesDocument",
                    Role: "RequiredReference"
                },
            ]
        },
        {
            Name: "PropertyDescriptor",
            Namespace: "Custom.Reflection",
            MemberType: "Entity",
            Title: {
                'en': "Property Descriptor"
            },
            Members: [
                {
                    Name: "Name",
                    MemberType: "Property",
                    PropertyType: "String",
                    Role: "Identity"
                },
                {
                    Name: "MemberType",
                    MemberType: "Property",
                    PropertyType: "MemberTypes",
                    Role: "Reference"
                },
                {
                    Name: "PropertyType",
                    MemberType: "Property",
                    PropertyType: "String",
                    Role: "Required"
                },
                {
                    Name: "PropertyRole",
                    MemberType: "Property",
                    PropertyType: "PropertyRoles",
                    Role: "Reference"
                },
                {
                    Name: "Title",
                    MemberType: "Property",
                    PropertyType: "Text",
                    Role: "Collection"
                },
            ]
        },
        {
            Name: "MemberTypes",
            MemberType: "Enum",
            Members: [
                {
                    Name: "Enum"
                },
                {
                    Name: "Primitive"
                },
                {
                    Name: "Complex"
                },
                {
                    Name: "Entity"
                },
                {
                    Name: "Measure"
                },
                {
                    Name: "Unit"
                },
                {
                    Name: "Property"
                },
                {
                    Name: "Member"
                }
            ]
        },
        {
            Name: "PropertyRoles",
            MemberType: "Enum",
            Members: [
                {
                    Name: "Value"
                },
                {
                    Name: "Required"
                },
                {
                    Name: "Reference"
                },
                {
                    Name: "Collection"
                },
                {
                    Name: "RequiredReference"
                },
                {
                    Name: "RequiredCollection"
                },
                {
                    Name: "Text"
                },
                {
                    Name: "Identity"
                }
            ]
        }
    ],
    Text: {
        "Continue": {
            "en": "",
            "es": ""
        }
    }
}
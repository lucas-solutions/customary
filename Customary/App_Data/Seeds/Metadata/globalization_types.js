{
    Type: [
        {
            Name: "Language",
            Namespace: "Globalization",
            MemberType: "Entity",
            Identity: "ID",
            Label: "Title",
            Runtime: "Custom.Globalization.LanguageDescriptor",
            Members: [
                {
                    Name: "ID",
                    PropertyType: "Boolean",
                    Attributes: 8
                },
                {
                    Name: "Code",
                    PropertyType: "Boolean",
                    Attributes: 4
                },
                {
                    Name: "Title",
                    PropertyType: "Text"
                },
            ],
            Title: {
                'en': "Culture",
                'es': "Cutura"
            },
        },
        {
            Name: "Culture",
            Namespace: "Globalization",
            MemberType: "Entity",
            Identity: "ID",
            Label: "Title",
            Runtime: "Custom.Globalization.CultureDescriptor",
            Members: [
                {
                    Name: "ID",
                    PropertyType: "Boolean"
                },
                {
                    Name: "DefinitiveCulture",
                    PropertyType: "Boolean"
                },
                {
                    Name: "Title",
                    PropertyType: "Text"
                },
            ],
            Title: {
                'en': "Culture",
                'es': "Cutura"
            },
        },
        {
            Name: "Measurement",
            Namespace: "Globalization",
            MemberType: "Entity",
            Identity: "ID",
            Label: "Title",
            Runtime: "Custom.Globalization.MeasurementDescriptor",
            Members: [
                {
                    Name: "MeasurementType",
                    PropertyType: "MeasurementTypes"
                },
                {
                    Name: "Suffix",
                    PropertyType: "String"
                }
            ],
            Title: {
                'en': "Measurement",
                'es': "Medida"
            },
        },
        {
            Name: "MeasurementTypes",
            Namespace: "Globalization",
            MemberType: "Enum",
            Runtime: "Custom.Globalization.MeasurementTypes",
            Members: [
                {
                    Name: "Quantity",
                    Value: 0
                },
                {
                    Name: "Money",
                    Value: 1
                },
                {
                    Name: "Weight",
                    Value: 2
                },
                {
                    Name: "Length",
                    Value: 3
                }
            ],
            Title: {
                'en': "Measurement",
                'es': "Medida"
            },
        },
        {
            Name: "Currency",
            Namespace: "Globalization",
            MemberType: "Entity",
            Extends: "Measurement",
            Runtime: "Custom.Globalization.CurrenctDescriptor",
            Members: [
                {
                    Name: "Symbol",
                    PropertyType: "String"
                },
                {
                    Name: "ChangeRate",
                    PropertyType: "String"
                }
            ],
            Title: {
                'en': "Money",
                'es': "Moneda"
            },
        },
        {
            Name: "Region",
            Namespace: "Globalization",
            MemberType: "Entity",
            Label: "Title",
            Runtime: "Custom.Globalization.RegionDescriptor",
            Members: [
            ],
            Title: {
                'en': "Region",
                'es': "Region"
            },
        },
        {
            Name: "Country",
            Namespace: "Globalization",
            MemberType: "Entity",
            Extends: "Region",
            Runtime: "Custom.Globalization.CountryDescriptor",
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
            Title: {
                'en': "Country",
                'es': "Pais"
            },
        }
    ]
}
{
    Type: [
        {
            Name: "Language",
            Namespace: "Custom.Globalization",
            MemberType: "Entity",
            Identity: "ID",
            Label: "Title",
            Runtime: "Custom.Globalization.LanguageDescriptor",
            Properties: [
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
            Namespace: "Custom.Globalization",
            MemberType: "Entity",
            Identity: "ID",
            Label: "Title",
            Runtime: "Custom.Globalization.CultureDescriptor",
            Properties: [
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
            Namespace: "Custom.Globalization",
            MemberType: "Entity",
            Identity: "ID",
            Label: "Title",
            Runtime: "Custom.Globalization.MeasurementDescriptor",
            Properties: [
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
            Namespace: "Custom.Globalization",
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
            Namespace: "Custom.Globalization",
            MemberType: "Entity",
            Extends: "Custom.Globalization.Measurement",
            Runtime: "Custom.Globalization.CurrenctDescriptor",
            Properties: [
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
            Namespace: "Custom.Globalization",
            MemberType: "Entity",
            Label: "Title",
            Runtime: "Custom.Globalization.RegionDescriptor",
            Properties: [
            ],
            Title: {
                'en': "Region",
                'es': "Region"
            },
        },
        {
            Name: "Country",
            Namespace: "Custom.Globalization",
            MemberType: "Entity",
            Extends: "Custom.Globalization.Region",
            Runtime: "Custom.Globalization.CountryDescriptor",
            Properties: [
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
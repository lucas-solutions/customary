{
    Applications: [
        {
            Name: "localhost"
        }
        ],
    Links: [
        {
            Type: "association",
            Multiplicity: "*",
            Principal: "Country",
            Dependant: "State",
            PrimaryKey: "Name",
            ForeignKey: "Country"
        },
        {
            Type: "association",
            Multiplicity: "*",
            Principal: "State",
            Dependant: "Province",
            PrimaryKey: "Name",
            ForeignKey: "State"
        },
        {
            Type: "association",
            Multiplicity: "*",
            Principal: "Province",
            Dependant: "Locality",
            PrimaryKey: "Name",
            ForeignKey: "Province"
        }
    ],
    Models: [
        {
            Name: "Country",
            Title: {
                'en': "Country",
                'es': "Pais"
            },
            Properties: [
                {
                    Name: "Name",
                    Type: "string",
                    Default: "USA"
                }
            ]
        },
        {
            Name: "State",
            Title: {
                'en': "State",
                'es': "Estado"
            },
            Properties: [
                {
                    Name: "Name",
                    Type: "string",
                    Default: "Florida"
                },
                {
                    Name: "Country",
                    Type: "string",
                    Default: "USA"
                }
            ]
        },
        {
            Name: "Province",
            Title: {
                'en': "Province",
                'es': "Provincia",
            },
            Properties: [
                {
                    Name: "Name",
                    Type: "string",
                    Default: "Tampa"
                },
                {
                    Name: "State",
                    Type: "string",
                    Default: "Florida"
                }
            ]
        },
        {
            Name: "Locality",
            Title: {
                'en': "Locality",
                'es': "Localidad",
            },
            Properties: [
                {
                    Name: "Name",
                    Type: "string",
                    Default: "Orlando"
                },
                {
                    Name: "Province",
                    Type: "string",
                    Default: "Tampa"
                },
                {
                    Name: "Population",
                    Type: "int",
                    Default: "0",
                    Format: ",",
                    Convert: "toCommaSeparated"
                }
            ]
        }
    ]
}
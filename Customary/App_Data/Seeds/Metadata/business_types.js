{
    Type: [
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
        }
    ]
}
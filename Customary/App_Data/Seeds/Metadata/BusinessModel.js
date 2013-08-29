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
    ]
}
{
    "Models": [
        {
            "Name": "Column",
            "Title": [
                { "Culture": "en", "Text": "Column" },
                { "Culture": "es", "Text": "Columna" },
            ],
            "Summary": [
                { "Culture": "en", "Text": "" },
                { "Culture": "es", "Text": "" },
            ],
            "Fields": [
                {
                    "Name": "Name",
                    "Type": "String",
                    "Max": 20,
                    "Required": true,
                    "Computed": false,
                    "Title": [
                        { "Culture": "en", "Text": "Name" },
                        { "Culture": "es", "Text": "Nombre" },
                    ]
                },
                {
                    "Name": "Flex",
                    "Type": "Integer",
                    "Max": 99,
                    "Min": 1,
                    "Required": false,
                    "Computed": false,
                    "Title": [
                        { "Culture": "en", "Text": "Flex" },
                        { "Culture": "es", "Text": "Flex" },
                    ]
                },
                {
                    "Name": "Fixed",
                    "Type": "Boolean",
                    "Required": false,
                    "Computed": false,
                    "Title": [
                        { "Culture": "en", "Text": "Fixed" },
                        { "Culture": "es", "Text": "Fijo" },
                    ]
                },
                {
                    "Name": "Width",
                    "Type": "Integer",
                    "Max": 500,
                    "Min": 5,
                    "Required": false,
                    "Computed": false,
                    "Title": [
                        { "Culture": "en", "Text": "Width" },
                        { "Culture": "es", "Text": "Ancho" },
                    ]
                },
                {
                    "Name": "ModifiedOn",
                    "Type": "DateTime",
                    "Required": false,
                    "Computed": true,
                    "Title": [
                        { "Culture": "en", "Text": "Modified on" },
                        { "Culture": "es", "Text": "Modificado" },
                    ]
                },
                {
                    "Name": "ModifiedBy",
                    "Type": "String",
                    "Max": 20,
                    "Required": false,
                    "Computed": true,
                    "Title": [
                        { "Culture": "en", "Text": "Modified by" },
                        { "Culture": "es", "Text": "Modificado por" },
                    ]
                },
                {
                    "Name": "CreatedOn",
                    "Type": "DateTime",
                    "Required": true,
                    "Computed": true,
                    "Title": [
                        { "Culture": "en", "Text": "Created on" },
                        { "Culture": "es", "Text": "Creado" },
                    ]
                },
                {
                    "Name": "CreatedBy",
                    "Type": "String",
                    "Max": 20,
                    "Required": true,
                    "Computed": true,
                    "Title": [
                        { "Culture": "en", "Text": "Created by" },
                        { "Culture": "es", "Text": "Creado por" },
                    ]
                },
            ],
            "CreatedOn": "2013-06-02:19:24",
            "CreatedBy": "system"
        }
    ]
}
{
    "Models": [
        {
            "Name": "Area",
            "Title": [
                { "Culture": "en", "Text": "Area" },
                { "Culture": "es", "Text": "Area" },
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
                    "Name": "Title",
                    "Type": "String",
                    "Max": 60,
                    "Required": true,
                    "Computed": false,
                    "Title": [
                        { "Culture": "en", "Text": "Title" },
                        { "Culture": "es", "Text": "Titulo" },
                    ]
                },
                {
                    "Name": "Summary",
                    "Type": "String",
                    "Max": 500,
                    "Required": true,
                    "Computed": false,
                    "Title": [
                        { "Culture": "en", "Text": "Summary" },
                        { "Culture": "es", "Text": "Sumario" },
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
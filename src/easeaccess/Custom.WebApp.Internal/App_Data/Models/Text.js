{
    "Models": [
        {
            "Name": "Text",
            "Title": [
                { "Culture": "en", "Text": "Text" },
                { "Culture": "es", "Text": "Texto" },
            ],
            "Summary": [
                { "Culture": "en", "Text": "" },
                { "Culture": "es", "Text": "" },
            ],
            "Fields": [
                {
                    "Name": "Culture",
                    "Type": "String",
                    "Max": 20,
                    "Required": true,
                    "Computed": false,
                    "Title": [
                        { "Culture": "en", "Text": "Culture" },
                        { "Culture": "es", "Text": "Cultura" },
                    ]
                },
                {
                    "Name": "Text",
                    "Type": "String",
                    "Required": true,
                    "Computed": false,
                    "Title": [
                        { "Culture": "en", "Text": "Text" },
                        { "Culture": "es", "Text": "Texto" },
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
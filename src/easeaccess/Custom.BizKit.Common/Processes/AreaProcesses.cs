using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Processes
{
    using Custom.Models;
    using Raven.Json.Linq;

    using Dictionary = Dictionary<string, object>;

    public class AreaProcesses : ReflectionProcesses<Area>
    {
        public AreaProcesses(Reflection reflection)
            : base(reflection)
        {
        }

        public AreaProcesses(Reflection reflection, RavenJObject data)
            : base(reflection, data)
        {
        }

        public object Metadata
        {
            get
            {
                return new Dictionary
                {
                    { "type", "object" },
                    { "members", new Dictionary
                        {
                            { "Name", new Dictionary
                                {
                                    { "title",  "Name" },
                                    { "type", "text" },
                                    { "require", true }
                                }
                            },
                            { "Title", new Dictionary
                                {
                                    { "title",  "Title" },
                                    { "type", "text" }
                                }
                            },
                            { "Summary", new Dictionary
                                {
                                    { "title",  "Summary" },
                                    { "type", "text" }
                                }
                            },
                            { "ModifiedOn", new Dictionary
                                {
                                    { "title", "Modified On" },
                                    { "type", "date" },
                                    { "readOnly", true },
                                    { "format", "Y-m-d\\TH:i:s" },
                                    //{ "submitFormat", "n/j/Y" },
                                    { "blankText", "Never modified" }
                                }
                            },
                            { "ModifiedBy", new Dictionary
                                {
                                    { "title",  "Modified By" },
                                    { "type", "text" },
                                    { "readOnly", true },
                                    { "blankText", "Never modified" }
                                }
                            },
                            { "CreatedOn", new Dictionary
                                {
                                    { "title", "Created On" },
                                    { "type", "date" },
                                    { "readOnly", true },
                                    { "format", "Y-m-d\\TH:i:s" },
                                    //{ "submitFormat", "n/j/Y" },
                                }
                            },
                            { "CreatedBy", new Dictionary
                                {
                                    { "title",  "Created By" },
                                    { "type", "text" },
                                    { "readOnly", true }
                                }
                            },
                            { "Areas", AreasMetadata },
                            { "Files", FilesMetadata },
                            { "Grids", GridsMetadata },
                            { "Lists", ListsMetadata },
                            { "Nodes", NodesMetadata }
                        }
                    }
                };
            }
        }

        private Dictionary AreasMetadata
        {
            get
            {
                return new Dictionary
                {
                    { "title", "Areas" },
                    { "type", "grid" },
                    { "arrange", "accordion" },
                    { "members", new Dictionary
                        { 
                            { "Name", new Dictionary
                                {
                                    { "editor", new Dictionary { { "allowBlank", true } } },
                                    { "fixed", false },
                                    { "flex", 1 },
                                    { "text", "Name" },
                                    { "width", 80 }
                                }
                            },
                            { "Title", new Dictionary
                                {
                                    { "editor", new Dictionary { { "allowBlank", true } } },
                                    { "fixed", false },
                                    { "flex", 2 },
                                    { "text", "Title" },
                                    { "width", 120 }
                                }
                            },
                            { "Summary", new Dictionary
                                {
                                    { "title", "Summary" },
                                    { "editor", new Dictionary { { "allowBlank", true } }},
                                    { "fixed", false },
                                    { "flex", 5},
                                    
                                    { "width", 120 }
                                }
                            },
                            { "ModifiedOn", new Dictionary
                                {
                                    { "title", "Modified On" },
                                    { "fixed", false },
                                    { "flex", 1 },
                                    { "format", "H:i:s" },
                                    { "width", 80 },
                                    { "type", "date" }
                                }
                            },
                            { "ModifiedBy", new Dictionary
                                {
                                    { "title", "Modified By" },
                                    { "fixed", false },
                                    { "flex", 1 },
                                    { "width", 80 }
                                }
                            },
                            { "CreatedOn", new Dictionary
                                {
                                    { "title", "Created On" },
                                    { "fixed", false },
                                    { "flex", 1 },
                                    { "format", "H:i:s" },
                                    { "width", 80 },
                                    { "type", "date" }
                                }
                            },
                            { "CreatedBy", new Dictionary
                                {
                                    { "title", "Create By" },
                                    { "fixed", "false" },
                                    { "flex", 1 },
                                    { "width", 80 }
                                }
                            }
                        }
                    }
                };
            }
        }

        private Dictionary FilesMetadata
        {
            get
            {
                return new Dictionary
                {
                    { "title", "Files" },
                    { "type", "grid" },
                    { "members", new Dictionary
                        { 
                            { "Name", new Dictionary
                                {
                                    { "editor", new Dictionary { { "allowBlank", true } } },
                                    { "fixed", false },
                                    { "flex", 1 },
                                    { "text", "Name" },
                                    { "width", 80 }
                                }
                            },
                            { "Title", new Dictionary
                                {
                                    { "editor", new Dictionary { { "allowBlank", true } } },
                                    { "fixed", false },
                                    { "flex", 2 },
                                    { "text", "Title" },
                                    { "width", 120 }
                                }
                            },
                            { "Summary", new Dictionary
                                {
                                    { "title", "Summary" },
                                    { "editor", new Dictionary { { "allowBlank", true } }},
                                    { "fixed", false },
                                    { "flex", 5},
                                    
                                    { "width", 120 }
                                }
                            },
                            { "ModifiedOn", new Dictionary
                                {
                                    { "title", "Modified On" },
                                    { "fixed", false },
                                    { "flex", 1 },
                                    { "format", "H:i:s" },
                                    { "width", 80 },
                                    { "type", "date" }
                                }
                            },
                            { "ModifiedBy", new Dictionary
                                {
                                    { "title", "Modified By" },
                                    { "fixed", false },
                                    { "flex", 1 },
                                    { "width", 80 }
                                }
                            },
                            { "CreatedOn", new Dictionary
                                {
                                    { "title", "Created On" },
                                    { "fixed", false },
                                    { "flex", 1 },
                                    { "format", "H:i:s" },
                                    { "width", 80 },
                                    { "type", "date" }
                                }
                            },
                            { "CreatedBy", new Dictionary
                                {
                                    { "title", "Create By" },
                                    { "fixed", "false" },
                                    { "flex", 1 },
                                    { "width", 80 }
                                }
                            }
                        }
                    }
                };
            }
        }

        private Dictionary GridsMetadata
        {
            get
            {
                return new Dictionary
                {
                    { "title", "Grids" },
                    { "type", "grid" },
                    { "members", new Dictionary
                        { 
                            { "Name", new Dictionary
                                {
                                    { "editor", new Dictionary { { "allowBlank", true } } },
                                    { "fixed", false },
                                    { "flex", 1 },
                                    { "text", "Name" },
                                    { "width", 80 }
                                }
                            },
                            { "Title", new Dictionary
                                {
                                    { "editor", new Dictionary { { "allowBlank", true } } },
                                    { "fixed", false },
                                    { "flex", 2 },
                                    { "text", "Title" },
                                    { "width", 120 }
                                }
                            },
                            { "Summary", new Dictionary
                                {
                                    { "title", "Summary" },
                                    { "editor", new Dictionary { { "allowBlank", true } }},
                                    { "fixed", false },
                                    { "flex", 5},
                                    
                                    { "width", 120 }
                                }
                            },
                            { "ModifiedOn", new Dictionary
                                {
                                    { "title", "Modified On" },
                                    { "fixed", false },
                                    { "flex", 1 },
                                    { "format", "H:i:s" },
                                    { "width", 80 },
                                    { "type", "date" }
                                }
                            },
                            { "ModifiedBy", new Dictionary
                                {
                                    { "title", "Modified By" },
                                    { "fixed", false },
                                    { "flex", 1 },
                                    { "width", 80 }
                                }
                            },
                            { "CreatedOn", new Dictionary
                                {
                                    { "title", "Created On" },
                                    { "fixed", false },
                                    { "flex", 1 },
                                    { "format", "H:i:s" },
                                    { "width", 80 },
                                    { "type", "date" }
                                }
                            },
                            { "CreatedBy", new Dictionary
                                {
                                    { "title", "Create By" },
                                    { "fixed", "false" },
                                    { "flex", 1 },
                                    { "width", 80 }
                                }
                            }
                        }
                    }
                };
            }
        }

        private Dictionary ListsMetadata
        {
            get
            {
                return new Dictionary
                {
                    { "title", "Lists" },
                    { "type", "grid" },
                    { "members", new Dictionary
                        { 
                            { "Name", new Dictionary
                                {
                                    { "editor", new Dictionary { { "allowBlank", true } } },
                                    { "fixed", false },
                                    { "flex", 1 },
                                    { "text", "Name" },
                                    { "width", 80 }
                                }
                            },
                            { "Title", new Dictionary
                                {
                                    { "editor", new Dictionary { { "allowBlank", true } } },
                                    { "fixed", false },
                                    { "flex", 2 },
                                    { "text", "Title" },
                                    { "width", 120 }
                                }
                            },
                            { "Summary", new Dictionary
                                {
                                    { "title", "Summary" },
                                    { "editor", new Dictionary { { "allowBlank", true } }},
                                    { "fixed", false },
                                    { "flex", 5},
                                    
                                    { "width", 120 }
                                }
                            },
                            { "ModifiedOn", new Dictionary
                                {
                                    { "title", "Modified On" },
                                    { "fixed", false },
                                    { "flex", 1 },
                                    { "format", "H:i:s" },
                                    { "width", 80 },
                                    { "type", "date" }
                                }
                            },
                            { "ModifiedBy", new Dictionary
                                {
                                    { "title", "Modified By" },
                                    { "fixed", false },
                                    { "flex", 1 },
                                    { "width", 80 }
                                }
                            },
                            { "CreatedOn", new Dictionary
                                {
                                    { "title", "Created On" },
                                    { "fixed", false },
                                    { "flex", 1 },
                                    { "format", "H:i:s" },
                                    { "width", 80 },
                                    { "type", "date" }
                                }
                            },
                            { "CreatedBy", new Dictionary
                                {
                                    { "title", "Create By" },
                                    { "fixed", "false" },
                                    { "flex", 1 },
                                    { "width", 80 }
                                }
                            }
                        }
                    }
                };
            }
        }

        private Dictionary NodesMetadata
        {
            get
            {
                return new Dictionary
                {
                    { "title", "Nodes" },
                    { "type", "grid" },
                    { "members", new Dictionary
                        { 
                            { "Name", new Dictionary
                                {
                                    { "editor", new Dictionary { { "allowBlank", true } } },
                                    { "fixed", false },
                                    { "flex", 1 },
                                    { "text", "Name" },
                                    { "width", 80 }
                                }
                            },
                            { "Title", new Dictionary
                                {
                                    { "editor", new Dictionary { { "allowBlank", true } } },
                                    { "fixed", false },
                                    { "flex", 2 },
                                    { "text", "Title" },
                                    { "width", 120 }
                                }
                            },
                            { "Summary", new Dictionary
                                {
                                    { "title", "Summary" },
                                    { "editor", new Dictionary { { "allowBlank", true } }},
                                    { "fixed", false },
                                    { "flex", 5},
                                    
                                    { "width", 120 }
                                }
                            },
                            { "ModifiedOn", new Dictionary
                                {
                                    { "title", "Modified On" },
                                    { "fixed", false },
                                    { "flex", 1 },
                                    { "format", "H:i:s" },
                                    { "width", 80 },
                                    { "type", "date" }
                                }
                            },
                            { "ModifiedBy", new Dictionary
                                {
                                    { "title", "Modified By" },
                                    { "fixed", false },
                                    { "flex", 1 },
                                    { "width", 80 }
                                }
                            },
                            { "CreatedOn", new Dictionary
                                {
                                    { "title", "Created On" },
                                    { "fixed", false },
                                    { "flex", 1 },
                                    { "format", "H:i:s" },
                                    { "width", 80 },
                                    { "type", "date" }
                                }
                            },
                            { "CreatedBy", new Dictionary
                                {
                                    { "title", "Create By" },
                                    { "fixed", "false" },
                                    { "flex", 1 },
                                    { "width", 80 }
                                }
                            }
                        }
                    }
                };
            }
        }
    }
}

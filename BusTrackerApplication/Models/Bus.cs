using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Storage.Table;

namespace BusTrackerApplication
{
    public class Bus:TableEntity
    {
    
            public Bus() { }

            public string Name { get; set; }
            public string Number { get; set; }
            public string ImagePath
            { get { return "~/images/800px_COLOURBOX1510671.jpg"; } }

        
    }
}
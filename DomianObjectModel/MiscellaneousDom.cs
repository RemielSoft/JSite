﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Remielsoft.JetSave.DomianObjectModel
{
  public   class MiscellaneousDom
    {
        public int Id { get; set; }


        public string Description{ get; set; }

        public Decimal Amount { get; set; }

        public string Per_consignment { get; set; }

        public string Mandatory { get; set; }

        public string ServiceTax { get; set; }
    }
} 

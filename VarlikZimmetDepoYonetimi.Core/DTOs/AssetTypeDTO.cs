﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.Core.DTOs
{
    public class AssetTypeDTO : BaseDTO
    {
        public int AssetTypeID { get; set; }
        public string AssetTypeName { get; set; }
    }
}

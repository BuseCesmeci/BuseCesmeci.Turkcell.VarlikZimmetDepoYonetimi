using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.Core.Models.Entities
{
    public class AssetCustomer : BaseEntity, IEntity
    {
        [Key]
        public int AssetCustomerID { get; set; }
        public int AssetID { get; set; }
        public int CustomerID { get; set; }
    }
}

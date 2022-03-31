using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.Core.Models.Entities
{
    public class Document : BaseEntity, IEntity
    {
        [Key]
        public int DocumentID { get; set; }
        public int AssetID { get; set; }
        public string PageCode { get; set; }
        public string FilePath { get; set; }
    }
}

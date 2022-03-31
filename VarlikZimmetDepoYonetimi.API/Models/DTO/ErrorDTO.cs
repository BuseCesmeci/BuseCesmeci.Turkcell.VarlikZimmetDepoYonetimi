using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.API.Models.DTO
{
    public class ErrorDTO
    {
        public ErrorDTO()
        {
            ErrorDesc = new List<string>();
        }
        public int StatusCode { get; set; }
        public List<string> ErrorDesc { get; set; }
    }
}

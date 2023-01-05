using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class WebConfig
    {
        [Key]
        public int OptionID { get; set; }
        public string OptionName { get; set; }
        public string OptionValue { get; set; }
    }
}

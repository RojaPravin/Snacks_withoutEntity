using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Snacks_withoutEntity.Models
{   

    public class billing
    {  
          //[table("billing")]
            public int Id { get; set; }
            [StringLength (100)]
            [Required (ErrorMessage = " Snacks Name is required")]
            public string Name { get; set; }
            public int? Cost { get; set; }
            public string Company { get; set; }

        
    }

}
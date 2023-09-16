using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerAutomation.Models
{
    public class BurgerMenu:BaseEntity
    {
        public string Explanation { get; set; }

        public override string ToString()
        {
            return $"{Name} => {Price:C2}"; 
        }
    }
}

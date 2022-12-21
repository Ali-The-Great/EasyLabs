using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalibrary.Models
{
    internal class ComponentsModel
    {
        public int Component_Id { get; set; }
        public int Test_Id { get; set; }
        public int Unit_Id { get; set; }
        public string Component_Description { get; set; }       
        public string M_average { get; set; }
        public string F_average { get; set; }
    }
}

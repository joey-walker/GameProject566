using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject566
{
    public class inventoryItem
    {
        public string name { set; get; }
        public inventoryItem(string name)
        {
            this.name = name;
        }
    }
}

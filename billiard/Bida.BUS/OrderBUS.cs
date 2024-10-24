using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bida.DTO;

namespace Bida.BUS
{

    public class OrderBUS
    {
        public List<ORDER> GetAll()
        {
            using (Model c = new Model())
            {
                return c.ORDERs.ToList();
            }
        }
    }
}

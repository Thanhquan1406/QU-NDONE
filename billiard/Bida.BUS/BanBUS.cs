using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bida.DTO;
using Bida.DAO;


namespace Bida.BUS
{
    public class BanBUS
    {
        public List<BAN> GetListBan()
        {
            return new BanDAO().getlstBan();
        }

        public void updateBan(BAN b)
        {
            new BanDAO().updateBan(b);
        }

        public void chuyenban(BAN b1, BAN b2)
        {
            b2.TINHTRANG = true;
            b2.GIOBD = b1.GIOBD;
            
            b1.TINHTRANG = false;

            updatemakh(b1,1);
            updatemakh(b2, b1.KHACHHANG.MAKH);
            updateBan(b1);
            updateBan(b2);

        }

        public void AddBan(BAN b)
        {
            new BanDAO().createBan(b);
        }

        public void updatemakh(BAN b, int makh)
        {
            new BanDAO().updateMakhB(b, makh);
        }
    }
}

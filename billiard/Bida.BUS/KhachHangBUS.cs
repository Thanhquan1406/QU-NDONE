using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bida.DTO;
using Bida.DAO;

namespace Bida.BUS
{
    public class KhachHangBUS
    {
        public List<KHACHHANG> GetListKH()
        {
            return new KhachHangDAO().getlstKhachHang();
        }

        public KHACHHANG GetKhachHangbyID(int a)
        {
            return new KhachHangDAO().GetKhachHangbyID(a);
        }

        public void addKH(KHACHHANG b)
        {
            new KhachHangDAO().addKhachHang(b);
        }
    }
}

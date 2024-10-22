using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bida.DAO;
using Bida.DTO;

namespace Bida.BUS
{
    public class NhanVienBUS
    {
        public List<NHANVIEN> GetListNV()
        {
            return new NhanVienDAO().getlsttNV();
        }

        public Boolean ValidateNv(string user, string pass)
        {
            return new NhanVienDAO().validateNV(user, pass);
        }

        public NHANVIEN GetNhanVienbyID(string user)
        {
            return new NhanVienDAO().GetNhanVienbyID(user);
        }
    }
}

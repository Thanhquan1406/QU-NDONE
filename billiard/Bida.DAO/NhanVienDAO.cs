using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bida.DTO;

namespace Bida.DAO
{
    public class NhanVienDAO
    {
        DataProvider provider;
        public NhanVienDAO()
        {
            provider= new DataProvider();
        }
        public List<NHANVIEN> getlsttNV()
        {
            List<NHANVIEN> lst = new List<NHANVIEN>();
            provider.Connect();
            string sql = "select * from NhanVien";
            SqlDataReader reader = provider.ExcuteReader(sql);

            while (reader.Read())
            {
                string manv = reader.GetString(0);
                string taikhoan = reader.GetString(1);
                bool calam = reader.GetBoolean(2);
                string pass = reader.GetString(3);

                NHANVIEN b = new NHANVIEN();
                b.MANHANVIEN = manv;
                b.TenNhanVien = taikhoan;
                b.CALAM = calam;
                b.PASSNV = pass;
                lst.Add(b);
            }
            return lst;
        }

        public Boolean validateNV(string user, string pass)
        {
            List<NHANVIEN> lst = new List<NHANVIEN>(this.getlsttNV());
            for(int i= 0 ; i<lst.Count;i++)
            {
                if (lst[i].MANHANVIEN.Equals(user) & lst[i].PASSNV.Equals(pass))
                {
                    return true;
                }
            }
            return false;
        }

        public NHANVIEN GetNhanVienbyID(String user)
        {
            List<NHANVIEN> lst = new List<NHANVIEN>(this.getlsttNV());
            NHANVIEN nv = null;
            for (int i = 0; i < lst.Count; i++)
            {
                if (lst[i].MANHANVIEN.Equals(user))
                {
                    nv = lst[i];
                    break;
                }
            }
            return nv;
        }
    }
}

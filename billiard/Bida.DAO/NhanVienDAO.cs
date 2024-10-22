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
                // Updated variable names and instantiation
                string manv = reader.GetString(0); // Read as string
                string taikhoan = reader.GetString(1);
                bool calam = reader.GetBoolean(2);
                string pass = reader.GetString(3);

                // Adjusted instantiation to match the existing NHANVIEN constructor
                NHANVIEN b = new NHANVIEN(); // Use the default constructor
                b.MANHANVIEN = manv; // Directly assign the string
                b.TenNhanVien = taikhoan; // Set the TenNhanVien property
                b.CALAM = calam; // Set the CALAM property
                b.PASSNV = pass; // Set the PASSNV property
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

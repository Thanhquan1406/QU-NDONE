using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bida.DTO;

namespace Bida.DAO
{
    public class KhachHangDAO
    {
        DataProvider provider;
        public KhachHangDAO()
        {
            provider= new DataProvider();
        }
        public List<KHACHHANG> getlstKhachHang()
        {
            List<KHACHHANG> lst = new List<KHACHHANG>();
            provider.Connect();
            string sql = "select * from KhachHang";
            SqlDataReader reader = provider.ExcuteReader(sql);

            while (reader.Read())
            {
                int makh = reader.GetInt32(0);
                string tenkh = reader.GetString(1);
                string sdt = reader.GetString(2);
                KHACHHANG b = new KHACHHANG(tenkh,sdt);
               
                b.MAKH = makh;
                lst.Add(b);
            }
            return lst;
        }
        public KHACHHANG GetKhachHangbyID(int user)
        {
            List<KHACHHANG> lst = new List<KHACHHANG>(this.getlstKhachHang());
            KHACHHANG nv = null;
            for (int i = 0; i < lst.Count; i++)
            {
                if (lst[i].MAKH == user)
                {
                    nv = lst[i];
                    break;
                }
            }
            return nv;
        }
        public void addKhachHang(KHACHHANG b)
        {
            provider.Connect();
            string sql = "insert into KHACHHANG(TENKH, SDT) VALUES ('"+ b.TENKH + "','" + b.SDT + "')";
            provider.executeNonQuery(sql);
        }


    }
}

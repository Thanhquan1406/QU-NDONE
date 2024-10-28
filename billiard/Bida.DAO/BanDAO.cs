using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Bida.DTO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bida.DAO
{
    public class BanDAO
    {
        DataProvider provider;

        public BanDAO()
        {
            provider = new DataProvider();
        }

        public List<BAN> getlstBan()
        {
            List<BAN> lst = new List<BAN>();
            provider.Connect();
            string sql = "select * from Ban";
            SqlDataReader reader = provider.ExcuteReader(sql);

            while (reader.Read())
            {
                int maban = reader.GetInt32(0);
                bool LoaiBan = reader.GetBoolean(1);
                int KhuVuc = reader.GetInt32(2);
                bool TinhTrang = reader.GetBoolean(3);

                DateTime? GioBD = reader.IsDBNull(4) ? (DateTime?)null : reader.GetDateTime(4);
                DateTime? GioKT = reader.IsDBNull(5) ? (DateTime?)null : reader.GetDateTime(5);

                BAN b = new BAN(LoaiBan, KhuVuc, TinhTrang, GioBD, GioKT);
                b.MABAN = maban;

                if (!reader.IsDBNull(6))
                {
                    b.KHACHHANG = new KhachHangDAO().GetKhachHangbyID(reader.GetInt32(6));
                }
                lst.Add(b);
            }
            return lst;
        }


        public void updateBan(BAN b)
        {
            string bd = b.GIOBD.HasValue ? b.GIOBD.Value.ToString("yyyy-MM-dd HH:mm:ss") : null;
            string kt = b.GIOKT.HasValue ? b.GIOKT.Value.ToString("yyyy-MM-dd HH:mm:ss") : null;
            provider.Connect();

            int loaiban = b.LOAIBAN.HasValue && b.LOAIBAN.Value ? 1 : 0;
            int tinhtrang = b.TINHTRANG.HasValue && b.TINHTRANG.Value ? 1 : 0;

            string sql = "UPDATE ban SET LOAIBAN = " + loaiban + ", KHUVUC = " + b.KHUVUC + ", TINHTRANG = " + tinhtrang +
                         (bd != null ? ", GIOBD = '" + bd + "'" : ", GIOBD = NULL") +
                         (kt != null ? ", GIOKT = '" + kt + "'" : ", GIOKT = NULL") +
                         " WHERE MABAN = " + b.MABAN;

            provider.executeNonQuery(sql);
        }


        public void createBan(BAN b)
        {
            string bd = b.GIOBD.HasValue ? b.GIOBD.Value.ToString("yyyy-MM-dd HH:mm:ss") : null;
            string kt = b.GIOKT.HasValue ? b.GIOKT.Value.ToString("yyyy-MM-dd HH:mm:ss") : null;

            provider.Connect();

            int loaiban = b.LOAIBAN.HasValue && b.LOAIBAN.Value ? 1 : 0;
            int tinhtrang = b.TINHTRANG.HasValue && b.TINHTRANG.Value ? 1 : 0;

            string sql = "INSERT INTO BAN (LOAIBAN, KHUVUC, TINHTRANG, GIOBD, GIOKT, MAKH) VALUES ("
                + loaiban + "," + b.KHUVUC + "," + tinhtrang + ",'" + bd + "','" + kt + "'," + 1 + ")";

            provider.executeNonQuery(sql);
        }

        public void updateMakhB(BAN b, int makh)
        {
            provider.Connect();

            b.KHACHHANG = new KhachHangDAO().GetKhachHangbyID(makh);

            string sql = "update ban set MAKH = " + makh + " where MABAN = " + b.MABAN;
            provider.executeNonQuery(sql);
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bida.DTO;
namespace Bida.DAO
{
    public class BienLaiDAO
    {
        DataProvider provider;

        public BienLaiDAO()
        {
            provider= new DataProvider();
        }
        public void addKhachHang(BIENLAI b)
        {
            provider.Connect();
            string bd = b.GioBD.HasValue ? b.GioBD.Value.ToString("yyyy-MM-dd HH:mm:ss") : null;
            string kt = b.GioKT.HasValue ? b.GioKT.Value.ToString("yyyy-MM-dd HH:mm:ss") : null;
            string sql = "insert into BIENLAI(MANHANVIEN, MABAN, MAKH, THOIGIAN, TONGTIEN, GIOBD, GIOKT) VALUES ('"+b.NHANVIEN.MANHANVIEN+"',"+b.BAN.MABAN+","+b.KHACHHANG.MAKH+",'"+b.ThoiGian+"','"+b.TONGTIEN+"','" + bd + "','" + kt + "')";
            provider.executeNonQuery(sql);
        }
    }
}

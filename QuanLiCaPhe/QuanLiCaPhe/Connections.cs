using System.Threading.Tasks;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace QuanLiCaPhe
{
    class Connections
    {
          #region Thuộc tính
        private SqlConnection _myConn;
        public SqlConnection MyConn
        {
            get { return _myConn; }
            set { _myConn = value; }
        }
        #endregion

        #region Phương Thức
        //Hàm Khởi Tạo cho Kết Nối DB
        public void Connection()
        {
            MyConn = new SqlConnection();
            KetNoiQuyenHeThong(MyConn);
          
        }

        public static string connectStr = @"Data Source=DESKTOP-0SJCJUI;Initial Catalog=Data;Integrated Security=True";

        //Kết Nối Quyền Hệ Thống
        public void KetNoiQuyenHeThong(SqlConnection _myConn)
        {
            try
            {
                if (_myConn.State == System.Data.ConnectionState.Open)
                    _myConn.Close();
                _myConn.ConnectionString = @"Data Source=DESKTOP-0SJCJUI;Initial Catalog=Data;Integrated Security=True";
                _myConn.Open();
            }
            catch
            {
                MessageBox.Show("Lỗi: KHÔNG THỂ KẾT NỐI VỚI DỮ LIỆU", "Thông Báo");
            }
        }

       

        //Hàm Lấy DataTable theo đối tượng string SQL
        public DataTable GetDataTable_SQL(string sql)
        {
            DataTable mydataTable = new DataTable();
            if (_myConn.State == ConnectionState.Open)
            {
                SqlDataAdapter mySQlDataAdap = new SqlDataAdapter(sql, _myConn);
                mySQlDataAdap.Fill(mydataTable);
            }
            return mydataTable;
        }
        #endregion
        
    }
}

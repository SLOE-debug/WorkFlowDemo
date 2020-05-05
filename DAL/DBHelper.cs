using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DAL
{
    public static class DBHelper
    {
        private static SqlConnection _Con;
        public static SqlConnection Con
        {
            get
            {
                _Con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
                _Con.Open();
                return _Con;
            }
        }

        public static SqlCommand _Cmd
        {
            get { return Con.CreateCommand(); }
        }

        public static int Update(string SqlStr)
        {
            using (SqlCommand Cmd = _Cmd)
            {
                Cmd.CommandText = SqlStr;
                return Cmd.ExecuteNonQuery();
            }
        }

        public static T GetOneVlaue<T>(string SqlStr)
        {
            using (SqlCommand Cmd = _Cmd)
            {
                Cmd.CommandText = SqlStr;
                return (T)Convert.ChangeType(Cmd.ExecuteScalar(), typeof(T));
            }
        }

        public static List<T> GetList<T>(string SqlStr)
            where T : new()
        {
            Type Ttype = typeof(T);
            SqlDataReader sdr;
            using (SqlCommand Cmd = _Cmd)
            {
                Cmd.CommandText = SqlStr;
                sdr = Cmd.ExecuteReader();
            }
            List<T> ls = new List<T>();
            while (sdr.Read())
            {
                T Tobject = new T();
                foreach (var item in Ttype.GetProperties())
                {
                    if (!item.PropertyType.Name.Contains("List"))
                    {
                        item.SetValue(Tobject, sdr[item.Name].ToString() == "" ? default : sdr[item.Name]);
                    }
                }
                ls.Add(Tobject);
            }
            sdr.Close();
            return ls;
        }

        public static T GetEntity<T>(string SqlStr) where T : new()
        {
            SqlDataReader sdr;
            using (SqlCommand Cmd = _Cmd)
            {
                Cmd.CommandText = SqlStr;
                sdr = Cmd.ExecuteReader();
            }
            T Tobject = new T();
            if (sdr.Read())
            {
                foreach (var item in typeof(T).GetProperties())
                {
                    item.SetValue(Tobject, sdr[item.Name].ToString() == "" ? default : sdr[item.Name]);
                }
            }
            else
            {
                Tobject = default;
            }
            sdr.Close();
            return Tobject;
        }
    }
}

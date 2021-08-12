using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Csharp_Crud.Controllers
{
   namespace Controllers { 
    class UserController : Database
    {

        //properties
        public string name { set; get; }
        public string age { set; get; }
        public string hobby { set; get; }
        public string id { set; get; }

            //Read data
            public DataTable dt = new DataTable();
            private DataSet ds = new DataSet();

        public void create_data()
        {

            conn.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "INSERT INTO users (name, age, hobby) VALUES(@name, @age, @hobby)";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                cmd.Parameters.Add("@age", MySqlDbType.VarChar).Value = age;
                cmd.Parameters.Add("@hobby", MySqlDbType.VarChar).Value = hobby;
                cmd.ExecuteNonQuery();
                conn.Close();
                //cmd.Parameters.Clear();
            }
        }

            //Update
            public void update_data()
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = "UPDATE users SET name = @name, age=@age, hobby=@hobby WHERE id=@id";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conn;
                    cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                    cmd.Parameters.Add("@age", MySqlDbType.VarChar).Value = age;
                    cmd.Parameters.Add("@hobby", MySqlDbType.VarChar).Value = hobby;
                    cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    //cmd.Parameters.Clear();
                }
            }

            //Delete
            public void delete_data()
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = "DELETE FROM users WHERE id=@id";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conn;
 
                    cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    //cmd.Parameters.Clear();
                }
            }

            //READ DATA
            public void read_data()
            {
                dt.Clear();
                string sql = "SELECT * FROM users";
               MySqlDataAdapter dta = new MySqlDataAdapter(sql, conn);
                dta.Fill(ds);
                dt = ds.Tables[0];
            }

            //SEARCH USER 
            public void search_data()
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = "SELECT * FROM users WHERE id=@id";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conn;

                    cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                    rd = cmd.ExecuteReader();
                    if (rd.Read() == true)
                    {

                        id = rd.GetString("id");
                        name = rd.GetString("name");
                        age = rd.GetString("age");
                        hobby = rd.GetString("hobby");
                        conn.Close();
                    } else
                    {
                        conn.Close();
                        
                    }
                    }
                    
                    //cmd.Parameters.Clear();
                }
            }

        }
        }


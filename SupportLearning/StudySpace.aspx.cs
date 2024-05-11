using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SupportLearning
{
    public partial class StudySpace : System.Web.UI.Page
    {
        static string connectionString = @"Data Source = MINH\SQLEXPRESS; Initial Catalog=CAPSTONE2; integrated security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string query = "SELECT [DocumentID_Doc],[Name_Doc],[Code_User] FROM [dbo].[Doc]";
                
                using(SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        if(reader.HasRows)
                        {
                            while (reader.Read())
                            {

                                lb_codeuser.Text += reader["DocumentID_Doc"].ToString() + "<br />";
                                lb_documentID.Text += reader["Name_Doc"].ToString() + "<br />";
                                lb_namedoc.Text += reader["Code_User"].ToString() + "<br />";
                            }
                        }
                        else
                        {
                            lb_codeuser.Text = "No data";
                            lb_documentID.Text = "No data";
                            lb_namedoc.Text = "No data";
                        }
                        reader.Close();
                    }
                }
            }
        }



    }
}
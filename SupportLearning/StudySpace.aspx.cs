using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SupportLearning.MessageBox;
using SupportLearning.ZOOM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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
                string query = @"Select P.PostDocID,D.Name_Doc, U.Name_UserInfo, P.TimePost_Doc, P.Description_Doc, P.File_Doc, (Select Count(*) From Like_Post L Where L.PostDocID = P.PostDocID) AS TotalLike
                                    From SL_UserInfo U, Post_Doc P, Doc D
                                    Where U.CMND_UserInfo = P.CMND_UserInfo AND
                                          U.Code_User = D.Code_User AND
                                          D.File_Doc = P.File_Doc";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);

                        DataList1.DataSource = dataTable;
                        DataList1.DataBind();

                        reader.Close();
                    }
                }
            }
        }

        protected void bt_ListFriends_Click(object sender, EventArgs e)
        {
            // Implement your logic here
        }

        protected async void bt_MeetingRoom_Click(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {
                // Set the ZEGOCLOUD API key
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("minh", "04AAAAAGZRliIAEDNpcjZmYXl4MG5weWxkYXkAoKzuFQdHkGJLpHTSXZSh9yvLBaDfCb+szuyhxDnZ6rdvXl9dUvsFFk5LutUudksGqG/gA272Zmgm64u+K+SZmNBkLbdgeH+eHwjHpXF/Odpwujmd4zfDpfU1lZKyC7zBj5wroJmrXFcn82nnoB/Qk8BCAhlrmzlyAVgoVfjNPUAfdl6lbNczZz17MY3shWLdiZR/NNt6WNSwopkITvc2Cqk=\r\n");

                // Set the ZEGOCLOUD API endpoint
                client.BaseAddress = new Uri("https://api.zegocloud.com");

                // Create a new meeting room
                var formData = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("displayName", "Your Meeting Room")
                };

                var content = new FormUrlEncodedContent(formData);

                var response = await client.PostAsync("/v2/CreateMeetingRoom", content);

                if (response.IsSuccessStatusCode)
                {
                    var meetingRoomUrl = response.Headers.Location.ToString();
                    Response.Redirect(meetingRoomUrl);
                }
                else
                {
                    // Handle the error
                }
            }

        }
    }
}



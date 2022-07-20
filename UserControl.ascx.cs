using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET_Web_Forms
{
    public partial class UserControl : System.Web.UI.UserControl
    {
        SqlConnection databaseConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SkillBuilderDbContext"].ConnectionString);

        public void Page_Load(object sender, EventArgs e)
        {
         
        }
        public void submitButton_Click(Object sender, EventArgs e)
        {
            string query = "SELECT [Id], [TenantId], [FirstName], [LastName], [Email] FROM [SkillBuilderFeature1].[dbo].[Users]";
            SqlCommand queryCommand = new SqlCommand(query, databaseConnection);

            databaseConnection.Open();

            SqlDataReader resultsReader = queryCommand.ExecuteReader();
            GridView1.DataSource = resultsReader;
            GridView1.DataBind();
            databaseConnection.Close();
        }
    }
}
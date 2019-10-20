using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
//using CsvHelper;

namespace BLaST_3
{

    public partial class Default : System.Web.UI.Page
    {
        string path = @"D:\SpecialEd.csv";
        SqlConnection dbConn = new SqlConnection(ConfigurationManager.ConnectionStrings["BLAST"].ConnectionString);

        public Encoding UTF8 { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {


            if (fundCategory.SelectedValue != "" || txtAUN.Text != "" || dateSchoolYear.Text != "" || txtID.Text != "" || dateReporting.Text != "")
            {
                // Validate user input
                dbConn.Open();

                SqlCommand insertCommand = dbConn.CreateCommand();
                insertCommand.CommandText = "INSERT INTO specialEdAct16 (AUN, schoolYearDate, secureID, reportingDate, collection, measureType, category) VALUES ('" + txtAUN.Text + "', '" + Convert.ToDateTime(dateSchoolYear.Text) + "', '" + txtID.Text + "', '" + Convert.ToDateTime(dateReporting.Text) + "', '" + Act16.Text + "', '" + MeasureType.Text + "', '" + fundCategory.SelectedValue + "')";
                insertCommand.ExecuteNonQuery();

                dbConn.Close();                

                txtAUN.Text = "";
                dateSchoolYear.Text = "";
                txtID.Text = "";
                dateReporting.Text = "";
                fundCategory.SelectedValue = "";

                litMessage.Text = "Woohoo ... it was submitted!";
            }
            else
            {
                litMessage.Text = "Please fill out the form completely before submitting";
            }
        }
        protected void btnExport_Click(object sender, EventArgs e)
        {
            string delim = ", ";
            string cs = ConfigurationManager.ConnectionStrings["BLAST"].ConnectionString;
            StringBuilder sb = new StringBuilder();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [specialEdAct16];", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                ds.Tables[0].TableName = "specialEdAct16";

                foreach (DataRow depratmentDR in ds.Tables["specialEdAct16"].Rows)
                {
                    int departmentId = Convert.ToInt32(depratmentDR["ID"]);
                    sb.Append(departmentId.ToString() + delim);
                    sb.Append(depratmentDR["AUN"].ToString() + delim);
                    sb.Append(depratmentDR["schoolYearDate"].ToString() + delim);
                    sb.Append(depratmentDR["secureID"].ToString() + delim);
                    sb.Append(depratmentDR["reportingDate"].ToString() + delim);
                    sb.Append(depratmentDR["collection"].ToString() + delim);
                    sb.Append(depratmentDR["measureType"].ToString() + delim);
                    sb.Append(depratmentDR["category"].ToString() + delim);
                    sb.Append("\r\n");
                    
                }
            }

            StreamWriter file = new StreamWriter(@"D:\SpecialEdCSV.txt");
            file.WriteLine(sb.ToString());
            file.Close();

            litMessage.Text = "File Exported to your Data Drive (D:)";
            

        }
    }
}
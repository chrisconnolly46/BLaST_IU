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
//using CsvHelper;

namespace BLaST_3
{
    public partial class Default : System.Web.UI.Page
    {

        SqlConnection dbConn = new SqlConnection(ConfigurationManager.ConnectionStrings["BLAST"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {


            if (fundCategory.SelectedValue != "" || txtAUN.Text != "" || dateSchoolYear.Text != "" || txtID.Text != "" || dateReporting.Text != "") {
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
                // Insert into DB
        }
            else
            {
                litMessage.Text = "Please fill out the form completely before submitting";
            }
        }
        protected void btnExport_Click(object sender, EventArgs e)
        {
            dbConn.Open();

            SqlCommand selectCommand = dbConn.CreateCommand();
            selectCommand.CommandText = "SELECT * FROM specialEdAct16";
            selectCommand.ExecuteReader();



            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"D:\SpecialEdCSV.txt"))
                {
                    file.WriteLine(txtAUN.Text + "," + dateSchoolYear.Text + "," + txtID.Text + "," + dateReporting.Text + "," + Act16.Text + "," + MeasureType.Text + "," + fundCategory.SelectedValue);




                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Whoops...csv file writer messed up! ", ex);
            }




            // create and or open csv file

            // loop through table

            // for each record in table write to csv file

            // close csv file


            dbConn.Close();

        }



    }

   

 

}
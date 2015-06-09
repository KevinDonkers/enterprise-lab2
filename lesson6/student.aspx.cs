using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//reference models
using lesson6.Models;
using System.Web.ModelBinding;

namespace lesson6
{
    public partial class student : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //check for the id in url
            if (!IsPostBack)
            {
                if (Request.QueryString.Keys.Count > 0)
                {
                    //we have a parameter populate the form
                    GetStudents();
                }
            }
        }

        protected void GetStudents()
        {
            //connect
            using (DefaultConnection conn = new DefaultConnection())
            {
                //get the student id
                Int32 StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);

                //get student info
                var s = (from stu in conn.Students
                         where stu.StudentID == StudentID
                         select stu).FirstOrDefault();

                //populate the form
                txtFirstName.Text = s.FirstMidName;
                txtLastName.Text = s.LastName;
                txtEnrollDate.Text = s.EnrollmentDate.ToString();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //connect
            using (DefaultConnection conn = new DefaultConnection())
            {
                //instantiate a new student object in memory
                Student s = new Student();

                //decide if updating or adding, then save
                if (Request.QueryString.Count > 0)
                {
                    Int32 StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);

                    s = (from stu in conn.Students
                         where stu.StudentID == StudentID
                         select stu).FirstOrDefault();
                }

                //fill the properties of our object from the form inputs
                s.FirstMidName = txtFirstName.Text;
                s.LastName = txtLastName.Text;
                s.EnrollmentDate = Convert.ToDateTime(txtEnrollDate.Text);

                if (Request.QueryString.Count == 0)
                {
                    conn.Students.Add(s);
                }
                conn.SaveChanges();

                //redirect to updated departments page
                Response.Redirect("students.aspx");
            }
        }
    }
}
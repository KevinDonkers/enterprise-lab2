using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//reference our entity framework models
using lesson6.Models;
using System.Web.ModelBinding;

namespace lesson6
{
    public partial class students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //fill the grid
            if (!IsPostBack)
            {
                GetStudents();
            }
        }

        protected void GetStudents()
        {
            //connect using our connection string from web.config and EF context class
            using (DefaultConnection conn = new DefaultConnection())
            {

                //use link to query the Departments model
                var students = from s in conn.Students
                           select s;

                //bind the query result to the gridview
                grdStudents.DataSource = students.ToList();
                grdStudents.DataBind();
            }
        }

        protected void grdStudents_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //connect
            using (DefaultConnection conn = new DefaultConnection())
            {
                //get the selected department id
                Int32 StudentID = Convert.ToInt32(grdStudents.DataKeys[e.RowIndex].Values["StudentID"]);

                var s = (from stu in conn.Students
                         where stu.StudentID == StudentID
                         select stu).FirstOrDefault();

                //delete
                conn.Students.Remove(s);
                conn.SaveChanges();

                //update the grid
                GetStudents();

            }
        }

        protected void grdStudents_Sorting(object sender, GridViewSortEventArgs e)
        {

            //connect
            using (DefaultConnection conn = new DefaultConnection())
            {

                if (e.SortDirection == SortDirection.Ascending)
                {
                    e.SortDirection = SortDirection.Descending;

                    var s = from stu in conn.Students
                             select stu;

                    s = s.OrderByDescending(x => e.SortExpression);

                    grdStudents.DataSource = s.ToList();
                }
                else
                {
                    e.SortDirection = SortDirection.Ascending;

                    var s = from stu in conn.Students
                             select stu;

                    s = s.OrderBy(x => e.SortExpression);

                    grdStudents.DataSource = s.ToList();
                }

                //bind the query result to the gridview
                grdStudents.DataBind();

            }

        }
    }
}
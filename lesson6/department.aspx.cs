﻿using System;
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
    public partial class department : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //check for the id in url
            if(!IsPostBack)
            {
                if(Request.QueryString.Keys.Count > 0)
                {
                    //we have a parameter populate the form
                    GetDepartment();
                }
            }

        }

        protected void GetDepartment()
        {
            //connect
            using (DefaultConnection conn = new DefaultConnection())
            {
                //get the department id
                Int32 DepartmentID = Convert.ToInt32(Request.QueryString["DepartmentID"]);

                //get department info
                var d = (from dep in conn.Departments
                         where dep.DepartmentID == DepartmentID
                         select dep).FirstOrDefault();
                
                //populate the form
                txtName.Text = d.Name;
                txtBudget.Text = d.Budget.ToString();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //connect
            using (DefaultConnection conn = new DefaultConnection())
            {
                //instantiate a new deparment object in memory
                Department d = new Department();

                //decide if updating or adding, then save
                if (Request.QueryString.Count > 0)
                {
                    Int32 DepartmentID = Convert.ToInt32(Request.QueryString["DepartmentID"]);

                    d = (from dep in conn.Departments
                         where dep.DepartmentID == DepartmentID
                         select dep).FirstOrDefault();
                }

                //fill the properties of our object from the form inputs
                d.Name = txtName.Text;
                d.Budget = Convert.ToDecimal(txtBudget.Text);

                if (Request.QueryString.Count == 0)
                {
                    conn.Departments.Add(d);
                }
                conn.SaveChanges();

                //redirect to updated departments page
                Response.Redirect("departments.aspx");
            }
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnxamePhobos.UI.adm
{
    public partial class DefaultAdm : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //lblSession.Font.Size = 14;

            //if (Session["Usuario"] == null)
            //{
            //    Response.Redirect("~/Login.aspx");
            //}
            //lblSession.Text = $"Seja Bem Chegado ! {Session["Usuario"].ToString().ToUpper()} " +
            //    $"a Enxame Phobos Anomaly!! Sua sessão iniciou às {DateTime.Now.ToString("t")}";

            //Response.AppendHeader("Refresh", String.Concat((Session.Timeout * 60), ";URL=../Login.aspx"));
        }
    }
}
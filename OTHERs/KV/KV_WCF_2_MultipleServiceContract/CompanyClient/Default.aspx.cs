using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void public_Click(object sender, EventArgs e)
    {
        CompanyService.CompanyPublicServiceClient client = new CompanyService.CompanyPublicServiceClient("BasicHttpBinding_ICompanyPublicService");
        var message=client.GetPublicOpertaion();
        myLabel.Text = message;
    }

    protected void private_Click(object sender, EventArgs e)
    {
        CompanyService.CompanyPrivateServiceClient client = new CompanyService.CompanyPrivateServiceClient("NetTcpBinding_ICompanyPrivateService");
        var message=client.GetPrivateInformation();
        myLabel1.Text = message;
    }
}
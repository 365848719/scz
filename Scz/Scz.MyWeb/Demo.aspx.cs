using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Scz.MyWeb
{
    public partial class Demo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMsg.Text = "this is a demo !";
                lblDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff");

                var list = new List<Student>
                {
                    new Student{ Id = "1",Name = "scz",BirthDay = DateTime.Parse("2019-01-12 12:20:00")},
                    new Student{ Id = "1",Name = "scz",BirthDay = DateTime.Parse("2019-05-09 12:20:00")},
                    new Student{ Id = "1",Name = "scz",BirthDay = DateTime.Parse("2010-10-12 12:20:00")}
                };

                lblMsg.Text = JsonConvert.SerializeObject(list);
            }
        }
    }

    public class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;
using System.Net;
using System.Net.Mail;

namespace VistaLM
{
    public partial class correos : Form
    {
        public correos()
        {
            InitializeComponent();
        }
        public string path;

        Reportes rep = new Reportes();
        private void button1_Click(object sender, EventArgs e)
        {
            MailMessage mmsg = new MailMessage();
            mmsg.To.Add(txtpass.Text);
            mmsg.From = new MailAddress("losmonosbodega@gmail.com");
            mmsg.Subject = "Consolidado diario";
            mmsg.Body = "Consolidado " + DateTime.Now.ToLongDateString();
            Attachment archivo = new Attachment(path);
            mmsg.Attachments.Add(archivo);
            SmtpClient client = new SmtpClient();
            client.Credentials = new NetworkCredential("losmonosbodega@gmail.com", "losmonos2018");
            client.Port = 587;
            client.EnableSsl = true;
            client.Host = "smtp.gmail.com";

            client.Send(mmsg);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

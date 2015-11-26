using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegTools
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        
    }
    public interface RegDll
    {
        private string toolName;
        private string toolAuthor;
        private string toolVer;
        
        //private delegate string  GetImgCode(byte[] img);
        //private GetImgCode getImgCode;
        //private delegate void DealLogs(string);
       // private DealLogs dealLogs;
        
        private string proxyIp=string.Empty;
        private string user=string.Empty;
        private string pass=string.Empty;
        
        public void Reg();
    }
}

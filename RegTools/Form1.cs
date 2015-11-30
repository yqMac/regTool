using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegTools
{
    public partial class Form1 : Form
    {


        #region 变量

        //公用Random对象
        Random ran = new Random();

        #region 账户设置
        //账户设置
        /// <summary>
        /// 名字有前缀
        /// </summary>
        private bool userNameHeadch;
        /// <summary>
        /// 名字有后缀
        /// </summary>
        private bool userNameEndch;
        /// <summary>
        /// 用户名生成类型，1，导入，2，规则生成
        /// </summary>
        private int userNameType;
        /// <summary>
        /// 前缀
        /// </summary>
        private string userNameHead;
        /// <summary>
        /// 后缀
        /// </summary>
        private string userNameEnd;
        /// <summary>
        /// 名字长度下限
        /// </summary>
        private int userNameLH;
        /// <summary>
        /// 名字长度上限
        /// </summary>
        private int userNameLE;
        private int userNameLenth
        {
            get
            {
                return ran.Next(userNameLH, userNameLE + 1);
            }
        }




        List<string> UserNameFromImported = new List<string>();

        private int userNameformImportedIndex;
        #endregion

        #region  密码生成设置
        /// <summary>
        /// 1、固定密码,2规则生成密码
        /// </summary>
        private int userPassType;
        private bool userPassHeadch;
        private bool userPassEndch;
        private string userPassHead;
        private string userPassEnd;
        private int userPassLH;
        private int userPassLE;
        private int userPassLenth
        {
            get
            {
                return ran.Next(userPassLH, userPassLE + 1);
            }
        }
        private string samePass;
        #endregion

        #region  验证码识别设置
        /// <summary>
        /// 1、平台打码2、手动打码
        /// </summary>
        private int vCodeType;
        /// <summary>
        /// 用于手动输入验证码的等待问题
        /// </summary>
        private bool waitforbtn = false;

        private string tmpCode = "";


        #endregion 验证码

        #region proxyip

        /// <summary>
        /// 1、宽带，2、代理ip池、3、不处理
        /// </summary>
        int proxyType = 3;

        List<string> list_proxyips = new List<string>();

        private int proxyipIndex;
        #endregion proxyip
        
        
        
        #endregion 变量

        #region 方法

        /// <summary>
        /// 根据规则创建用户名
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            //导入帐号
            if (userNameType == 1)
            {
                if(userNameformImportedIndex <UserNameFromImported .Count)
                {
                    return UserNameFromImported[userNameformImportedIndex ++];
                }else
                {
                    return "";
                }
            }

            //规则随机帐号：
            int legth = userNameLenth;
            string name = string.Empty;
            string a = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string b = "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ_";
            string s1 = "", s2 = "", s3 = "";
            //前缀文本
            if (userNameHeadch &&!string.IsNullOrEmpty(userNameHead))
            {
                legth = legth - userNameHead.Length;
                s1 = userNameHead;
            }         
            //后缀文本 
            if(userNameEndch && !string.IsNullOrEmpty (userNameEnd))
            {
                legth = legth - userNameEnd .Length;
                s3 = userNameEnd;
            }
            s2 += a[ran.Next(a.Length)];
            //随机文本
            for (int i = 0; i < legth-1; i++)
            {
                s2 += b[ran.Next(b.Length)];
            }
            //合成
            name +=s1 +s2 +s3 ;
            return name;
        }

        public string GetPass()
        {
            //固定密码
            if (userPassType == 1)
            {
                return samePass;
            }
            //规则生成密码
            int legth = userPassLenth;
            string pass = string.Empty;
            string a = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string b = "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ_";
            string s1 = "", s2 = "", s3 = "";

            //前缀
            if (userPassHeadch && !string.IsNullOrEmpty(userPassHead))
            {
                legth = legth - userPassHead.Length;
                s1 = userPassHead;

            }
            //后缀
            if (userPassEndch && !string.IsNullOrEmpty(userPassEnd))
            {
                legth = legth - userPassEnd.Length;
                s3 = userPassEnd;
            }
            //随机
            s2 += a[ran.Next(a.Length)];
            for (int i = 0; i < legth-1; i++)
            {
                s2 += b[ran.Next(b.Length)];
            }
            //合成
            pass += s1 + s2 + s3;
            return pass;
        }

        public void Tsleep(int time)
        {
            Thread t = new Thread(o => Thread.Sleep(time));
            t.Start();
            while (t.IsAlive)
            {
                Thread.Sleep(1);
                Application.DoEvents();
            }
        }
        private string GetImgCode(byte [] bytes)
        {
            StringBuilder strb = new StringBuilder();
            try
            {
                //手动输入验证码--单线程
                if(vCodeType == 2)
                {
                    MemoryStream ms = new MemoryStream(bytes );
                    Image image = System.Drawing.Image.FromStream(ms);
                    picBox_Vcode.Image = image;

                    waitforbtn = true;
                    while (waitforbtn ||string.IsNullOrEmpty (tmpCode ))
                    {
                        Tsleep(10);
                    }
                    string code = tmpCode;
                    tmpCode = string.Empty;
                    return code;

                }
            }
            catch (Exception ex)
            {
            }
            return strb.ToString();
        }


        public void Reg()
        {
            string status = string.Empty;

            Email163 email = new Email163();
            email.getImgCode = GetImgCode;
            bool s=email.Login163("yqmacyuqiang","aa13655312932bb");
            //email.setProxy("121.69.24.22:8118");//121.69.24.22:8118
            if (!email .RegUserPass (GetName (),GetPass(),ref status ))
            {
                MessageBox.Show(status );
            }
            else
            {
                MessageBox.Show("成功");
            }
        }


        #endregion 方法

        #region 事件

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            switch (btn.Tag.ToString())
            {
                case "submitVCode":
                    if(txt_Vcode .Text != "")
                    {
                        tmpCode = txt_Vcode.Text.Trim();                  
                        waitforbtn = false;
                        txt_Vcode.Text = "";
                        picBox_Vcode.Image = null;
                    }
                    break;
                case "Start":
                    readSet();
                     Reg();
                    break;
                default:
                    break;
            }
        }

        #region 配置改变触发事件

        #endregion 配置改变触发事件

        #endregion 事件

        public void readSet()
        {
            userNameLH = (int)num_user_h.Value;
            userNameLE = (int)num_user_end.Value;
            userNameHead = txt_user_head.Text.Trim();
            userNameEnd = txt_user_end.Text.Trim();

           
            userNameType = 2;
            
            userNameHeadch = checkBox_userheadch.Checked;
            userNameEndch = checkBox_userendch.Checked;

 
                userPassType = 2;
  

            if (rab_Vcode_p.Checked)
            {
                vCodeType = 1;
            }
            else
            {
                vCodeType = 2;
            }

            if (rab_IP_k.Checked)
            {
                proxyType = 1;
            }
            else if (rab_IP_proxy.Checked)
            {
                proxyType = 2;
            }
            else
            {
                proxyType = 3;
            }

        }

        private void rab_CheckedChanged(object sender, EventArgs e)
        {
            return;
            userNameLH = (int)num_user_h.Value;
            userNameLE = (int)num_user_end.Value;
            userNameHead = txt_user_head.Text.Trim();
            userNameEnd = txt_user_end.Text.Trim();





            RadioButton rb = (RadioButton)sender;
            switch (rb.Tag.ToString ())
            {
                case "User_Import":
    
                        userNameLH =(int ) num_user_h.Value;
                        userNameLE = (int)num_user_end.Value;
                        userNameHead = txt_user_head.Text.Trim();
                        userNameEnd = txt_user_end.Text.Trim();

                    
                    break;
                case "Pass_Same":

                    break;
                case "VCode_Flat":

                    break;
                case "IP_PPPOE":

                    break;
                case "IP_Proxy":
                    break;
                default:
                    break;
            }
        }



        private void txt_Vcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode ==Keys.Enter)
            {
                btn_Click(btn_submitVcode ,null );
            }
        }

        private void checkBox_StrVcodeImg_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox_StrVcodeImg .Checked)
            {
                picBox_Vcode.SizeMode = PictureBoxSizeMode.Zoom  ;
            }
            else
            {
                picBox_Vcode.SizeMode = PictureBoxSizeMode.CenterImage;
            }
            picBox_Vcode.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}

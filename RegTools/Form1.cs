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
        #endregion 

        //验证码识别设置
        /// <summary>
        /// 1、平台打码2、手动打码
        /// </summary>
        private int vCodeType;


        #endregion 变量

        #region 方法

        /// <summary>
        /// 根据规则创建用户名
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            int legth = userNameLenth;
            string name = string.Empty;
            string b = "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ_";


            if (userNameHeadch &&!string.IsNullOrEmpty(userNameHead))
            {
                legth = legth - userNameHead.Length;
                name += userNameHead;

            }
           
            if(userNameEndch && !string.IsNullOrEmpty (userNameEnd))
            {
                legth = legth - userNameEnd .Length;
                for (int i = 0; i < legth ; i++)
                {
                    name += b[ran.Next(b.Length)];
                }
                name += userNameEnd;
                
            }
            else
            {
                for (int i = 0; i < legth; i++)
                {
                    name += b[ran.Next(b.Length)];
                }
            }
            return name;
        }

        public string GetPass()
        {
            int legth = userPassLenth ;
            string pass = string.Empty;
            string b = "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ_";


            if (userPassHeadch && !string.IsNullOrEmpty(userPassHead))
            {
                legth = legth - userPassHead.Length;
                pass += userPassHead;

            }

            if (userPassEndch && !string.IsNullOrEmpty(userPassEnd))
            {
                legth = legth - userPassEnd.Length;
                for (int i = 0; i < legth; i++)
                {
                    pass += b[ran.Next(b.Length)];
                }
                pass += userPassEnd;

            }
            else
            {
                for (int i = 0; i < legth; i++)
                {
                    pass += b[ran.Next(b.Length)];
                }
            }
            return pass;
        }




        public void Reg()
        {

        }


        #endregion 方法

        #region 事件

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {

        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {

        }

        #region 配置改变触发事件

        #endregion 配置改变触发事件

        #endregion 事件

        private void rab_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            switch (rb.Tag.ToString ())
            {
                case "User_Import":

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
    }
}

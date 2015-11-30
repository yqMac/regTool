using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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



        Dictionary<string, string> dic_UserPwd = new Dictionary<string, string>();

        #endregion 变量

        #region 方法

      
        /// <summary>
        /// 验证码识别ｆｏｒ　ｂｙｔｅ[]
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
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
            //bool s=email.Login163("yqmacyuqiang","aa13655312932bb");
            //email.setProxy("121.69.24.22:8118");//121.69.24.22:8118
            string name = CreateName();
            string pwd = CreatePwd();
            if (!email .RegUserPass (name, name,ref status ))
            {
                bool s = email.Login163(name , pwd );
                MessageBox.Show((s?"登录成功":"登录失败")+"\n"+status );
            }
            else
            {
                bool s = email.Login163(name, pwd);
                MessageBox.Show((s ? "登录成功" : "登录失败") + "\n" + status);
            }
        }


        #endregion 方法

        /// <summary>
        /// 根据规则创建字符串
        /// </summary>
        /// <returns></returns>
        public string getRandomString(int lenth)
        {
            if (lenth <= 0)
            {
                return "";
            }
            string name = string.Empty;
            string a = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string b = "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ_";

            name += a[ran.Next(a.Length)];
            //随机文本
            for (int i = 0; i < lenth - 1; i++)
            {
                name += b[ran.Next(b.Length)];
            }
            //合成
            return name;
        }

        /// <summary>
        /// 不卡界面的ｓｌｅeｐ
        /// </summary>
        /// <param name="time"></param>
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


        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 规则生成用户名
        /// </summary>
        /// <returns></returns>
        public string CreateName()
        {
            //生成帐号密码  
            int nameLength = ran.Next((int)num_user_h.Value, (int)num_user_end.Value + 1);
            string nameHead = checkBox_userheadch.Checked ? txt_user_head.Text.Trim() : "";
            string nameEnd = checkBox_userendch.Checked ? txt_user_end.Text.Trim() : "";
            string name = nameHead + getRandomString(nameLength - nameHead.Length - nameEnd.Length) + nameEnd;
            return name;
        }

        /// <summary>
        /// 规则生成密码
        /// </summary>
        /// <returns></returns>
        public string CreatePwd()
        {
            bool pwdsame = rab_samePwd.Checked;
            string spwd = txtBox_pwd_same.Text.Trim();
            int pwdLength = ran.Next((int)num_pwd_head.Value, (int)num_pwd_end.Value + 1);
            string pwdHead = checkBox_pwd_head.Checked ? txtBox_pwd_head.Text.Trim() : "";
            string pwdEnd = checkBox_pwd_end.Checked ? txtBox_pwd_end.Text.Trim() : "";
            string pwd = "";
            if (pwdsame)
            {
                pwd = spwd;
            }
            else
            {
                pwd = pwdHead + getRandomString(pwdLength - pwdHead.Length - pwdEnd.Length) + pwdEnd;
            }
            return pwd;
        }

        /// <summary>
        /// 添加帐号密码到列表
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        public void adduserpwdtolist(string name ,string pwd)
        {
            if (!dic_UserPwd.ContainsKey(name ))
            {
                dic_UserPwd.Add(name ,pwd );
                ListViewItem lvi = new ListViewItem();
                lvi.Text = listView_UserPass.Items.Count.ToString();
                lvi.SubItems.Add(name);
                lvi.SubItems.Add(pwd);
                listView_UserPass.Items.Add(lvi);
            }  
        }

        /// <summary>
        /// 按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Click(object sender, EventArgs e)
        {
            ///判断是哪个按钮
            Button btn = (Button)sender;
            switch (btn.Tag.ToString())
            {
                case "submitVCode":
                    if (txt_Vcode.Text != "")
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
                case "btn_Stop":
                    //readSet();
                    //Reg();
                    break;
                case "btn_autoCreateUsers":
                    int num_toCreate = 0;
                    int.TryParse(txtBox_CreateUserNum.Text.Trim(), out num_toCreate);
                    if (num_toCreate > 100)
                    {
                        num_toCreate = 100;
                        txtBox_CreateUserNum.Text = num_toCreate.ToString();
                    }
                    num_toCreate = num_toCreate <= 0 ? 1 : num_toCreate;
                    while (num_toCreate-- > 0)
                    {
                        adduserpwdtolist(CreateName(), CreatePwd());
                    }

                    break;
                case "btn_user_Clear":
                    listView_UserPass.Items.Clear();
                    break;
                case "btn_AddGiven":
                    string givenname = txtBox_GivenUser.Text.Trim();
                    string givenpwd = txtBox_GivenPass.Text.Trim();
                    givenname = string.IsNullOrEmpty(givenname) ? CreateName() : givenname;
                    givenpwd = string.IsNullOrEmpty(givenpwd) ? CreatePwd () : givenpwd;
                    adduserpwdtolist(givenname ,givenpwd );
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 读入帐号数据
        /// </summary>
        /// <param name="file"></param>
        private void importUsers(string file)
        {
            if (File.Exists(file))
            {
                string content = string.Empty;
                using (StreamReader sr = new StreamReader(file))
                {
                    content = sr.ReadToEnd();//一次性读入内存
                    sr.Dispose();
                }
                if (!string.IsNullOrEmpty(content))
                {
                    string user = "";
                    string pass = "";
                    Regex reg = new Regex("(.*?)----(.*?)(----(.*?))?\\r\\n");
                    MatchCollection mc = reg.Matches(content);
                    if (mc.Count > 0)
                    {
                        foreach (Match item in mc)
                        {
                            user = item.Groups[1].Value;
                            pass = item.Groups[2].Value;
                            adduserpwdtolist(user, pass);
                        }
                    }

                }

            }

        }


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

        /// <summary>
        /// RadioButton checked 改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// textbox　keydown事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode !=Keys.Enter)
            {
                return;
            }

            TextBox tbox = (TextBox)sender;
            switch (tbox .Tag .ToString())
            {
                case "txt_Vcode":
                    btn_Click(btn_submitVcode, null);
                    break;
                default:
                    break;
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

        /// <summary>
        /// 拖放进入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView_DragDrop(object sender, DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            int i;
            for (i = 0; i < s.Length; i++)
            {
                if (s[i].Trim() != "")
                {
                    importUsers(s[i]);
                }
            }
        }

        /// <summary>
        /// 拖放进入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }
    }
}

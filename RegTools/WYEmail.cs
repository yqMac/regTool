using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using HttpCodeLib;

namespace RegTools
{
    class Email163
    {
        #region 变量

        HttpHelpers helper = null;
        HttpItems items = null;
        HttpResults hr = null;
        String Cookies = string.Empty;
        String Proxy = string.Empty;

        public delegate string GetImgCode(byte[] bytes);
        public GetImgCode getImgCode;
        #endregion 变量

        string winx1_1;

        #region 构造
        public Email163()
        {

            helper = new HttpHelpers();
            items = new HttpItems();

        }

        #endregion 构造


        #region 功能

        /// <summary>
        /// 检查某用户名可否被注册
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        private bool CheckUserName(string username)
        {
            try
            {
                string url = String.Format("http://reg.email.163.com/unireg/call.do?cmd=urs.checkName");
                string postdata = "name="+username ;
                items = new HttpItems()
                {
                    URL = url,
                    Cookie = Cookies,
                    Method = "post",
                    Postdata =postdata 
                };
                //items.Container = cc;
                // items.ProxyIp = proxy ;
                hr = helper.GetHtml(items,ref Cookies);
                //Cookies +=  HttpHelpers.GetSmallCookie(hr.Cookie);
                string reHtml = hr.Html.Replace("\r\n", "").Replace("\t", "").Replace("\n", "");
                reHtml = reHtml.Trim();
                //Cookiesss += hr.Cookie;
                if (reHtml.Contains("OK"))
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
            }

            return false;
        }
        public void setProxy(string proxyip)
        {
            this.Proxy = proxyip;
        }

        public bool Login163(string user,string pwd)
        {
            Cookies = "";
            string url = "";
            string postdata = "";
            string reHtml = "";
            try
            {
                //获取浏览器标识JESSION等基础信息
                url = string.Format("http://reg.163.com/click.jsp?click_in=Login&v={0}&click_count_spec=userLoginQuery&_ahref=&_at=",new XJHTTP ().GetTimeByJs ());
                items = new HttpItems() {
                    URL =url,
                    Cookie =Cookies,
                    Referer=string.Format ("http://reg.163.com/UserLogin.do?errorType=460&errorUsername={0}@163.com",user )//"http://reg.163.com/UserLogin.do"
                };
                hr = helper.GetHtml(items ,ref Cookies );
                reHtml = hr.Html;


                //提交登录信息
                url = string.Format("https://reg.163.com/logins.jsp");
                postdata = string.Format("type=1&product=urs&url=&url2=http%3A%2F%2Freg.163.com%2FUserLogin.do&username={0}%40163.com&password={1}",user ,pwd );
                items = new HttpItems()
                {
                    URL = url,
                    Cookie = Cookies,
                    Method ="post",
                    Postdata =postdata,
                     Referer = string.Format("http://reg.163.com/UserLogin.do?errorType=460&errorUsername={0}@163.com", user)
                };
                hr = helper.GetHtml(items, ref Cookies);
                reHtml = hr.Html;

                //登录后面内容
                url = string.Format("http://reg.163.com/Main.jsp?username={0}",user );
                items = new HttpItems()
                {
                    URL = url,
                    Cookie = Cookies,
                };
                hr = helper.GetHtml(items, ref Cookies);
                reHtml = hr.Html;

                if (reHtml.Contains("上次登录")) {
                    return true;
                }
            }

            catch (Exception ex)
            {
                
            }


            return false;
        }



        public bool RegUserPass(string user, string pass, ref string status)
        {
            try
            {
                return RegUserPass_Music(user, pass, ref status);
                /*
                string codeID= string.Empty ;
                string postData = string.Empty;
                string Vcode = string.Empty;
                 byte[] codebytes = null;
                string[] pros = { "db"};
                string[] pros1 = { "db","xyq","xy2","ty","dh2","bw","xy3","xqn",
                                 "x3","zmq","dtws2","lj","wh","jl","zh","ff",
                                    "tuji","wxdj","sc2","y3","my","dhxy","ldxy"};

                string pro = pros[new Random ().Next (pros.Length )];
                Cookies = "";
                status = string.Empty ;

                if(!CheckUserName (user))
                {
                    status = "检查用户名可注册性返回失败";
                    return false;
                }


                //获取初始　JSESSIONID,SID两个唯一标识，返回的Cookie里面
                string url = String.Format("http://reg.163.com/reg/innerDomainReg.do?product="+pro+"&url=http%3A%2F%2F"+pro+".163.com&loginurl=http%3A%2F%2F"+pro+".163.com");
                items = new HttpItems() {
                    URL = url,
                    Cookie = Cookies,
                    ProxyIp = Proxy 

                };
                hr = helper.GetHtml(items,ref Cookies);
                Cookies += hr.Cookie;
                string  reHtml = hr.Html.Replace("\r\n", "").Replace("\t", "").Replace("\n", "");

        GETVCODE:
                //获取验证码ID

                url = String.Format("http://reg.163.com/services/getid");
                items = new HttpItems() {
                    URL = url,
                    Cookie = Cookies,
                    ProxyIp = Proxy
                };
                  items.URL = url;
                //items.Container = cc;
                items.Cookie = Cookies;
                 items.ProxyIp = Proxy;
                hr = helper.GetHtml(items, ref Cookies);
                reHtml = hr.Html.Replace("\r\n", "").Replace("\t", "").Replace("\n", "");
                reHtml = reHtml.Trim();

                codeID= reHtml;

                //获取验证码数据

                url = String.Format("http://reg.163.com/services/getimg?v=1448380241064&num=6&type=2&id={0}", codeID);
                 items = new HttpItems() {
                     URL = url,
                     Cookie = Cookies,
                     ProxyIp = Proxy
                 };
                items.URL = url;
                ///items.Container = cc;
                items.Cookie = Cookies;
                items.ResultType = CsharpHttpHelpers.Enum.ResultType.Byte;
                items.ProxyIp = Proxy;
                hr = helper.GetHtml(items,ref Cookies);
                Cookies += hr.Cookie;

                codebytes = hr.ResultByte;
                //获取验证码
                 if(getImgCode ==null || codebytes ==null ||string.IsNullOrEmpty  (Vcode =getImgCode (codebytes )) )
                {
                    status = "验证码识别有问题："+Vcode;
                    return false;
                }

                //正式提交注册数据
                //string winx1_2 = (((long)new Random().Next(100) * 10e4) + 10e6).ToString() + ((long.Parse(new XJHTTP().GetTimeByJs()) / 1000).ToString());
                //username = "tempemail2";
                //pwd = "tempemail2163";
                //vcode = "29cbgx";
                //codeId = "818e907d3eda65edfead7ec0f3f4d3ba1b45a181";
                string codez = winx1_1 + "_";// + winx1_2;
                url = String.Format("https://reg.163.com/reg/innerDomainRegSubmit.do");
                postData = String.Format(
                    "url=http://"+pro+".163.com&product="+pro+"&loginurl=http%3A%2F%2F"+pro+".163.com&fromUrl=http%253A%252F%252Freg.163.com%252Freg%252Freg.jsp%253Fproduct%253D"+pro+"%2526url%253Dhttp%25253A%25252F%25252F"+pro+".163.com%2526loginurl%253Dhttp%25253A%25252F%25252F"+pro+".163.com&u1=0&codez={0}&radomPassID={1}&username={2}&domain=%40163.com&password={3}&cpassword={4}&radomPass={5}&agree=on"
                    , codez, codeID , user, pass, pass, Vcode);

                items = new HttpItemss();
                items.URL = url;
                items.ProxyIp = Proxy;
                items.Method = "POST";
                items.Postdata = postData;
                items.Referer = "http://reg.163.com/reg/innerDomainReg.do?product="+pro+"";
                items.Cookie = "_ntes_nnid=; _ntes_nuid=;URS_Analyze=1; reg_info=366303" + new Random().Next(11111111, 100000000).ToString() + ";" + Cookies;
                items.Cookie = "_ntes_nnid=;_ntes_nuid=;URS_Analyze=1; reg_info=366303;" + Cookies;

                //items.Cookie = "_ntes_nnid=; _ntes_nuid=;URS_Analyze=1; reg_info=366303;JSESSIONID=decg0XMdMALNThAXai-ev;REG_ANALYSIS=85faf129-494a-480e-b2e8-13d3b46138a6;SID=403b5163-07a1-4493-a20e-8ed11e31d144;";
                items.Allowautoredirect = true   ;
                hr = helper.GetHtml(items,ref Cookies);
                reHtml = hr.Html.Replace("\r\n", "").Replace("\t", "").Replace("\n", "");
                reHtml = reHtml.Trim();
                if (reHtml.Contains("您输入的图片中的文字不正确！"))
                {
                    goto GETVCODE;
                }
                else if (reHtml.Contains("正在登录，请稍等"))
                {
                    File.AppendAllText(Environment.CurrentDirectory + @"\finishUsers.txt", string.Format("{0}----{1}\r\n", user, pass));

                    status +="注册成功\t";
                    return true;
                    //MessageBox.Show("注册成功");
                }
                else
                {
                    if(reHtml .Contains ("短信验证"))
                    status += "短信验证" ;
                    else
                    {
                        status +=reHtml ;
                    }
                    return false;
                    //MessageBox.Show(reHtml);
                }
                */
            }
            catch (Exception ex)
            {
            }

            return false;
        }


        /// <summary>
        /// 取文本中间
        /// </summary>
        /// <param name="allStr">原字符</param>
        /// <param name="firstStr">前面的文本</param>
        /// <param name="lastStr">后面的文本</param>
        /// <returns></returns>
        public string GetStringMid(string allStr, string firstStr, string lastStr)
        {
            //取出前面的位置
            int index1 = allStr.IndexOf(firstStr);
            //取出后面的位置
            int index2 = allStr.IndexOf(lastStr, index1 + firstStr.Length);

            if (index1 < 0 || index2 < 0)
            {
                return "";
            }
            //定位到前面的位置
            index1 = index1 + firstStr.Length;
            //判断要取的文本的长度
            index2 = index2 - index1;

            if (index1 < 0 || index2 < 0)
            {
                return "";
            }
            //取出文本
            return allStr.Substring(index1, index2);
        }

        public string get_env(string html)
        {
            string evalue = "";
            int c = 4;
            int d = 7;
            int p = 6;
            int g = c * 100 + d * 10 + p;


            evalue = GetStringMid(html, "envalue : \"", "\"");
            int e = g * int.Parse(evalue);

            string k_f = e.ToString();
            string k_e = "";
            for (int i = k_f.Length - 1; i >= 0; i--)
            {
                k_e += k_f[i];
            }
            string re = p.ToString() + k_e + d.ToString() + c.ToString();
            /*
            		 c d p ;
		 g =cdp;
		 e=g*env;
		 k =e 反转
		 
        var i = p + k + d + c;
            */
            return re;
        }
        private Dictionary<string, string> getPater(string allText, string head, string end, char[] zusplit, char[] kvsplit)
        {
            Dictionary<string, string> re = new Dictionary<string, string>();
            if (head != "" && allText.IndexOf(head) != -1)
            {
                allText = allText.Substring(allText.IndexOf(head) + head.Length);
            }
            if (end != "" && allText.IndexOf(end) != -1)
            {
                allText = allText.Substring(0, allText.IndexOf(end));
            }
            string[] tmps = allText.Split(zusplit).Where(s => !string.IsNullOrEmpty(s)).ToArray();
            //tmps = tmps;
            foreach (string item in tmps)
            {
                string[] tmp2 = item.Split(kvsplit).Where(s => !string.IsNullOrEmpty(s)).ToArray();
                if (tmp2.Length == 2 && !re.ContainsKey(tmp2[0]))
                {
                    re.Add(tmp2[0], tmp2[1]);
                }
            }


            return re;
        }

        public void forlog(string cookie,string name,string pwd)
        {
            string url = string.Format("http://reg.email.163.com/unireg/call.do?cmd=register.formLog");
            string[] data =
            {
                string.Format("opt=write_field&flow=main&field=name&result=done&uid={0}%40163.com&timecost={1}&level=info",name,new Random ().Next (4000,10000).ToString () ),
                string.Format ("opt=write_field&flow=main&field=pwd&result=done&strength=2&timecost={0}&level=info",new Random ().Next (4000,10000).ToString ()),
                string.Format ("opt=write_field&flow=main&field=cfmPwd&result=done&timecost={0}&level=info",new Random ().Next (4000,10000).ToString ()),
                string.Format ("opt=write_field&flow=main&field=vcode&result=done&timecost={0}&level=info",new Random ().Next (4000,10000).ToString ()),

             };
            string postdata = "";
            //"opt=write_field&flow=main&field=name&result=done&uid=kljdiel%40163.com&timecost=4460&level=info";
            //opt=write_field&flow=main&field=pwd&result=done&strength=2&timecost=2927&level=info
            //opt=write_field&flow=main&field=cfmPwd&result=done&timecost=2967&level=info
            //opt=write_field&flow=main&field=vcode&result=done&timecost=4920&level=info
            int index = 0;

            while (index < data.Length)
            {
                postdata = data[index];
                index++;

                items = new HttpItems()
                {
                    URL = url,
                    Cookie = Cookies,
                    ProxyIp = Proxy
                };
                hr = helper.GetHtml(items,ref Cookies);
                //Cookies +=  HttpHelpers.GetSmallCookie(hr.Cookie);
                string reHtml = hr.Html.Replace("\r\n", "").Replace("\t", "").Replace("\n", "");
            }
            //reHtml = reHtml.Trim();
            
        }

        public bool RegUserPass_Music(string user, string pass, ref string status)
        {
            try
            {
                //http://reg.email.163.com/unireg/call.do?cmd=register.entrance&from=163navi%C2%AEPage=163

                //https://ssl.mail.163.com/regall/unireg/prepare.jsp?sid=13B5821160ADE399CD009F3F9AB10EBE&sd=INTERNAL19
                //sid是Cookie中的JSESSIONID


                //验证码
                //http://reg.email.163.com/unireg/call.do?cmd=register.verifyCode&v=common/verifycode/vc_en&env=704864408122&t=1448764801723
                //checkName
                //http://reg.email.163.com/unireg/call.do?cmd=urs.checkName
                //Post
                //name=yqmacmusic

                //https://ssl.mail.163.com/regall/unireg/call.do;jsessionid=13B5821160ADE399CD009F3F9AB10EBE?cmd=register.start
                //name=yqmacmusic&flow=main&uid=yqmacmusic%40163.com&password=yqmacmusic163&confirmPassword=yqmacmusic163&mobile=&vcode=yxysy&from=163navi%C2%AEPage%3D163

                /*name:yqmacmusic
                flow:main
                uid:yqmacmusic@163.com
                password:yqmacmusic163
                confirmPassword:yqmacmusic163
                mobile:
                vcode: yxysy
                from:163navi®Page = 163
          */


                string postData = string.Empty;
                string Vcode = string.Empty;
                byte[] codebytes = null;
                Cookies = "";
                status = string.Empty;

                Cookies = "";
                //获取初始　JSESSIONID,SID两个唯一标识，返回的Cookie里面
                string url = string.Format("http://reg.email.163.com/unireg/call.do?cmd=register.entrance&from=163navi%C2%AEPage=163");
                items = new HttpItems()
                {
                    URL = url,
                    Cookie = Cookies,
                    ProxyIp = Proxy
                };
                hr = helper.GetHtml(items,ref Cookies);
                //Cookies += HttpHelpers.GetSmallCookie(hr.Cookie);
                string reHtml = hr.Html.Replace("\r\n", "").Replace("\t", "").Replace("\n", "");
                //reHtml = reHtml.Trim();
                if (reHtml == "无法连接到远程服务器")
                {
                    status += "无法连接到远程服务器";
                    return false;
                }
                string envalue = get_env(reHtml);



                if (!CheckUserName(user))
                {
                    status = "检查用户名可注册性返回失败";
                    return false;
                }
                GETVCODE:


                //获取验证码数据

                url = String.Format("http://reg.email.163.com/unireg/call.do?cmd=register.verifyCode&v=common/verifycode/vc_en&env={0}&t={1}", envalue, new XJHTTP().GetTimeByJs());
                items = new HttpItems()
                {
                    URL = url,
                    Cookie = Cookies,
                    ProxyIp = Proxy,
                    ResultType = ResultType.Byte 
                };

                hr = helper.GetHtml(items,ref Cookies );
                //Cookies +=  HttpHelpers.GetSmallCookie(hr.Cookie);
                codebytes = hr.ResultByte;
                //获取验证码
                if (codebytes.Length < 100 || getImgCode == null || codebytes == null || string.IsNullOrEmpty(Vcode = getImgCode(codebytes)))
                {
                    string str = System.Text.Encoding.Default.GetString(codebytes);
                    str = GetStringMid(str, "msg\":\"", "\"");
                    status = "验证码识别有问题：" + str;
                    //status += hr.Html;
                    return false;
                }


                forlog(Cookies ,user ,pass );

                string sid = "";
                sid = GetStringMid(Cookies, "JSESSIONID=", ";");
                string sd = GetStringMid(Cookies,"ser_adapter=",";");
                if(string.IsNullOrEmpty(sd))
                {
                    sd = Cookies.Substring(Cookies .IndexOf ("ser_adapter=")+ "ser_adapter=".Length );
                }
                //prepare
                url = String.Format("https://ssl.mail.163.com/regall/unireg/prepare.jsp?sid={0}&sd={1}", sid, sd);
                items = new HttpItems()
                {
                    URL = url,
                    Cookie = Cookies,
                    ProxyIp = Proxy,
                    //KeepAlive = true,
                    CerPath = System.Environment.CurrentDirectory + @"\163reg.cer",
                    //ProtocolVersion = System.Net.HttpVersion.Version10 
                    //IsAjax = true 
                    
                };
                //items.CerPath = System.Environment.CurrentDirectory + @"\163reg.cer";
                hr = helper.GetHtml(items,ref Cookies);
                //Cookies +=  HttpHelpers.GetSmallCookie(hr.Cookie);
                reHtml = hr.Html.Replace("\r\n", "").Replace("\t", "").Replace("\n", "");
               // Cookies =Cookies.Replace(";;",";");





                //正式提交注册数据
                url = String.Format("https://ssl.mail.163.com/regall/unireg/call.do;jsessionid={0}?cmd=register.start", sid);
                postData = String.Format(
                    "name={0}&flow=main&uid={1}%40163.com&password={2}&confirmPassword={3}&mobile=&vcode={4}&from=163navi%C2%AEPage%3D163"
                    , user, user, pass, pass, Vcode);
                items = new HttpItems()
                {
                    URL = url,
                    Cookie = Cookies,
                    ProxyIp = Proxy,
                    Method = "POST",
                    //PostDataType = CsharpHttpHelpers.Enum.PostDataType.String,
                    Postdata = postData,
                    //KeepAlive =true ,
                    Referer = "http://reg.email.163.com/unireg/call.do?cmd=register.entrance&from=163navi%C2%AEPage=163",
                    Allowautoredirect = false ,
                    //IsAjax =true ,
                    CerPath = System.Environment.CurrentDirectory + @"\163reg.cer",
                    //ProtocolVersion = System.Net.HttpVersion.Version10
                };
                hr = helper.GetHtml(items,ref Cookies);
               // Cookies +=  HttpHelpers.GetSmallCookie(hr.Cookie);
                reHtml = hr.Html.Replace("\r\n", "").Replace("\t", "").Replace("\n", "");
                reHtml = reHtml.Trim();

                ////Cookies = HttpHelpers.GetSmallCookie(Cookies );
                // url = string.Format("http://entry.mail.163.com/coremail/fcg/ntesdoor2");
                //items = new HttpItems()
                //{
                //    URL = url,
                //    Cookie = Cookies,
                //    ProxyIp = Proxy
                //};
                //hr = helper.GetHtml(items,ref Cookies);
                ////Cookies +=  HttpHelpers.GetSmallCookie(hr.Cookie);
                // reHtml = hr.Html.Replace("\r\n", "").Replace("\t", "").Replace("\n", "");
                ////reHtml = reHtml.Trim();
                //if (reHtml == "无法连接到远程服务器")
                //{
                //    status += "无法连接到远程服务器";
                //    return false;
                //}
        

                //{"code":401,"desc":"PARAMETER ERROR","msg":"VCODE_NOT_MATCH","result":863675}
                if (reHtml.Contains("注册成功") || reHtml.Contains("http://mail.163.com/dashi/activity/reg/ok.do?from=zimu"))
                {
                    File.AppendAllText(Environment.CurrentDirectory + @"\finishUsers.txt", string.Format("{0}----{1}\r\n", user, pass));
                    status += "注册成功\t";
                    return true;
                    //MessageBox.Show("注册成功");
                }
                else
                {
                    yq.LogHelper.Debug("user :" + user + ";pass:" + pass + ";msg" + reHtml);
                    string msg = GetStringMid(reHtml, "msg\":\"", "\"");
                    switch (string.IsNullOrEmpty(msg) ? reHtml : msg)
                    {
                        case "INVALID NAME":
                            status += "无效的用户名";
                            break;
                        case "NAME_EQUALS_PASSWORD":
                            status += "密码和用户名不能完全相同";
                            break;
                        case "NO_PASSWORD":
                            break;
                        case "NAME EQUALS PASSWORD":
                        case "PASSWORD TOO SIMPLE":
                            status += "密码过于简单，请尝试“字母+数字”的组合";
                            break;
                        case "NO_CONFIRMED_PASSWORD":
                        case "PASSWORD_NOT_MATCH":
                            break;
                        case "INVALID MOBILE":
                            status += "请填写有效的11位手机号码";
                            break;
                        case "BIND TOO MANY":
                            status += "该手机号码已绑定5个帐号，请编辑短信“JC”发送到 10690163331，取消手机和所有帐号的绑定关系";
                            break;
                        case "VCODE_NOT_MATCH":
                            goto GETVCODE;
                        default:
                            status += reHtml;
                            break;
                    }
                    return false;
                    //MessageBox.Show(reHtml);
                }
            }
            catch (Exception ex)
            {
            }
            /*
            this.handleMsg = function(U) {
        switch (U.msg) {
        case "INVALID NAME":
            d.showRemind("error", "name", "无效的用户名");
            j.name = false;
            break;
        case "ILLEGAL_UID":
            $("#nameIpt").blur();
            j.name = false;
            break;
        case "NAME_EQUALS_PASSWORD":
            d.showRemind("error", "mainPwd", "密码和用户名不能完全相同");
            j.pwd = false;
            break;
        case "NO_PASSWORD":
            $("#mainPwdIpt").blur();
            j.pwd = false;
            break;
        case "NAME EQUALS PASSWORD":
        case "PASSWORD TOO SIMPLE":
            d.showRemind("error", "mainPwd", "密码过于简单，请尝试“字母+数字”的组合");
            j.pwd = false;
            break;
        case "NO_CONFIRMED_PASSWORD":
        case "PASSWORD_NOT_MATCH":
            $("#mainCfwPwdIpt").blur();
            j.cfmPwd = false;
            break;
        case "INVALID MOBILE":
            d.showRemind("error", "mainMobile", "请填写有效的11位手机号码");
            j.mobile = false;
            break;
        case "BIND TOO MANY":
            d.showRemind("error", "mainMobile", "该手机号码已绑定5个帐号，请编辑短信“JC”发送到 10690163331，取消手机和所有帐号的绑定关系");
            j.mobile = false;
            break;
        case "VCODE_NOT_MATCH":
            d.showRemind("error", "vcode", "验证码不正确，请重新填写");
            if (U.result) {
                f.initEnv(U.result)
            }
            $("#vcodeImg").click();
            j.vcode = false;
            break;
        case "INVALID_SUSPEND":
        case "REGISTER_NOT_FOUND":
            $("#overdueTips").show();
            break;
        default:
            $("#overdueTips").show();
            break
        }
            */
            return false;
        }



        #endregion 功能



    }
}

namespace RegTools
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.comb_Proj = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.rab_User_o = new System.Windows.Forms.RadioButton();
            this.panel_User_r = new System.Windows.Forms.Panel();
            this.panel_User_s = new System.Windows.Forms.Panel();
            this.rab_User_s = new System.Windows.Forms.RadioButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel_Pwd_s = new System.Windows.Forms.Panel();
            this.panel_Pwd_eq = new System.Windows.Forms.Panel();
            this.rab_Pwd_s = new System.Windows.Forms.RadioButton();
            this.rab_Pwd_eq = new System.Windows.Forms.RadioButton();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.panel_Vcode_hand = new System.Windows.Forms.Panel();
            this.panel_Vcode_p = new System.Windows.Forms.Panel();
            this.rab_Vcode_Nodo = new System.Windows.Forms.RadioButton();
            this.ran_Vcode_handl = new System.Windows.Forms.RadioButton();
            this.rab_Vcode_p = new System.Windows.Forms.RadioButton();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.rab_IP_Nodo = new System.Windows.Forms.RadioButton();
            this.r = new System.Windows.Forms.RadioButton();
            this.rab_IP_k = new System.Windows.Forms.RadioButton();
            this.panel_IP_proxy = new System.Windows.Forms.Panel();
            this.panel_IP_k = new System.Windows.Forms.Panel();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.btn_Start = new System.Windows.Forms.Button();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel_User_r.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // comb_Proj
            // 
            this.comb_Proj.FormattingEnabled = true;
            this.comb_Proj.Location = new System.Drawing.Point(84, 21);
            this.comb_Proj.Name = "comb_Proj";
            this.comb_Proj.Size = new System.Drawing.Size(132, 20);
            this.comb_Proj.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Location = new System.Drawing.Point(3, 50);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(559, 309);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.richTextBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(551, 283);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "即时日志";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(5, 6);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(541, 276);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "测试log输出临时使用";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.rab_User_o);
            this.tabPage1.Controls.Add(this.panel_User_r);
            this.tabPage1.Controls.Add(this.panel_User_s);
            this.tabPage1.Controls.Add(this.rab_User_s);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(551, 283);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "帐号";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // rab_User_o
            // 
            this.rab_User_o.AutoSize = true;
            this.rab_User_o.Location = new System.Drawing.Point(11, 10);
            this.rab_User_o.Name = "rab_User_o";
            this.rab_User_o.Size = new System.Drawing.Size(71, 16);
            this.rab_User_o.TabIndex = 6;
            this.rab_User_o.TabStop = true;
            this.rab_User_o.Text = "外部导入";
            this.rab_User_o.UseVisualStyleBackColor = true;
            // 
            // panel_User_r
            // 
            this.panel_User_r.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_User_r.Controls.Add(this.label2);
            this.panel_User_r.Location = new System.Drawing.Point(6, 28);
            this.panel_User_r.Name = "panel_User_r";
            this.panel_User_r.Size = new System.Drawing.Size(229, 253);
            this.panel_User_r.TabIndex = 5;
            // 
            // panel_User_s
            // 
            this.panel_User_s.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_User_s.Location = new System.Drawing.Point(240, 28);
            this.panel_User_s.Name = "panel_User_s";
            this.panel_User_s.Size = new System.Drawing.Size(310, 252);
            this.panel_User_s.TabIndex = 1;
            // 
            // rab_User_s
            // 
            this.rab_User_s.AutoSize = true;
            this.rab_User_s.Location = new System.Drawing.Point(241, 11);
            this.rab_User_s.Name = "rab_User_s";
            this.rab_User_s.Size = new System.Drawing.Size(71, 16);
            this.rab_User_s.TabIndex = 0;
            this.rab_User_s.TabStop = true;
            this.rab_User_s.Text = "规则生成";
            this.rab_User_s.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel_Pwd_s);
            this.tabPage2.Controls.Add(this.panel_Pwd_eq);
            this.tabPage2.Controls.Add(this.rab_Pwd_s);
            this.tabPage2.Controls.Add(this.rab_Pwd_eq);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(551, 283);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "密码";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel_Pwd_s
            // 
            this.panel_Pwd_s.Location = new System.Drawing.Point(230, 28);
            this.panel_Pwd_s.Name = "panel_Pwd_s";
            this.panel_Pwd_s.Size = new System.Drawing.Size(314, 250);
            this.panel_Pwd_s.TabIndex = 5;
            // 
            // panel_Pwd_eq
            // 
            this.panel_Pwd_eq.Location = new System.Drawing.Point(6, 28);
            this.panel_Pwd_eq.Name = "panel_Pwd_eq";
            this.panel_Pwd_eq.Size = new System.Drawing.Size(218, 252);
            this.panel_Pwd_eq.TabIndex = 3;
            // 
            // rab_Pwd_s
            // 
            this.rab_Pwd_s.AutoSize = true;
            this.rab_Pwd_s.Location = new System.Drawing.Point(230, 9);
            this.rab_Pwd_s.Name = "rab_Pwd_s";
            this.rab_Pwd_s.Size = new System.Drawing.Size(83, 16);
            this.rab_Pwd_s.TabIndex = 1;
            this.rab_Pwd_s.TabStop = true;
            this.rab_Pwd_s.Text = "自定义规则";
            this.rab_Pwd_s.UseVisualStyleBackColor = true;
            // 
            // rab_Pwd_eq
            // 
            this.rab_Pwd_eq.AutoSize = true;
            this.rab_Pwd_eq.Location = new System.Drawing.Point(11, 9);
            this.rab_Pwd_eq.Name = "rab_Pwd_eq";
            this.rab_Pwd_eq.Size = new System.Drawing.Size(71, 16);
            this.rab_Pwd_eq.TabIndex = 0;
            this.rab_Pwd_eq.TabStop = true;
            this.rab_Pwd_eq.Text = "固定密码";
            this.rab_Pwd_eq.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.panel_Vcode_hand);
            this.tabPage4.Controls.Add(this.panel_Vcode_p);
            this.tabPage4.Controls.Add(this.rab_Vcode_Nodo);
            this.tabPage4.Controls.Add(this.ran_Vcode_handl);
            this.tabPage4.Controls.Add(this.rab_Vcode_p);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(551, 283);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "验证码";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // panel_Vcode_hand
            // 
            this.panel_Vcode_hand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Vcode_hand.Location = new System.Drawing.Point(263, 38);
            this.panel_Vcode_hand.Name = "panel_Vcode_hand";
            this.panel_Vcode_hand.Size = new System.Drawing.Size(281, 241);
            this.panel_Vcode_hand.TabIndex = 4;
            // 
            // panel_Vcode_p
            // 
            this.panel_Vcode_p.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Vcode_p.Location = new System.Drawing.Point(3, 38);
            this.panel_Vcode_p.Name = "panel_Vcode_p";
            this.panel_Vcode_p.Size = new System.Drawing.Size(254, 241);
            this.panel_Vcode_p.TabIndex = 3;
            // 
            // rab_Vcode_Nodo
            // 
            this.rab_Vcode_Nodo.AutoSize = true;
            this.rab_Vcode_Nodo.Checked = true;
            this.rab_Vcode_Nodo.Location = new System.Drawing.Point(449, 12);
            this.rab_Vcode_Nodo.Name = "rab_Vcode_Nodo";
            this.rab_Vcode_Nodo.Size = new System.Drawing.Size(95, 16);
            this.rab_Vcode_Nodo.TabIndex = 2;
            this.rab_Vcode_Nodo.TabStop = true;
            this.rab_Vcode_Nodo.Text = "不处理验证码";
            this.rab_Vcode_Nodo.UseVisualStyleBackColor = true;
            // 
            // ran_Vcode_handl
            // 
            this.ran_Vcode_handl.AutoSize = true;
            this.ran_Vcode_handl.Location = new System.Drawing.Point(263, 12);
            this.ran_Vcode_handl.Name = "ran_Vcode_handl";
            this.ran_Vcode_handl.Size = new System.Drawing.Size(71, 16);
            this.ran_Vcode_handl.TabIndex = 1;
            this.ran_Vcode_handl.Text = "手工打码";
            this.ran_Vcode_handl.UseVisualStyleBackColor = true;
            // 
            // rab_Vcode_p
            // 
            this.rab_Vcode_p.AutoSize = true;
            this.rab_Vcode_p.Location = new System.Drawing.Point(11, 12);
            this.rab_Vcode_p.Name = "rab_Vcode_p";
            this.rab_Vcode_p.Size = new System.Drawing.Size(71, 16);
            this.rab_Vcode_p.TabIndex = 0;
            this.rab_Vcode_p.Text = "打码平台";
            this.rab_Vcode_p.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.rab_IP_Nodo);
            this.tabPage5.Controls.Add(this.r);
            this.tabPage5.Controls.Add(this.rab_IP_k);
            this.tabPage5.Controls.Add(this.panel_IP_proxy);
            this.tabPage5.Controls.Add(this.panel_IP_k);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(551, 283);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "IP地址";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // rab_IP_Nodo
            // 
            this.rab_IP_Nodo.AutoSize = true;
            this.rab_IP_Nodo.Checked = true;
            this.rab_IP_Nodo.Location = new System.Drawing.Point(454, 12);
            this.rab_IP_Nodo.Name = "rab_IP_Nodo";
            this.rab_IP_Nodo.Size = new System.Drawing.Size(71, 16);
            this.rab_IP_Nodo.TabIndex = 8;
            this.rab_IP_Nodo.TabStop = true;
            this.rab_IP_Nodo.Text = "不处理IP";
            this.rab_IP_Nodo.UseVisualStyleBackColor = true;
            // 
            // r
            // 
            this.r.AutoSize = true;
            this.r.Location = new System.Drawing.Point(235, 12);
            this.r.Name = "r";
            this.r.Size = new System.Drawing.Size(71, 16);
            this.r.TabIndex = 7;
            this.r.Text = "代理IP池";
            this.r.UseVisualStyleBackColor = true;
            // 
            // rab_IP_k
            // 
            this.rab_IP_k.AutoSize = true;
            this.rab_IP_k.Location = new System.Drawing.Point(11, 12);
            this.rab_IP_k.Name = "rab_IP_k";
            this.rab_IP_k.Size = new System.Drawing.Size(71, 16);
            this.rab_IP_k.TabIndex = 6;
            this.rab_IP_k.Text = "宽带拨号";
            this.rab_IP_k.UseVisualStyleBackColor = true;
            // 
            // panel_IP_proxy
            // 
            this.panel_IP_proxy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_IP_proxy.Location = new System.Drawing.Point(235, 38);
            this.panel_IP_proxy.Name = "panel_IP_proxy";
            this.panel_IP_proxy.Size = new System.Drawing.Size(309, 241);
            this.panel_IP_proxy.TabIndex = 5;
            // 
            // panel_IP_k
            // 
            this.panel_IP_k.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_IP_k.Location = new System.Drawing.Point(3, 38);
            this.panel_IP_k.Name = "panel_IP_k";
            this.panel_IP_k.Size = new System.Drawing.Size(226, 241);
            this.panel_IP_k.TabIndex = 4;
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(551, 283);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "附加设置";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(236, 18);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(158, 23);
            this.btn_Start.TabIndex = 2;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = true;
            // 
            // btn_Stop
            // 
            this.btn_Stop.Location = new System.Drawing.Point(400, 18);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(151, 23);
            this.btn_Stop.TabIndex = 3;
            this.btn_Stop.Text = "Stop";
            this.btn_Stop.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "项目名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "将文件拖进来，每行一个帐号";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 363);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Stop);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.comb_Proj);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "通用注册机";
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel_User_r.ResumeLayout(false);
            this.panel_User_r.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comb_Proj;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Panel panel_User_s;
        private System.Windows.Forms.RadioButton rab_User_s;
        private System.Windows.Forms.Panel panel_Pwd_s;
        private System.Windows.Forms.RadioButton rab_Pwd_s;
        private System.Windows.Forms.RadioButton rab_Pwd_eq;
        private System.Windows.Forms.Panel panel_Vcode_hand;
        private System.Windows.Forms.Panel panel_Vcode_p;
        private System.Windows.Forms.RadioButton rab_Vcode_Nodo;
        private System.Windows.Forms.RadioButton ran_Vcode_handl;
        private System.Windows.Forms.RadioButton rab_Vcode_p;
        private System.Windows.Forms.RadioButton rab_IP_Nodo;
        private System.Windows.Forms.RadioButton r;
        private System.Windows.Forms.RadioButton rab_IP_k;
        private System.Windows.Forms.Panel panel_IP_proxy;
        private System.Windows.Forms.Panel panel_IP_k;
        private System.Windows.Forms.Panel panel_Pwd_eq;
        private System.Windows.Forms.RadioButton rab_User_o;
        private System.Windows.Forms.Panel panel_User_r;
        private System.Windows.Forms.Label label2;
    }
}


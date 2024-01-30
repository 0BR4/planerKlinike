namespace DiplomskiPlanerKlinike
{
    partial class FormLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.label1 = new System.Windows.Forms.Label();
            this.labelUserName = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.panelSelectLanguage = new System.Windows.Forms.Panel();
            this.buttonGerman = new System.Windows.Forms.Button();
            this.buttonEnglish = new System.Windows.Forms.Button();
            this.buttonSerbian = new System.Windows.Forms.Button();
            this.buttonSelectLanguage = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonHidePassword = new System.Windows.Forms.Button();
            this.buttonShowPassword = new System.Windows.Forms.Button();
            this.panelSelectLanguage.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelUserName
            // 
            resources.ApplyResources(this.labelUserName, "labelUserName");
            this.labelUserName.Name = "labelUserName";
            // 
            // labelPassword
            // 
            resources.ApplyResources(this.labelPassword, "labelPassword");
            this.labelPassword.Name = "labelPassword";
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.BackColor = System.Drawing.Color.White;
            this.textBoxUserName.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.textBoxUserName, "textBoxUserName");
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxUserName_KeyDown);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.BackColor = System.Drawing.Color.White;
            this.textBoxPassword.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.textBoxPassword, "textBoxPassword");
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.UseSystemPasswordChar = true;
            this.textBoxPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxPassword_KeyDown);
            // 
            // panelSelectLanguage
            // 
            this.panelSelectLanguage.Controls.Add(this.buttonGerman);
            this.panelSelectLanguage.Controls.Add(this.buttonEnglish);
            this.panelSelectLanguage.Controls.Add(this.buttonSerbian);
            this.panelSelectLanguage.Controls.Add(this.buttonSelectLanguage);
            resources.ApplyResources(this.panelSelectLanguage, "panelSelectLanguage");
            this.panelSelectLanguage.Name = "panelSelectLanguage";
            // 
            // buttonGerman
            // 
            resources.ApplyResources(this.buttonGerman, "buttonGerman");
            this.buttonGerman.Name = "buttonGerman";
            this.buttonGerman.UseVisualStyleBackColor = true;
            this.buttonGerman.Click += new System.EventHandler(this.buttonGerman_Click);
            // 
            // buttonEnglish
            // 
            resources.ApplyResources(this.buttonEnglish, "buttonEnglish");
            this.buttonEnglish.Name = "buttonEnglish";
            this.buttonEnglish.UseVisualStyleBackColor = true;
            this.buttonEnglish.Click += new System.EventHandler(this.buttonEnglish_Click);
            // 
            // buttonSerbian
            // 
            resources.ApplyResources(this.buttonSerbian, "buttonSerbian");
            this.buttonSerbian.Name = "buttonSerbian";
            this.buttonSerbian.UseVisualStyleBackColor = true;
            this.buttonSerbian.Click += new System.EventHandler(this.buttonSerbian_Click);
            // 
            // buttonSelectLanguage
            // 
            resources.ApplyResources(this.buttonSelectLanguage, "buttonSelectLanguage");
            this.buttonSelectLanguage.Name = "buttonSelectLanguage";
            this.buttonSelectLanguage.UseVisualStyleBackColor = true;
            this.buttonSelectLanguage.Click += new System.EventHandler(this.buttonSelectLanguage_Click);
            // 
            // buttonExit
            // 
            resources.ApplyResources(this.buttonExit, "buttonExit");
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonLogin
            // 
            resources.ApplyResources(this.buttonLogin, "buttonLogin");
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // buttonClear
            // 
            resources.ApplyResources(this.buttonClear, "buttonClear");
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonHidePassword
            // 
            resources.ApplyResources(this.buttonHidePassword, "buttonHidePassword");
            this.buttonHidePassword.Name = "buttonHidePassword";
            this.buttonHidePassword.UseVisualStyleBackColor = true;
            this.buttonHidePassword.Click += new System.EventHandler(this.buttonHidePassword_Click);
            // 
            // buttonShowPassword
            // 
            resources.ApplyResources(this.buttonShowPassword, "buttonShowPassword");
            this.buttonShowPassword.Name = "buttonShowPassword";
            this.buttonShowPassword.UseVisualStyleBackColor = true;
            this.buttonShowPassword.Click += new System.EventHandler(this.buttonShowPassword_Click);
            // 
            // FormLogin
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonShowPassword);
            this.Controls.Add(this.buttonHidePassword);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.panelSelectLanguage);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelUserName);
            this.Controls.Add(this.label1);
            this.Name = "FormLogin";
            this.panelSelectLanguage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Panel panelSelectLanguage;
        private System.Windows.Forms.Button buttonSerbian;
        private System.Windows.Forms.Button buttonSelectLanguage;
        private System.Windows.Forms.Button buttonEnglish;
        private System.Windows.Forms.Button buttonGerman;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonHidePassword;
        private System.Windows.Forms.Button buttonShowPassword;
    }
}


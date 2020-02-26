namespace WinHotel
{
    partial class MainForm
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
            this.btnModule1 = new System.Windows.Forms.Button();
            this.btnModule2 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.username = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.password = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnModule1
            // 
            this.btnModule1.FlatAppearance.BorderSize = 0;
            this.btnModule1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModule1.Font = new System.Drawing.Font("Georgia", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnModule1.ForeColor = System.Drawing.Color.White;
            this.btnModule1.Location = new System.Drawing.Point(23, 85);
            this.btnModule1.Name = "btnModule1";
            this.btnModule1.Size = new System.Drawing.Size(155, 54);
            this.btnModule1.TabIndex = 8;
            this.btnModule1.Text = "Rooms";
            this.btnModule1.UseVisualStyleBackColor = true;
            this.btnModule1.Visible = false;
            this.btnModule1.Click += new System.EventHandler(this.btnModule1_Click);
            // 
            // btnModule2
            // 
            this.btnModule2.FlatAppearance.BorderSize = 0;
            this.btnModule2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModule2.Font = new System.Drawing.Font("Georgia", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnModule2.ForeColor = System.Drawing.Color.White;
            this.btnModule2.Location = new System.Drawing.Point(23, 172);
            this.btnModule2.Name = "btnModule2";
            this.btnModule2.Size = new System.Drawing.Size(155, 52);
            this.btnModule2.TabIndex = 9;
            this.btnModule2.Text = "Residents";
            this.btnModule2.UseVisualStyleBackColor = true;
            this.btnModule2.Visible = false;
            this.btnModule2.Click += new System.EventHandler(this.btnModule2_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(670, 603);
            this.panel3.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.username);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.password);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Georgia", 10.8F);
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(670, 603);
            this.panel1.TabIndex = 6;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1_Paint);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(670, 26);
            this.panel4.TabIndex = 6;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel4_Paint);
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.BackColor = System.Drawing.Color.Transparent;
            this.username.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.username.Font = new System.Drawing.Font("Georgia", 10.8F);
            this.username.ForeColor = System.Drawing.Color.White;
            this.username.Location = new System.Drawing.Point(305, 214);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(106, 23);
            this.username.TabIndex = 2;
            this.username.Text = "UserName:";
            this.username.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.username.Click += new System.EventHandler(this.Username_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Georgia", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(255, 372);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(193, 54);
            this.button1.TabIndex = 5;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // password
            // 
            this.password.AutoSize = true;
            this.password.BackColor = System.Drawing.Color.Transparent;
            this.password.Font = new System.Drawing.Font("Georgia", 10.8F);
            this.password.ForeColor = System.Drawing.Color.White;
            this.password.Location = new System.Drawing.Point(310, 283);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(97, 23);
            this.password.TabIndex = 1;
            this.password.Text = "Password:";
            this.password.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.password.Click += new System.EventHandler(this.password_Click);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.SlateGray;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(255, 310);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(193, 21);
            this.textBox2.TabIndex = 4;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox2_KeyDown);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.SlateGray;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(255, 241);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(193, 21);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox1_KeyDown);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Georgia", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(23, 479);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(155, 58);
            this.button2.TabIndex = 0;
            this.button2.Text = "LogOut";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.btnModule1);
            this.panel2.Controls.Add(this.btnModule2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.panel2.Location = new System.Drawing.Point(670, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(177, 603);
            this.panel2.TabIndex = 7;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel5.Location = new System.Drawing.Point(3, 85);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(13, 54);
            this.panel5.TabIndex = 10;
            this.panel5.Visible = false;
            this.panel5.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel5_Paint);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 603);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Opacity = 0.96D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnModule1;
        private System.Windows.Forms.Button btnModule2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label password;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label username;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.Panel panel5;
    }
}


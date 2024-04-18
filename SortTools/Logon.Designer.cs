﻿namespace SortTools
{
    partial class Logon
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtLogonLastName = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.btnLogon = new System.Windows.Forms.Button();
            this.txtEmployeeID = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SortTools.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(231, 13);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(133, 90);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(393, 233);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(191, 52);
            this.btnClose.TabIndex = 29;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Label3
            // 
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(14, 243);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(183, 32);
            this.Label3.TabIndex = 28;
            this.Label3.Text = "Last Name";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtLogonLastName
            // 
            this.txtLogonLastName.AcceptsReturn = true;
            this.txtLogonLastName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLogonLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLogonLastName.Location = new System.Drawing.Point(220, 244);
            this.txtLogonLastName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLogonLastName.Name = "txtLogonLastName";
            this.txtLogonLastName.Size = new System.Drawing.Size(140, 30);
            this.txtLogonLastName.TabIndex = 25;
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(14, 183);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(183, 32);
            this.Label2.TabIndex = 27;
            this.Label2.Text = "Employee ID";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLogon
            // 
            this.btnLogon.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogon.Location = new System.Drawing.Point(393, 173);
            this.btnLogon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLogon.Name = "btnLogon";
            this.btnLogon.Size = new System.Drawing.Size(191, 52);
            this.btnLogon.TabIndex = 26;
            this.btnLogon.Text = "Logon";
            this.btnLogon.UseVisualStyleBackColor = true;
            this.btnLogon.Click += new System.EventHandler(this.btnLogon_Click);
            // 
            // txtEmployeeID
            // 
            this.txtEmployeeID.AcceptsReturn = true;
            this.txtEmployeeID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmployeeID.Location = new System.Drawing.Point(220, 184);
            this.txtEmployeeID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEmployeeID.Name = "txtEmployeeID";
            this.txtEmployeeID.PasswordChar = '*';
            this.txtEmployeeID.Size = new System.Drawing.Size(140, 30);
            this.txtEmployeeID.TabIndex = 23;
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(12, 114);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(572, 50);
            this.Label1.TabIndex = 24;
            this.Label1.Text = "Please Type Your Employee ID and Last Name";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Logon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 316);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.txtLogonLastName);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.btnLogon);
            this.Controls.Add(this.txtEmployeeID);
            this.Controls.Add(this.Label1);
            this.Name = "Logon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Logon";
            this.Load += new System.EventHandler(this.Logon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtLogonLastName;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Button btnLogon;
        internal System.Windows.Forms.TextBox txtEmployeeID;
        internal System.Windows.Forms.Label Label1;
    }
}


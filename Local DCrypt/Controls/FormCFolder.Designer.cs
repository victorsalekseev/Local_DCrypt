namespace Remote_DCrypt.Controls
{
    partial class FormCFolder
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
            this.button_ok = new System.Windows.Forms.Button();
            this.textBox_act = new System.Windows.Forms.TextBox();
            this.checkBox_isEncrypt = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(209, 11);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(64, 23);
            this.button_ok.TabIndex = 0;
            this.button_ok.Text = "OK";
            this.button_ok.UseVisualStyleBackColor = true;
            // 
            // textBox_act
            // 
            this.textBox_act.Location = new System.Drawing.Point(12, 12);
            this.textBox_act.Name = "textBox_act";
            this.textBox_act.Size = new System.Drawing.Size(191, 20);
            this.textBox_act.TabIndex = 1;
            // 
            // checkBox_isEncrypt
            // 
            this.checkBox_isEncrypt.AutoSize = true;
            this.checkBox_isEncrypt.Location = new System.Drawing.Point(12, 38);
            this.checkBox_isEncrypt.Name = "checkBox_isEncrypt";
            this.checkBox_isEncrypt.Size = new System.Drawing.Size(119, 17);
            this.checkBox_isEncrypt.TabIndex = 2;
            this.checkBox_isEncrypt.Text = "Зашифровать имя";
            this.checkBox_isEncrypt.UseVisualStyleBackColor = true;
            // 
            // FormCFolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 60);
            this.Controls.Add(this.checkBox_isEncrypt);
            this.Controls.Add(this.textBox_act);
            this.Controls.Add(this.button_ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCFolder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Создать";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.TextBox textBox_act;
        private System.Windows.Forms.CheckBox checkBox_isEncrypt;
    }
}
namespace Local_DCrypt
{
    partial class FormPref
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
            this.textBox_pref = new System.Windows.Forms.TextBox();
            this.button_pref = new System.Windows.Forms.Button();
            this.textBox_pref_name = new System.Windows.Forms.TextBox();
            this.button_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_pref
            // 
            this.textBox_pref.Location = new System.Drawing.Point(99, 12);
            this.textBox_pref.Name = "textBox_pref";
            this.textBox_pref.Size = new System.Drawing.Size(151, 20);
            this.textBox_pref.TabIndex = 1;
            // 
            // button_pref
            // 
            this.button_pref.Location = new System.Drawing.Point(256, 12);
            this.button_pref.Name = "button_pref";
            this.button_pref.Size = new System.Drawing.Size(32, 20);
            this.button_pref.TabIndex = 2;
            this.button_pref.Text = "ОК";
            this.button_pref.UseVisualStyleBackColor = true;
            // 
            // textBox_pref_name
            // 
            this.textBox_pref_name.Enabled = false;
            this.textBox_pref_name.Location = new System.Drawing.Point(8, 12);
            this.textBox_pref_name.Name = "textBox_pref_name";
            this.textBox_pref_name.Size = new System.Drawing.Size(85, 20);
            this.textBox_pref_name.TabIndex = 0;
            // 
            // button_cancel
            // 
            this.button_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_cancel.Location = new System.Drawing.Point(256, 23);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(0, 0);
            this.button_cancel.TabIndex = 3;
            this.button_cancel.Text = "Отмена";
            this.button_cancel.UseVisualStyleBackColor = true;
            // 
            // FormPref
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_cancel;
            this.ClientSize = new System.Drawing.Size(294, 42);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.textBox_pref_name);
            this.Controls.Add(this.button_pref);
            this.Controls.Add(this.textBox_pref);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormPref";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавить свойство";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_pref;
        private System.Windows.Forms.Button button_pref;
        private System.Windows.Forms.TextBox textBox_pref_name;
        private System.Windows.Forms.Button button_cancel;
    }
}
namespace JummahManagement
{
    partial class AddCity
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
            this.txtAddCityName = new System.Windows.Forms.TextBox();
            this.btn_Add_City = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtAddCityName
            // 
            this.txtAddCityName.AcceptsReturn = true;
            this.txtAddCityName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddCityName.Location = new System.Drawing.Point(13, 22);
            this.txtAddCityName.Name = "txtAddCityName";
            this.txtAddCityName.Size = new System.Drawing.Size(252, 26);
            this.txtAddCityName.TabIndex = 0;
            this.txtAddCityName.Text = "Add City name";
            this.txtAddCityName.Click += new System.EventHandler(this.textBox1_Click);
            // 
            // btn_Add_City
            // 
            this.btn_Add_City.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Add_City.Location = new System.Drawing.Point(54, 54);
            this.btn_Add_City.Name = "btn_Add_City";
            this.btn_Add_City.Size = new System.Drawing.Size(149, 44);
            this.btn_Add_City.TabIndex = 1;
            this.btn_Add_City.Text = "Add Now";
            this.btn_Add_City.UseVisualStyleBackColor = true;
            this.btn_Add_City.Click += new System.EventHandler(this.btn_Add_City_Click);
            // 
            // AddCity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 110);
            this.Controls.Add(this.btn_Add_City);
            this.Controls.Add(this.txtAddCityName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddCity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddCity";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAddCityName;
        private System.Windows.Forms.Button btn_Add_City;
    }
}
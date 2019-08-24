namespace BabatyeInventory
{
    partial class main
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.TimerSlider = new System.Windows.Forms.Timer(this.components);
            this.SuggestedDhaeNames = new System.Windows.Forms.Timer(this.components);
            this.TimerShowBranches = new System.Windows.Forms.Timer(this.components);
            this.TimerShowBranches1 = new System.Windows.Forms.Timer(this.components);
            this.TimerBranchCount = new System.Windows.Forms.Timer(this.components);
            this.tblCityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.BtnInsert = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tblCityBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tblCityBindingSource
            // 
            this.tblCityBindingSource.DataMember = "tbl_City";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(40, 49);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(187, 29);
            this.textBox1.TabIndex = 0;
            // 
            // BtnInsert
            // 
            this.BtnInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnInsert.Location = new System.Drawing.Point(251, 49);
            this.BtnInsert.Name = "BtnInsert";
            this.BtnInsert.Size = new System.Drawing.Size(144, 29);
            this.BtnInsert.TabIndex = 1;
            this.BtnInsert.Text = "Insert";
            this.BtnInsert.UseVisualStyleBackColor = true;
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(435, 207);
            this.Controls.Add(this.BtnInsert);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.tblCityBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer TimerSlider;
        private System.Windows.Forms.Timer SuggestedDhaeNames;
        private System.Windows.Forms.Timer TimerShowBranches;
        private System.Windows.Forms.Timer TimerShowBranches1;
        private System.Windows.Forms.Timer TimerBranchCount;
        private System.Windows.Forms.BindingSource tblCityBindingSource;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button BtnInsert;
    }
}


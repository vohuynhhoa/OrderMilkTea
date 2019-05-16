namespace fManager
{
    partial class fIndex
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fIndex));
            this.btnclick = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // btnclick
            // 
            this.btnclick.Appearance.BackColor = System.Drawing.Color.White;
            this.btnclick.Appearance.BackColor2 = System.Drawing.Color.White;
            this.btnclick.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclick.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.btnclick.Appearance.Options.UseBackColor = true;
            this.btnclick.Appearance.Options.UseFont = true;
            this.btnclick.Appearance.Options.UseForeColor = true;
            this.btnclick.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnclick.Location = new System.Drawing.Point(201, 170);
            this.btnclick.Name = "btnclick";
            this.btnclick.Size = new System.Drawing.Size(97, 37);
            this.btnclick.TabIndex = 0;
            this.btnclick.Text = "Click here >>";
            this.btnclick.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // fIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Stretch;
            this.BackgroundImageStore = global::fManager.Properties.Resources.Fresh_and_Organic__1_;
            this.ClientSize = new System.Drawing.Size(505, 353);
            this.Controls.Add(this.btnclick);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fIndex";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Index";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fIndex_FormClosing);
            this.Load += new System.EventHandler(this.fIndex_Load);
            this.Click += new System.EventHandler(this.fIndex_Click);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnclick;
    }
}
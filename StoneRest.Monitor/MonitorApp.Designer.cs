namespace StoneRest.Monitor
{
    partial class MonitorApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonitorApp));
            this.cbOnOff = new System.Windows.Forms.CheckBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.tUpdateCities = new System.Windows.Forms.Timer(this.components);
            this.lbLast = new System.Windows.Forms.Label();
            this.txtLast = new System.Windows.Forms.TextBox();
            this.lbNext = new System.Windows.Forms.Label();
            this.txtNext = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbOnOff
            // 
            this.cbOnOff.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbOnOff.BackColor = System.Drawing.Color.Red;
            this.cbOnOff.Location = new System.Drawing.Point(312, 98);
            this.cbOnOff.Name = "cbOnOff";
            this.cbOnOff.Size = new System.Drawing.Size(211, 29);
            this.cbOnOff.TabIndex = 1;
            this.cbOnOff.Text = "Off";
            this.cbOnOff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbOnOff.UseVisualStyleBackColor = false;
            this.cbOnOff.CheckedChanged += new System.EventHandler(this.cbOnOff_CheckedChanged);
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(12, 12);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(293, 137);
            this.txtLog.TabIndex = 2;
            // 
            // tUpdateCities
            // 
            this.tUpdateCities.Tick += new System.EventHandler(this.tUpdateCities_Tick);
            // 
            // lbLast
            // 
            this.lbLast.AutoSize = true;
            this.lbLast.Location = new System.Drawing.Point(317, 49);
            this.lbLast.Name = "lbLast";
            this.lbLast.Size = new System.Drawing.Size(75, 13);
            this.lbLast.TabIndex = 3;
            this.lbLast.Text = "Último update:";
            // 
            // txtLast
            // 
            this.txtLast.Location = new System.Drawing.Point(398, 46);
            this.txtLast.Name = "txtLast";
            this.txtLast.ReadOnly = true;
            this.txtLast.Size = new System.Drawing.Size(125, 20);
            this.txtLast.TabIndex = 4;
            // 
            // lbNext
            // 
            this.lbNext.AutoSize = true;
            this.lbNext.Location = new System.Drawing.Point(309, 75);
            this.lbNext.Name = "lbNext";
            this.lbNext.Size = new System.Drawing.Size(83, 13);
            this.lbNext.TabIndex = 3;
            this.lbNext.Text = "Próximo update:";
            // 
            // txtNext
            // 
            this.txtNext.Location = new System.Drawing.Point(398, 72);
            this.txtNext.Name = "txtNext";
            this.txtNext.ReadOnly = true;
            this.txtNext.Size = new System.Drawing.Size(125, 20);
            this.txtNext.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(312, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Monitor";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(390, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "- Luiz Felipe M. Clementino";
            // 
            // MonitorApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 161);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNext);
            this.Controls.Add(this.txtLast);
            this.Controls.Add(this.lbNext);
            this.Controls.Add(this.lbLast);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.cbOnOff);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MonitorApp";
            this.Text = "StoneRest.Monitor";
            this.Load += new System.EventHandler(this.MonitorApp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbOnOff;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Timer tUpdateCities;
        private System.Windows.Forms.Label lbLast;
        private System.Windows.Forms.TextBox txtLast;
        private System.Windows.Forms.Label lbNext;
        private System.Windows.Forms.TextBox txtNext;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}


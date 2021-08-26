
namespace Combosnel
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnConnect = new System.Windows.Forms.Button();
            this.grbCPUOptions = new System.Windows.Forms.GroupBox();
            this.btnPressSelected = new System.Windows.Forms.Button();
            this.cmbButton = new System.Windows.Forms.ComboBox();
            this.nudSDIFrames = new System.Windows.Forms.NumericUpDown();
            this.nudShieldHoldTime = new System.Windows.Forms.NumericUpDown();
            this.cmbShieldType = new System.Windows.Forms.ComboBox();
            this.cmbSDIDirection = new System.Windows.Forms.ComboBox();
            this.chbShieldHold = new System.Windows.Forms.CheckBox();
            this.cmbDIDirection = new System.Windows.Forms.ComboBox();
            this.chbEnableSDI = new System.Windows.Forms.CheckBox();
            this.chbEnableDI = new System.Windows.Forms.CheckBox();
            this.grbCPUOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSDIFrames)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudShieldHoldTime)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(10, 10);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(117, 29);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect Controller";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // grbCPUOptions
            // 
            this.grbCPUOptions.BackColor = System.Drawing.SystemColors.Control;
            this.grbCPUOptions.Controls.Add(this.btnPressSelected);
            this.grbCPUOptions.Controls.Add(this.cmbButton);
            this.grbCPUOptions.Controls.Add(this.nudSDIFrames);
            this.grbCPUOptions.Controls.Add(this.nudShieldHoldTime);
            this.grbCPUOptions.Controls.Add(this.cmbShieldType);
            this.grbCPUOptions.Controls.Add(this.cmbSDIDirection);
            this.grbCPUOptions.Controls.Add(this.chbShieldHold);
            this.grbCPUOptions.Controls.Add(this.cmbDIDirection);
            this.grbCPUOptions.Controls.Add(this.chbEnableSDI);
            this.grbCPUOptions.Controls.Add(this.chbEnableDI);
            this.grbCPUOptions.Location = new System.Drawing.Point(11, 46);
            this.grbCPUOptions.Name = "grbCPUOptions";
            this.grbCPUOptions.Size = new System.Drawing.Size(353, 152);
            this.grbCPUOptions.TabIndex = 3;
            this.grbCPUOptions.TabStop = false;
            this.grbCPUOptions.Text = "CPU Options";
            // 
            // btnPressSelected
            // 
            this.btnPressSelected.Enabled = false;
            this.btnPressSelected.Location = new System.Drawing.Point(111, 127);
            this.btnPressSelected.Name = "btnPressSelected";
            this.btnPressSelected.Size = new System.Drawing.Size(128, 20);
            this.btnPressSelected.TabIndex = 17;
            this.btnPressSelected.Text = "Press Selected Button";
            this.btnPressSelected.UseVisualStyleBackColor = true;
            this.btnPressSelected.Click += new System.EventHandler(this.btnPressSelected_Click);
            // 
            // cmbButton
            // 
            this.cmbButton.Enabled = false;
            this.cmbButton.FormattingEnabled = true;
            this.cmbButton.Location = new System.Drawing.Point(244, 127);
            this.cmbButton.Name = "cmbButton";
            this.cmbButton.Size = new System.Drawing.Size(104, 21);
            this.cmbButton.TabIndex = 16;
            this.cmbButton.SelectionChangeCommitted += new System.EventHandler(this.cmbButton_SelectionChangeCommitted);
            // 
            // nudSDIFrames
            // 
            this.nudSDIFrames.Enabled = false;
            this.nudSDIFrames.Location = new System.Drawing.Point(219, 45);
            this.nudSDIFrames.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSDIFrames.Name = "nudSDIFrames";
            this.nudSDIFrames.Size = new System.Drawing.Size(103, 20);
            this.nudSDIFrames.TabIndex = 15;
            this.nudSDIFrames.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSDIFrames.ValueChanged += new System.EventHandler(this.nudSDIFrames_ValueChanged);
            // 
            // nudShieldHoldTime
            // 
            this.nudShieldHoldTime.Enabled = false;
            this.nudShieldHoldTime.Location = new System.Drawing.Point(219, 17);
            this.nudShieldHoldTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudShieldHoldTime.Name = "nudShieldHoldTime";
            this.nudShieldHoldTime.Size = new System.Drawing.Size(103, 20);
            this.nudShieldHoldTime.TabIndex = 12;
            this.nudShieldHoldTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudShieldHoldTime.ValueChanged += new System.EventHandler(this.nudShieldHoldTime_ValueChanged);
            // 
            // cmbShieldType
            // 
            this.cmbShieldType.Enabled = false;
            this.cmbShieldType.FormattingEnabled = true;
            this.cmbShieldType.Location = new System.Drawing.Point(111, 17);
            this.cmbShieldType.Name = "cmbShieldType";
            this.cmbShieldType.Size = new System.Drawing.Size(104, 21);
            this.cmbShieldType.TabIndex = 11;
            this.cmbShieldType.Text = "Shield Hold";
            this.cmbShieldType.SelectionChangeCommitted += new System.EventHandler(this.cmbShieldType_SelectionChangeCommitted);
            // 
            // cmbSDIDirection
            // 
            this.cmbSDIDirection.Enabled = false;
            this.cmbSDIDirection.FormattingEnabled = true;
            this.cmbSDIDirection.Location = new System.Drawing.Point(111, 45);
            this.cmbSDIDirection.Name = "cmbSDIDirection";
            this.cmbSDIDirection.Size = new System.Drawing.Size(104, 21);
            this.cmbSDIDirection.TabIndex = 14;
            this.cmbSDIDirection.Text = "Direction";
            this.cmbSDIDirection.SelectionChangeCommitted += new System.EventHandler(this.cmbSDIDirection_SelectionChangeCommitted);
            // 
            // chbShieldHold
            // 
            this.chbShieldHold.AutoSize = true;
            this.chbShieldHold.Enabled = false;
            this.chbShieldHold.Location = new System.Drawing.Point(5, 19);
            this.chbShieldHold.Name = "chbShieldHold";
            this.chbShieldHold.Size = new System.Drawing.Size(91, 17);
            this.chbShieldHold.TabIndex = 10;
            this.chbShieldHold.Text = "Enable Shield";
            this.chbShieldHold.UseVisualStyleBackColor = true;
            this.chbShieldHold.CheckedChanged += new System.EventHandler(this.chbShieldHold_CheckedChanged);
            // 
            // cmbDIDirection
            // 
            this.cmbDIDirection.Enabled = false;
            this.cmbDIDirection.FormattingEnabled = true;
            this.cmbDIDirection.Location = new System.Drawing.Point(111, 72);
            this.cmbDIDirection.Name = "cmbDIDirection";
            this.cmbDIDirection.Size = new System.Drawing.Size(104, 21);
            this.cmbDIDirection.TabIndex = 9;
            this.cmbDIDirection.Text = "Direction";
            this.cmbDIDirection.SelectionChangeCommitted += new System.EventHandler(this.cmbDIDirection_SelectionChangeCommitted);
            // 
            // chbEnableSDI
            // 
            this.chbEnableSDI.AutoSize = true;
            this.chbEnableSDI.Enabled = false;
            this.chbEnableSDI.Location = new System.Drawing.Point(5, 47);
            this.chbEnableSDI.Name = "chbEnableSDI";
            this.chbEnableSDI.Size = new System.Drawing.Size(80, 17);
            this.chbEnableSDI.TabIndex = 13;
            this.chbEnableSDI.Text = "Enable SDI";
            this.chbEnableSDI.UseVisualStyleBackColor = true;
            this.chbEnableSDI.CheckedChanged += new System.EventHandler(this.chbEnableSDI_CheckedChanged);
            // 
            // chbEnableDI
            // 
            this.chbEnableDI.AutoSize = true;
            this.chbEnableDI.Enabled = false;
            this.chbEnableDI.Location = new System.Drawing.Point(5, 74);
            this.chbEnableDI.Name = "chbEnableDI";
            this.chbEnableDI.Size = new System.Drawing.Size(73, 17);
            this.chbEnableDI.TabIndex = 8;
            this.chbEnableDI.Text = "Enable DI";
            this.chbEnableDI.UseVisualStyleBackColor = true;
            this.chbEnableDI.CheckedChanged += new System.EventHandler(this.chbEnableDI_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 208);
            this.Controls.Add(this.grbCPUOptions);
            this.Controls.Add(this.btnConnect);
            this.Name = "Form1";
            this.Text = "Combosnel";
            this.grbCPUOptions.ResumeLayout(false);
            this.grbCPUOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSDIFrames)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudShieldHoldTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.GroupBox grbCPUOptions;
        private System.Windows.Forms.ComboBox cmbDIDirection;
        private System.Windows.Forms.CheckBox chbEnableDI;
        private System.Windows.Forms.CheckBox chbShieldHold;
        private System.Windows.Forms.ComboBox cmbShieldType;
        private System.Windows.Forms.NumericUpDown nudShieldHoldTime;
        private System.Windows.Forms.ComboBox cmbSDIDirection;
        private System.Windows.Forms.CheckBox chbEnableSDI;
        private System.Windows.Forms.NumericUpDown nudSDIFrames;
        private System.Windows.Forms.Button btnPressSelected;
        private System.Windows.Forms.ComboBox cmbButton;
    }
}


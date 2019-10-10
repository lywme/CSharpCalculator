namespace MyCalc
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtOutBox = new System.Windows.Forms.TextBox();
            this.btnKeyMC = new System.Windows.Forms.Button();
            this.btnKeyMA = new System.Windows.Forms.Button();
            this.btnKeyMS = new System.Windows.Forms.Button();
            this.btnKeyMR = new System.Windows.Forms.Button();
            this.btnKeyMul = new System.Windows.Forms.Button();
            this.btnKeyDiv = new System.Windows.Forms.Button();
            this.btnKeySign = new System.Windows.Forms.Button();
            this.btnKeyAC = new System.Windows.Forms.Button();
            this.btnKeySub = new System.Windows.Forms.Button();
            this.btnKey9 = new System.Windows.Forms.Button();
            this.btnKey8 = new System.Windows.Forms.Button();
            this.btnKey7 = new System.Windows.Forms.Button();
            this.btnKeyPlus = new System.Windows.Forms.Button();
            this.btnKey6 = new System.Windows.Forms.Button();
            this.btnKey5 = new System.Windows.Forms.Button();
            this.btnKey4 = new System.Windows.Forms.Button();
            this.btnKey3 = new System.Windows.Forms.Button();
            this.btnKey2 = new System.Windows.Forms.Button();
            this.btnKey1 = new System.Windows.Forms.Button();
            this.btnKeyPeriod = new System.Windows.Forms.Button();
            this.btnKey0 = new System.Windows.Forms.Button();
            this.btnKeyResult = new System.Windows.Forms.Button();
            this.lblMemoryFlag = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.测批量测试用例测试ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于MyCalclatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtOutBox
            // 
            this.txtOutBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtOutBox.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutBox.Location = new System.Drawing.Point(14, 38);
            this.txtOutBox.Name = "txtOutBox";
            this.txtOutBox.ShortcutsEnabled = false;
            this.txtOutBox.Size = new System.Drawing.Size(254, 29);
            this.txtOutBox.TabIndex = 0;
            this.txtOutBox.TabStop = false;
            this.txtOutBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnKeyMC
            // 
            this.btnKeyMC.CausesValidation = false;
            this.btnKeyMC.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKeyMC.Location = new System.Drawing.Point(14, 80);
            this.btnKeyMC.Name = "btnKeyMC";
            this.btnKeyMC.Size = new System.Drawing.Size(50, 23);
            this.btnKeyMC.TabIndex = 1;
            this.btnKeyMC.TabStop = false;
            this.btnKeyMC.Text = "MC";
            this.btnKeyMC.UseVisualStyleBackColor = true;
            this.btnKeyMC.Click += new System.EventHandler(this.btnKeyMC_Click);
            // 
            // btnKeyMA
            // 
            this.btnKeyMA.CausesValidation = false;
            this.btnKeyMA.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKeyMA.Location = new System.Drawing.Point(82, 80);
            this.btnKeyMA.Name = "btnKeyMA";
            this.btnKeyMA.Size = new System.Drawing.Size(50, 23);
            this.btnKeyMA.TabIndex = 2;
            this.btnKeyMA.TabStop = false;
            this.btnKeyMA.Text = "M+";
            this.btnKeyMA.UseVisualStyleBackColor = true;
            this.btnKeyMA.Click += new System.EventHandler(this.btnKeyMA_Click);
            // 
            // btnKeyMS
            // 
            this.btnKeyMS.CausesValidation = false;
            this.btnKeyMS.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKeyMS.Location = new System.Drawing.Point(150, 80);
            this.btnKeyMS.Name = "btnKeyMS";
            this.btnKeyMS.Size = new System.Drawing.Size(50, 23);
            this.btnKeyMS.TabIndex = 3;
            this.btnKeyMS.TabStop = false;
            this.btnKeyMS.Text = "M-";
            this.btnKeyMS.UseVisualStyleBackColor = true;
            this.btnKeyMS.Click += new System.EventHandler(this.btnKeyMS_Click);
            // 
            // btnKeyMR
            // 
            this.btnKeyMR.CausesValidation = false;
            this.btnKeyMR.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKeyMR.Location = new System.Drawing.Point(218, 80);
            this.btnKeyMR.Name = "btnKeyMR";
            this.btnKeyMR.Size = new System.Drawing.Size(50, 23);
            this.btnKeyMR.TabIndex = 4;
            this.btnKeyMR.TabStop = false;
            this.btnKeyMR.Text = "MR";
            this.btnKeyMR.UseVisualStyleBackColor = true;
            this.btnKeyMR.Click += new System.EventHandler(this.btnKeyMR_Click);
            // 
            // btnKeyMul
            // 
            this.btnKeyMul.CausesValidation = false;
            this.btnKeyMul.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKeyMul.Location = new System.Drawing.Point(218, 110);
            this.btnKeyMul.Name = "btnKeyMul";
            this.btnKeyMul.Size = new System.Drawing.Size(50, 23);
            this.btnKeyMul.TabIndex = 8;
            this.btnKeyMul.TabStop = false;
            this.btnKeyMul.Text = "x";
            this.btnKeyMul.UseVisualStyleBackColor = true;
            this.btnKeyMul.Click += new System.EventHandler(this.btnKeyMul_Click);
            // 
            // btnKeyDiv
            // 
            this.btnKeyDiv.CausesValidation = false;
            this.btnKeyDiv.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKeyDiv.Location = new System.Drawing.Point(150, 110);
            this.btnKeyDiv.Name = "btnKeyDiv";
            this.btnKeyDiv.Size = new System.Drawing.Size(50, 23);
            this.btnKeyDiv.TabIndex = 7;
            this.btnKeyDiv.TabStop = false;
            this.btnKeyDiv.Text = "/";
            this.btnKeyDiv.UseVisualStyleBackColor = true;
            this.btnKeyDiv.Click += new System.EventHandler(this.btnKeyDiv_Click);
            // 
            // btnKeySign
            // 
            this.btnKeySign.CausesValidation = false;
            this.btnKeySign.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKeySign.Location = new System.Drawing.Point(82, 110);
            this.btnKeySign.Name = "btnKeySign";
            this.btnKeySign.Size = new System.Drawing.Size(50, 23);
            this.btnKeySign.TabIndex = 6;
            this.btnKeySign.TabStop = false;
            this.btnKeySign.Text = "+/-";
            this.btnKeySign.UseVisualStyleBackColor = true;
            this.btnKeySign.Click += new System.EventHandler(this.btnKeySign_Click);
            // 
            // btnKeyAC
            // 
            this.btnKeyAC.CausesValidation = false;
            this.btnKeyAC.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKeyAC.Location = new System.Drawing.Point(14, 110);
            this.btnKeyAC.Name = "btnKeyAC";
            this.btnKeyAC.Size = new System.Drawing.Size(50, 23);
            this.btnKeyAC.TabIndex = 5;
            this.btnKeyAC.TabStop = false;
            this.btnKeyAC.Text = "AC";
            this.btnKeyAC.UseVisualStyleBackColor = true;
            this.btnKeyAC.Click += new System.EventHandler(this.btnKeyAC_Click);
            // 
            // btnKeySub
            // 
            this.btnKeySub.CausesValidation = false;
            this.btnKeySub.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKeySub.Location = new System.Drawing.Point(218, 139);
            this.btnKeySub.Name = "btnKeySub";
            this.btnKeySub.Size = new System.Drawing.Size(50, 23);
            this.btnKeySub.TabIndex = 12;
            this.btnKeySub.TabStop = false;
            this.btnKeySub.Text = "-";
            this.btnKeySub.UseVisualStyleBackColor = true;
            this.btnKeySub.Click += new System.EventHandler(this.btnKeySub_Click);
            // 
            // btnKey9
            // 
            this.btnKey9.CausesValidation = false;
            this.btnKey9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKey9.Location = new System.Drawing.Point(150, 139);
            this.btnKey9.Name = "btnKey9";
            this.btnKey9.Size = new System.Drawing.Size(50, 23);
            this.btnKey9.TabIndex = 11;
            this.btnKey9.TabStop = false;
            this.btnKey9.Text = "9";
            this.btnKey9.UseVisualStyleBackColor = true;
            this.btnKey9.Click += new System.EventHandler(this.btnKey9_Click);
            // 
            // btnKey8
            // 
            this.btnKey8.CausesValidation = false;
            this.btnKey8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKey8.Location = new System.Drawing.Point(82, 139);
            this.btnKey8.Name = "btnKey8";
            this.btnKey8.Size = new System.Drawing.Size(50, 23);
            this.btnKey8.TabIndex = 10;
            this.btnKey8.TabStop = false;
            this.btnKey8.Text = "8";
            this.btnKey8.UseVisualStyleBackColor = true;
            this.btnKey8.Click += new System.EventHandler(this.btnKey8_Click);
            // 
            // btnKey7
            // 
            this.btnKey7.CausesValidation = false;
            this.btnKey7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKey7.Location = new System.Drawing.Point(14, 139);
            this.btnKey7.Name = "btnKey7";
            this.btnKey7.Size = new System.Drawing.Size(50, 23);
            this.btnKey7.TabIndex = 9;
            this.btnKey7.TabStop = false;
            this.btnKey7.Text = "7";
            this.btnKey7.UseVisualStyleBackColor = true;
            this.btnKey7.Click += new System.EventHandler(this.btnKey7_Click);
            // 
            // btnKeyPlus
            // 
            this.btnKeyPlus.CausesValidation = false;
            this.btnKeyPlus.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKeyPlus.Location = new System.Drawing.Point(218, 170);
            this.btnKeyPlus.Name = "btnKeyPlus";
            this.btnKeyPlus.Size = new System.Drawing.Size(50, 23);
            this.btnKeyPlus.TabIndex = 16;
            this.btnKeyPlus.TabStop = false;
            this.btnKeyPlus.Text = "+";
            this.btnKeyPlus.UseVisualStyleBackColor = true;
            this.btnKeyPlus.Click += new System.EventHandler(this.btnKeyPlus_Click);
            // 
            // btnKey6
            // 
            this.btnKey6.CausesValidation = false;
            this.btnKey6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKey6.Location = new System.Drawing.Point(150, 170);
            this.btnKey6.Name = "btnKey6";
            this.btnKey6.Size = new System.Drawing.Size(50, 23);
            this.btnKey6.TabIndex = 15;
            this.btnKey6.TabStop = false;
            this.btnKey6.Text = "6";
            this.btnKey6.UseVisualStyleBackColor = true;
            this.btnKey6.Click += new System.EventHandler(this.btnKey6_Click);
            // 
            // btnKey5
            // 
            this.btnKey5.CausesValidation = false;
            this.btnKey5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKey5.Location = new System.Drawing.Point(82, 170);
            this.btnKey5.Name = "btnKey5";
            this.btnKey5.Size = new System.Drawing.Size(50, 23);
            this.btnKey5.TabIndex = 14;
            this.btnKey5.TabStop = false;
            this.btnKey5.Text = "5";
            this.btnKey5.UseVisualStyleBackColor = true;
            this.btnKey5.Click += new System.EventHandler(this.btnKey5_Click);
            // 
            // btnKey4
            // 
            this.btnKey4.CausesValidation = false;
            this.btnKey4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKey4.Location = new System.Drawing.Point(14, 170);
            this.btnKey4.Name = "btnKey4";
            this.btnKey4.Size = new System.Drawing.Size(50, 23);
            this.btnKey4.TabIndex = 13;
            this.btnKey4.TabStop = false;
            this.btnKey4.Text = "4";
            this.btnKey4.UseVisualStyleBackColor = true;
            this.btnKey4.Click += new System.EventHandler(this.btnKey4_Click);
            // 
            // btnKey3
            // 
            this.btnKey3.CausesValidation = false;
            this.btnKey3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKey3.Location = new System.Drawing.Point(150, 200);
            this.btnKey3.Name = "btnKey3";
            this.btnKey3.Size = new System.Drawing.Size(50, 23);
            this.btnKey3.TabIndex = 19;
            this.btnKey3.TabStop = false;
            this.btnKey3.Text = "3";
            this.btnKey3.UseVisualStyleBackColor = true;
            this.btnKey3.Click += new System.EventHandler(this.btnKey3_Click);
            // 
            // btnKey2
            // 
            this.btnKey2.CausesValidation = false;
            this.btnKey2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKey2.Location = new System.Drawing.Point(82, 200);
            this.btnKey2.Name = "btnKey2";
            this.btnKey2.Size = new System.Drawing.Size(50, 23);
            this.btnKey2.TabIndex = 18;
            this.btnKey2.TabStop = false;
            this.btnKey2.Text = "2";
            this.btnKey2.UseVisualStyleBackColor = true;
            this.btnKey2.Click += new System.EventHandler(this.btnKey2_Click);
            // 
            // btnKey1
            // 
            this.btnKey1.CausesValidation = false;
            this.btnKey1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKey1.Location = new System.Drawing.Point(14, 200);
            this.btnKey1.Name = "btnKey1";
            this.btnKey1.Size = new System.Drawing.Size(50, 23);
            this.btnKey1.TabIndex = 17;
            this.btnKey1.TabStop = false;
            this.btnKey1.Text = "1";
            this.btnKey1.UseVisualStyleBackColor = true;
            this.btnKey1.Click += new System.EventHandler(this.btnKey1_Click);
            // 
            // btnKeyPeriod
            // 
            this.btnKeyPeriod.CausesValidation = false;
            this.btnKeyPeriod.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKeyPeriod.Location = new System.Drawing.Point(150, 230);
            this.btnKeyPeriod.Name = "btnKeyPeriod";
            this.btnKeyPeriod.Size = new System.Drawing.Size(50, 23);
            this.btnKeyPeriod.TabIndex = 21;
            this.btnKeyPeriod.TabStop = false;
            this.btnKeyPeriod.Text = ".";
            this.btnKeyPeriod.UseVisualStyleBackColor = true;
            this.btnKeyPeriod.Click += new System.EventHandler(this.btnKeyPeriod_Click);
            // 
            // btnKey0
            // 
            this.btnKey0.CausesValidation = false;
            this.btnKey0.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKey0.Location = new System.Drawing.Point(14, 230);
            this.btnKey0.Name = "btnKey0";
            this.btnKey0.Size = new System.Drawing.Size(118, 23);
            this.btnKey0.TabIndex = 20;
            this.btnKey0.TabStop = false;
            this.btnKey0.Text = "   0";
            this.btnKey0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKey0.UseVisualStyleBackColor = true;
            this.btnKey0.Click += new System.EventHandler(this.btnKey0_Click);
            // 
            // btnKeyResult
            // 
            this.btnKeyResult.CausesValidation = false;
            this.btnKeyResult.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKeyResult.Location = new System.Drawing.Point(218, 200);
            this.btnKeyResult.Name = "btnKeyResult";
            this.btnKeyResult.Size = new System.Drawing.Size(50, 53);
            this.btnKeyResult.TabIndex = 22;
            this.btnKeyResult.TabStop = false;
            this.btnKeyResult.Text = "=";
            this.btnKeyResult.UseVisualStyleBackColor = true;
            this.btnKeyResult.Click += new System.EventHandler(this.btnKeyResult_Click);
            // 
            // lblMemoryFlag
            // 
            this.lblMemoryFlag.AutoSize = true;
            this.lblMemoryFlag.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lblMemoryFlag.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemoryFlag.Location = new System.Drawing.Point(17, 45);
            this.lblMemoryFlag.Name = "lblMemoryFlag";
            this.lblMemoryFlag.Size = new System.Drawing.Size(0, 16);
            this.lblMemoryFlag.TabIndex = 23;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件FToolStripMenuItem,
            this.关于AToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(282, 24);
            this.menuStrip1.TabIndex = 24;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件FToolStripMenuItem
            // 
            this.文件FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.测批量测试用例测试ToolStripMenuItem});
            this.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem";
            this.文件FToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.文件FToolStripMenuItem.Text = "文件(&F)";
            // 
            // 测批量测试用例测试ToolStripMenuItem
            // 
            this.测批量测试用例测试ToolStripMenuItem.Name = "测批量测试用例测试ToolStripMenuItem";
            this.测批量测试用例测试ToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.测批量测试用例测试ToolStripMenuItem.Text = "测批量测试用例测试...";
            this.测批量测试用例测试ToolStripMenuItem.Click += new System.EventHandler(this.测批量测试用例测试ToolStripMenuItem_Click);
            // 
            // 关于AToolStripMenuItem
            // 
            this.关于AToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于ToolStripMenuItem,
            this.关于MyCalclatorToolStripMenuItem});
            this.关于AToolStripMenuItem.Name = "关于AToolStripMenuItem";
            this.关于AToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.关于AToolStripMenuItem.Text = "关于(&A)";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.关于ToolStripMenuItem.Text = "外部批量计算文件格式说明...";
            // 
            // 关于MyCalclatorToolStripMenuItem
            // 
            this.关于MyCalclatorToolStripMenuItem.Name = "关于MyCalclatorToolStripMenuItem";
            this.关于MyCalclatorToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.关于MyCalclatorToolStripMenuItem.Text = "关于MyCaculator...";
            this.关于MyCalclatorToolStripMenuItem.Click += new System.EventHandler(this.关于MyCalclatorToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(282, 266);
            this.Controls.Add(this.lblMemoryFlag);
            this.Controls.Add(this.btnKeyResult);
            this.Controls.Add(this.btnKeyPeriod);
            this.Controls.Add(this.btnKey0);
            this.Controls.Add(this.btnKey3);
            this.Controls.Add(this.btnKey2);
            this.Controls.Add(this.btnKey1);
            this.Controls.Add(this.btnKeyPlus);
            this.Controls.Add(this.btnKey6);
            this.Controls.Add(this.btnKey5);
            this.Controls.Add(this.btnKey4);
            this.Controls.Add(this.btnKeySub);
            this.Controls.Add(this.btnKey9);
            this.Controls.Add(this.btnKey8);
            this.Controls.Add(this.btnKey7);
            this.Controls.Add(this.btnKeyMul);
            this.Controls.Add(this.btnKeyDiv);
            this.Controls.Add(this.btnKeySign);
            this.Controls.Add(this.btnKeyAC);
            this.Controls.Add(this.btnKeyMR);
            this.Controls.Add(this.btnKeyMS);
            this.Controls.Add(this.btnKeyMA);
            this.Controls.Add(this.btnKeyMC);
            this.Controls.Add(this.txtOutBox);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Caculator By Lyw!";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOutBox;
        private System.Windows.Forms.Button btnKeyMC;
        private System.Windows.Forms.Button btnKeyMA;
        private System.Windows.Forms.Button btnKeyMS;
        private System.Windows.Forms.Button btnKeyMR;
        private System.Windows.Forms.Button btnKeyMul;
        private System.Windows.Forms.Button btnKeyDiv;
        private System.Windows.Forms.Button btnKeySign;
        private System.Windows.Forms.Button btnKeyAC;
        private System.Windows.Forms.Button btnKeySub;
        private System.Windows.Forms.Button btnKey9;
        private System.Windows.Forms.Button btnKey8;
        private System.Windows.Forms.Button btnKey7;
        private System.Windows.Forms.Button btnKeyPlus;
        private System.Windows.Forms.Button btnKey6;
        private System.Windows.Forms.Button btnKey5;
        private System.Windows.Forms.Button btnKey4;
        private System.Windows.Forms.Button btnKey3;
        private System.Windows.Forms.Button btnKey2;
        private System.Windows.Forms.Button btnKey1;
        private System.Windows.Forms.Button btnKeyPeriod;
        private System.Windows.Forms.Button btnKey0;
        private System.Windows.Forms.Button btnKeyResult;
        private System.Windows.Forms.Label lblMemoryFlag;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于AToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于MyCalclatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 测批量测试用例测试ToolStripMenuItem;
    }
}


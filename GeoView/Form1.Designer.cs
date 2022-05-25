namespace GeoView
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.UIPanel = new System.Windows.Forms.Panel();
            this.PointsColor = new System.Windows.Forms.Button();
            this.SurfaceColor = new System.Windows.Forms.Button();
            this.MeshColor = new System.Windows.Forms.Button();
            this.labelAlpha = new System.Windows.Forms.Label();
            this.labelTransparency = new System.Windows.Forms.Label();
            this.trackBarTransparency = new System.Windows.Forms.TrackBar();
            this.checkBoxColoring = new System.Windows.Forms.CheckBox();
            this.labelOriginPos = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.trackBarZOriginPos = new System.Windows.Forms.TrackBar();
            this.trackBarYOriginPos = new System.Windows.Forms.TrackBar();
            this.trackBarXOriginPos = new System.Windows.Forms.TrackBar();
            this.checkBox_lightning = new System.Windows.Forms.CheckBox();
            this.labelScaling = new System.Windows.Forms.Label();
            this.labelView = new System.Windows.Forms.Label();
            this.labelZ = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.labelX = new System.Windows.Forms.Label();
            this.trackBarZScale = new System.Windows.Forms.TrackBar();
            this.trackBarYScale = new System.Windows.Forms.TrackBar();
            this.trackBarXScale = new System.Windows.Forms.TrackBar();
            this.labelPhi = new System.Windows.Forms.Label();
            this.labelPsi = new System.Windows.Forms.Label();
            this.labelR = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.OpenFile = new System.Windows.Forms.Button();
            this.trackBarPsi = new System.Windows.Forms.TrackBar();
            this.trackBarPhi = new System.Windows.Forms.TrackBar();
            this.trackBarR = new System.Windows.Forms.TrackBar();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.TextureLoad = new System.Windows.Forms.Button();
            this.checkBoxTexture = new System.Windows.Forms.CheckBox();
            this.UIPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTransparency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZOriginPos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarYOriginPos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarXOriginPos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarYScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarXScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPsi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPhi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarR)).BeginInit();
            this.SuspendLayout();
            // 
            // UIPanel
            // 
            this.UIPanel.Controls.Add(this.checkBoxTexture);
            this.UIPanel.Controls.Add(this.TextureLoad);
            this.UIPanel.Controls.Add(this.PointsColor);
            this.UIPanel.Controls.Add(this.SurfaceColor);
            this.UIPanel.Controls.Add(this.MeshColor);
            this.UIPanel.Controls.Add(this.labelAlpha);
            this.UIPanel.Controls.Add(this.labelTransparency);
            this.UIPanel.Controls.Add(this.trackBarTransparency);
            this.UIPanel.Controls.Add(this.checkBoxColoring);
            this.UIPanel.Controls.Add(this.labelOriginPos);
            this.UIPanel.Controls.Add(this.label2);
            this.UIPanel.Controls.Add(this.label3);
            this.UIPanel.Controls.Add(this.label4);
            this.UIPanel.Controls.Add(this.trackBarZOriginPos);
            this.UIPanel.Controls.Add(this.trackBarYOriginPos);
            this.UIPanel.Controls.Add(this.trackBarXOriginPos);
            this.UIPanel.Controls.Add(this.checkBox_lightning);
            this.UIPanel.Controls.Add(this.labelScaling);
            this.UIPanel.Controls.Add(this.labelView);
            this.UIPanel.Controls.Add(this.labelZ);
            this.UIPanel.Controls.Add(this.labelY);
            this.UIPanel.Controls.Add(this.labelX);
            this.UIPanel.Controls.Add(this.trackBarZScale);
            this.UIPanel.Controls.Add(this.trackBarYScale);
            this.UIPanel.Controls.Add(this.trackBarXScale);
            this.UIPanel.Controls.Add(this.labelPhi);
            this.UIPanel.Controls.Add(this.labelPsi);
            this.UIPanel.Controls.Add(this.labelR);
            this.UIPanel.Controls.Add(this.comboBox1);
            this.UIPanel.Controls.Add(this.OpenFile);
            this.UIPanel.Controls.Add(this.trackBarPsi);
            this.UIPanel.Controls.Add(this.trackBarPhi);
            this.UIPanel.Controls.Add(this.trackBarR);
            this.UIPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.UIPanel.Location = new System.Drawing.Point(1019, 0);
            this.UIPanel.Name = "UIPanel";
            this.UIPanel.Size = new System.Drawing.Size(200, 800);
            this.UIPanel.TabIndex = 0;
            // 
            // PointsColor
            // 
            this.PointsColor.Location = new System.Drawing.Point(11, 616);
            this.PointsColor.Name = "PointsColor";
            this.PointsColor.Size = new System.Drawing.Size(185, 23);
            this.PointsColor.TabIndex = 32;
            this.PointsColor.Text = "Select points color";
            this.PointsColor.UseVisualStyleBackColor = true;
            this.PointsColor.Click += new System.EventHandler(this.PointsColor_Click);
            // 
            // SurfaceColor
            // 
            this.SurfaceColor.Location = new System.Drawing.Point(11, 674);
            this.SurfaceColor.Name = "SurfaceColor";
            this.SurfaceColor.Size = new System.Drawing.Size(185, 23);
            this.SurfaceColor.TabIndex = 31;
            this.SurfaceColor.Text = "Select surface color";
            this.SurfaceColor.UseVisualStyleBackColor = true;
            this.SurfaceColor.Click += new System.EventHandler(this.SurfaceColor_Click);
            // 
            // MeshColor
            // 
            this.MeshColor.Location = new System.Drawing.Point(11, 645);
            this.MeshColor.Name = "MeshColor";
            this.MeshColor.Size = new System.Drawing.Size(185, 23);
            this.MeshColor.TabIndex = 30;
            this.MeshColor.Text = "Select mesh color";
            this.MeshColor.UseVisualStyleBackColor = true;
            this.MeshColor.Click += new System.EventHandler(this.MeshColor_Click);
            // 
            // labelAlpha
            // 
            this.labelAlpha.AutoSize = true;
            this.labelAlpha.Location = new System.Drawing.Point(9, 575);
            this.labelAlpha.Name = "labelAlpha";
            this.labelAlpha.Size = new System.Drawing.Size(14, 13);
            this.labelAlpha.TabIndex = 28;
            this.labelAlpha.Text = "A";
            // 
            // labelTransparency
            // 
            this.labelTransparency.AutoSize = true;
            this.labelTransparency.Location = new System.Drawing.Point(33, 549);
            this.labelTransparency.Name = "labelTransparency";
            this.labelTransparency.Size = new System.Drawing.Size(72, 13);
            this.labelTransparency.TabIndex = 27;
            this.labelTransparency.Text = "Transparency";
            // 
            // trackBarTransparency
            // 
            this.trackBarTransparency.Location = new System.Drawing.Point(29, 566);
            this.trackBarTransparency.Name = "trackBarTransparency";
            this.trackBarTransparency.Size = new System.Drawing.Size(168, 45);
            this.trackBarTransparency.TabIndex = 26;
            this.trackBarTransparency.TickFrequency = 10;
            this.trackBarTransparency.Value = 10;
            this.trackBarTransparency.Scroll += new System.EventHandler(this.trackBarTransparency_Scroll);
            // 
            // checkBoxColoring
            // 
            this.checkBoxColoring.AutoSize = true;
            this.checkBoxColoring.Location = new System.Drawing.Point(12, 775);
            this.checkBoxColoring.Name = "checkBoxColoring";
            this.checkBoxColoring.Size = new System.Drawing.Size(64, 17);
            this.checkBoxColoring.TabIndex = 25;
            this.checkBoxColoring.Text = "Coloring";
            this.checkBoxColoring.UseVisualStyleBackColor = true;
            this.checkBoxColoring.CheckedChanged += new System.EventHandler(this.checkBoxColoring_CheckedChanged);
            // 
            // labelOriginPos
            // 
            this.labelOriginPos.AutoSize = true;
            this.labelOriginPos.Location = new System.Drawing.Point(26, 383);
            this.labelOriginPos.Name = "labelOriginPos";
            this.labelOriginPos.Size = new System.Drawing.Size(73, 13);
            this.labelOriginPos.TabIndex = 24;
            this.labelOriginPos.Text = "Origin position";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 511);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Z";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 461);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Y";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 412);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "X";
            // 
            // trackBarZOriginPos
            // 
            this.trackBarZOriginPos.Location = new System.Drawing.Point(29, 501);
            this.trackBarZOriginPos.Minimum = -10;
            this.trackBarZOriginPos.Name = "trackBarZOriginPos";
            this.trackBarZOriginPos.Size = new System.Drawing.Size(168, 45);
            this.trackBarZOriginPos.TabIndex = 20;
            this.trackBarZOriginPos.Scroll += new System.EventHandler(this.trackBarZOriginPos_Scroll);
            // 
            // trackBarYOriginPos
            // 
            this.trackBarYOriginPos.Location = new System.Drawing.Point(29, 450);
            this.trackBarYOriginPos.Minimum = -10;
            this.trackBarYOriginPos.Name = "trackBarYOriginPos";
            this.trackBarYOriginPos.Size = new System.Drawing.Size(168, 45);
            this.trackBarYOriginPos.TabIndex = 19;
            this.trackBarYOriginPos.Scroll += new System.EventHandler(this.trackBarYOriginPos_Scroll);
            // 
            // trackBarXOriginPos
            // 
            this.trackBarXOriginPos.Location = new System.Drawing.Point(29, 399);
            this.trackBarXOriginPos.Minimum = -10;
            this.trackBarXOriginPos.Name = "trackBarXOriginPos";
            this.trackBarXOriginPos.Size = new System.Drawing.Size(168, 45);
            this.trackBarXOriginPos.TabIndex = 18;
            this.trackBarXOriginPos.Scroll += new System.EventHandler(this.trackBarXOriginPos_Scroll);
            // 
            // checkBox_lightning
            // 
            this.checkBox_lightning.AutoSize = true;
            this.checkBox_lightning.Location = new System.Drawing.Point(12, 752);
            this.checkBox_lightning.Name = "checkBox_lightning";
            this.checkBox_lightning.Size = new System.Drawing.Size(69, 17);
            this.checkBox_lightning.TabIndex = 17;
            this.checkBox_lightning.Text = "Lightning";
            this.checkBox_lightning.UseVisualStyleBackColor = true;
            this.checkBox_lightning.CheckedChanged += new System.EventHandler(this.checkBox_lightning_CheckedChanged);
            // 
            // labelScaling
            // 
            this.labelScaling.AutoSize = true;
            this.labelScaling.Location = new System.Drawing.Point(26, 201);
            this.labelScaling.Name = "labelScaling";
            this.labelScaling.Size = new System.Drawing.Size(42, 13);
            this.labelScaling.TabIndex = 16;
            this.labelScaling.Text = "Scaling";
            // 
            // labelView
            // 
            this.labelView.AutoSize = true;
            this.labelView.Location = new System.Drawing.Point(26, 34);
            this.labelView.Name = "labelView";
            this.labelView.Size = new System.Drawing.Size(30, 13);
            this.labelView.TabIndex = 15;
            this.labelView.Text = "View";
            // 
            // labelZ
            // 
            this.labelZ.AutoSize = true;
            this.labelZ.Location = new System.Drawing.Point(9, 329);
            this.labelZ.Name = "labelZ";
            this.labelZ.Size = new System.Drawing.Size(14, 13);
            this.labelZ.TabIndex = 14;
            this.labelZ.Text = "Z";
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(9, 279);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(14, 13);
            this.labelY.TabIndex = 13;
            this.labelY.Text = "Y";
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(9, 230);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(14, 13);
            this.labelX.TabIndex = 12;
            this.labelX.Text = "X";
            // 
            // trackBarZScale
            // 
            this.trackBarZScale.Location = new System.Drawing.Point(29, 319);
            this.trackBarZScale.Maximum = 100;
            this.trackBarZScale.Name = "trackBarZScale";
            this.trackBarZScale.Size = new System.Drawing.Size(168, 45);
            this.trackBarZScale.TabIndex = 11;
            this.trackBarZScale.Value = 10;
            this.trackBarZScale.Scroll += new System.EventHandler(this.trackBarZScale_Scroll);
            // 
            // trackBarYScale
            // 
            this.trackBarYScale.Location = new System.Drawing.Point(29, 268);
            this.trackBarYScale.Maximum = 100;
            this.trackBarYScale.Name = "trackBarYScale";
            this.trackBarYScale.Size = new System.Drawing.Size(168, 45);
            this.trackBarYScale.TabIndex = 10;
            this.trackBarYScale.Value = 10;
            this.trackBarYScale.Scroll += new System.EventHandler(this.trackBarYScale_Scroll);
            // 
            // trackBarXScale
            // 
            this.trackBarXScale.Location = new System.Drawing.Point(29, 217);
            this.trackBarXScale.Maximum = 100;
            this.trackBarXScale.Name = "trackBarXScale";
            this.trackBarXScale.Size = new System.Drawing.Size(168, 45);
            this.trackBarXScale.TabIndex = 9;
            this.trackBarXScale.Value = 10;
            this.trackBarXScale.Scroll += new System.EventHandler(this.trackBarXScale_Scroll);
            // 
            // labelPhi
            // 
            this.labelPhi.AutoSize = true;
            this.labelPhi.Location = new System.Drawing.Point(8, 163);
            this.labelPhi.Name = "labelPhi";
            this.labelPhi.Size = new System.Drawing.Size(22, 13);
            this.labelPhi.TabIndex = 8;
            this.labelPhi.Text = "Phi";
            // 
            // labelPsi
            // 
            this.labelPsi.AutoSize = true;
            this.labelPsi.Location = new System.Drawing.Point(8, 112);
            this.labelPsi.Name = "labelPsi";
            this.labelPsi.Size = new System.Drawing.Size(21, 13);
            this.labelPsi.TabIndex = 7;
            this.labelPsi.Text = "Psi";
            // 
            // labelR
            // 
            this.labelR.AutoSize = true;
            this.labelR.Location = new System.Drawing.Point(8, 60);
            this.labelR.Name = "labelR";
            this.labelR.Size = new System.Drawing.Size(15, 13);
            this.labelR.TabIndex = 6;
            this.labelR.Text = "R";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Points",
            "Mesh",
            "Surface",
            "Surface and mesh"});
            this.comboBox1.Location = new System.Drawing.Point(108, 5);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(89, 21);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // OpenFile
            // 
            this.OpenFile.Location = new System.Drawing.Point(3, 3);
            this.OpenFile.Name = "OpenFile";
            this.OpenFile.Size = new System.Drawing.Size(89, 23);
            this.OpenFile.TabIndex = 3;
            this.OpenFile.Text = "File..";
            this.OpenFile.UseVisualStyleBackColor = true;
            this.OpenFile.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // trackBarPsi
            // 
            this.trackBarPsi.Location = new System.Drawing.Point(29, 152);
            this.trackBarPsi.Maximum = 360;
            this.trackBarPsi.Name = "trackBarPsi";
            this.trackBarPsi.Size = new System.Drawing.Size(168, 45);
            this.trackBarPsi.TabIndex = 2;
            this.trackBarPsi.TickFrequency = 10;
            this.trackBarPsi.Value = 30;
            this.trackBarPsi.Scroll += new System.EventHandler(this.trackBarPsi_Scroll);
            // 
            // trackBarPhi
            // 
            this.trackBarPhi.Location = new System.Drawing.Point(29, 101);
            this.trackBarPhi.Maximum = 90;
            this.trackBarPhi.Minimum = -90;
            this.trackBarPhi.Name = "trackBarPhi";
            this.trackBarPhi.Size = new System.Drawing.Size(168, 45);
            this.trackBarPhi.TabIndex = 1;
            this.trackBarPhi.TickFrequency = 10;
            this.trackBarPhi.Value = 30;
            this.trackBarPhi.Scroll += new System.EventHandler(this.trackBarPhi_Scroll);
            // 
            // trackBarR
            // 
            this.trackBarR.Location = new System.Drawing.Point(29, 50);
            this.trackBarR.Maximum = 100;
            this.trackBarR.Name = "trackBarR";
            this.trackBarR.Size = new System.Drawing.Size(168, 45);
            this.trackBarR.TabIndex = 0;
            this.trackBarR.TickFrequency = 10;
            this.trackBarR.Value = 10;
            this.trackBarR.Scroll += new System.EventHandler(this.trackBarR_Scroll);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // TextureLoad
            // 
            this.TextureLoad.Location = new System.Drawing.Point(94, 727);
            this.TextureLoad.Name = "TextureLoad";
            this.TextureLoad.Size = new System.Drawing.Size(75, 23);
            this.TextureLoad.TabIndex = 33;
            this.TextureLoad.Text = "Load texture";
            this.TextureLoad.UseVisualStyleBackColor = true;
            this.TextureLoad.Click += new System.EventHandler(this.TextureLoad_Click);
            // 
            // checkBoxTexture
            // 
            this.checkBoxTexture.AutoSize = true;
            this.checkBoxTexture.Location = new System.Drawing.Point(12, 729);
            this.checkBoxTexture.Name = "checkBoxTexture";
            this.checkBoxTexture.Size = new System.Drawing.Size(62, 17);
            this.checkBoxTexture.TabIndex = 34;
            this.checkBoxTexture.Text = "Texture";
            this.checkBoxTexture.UseVisualStyleBackColor = true;
            this.checkBoxTexture.CheckedChanged += new System.EventHandler(this.checkBoxTexture_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1219, 800);
            this.Controls.Add(this.UIPanel);
            this.Name = "Form1";
            this.Text = "GeoView";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.UIPanel.ResumeLayout(false);
            this.UIPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTransparency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZOriginPos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarYOriginPos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarXOriginPos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarYScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarXScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPsi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPhi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarR)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel UIPanel;
        private System.Windows.Forms.TrackBar trackBarPsi;
        private System.Windows.Forms.TrackBar trackBarPhi;
        private System.Windows.Forms.TrackBar trackBarR;
        private System.Windows.Forms.Button OpenFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label labelScaling;
        private System.Windows.Forms.Label labelView;
        private System.Windows.Forms.Label labelZ;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.TrackBar trackBarZScale;
        private System.Windows.Forms.TrackBar trackBarYScale;
        private System.Windows.Forms.TrackBar trackBarXScale;
        private System.Windows.Forms.Label labelPhi;
        private System.Windows.Forms.Label labelPsi;
        private System.Windows.Forms.Label labelR;
        private System.Windows.Forms.CheckBox checkBox_lightning;
        private System.Windows.Forms.Label labelOriginPos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar trackBarZOriginPos;
        private System.Windows.Forms.TrackBar trackBarYOriginPos;
        private System.Windows.Forms.TrackBar trackBarXOriginPos;
        private System.Windows.Forms.CheckBox checkBoxColoring;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Label labelAlpha;
        private System.Windows.Forms.Label labelTransparency;
        private System.Windows.Forms.TrackBar trackBarTransparency;
        private System.Windows.Forms.Button PointsColor;
        private System.Windows.Forms.Button SurfaceColor;
        private System.Windows.Forms.Button MeshColor;
        private System.Windows.Forms.Button TextureLoad;
        private System.Windows.Forms.CheckBox checkBoxTexture;
    }
}


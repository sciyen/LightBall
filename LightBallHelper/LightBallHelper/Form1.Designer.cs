namespace LightBallHelper
{
    partial class LightBallHelper
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BtnLoadFile = new System.Windows.Forms.Button();
            this.labelNowTime = new System.Windows.Forms.Label();
            this.labelTotalTime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.BtnPlay = new System.Windows.Forms.Button();
            this.BtnStop = new System.Windows.Forms.Button();
            this.audioTrackBar = new System.Windows.Forms.TrackBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.BtnTopColour = new System.Windows.Forms.Button();
            this.BtnBottomColour = new System.Windows.Forms.Button();
            this.comboBoxPeakCalculationStrategy = new System.Windows.Forms.ComboBox();
            this.updownTopHeight = new System.Windows.Forms.NumericUpDown();
            this.updownBottomHeight = new System.Windows.Forms.NumericUpDown();
            this.labelRendering = new System.Windows.Forms.Label();
            this.effectsOptions = new System.Windows.Forms.ListBox();
            this.effectsList = new System.Windows.Forms.ListBox();
            this.keypointsList = new System.Windows.Forms.ListBox();
            this.BtnAddEffect = new System.Windows.Forms.Button();
            this.BtnDelEffect = new System.Windows.Forms.Button();
            this.BtnDelKeypoint = new System.Windows.Forms.Button();
            this.BtnAddKeypoint = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnBackwardMove = new System.Windows.Forms.Button();
            this.BtnForwardMove = new System.Windows.Forms.Button();
            this.UpdownOffset = new System.Windows.Forms.NumericUpDown();
            this.textBoxEffectStart = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxEffectEnd = new System.Windows.Forms.TextBox();
            this.pictureBoxIndicator = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.trackBarColorSelect = new System.Windows.Forms.TrackBar();
            this.pictureBoxColorBar = new System.Windows.Forms.PictureBox();
            this.trackBarLightness = new System.Windows.Forms.TrackBar();
            this.textBoxColorR = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxColorG = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxColorB = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxColorH = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxColorS = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxColorV = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.BtnColorShowStart = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.keypointStartingColor = new System.Windows.Forms.GroupBox();
            this.textBoxKeypointSpace = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.BtnSetColorNowtime = new System.Windows.Forms.Button();
            this.BtnKeypointSave = new System.Windows.Forms.Button();
            this.textBoxBrightTransition = new System.Windows.Forms.TextBox();
            this.textBoxColorTransition = new System.Windows.Forms.TextBox();
            this.textBoxKeypointDuration = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.BtnColorShowEnd = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxColorStart = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.effect = new System.Windows.Forms.Label();
            this.textBoxEffectName = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textBoxEffectTransition = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.BtnSetStartNowtime = new System.Windows.Forms.Button();
            this.BtnSetEndNowtime = new System.Windows.Forms.Button();
            this.BtnHistorySave = new System.Windows.Forms.Button();
            this.BtnHistoryLoad = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnExport = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnSetGlobalStarting = new System.Windows.Forms.Button();
            this.label28 = new System.Windows.Forms.Label();
            this.textBoxGlobalStarting = new System.Windows.Forms.TextBox();
            this.textBoxAddKeypointFixDuration = new System.Windows.Forms.TextBox();
            this.checkBoxAddKeypointFixDuration = new System.Windows.Forms.CheckBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.checkBoxAddKeypointFixSpace = new System.Windows.Forms.CheckBox();
            this.textBoxAddKeypointFixSpace = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.checkBoxAddKeypointColorTran = new System.Windows.Forms.CheckBox();
            this.textBoxAddKeypointColorTran = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.audioTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updownTopHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updownBottomHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpdownOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIndicator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarColorSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColorBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLightness)).BeginInit();
            this.keypointStartingColor.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnLoadFile
            // 
            this.BtnLoadFile.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BtnLoadFile.Location = new System.Drawing.Point(26, 424);
            this.BtnLoadFile.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnLoadFile.Name = "BtnLoadFile";
            this.BtnLoadFile.Size = new System.Drawing.Size(87, 35);
            this.BtnLoadFile.TabIndex = 0;
            this.BtnLoadFile.Text = "Load File";
            this.BtnLoadFile.UseVisualStyleBackColor = true;
            this.BtnLoadFile.Click += new System.EventHandler(this.BtnLoadFile_Click);
            // 
            // labelNowTime
            // 
            this.labelNowTime.AutoSize = true;
            this.labelNowTime.Location = new System.Drawing.Point(13, 475);
            this.labelNowTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNowTime.Name = "labelNowTime";
            this.labelNowTime.Size = new System.Drawing.Size(138, 19);
            this.labelNowTime.TabIndex = 1;
            this.labelNowTime.Text = "Current: 00:00:000";
            // 
            // labelTotalTime
            // 
            this.labelTotalTime.AutoSize = true;
            this.labelTotalTime.Location = new System.Drawing.Point(1388, 475);
            this.labelTotalTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTotalTime.Name = "labelTotalTime";
            this.labelTotalTime.Size = new System.Drawing.Size(119, 19);
            this.labelTotalTime.TabIndex = 2;
            this.labelTotalTime.Text = "Total: 00:00:000";
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.OnTimerTick);
            // 
            // BtnPlay
            // 
            this.BtnPlay.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BtnPlay.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BtnPlay.Location = new System.Drawing.Point(656, 424);
            this.BtnPlay.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnPlay.Name = "BtnPlay";
            this.BtnPlay.Size = new System.Drawing.Size(74, 35);
            this.BtnPlay.TabIndex = 3;
            this.BtnPlay.Text = "Play";
            this.BtnPlay.UseVisualStyleBackColor = false;
            this.BtnPlay.Click += new System.EventHandler(this.BtnPlay_Click);
            // 
            // BtnStop
            // 
            this.BtnStop.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BtnStop.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BtnStop.Location = new System.Drawing.Point(921, 424);
            this.BtnStop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnStop.Name = "BtnStop";
            this.BtnStop.Size = new System.Drawing.Size(74, 35);
            this.BtnStop.TabIndex = 4;
            this.BtnStop.Text = "End";
            this.BtnStop.UseVisualStyleBackColor = false;
            this.BtnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // audioTrackBar
            // 
            this.audioTrackBar.Location = new System.Drawing.Point(2, 497);
            this.audioTrackBar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.audioTrackBar.Maximum = 1000;
            this.audioTrackBar.Name = "audioTrackBar";
            this.audioTrackBar.Size = new System.Drawing.Size(1540, 56);
            this.audioTrackBar.TabIndex = 5;
            this.audioTrackBar.Scroll += new System.EventHandler(this.AudioTrackBar_Scroll);
            // 
            // BtnTopColour
            // 
            this.BtnTopColour.Location = new System.Drawing.Point(1281, 435);
            this.BtnTopColour.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnTopColour.Name = "BtnTopColour";
            this.BtnTopColour.Size = new System.Drawing.Size(29, 27);
            this.BtnTopColour.TabIndex = 6;
            this.BtnTopColour.UseVisualStyleBackColor = true;
            this.BtnTopColour.Click += new System.EventHandler(this.OnColorButtonClick);
            // 
            // BtnBottomColour
            // 
            this.BtnBottomColour.Location = new System.Drawing.Point(1281, 468);
            this.BtnBottomColour.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnBottomColour.Name = "BtnBottomColour";
            this.BtnBottomColour.Size = new System.Drawing.Size(29, 27);
            this.BtnBottomColour.TabIndex = 7;
            this.BtnBottomColour.UseVisualStyleBackColor = true;
            this.BtnBottomColour.Click += new System.EventHandler(this.OnColorButtonClick);
            // 
            // comboBoxPeakCalculationStrategy
            // 
            this.comboBoxPeakCalculationStrategy.FormattingEnabled = true;
            this.comboBoxPeakCalculationStrategy.Location = new System.Drawing.Point(1020, 464);
            this.comboBoxPeakCalculationStrategy.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBoxPeakCalculationStrategy.Name = "comboBoxPeakCalculationStrategy";
            this.comboBoxPeakCalculationStrategy.Size = new System.Drawing.Size(152, 27);
            this.comboBoxPeakCalculationStrategy.TabIndex = 8;
            // 
            // updownTopHeight
            // 
            this.updownTopHeight.Location = new System.Drawing.Point(1317, 435);
            this.updownTopHeight.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.updownTopHeight.Name = "updownTopHeight";
            this.updownTopHeight.Size = new System.Drawing.Size(70, 27);
            this.updownTopHeight.TabIndex = 9;
            // 
            // updownBottomHeight
            // 
            this.updownBottomHeight.Location = new System.Drawing.Point(1317, 468);
            this.updownBottomHeight.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.updownBottomHeight.Name = "updownBottomHeight";
            this.updownBottomHeight.Size = new System.Drawing.Size(70, 27);
            this.updownBottomHeight.TabIndex = 10;
            // 
            // labelRendering
            // 
            this.labelRendering.AutoSize = true;
            this.labelRendering.Font = new System.Drawing.Font("微軟正黑體", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelRendering.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelRendering.Location = new System.Drawing.Point(34, 556);
            this.labelRendering.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRendering.Name = "labelRendering";
            this.labelRendering.Size = new System.Drawing.Size(446, 101);
            this.labelRendering.TabIndex = 12;
            this.labelRendering.Text = "Rendering";
            // 
            // effectsOptions
            // 
            this.effectsOptions.FormattingEnabled = true;
            this.effectsOptions.ItemHeight = 19;
            this.effectsOptions.Location = new System.Drawing.Point(26, 34);
            this.effectsOptions.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.effectsOptions.Name = "effectsOptions";
            this.effectsOptions.Size = new System.Drawing.Size(115, 384);
            this.effectsOptions.TabIndex = 14;
            // 
            // effectsList
            // 
            this.effectsList.FormattingEnabled = true;
            this.effectsList.ItemHeight = 19;
            this.effectsList.Location = new System.Drawing.Point(149, 34);
            this.effectsList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.effectsList.Name = "effectsList";
            this.effectsList.Size = new System.Drawing.Size(200, 384);
            this.effectsList.TabIndex = 15;
            this.effectsList.SelectedIndexChanged += new System.EventHandler(this.EffectsList_SelectedIndexChanged);
            // 
            // keypointsList
            // 
            this.keypointsList.FormattingEnabled = true;
            this.keypointsList.ItemHeight = 19;
            this.keypointsList.Location = new System.Drawing.Point(357, 34);
            this.keypointsList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.keypointsList.Name = "keypointsList";
            this.keypointsList.Size = new System.Drawing.Size(200, 384);
            this.keypointsList.TabIndex = 16;
            this.keypointsList.SelectedIndexChanged += new System.EventHandler(this.KeypointsList_SelectedIndexChanged);
            // 
            // BtnAddEffect
            // 
            this.BtnAddEffect.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BtnAddEffect.Location = new System.Drawing.Point(149, 424);
            this.BtnAddEffect.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnAddEffect.Name = "BtnAddEffect";
            this.BtnAddEffect.Size = new System.Drawing.Size(90, 35);
            this.BtnAddEffect.TabIndex = 17;
            this.BtnAddEffect.Text = "Add Effect";
            this.BtnAddEffect.UseVisualStyleBackColor = true;
            this.BtnAddEffect.Click += new System.EventHandler(this.BtnAddEffect_Click);
            // 
            // BtnDelEffect
            // 
            this.BtnDelEffect.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BtnDelEffect.Location = new System.Drawing.Point(259, 424);
            this.BtnDelEffect.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnDelEffect.Name = "BtnDelEffect";
            this.BtnDelEffect.Size = new System.Drawing.Size(90, 35);
            this.BtnDelEffect.TabIndex = 18;
            this.BtnDelEffect.Text = "Del Effect";
            this.BtnDelEffect.UseVisualStyleBackColor = true;
            this.BtnDelEffect.Click += new System.EventHandler(this.BtnDelEffect_Click);
            // 
            // BtnDelKeypoint
            // 
            this.BtnDelKeypoint.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BtnDelKeypoint.Location = new System.Drawing.Point(467, 424);
            this.BtnDelKeypoint.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnDelKeypoint.Name = "BtnDelKeypoint";
            this.BtnDelKeypoint.Size = new System.Drawing.Size(90, 35);
            this.BtnDelKeypoint.TabIndex = 20;
            this.BtnDelKeypoint.Text = "Del Key";
            this.BtnDelKeypoint.UseVisualStyleBackColor = true;
            this.BtnDelKeypoint.Click += new System.EventHandler(this.BtnDelKeypoint_Click);
            // 
            // BtnAddKeypoint
            // 
            this.BtnAddKeypoint.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BtnAddKeypoint.Location = new System.Drawing.Point(357, 424);
            this.BtnAddKeypoint.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnAddKeypoint.Name = "BtnAddKeypoint";
            this.BtnAddKeypoint.Size = new System.Drawing.Size(90, 35);
            this.BtnAddKeypoint.TabIndex = 19;
            this.BtnAddKeypoint.Text = "Add Key";
            this.BtnAddKeypoint.UseVisualStyleBackColor = true;
            this.BtnAddKeypoint.Click += new System.EventHandler(this.BtnAddKeypoint_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1180, 437);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 19);
            this.label1.TabIndex = 21;
            this.label1.Text = "Top Wave";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1180, 472);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 19);
            this.label2.TabIndex = 22;
            this.label2.Text = "Bottom Wave";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1017, 441);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 19);
            this.label3.TabIndex = 23;
            this.label3.Text = "Peak Algorithm";
            // 
            // BtnBackwardMove
            // 
            this.BtnBackwardMove.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BtnBackwardMove.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BtnBackwardMove.Location = new System.Drawing.Point(575, 424);
            this.BtnBackwardMove.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnBackwardMove.Name = "BtnBackwardMove";
            this.BtnBackwardMove.Size = new System.Drawing.Size(74, 35);
            this.BtnBackwardMove.TabIndex = 24;
            this.BtnBackwardMove.Text = "<<";
            this.BtnBackwardMove.UseVisualStyleBackColor = false;
            this.BtnBackwardMove.Click += new System.EventHandler(this.BtnBackwardMove_Click);
            // 
            // BtnForwardMove
            // 
            this.BtnForwardMove.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BtnForwardMove.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BtnForwardMove.Location = new System.Drawing.Point(737, 424);
            this.BtnForwardMove.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnForwardMove.Name = "BtnForwardMove";
            this.BtnForwardMove.Size = new System.Drawing.Size(74, 35);
            this.BtnForwardMove.TabIndex = 25;
            this.BtnForwardMove.Text = ">>";
            this.BtnForwardMove.UseVisualStyleBackColor = false;
            this.BtnForwardMove.Click += new System.EventHandler(this.BtnForwardMove_Click);
            // 
            // UpdownOffset
            // 
            this.UpdownOffset.Location = new System.Drawing.Point(819, 430);
            this.UpdownOffset.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.UpdownOffset.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.UpdownOffset.Name = "UpdownOffset";
            this.UpdownOffset.Size = new System.Drawing.Size(71, 27);
            this.UpdownOffset.TabIndex = 26;
            // 
            // textBoxEffectStart
            // 
            this.textBoxEffectStart.Location = new System.Drawing.Point(106, 59);
            this.textBoxEffectStart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxEffectStart.Name = "textBoxEffectStart";
            this.textBoxEffectStart.Size = new System.Drawing.Size(112, 27);
            this.textBoxEffectStart.TabIndex = 27;
            this.textBoxEffectStart.Leave += new System.EventHandler(this.MainInputsTextBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 64);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 19);
            this.label4.TabIndex = 28;
            this.label4.Text = "Start Time";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 96);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 19);
            this.label5.TabIndex = 30;
            this.label5.Text = "End Time";
            // 
            // textBoxEffectEnd
            // 
            this.textBoxEffectEnd.Location = new System.Drawing.Point(106, 92);
            this.textBoxEffectEnd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxEffectEnd.Name = "textBoxEffectEnd";
            this.textBoxEffectEnd.Size = new System.Drawing.Size(112, 27);
            this.textBoxEffectEnd.TabIndex = 29;
            this.textBoxEffectEnd.Leave += new System.EventHandler(this.MainInputsTextBox_TextChanged);
            // 
            // pictureBoxIndicator
            // 
            this.pictureBoxIndicator.Image = global::LightBallHelper.Resource1.indicator;
            this.pictureBoxIndicator.Location = new System.Drawing.Point(37, 528);
            this.pictureBoxIndicator.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBoxIndicator.Name = "pictureBoxIndicator";
            this.pictureBoxIndicator.Size = new System.Drawing.Size(5, 189);
            this.pictureBoxIndicator.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxIndicator.TabIndex = 13;
            this.pictureBoxIndicator.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(17, 540);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1507, 160);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // trackBarColorSelect
            // 
            this.trackBarColorSelect.Location = new System.Drawing.Point(71, 86);
            this.trackBarColorSelect.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.trackBarColorSelect.Maximum = 360;
            this.trackBarColorSelect.Minimum = 1;
            this.trackBarColorSelect.Name = "trackBarColorSelect";
            this.trackBarColorSelect.Size = new System.Drawing.Size(305, 56);
            this.trackBarColorSelect.TabIndex = 43;
            this.trackBarColorSelect.Value = 1;
            this.trackBarColorSelect.Scroll += new System.EventHandler(this.setColorWithTrackBar);
            // 
            // pictureBoxColorBar
            // 
            this.pictureBoxColorBar.Image = global::LightBallHelper.ColorBar.color_bar;
            this.pictureBoxColorBar.Location = new System.Drawing.Point(85, 119);
            this.pictureBoxColorBar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBoxColorBar.Name = "pictureBoxColorBar";
            this.pictureBoxColorBar.Size = new System.Drawing.Size(274, 34);
            this.pictureBoxColorBar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxColorBar.TabIndex = 44;
            this.pictureBoxColorBar.TabStop = false;
            // 
            // trackBarLightness
            // 
            this.trackBarLightness.Location = new System.Drawing.Point(71, 159);
            this.trackBarLightness.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.trackBarLightness.Maximum = 100;
            this.trackBarLightness.Minimum = 1;
            this.trackBarLightness.Name = "trackBarLightness";
            this.trackBarLightness.Size = new System.Drawing.Size(305, 56);
            this.trackBarLightness.TabIndex = 45;
            this.trackBarLightness.Value = 1;
            this.trackBarLightness.Scroll += new System.EventHandler(this.setColorWithTrackBar);
            // 
            // textBoxColorR
            // 
            this.textBoxColorR.Location = new System.Drawing.Point(185, 207);
            this.textBoxColorR.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxColorR.Name = "textBoxColorR";
            this.textBoxColorR.Size = new System.Drawing.Size(51, 27);
            this.textBoxColorR.TabIndex = 31;
            this.textBoxColorR.Leave += new System.EventHandler(this.setColorWithRGBTextBox);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(181, 186);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 19);
            this.label6.TabIndex = 32;
            this.label6.Text = "R";
            // 
            // textBoxColorG
            // 
            this.textBoxColorG.Location = new System.Drawing.Point(245, 207);
            this.textBoxColorG.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxColorG.Name = "textBoxColorG";
            this.textBoxColorG.Size = new System.Drawing.Size(51, 27);
            this.textBoxColorG.TabIndex = 33;
            this.textBoxColorG.Leave += new System.EventHandler(this.setColorWithRGBTextBox);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(242, 186);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 19);
            this.label7.TabIndex = 34;
            this.label7.Text = "G";
            // 
            // textBoxColorB
            // 
            this.textBoxColorB.Location = new System.Drawing.Point(304, 207);
            this.textBoxColorB.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxColorB.Name = "textBoxColorB";
            this.textBoxColorB.Size = new System.Drawing.Size(51, 27);
            this.textBoxColorB.TabIndex = 35;
            this.textBoxColorB.Leave += new System.EventHandler(this.setColorWithRGBTextBox);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(301, 186);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 19);
            this.label8.TabIndex = 36;
            this.label8.Text = "B";
            // 
            // textBoxColorH
            // 
            this.textBoxColorH.Location = new System.Drawing.Point(185, 254);
            this.textBoxColorH.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxColorH.Name = "textBoxColorH";
            this.textBoxColorH.Size = new System.Drawing.Size(51, 27);
            this.textBoxColorH.TabIndex = 37;
            this.textBoxColorH.Leave += new System.EventHandler(this.setColorWithHSVTextBox);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(181, 235);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(20, 19);
            this.label11.TabIndex = 38;
            this.label11.Text = "H";
            // 
            // textBoxColorS
            // 
            this.textBoxColorS.Location = new System.Drawing.Point(245, 254);
            this.textBoxColorS.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxColorS.Name = "textBoxColorS";
            this.textBoxColorS.Size = new System.Drawing.Size(51, 27);
            this.textBoxColorS.TabIndex = 39;
            this.textBoxColorS.Leave += new System.EventHandler(this.setColorWithHSVTextBox);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(242, 235);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(18, 19);
            this.label10.TabIndex = 40;
            this.label10.Text = "S";
            // 
            // textBoxColorV
            // 
            this.textBoxColorV.Location = new System.Drawing.Point(304, 254);
            this.textBoxColorV.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxColorV.Name = "textBoxColorV";
            this.textBoxColorV.Size = new System.Drawing.Size(51, 27);
            this.textBoxColorV.TabIndex = 41;
            this.textBoxColorV.Leave += new System.EventHandler(this.setColorWithHSVTextBox);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(301, 235);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(19, 19);
            this.label9.TabIndex = 42;
            this.label9.Text = "V";
            // 
            // BtnColorShowStart
            // 
            this.BtnColorShowStart.Location = new System.Drawing.Point(99, 207);
            this.BtnColorShowStart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnColorShowStart.Name = "BtnColorShowStart";
            this.BtnColorShowStart.Size = new System.Drawing.Size(74, 74);
            this.BtnColorShowStart.TabIndex = 46;
            this.BtnColorShowStart.UseVisualStyleBackColor = true;
            this.BtnColorShowStart.Click += new System.EventHandler(this.BtnColorShowStart_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(17, 86);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 19);
            this.label12.TabIndex = 47;
            this.label12.Text = "Color";
            // 
            // keypointStartingColor
            // 
            this.keypointStartingColor.Controls.Add(this.textBoxKeypointSpace);
            this.keypointStartingColor.Controls.Add(this.label26);
            this.keypointStartingColor.Controls.Add(this.label27);
            this.keypointStartingColor.Controls.Add(this.BtnSetColorNowtime);
            this.keypointStartingColor.Controls.Add(this.BtnKeypointSave);
            this.keypointStartingColor.Controls.Add(this.textBoxBrightTransition);
            this.keypointStartingColor.Controls.Add(this.textBoxColorTransition);
            this.keypointStartingColor.Controls.Add(this.textBoxKeypointDuration);
            this.keypointStartingColor.Controls.Add(this.label24);
            this.keypointStartingColor.Controls.Add(this.label25);
            this.keypointStartingColor.Controls.Add(this.label22);
            this.keypointStartingColor.Controls.Add(this.label21);
            this.keypointStartingColor.Controls.Add(this.BtnColorShowEnd);
            this.keypointStartingColor.Controls.Add(this.label20);
            this.keypointStartingColor.Controls.Add(this.label19);
            this.keypointStartingColor.Controls.Add(this.label18);
            this.keypointStartingColor.Controls.Add(this.label13);
            this.keypointStartingColor.Controls.Add(this.textBoxColorStart);
            this.keypointStartingColor.Controls.Add(this.label12);
            this.keypointStartingColor.Controls.Add(this.BtnColorShowStart);
            this.keypointStartingColor.Controls.Add(this.label9);
            this.keypointStartingColor.Controls.Add(this.textBoxColorV);
            this.keypointStartingColor.Controls.Add(this.label10);
            this.keypointStartingColor.Controls.Add(this.textBoxColorS);
            this.keypointStartingColor.Controls.Add(this.label11);
            this.keypointStartingColor.Controls.Add(this.textBoxColorH);
            this.keypointStartingColor.Controls.Add(this.label8);
            this.keypointStartingColor.Controls.Add(this.textBoxColorB);
            this.keypointStartingColor.Controls.Add(this.label7);
            this.keypointStartingColor.Controls.Add(this.textBoxColorG);
            this.keypointStartingColor.Controls.Add(this.label6);
            this.keypointStartingColor.Controls.Add(this.textBoxColorR);
            this.keypointStartingColor.Controls.Add(this.trackBarLightness);
            this.keypointStartingColor.Controls.Add(this.pictureBoxColorBar);
            this.keypointStartingColor.Controls.Add(this.trackBarColorSelect);
            this.keypointStartingColor.Location = new System.Drawing.Point(1048, 18);
            this.keypointStartingColor.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.keypointStartingColor.Name = "keypointStartingColor";
            this.keypointStartingColor.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.keypointStartingColor.Size = new System.Drawing.Size(400, 411);
            this.keypointStartingColor.TabIndex = 47;
            this.keypointStartingColor.TabStop = false;
            this.keypointStartingColor.Text = "Keypoint Starting Color";
            // 
            // textBoxKeypointSpace
            // 
            this.textBoxKeypointSpace.Location = new System.Drawing.Point(290, 48);
            this.textBoxKeypointSpace.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxKeypointSpace.Name = "textBoxKeypointSpace";
            this.textBoxKeypointSpace.Size = new System.Drawing.Size(62, 27);
            this.textBoxKeypointSpace.TabIndex = 72;
            this.textBoxKeypointSpace.Text = "0";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(351, 51);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(31, 19);
            this.label26.TabIndex = 71;
            this.label26.Text = "sec";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(286, 24);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(50, 19);
            this.label27.TabIndex = 70;
            this.label27.Text = "Space";
            // 
            // BtnSetColorNowtime
            // 
            this.BtnSetColorNowtime.Location = new System.Drawing.Point(136, 48);
            this.BtnSetColorNowtime.Name = "BtnSetColorNowtime";
            this.BtnSetColorNowtime.Size = new System.Drawing.Size(27, 27);
            this.BtnSetColorNowtime.TabIndex = 67;
            this.BtnSetColorNowtime.TabStop = false;
            this.BtnSetColorNowtime.Text = "N";
            this.BtnSetColorNowtime.UseVisualStyleBackColor = true;
            this.BtnSetColorNowtime.Click += new System.EventHandler(this.BtnSetColorNowtime_Click);
            // 
            // BtnKeypointSave
            // 
            this.BtnKeypointSave.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BtnKeypointSave.Location = new System.Drawing.Point(259, 372);
            this.BtnKeypointSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnKeypointSave.Name = "BtnKeypointSave";
            this.BtnKeypointSave.Size = new System.Drawing.Size(129, 28);
            this.BtnKeypointSave.TabIndex = 69;
            this.BtnKeypointSave.Text = "Keypoint Save";
            this.BtnKeypointSave.UseVisualStyleBackColor = false;
            this.BtnKeypointSave.Click += new System.EventHandler(this.BtnKeypointSave_Click);
            // 
            // textBoxBrightTransition
            // 
            this.textBoxBrightTransition.Location = new System.Drawing.Point(266, 337);
            this.textBoxBrightTransition.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxBrightTransition.Name = "textBoxBrightTransition";
            this.textBoxBrightTransition.Size = new System.Drawing.Size(70, 27);
            this.textBoxBrightTransition.TabIndex = 68;
            this.textBoxBrightTransition.Text = "0";
            this.textBoxBrightTransition.Leave += new System.EventHandler(this.showEndColor_Changed);
            // 
            // textBoxColorTransition
            // 
            this.textBoxColorTransition.Location = new System.Drawing.Point(266, 302);
            this.textBoxColorTransition.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxColorTransition.Name = "textBoxColorTransition";
            this.textBoxColorTransition.Size = new System.Drawing.Size(70, 27);
            this.textBoxColorTransition.TabIndex = 67;
            this.textBoxColorTransition.Text = "0";
            this.textBoxColorTransition.Leave += new System.EventHandler(this.showEndColor_Changed);
            // 
            // textBoxKeypointDuration
            // 
            this.textBoxKeypointDuration.Location = new System.Drawing.Point(193, 47);
            this.textBoxKeypointDuration.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxKeypointDuration.Name = "textBoxKeypointDuration";
            this.textBoxKeypointDuration.Size = new System.Drawing.Size(62, 27);
            this.textBoxKeypointDuration.TabIndex = 65;
            this.textBoxKeypointDuration.Text = "0";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(332, 340);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(64, 19);
            this.label24.TabIndex = 66;
            this.label24.Text = "°/1000s";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(176, 340);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(94, 19);
            this.label25.TabIndex = 65;
            this.label25.Text = "Bright Trans";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(254, 50);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(31, 19);
            this.label22.TabIndex = 63;
            this.label22.Text = "sec";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(332, 305);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(64, 19);
            this.label21.TabIndex = 62;
            this.label21.Text = "°/1000s";
            // 
            // BtnColorShowEnd
            // 
            this.BtnColorShowEnd.Location = new System.Drawing.Point(99, 296);
            this.BtnColorShowEnd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnColorShowEnd.Name = "BtnColorShowEnd";
            this.BtnColorShowEnd.Size = new System.Drawing.Size(74, 74);
            this.BtnColorShowEnd.TabIndex = 61;
            this.BtnColorShowEnd.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(176, 305);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(79, 19);
            this.label20.TabIndex = 60;
            this.label20.Text = "Hue Trans";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(189, 23);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(70, 19);
            this.label19.TabIndex = 58;
            this.label19.Text = "Duration";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(17, 23);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(80, 19);
            this.label18.TabIndex = 56;
            this.label18.Text = "Start Time";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 159);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 19);
            this.label13.TabIndex = 48;
            this.label13.Text = "Bright";
            // 
            // textBoxColorStart
            // 
            this.textBoxColorStart.Location = new System.Drawing.Point(21, 47);
            this.textBoxColorStart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxColorStart.Name = "textBoxColorStart";
            this.textBoxColorStart.Size = new System.Drawing.Size(112, 27);
            this.textBoxColorStart.TabIndex = 55;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(28, 9);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(113, 19);
            this.label14.TabIndex = 48;
            this.label14.Text = "Effects Options";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(199, 9);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(82, 19);
            this.label15.TabIndex = 49;
            this.label15.Text = "Effects List";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(402, 9);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(105, 19);
            this.label16.TabIndex = 50;
            this.label16.Text = "Keypoints List";
            // 
            // effect
            // 
            this.effect.AutoSize = true;
            this.effect.Location = new System.Drawing.Point(24, 30);
            this.effect.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.effect.Name = "effect";
            this.effect.Size = new System.Drawing.Size(51, 19);
            this.effect.TabIndex = 52;
            this.effect.Text = "Name";
            // 
            // textBoxEffectName
            // 
            this.textBoxEffectName.Location = new System.Drawing.Point(106, 25);
            this.textBoxEffectName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxEffectName.Name = "textBoxEffectName";
            this.textBoxEffectName.Size = new System.Drawing.Size(112, 27);
            this.textBoxEffectName.TabIndex = 51;
            this.textBoxEffectName.Leave += new System.EventHandler(this.MainInputsTextBox_TextChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(24, 130);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(78, 19);
            this.label17.TabIndex = 54;
            this.label17.Text = "Transition";
            // 
            // textBoxEffectTransition
            // 
            this.textBoxEffectTransition.Location = new System.Drawing.Point(106, 125);
            this.textBoxEffectTransition.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxEffectTransition.Name = "textBoxEffectTransition";
            this.textBoxEffectTransition.Size = new System.Drawing.Size(112, 27);
            this.textBoxEffectTransition.TabIndex = 53;
            this.textBoxEffectTransition.Leave += new System.EventHandler(this.MainInputsTextBox_TextChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(221, 130);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(31, 19);
            this.label23.TabIndex = 64;
            this.label23.Text = "sec";
            // 
            // BtnSetStartNowtime
            // 
            this.BtnSetStartNowtime.Location = new System.Drawing.Point(225, 59);
            this.BtnSetStartNowtime.Name = "BtnSetStartNowtime";
            this.BtnSetStartNowtime.Size = new System.Drawing.Size(27, 27);
            this.BtnSetStartNowtime.TabIndex = 65;
            this.BtnSetStartNowtime.TabStop = false;
            this.BtnSetStartNowtime.Text = "N";
            this.BtnSetStartNowtime.UseVisualStyleBackColor = true;
            this.BtnSetStartNowtime.Click += new System.EventHandler(this.BtnSetStartNowtime_Click);
            // 
            // BtnSetEndNowtime
            // 
            this.BtnSetEndNowtime.Location = new System.Drawing.Point(225, 92);
            this.BtnSetEndNowtime.Name = "BtnSetEndNowtime";
            this.BtnSetEndNowtime.Size = new System.Drawing.Size(27, 27);
            this.BtnSetEndNowtime.TabIndex = 66;
            this.BtnSetEndNowtime.TabStop = false;
            this.BtnSetEndNowtime.Text = "N";
            this.BtnSetEndNowtime.UseVisualStyleBackColor = true;
            this.BtnSetEndNowtime.Click += new System.EventHandler(this.BtnSetEndNowtime_Click);
            // 
            // BtnHistorySave
            // 
            this.BtnHistorySave.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BtnHistorySave.Location = new System.Drawing.Point(18, 74);
            this.BtnHistorySave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnHistorySave.Name = "BtnHistorySave";
            this.BtnHistorySave.Size = new System.Drawing.Size(90, 35);
            this.BtnHistorySave.TabIndex = 68;
            this.BtnHistorySave.Text = "Save";
            this.BtnHistorySave.UseVisualStyleBackColor = true;
            this.BtnHistorySave.Click += new System.EventHandler(this.BtnHistorySave_Click);
            // 
            // BtnHistoryLoad
            // 
            this.BtnHistoryLoad.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BtnHistoryLoad.Location = new System.Drawing.Point(18, 33);
            this.BtnHistoryLoad.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnHistoryLoad.Name = "BtnHistoryLoad";
            this.BtnHistoryLoad.Size = new System.Drawing.Size(90, 35);
            this.BtnHistoryLoad.TabIndex = 67;
            this.BtnHistoryLoad.Text = "Load";
            this.BtnHistoryLoad.UseVisualStyleBackColor = true;
            this.BtnHistoryLoad.Click += new System.EventHandler(this.BtnHistoryLoad_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnSetEndNowtime);
            this.groupBox1.Controls.Add(this.BtnSetStartNowtime);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.textBoxEffectTransition);
            this.groupBox1.Controls.Add(this.effect);
            this.groupBox1.Controls.Add(this.textBoxEffectName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxEffectEnd);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxEffectStart);
            this.groupBox1.Location = new System.Drawing.Point(704, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(271, 162);
            this.groupBox1.TabIndex = 69;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Effect Setting";
            // 
            // BtnExport
            // 
            this.BtnExport.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BtnExport.Location = new System.Drawing.Point(18, 186);
            this.BtnExport.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnExport.Name = "BtnExport";
            this.BtnExport.Size = new System.Drawing.Size(90, 35);
            this.BtnExport.TabIndex = 70;
            this.BtnExport.Text = "Export";
            this.BtnExport.UseVisualStyleBackColor = true;
            this.BtnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnSetGlobalStarting);
            this.groupBox2.Controls.Add(this.label28);
            this.groupBox2.Controls.Add(this.textBoxGlobalStarting);
            this.groupBox2.Controls.Add(this.BtnExport);
            this.groupBox2.Controls.Add(this.BtnHistorySave);
            this.groupBox2.Controls.Add(this.BtnHistoryLoad);
            this.groupBox2.Location = new System.Drawing.Point(575, 18);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(123, 234);
            this.groupBox2.TabIndex = 71;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Configuration";
            // 
            // BtnSetGlobalStarting
            // 
            this.BtnSetGlobalStarting.Location = new System.Drawing.Point(81, 141);
            this.BtnSetGlobalStarting.Name = "BtnSetGlobalStarting";
            this.BtnSetGlobalStarting.Size = new System.Drawing.Size(27, 27);
            this.BtnSetGlobalStarting.TabIndex = 67;
            this.BtnSetGlobalStarting.TabStop = false;
            this.BtnSetGlobalStarting.Text = "N";
            this.BtnSetGlobalStarting.UseVisualStyleBackColor = true;
            this.BtnSetGlobalStarting.Click += new System.EventHandler(this.BtnSetGlobalStarting_Click);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(14, 119);
            this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(103, 19);
            this.label28.TabIndex = 68;
            this.label28.Text = "Starting Time";
            // 
            // textBoxGlobalStarting
            // 
            this.textBoxGlobalStarting.Location = new System.Drawing.Point(18, 141);
            this.textBoxGlobalStarting.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxGlobalStarting.Name = "textBoxGlobalStarting";
            this.textBoxGlobalStarting.Size = new System.Drawing.Size(56, 27);
            this.textBoxGlobalStarting.TabIndex = 67;
            // 
            // textBoxAddKeypointFixDuration
            // 
            this.textBoxAddKeypointFixDuration.Location = new System.Drawing.Point(831, 199);
            this.textBoxAddKeypointFixDuration.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxAddKeypointFixDuration.Name = "textBoxAddKeypointFixDuration";
            this.textBoxAddKeypointFixDuration.Size = new System.Drawing.Size(91, 27);
            this.textBoxAddKeypointFixDuration.TabIndex = 67;
            // 
            // checkBoxAddKeypointFixDuration
            // 
            this.checkBoxAddKeypointFixDuration.AutoSize = true;
            this.checkBoxAddKeypointFixDuration.Location = new System.Drawing.Point(716, 203);
            this.checkBoxAddKeypointFixDuration.Name = "checkBoxAddKeypointFixDuration";
            this.checkBoxAddKeypointFixDuration.Size = new System.Drawing.Size(115, 23);
            this.checkBoxAddKeypointFixDuration.TabIndex = 72;
            this.checkBoxAddKeypointFixDuration.Text = "Fix Duration";
            this.checkBoxAddKeypointFixDuration.UseVisualStyleBackColor = true;
            this.checkBoxAddKeypointFixDuration.CheckedChanged += new System.EventHandler(this.CheckBoxAddKeypointFixDuration_CheckedChanged);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(925, 204);
            this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(31, 19);
            this.label29.TabIndex = 73;
            this.label29.Text = "sec";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(925, 237);
            this.label30.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(31, 19);
            this.label30.TabIndex = 76;
            this.label30.Text = "sec";
            // 
            // checkBoxAddKeypointFixSpace
            // 
            this.checkBoxAddKeypointFixSpace.AutoSize = true;
            this.checkBoxAddKeypointFixSpace.Location = new System.Drawing.Point(716, 236);
            this.checkBoxAddKeypointFixSpace.Name = "checkBoxAddKeypointFixSpace";
            this.checkBoxAddKeypointFixSpace.Size = new System.Drawing.Size(95, 23);
            this.checkBoxAddKeypointFixSpace.TabIndex = 75;
            this.checkBoxAddKeypointFixSpace.Text = "Fix Space";
            this.checkBoxAddKeypointFixSpace.UseVisualStyleBackColor = true;
            this.checkBoxAddKeypointFixSpace.CheckedChanged += new System.EventHandler(this.CheckBoxAddKeypointFixSpace_CheckedChanged);
            // 
            // textBoxAddKeypointFixSpace
            // 
            this.textBoxAddKeypointFixSpace.Location = new System.Drawing.Point(831, 232);
            this.textBoxAddKeypointFixSpace.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxAddKeypointFixSpace.Name = "textBoxAddKeypointFixSpace";
            this.textBoxAddKeypointFixSpace.Size = new System.Drawing.Size(91, 27);
            this.textBoxAddKeypointFixSpace.TabIndex = 74;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(925, 270);
            this.label31.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(31, 19);
            this.label31.TabIndex = 79;
            this.label31.Text = "sec";
            // 
            // checkBoxAddKeypointColorTran
            // 
            this.checkBoxAddKeypointColorTran.AutoSize = true;
            this.checkBoxAddKeypointColorTran.Location = new System.Drawing.Point(716, 269);
            this.checkBoxAddKeypointColorTran.Name = "checkBoxAddKeypointColorTran";
            this.checkBoxAddKeypointColorTran.Size = new System.Drawing.Size(106, 23);
            this.checkBoxAddKeypointColorTran.TabIndex = 78;
            this.checkBoxAddKeypointColorTran.Text = "Auto Color";
            this.checkBoxAddKeypointColorTran.UseVisualStyleBackColor = true;
            // 
            // textBoxAddKeypointColorTran
            // 
            this.textBoxAddKeypointColorTran.Location = new System.Drawing.Point(831, 265);
            this.textBoxAddKeypointColorTran.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxAddKeypointColorTran.Name = "textBoxAddKeypointColorTran";
            this.textBoxAddKeypointColorTran.Size = new System.Drawing.Size(91, 27);
            this.textBoxAddKeypointColorTran.TabIndex = 77;
            // 
            // LightBallHelper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1546, 721);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.checkBoxAddKeypointColorTran);
            this.Controls.Add(this.textBoxAddKeypointColorTran);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.checkBoxAddKeypointFixSpace);
            this.Controls.Add(this.textBoxAddKeypointFixSpace);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.checkBoxAddKeypointFixDuration);
            this.Controls.Add(this.textBoxAddKeypointFixDuration);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.keypointStartingColor);
            this.Controls.Add(this.UpdownOffset);
            this.Controls.Add(this.BtnForwardMove);
            this.Controls.Add(this.BtnBackwardMove);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnDelKeypoint);
            this.Controls.Add(this.BtnAddKeypoint);
            this.Controls.Add(this.BtnDelEffect);
            this.Controls.Add(this.BtnAddEffect);
            this.Controls.Add(this.keypointsList);
            this.Controls.Add(this.effectsList);
            this.Controls.Add(this.effectsOptions);
            this.Controls.Add(this.pictureBoxIndicator);
            this.Controls.Add(this.labelRendering);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.updownBottomHeight);
            this.Controls.Add(this.updownTopHeight);
            this.Controls.Add(this.comboBoxPeakCalculationStrategy);
            this.Controls.Add(this.BtnBottomColour);
            this.Controls.Add(this.BtnTopColour);
            this.Controls.Add(this.audioTrackBar);
            this.Controls.Add(this.BtnStop);
            this.Controls.Add(this.BtnPlay);
            this.Controls.Add(this.labelTotalTime);
            this.Controls.Add(this.labelNowTime);
            this.Controls.Add(this.BtnLoadFile);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "LightBallHelper";
            this.Text = "LightBallHelper";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.LightBallHelper_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.audioTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updownTopHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updownBottomHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpdownOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIndicator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarColorSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColorBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLightness)).EndInit();
            this.keypointStartingColor.ResumeLayout(false);
            this.keypointStartingColor.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnLoadFile;
        private System.Windows.Forms.Label labelNowTime;
        private System.Windows.Forms.Label labelTotalTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button BtnPlay;
        private System.Windows.Forms.Button BtnStop;
        private System.Windows.Forms.TrackBar audioTrackBar;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button BtnTopColour;
        private System.Windows.Forms.Button BtnBottomColour;
        private System.Windows.Forms.ComboBox comboBoxPeakCalculationStrategy;
        private System.Windows.Forms.NumericUpDown updownTopHeight;
        private System.Windows.Forms.NumericUpDown updownBottomHeight;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelRendering;
        private System.Windows.Forms.PictureBox pictureBoxIndicator;
        private System.Windows.Forms.ListBox effectsOptions;
        private System.Windows.Forms.ListBox effectsList;
        private System.Windows.Forms.ListBox keypointsList;
        private System.Windows.Forms.Button BtnAddEffect;
        private System.Windows.Forms.Button BtnDelEffect;
        private System.Windows.Forms.Button BtnDelKeypoint;
        private System.Windows.Forms.Button BtnAddKeypoint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnBackwardMove;
        private System.Windows.Forms.Button BtnForwardMove;
        private System.Windows.Forms.NumericUpDown UpdownOffset;
        private System.Windows.Forms.TextBox textBoxEffectStart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxEffectEnd;
        private System.Windows.Forms.TrackBar trackBarColorSelect;
        private System.Windows.Forms.PictureBox pictureBoxColorBar;
        private System.Windows.Forms.TrackBar trackBarLightness;
        private System.Windows.Forms.TextBox textBoxColorR;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxColorG;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxColorB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxColorH;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxColorS;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxColorV;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button BtnColorShowStart;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox keypointStartingColor;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label effect;
        private System.Windows.Forms.TextBox textBoxEffectName;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBoxEffectTransition;
        private System.Windows.Forms.Button BtnColorShowEnd;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBoxColorStart;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox textBoxBrightTransition;
        private System.Windows.Forms.TextBox textBoxColorTransition;
        private System.Windows.Forms.TextBox textBoxKeypointDuration;
        private System.Windows.Forms.Button BtnKeypointSave;
        private System.Windows.Forms.Button BtnSetStartNowtime;
        private System.Windows.Forms.Button BtnSetColorNowtime;
        private System.Windows.Forms.Button BtnSetEndNowtime;
        private System.Windows.Forms.TextBox textBoxKeypointSpace;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Button BtnHistorySave;
        private System.Windows.Forms.Button BtnHistoryLoad;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnExport;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnSetGlobalStarting;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox textBoxGlobalStarting;
        private System.Windows.Forms.TextBox textBoxAddKeypointFixDuration;
        private System.Windows.Forms.CheckBox checkBoxAddKeypointFixDuration;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.CheckBox checkBoxAddKeypointFixSpace;
        private System.Windows.Forms.TextBox textBoxAddKeypointFixSpace;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.CheckBox checkBoxAddKeypointColorTran;
        private System.Windows.Forms.TextBox textBoxAddKeypointColorTran;
    }
}


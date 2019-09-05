using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;
using WaveFormRendererLib;

namespace LightBallHelper {
    public partial class LightBallHelper : Form {
        private IWavePlayer wavePlayer;
        private AudioFileReader audioFileReader;
        private string fileName = "";

        private readonly WaveFormRenderer waveFormRenderer;
        private readonly WaveFormRendererSettings standardSettings;

        string prefixNowTime = "Current: ";
        string prefixTotalTime ="Total: ";

        const int SEC_PIXEL_RATIOL = 60;
        const int START_POS = 50;
        const int WAVE_LOC_Y = 540;
        private int waveImageLen = 0;

        private List<Effects> effectListObj;
        private Color keyColor;
        public static TimeSpan globalStartingTime;

        public LightBallHelper() {
            InitializeComponent();
            labelNowTime.Text = prefixNowTime;
            labelTotalTime.Text = prefixTotalTime;

            waveFormRenderer = new WaveFormRenderer();
            standardSettings = new StandardWaveFormRendererSettings() { Name = "Standard" };

            BtnTopColour.BackColor = standardSettings.TopPeakPen.Color;
            BtnBottomColour.BackColor = standardSettings.BottomPeakPen.Color;

            updownTopHeight.Value = 80;
            updownBottomHeight.Value = 80;
            labelRendering.Visible = false;
            timer1.Enabled = false;
            Bitmap bitmap = new Bitmap(Resource1.indicator);
            pictureBoxIndicator.BackColor = Color.Transparent;
            pictureBoxIndicator.Location = new Point(START_POS-5, WAVE_LOC_Y-5);
            pictureBoxIndicator.Image = bitmap;

            UpdownOffset.Value = 50;

            comboBoxPeakCalculationStrategy.Items.Add("Max Rms Value");
            comboBoxPeakCalculationStrategy.Items.Add("Max Absolute Value");
            comboBoxPeakCalculationStrategy.Items.Add("Sampled Peaks");
            comboBoxPeakCalculationStrategy.Items.Add("Scaled Average");
            comboBoxPeakCalculationStrategy.SelectedIndex = 0;
            comboBoxPeakCalculationStrategy.SelectedIndexChanged += (sender, args) => {
                if ( !String.IsNullOrEmpty(fileName))
                    RenderWaveform();
            };

            effectListObj = new List<Effects>();

            effectsOptions.Items.Add("Color Transition");
            //effectsList.DisplayMember = "Effect_Name";
            keyColor = Color.AliceBlue;
            setColor(keyColor);
            //effectsList.ValueMember = "Time_Info";
            globalStartingTime = TimeSpan.Zero;
            textBoxGlobalStarting.Text = getFormatedTimeString(globalStartingTime);
            textBoxAddKeypointFixDuration.Text = "0.1";
            textBoxAddKeypointFixSpace.Text = "0.3";
            textBoxAddKeypointColorTran.Text = "0";
        }
        private void LightBallHelper_Paint(object sender, PaintEventArgs e) {
        }
        public static string getFormatedTimeString(TimeSpan time) {
            return string.Format("{0:D2}:{1:D2}:{2:D3}", (int)time.TotalMinutes, time.Seconds, time.Milliseconds);
        }
        public static TimeSpan getTimeSpanFromString(string str) {
            string[] words = str.Split(':');
            int min, sec, mill;
            if ( words.Length == 3
                && int.TryParse(words[0], out min)
                && int.TryParse(words[1], out sec)
                && int.TryParse(words[2], out mill) )
                return new TimeSpan(0, 0, min, sec, mill);
            MessageBox.Show("Time Format Error!\n" + str, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return TimeSpan.Zero;
        }
        public static double getDoubleFromString(string str) {
            double result;
            if ( double.TryParse(str, out result) )
                return result;
            MessageBox.Show("Double Format Error!\n" + str, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return 0;
        }
        public static int getIntFromString(string str) {
            int result;
            if ( int.TryParse(str, out result) )
                return result;
            MessageBox.Show("Int Format Error!\n" + str, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return 0;
        }
        #region PlayAudio
        private static string FormatTimeSpan(TimeSpan ts) {
            return string.Format("{0:D2}:{1:D2}:{2:D3}", (int)ts.TotalMinutes, ts.Seconds, ts.Milliseconds);
        }
        private void GenerateAudioFile() {
            if (wavePlayer == null || audioFileReader == null) {
                wavePlayer = CreateWavePlayer();
                audioFileReader = new AudioFileReader(fileName);
                wavePlayer.Init(audioFileReader);
                wavePlayer.PlaybackStopped += OnPlaybackStopped;
                labelTotalTime.Text = prefixTotalTime + FormatTimeSpan(audioFileReader.TotalTime);
                waveImageLen = (int)audioFileReader.TotalTime.TotalSeconds * SEC_PIXEL_RATIOL;
                pictureBox1.Size = new Size(waveImageLen, 265);
            }
        }
        private string SelectInputFile() {
            CloseWavePlayer();
            timer1.Enabled = true;
            var ofd = new OpenFileDialog();
            ofd.Filter = "Audio Files|*.mp3;*.wav;*.aiff;*.wma";
            if ( ofd.ShowDialog() == DialogResult.OK ) {
                fileName = ofd.FileName;
                GenerateAudioFile();
                RenderWaveform();
                return ofd.FileName;
            }
            return null;
        }
        private void BtnLoadFile_Click(object sender, EventArgs e) {
            fileName = SelectInputFile();
        }
        void OnTimerTick(object sender, EventArgs e) {
            if ( wavePlayer!=null && audioFileReader != null ) {
                TimeSpan currentTime = (wavePlayer.PlaybackState == PlaybackState.Stopped) ? TimeSpan.Zero : audioFileReader.CurrentTime;
                labelNowTime.Text = prefixNowTime + FormatTimeSpan(currentTime);
                audioTrackBar.Value = Math.Min(audioTrackBar.Maximum, (int)(audioTrackBar.Maximum * currentTime.TotalSeconds / audioFileReader.TotalTime.TotalSeconds));
                pictureBox1.Location = new Point(START_POS - (int)currentTime.TotalMilliseconds * SEC_PIXEL_RATIOL/1000, WAVE_LOC_Y);
            }
            else {
                labelNowTime.Text = prefixNowTime + "00:00:000";
                audioTrackBar.Value = 0;
            }
        }

        private void BtnPlay_Click(object sender, EventArgs e) {
            // wavePlayer already init
            if ( wavePlayer != null ) {
                //timer1.Enabled = !timer1.Enabled;
                if ( wavePlayer.PlaybackState == PlaybackState.Playing )
                    wavePlayer.Pause();
                else
                    wavePlayer.Play();
            }
            else {
                SelectInputFile();
            }
        }
        private IWavePlayer CreateWavePlayer() {
            switch ( 1 ) {
                //switch ( comboBoxOutputDriver.SelectedIndex ) {
                case 2:
                    return new WaveOutEvent();
                case 1:
                    return new WaveOut(WaveCallbackInfo.FunctionCallback());
                default:
                    return new WaveOut();
            }
        }

        private void CloseWavePlayer() {
            if ( wavePlayer != null )
                wavePlayer.Stop();
            if ( audioFileReader != null ) {
                // this one really closes the file and ACM conversion
                audioFileReader.Dispose();
                audioFileReader = null;
            }
            if ( wavePlayer != null ) {
                wavePlayer.Dispose();
                wavePlayer = null;
            }
        }
        void OnPlaybackStopped(object sender, StoppedEventArgs e) {
            // we want to be always on the GUI thread and be able to change GUI components
            Debug.Assert(!InvokeRequired, "PlaybackStopped on wrong thread");
            // we want it to be safe to clean up input stream and playback device in the handler for PlaybackStopped
            CloseWavePlayer();
            if ( e.Exception != null ) {
                MessageBox.Show(String.Format("Playback Stopped due to an error {0}", e.Exception.Message));
            }
        }

        private void BtnStop_Click(object sender, EventArgs e) {
            CloseWavePlayer();
        }

        private void AudioTrackBar_Scroll(object sender, EventArgs e) {
            if(wavePlayer!= null ) {
                audioFileReader.CurrentTime = TimeSpan.FromSeconds(audioFileReader.TotalTime.TotalSeconds 
                    * audioTrackBar.Value / audioTrackBar.Maximum);
            }
        }
        #endregion PlayAudio
        #region Draw Wave Form
        private IPeakProvider GetPeakProvider() {
            switch ( comboBoxPeakCalculationStrategy.SelectedIndex ) {
                case 0:
                    return new RmsPeakProvider(100);
                case 1:
                    return new MaxPeakProvider();
                case 2:
                    return new SamplingPeakProvider(100);
                case 3:
                    return new AveragePeakProvider(4);
                default:
                    throw new InvalidOperationException("Unknown calculation strategy");
            }
        }
        private void GetRendererSettings() {
            standardSettings.TopHeight = (int)updownTopHeight.Value;
            standardSettings.BottomHeight = (int)updownBottomHeight.Value;
            standardSettings.Width = waveImageLen;// this.Size.Width;
            //standardSettings.DecibelScale = checkBoxDecibels.Checked;
        }
        private void RenderWaveform() {
            if ( String.IsNullOrEmpty(fileName)) return;
            GetRendererSettings();
            //if ( imageFile != null ) {
            //    settings.BackgroundImage = new Bitmap(imageFile);
            //}
            pictureBox1.Image = null;
            labelRendering.Visible = true;
            Enabled = false;
            var peakProvider = GetPeakProvider();
            Task.Factory.StartNew(() => RenderThreadFunc(peakProvider, standardSettings));
        }
        private void RenderThreadFunc(IPeakProvider peakProvider, WaveFormRendererSettings settings) {
            Image image = null;
            try {
                image = waveFormRenderer.Render(fileName, peakProvider, settings);
            }
            catch ( Exception e ) {
                MessageBox.Show("error");
                MessageBox.Show(e.Message);
            }
            BeginInvoke((Action)(() => FinishedRender(image)));
        }

        private void FinishedRender(Image image) {
            labelRendering.Visible = false;
            pictureBox1.Image = image;
            Enabled = true;
        }
        private void OnColorButtonClick(object sender, EventArgs e) {
            var button = (Button) sender;
            var cd = new ColorDialog();
            cd.Color = button.BackColor;
            if ( cd.ShowDialog(this) == DialogResult.OK ) {
                button.BackColor = cd.Color;

                standardSettings.TopPeakPen = new Pen(BtnTopColour.BackColor);
                standardSettings.BottomPeakPen = new Pen(BtnBottomColour.BackColor);
                if( !String.IsNullOrEmpty(fileName) )
                    RenderWaveform();
            }
        }
        #endregion Draw Wave Form
        #region Main Effect
        private void BtnBackwardMove_Click(object sender, EventArgs e) {
            audioFileReader.CurrentTime = audioFileReader.CurrentTime.Subtract(new TimeSpan(0, 0, 0, 0, (int)UpdownOffset.Value));
        }

        private void BtnForwardMove_Click(object sender, EventArgs e) {
            audioFileReader.CurrentTime = audioFileReader.CurrentTime.Add(new TimeSpan(0, 0, 0, 0, (int)UpdownOffset.Value));
        }
        private Effects getEffectsById(int i) {
            switch ( i ) {
                case 0:
                    return new EffectColorTransition(audioFileReader.CurrentTime);
                default:
                    return new EffectColorTransition(audioFileReader.CurrentTime);
            }
        }
        private void BtnAddEffect_Click(object sender, EventArgs e) {
            if ( audioFileReader == null )
                MessageBox.Show("Please load music file before setting effects!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if ( effectsOptions.SelectedIndex < 0 )
                MessageBox.Show("Please select an effect from effect list!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                Effects new_effect = getEffectsById(effectsOptions.SelectedIndex);
                effectsList.Items.Add(new_effect.Effect_Name);
                effectListObj.Add(new_effect);
            }
        }
        private void BtnDelEffect_Click(object sender, EventArgs e) {
            if ( effectsList.SelectedIndex >= 0 ) {
                int index = effectsList.SelectedIndex;
                effectListObj.RemoveAt(index);
                effectsList.Items.RemoveAt(index);
            }
        }
        private Boolean mainTextBoxLoading = false;
        private void updateMainInputs() {
            if ( effectsList.SelectedIndex >= 0) {
                textBoxEffectName.Text = effectListObj[effectsList.SelectedIndex].effectName;
                textBoxEffectStart.Text = getFormatedTimeString(effectListObj[effectsList.SelectedIndex].startTime);
                textBoxEffectEnd.Text = getFormatedTimeString(effectListObj[effectsList.SelectedIndex].endTime);
                textBoxEffectTransition.Text = effectListObj[effectsList.SelectedIndex].transition.ToString();
            }
        }
        private void setMainInputs() {
            if ( !mainTextBoxLoading && effectsList.SelectedIndex >= 0 ) {
                effectListObj[effectsList.SelectedIndex].Effect_Name = textBoxEffectName.Text;
                effectListObj[effectsList.SelectedIndex].startTime = getTimeSpanFromString(textBoxEffectStart.Text);
                effectListObj[effectsList.SelectedIndex].endTime = getTimeSpanFromString(textBoxEffectEnd.Text);
                if ( !double.TryParse(textBoxEffectTransition.Text, out effectListObj[effectsList.SelectedIndex].transition) )
                    MessageBox.Show("Double Format Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                effectsList.Items[effectsList.SelectedIndex] = effectListObj[effectsList.SelectedIndex].Effect_Name;
            }
        }
        private void EffectsList_SelectedIndexChanged(object sender, EventArgs e) {
            mainTextBoxLoading = true;
            updateMainInputs();
            mainTextBoxLoading = false;

            keypointsList.Items.Clear();
            if ( effectsList.SelectedIndex >= 0 ) {
                effectListObj[effectsList.SelectedIndex].keypoints.ForEach((keypoint) =>
                {
                    keypointsList.Items.Add(keypoint.Time_Info);
                });
            }
            
        }
        private void MainInputsTextBox_TextChanged(object sender, EventArgs e) {
            setMainInputs();
        }
        #endregion
        #region Color Trans
        Color SetHue(Color oldColor) {
            var temp = new HSV();
            temp.h = oldColor.GetHue();
            temp.s = oldColor.GetSaturation();
            temp.v = getBrightness(oldColor);
            return ColorFromHSL(temp);
        }

        // A common triple float struct for both HSL & HSV
        // Actually this should be immutable and have a nice constructor!!
        public struct HSV { public double h; public double s; public double v;
            public HSV(double a, double b, double c) {
                h = a; s = b; v = c;
            }
        }

        // the Color Converter
        static public Color ColorFromHSL(HSV hsl) {
            if ( hsl.s == 0 ) { int L = (int)hsl.v; return Color.FromArgb(255, L, L, L); }

            double min, max, h;
            h = hsl.h / 360d;

            max = hsl.v < 0.5d ? hsl.v * (1 + hsl.s) : (hsl.v + hsl.s) - (hsl.v * hsl.s);
            min = (hsl.v * 2d) - max;

            Color c = Color.FromArgb(255, (int)(255 * RGBChannelFromHue(min, max,h + 1 / 3d)%256),
                                  (int)(255 * RGBChannelFromHue(min, max,h)%256),
                                  (int)(255 * RGBChannelFromHue(min, max,h - 1 / 3d))%256);
            return c;
        }

        static double RGBChannelFromHue(double m1, double m2, double h) {
            h = (h + 1d) % 1d;
            if ( h < 0 ) h += 1;
            if ( h * 6 < 1 ) return m1 + (m2 - m1) * 6 * h;
            else if ( h * 2 < 1 ) return m2;
            else if ( h * 3 < 2 ) return m1 + (m2 - m1) * 6 * (2d / 3d - h);
            else return m1;

        }
        float getBrightness(Color c) { return (c.R * 0.299f + c.G * 0.587f + c.B * 0.114f) / 256f; }
        #endregion
        #region Color Selector
        private void setColor(Color color) {
            keyColor = color;
            BtnColorShowStart.BackColor = color;
            textBoxColorH.Text = color.GetHue().ToString();
            textBoxColorS.Text = color.GetSaturation().ToString();
            textBoxColorV.Text = getBrightness(color).ToString();
            textBoxColorR.Text = color.R.ToString();
            textBoxColorG.Text = color.G.ToString();
            textBoxColorB.Text = color.B.ToString();
            trackBarColorSelect.Value = (int)color.GetHue() <= 0 ? 1 : (int)color.GetHue();
            trackBarLightness.Value = (int)(getBrightness(color)*100) <= 0 ? 1: (int)(getBrightness(color) * 100);
            setShowEndColor(color);
        }
        private void setShowEndColor(Color color) {
            BtnColorShowEnd.BackColor = ColorFromHSL(
                new HSV(color.GetHue() + (getDoubleFromString(textBoxColorTransition.Text) * getDoubleFromString(textBoxKeypointDuration.Text))
                , color.GetSaturation()
                , getBrightness(color) + (getDoubleFromString(textBoxBrightTransition.Text) * getDoubleFromString(textBoxKeypointDuration.Text))));
        }
        private void showEndColor_Changed(object sender, EventArgs e) {
            setShowEndColor(keyColor);
        }
        private void setColorWithRGBTextBox(object sender, EventArgs e) {
            Color new_color = Color.FromArgb(
                getIntFromString(textBoxColorR.Text),
                getIntFromString(textBoxColorG.Text),
                getIntFromString(textBoxColorB.Text));
            setColor(new_color);
        }
        private void setColorWithHSVTextBox(object sender, EventArgs e) {
            int r,g,b;
            Color new_color = ColorFromHSL(new HSV(getDoubleFromString(textBoxColorH.Text),
                getDoubleFromString(textBoxColorS.Text),
                getDoubleFromString(textBoxColorV.Text)));
            setColor(new_color);
        }
        private void setColorWithTrackBar(object sender, EventArgs e) {
            int r,g,b;
            Color new_color = ColorFromHSL(new HSV(trackBarColorSelect.Value,
                getDoubleFromString(textBoxColorS.Text),
                trackBarLightness.Value/100.0));
                setColor(new_color);
        }
        #endregion
        private void updateKeypointInputs() {
            if (keypointsList.SelectedIndex >= 0 ) {
                KeyPoint target = effectListObj[effectsList.SelectedIndex].keypoints[keypointsList.SelectedIndex];
                textBoxColorStart.Text = getFormatedTimeString(target.startTime);
                textBoxKeypointDuration.Text = target.duration.ToString();
                setColor(target.color);
                textBoxColorTransition.Text = target.colorTransition.ToString();
                textBoxBrightTransition.Text = target.brightTransition.ToString();
            }
        }
        private void setKeypointInputs() {
            if ( keypointsList.SelectedIndex >= 0 ) {
                effectListObj[effectsList.SelectedIndex].keypoints[keypointsList.SelectedIndex].startTime = getTimeSpanFromString(textBoxColorStart.Text);
                effectListObj[effectsList.SelectedIndex].keypoints[keypointsList.SelectedIndex].duration = getDoubleFromString(textBoxKeypointDuration.Text);
                effectListObj[effectsList.SelectedIndex].keypoints[keypointsList.SelectedIndex].color = keyColor;
                effectListObj[effectsList.SelectedIndex].keypoints[keypointsList.SelectedIndex].colorTransition = getDoubleFromString(textBoxColorTransition.Text);
                effectListObj[effectsList.SelectedIndex].keypoints[keypointsList.SelectedIndex].colorTransition = getDoubleFromString(textBoxBrightTransition.Text);
                keypointsList.Items[keypointsList.SelectedIndex] = effectListObj[effectsList.SelectedIndex].keypoints[keypointsList.SelectedIndex].Time_Info;
            }
        }
        private void KeypointsList_SelectedIndexChanged(object sender, EventArgs e) {
            updateKeypointInputs();
        }
        private void BtnAddKeypoint_Click(object sender, EventArgs e) {
            if (effectsList.SelectedIndex < 0)
                MessageBox.Show("Please select a effect first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (keypointsList.SelectedIndex < 0 )
                MessageBox.Show("Please select a keypoint first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                Color color = keyColor;
                if ( checkBoxAddKeypointColorTran.Checked ) {
                    Color starting_color = effectListObj[effectsList.SelectedIndex].keypoints[0].color;
                    color = ColorFromHSL(
                        new HSV(color.GetHue() + (getDoubleFromString(textBoxAddKeypointColorTran.Text) * (audioFileReader.CurrentTime.Subtract(effectListObj[effectsList.SelectedIndex].keypoints[0].startTime).TotalSeconds))
                        , starting_color.GetSaturation()
                        , getBrightness(starting_color) ));
                }
                KeyPoint new_keypoint;
                if ( checkBoxAddKeypointFixSpace.Checked ) {
                    TimeSpan space=  TimeSpan.FromSeconds(getDoubleFromString(textBoxAddKeypointFixSpace.Text));
                    double dur = audioFileReader.CurrentTime.Subtract(effectListObj[effectsList.SelectedIndex].keypoints[keypointsList.SelectedIndex].startTime).Subtract(space).TotalSeconds;
                    new_keypoint = new KeyPoint(audioFileReader.CurrentTime, color, dur);
                } 
                else if ( checkBoxAddKeypointFixDuration.Checked ) {
                    double dur = getDoubleFromString(textBoxAddKeypointFixDuration.Text);
                    new_keypoint = new KeyPoint(audioFileReader.CurrentTime, color, dur);
                }
                else
                    new_keypoint = new KeyPoint(audioFileReader.CurrentTime, color);
                effectListObj[effectsList.SelectedIndex].keypoints.Add(new_keypoint);
                keypointsList.Items.Add(new_keypoint.Time_Info);
                keypointsList.SelectedIndex += 1;
                audioFileReader.CurrentTime = audioFileReader.CurrentTime.Add(new TimeSpan(0, 0, 0, 0, (int)UpdownOffset.Value));
            }
        }
        private void BtnDelKeypoint_Click(object sender, EventArgs e) {
            if ( effectsList.SelectedIndex >= 0 && keypointsList.SelectedIndex >= 0 ) {
                if ( effectListObj[effectsList.SelectedIndex].keypoints.Count <= 1 ) {
                    MessageBox.Show("There must be at least a keypoint in an effect!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int index = keypointsList.SelectedIndex;
                effectListObj[effectsList.SelectedIndex].keypoints.RemoveAt(index);
                keypointsList.Items.RemoveAt(index);
            }
        }
        private void BtnKeypointSave_Click(object sender, EventArgs e) {
            setKeypointInputs();
        }
        private void BtnSetStartNowtime_Click(object sender, EventArgs e) {
            textBoxEffectStart.Text = audioFileReader != null ? getFormatedTimeString(audioFileReader.CurrentTime) : "0";
            setMainInputs();
        }
        private void BtnSetEndNowtime_Click(object sender, EventArgs e) {
            textBoxEffectEnd.Text = audioFileReader != null ? getFormatedTimeString(audioFileReader.CurrentTime) : "0";
            setMainInputs();
        }
        private void BtnSetGlobalStarting_Click(object sender, EventArgs e) {
            textBoxGlobalStarting.Text = audioFileReader != null ? getFormatedTimeString(audioFileReader.CurrentTime) : "0";
            globalStartingTime = audioFileReader.CurrentTime;
        }
        private void BtnSetColorNowtime_Click(object sender, EventArgs e) {
            textBoxColorStart.Text = audioFileReader != null ? getFormatedTimeString(audioFileReader.CurrentTime) : "0";
            setKeypointInputs();
        }
        private void BtnHistorySave_Click(object sender, EventArgs e) {
            var ofd = new SaveFileDialog();
            ofd.Filter = "LightBallHistory|*.lbh";
            if ( ofd.ShowDialog() == DialogResult.OK ) {
                Effects.SaveHistory(ofd.FileName, effectListObj);
            }
        }
        private void BtnHistoryLoad_Click(object sender, EventArgs e) {
            var ofd = new OpenFileDialog();
            ofd.Filter = "LightBallHistory|*.lbh";
            if ( ofd.ShowDialog() == DialogResult.OK ) {
                Effects.LoadHistory(ofd.FileName, out effectListObj);
                effectsList.Items.Clear();
                effectListObj.ForEach((eff) =>
                {
                    effectsList.Items.Add(eff.Effect_Name);
                });
            }
        }
        private void BtnExport_Click(object sender, EventArgs e) {
            var ofd = new SaveFileDialog();
            ofd.Filter = "Array|*.cpp";
            if ( ofd.ShowDialog() == DialogResult.OK ) {
                Effects.ExportTasks(ofd.FileName, effectListObj);
            }
        }
        private void BtnColorShowStart_Click(object sender, EventArgs e) {
            ColorDialog colorDlg = new ColorDialog();
            colorDlg.Color = keyColor;
            if ( colorDlg.ShowDialog() == DialogResult.OK ) {
                setColor(colorDlg.Color);
            }
        }
        private void CheckBoxAddKeypointFixDuration_CheckedChanged(object sender, EventArgs e) {
            if ( checkBoxAddKeypointFixSpace.Checked )
                checkBoxAddKeypointFixSpace.Checked = false;
        }
        private void CheckBoxAddKeypointFixSpace_CheckedChanged(object sender, EventArgs e) {
            if ( checkBoxAddKeypointFixDuration.Checked )
                checkBoxAddKeypointFixDuration.Checked = false;
        }
    }
}

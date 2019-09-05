using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LightBallHelper {
    class KeyPoint {
        static private Color defaultColor = Color.Bisque;
        const double defaultDuration = 1; // in seconds
        public TimeSpan startTime;
        public double duration; // in seconds

        public double colorTransition;
        public double brightTransition;
        public Color color;
        public string Time_Info {
            get {
                return (string.Format("{0:D2}:{1:D2}:{2:D3}", (int)startTime.TotalMinutes, startTime.Seconds
                    , startTime.Milliseconds) + " \t " + string.Format("{0:0.000}", duration));
            }
        }
        public KeyPoint(TimeSpan start_time, double dur = defaultDuration) {
            this.startTime = start_time;
            duration = dur;
            color = defaultColor;
            colorTransition = 0;
            brightTransition = 0;
        }
        public KeyPoint(TimeSpan start_time, double dur, Color col, double colTran, double briTran) {
            this.startTime = start_time;
            duration = dur;
            color = col;
            colorTransition = colTran;
            brightTransition = briTran;
        }
        public KeyPoint(TimeSpan start_time, Color col, double dur = defaultDuration) {
            this.startTime = start_time;
            duration = dur;
            color = col;
            colorTransition = 0;
            brightTransition = 0;
        }
    }
    class Effects {
        public const int defaultDuration = 10; // in seconds
        public const int defaultTransition = 0; // in seconds
        public string effectName;
        private static int nameCounter = 0;
        public string Effect_Name {
            get {
                return (this.effectName + "\t" + string.Format("{0:D2}:{1:D2}:{2:D3}", (int)startTime.TotalMinutes, startTime.Seconds, startTime.Milliseconds));
            }
            set { this.effectName = value; }
        }
        public string Time_Info {
            get { return string.Format("{0:D2}:{1:D2}:{2:D3}", (int)startTime.TotalMinutes, startTime.Seconds, startTime.Milliseconds); }
            }
        public TimeSpan startTime;
        public TimeSpan endTime;
        public double transition;
        public List<KeyPoint> keypoints;
        public Effects(TimeSpan nowtime, string name = "unamed effect", double dur= defaultDuration, double tran= defaultTransition) {
            effectName = name;
            startTime = nowtime;
            endTime = startTime.Add(new TimeSpan(0, 0, (int)Math.Floor(dur), ((int)Math.Floor(dur*1000))/1000));
            transition = tran;
            keypoints = new List<KeyPoint>();
            keypoints.Add(new KeyPoint(startTime));
        }
        public Effects(TimeSpan nowtime, TimeSpan end, string name = "unamed effect", double tran = defaultTransition) {
            if ( name == "unamed effect" )
                name += nameCounter;
            effectName = name;
            startTime = nowtime;
            endTime = end;
            transition = tran;
            keypoints = new List<KeyPoint>();
        }
        public void Add(TimeSpan nowtime, double dur = defaultDuration) {
            keypoints.Add(new KeyPoint(nowtime));
        }
        public void Add(TimeSpan start_time, double dur, Color col, double colTran, double briTran) {
            keypoints.Add(new KeyPoint(start_time, dur, col, colTran, briTran));
        }
        public void Delete(int index) {
            keypoints.RemoveAt(index);
        }
        public string GetHistory() {
            string cmd = effectName + "," + startTime + "," + endTime + "," + transition + "\n";
            keypoints.ForEach((key) =>
            {
                cmd += this.effectName + "," + LightBallHelper.getFormatedTimeString(key.startTime) + "," + key.duration + "," + key.colorTransition + "," + key.brightTransition + "," + key.color.R + "," + key.color.G + ","  + key.color.B + "\n";
            });
            return cmd;
        }
        public static void SaveHistory(string filename, List<Effects> effects) {
            string cmd = "";
            effects.ForEach((effect) =>
            {
                cmd += effect.GetHistory();
            });
            StreamWriter sw = new StreamWriter(filename);
            sw.WriteLine(cmd);
            sw.Close();
        }
        public static void LoadHistory(string filename, out List<Effects> effects) {
            effects = new List<Effects>();
            StreamReader sr = new StreamReader(filename);
            string line;
            string effect_name = "";
            Effects now_eff = null;
            while((line = sr.ReadLine()) != null ) {
                string[] strs = line.Split(',');
                if ( strs.Length <= 1 )
                    continue;
                if (strs[0] != effect_name) {
                    if ( now_eff != null )
                        effects.Add(now_eff);
                    effect_name = strs[0];
                    MessageBox.Show(line);
                    // public Effects(TimeSpan nowtime, TimeSpan end, string name = "unamed effect", double tran = defaultTransition)
                    now_eff = new Effects(LightBallHelper.getTimeSpanFromString(strs[1]), LightBallHelper.getTimeSpanFromString(strs[2]), effect_name, LightBallHelper.getDoubleFromString(strs[3]));
                }
                else {
                    now_eff.Add(LightBallHelper.getTimeSpanFromString(strs[1]),
                        LightBallHelper.getDoubleFromString(strs[2]),
                        Color.FromArgb(LightBallHelper.getIntFromString(strs[5]),
                                       LightBallHelper.getIntFromString(strs[6]),
                                       LightBallHelper.getIntFromString(strs[7])),
                        LightBallHelper.getDoubleFromString(strs[3]),
                        LightBallHelper.getDoubleFromString(strs[4]));
                }
            }
            effects.Add(now_eff);
            sr.Close();
        }
        public static void ExportTasks(string filename, List<Effects> effects) {
            string cmd = "";
            effects.ForEach((eff) =>
            {
                eff.keypoints.ForEach((key) =>
                {
                    TimeSpan t_start = key.startTime.Subtract(LightBallHelper.globalStartingTime);
                    int start = 1000 * t_start.Seconds + t_start.Milliseconds;
                    cmd += "{LM_SET_HSL_PROGRESSIVE," + start + "," + (int)1000 * key.duration + "," + (int)key.color.GetHue() + "," + (int)(key.color.GetSaturation() * 255) + "," + (int)(key.color.GetBrightness() * 255) + "," + (int)(1000 * key.colorTransition) + "," + (int)(1000 * key.brightTransition) + "},\n";
                });
            });
            StreamWriter sw = new StreamWriter(filename);
            sw.WriteLine(cmd);
            sw.Close();
        }
    }
    class EffectColorTransition : Effects {
        public EffectColorTransition(TimeSpan starttime, string name = "unamed effect")
            : base(starttime, name) {
        }
    }
}

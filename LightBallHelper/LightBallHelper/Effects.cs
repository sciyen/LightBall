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
        public static Color defaultColor = Color.Bisque;
        public const double defaultDuration = 1; // in seconds
        public const double defaultDuty = 100; // in percentage
        public TimeSpan startTime;
        public double duration; // in seconds
        public double duty;     // in percentage

        public double colorTransition;
        public double brightTransition;
        public Color color;

        /* Effect Attr (Auto Generation) */
        public string Time_Info {
            get {
                return (string.Format("{0:D2}:{1:D2}:{2:D3}", (int)startTime.TotalMinutes, startTime.Seconds
                    , startTime.Milliseconds) + " \t " + string.Format("{0:0.000}", duration));
            }
        }
        public KeyPoint(TimeSpan start_time, Color col, double dur, double duty, double colTran, double briTran) {
            this.startTime = start_time;
            duration = dur;
            this.duty = duty;
            color = col;
            colorTransition = colTran;
            brightTransition = briTran;
        }
        public KeyPoint(TimeSpan start_time, Color col, double dur = defaultDuration, double duty = defaultDuty) {
            this.startTime = start_time;
            duration = dur;
            this.duty = duty;
            color = col;
            colorTransition = 0;
            brightTransition = 0;
        }
    }
    abstract class Effects {
        public enum AutoGenMode { enable, disable, either };
        public enum EffectsNames { EffectHSL, EffectColorTransition, EffectSparkAsync, End};
        public EffectsNames effectName;

        public AutoGenMode autoGenMode;
        public bool autoGen = false;
        public int para_len;
        public string[] para_label;
        public string[] para_value;
        public string[] para_unit;
        public const int defaultDuration = 10; // in seconds
        public const int defaultTransition = 0; // in seconds
        public string Effect_Name {
            get {
                return (this.effectName.ToString() + "\t" + string.Format("{0:D2}:{1:D2}:{2:D3}", (int)startTime.TotalMinutes, startTime.Seconds, startTime.Milliseconds));
            }
        }
        public string Time_Info {
            get { return string.Format("{0:D2}:{1:D2}:{2:D3}", (int)startTime.TotalMinutes, startTime.Seconds, startTime.Milliseconds); }
            }
        public TimeSpan startTime;
        public TimeSpan endTime;
        public double transition;
        public List<KeyPoint> keypoints;
        public Effects(TimeSpan nowtime, EffectsNames name, double dur= defaultDuration, double tran= defaultTransition) {
            effectName = name;
            startTime = nowtime;
            endTime = startTime.Add(new TimeSpan(0, 0, (int)Math.Floor(dur), ((int)Math.Floor(dur*1000))/1000));
            transition = tran;
            keypoints = new List<KeyPoint>();
            keypoints.Add(new KeyPoint(startTime, KeyPoint.defaultColor));
        }
        public Effects(TimeSpan nowtime, TimeSpan end, EffectsNames name, double tran = defaultTransition) {
            effectName = name;
            startTime = nowtime;
            endTime = end;
            transition = tran;
            keypoints = new List<KeyPoint>();
        }
        public void Add(TimeSpan nowtime, double dur = defaultDuration) {
            keypoints.Add(new KeyPoint(nowtime, KeyPoint.defaultColor));
        }
        public void Add(TimeSpan start_time, double dur, double duty, Color col, double colTran, double briTran) {
            keypoints.Add(new KeyPoint(start_time, col, dur, duty, colTran, briTran));
        }
        public void Delete(int index) {
            keypoints.RemoveAt(index);
        }
        public abstract string GetHistory(int id);
        public abstract void LoadKeypoints(string[] strs);
        public abstract string GetTasks();
        public static void SaveHistory(string filename, List<Effects> effects) {
            string cmd = "";
            int cmd_id = 0;
            effects.ForEach((effect) =>
            {
                cmd += effect.GetHistory(cmd_id);
                cmd_id++;
            });
            StreamWriter sw = new StreamWriter(filename);
            sw.WriteLine(cmd);
            sw.Close();
        }
        public static void RestoreHistory(string filename, out List<Effects> effects) {
            effects = new List<Effects>();
            StreamReader sr = new StreamReader(filename);
            Effects now_eff = null;
            string line;
            int cmd_id = -1;
            while((line = sr.ReadLine()) != null ) {
                string[] strs = line.Split(',');
                if ( strs.Length <= 1 )
                    continue;
                int id;
                if ( int.TryParse(strs[0], out id) ) {
                    if ( cmd_id != id ) {
                        if ( now_eff != null )
                            effects.Add(now_eff);
                        cmd_id = id;
                        EffectsNames effect = (EffectsNames)Enum.Parse(typeof(EffectsNames), strs[1]);
                        TimeSpan start = LightBallHelper.getTimeSpanFromString(strs[2]);
                        switch ( effect ) {
                            case EffectsNames.EffectHSL:
                                now_eff = new EffectHSL(start); break;
                            case EffectsNames.EffectColorTransition:
                                now_eff = new EffectColorTransition(start); break;
                            case EffectsNames.EffectSparkAsync:
                                now_eff = new EffectSparkAsync(start); break;
                            default:
                                 break;
                        }
                    }
                    else
                        now_eff.LoadKeypoints(strs);
                }
            }
            sr.Close();
        }
        public static void ExportTasks(string filename, List<Effects> effects) {
            string cmd = "";
            effects.ForEach((eff) =>
            {
                cmd += eff.GetTasks();
            });
            StreamWriter sw = new StreamWriter(filename);
            sw.WriteLine(cmd);
            sw.Close();
        }
    }
    class EffectHSL : Effects {
        public EffectHSL(TimeSpan start_time)
            :base(start_time, EffectsNames.EffectHSL) {
            base.autoGenMode = AutoGenMode.either;
            base.para_len = 3;
            base.para_label = new string[] { "Count", "Duration", "Duty" };
            base.para_unit = new string[] { "times", "sec", "%" };
            base.para_value = new string[] { "1", "0.45", "100" };
        }
        public EffectHSL(string[] strs)
            : base(LightBallHelper.getTimeSpanFromString(strs[2]), EffectsNames.EffectHSL) {
            base.autoGenMode = AutoGenMode.either;
            base.para_len = 3;
            base.endTime = LightBallHelper.getTimeSpanFromString(strs[3]);
            autoGen = (strs[4] == "autoGen" ? true : false);
            base.para_value = new string[] { strs[5], strs[6], strs[7] };
        }
        public override string GetHistory(int id) {
            string autoGenStr = (autoGen ? "autoGen" : "manGen");
            string cmd = id + "," + this.effectName + "," + LightBallHelper.getFormatedTimeString(startTime) + "," + LightBallHelper.getFormatedTimeString(endTime) + "," + autoGenStr +","  + "," + para_value[0] + "," + para_value[1] + "," + para_value[2] + "\n";
            keypoints.ForEach((key) =>
            {
                cmd += id + "," + this.effectName + "," + LightBallHelper.getFormatedTimeString(key.startTime) + "," +
                key.duration + "," + key.duty + "," + key.color.R + "," + key.color.G + "," + key.color.B + "\n";
            });
            return cmd;
        }
        public override void LoadKeypoints(string[] strs) {
            this.Add(LightBallHelper.getTimeSpanFromString(strs[2]),    // Start_time
            LightBallHelper.getDoubleFromString(strs[3]),               // Duration
            LightBallHelper.getDoubleFromString(strs[4]),               // Duty
            Color.FromArgb(LightBallHelper.getIntFromString(strs[5]),   // R
                           LightBallHelper.getIntFromString(strs[6]),   // G
                           LightBallHelper.getIntFromString(strs[7])),  // B
            0, 0);
        }
        public override string GetTasks() {
            string cmd = "";
            keypoints.ForEach((key) =>
            {
                TimeSpan t_start = key.startTime.Subtract(LightBallHelper.globalStartingTime);
                int start = 1000 * t_start.Seconds + t_start.Milliseconds;
                cmd += "{LM_SET_HSL," + start + "," + (int)1000 * key.duration + "," + (int)key.color.GetHue() + "," + (int)(key.color.GetSaturation() * 255) + "," + (int)(key.color.GetBrightness() * 255) + "},\n";
            });
            return cmd;
        }
    }
    class EffectColorTransition : Effects {
        public EffectColorTransition(TimeSpan start_time)
            : base(start_time, EffectsNames.EffectColorTransition) {
            base.autoGenMode = AutoGenMode.either;
            base.para_len = 5;
            base.para_label = new string[] { "Count", "Duration", "Duty", "ColorTran", "BrightTran" };
            base.para_unit  = new string[] { "times", "sec"     , "%"   , "sec"      , "sec" };
            base.para_value = new string[] { "1"    , "0.45"    , "100" , "0"        , "0" };
        }
        public EffectColorTransition(string[] strs)
            : base(LightBallHelper.getTimeSpanFromString(strs[2]), EffectsNames.EffectColorTransition) {
            base.autoGenMode = AutoGenMode.either;
            base.para_len = 5;
            base.endTime = LightBallHelper.getTimeSpanFromString(strs[3]);
            autoGen = (strs[4] == "autoGen" ? true : false);
            base.para_value = new string[] { strs[5], strs[6], strs[7], strs[8], strs[9] };
        }
        public override string GetHistory(int id) {
            string autoGenStr = (autoGen ? "autoGen" : "manGen");
            string cmd = id + "," + this.effectName + "," + LightBallHelper.getFormatedTimeString(startTime) + "," + LightBallHelper.getFormatedTimeString(endTime) + "," + autoGenStr +","  + "," + para_value[0] + "," + para_value[1] + "," + para_value[2] + para_value[3] + "," + para_value[4] + "\n";
            keypoints.ForEach((key) =>
            {
                cmd += id +","+ this.effectName + "," + LightBallHelper.getFormatedTimeString(key.startTime) + "," + key.duration + "," + key.duty + "," + key.colorTransition + "," + key.brightTransition + "," + key.color.R + "," + key.color.G + "," + key.color.B + "\n";
            });
            return cmd;
        }
        public override void LoadKeypoints(string[] strs) {
            this.Add(LightBallHelper.getTimeSpanFromString(strs[2]),    // Start_time
            LightBallHelper.getDoubleFromString(strs[3]),               // Duration
            LightBallHelper.getDoubleFromString(strs[4]),               // Duty
            Color.FromArgb(LightBallHelper.getIntFromString(strs[7]),   // R
                            LightBallHelper.getIntFromString(strs[8]),  // G
                            LightBallHelper.getIntFromString(strs[9])), // B
            LightBallHelper.getDoubleFromString(strs[5]),               // Color Tran
            LightBallHelper.getDoubleFromString(strs[6]));              // Bright Tran
        }
        public override string GetTasks() {
            string cmd = "";
            keypoints.ForEach((key) =>
            {
                TimeSpan t_start = key.startTime.Subtract(LightBallHelper.globalStartingTime);
                int start = 1000 * t_start.Seconds + t_start.Milliseconds;
                cmd += "{LM_SET_HSL_PROGRESSIVE," + start + "," + (int)1000 * key.duration + "," + (int)key.color.GetHue() + "," + (int)(key.color.GetSaturation() * 255) + "," + (int)(key.color.GetBrightness() * 255) + "," + (int)(1000 * key.colorTransition) + "," + (int)(1000 * key.brightTransition) + "},\n";
            });
            return cmd;
        }
    }
    class EffectSparkAsync : Effects {
        public EffectSparkAsync(TimeSpan start_time)
            : base(start_time, EffectsNames.EffectSparkAsync) {
            base.autoGenMode = AutoGenMode.enable;
            base.para_len = 5;
            base.para_label = new string[] { "Count", "Duration", "Duty", "ColorTran", "MeteorTran" };
            base.para_unit = new string[] { "times", "sec", "%", "sec", "sec" };
            base.para_value = new string[] { "1", "0.45", "100", "0", "0" };
        }
        public EffectSparkAsync(string[] strs)
            : base(LightBallHelper.getTimeSpanFromString(strs[2]), EffectsNames.EffectSparkAsync) {
            base.autoGenMode = AutoGenMode.enable;
            base.para_len = 5;
            base.endTime = LightBallHelper.getTimeSpanFromString(strs[3]);
            base.para_value = new string[] { strs[7], strs[8], strs[9], strs[10], strs[11] };
            this.Add(this.startTime, 0, 0, 
             Color.FromArgb(LightBallHelper.getIntFromString(strs[4]),   // R
                            LightBallHelper.getIntFromString(strs[5]),   // G
                            LightBallHelper.getIntFromString(strs[6])),  // B
             0, 0);              // Bright Tran
        }
        public override string GetHistory(int id) {
            KeyPoint key = keypoints[0];
            string cmd = id + "," + this.effectName + "," + LightBallHelper.getFormatedTimeString(startTime) + "," + LightBallHelper.getFormatedTimeString(endTime) + "," + key.color.R + "," + key.color.G + "," + key.color.B + "," + para_value[0] + "," + para_value[1] + "," + para_value[2] + para_value[3] + "," + para_value[4] + "\n";
            return cmd;
        }
        public override void LoadKeypoints(string[] strs) {
            /* No need */
        }
        public override string GetTasks() {
            string cmd = "";
            keypoints.ForEach((key) =>
            {
                TimeSpan t_start = key.startTime.Subtract(LightBallHelper.globalStartingTime);
                int start = 1000 * t_start.Seconds + t_start.Milliseconds;
                cmd += "{LM_SET_HSL_SPARK_ASYNC," + start + "," + (int)1000 * key.duration + "," + (int)key.color.GetHue() + "," + (int)(key.color.GetSaturation() * 255) + "," + (int)(key.color.GetBrightness() * 255) + "," + (int)(1000 * key.colorTransition) + "," + (int)(1000 * key.brightTransition) + "},\n";
            });
            return cmd;
        }
    }
}

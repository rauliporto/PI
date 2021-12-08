using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Text;

public sealed class Statistics : MonoBehaviour
{
    
    private static readonly Statistics instance = new Statistics();
    private static Statistics statistics;

    public Text times;
    private static Dictionary<int, CountPatients> stats;

    static Statistics()
    {
        statistics = new Statistics();
        stats = new Dictionary<int, CountPatients>();
    }

    public void setStatistics(int gravity, float time)
    {        
        if (stats.ContainsKey(gravity)) {
            stats[gravity].increaseTotalPatients();
            stats[gravity].increaseTotalTime(time);
        }
        else
            stats.Add(gravity, new CountPatients(1, time));
    }

    public void writeFile(int gravity, float time, int exam)
    {
        string workingDirectory = Environment.CurrentDirectory;
        String path = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        if (!File.Exists(path + "/test.csv"))
        {
            //Open the File
            StreamWriter sw = File.CreateText(path+"/test.csv");
            sw.Write(gravity + ";" + exam + ";" + time+"\n");
            sw.Close();
        }
        else
        {
            StreamWriter sw = File.AppendText(path + "/test.csv");
            sw.Write(gravity + ";" + exam + ";" + time+"\n");
            sw.Close();
        }
    }

    void Update()
    {
        times.text = "";
        foreach (KeyValuePair<int, CountPatients> s in stats)
        {         
            times.text += "<color="+gravityToColor(s.Key).Key+">" + gravityToColor(s.Key).Value +"</color>" + ":" + (s.Value.getTotalTime()/s.Value.getTotalPatients()) + "\n";
        }
    }

    private KeyValuePair<string, string> gravityToColor(int gravity)
    {
        switch (gravity)
        {
            case 1: return new KeyValuePair<string, string>("red", "Vermelho");
            case 2: return new KeyValuePair<string, string>("#FFA500", "Laranja");
            case 3: return new KeyValuePair<string, string>("yellow", "Amarelo");
            case 4: return new KeyValuePair<string, string>("blue", "Azul");
            case 5: return new KeyValuePair<string, string>("green", "Verde");
            default:
               return new KeyValuePair<string, string>("white", "Branco");
        } 
    }
    
    public static Statistics Instance
    {
        get { return instance; }
    }

    private class CountPatients
    {
        private int totalPatients;
        private float totalTime;

        public CountPatients(int tp, float tt)
        {
            totalPatients = tp;
            totalTime = tt;
        }

        public int getTotalPatients() {
            return totalPatients;
        }
        
        public float getTotalTime() {
            return totalTime;
        }

        public void increaseTotalPatients() {
            totalPatients++;
        }
        
        public void increaseTotalTime(float time) {
            totalTime += time;
        }
    }

}

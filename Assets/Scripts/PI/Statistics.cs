using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Text;
using System.Linq;

public sealed class Statistics : MonoBehaviour
{
    
    private static readonly Statistics instance = new Statistics();
    private static Statistics statistics;

    public Text times;
    private static SortedDictionary<int, CountPatients> stats;

    static Statistics()
    {
        statistics = new Statistics();
        stats = new SortedDictionary<int, CountPatients>();
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
    
    public void writeFileTotals(int gravity, float time, bool exam)
    {
        string txt = gravity + ";" + exam + ";" + time+"\n";
        writeFile("/test.csv", txt);
    }

    public void writeFileTriage(float time)
    {
        string txt = time+"\n";
        writeFile("/testTriagem.csv", txt);
    }

    public void writeFileDoctor(int gravity, float time)
    {
        string txt = gravity + ";" + time+"\n";
        writeFile("/testMedico.csv", txt);
    }

    public void writeFile(string name, string text)
    {
        String path = Directory.GetCurrentDirectory();
        if (!File.Exists(path + name))
        {
            //Open the File
            StreamWriter sw = File.CreateText(path + name);
            sw.Write(text);
            sw.Close();
        }
        else
        {
            StreamWriter sw = File.AppendText(path + name);
            sw.Write(text);
            sw.Close();
        }
    }

    void Update()
    {
        double total = 0;
        times.text = "";
        if(stats.Count != 0) 
            times.text = "<b>Cores     Tempo   Quantidade</b>\n";


        foreach (KeyValuePair<int, CountPatients> s in stats.OrderBy(key => key.Key))
        {   
            total = System.Math.Round(((s.Value.getTotalTime()/10)/s.Value.getTotalPatients()), 2);     
            times.text += "<color="+gravityToColor(s.Key).Key+">" + gravityToColor(s.Key).Value +"</color>" + total + "    " + s.Value.getTotalPatients().ToString() + "\n";
        }
    }

    private KeyValuePair<string, string> gravityToColor(int gravity)
    {
        switch (gravity)
        {
            case 1: return new KeyValuePair<string, string>("red",     "Vermelho:");
            case 2: return new KeyValuePair<string, string>("#FFA500", "Laranja:   ");
            case 3: return new KeyValuePair<string, string>("yellow",  "Amarelo:  ");
            case 4: return new KeyValuePair<string, string>("blue",    "Azul:        ");
            case 5: return new KeyValuePair<string, string>("green",   "Verde:      ");
            default:
               return new KeyValuePair<string, string>("white", "Branco:    ");
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

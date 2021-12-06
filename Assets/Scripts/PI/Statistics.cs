using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    void Update()
    {
        times.text = "";
        foreach (KeyValuePair<int, CountPatients> s in stats)
        {         
            times.text += "<color="+gravityToColor(s.Key)+">" + gravityToString(s.Key) +"</color>" + ":" + (s.Value.getTotalTime()/s.Value.getTotalPatients()) + "\n";
        }
    }

    private string gravityToString(int gravity)
    {
        switch (gravity)
        {
            case 1: return "Vermelho";
            case 2: return "Laranja";
            case 3: return "Amarelo";
            case 4: return "Azul";
            case 5: return "Verde";
            default:
               return "Branco";
        } 
    }

    private string gravityToColor(int gravity)
    {
        switch (gravity)
        {
            case 1: return "red"; 
            case 2: return "#FFA500";
            case 3: return "yellow";
            case 4: return "blue"; 
            case 5: return "green";
            default:
                return "white";
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class examesMedicos : MonoBehaviour
{
    private static readonly examesMedicos instance = new examesMedicos();
    private static examesMedicos exames;

    private int TOTAL_ACONTECIMENTOS = 10;
    private float PROB_SUCESSOS = 0.6f;
    private int tentativa;
    private float prox_sucesso = -1;
    private float intervalo_sucesso;
    private float sucessos_acumulados;
    
    
    static examesMedicos()
    {
        exames = new examesMedicos();
    }

    public static examesMedicos Instance
    {
        get { return instance; }
    }

    private int binomial(int n, float p)
    {
        int sum = 0;
        for (int i = 0; i < n; i++) sum += Convert.ToInt32(bernoulli(p));
        return sum;
    }

    private bool bernoulli(float p)
    {
        return UnityEngine.Random.Range(0.0f, 1.0f) < p;
    }

    public bool hasExam()
    {
        if (prox_sucesso == -1 || tentativa >= TOTAL_ACONTECIMENTOS) 
        {
            int bin = binomial(TOTAL_ACONTECIMENTOS, PROB_SUCESSOS);
            print("Exam: " + bin);
            intervalo_sucesso = (float) TOTAL_ACONTECIMENTOS / (float) bin;
            prox_sucesso = intervalo_sucesso;
            tentativa = 0;
        }

        tentativa++;

        if (tentativa == roundToNearestInteger(prox_sucesso))
        {
            prox_sucesso += intervalo_sucesso;
            return true;
        } 
        else {
            return false;
        }
    }

    private int roundToNearestInteger(float value) {
        return Mathf.RoundToInt(value);
    }
}
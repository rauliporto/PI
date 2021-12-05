using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class examesMedicos : MonoBehaviour
{
    
    private int TOTAL_ACONTECIMENTOS = 10;
    private float PROB_SUCESSOS = 0.6f;
    private int tentativa;
    private int prox_sucesso;
    private float intervalo_sucesso;
    private float sucessos_acumulados;


    // Start is called before the first frame update
    void Start()
    {
        tentativa = -1;
        prox_sucesso = -1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int binomial(int n, float p)
    {
        int sum = 0;
        for (int i = 0; i < n; i++) sum += Convert.ToInt32(bernoulli(p));
        return sum;
    }

    public bool bernoulli(float p)
    {
        return UnityEngine.Random.Range(0.0f, 1.0f) < p;
    }

    public bool hasExam()
    {
        if (prox_sucesso == -1 || tentativa >= TOTAL_ACONTECIMENTOS) 
        {
            intervalo_sucesso = TOTAL_ACONTECIMENTOS / binomial(TOTAL_ACONTECIMENTOS, PROB_SUCESSOS);

            prox_sucesso = roundToNearestInteger(intervalo_sucesso);
            
            tentativa = -1;
        }

        tentativa++;

        if (tentativa == prox_sucesso)
        {
            prox_sucesso += roundToNearestInteger(intervalo_sucesso * (tentativa + 1));
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
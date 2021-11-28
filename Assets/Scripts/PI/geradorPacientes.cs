using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Timers;

public class geradorPacientes : MonoBehaviour
{
    public GameObject objectNPC;
    public int npcCounter;
    public int xPos;
    public int zPos;
    public float temporizador;
    public float temporizador2;
    int mu;
    private int senha;
    private int nNPC;
    private int criados;
    private int calculados;

    // Start is called before the first frame update
    void Start()
    {
        xPos = -21;
        zPos = -61;
        mu = 5;
        // Temporizador será igual ao mu 
        temporizador = 0;
        temporizador2 = 0;
        senha=1;
        criados=0;
        calculados=0;
    }

    void Update()
    {
        // Criar um timer para depois fazer a call da função poisson e ver quantos pacientes temos de criar e atribuir à lista de receção

        if (temporizador > 0) {
            temporizador -= Time.deltaTime;
        }
        else {
            if(criados < calculados){
                print("criados: " + criados);
                GameObject gerado = Instantiate(objectNPC, new Vector3(xPos, 2.0F, zPos), Quaternion.identity);
                InicializacaoVARS.filaEntrada.Enqueue(gerado);
                gerado.GetComponent<informacaoPaciente>().setSenha(senha);
                senha++;
                print(InicializacaoVARS.filaEntrada.Count);
                criados++;

            }
            else {
                calculados = poisson();
                criados = 0;
                print("temporizador: " + temporizador + "calculados:" + calculados + "criados:" + criados);
           }
            temporizador = calculados > 0 ? 60/calculados : 60;
        }
    }
    
    public int poisson()
    {
        if (mu <= 0) return 0;
        
        // é preciso criar o random entre 0.0 e 1.0
        float a = UnityEngine.Random.Range(0.0f, 1.0f);
        //float a = 0.5f;
        //-------------------------------------------------
        float b = 1.0f;
        int i;
        for (i = 0; b >= Math.Exp(-mu); i++)
            b = b * a;

       return i - 1;
    }
}

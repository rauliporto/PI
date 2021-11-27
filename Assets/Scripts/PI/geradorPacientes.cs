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
    int mu;
    private int senha;

    // Start is called before the first frame update
    void Start()
    {
        xPos = -21;
        zPos = -61;
        mu = 10;
        // Temporizador será igual ao mu 
       temporizador = mu;
       print("teste");
    senha=1;
      
    }

    void Update()
    {
        // Criar um timer para depois fazer a call da função poisson e ver quantos pacientes temos de criar e atribuir à lista de receção
        if (temporizador > 0)
        {
            temporizador -= Time.deltaTime;
            System.Console.WriteLine(" A aguardar");
        }
    else
        {
            System.Console.WriteLine(" A Criar");
           int nNPC = poisson(1.0f);
           while (nNPC > 0)
            {
                
                GameObject gerado = Instantiate(objectNPC, new Vector3(xPos, 2.0F, zPos), Quaternion.identity);
                InicializacaoVARS.filaEntrada.Enqueue(gerado);
                gerado.GetComponent<informacaoPaciente>().setSenha(senha);
                senha++;
                print(InicializacaoVARS.filaEntrada.Count);
                nNPC--;
            }

            temporizador = mu;
            System.Console.WriteLine(" reset temporizador");
        }      
    }

    public int poisson(float mu)
    {
        if (mu <= 0) return 0;
        
        // é preciso criar o random entre 0.0 e 1.0
        //float a = UnityEngine.Random.Range(0.0f, 1.0f);
        float a = 0.5f;
        //-------------------------------------------------
        float b = 1.0f;
        int i;
        for (i = 0; b >= Math.Exp(-mu); i++)
            b = b * a;

       return i - 1;
    }
}

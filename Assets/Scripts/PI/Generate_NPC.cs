using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Timers;

public class Generate_NPC : MonoBehaviour
{
    public GameObject objectNPC;
    public int npcCounter;
    public int x;
    public int z;
    public float temporizador;
    int mu;

    // Start is called before the first frame update
    void Start()
    {
        x = InicializacaoVARS.xPos;
        z = InicializacaoVARS.zPos;
        npcCounter = 0;
        mu = 10;
        // Temporizador será igual ao mu 
       temporizador = mu;
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
           int nNPC = poisson(1.0);
           while (nNPC > 0)
            {
                InicializacaoVARS.filaEntrada.Add(Instantiate(objectNPC, new Vector3(x, 2.0F, z), Quaternion.identity));
                 nNPC -= 1;
            }

            temporizador = mu;
            System.Console.WriteLine(" reset temporizador");
        }
        
      
    }

    public int poisson(double mu)
    {
        if (mu > 0)
        {
            // é preciso criar o random entre 0.0 e 1.0
            double a = 0.5;
            //-------------------------------------------------

            double b = 1.0;
            int i;
            for (i = 0; b >= Math.Exp(-mu); i++)
                b = b * a;
       return i - 1;
        }
        return 0;
    }


}

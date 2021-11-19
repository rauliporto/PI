using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    int cadenciaEntrada, gravidadeDoente, tempoParaTriagem, velocidadeAtendimento, possibilidadeExame;
    int rececionistas, enfermeiros, medicos;
    int velocidadeRececao, velocidadeEnfermeiro, velocidadeExame;



    // Start is called before the first frame update
    void Start()
    {
        // Podemos criar campos diretamente no NPC de forma a controlar estes valores diretamente lá
        rececionistas = 2;
        enfermeiros = 2;
        medicos = 3;
        velocidadeRececao = 1;
        velocidadeEnfermeiro = 1;
        velocidadeExame = 1;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

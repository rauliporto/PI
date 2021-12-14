using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chamadaDaRececionista : MonoBehaviour
{
    public float temporizador;
    public GameObject pacienteAtual;
    
    // Start is called before the first frame update
    void Start()
    {
        temporizador = 20;
        pacienteAtual = null;
    }

    // Update is called once per frame
    void Update()
    { 

        if(pacienteAtual != null && pacienteAtual.GetComponent<movimentoPaciente>().nearPosition()) {
            if (temporizador > 0 ) {
                temporizador -= Time.deltaTime;
            }
            else {
                insertTriagem();
                pacienteAtual = null;
            }
        }
        else {
            if(pacienteAtual == null){
                if(canICall()) {
                    callPacient();
                    temporizador = 10;
                }
            }

        }
    }
    
    public void insertTriagem() {
        pacienteAtual.GetComponent<movimentoPaciente>().moveTo("WaitingArea");
        InicializacaoVARS.filaTriagem.Enqueue(pacienteAtual);   
        pacienteAtual.GetComponent<informacaoPaciente>().addTempoEsperaTriagem(); 
    }

    public void callPacient() {
        pacienteAtual  = InicializacaoVARS.filaEntrada.Dequeue();
        pacienteAtual.GetComponent<movimentoPaciente>().moveTo(gameObject.tag);
    }

    public bool canICall() {
        if (InicializacaoVARS.filaEntrada.Count > 0 && InicializacaoVARS.filaEntrada.Peek().GetComponent<movimentoPaciente>().getCalled())
            return true;
        return false;
    }
    
}

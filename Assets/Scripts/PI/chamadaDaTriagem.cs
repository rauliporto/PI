using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chamadaDaTriagem : MonoBehaviour
{
    public float temporizador;
    public GameObject pacienteAtual;

    private readonly float rate = 0.08f; 
    private readonly float mean = 12f;
    
    // Start is called before the first frame update
    void Start()
    {
        temporizador = exponential();
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
                pacienteAtual.GetComponent<movimentoPaciente>().moveTo("WaitingArea2");
                InicializacaoVARS.filaMedico.Enqueue(pacienteAtual);    
                pacienteAtual = null;
            }

        }
        else {
            if(pacienteAtual == null) {
                if (InicializacaoVARS.filaTriagem.Count > 0 && InicializacaoVARS.filaTriagem.Peek().GetComponent<movimentoPaciente>().getCalled()) {
                    pacienteAtual  = InicializacaoVARS.filaTriagem.Dequeue();
                    pacienteAtual.GetComponent<movimentoPaciente>().moveTo(gameObject.tag);
                    temporizador = exponential();
                }
            }
        }
    }

    public float exponential() {
        return rate - mean * Mathf.Log(UnityEngine.Random.Range(0.0f, 1.0f));
    }
}

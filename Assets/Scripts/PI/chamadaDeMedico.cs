using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chamadaDeMedico : MonoBehaviour
{
    public float temporizador;
    public GameObject pacienteAtual;
    
    // Start is called before the first frame update
    void Start()
    {
        temporizador = 50;
        pacienteAtual = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (temporizador > 0) {
            temporizador -= Time.deltaTime;
        }
        else
        { 
// Aqui podemos colocar um if para o caso do paciente ir para fazer o EXAME

            if(pacienteAtual != null) {
                pacienteAtual.GetComponent<movimentoPaciente>().moveTo("Exit");  
                pacienteAtual = null;

            }

            if (InicializacaoVARS.filaMedico.Count > 0 && InicializacaoVARS.filaMedico.Peek().GetComponent<movimentoPaciente>().getCalled()) {
                pacienteAtual  = InicializacaoVARS.filaMedico.Dequeue();
                pacienteAtual.GetComponent<movimentoPaciente>().moveTo(gameObject.tag);
                temporizador = 10;
            }
        }
    }
}


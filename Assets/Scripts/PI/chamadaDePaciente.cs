using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chamadaDePaciente : MonoBehaviour
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
if (temporizador > 0)
{
temporizador -= Time.deltaTime;
}
else
{ 
if(pacienteAtual != null) {
    pacienteAtual.GetComponent<movimentoPaciente>().moveTo("WaitingArea");
    pacienteAtual = null;

}


    if (InicializacaoVARS.filaEntrada.Count > 0 && InicializacaoVARS.filaEntrada.Peek().GetComponent<movimentoPaciente>().getCalled()){
    
        pacienteAtual  = InicializacaoVARS.filaEntrada.Dequeue();
        string a = (string) gameObject.tag;
        print(a);
    pacienteAtual.GetComponent<movimentoPaciente>().moveTo(gameObject.tag);
    
temporizador = 10;
    
                }

}
}
}

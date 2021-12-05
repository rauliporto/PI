using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chamadaDaTriagem : MonoBehaviour
{
    public float temporizador;
    private GameObject pacienteAtual;
    private Renderer head;

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
        if (pacienteAtual != null && pacienteAtual.GetComponent<movimentoPaciente>().nearPosition()) {
            if (temporizador > 0) {
                temporizador -= Time.deltaTime;
            }
            else {
                pacienteAtual.GetComponent<movimentoPaciente>().moveTo("WaitingArea2");
                int gravity = dirac();
                pacienteAtual.GetComponent<movimentoPaciente>().setGravity(gravity);
                addQueue(gravity);
                changeColorBandage(gravity);
                pacienteAtual = null;
            }

        }
        else {
            if (pacienteAtual == null) {
                if (InicializacaoVARS.filaTriagem.Count > 0 && InicializacaoVARS.filaTriagem.Peek().GetComponent<movimentoPaciente>().getCalled()) {
                    pacienteAtual = InicializacaoVARS.filaTriagem.Dequeue();
                    pacienteAtual.GetComponent<movimentoPaciente>().moveTo(gameObject.tag);
                    temporizador = exponential();
                }
            }
        }
    }

    public void changeColorBandage(int gravity) {
        Color c = Color.white;
        switch (gravity)
        {
            case 1: c = Color.red; break;
            case 2: c = new Color(0.2F, 0.3F, 0.4F); break;
            case 3: c = Color.yellow; break;
            case 4: c = Color.blue; break;
            case 5: c = Color.green; break;
            default:
                break;
        } 
        pacienteAtual.transform.Find("Specifics").Find("Bandages").Find("Bandage (1)").GetComponent<Renderer>().material.SetColor("_Color", c);
    }

    
    public void addQueue(int gravity) {
        switch (gravity)
        {
            case 1:
                InicializacaoVARS.filaMedico1.Enqueue(pacienteAtual); break;
            case 2:
                InicializacaoVARS.filaMedico2.Enqueue(pacienteAtual); break;
            case 3:
                InicializacaoVARS.filaMedico3.Enqueue(pacienteAtual); break;
            case 4:
                InicializacaoVARS.filaMedico4.Enqueue(pacienteAtual); break;
            case 5:
                InicializacaoVARS.filaMedico5.Enqueue(pacienteAtual); break;
            case 6:
                InicializacaoVARS.filaMedico6.Enqueue(pacienteAtual); break;
        }    
    }

    public float exponential() {
        return rate - mean * Mathf.Log(UnityEngine.Random.Range(0.0f, 1.0f));
    }

    public int dirac()
    {
        float u = UnityEngine.Random.Range(0.0f, 1.0f);
        if (u < 0.004) return 1;
        else if (u < 0.108) return 2;
        else if (u < 0.577) return 3;
        else if (u < 0.949) return 4;
        else if (u < 0.967) return 5;
        else return 6;   
    }       
}

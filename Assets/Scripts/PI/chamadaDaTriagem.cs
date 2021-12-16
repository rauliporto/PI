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
                pacienteAtual.GetComponent<informacaoPaciente>().setPulseira(gravity);
                addQueue(gravity);
                changeColorBandage(gravity);
                pacienteAtual = null;
            }

        }
        else {
            if (pacienteAtual == null) {
                if (InicializacaoVARS.filaTriagem.Count > 0 && InicializacaoVARS.filaTriagem.Peek().GetComponent<movimentoPaciente>().getCalled()) {
                    pacienteAtual = InicializacaoVARS.filaTriagem.Dequeue();
                    updateStatistics();
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
            case 2: c = new Color(1.0F, 0.5F, 0.0F); break;
            case 3: c = Color.yellow; break;
            case 4: c = Color.blue; break;
            case 5: c = Color.green; break;
            default:
                break;
        } 
        Transform bangages = pacienteAtual.transform.Find("Specifics").Find("Bandages");
        
        foreach (Transform bangage in bangages)
        {
            bangage.GetComponent<Renderer>().material.SetColor("_Color", c);
        }
    }

    
    public void addQueue(int gravity) {
        pacienteAtual.GetComponent<informacaoPaciente>().setTempoEsperaMedico(); 

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
        float result = -1;
        while (result < 0.0f || result > 20.0f)
        {
            result = rate - mean * Mathf.Log(UnityEngine.Random.Range(0.0f, 1.0f));
        }
        return result;
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

    public void updateStatistics() {
        Statistics.Instance.writeFileTriage(Time.time - pacienteAtual.GetComponent<informacaoPaciente>().getTempoEsperaTriagem());
    }     
}

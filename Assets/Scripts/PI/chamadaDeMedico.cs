using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chamadaDeMedico : MonoBehaviour
{
    public float temporizador;
    public GameObject pacienteAtual;
    public int gravity;

    private readonly float sd = 20f;
    private readonly float mean1 = 50f;
    private readonly float mean2 = 45f;
    private readonly float mean3 = 40f;
    private readonly float mean4 = 35f;
    private readonly float mean5 = 30f;
    private readonly float mean6 = 25f;
 

    // Start is called before the first frame update
    void Start()
    {
        temporizador = 50;
        pacienteAtual = null;
        gravity = 0;
    }

    // Update is called once per frame
    void Update()
    {
         if(pacienteAtual != null && pacienteAtual.GetComponent<movimentoPaciente>().nearPosition()) {
            if (temporizador > 0 ) {
                temporizador -= Time.deltaTime;
            }
            else {
                bool goToExame = examesMedicos.Instance.hasExam();
                print("Goes to exame: " + goToExame);
                if (goToExame) {
                    pacienteAtual.GetComponent<movimentoPaciente>().goToExam();
                } else {
                    pacienteAtual.GetComponent<movimentoPaciente>().moveTo("Exit");
                }

                pacienteAtual = null;
            }
        }
        else {
            if (pacienteAtual == null)
            {
                if (InicializacaoVARS.filaMedico1.Count > 0 && InicializacaoVARS.filaMedico1.Peek().GetComponent<movimentoPaciente>().getCalled())
                {
                    pacienteAtual = InicializacaoVARS.filaMedico1.Dequeue();
                    gravity = pacienteAtual.GetComponent<informacaoPaciente>().getPulseira();
                    pacienteAtual.GetComponent<movimentoPaciente>().moveTo(gameObject.tag);
                    temporizador = normal(gravity);
                    updateStatistics();
                }
                else
                {
                    if (InicializacaoVARS.filaMedico2.Count > 0 && InicializacaoVARS.filaMedico2.Peek().GetComponent<movimentoPaciente>().getCalled())
                    {
                        pacienteAtual = InicializacaoVARS.filaMedico2.Dequeue();
                        gravity = pacienteAtual.GetComponent<informacaoPaciente>().getPulseira();
                        pacienteAtual.GetComponent<movimentoPaciente>().moveTo(gameObject.tag);
                        temporizador = normal(gravity);
                        updateStatistics();
                    }
                    else
                    {
                        if (InicializacaoVARS.filaMedico3.Count > 0 && InicializacaoVARS.filaMedico3.Peek().GetComponent<movimentoPaciente>().getCalled())
                        {
                            pacienteAtual = InicializacaoVARS.filaMedico3.Dequeue();
                            gravity = pacienteAtual.GetComponent<informacaoPaciente>().getPulseira();
                            pacienteAtual.GetComponent<movimentoPaciente>().moveTo(gameObject.tag);
                            temporizador = normal(gravity);
                            updateStatistics();
                        }
                        else
                        {
                            if (InicializacaoVARS.filaMedico4.Count > 0 && InicializacaoVARS.filaMedico4.Peek().GetComponent<movimentoPaciente>().getCalled())
                            {
                                pacienteAtual = InicializacaoVARS.filaMedico4.Dequeue();
                                gravity = pacienteAtual.GetComponent<informacaoPaciente>().getPulseira();
                                pacienteAtual.GetComponent<movimentoPaciente>().moveTo(gameObject.tag);
                                temporizador = normal(gravity);
                                updateStatistics();
                            }
                            else
                            {
                                if (InicializacaoVARS.filaMedico5.Count > 0 && InicializacaoVARS.filaMedico5.Peek().GetComponent<movimentoPaciente>().getCalled())
                                {
                                    pacienteAtual = InicializacaoVARS.filaMedico5.Dequeue();
                                    gravity = pacienteAtual.GetComponent<informacaoPaciente>().getPulseira();
                                    pacienteAtual.GetComponent<movimentoPaciente>().moveTo(gameObject.tag);
                                    temporizador = normal(gravity);
                                    updateStatistics();
                                }
                                else
                                {
                                    if (InicializacaoVARS.filaMedico6.Count > 0 && InicializacaoVARS.filaMedico6.Peek().GetComponent<movimentoPaciente>().getCalled())
                                    {
                                        pacienteAtual = InicializacaoVARS.filaMedico6.Dequeue();
                                        gravity = pacienteAtual.GetComponent<informacaoPaciente>().getPulseira();
                                        pacienteAtual.GetComponent<movimentoPaciente>().moveTo(gameObject.tag);
                                        temporizador = normal(gravity);
                                        updateStatistics();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    public float normal(int gravity)
    {
        float a = 0;
        float mean = 0;
        switch (gravity)
        {
            case 1:
                mean = mean1;
                break;
            case 2:
                mean = mean2;
                break;
            case 3:
                mean = mean3;
                break;
            case 4:
                mean = mean4;
                break;
            case 5:
                mean = mean5;
                break;
            case 6:
                mean = mean6;
                break;
        }
        float b = mean + 2 * sd;
        float valor = -1;
        while (valor < a || valor > b)
        {
            float u1 = UnityEngine.Random.Range(-1.0f, 1.0f);
            float u2 = UnityEngine.Random.Range(-1.0f, 1.0f);
            float u = u1 * u1 + u2 * u2;
            valor = mean + sd * u1 * Mathf.Sqrt(-2 * Mathf.Log(u) / u);
        }
        return valor;
    }

    public void updateStatistics() {
        Statistics.Instance.writeFileDoctor(pacienteAtual.GetComponent<informacaoPaciente>().getPulseira(), pacienteAtual.GetComponent<informacaoPaciente>().getTempoEsperaMedico());
    }   
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class informacaoPaciente : MonoBehaviour
{
    public int pulseira;
    public int senha;
    public float tempoEntrada;
    public bool fezExame;
    public float tempoEsperaTriagem;
    public float tempoEsperaMedico;


    // Start is called before the first frame update
    void Start()
    {
        pulseira = 0;
        senha = 0;
        tempoEntrada = Time.time;
        tempoEsperaTriagem = 0;
        tempoEsperaMedico = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setSenha(int senha){
        this.senha = senha;
    }

    public int getSenha(){
        return senha;
    }

    public float getTime(){
        return tempoEntrada;
    }

    public void setTempoEsperaTriagem(){
        tempoEsperaTriagem = Time.time;
    }

    public float getTempoEsperaTriagem(){
        return tempoEsperaTriagem;
    }

    public void setTempoEsperaMedico(){
        tempoEsperaMedico = Time.time;
    }

    public float getTempoEsperaMedico(){
        return Time.time - tempoEsperaMedico;
    }

    public void setPulseira(int pulseira){
        this.pulseira = pulseira;
    }

    public int getPulseira(){
        return pulseira;
    }

    public void setExam(bool fezExame) {
        this.fezExame = fezExame;
    }
    
    public bool getExam(){
        return this.fezExame;
    }
}

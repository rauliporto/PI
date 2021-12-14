using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class informacaoPaciente : MonoBehaviour
{
    public int pulseira;
    public int senha;
    public float tempo;
    public bool fezExame;

    public float tempoEsperaTriagem;
    public float tempoEsperaMedico;


    // Start is called before the first frame update
    void Start()
    {
        pulseira = 0;
        senha = 0;
        tempo = 0;
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

    public void addTime(){
        tempo +=Time.deltaTime;
    }

    public float getTime(){
        return tempo;
    }

    public void addTempoEsperaTriagem(){
        tempoEsperaTriagem +=Time.deltaTime;
    }

    public float getTempoEsperaTriagem(){
        return tempoEsperaTriagem;
    }

    public void addTempoEsperaMedico(){
        tempoEsperaMedico +=Time.deltaTime;
    }

    public float getTempoEsperaMedico(){
        return tempoEsperaMedico;
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

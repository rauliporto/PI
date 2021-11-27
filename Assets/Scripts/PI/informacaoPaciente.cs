using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class informacaoPaciente : MonoBehaviour
{
    public static int pulseira;
    public int senha;
    // Start is called before the first frame update
    void Start()
    {
        pulseira = 0;
        senha = 0;
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
}

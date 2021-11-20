using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicializacaoVARS : MonoBehaviour
{
    public static List<GameObject> filaEntrada;
    public static List<GameObject> filaTriagem;
    public static List<GameObject> filaMedico;
    public static int numeroEnfermeiros;
    public static int numeroMedicos;
    public static int numeroRececionistas;
    public static int xPos;
    public static int zPos;
    private static System.Timers.Timer temporizador;

    // Start is called before the first frame update
    void Start()
    {
        filaMedico = new List<GameObject>();
        filaTriagem = new List<GameObject>();
        filaEntrada = new List<GameObject>();
        numeroEnfermeiros = 2;
        numeroRececionistas = 2;
        numeroMedicos = 2;
        // posição de spawn dos pacientes
        xPos = -21;
        zPos = -61;
        // Temporizador com intervalos de 1 segundo
   
        



    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

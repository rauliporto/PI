using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicializacaoVARS : MonoBehaviour
{
    public static Queue<GameObject> filaEntrada;
    public static Queue<GameObject> filaTriagem;
    public static Queue<GameObject> filaMedico1;
    public static Queue<GameObject> filaMedico2;
    public static Queue<GameObject> filaMedico3;
    public static Queue<GameObject> filaMedico4;
    public static Queue<GameObject> filaMedico5;
    public static Queue<GameObject> filaMedico6;

    public static int numeroEnfermeiros;
    public static int numeroMedicos;
    public static int numeroRececionistas;
    private static System.Timers.Timer temporizador;
    public static Vector3 entrada,rece1,rece2;

    // Start is called before the first frame update
    void Start()
    {
        filaMedico1 = new Queue<GameObject>();
        filaMedico2 = new Queue<GameObject>();
        filaMedico3 = new Queue<GameObject>();
        filaMedico4 = new Queue<GameObject>();
        filaMedico5 = new Queue<GameObject>();
        filaMedico6 = new Queue<GameObject>();
        filaTriagem = new Queue<GameObject>();
        filaEntrada = new Queue<GameObject>();
        numeroEnfermeiros = 2;
        numeroRececionistas = 2;
        numeroMedicos = 2;
    }

    // Update is called once per frame
    void Update()
    {}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicializacaoVARS : MonoBehaviour
{
    public static Queue<GameObject> filaEntrada;
    public static Queue<GameObject> filaTriagem;
    public static Queue<GameObject> filaMedico;
    public static int numeroEnfermeiros;
    public static int numeroMedicos;
    public static int numeroRececionistas;
    private static System.Timers.Timer temporizador;
    public static Vector3 entrada,rece1,rece2;

    // Start is called before the first frame update
    void Start()
    {
        filaMedico = new Queue<GameObject>();
        filaTriagem = new Queue<GameObject>();
        filaEntrada = new Queue<GameObject>();
        numeroEnfermeiros = 2;
        numeroRececionistas = 2;
        numeroMedicos = 2;
    }

    // Update is called once per frame
    void Update()
    {}

    class GravityComparator : IComparer<GameObject>
    {
        public int Compare(GameObject x, GameObject y)
        {
            return x.GetComponent<movimentoPaciente>().getGravity().CompareTo(y.GetComponent<movimentoPaciente>().getGravity());
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class movimentoPaciente : MonoBehaviour
{
    public string pos;
    public bool canIMove;
    public bool called;
    public float temporizadorExam;

    NavMeshAgent patient;

    // Start is called before the first frame update
    void Start()
    {
        pos = "Door";
        canIMove = true;
        called = false;
        patient = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canIMove)
        {
            this.GetComponent<NavMeshAgent>().isStopped = false;
            GameObject aux = getVector();
            patient.SetDestination(aux.transform.position);
        }

        if (nearPosition())
        {

            this.GetComponent<NavMeshAgent>().isStopped = true;
            canIMove = false;
            called = true;
            if (pos == "Exit") {
                updateStatistics();              
                GameObject.Destroy(this.gameObject);
            }
        }

        if(GetComponent<informacaoPaciente>().getExam()) 
        {
            if(temporizadorExam < 0)
            {
                this.moveTo("Exit");
            } else {
                temporizadorExam -= Time.deltaTime;
            }
        }
    }

    public void moveTo(string pos)
    {
        this.pos = pos;
        canIMove = true;
        called = false;
    }

    public GameObject getVector()
    {
        GameObject[] aux = new GameObject[1];
        aux = GameObject.FindGameObjectsWithTag(pos);
        //if(pos != "Door" )
        //print(pos);
        return aux[0];
    }

    public bool getCalled() {
        return called;
    }

    public void updateStatistics() {
        print(" Aqui 1");
        float tempoFinal = Time.time - GetComponent<informacaoPaciente>().getTime();
        Statistics.Instance.setStatistics(GetComponent<informacaoPaciente>().getPulseira(), tempoFinal);
        Statistics.Instance.writeFileTotals(GetComponent<informacaoPaciente>().getPulseira(), tempoFinal, GetComponent<informacaoPaciente>().getExam());
    }

    public bool nearPosition()
    {
        GameObject aux = getVector();
        if (Vector3.Distance(transform.position, aux.transform.position) < 2.5F)
            return true;
        return false;
    }

    public void goToExam(){
        this.moveTo("ExameArea");
        GetComponent<informacaoPaciente>().setExam(true);
        temporizadorExam = 50;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class movimentoPaciente : MonoBehaviour
{
    public string pos;
    public bool canIMove;
    public bool called;
    public int gravity;

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
        GetComponent<informacaoPaciente>().addTime();
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
                Statistics.Instance.setStatistics(GetComponent<informacaoPaciente>().getPulseira(), GetComponent<informacaoPaciente>().getTime());
                Object.Destroy(this.gameObject);    
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

    public bool nearPosition()
    {
        GameObject aux = getVector();
        if (Vector3.Distance(transform.position, aux.transform.position) < 2.5F)
            return true;
        return false;
    }
}

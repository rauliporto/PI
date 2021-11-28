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
        if(canIMove)
        {
            GameObject aux = getVector();
            patient.SetDestination(aux.transform.position);
        }

        if (nearPosition())
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            canIMove = false;
            called = true;
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

    public int getGravity() {
        return gravity;
    }

    public void setGravity(int gravity) {
        gravity = gravity;
    }

    public bool nearPosition()
    {
        GameObject aux = getVector();
        if (Vector3.Distance(transform.position, aux.transform.position) < 5f)
            return true;
        return false;
    }
}

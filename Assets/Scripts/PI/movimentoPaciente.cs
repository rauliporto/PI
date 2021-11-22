using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentoPaciente : MonoBehaviour
{
    public string pos;
    public bool canIMove;
    public int status; //1 - called; 2 - waiting; 3 - calledTriage

    // Start is called before the first frame update
    void Start()
    {
        pos = "Door";
        canIMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(canIMove)
        {
            GameObject aux = getVector();
            transform.position = Vector3.MoveTowards(transform.position, aux.transform.position, 2.0F * Time.deltaTime);
            status = 0;
        }

        if (nearPosition())
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            if (pos == "Door")
                status = 1;
            else if (pos == "WaitingArea") 
                status = 2; 
            else if (pos == "Hall") 
                status = 3; 

            canIMove = false;
        }           
    }

    public void moveTo(string pos)
    {
        this.pos = pos;
        canIMove = true;
    }

    public GameObject getVector()
    {
        GameObject[] aux = new GameObject[1];
        aux = GameObject.FindGameObjectsWithTag(pos);
        print(pos);
        return aux[0];
    }

    public bool getCalled() {
        return status == 1;
    }

    public bool isWaiting() {
        return status == 2;
    }

    public bool isCalledTriage() {
        return status == 3;
    }

    public bool nearPosition()
    {
        GameObject aux = getVector();
        if (Vector3.Distance(transform.position, aux.transform.position) < 0.001f)
            return true;
        return false;
    }

}

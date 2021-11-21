using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentoPaciente : MonoBehaviour
{
    public string pos;
    public bool canIMove;
    public bool called;
    public bool sorted;
    
    // Start is called before the first frame update
    void Start()
    {
        pos = "Door";

        canIMove = true;
        called = false;
        sorted = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(canIMove)
        {
            GameObject aux = getVector();
            transform.position = Vector3.MoveTowards(transform.position, aux.transform.position, 2.0F * Time.deltaTime);
            called = false;
        }

        if (nearPosition())
        {
           GetComponent<Rigidbody>().velocity = Vector3.zero;
           GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            called = true;
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
        return aux[0];
    }

    public bool getCalled() {
        return called;
    }

    public bool isSorted() {
        return sorted;
    }

    public bool nearPosition()
    {
        GameObject aux = getVector();
        if (Vector3.Distance(transform.position, aux.transform.position) < 0.001f)
            return true;
        return false;
    }

}

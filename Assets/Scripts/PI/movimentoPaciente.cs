using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentoPaciente : MonoBehaviour
{
    public string pos;
    public bool canIMove;
    public bool called;
    public int status; //1 - called; 2 - waiting; 3 - calledTriage
    public int gravity;

    // Start is called before the first frame update
    void Start()
    {
        pos = "Door";
        canIMove = true;
        called = false;
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

    public bool nearPosition()
    {
        GameObject aux = getVector();
        print(Vector3.Distance(transform.position, aux.transform.position));
        if (Vector3.Distance(transform.position, aux.transform.position) < 2f)
            return true;
        return false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentoPaciente : MonoBehaviour
{
    public int pos;
    public bool canIMove;
    
    // Start is called before the first frame update
    void Start()
    {
        canIMove = true;
        pos = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(canIMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, getVector(), 2.0F * Time.deltaTime);
        }

        if (nearPosition())
        {
           GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        }


            
    }

    public void moveTo(int pos)
    {
        this.pos = pos;
        canIMove = true;
    }

    public Vector3 getVector()
    {
        if (pos == 1)
            return InicializacaoVARS.entrada;
        if (pos == 2)
            return InicializacaoVARS.rece1;
        if (pos == 3)
            return InicializacaoVARS.rece2;
        else 
            return InicializacaoVARS.entrada;
    }

    public bool nearPosition()
    {
        if (Vector3.Distance(transform.position, getVector()) < 0.001f)
            return true;
        return false;

    }

}

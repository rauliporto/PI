using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class geradorEnfermeiras : MonoBehaviour
{
    public GameObject objectEnfermeiras;
    // Start is called before the first frame update
    void Start()

    {
        GameObject enfermeiro1;
        GameObject enfermeiro2;
        print("numeroEnfermeiros:" + InicializacaoVARS.numeroEnfermeiros);

        //if (InicializacaoVARS.numeroEnfermeiros > 0)
        //{
            enfermeiro1 = Instantiate(objectEnfermeiras, new Vector3(-42F, 1.67F, 26F), Quaternion.identity);
            enfermeiro1.transform.rotation = Quaternion.Euler(0, -90, 0);
            enfermeiro1.gameObject.tag = "TriageRoom";
        //}
        //if (InicializacaoVARS.numeroEnfermeiros > 1)
        //{
            enfermeiro2 = Instantiate(objectEnfermeiras, new Vector3(-1F, 1.67F, 26F), Quaternion.identity);
            enfermeiro2.transform.rotation = Quaternion.Euler(0, -90, 0);
            enfermeiro2.gameObject.tag = "TriageRoom2";
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class geradorRececionistas : MonoBehaviour
{
    public GameObject objectRececionista;

    // Start is called before the first frame update
    void Start()
    {
        GameObject rececionista1;
        GameObject rececionista2;

        if (InicializacaoVARS.numeroRececionistas > 0)
        {
            rececionista1 = Instantiate(objectRececionista, new Vector3(-31F, 1.55F, -16F), Quaternion.identity);
            rececionista1.gameObject.tag = "Reception";
                    }
        if (InicializacaoVARS.numeroRececionistas > 1)
        {
            rececionista2 = Instantiate(objectRececionista, new Vector3(-11.5F, 1.55F, -16F), Quaternion.identity);
           rececionista2.gameObject.tag = "Reception2";
           // rececionista2.gabinete = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

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
            rececionista1 = Instantiate(objectRececionista, new Vector3(-24.70F, 1.55F, -8.6F), Quaternion.identity);
                    }
        if (InicializacaoVARS.numeroRececionistas > 1)
        {
            rececionista2 = Instantiate(objectRececionista, new Vector3(-17.9F, 1.55F, -8.6F), Quaternion.identity);
                    }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

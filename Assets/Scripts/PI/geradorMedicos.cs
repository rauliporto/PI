using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class geradorMedicos : MonoBehaviour
{
    public GameObject objectMedicos;
    public int numeroMedicos;
    // Start is called before the first frame update
    void Start()

    {
        GameObject medico1;
        GameObject medico2;
        GameObject medico3;
        if (numeroMedicos > 0)
        {
            medico1 = Instantiate(objectMedicos, new Vector3(-47F, 1.55F, 14F), Quaternion.identity);
            medico1.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (numeroMedicos > 1)
        {
            medico2 = Instantiate(objectMedicos, new Vector3(-29F, 1.55F, 14F), Quaternion.identity);
            medico2.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
            if (numeroMedicos > 2)
            {
                medico3 = Instantiate(objectMedicos, new Vector3(-19F, 1.55F, 14F), Quaternion.identity);
            medico3.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

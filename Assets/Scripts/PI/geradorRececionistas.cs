using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class geradorRececionistas : MonoBehaviour
{
    public GameObject objectRececionista;
    public int numeroRecionistas;
    // Start is called before the first frame update
    void Start()
    {
        if( numeroRecionistas > 0 )
            Instantiate(objectRececionista, new Vector3(-24.70F, 1.55F, -8.6F), Quaternion.identity);
        if (numeroRecionistas > 1)
            Instantiate(objectRececionista, new Vector3(-17.9F, 1.55F, -8.6F), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

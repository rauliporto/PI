using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class geradorEnfermeiras : MonoBehaviour
{
    public GameObject objectEnfermeiras;
    public int numeroEnfermeiras;
    // Start is called before the first frame update
    void Start()
     
    {
        GameObject enfermeiro1;
        GameObject enfermeiro2;
        if (numeroEnfermeiras > 0)
           enfermeiro1 = Instantiate(objectEnfermeiras, new Vector3(13.5F, 1.55F, 6F), Quaternion.identity);
        if (numeroEnfermeiras > 1)
            enfermeiro2 = Instantiate(objectEnfermeiras, new Vector3(13.5F, 1.55F, -2F), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

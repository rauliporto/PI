using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class geradorMedicos : MonoBehaviour
{
    public GameObject objectMedicos;
        // Start is called before the first frame update
    void Start()

    {
        GameObject medico1;
        GameObject medico2;
        GameObject medico3;
        print(InicializacaoVARS.numeroMedicos);
        //if (InicializacaoVARS.numeroMedicos > 0)
        //{
            medico1 = Instantiate(objectMedicos, new Vector3(-53F, 1.55F, 35F), Quaternion.identity);
            medico1.transform.rotation = Quaternion.Euler(0, 180, 0);
            medico1.gameObject.tag = "Gabinete1";
        //}
        //if (InicializacaoVARS.numeroMedicos > 1)
        //{
            medico2 = Instantiate(objectMedicos, new Vector3(-50F, 1.55F, 60F), Quaternion.identity);
            medico2.transform.rotation = Quaternion.Euler(0, 180, 0);
            medico2.gameObject.tag = "Gabinete2";
        //}
        //if (InicializacaoVARS.numeroMedicos > 2) {
            medico3 = Instantiate(objectMedicos, new Vector3(10F, 1.55F, 58F), Quaternion.identity);
            medico3.transform.rotation = Quaternion.Euler(0, 180, 0);
            medico3.gameObject.tag = "Gabinete3";
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

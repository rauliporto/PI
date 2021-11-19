using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateNPC : MonoBehaviour
{
    public GameObject objectNPC;
    public int xPos;
    public int zPos;
    public int npcCounter;
    // Start is called before the first frame update
    void Start()
    {
        npcCounter = 0;
        StartCoroutine(SpawnNPC());
    }

    IEnumerator SpawnNPC()
    {

        while(npcCounter <10)
        {
            xPos = -13;
            zPos = -32;
            Instantiate(objectNPC, new Vector3(xPos, 2, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            npcCounter += 1;
        }
       
    }

}

﻿using System.Collections;
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
        while(npcCounter < 10)
        {
            Instantiate(objectNPC, new Vector3(xPos, 1.0F, zPos), Quaternion.identity);
            
            npcCounter++;
        }
      
    }

   

}

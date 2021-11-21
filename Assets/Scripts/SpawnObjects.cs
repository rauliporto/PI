using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour {
    private int mean = 12;
    public GameObject patientPrefab;
    
    private void Start() {
        Invoke(nameof(SpawnPatient), 1f);
    }

    private void SpawnPatient() {
        GameObject x = Instantiate(patientPrefab, new Vector3(-21, 2.0F, -61), Quaternion.identity);
        print("teste" + poisson());
        Invoke(nameof(SpawnPatient), poisson());
    }

    private int poisson() {
        float b = 1.0f;
        int i;
        for (i = 0; b >= Mathf.Exp(-mean); i++)
            b *= UnityEngine.Random.Range(0.0f, 1.0f);

        return i - 1;
    }
}

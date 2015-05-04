using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Eyes : MonoBehaviour {

    public GameObject eyes;


    void OnTriggerEnter(Collider other)
    {
        eyes.SetActiveRecursively(false);
    }

    void OnTriggerExit(Collider other)
    {
        eyes.SetActiveRecursively(true);
    }
}

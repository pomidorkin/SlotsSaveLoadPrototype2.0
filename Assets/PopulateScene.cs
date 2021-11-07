using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateScene : MonoBehaviour
{
    [SerializeField] GameObject vehicleToInstantiate;
    void Start()
    {
            Instantiate(vehicleToInstantiate);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    public List<ModuleDescriptor> modules;
    SerializationManager serializationManager;
    [SerializeField] GameObject newModule;
    VehicleDecriptor vehicleDecriptor;

    // Start is called before the first frame update
    void Start()
    {
        serializationManager = FindObjectOfType<SerializationManager>();
        vehicleDecriptor = serializationManager.LoadGame();
        SpawnModules();
    }

    private void SpawnModules()
    {
        // VehicleDescriptor has a list of ModuleDescriptors, we spawn prefab newModule an
        // amout of times equal the the length of the module descriptors list in 
        // VehicleDescriptor. After that we assing or attach each newly spawned module
        // it's ModuleDescriptor
        for (int i = 0; i < vehicleDecriptor.GetModules().Count; i++)
        {
            GameObject module = Instantiate(newModule, new Vector3(vehicleDecriptor.GetModules()[i].x,
                vehicleDecriptor.GetModules()[i].y, 0), Quaternion.identity) as GameObject;
            module.GetComponent<Module>().AssignModuleDescriptor(vehicleDecriptor.GetModules()[i]);
        }
    }
}

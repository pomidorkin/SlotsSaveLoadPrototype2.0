using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    MySceneManager mySceneManager;
    [SerializeField] GameObject thePrefabToSpawn;
    VehicleDecriptor vehicleDecriptor;
    SerializationManager serializationManager;

    private void Start()
    {
        mySceneManager = GetComponent<MySceneManager>();
        vehicleDecriptor = new VehicleDecriptor();
        serializationManager = GetComponent<SerializationManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Camera theCamera = Camera.main;
            RaycastHit2D ray = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (ray)
            {
                GameObject go = SpawnModuleOnClick(ray);
                AddModulesToVehicleDecriptor(go);

            }

        }

        if (Input.GetMouseButtonDown(1))
        {
            Camera theCamera = Camera.main;
            RaycastHit2D ray = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (ray)
            {
                DestroyModule(ray);
            }

        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Loading Second Scene
            mySceneManager.LoadNewScene(1);
        }
    }

    private static void DestroyModule(RaycastHit2D ray)
    {
        Destroy(ray.collider.transform.parent.gameObject);
    }

    private void AddModulesToVehicleDecriptor(GameObject go)
    {
        // Adding moduels to the list in Vehicle
        ModuleDescriptor md = new ModuleDescriptor();
        md.x = go.transform.position.x;
        md.y = go.transform.position.y;
        vehicleDecriptor.AddModule(md);
        // Saving VehicleDescriptor after each new placement of a module
        serializationManager.SaveGame(vehicleDecriptor);
    }

    private GameObject SpawnModuleOnClick(RaycastHit2D ray)
    {
        Vector3 spawnSpot = ray.collider.transform.position; // Position of the slot
        GameObject go = (GameObject)Instantiate(thePrefabToSpawn, spawnSpot, Quaternion.identity);
        go.transform.parent = ray.transform;
        // Disabling module's collider so that we cannot place multiple objects on one place
        // TODO: We need to enable them back when we delete a module
        ray.transform.GetComponent<BoxCollider2D>().enabled = false;
        return go;
    }
}

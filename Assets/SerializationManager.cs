using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class SerializationManager : MonoBehaviour
{
    // Make this class a singleton / single instance
    static public SerializationManager instance;
    string filePath;

    private void Awake()
    {
        // TODO: Needs refactoring:
        // Serialization manager must be added to its own game object
        // Because we need to destroy the mouse manager on load, but we need to keep
        // the serialization manager
        DontDestroyOnLoad(this); 
        // ^^^

        filePath = Application.persistentDataPath + "/save.data";

        // Check there are no other copies of this class in the scene
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveGame(VehicleDecriptor saveData)
    {
        FileStream dataStream = new FileStream(filePath, FileMode.Create);

        BinaryFormatter converter = new BinaryFormatter();
        converter.Serialize(dataStream, saveData);

        dataStream.Close();
    }

    public VehicleDecriptor LoadGame()
    {
        if (File.Exists(filePath))
        {
            // File exists
            FileStream dataStream = new FileStream(filePath, FileMode.Open);

            BinaryFormatter converter = new BinaryFormatter();
            VehicleDecriptor saveData = converter.Deserialize(dataStream) as VehicleDecriptor;

            dataStream.Close();
            return saveData;
        }
        else
        {
            // File does not exist
            Debug.LogError("Save file not found in " + filePath);
            return null;
        }
    }


}

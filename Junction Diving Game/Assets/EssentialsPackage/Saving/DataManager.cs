using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[System.Serializable] public class GameData 
{

    public GameData ()
    {

    }

}


public class DataManager : MonoBehaviour
{
    public static DataManager Singleton;

    [SerializeField] private GameData data;

    public bool Active { get { return data != null; } }





    #region SaveLoad


    private void Awake ()
    {
        if (Singleton != null)
        {
            Destroy (gameObject);
        } else
        {
            Singleton = this;
            Load ();
        }

        DontDestroyOnLoad (gameObject);

    }

    private void OnApplicationPause (bool pause)
    {
        Save ();
    }

    private void OnApplicationQuit ()
    {
        Save ();
    }

    private void OnDestroy ()
    {
        Save ();
    }

    private void OnDisable ()
    {
        Save ();
    }

    public void Load ()
    {

        data = LoadData ();

    }

    public void Save ()
    {

        SaveData (data);

    }

    private string fileName = "saveData.data";

    private void SaveData (GameData saveData)
    {

        BinaryFormatter formatter = new BinaryFormatter ();
        string path = Path.Combine (Application.persistentDataPath, fileName);

        FileStream stream = new FileStream (path, FileMode.Create);


        formatter.Serialize (stream, saveData);
        stream.Close ();
    }

    private GameData LoadData ()
    {
        string path = Path.Combine (Application.persistentDataPath, fileName);

        if (File.Exists (path))
        {
            BinaryFormatter formatter = new BinaryFormatter ();
            FileStream stream = new FileStream (path, FileMode.Open);

            GameData data = formatter.Deserialize (stream) as GameData;

            stream.Close ();

            return data;

        } else
        {

            return new GameData ();
        }
    }
    #endregion
}

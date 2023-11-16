using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    public SaveData SaveFile;
    public int SaveID;
    public bool toLoad = false;

    // Start is called before the first frame update
    public void LoadData(SaveData file, int id){
            SaveFile = file;
            SaveID = id;
            DontDestroyOnLoad(gameObject);
            toLoad = true;
        }
}


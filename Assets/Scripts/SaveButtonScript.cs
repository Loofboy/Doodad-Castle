using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private string SaveID;
    public SaveData file;
    public GameObject dataman;

    public void SaveGame(){
        if(!string.IsNullOrEmpty(SaveID)){
            file = dataman.GetComponent<DataManager>().save;
            string path = Application.streamingAssetsPath + "/SaveData" + SaveID + ".json";
            var content = JsonUtility.ToJson(file, true);
            file = JsonUtility.FromJson<SaveData>(content);
            System.IO.Directory.CreateDirectory(Application.streamingAssetsPath);
            System.IO.File.WriteAllText(path, content);
        }
    }
}

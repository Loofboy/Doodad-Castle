using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LoadButtonScript : MonoBehaviour
{
    [SerializeField] private int SaveID;
    public SaveData file;
    public GameObject SaveDataObj;
    private string path;
    void Start(){
        path = Application.streamingAssetsPath + "/SaveData" + SaveID + ".json";
        if(!System.IO.File.Exists(path)){
            gameObject.GetComponent<Button>().interactable = false;
        }
        else{
            gameObject.GetComponent<Button>().interactable = true;
            string path = Application.streamingAssetsPath + "/SaveData" + SaveID + ".json";
            if(!string.IsNullOrEmpty(path)){
                var content = System.IO.File.ReadAllText(path);
                file = JsonUtility.FromJson<SaveData>(content);
            }
        }
    }
    // Start is called before the first frame update
    public void SendFile(){
        SaveDataObj.GetComponent<Save>().LoadData(file, SaveID);
    }
}

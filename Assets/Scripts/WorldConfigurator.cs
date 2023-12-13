using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldConfigurator : MonoBehaviour
{
    private static WorldConfigurator _instance;

    public static WorldConfigurator Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindFirstObjectByType<WorldConfigurator>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject("WorldConfigurator");
                    _instance = obj.AddComponent<WorldConfigurator>();
                }
            }
            return _instance;
        }
    }

    public float ObstructionFadingSpeed { get; set; }

    public Material transparentMaterial;  // You may need to set this in the Unity Editor
}

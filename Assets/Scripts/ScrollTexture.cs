using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTexture : MonoBehaviour
{
    public float scrollSpeedX;
    public float scrollSpeedY;
    private MeshRenderer meshr;
    // Start is called before the first frame update
    void Start()
    {
        meshr = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        meshr.material.mainTextureOffset = new Vector2(Time.realtimeSinceStartup * scrollSpeedX, Time.realtimeSinceStartup * scrollSpeedY);
    }
}

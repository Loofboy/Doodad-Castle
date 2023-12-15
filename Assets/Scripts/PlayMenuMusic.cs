using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMenuMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        JSAM.AudioManager.PlayMusic(SoundLibraryMusic.MenuMusic);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

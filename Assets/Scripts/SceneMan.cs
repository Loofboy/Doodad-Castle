using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMan : MonoBehaviour
{
    public GameObject SettingsMenu;
    public GameObject MainMenu;
    public GameObject LoadMenu;
    public GameObject StoryCards;
    public Animator Fader;
    public bool pausable = false;
    // Start is called before the first frame update
    public void EnterMenu() {
        Time.timeScale = 1;
        JSAM.AudioManager.PlaySound(SoundLibrarySounds.click);
        StartCoroutine(SwitchScene("MainMenuScene"));
    }

    public void ResumeGame() {
        MainMenu.SetActive(false);
        SettingsMenu.SetActive(false);
        pausable = true;
        Time.timeScale = 1;
        JSAM.AudioManager.PlaySound(SoundLibrarySounds.click);
    }

    public void PlayGame() {
        //Fader.SetTrigger("Fade");
        StartCoroutine(SwitchScene("GameScene"));
    }
    private IEnumerator SwitchScene(string name) {
        Fader.SetTrigger("Fade");
        JSAM.AudioManager.StopMusicIfPlaying(SoundLibraryMusic.GameMusic);
        JSAM.AudioManager.StopMusicIfPlaying(SoundLibraryMusic.MenuMusic);
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene(name);
    }

    public void QuitGame() {
        JSAM.AudioManager.PlaySound(SoundLibrarySounds.click);
        Application.Quit();
    }

    public void EnterSettings() {
        if (SettingsMenu == null || MainMenu == null)
            return;
        SettingsMenu.SetActive(true);
        MainMenu.SetActive(false);
        JSAM.AudioManager.PlaySound(SoundLibrarySounds.click);
    }

    public void EnterLoadMenu() {
        if (LoadMenu == null || MainMenu == null)
            return;
        LoadMenu.SetActive(true);
        MainMenu.SetActive(false);
        JSAM.AudioManager.PlaySound(SoundLibrarySounds.click);
    }

    public void ExitSettings() {
        if (SettingsMenu == null || MainMenu == null)
            return;
        SettingsMenu.SetActive(false);
        MainMenu.SetActive(true);
        JSAM.AudioManager.PlaySound(SoundLibrarySounds.click);
    }

    public void ExitLoadMenu() {
        if (LoadMenu == null || MainMenu == null)
            return;
        LoadMenu.SetActive(false);
        MainMenu.SetActive(true);
        JSAM.AudioManager.PlaySound(SoundLibrarySounds.click);
    }
    public void EnterCards()
    {
        StoryCards.SetActive(true);
        //StoryCards.GetComponent<Dialoguer>().StartDialogue();
        MainMenu.SetActive(false);
        JSAM.AudioManager.PlaySound(SoundLibrarySounds.click);
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape) && pausable == true){
            JSAM.AudioManager.PlaySound(SoundLibrarySounds.click);
            MainMenu.SetActive(true);
            pausable = false;
            Time.timeScale = 0;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && pausable == false){
            ResumeGame();
        }
    }
}

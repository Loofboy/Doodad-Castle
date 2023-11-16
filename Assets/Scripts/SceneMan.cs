using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMan : MonoBehaviour
{
    public GameObject SettingsMenu;
    public GameObject MainMenu;
    public GameObject LoadMenu;
    public Animator Fader;
    public bool pausable = false;
    // Start is called before the first frame update
    public void EnterMenu(){
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenuScene");
    }

    public void ResumeGame(){
        MainMenu.SetActive(false);
        SettingsMenu.SetActive(false);
        pausable = true;
        Time.timeScale = 1;
    }

    public void PlayGame(){
        Fader.SetTrigger("Fade");
        StartCoroutine(SwitchScene());
    }
    private IEnumerator SwitchScene(){
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void EnterSettings(){
        if(SettingsMenu == null || MainMenu == null)
            return;
        SettingsMenu.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void EnterLoadMenu(){
        if(LoadMenu == null || MainMenu == null)
            return;
        LoadMenu.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void ExitSettings(){
        if(SettingsMenu == null || MainMenu == null)
            return;
        SettingsMenu.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void ExitLoadMenu(){
        if(LoadMenu == null || MainMenu == null)
            return;
        LoadMenu.SetActive(false);
        MainMenu.SetActive(true);
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape) && pausable == true){
            MainMenu.SetActive(true);
            pausable = false;
            Time.timeScale = 0;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && pausable == false){
            ResumeGame();
        }



    }
}

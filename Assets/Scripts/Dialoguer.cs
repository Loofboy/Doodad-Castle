using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialoguer : MonoBehaviour
{
    public SceneMan scener;
    public TextMeshProUGUI textcomp;
    public string[] lines;
    public List<Sprite> cardimages;
    public float textSpeed;
    public bool LaunchNewGame;
    public bool hasCards;

    private int index;
    public Image imagecomp;
    // Start is called before the first frame update
    void Start()
    {
        textcomp.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(textcomp.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textcomp.text = lines[index];
            }
        }
    }

    public void StartDialogue()
    {
        index = 0;
        if (hasCards)
            imagecomp.sprite = cardimages[index];
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textcomp.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    void NextLine()
    {
        if(index < lines.Length - 1)
        {
            index++;
            textcomp.text = string.Empty;
            if (hasCards)
                imagecomp.sprite = cardimages[index];
            StartCoroutine(TypeLine());
        }
        else
        {
            
            if (LaunchNewGame)
            {
                scener.PlayGame();
            }
            else gameObject.SetActive(false);
        }
    }
}

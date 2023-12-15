using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveItem : MonoBehaviour
{

    public Transform target;
    public float speed;
    private float timenow;
    private bool isgone = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        speed += 0.075f;

        if (Vector3.Distance(transform.position, target.position) < 0.001f)
        {
            if (!isgone)
            {
                timenow = Time.time;
                JSAM.AudioManager.PlaySound(SoundLibrarySounds.pop, transform);
            }
                isgone = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = null;
            transform.GetChild(0).gameObject.SetActive(false);
            if (Time.time > timenow + 2f)
                Destroy(gameObject);
        }
    }
}

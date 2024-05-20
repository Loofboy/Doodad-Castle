using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 10f;
    public float damage = 2;
    Rigidbody rb;


    // Update is called once per frame
    private void Start() {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other) {
		if (other.gameObject.layer == 8) {
			other.gameObject.GetComponent<PlayerController>().DecreaseHealth(damage);
		} 
        Destroy(gameObject);
    }
}

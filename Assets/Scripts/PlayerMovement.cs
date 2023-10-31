using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust this to control the player's movement speed
    public float jumpForce = 10f; // Adjust this to control the jump force
    public bool isGrounded = true;

    private Rigidbody rb;
    public LayerMask terrainLayer;
    public GameObject body;
    public Animator Anim;
    public bool flipped = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(Blink());
    }

    void repeatBlink()
    {
        StartCoroutine(Blink());
    }
    private void Update()
    {

        // Player movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            Anim.SetBool("IsJumping", true);
        }

        if(movement != Vector3.zero)
            Anim.SetBool("IsRunning", true);
        else Anim.SetBool("IsRunning", false);

        if (rb.velocity.y > 0)
        {
            Anim.SetBool("IsJumping", true);
            Anim.SetBool("IsFalling", false);
        }
        else if(rb.velocity.y < -0.2)
        {
            Anim.SetBool("IsJumping", false);
            Anim.SetBool("IsFalling", true);
        }
        else if (isGrounded)
        {
            Anim.SetBool("IsFalling", false);
            Anim.SetBool("IsJumping", false);
        }
        //(transform.position + transform.TransformDirection(movement))

        if (horizontalInput != 0 && horizontalInput < 0)
        {
            body.transform.localScale = new Vector3(-1f, 1f, 1f);
            flipped = true;
        }
        else if (horizontalInput != 0 && horizontalInput > 0)
        {
            body.transform.localScale = new Vector3(1f, 1f, 1f);
            flipped = false;
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if(collider != null && collider.TryGetComponent<ItemObject>(out ItemObject item))
        {
            Debug.Log("Collided with item " + collider.name);
            item.OnPickupItem();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    private IEnumerator Blink()
    {
        yield return new WaitForSeconds(10f);
        Anim.SetTrigger("Blink");
        StartCoroutine(Blink());
    }

}
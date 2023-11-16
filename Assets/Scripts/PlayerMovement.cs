using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private float defmoveSpeed = 5;
    private float defjumpForce = 10;
    private float defmaxhealth = 10;
    public float moveSpeed;
    public float jumpForce;
    public float maxhealth;
    public float health;
    public float invinctime = 1;
    public bool isGrounded = true;

    public TextMeshProUGUI healthText;
    public Slider HealthBar;

    private float damagedTime = 0f;
    private Rigidbody rb;
    public LayerMask terrainLayer;
    public GameObject body;
    public Animator Anim;
    public bool flipped = false;

    private void Start()
    {
        moveSpeed = defmoveSpeed;
        jumpForce = defjumpForce;
        maxhealth = defmaxhealth;
        rb = GetComponent<Rigidbody>();
        StartCoroutine(Blink());
        health = maxhealth;
        HealthBar.maxValue = maxhealth;
        HealthBar.value = health;
        healthText.text = "Health: " + health;
    }

    void repeatBlink()
    {
        StartCoroutine(Blink());
    }

    public void ResetStats(){
        CharacterData dat = transform.GetChild(0).GetComponent<CharAnimEvents>().chardat;
        moveSpeed = defmoveSpeed + dat.SpeedBuff;
        jumpForce = defjumpForce + dat.JumpBuff;
        maxhealth = defmaxhealth + dat.HealthModifier;
        HealthBar.maxValue = maxhealth;
        if(health > maxhealth){
            health = maxhealth;
            HealthBar.value = health;
        }
        healthText.text = "Health: " + health;
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
    public void DecreaseHealth(float damageDealt)
    {
        if(Time.time > damagedTime + invinctime){
            damagedTime = Time.time;
            health -= damageDealt;
            HealthBar.value = health;
            healthText.text = "Health: " + health;
            if(health <= 0){

                Vector3 newpos = new Vector3(0, 10, 0);
                Debug.Log("PLAYER DIED");
                transform.position = newpos;
                
                health = maxhealth;
                HealthBar.value = health;
                healthText.text = "Health: " + health;
            }
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
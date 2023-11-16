using UnityEngine;
using System.Collections;

public class NPCController : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust this to control the player's movement speed
    public float jumpForce = 10f; // Adjust this to control the jump force
    public bool isGrounded = true;

    private Rigidbody rb;
    public LayerMask terrainLayer;
    public GameObject body;
    public Animator Anim;
    public bool flipped = false;
    private GameObject playerpref;
    private bool EnteredTrigger;

    public GameObject placeholderpref;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(Blink());
        body = this.gameObject.transform.GetChild(0).gameObject;
        Anim = body.GetComponent<Animator>();
    }

    void repeatBlink()
    {
        StartCoroutine(Blink());
    }
    private void Update()
    {

        // Player movement
       // float horizontalInput = Input.GetAxis("Horizontal");
        //float verticalInput = Input.GetAxis("Vertical");

        //Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
        //transform.Translate(movement);

        //if (isGrounded && Input.GetButtonDown("Jump"))
        // {
        //     rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        //     isGrounded = false;
        //     Anim.SetBool("IsJumping", true);
        // }

        if(rb.velocity.x != 0 || rb.velocity.y != 0)
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

        //if (horizontalInput != 0 && horizontalInput < 0)
        //{
        //    body.transform.localScale = new Vector3(-1f, 1f, 1f);
        //    flipped = true;
        //}
        //else if (horizontalInput != 0 && horizontalInput > 0)
        //{
        //    body.transform.localScale = new Vector3(1f, 1f, 1f);
        //    flipped = false;
        //}
        if (Input.GetKeyDown(KeyCode.R) && EnteredTrigger)
        {
            SwitchCharacter(false);
        }

    }
    public void SwitchCharacter(bool switchpos){
        playerpref = GameObject.FindGameObjectWithTag("Play");
        var Playerobj = playerpref.transform.GetChild(0);
            var NPCObj = transform.GetChild(0);
            playerpref.GetComponent<PlayerToolUser>().playerAnim.SetBool("IsHoldingTool", false);
            if(playerpref.transform.GetChild(0).GetChild(1).GetChild(1).GetChild(0).GetChild(0).transform.childCount != 0){
                Destroy(playerpref.transform.GetChild(0).GetChild(1).GetChild(1).GetChild(0).GetChild(0).GetChild(0).gameObject);
                playerpref.GetComponent<PlayerToolUser>().currenttoolid = "none";
            }
            
            var pl = Instantiate(placeholderpref, transform.position, Quaternion.identity);
            
            Playerobj.transform.SetParent(pl.transform);
            NPCObj.transform.SetParent(pl.transform);

            if(switchpos == false){
                transform.position = playerpref.transform.position;
                playerpref.transform.position = pl.transform.position;
            }
            else{
                Playerobj.transform.position = transform.position;
                NPCObj.transform.position = playerpref.transform.position;
            }

            Playerobj.transform.SetParent(transform);
            NPCObj.transform.SetParent(playerpref.transform);

            Destroy(pl.gameObject);

            body = transform.GetChild(0).gameObject;
            Anim = body.GetComponent<Animator>();
            transform.GetChild(0).GetComponent<CharAnimEvents>().parentChar = this.gameObject;
            playerpref.transform.GetChild(0).GetComponent<CharAnimEvents>().parentChar = playerpref.gameObject;
            playerpref.GetComponent<PlayerController>().body = playerpref.gameObject.transform.GetChild(0).gameObject;
            playerpref.GetComponent<PlayerController>().Anim = playerpref.gameObject.transform.GetChild(0).GetComponent<Animator>();
            playerpref.GetComponent<PlayerToolUser>().playerAnim = playerpref.gameObject.transform.GetChild(0).GetComponent<Animator>();
            playerpref.GetComponent<PlayerToolUser>().toolpos = playerpref.gameObject.transform.GetChild(0).GetChild(1).GetChild(1).GetChild(0).GetChild(0).gameObject;
            // if(this.gameObject.transform.GetChild(0).GetChild(1).GetChild(1).GetChild(0).GetChild(0).GetChild(0) != null)
            //     Destroy(this.gameObject.transform.GetChild(0).GetChild(1).GetChild(1).GetChild(0).GetChild(0).GetChild(0));
            playerpref.GetComponent<PlayerController>().ResetStats();




    }
    //private void OnTriggerEnter(Collider collider)
    //{
    //    if(collider != null && collider.TryGetComponent<ItemObject>(out ItemObject item))
    //    {
    //        Debug.Log("Collided with item " + collider.name);
    //        item.OnPickupItem();
        // }
    // }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 8)
        {
           // playerpref = other.gameObject;
            EnteredTrigger = true;
            Debug.Log("INBOUNDARYWITHNPC");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            EnteredTrigger = false;
            Debug.Log("OUTBOUNDARYWITHNPC");
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
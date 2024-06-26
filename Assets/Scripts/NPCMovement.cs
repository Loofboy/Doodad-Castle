using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class NPCController : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust this to control the player's movement speed
    public float jumpForce = 10f; // Adjust this to control the jump force
    public bool isGrounded = true;
    public GameObject assignedResource;
    public List<string> FriendList = new List<string>();
    public List<string> EnemyList = new List<string>();
    public bool isPicking = false;
    public float invCapacity;
    public List<GameObject> items = new List<GameObject>();
    public bool busy = false;
    public bool onCooldown = false;

    private Rigidbody rb;
    public LayerMask terrainLayer;
    public GameObject body;
    public Animator Anim;
    public bool flipped = false;
    private GameObject playerpref;
    private bool EnteredTrigger;

    public bool canMove = true;

    public GameObject placeholderpref;
    public ToolBarScript Toolbar;

    [SerializeField] public UnityEngine.AI.NavMeshAgent navagent;
    [SerializeField] GameObject resourceMenu;


    private void Awake()
    {
        Toolbar = GameObject.Find("Tool bar").GetComponent<ToolBarScript>();
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(Blink());
        body = this.gameObject.transform.GetChild(0).gameObject;
        Anim = body.GetComponent<Animator>();
        resourceMenu = GameObject.FindObjectOfType<ResourceMenu>(true).gameObject;
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

        if(navagent.velocity.x != 0 || navagent.velocity.y != 0)
            Anim.SetBool("IsRunning", true);
        else Anim.SetBool("IsRunning", false);

        /*if (navagent.velocity.y > 0)
        {
            Anim.SetBool("IsJumping", true);
            Anim.SetBool("IsFalling", false);
        }
        else if(navagent.velocity.y < -0.2)
        {
            Anim.SetBool("IsJumping", false);
            Anim.SetBool("IsFalling", true);
        }
        else if (isGrounded)
        {
            Anim.SetBool("IsFalling", false);
            Anim.SetBool("IsJumping", false);
        }*/
        //(transform.position + transform.TransformDirection(movement))

        if (navagent.velocity.x < 0 && canMove)
        {
            body.transform.localScale = new Vector3(-1f, 1f, 1f);
            flipped = true;
        }
        else if (navagent.velocity.x != 0 && navagent.velocity.x > 0 && canMove)
        {
            body.transform.localScale = new Vector3(1f, 1f, 1f);
            flipped = false;
        }

        if (Input.GetKeyDown(KeyCode.R) && EnteredTrigger)
        {
            SwitchCharacter(false);
        }
        if (Input.GetKeyDown(KeyCode.T) && EnteredTrigger && !busy)
        {
            OpenResourceMenu();
        }

        FriendList = body.GetComponent<CharAnimEvents>().chardat.friendlist;
        EnemyList = body.GetComponent<CharAnimEvents>().chardat.enemylist;

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
        Toolbar.DeselectAll();

            
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
        assignedResource = null;
        if(GetComponent<PlayerToolUser>().currenttoolid != "none")
            GetComponent<PlayerToolUser>().UnEquipTool();
        GetComponent<BehaviourTreeRunner>().Restart();
        busy = false;
        transform.GetComponentInChildren<CharAnimEvents>().parentChar = this.gameObject;
        playerpref.transform.GetComponentInChildren<CharAnimEvents>().parentChar = playerpref.gameObject;
        playerpref.GetComponent<PlayerController>().body = playerpref.gameObject.transform.GetChild(0).gameObject;
        playerpref.GetComponent<PlayerController>().Anim = playerpref.gameObject.transform.GetChild(0).GetComponent<Animator>();
        playerpref.GetComponent<PlayerToolUser>().playerAnim = playerpref.gameObject.transform.GetChild(0).GetComponent<Animator>();
        playerpref.GetComponent<PlayerToolUser>().toolpos = playerpref.gameObject.transform.GetChild(0).GetChild(1).GetChild(1).GetChild(0).GetChild(0).gameObject;
            // if(this.gameObject.transform.GetChild(0).GetChild(1).GetChild(1).GetChild(0).GetChild(0).GetChild(0) != null)
            //     Destroy(this.gameObject.transform.GetChild(0).GetChild(1).GetChild(1).GetChild(0).GetChild(0).GetChild(0));
        playerpref.GetComponent<PlayerController>().ResetStats();
    }

    public void OpenResourceMenu()
    {
        if (resourceMenu == null) resourceMenu = GameObject.FindObjectOfType<ResourceMenu>(true).gameObject;
        if (resourceMenu == null) return;
        if (resourceMenu.active) resourceMenu.GetComponent<ResourceMenu>().CloseMenu();
        else
        {
            resourceMenu.SetActive(true);
            resourceMenu.GetComponent<ResourceMenu>().assignedNPC = this;
        }
    }
    public void DumpItems(){
        StartCoroutine(spawnitem());
    }
    public IEnumerator cooldownInteract()
    {
        yield return new WaitForSeconds(60f);
        onCooldown = false;
    }
    IEnumerator spawnitem(){
        int num1 = UnityEngine.Random.Range(1, 5);
        float num2 = UnityEngine.Random.Range(-2, 2);
        for(int i = 0; i < items.Count; i++){
            Instantiate(items[i], transform.position + Vector3.up*num1 + Vector3.right*num2, Quaternion.identity);
            yield return new WaitForSeconds(2.5f / items.Count);
        }
        items.Clear();
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
    private void OnTriggerStay(Collider other) {
        if(other.gameObject.layer == 7 && isPicking){
            items.Add(other.gameObject.GetComponentInChildren<ItemObject>().referenceItem.prefab);
            Destroy(other.gameObject);
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
            if (!navagent.enabled)
                navagent.enabled = true;
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
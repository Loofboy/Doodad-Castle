using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiAgent : MonoBehaviour
{

    public GameObject Player;
    public GameObject projectile;
    public float projectileSpeed;
    public float projectileCooldown;
    public bool hasAggressionStates = false;
    public bool aggressive;
    public float aggressionDuration= 10f;
    //public Vector3 Position;
    public float health;
    public NPCController NPC;
    public bool NPCenemy = false;
    public NavMeshAgent navagent;
    private float prevhealth;
    private float fireTime = 0f;
    private float aggressionTime = 0f;
    private void Start() {
        navagent = GetComponent<NavMeshAgent>();
    }
    private void Update() {
        if(Player == null)
            Player = PlayerController.instance.gameObject;
        //Position = transform.position;
        
        if(hasAggressionStates && health != prevhealth){
            aggressive = true;
            aggressionTime = Time.time;
        }
        if(aggressive && aggressionTime + aggressionDuration < Time.time){
            aggressive = false;
        }

        prevhealth = health;
    }

    public bool CheckforPlayerInRange(float range){
        return Vector3.Distance(Player.transform.position, transform.position) <= range;
    }

    public bool CheckforNPCInRange(float range){
        Collider[] colliders = Physics.OverlapSphere(transform.position, range);
        foreach (Collider collider in colliders)
        {
            NPCController npcController = collider.GetComponent<NPCController>();
            if (npcController != null && !npcController.busy && !npcController.onCooldown && npcController != GetComponent<NPCController>() && !GetComponent<NPCController>().busy && !GetComponent<NPCController>().onCooldown) {
                NPC = npcController;
                return true;
            }
        }
        return false;
    }
    public void InteractWithNPC()
    {
        navagent.isStopped = true;
        GetComponent<NPCController>().busy = true;
        GetComponent<NPCController>().onCooldown = true;
        GetComponent<NPCController>().canMove = false;
        NPC.busy = true;
        NPC.onCooldown = true;
        NPC.navagent.isStopped = true;
        NPC.canMove = false;
        if(NPC.gameObject.transform.position.x < transform.position.x)
        {
            GetComponent<NPCController>().body.transform.localScale = new Vector3(-1f, 1f, 1f);
            GetComponent<NPCController>().flipped = true;

            NPC.body.transform.localScale = new Vector3(1f, 1f, 1f);
            NPC.flipped = false;
        }
        else if (NPC.gameObject.transform.position.x >= transform.position.x)
        {
            GetComponent<NPCController>().body.transform.localScale = new Vector3(1f, 1f, 1f);
            GetComponent<NPCController>().flipped = false;

            NPC.body.transform.localScale = new Vector3(-1f, 1f, 1f);
            NPC.flipped = true;
        }
        GetComponentInChildren<CharAnimEvents>().PlayInteractAnim(NPCenemy);
        NPC.GetComponentInChildren<CharAnimEvents>().PlayInteractAnim(NPCenemy);
        StartCoroutine(StopChatter());
    }
    IEnumerator StopChatter()
    {
        yield return new WaitForSeconds(10f);
        navagent.isStopped = false;
        GetComponent<NPCController>().busy = false;
        GetComponent<NPCController>().canMove = true;
        NPC.busy = false;
        NPC.navagent.isStopped = false;
        NPC.canMove = true;
        StartCoroutine(NPC.cooldownInteract());
        StartCoroutine(GetComponent<NPCController>().cooldownInteract());
    }
    public void FireProjectile(Vector3 target){
        if(fireTime + projectileCooldown < Time.time){
            GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity);
            bullet.transform.LookAt(target);
            bullet.GetComponent<Bullet>().speed = projectileSpeed;
            fireTime = Time.time;
        }
    }
    public void MoveToTarget(Vector3 target){
        navagent.isStopped = false;
        navagent.destination = target;
    }
    public void StopNav(){
        navagent.isStopped = true;
    }
    public void EquipTool(GameObject resource){
        ResourceData res = resource.GetComponentInChildren<ResourceObject>().referenceResource;
        if(res.allowedwpntype == "axe"){
            GetComponentInChildren<PlayerToolUser>().compareTool(GetComponentInChildren<PlayerToolUser>().AxePrefab, "tool_staraxe");
        }
        else if(res.allowedwpntype == "pick"){
            GetComponentInChildren<PlayerToolUser>().compareTool(GetComponentInChildren<PlayerToolUser>().PickPrefab, "tool_starpick");
        }
        else if(res.allowedwpntype == "sword"){
            GetComponentInChildren<PlayerToolUser>().compareTool(GetComponentInChildren<PlayerToolUser>().SwordPrefab, "tool_starsword");
        }
    }
}

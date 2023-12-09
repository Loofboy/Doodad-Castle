using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceObject : MonoBehaviour
{
    public ResourceData referenceResource;
    ToolObject tool;
    public float HP;
    public float damage;
    public bool isEnemy;
    Animator resAnim;

    private void Start()
    {
        HP = referenceResource.resourceHealth;
        damage = referenceResource.damage;
        resAnim = GetComponent<Animator>();
    }
    public void decreaseHP(float toolDamage)
    {
        HP -= toolDamage;
        resAnim.SetTrigger("Hit");
        if(HP <= 0)
        {
            OnDestroyResource();
        }
    }
    public void OnDestroyResource()
    {
        for(int i = 0; i < referenceResource.dropCount; i++)
        {
            Vector3 pos = new Vector3(transform.position.x, transform.position.y+i*2, transform.position.z);
            Instantiate(referenceResource.dropPrefab, pos, Quaternion.identity);
        }
        transform.parent.gameObject.GetComponent<ResourceRespawner>().BeginRespawn(gameObject, isEnemy);
        if (isEnemy)
        {
            transform.parent.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            transform.parent.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9 || other.gameObject.layer == 11)
        {
            Debug.Log("Hit " + this.gameObject.name);
            tool = other.transform.parent.GetChild(0).GetChild(1).GetChild(1).GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<ToolObject>();
            if(tool.wpntype == referenceResource.allowedwpntype)
            {
                decreaseHP(tool.damage);
                Object.Destroy(other.gameObject);
            }
        }
    }
}

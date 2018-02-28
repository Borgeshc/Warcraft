using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minotaur : MonoBehaviour
{
    public LayerMask wallMask;
    public float speed = 2f;
    public float rotationSpeed = 100f;
    public float timeBeforeReady = 1.5f;
    public float timeBeforeCharge = 1f;
    public Collider myCollider;

    GameObject player;
    Animator anim;
    Health health;

    bool ready;
    bool charging;
    bool timeToMove;

    Vector3 targetPosition;

    private IEnumerator Start()
    {
        player = GameObject.Find("Player");
        health = GetComponent<Health>();
        anim = GetComponentInChildren<Animator>();
        anim.SetTrigger("Spawn");

        yield return new WaitForSeconds(timeBeforeReady);
        ready = true;
    }

    private void Update()
    {
        if (!ready || health.isDead) return;

        if(!charging)
        {
            charging = true;
            StartCoroutine(Charge());
        }

        if(timeToMove)
            transform.position = Vector3.Lerp(transform.position, new Vector3(targetPosition.x, 0, targetPosition.z), speed * Time.deltaTime);
    }

    IEnumerator Charge()
    {
        transform.LookAt(player.transform.position);

        anim.SetTrigger("Taunt");

        yield return new WaitForSeconds(timeBeforeCharge);

        if (myCollider.enabled == false)
            myCollider.enabled = true;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, wallMask))
        {
            anim.SetBool("Move", true);
            anim.SetBool("Attack", true);

            targetPosition = hit.point;
            timeToMove = true;
        }

        yield return new WaitUntil(() => CheckDistance(targetPosition) == true);
        anim.SetBool("Attack", false);
        anim.SetBool("Move", false);
        timeToMove = false;
        charging = false;
    }

    bool CheckDistance(Vector3 hit)
    {
        if (Vector3.Distance(transform.position, hit) <= 5)
            return true;
        else return false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Player"))
        {
            other.GetComponent<PlayerHealth>().Killed();
        }
    }
}

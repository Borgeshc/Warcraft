using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceOnTrigger : MonoBehaviour
{
    public int force;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Enemy"))
        {
            other.GetComponent<Rigidbody>().AddForce((other.transform.up + -other.transform.forward) * force);
            Destroy(gameObject);
        }
    }
}

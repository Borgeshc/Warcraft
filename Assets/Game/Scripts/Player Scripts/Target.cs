using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Target : MonoBehaviour
{
    public LayerMask targetable;
    public static GameObject target;
    public static List<GameObject> nearByTargets = new List<GameObject>();

    PlayerManager playerManager;
    bool checkingNearByEnemies;

    private void Start()
    {
        playerManager = GetComponent<PlayerManager>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, 100, targetable))
            {
                if (target != hit.transform.gameObject)
                    nearByTargets.Clear();

                target = hit.transform.gameObject;
                hit.transform.GetComponent<Targetable>().Target(playerManager);
            }
            else
            {
                playerManager.DisableEnemyNamePlate();
                target = null;
                nearByTargets.Clear();
            }
        }

        if(!checkingNearByEnemies)
        {
            checkingNearByEnemies = true;
            StartCoroutine(CheckNearByEnemies());
        }
    }

    IEnumerator CheckNearByEnemies()
    {
        if (target != null)
        {
            RaycastHit[] hit = Physics.SphereCastAll(target.transform.position, 10, transform.position, 0, targetable);

            List<GameObject> hitObjects = new List<GameObject>();

            for (int i = 0; i < hit.Length; i++)
            {
                hitObjects.Add(hit[i].transform.gameObject);
                if (!nearByTargets.Contains(hitObjects[i]))
                {
                    nearByTargets.Add(hitObjects[i]);
                }
            }

            for (int i = 0; i < nearByTargets.Count; i++)
            {
                if (!hitObjects.Contains(nearByTargets[i]))
                {
                    nearByTargets.Remove(nearByTargets[i]);
                }
            }
        }

        yield return new WaitForSeconds(.5f);
        checkingNearByEnemies = false;
    }

    public List<GameObject> GrabTargets(int numberOfTargets)
    {
        List<GameObject> targetsToGrab = new List<GameObject>();
        for(int i = 0; i < numberOfTargets; i++)
        {
            if(nearByTargets[i] != null)
                targetsToGrab.Add(nearByTargets[i]);
        }

        return targetsToGrab;
    }
}


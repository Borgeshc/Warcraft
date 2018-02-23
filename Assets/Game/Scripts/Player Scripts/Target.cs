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

    List<Transform> allEnemies = new List<Transform>();

    int tab;

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

        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(target != null)
            {
                if (nearByTargets.Count >= 1)
                {
                    if (tab >= nearByTargets.Count - 1)
                        tab = 0;
                    else
                        tab++;

                    target = nearByTargets[tab];

                    if (target)
                        target.transform.GetComponent<Targetable>().Target(playerManager);
                }
            }
            else
            {
                allEnemies.Clear();

                foreach(GameObject go in GameObject.FindGameObjectsWithTag("Enemy"))
                {
                    allEnemies.Add(go.transform);
                }

                target = GetClosestEnemy(allEnemies).gameObject;

                if(target)
                    target.transform.GetComponent<Targetable>().Target(playerManager);
            }
        }
    }

    Transform GetClosestEnemy(List<Transform> enemies)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (Transform potentialTarget in enemies)
        {
            Vector3 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }

        return bestTarget;
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
        if(nearByTargets.Count < numberOfTargets)
        {
            return nearByTargets;
        }
        else
        {
            List<GameObject> targetsToGrab = new List<GameObject>();
            for (int i = 0; i < numberOfTargets - 1; i++)
            {
                if (nearByTargets[i] != null)
                    targetsToGrab.Add(nearByTargets[i]);
            }

            return targetsToGrab;
        }
    }
}


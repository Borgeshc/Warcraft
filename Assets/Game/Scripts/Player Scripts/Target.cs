using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public LayerMask targetable;
    public static GameObject target;

    PlayerManager playerManager;

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
                target = hit.transform.gameObject;
                hit.transform.GetComponent<Targetable>().Target(playerManager);
            }
            else
            {
                playerManager.DisableEnemyNamePlate();
                target = null;
            }
        }
    }
}

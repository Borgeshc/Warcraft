using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementAbility : Ability
{
    public GameObject placementPendingObject;
    public GameObject objectToPlace;
    public NamePlate enemyNamePlate;

    public LayerMask placementLayerMask;

    bool isActivated;

    public override void ActivateAbility()
    {
        if (!OnGlobalCooldown() && !OnCooldown())
        {
            if (!isActivated)
            {
                isActivated = true;
            }
            else
            {
                ReActivateAbility();
            }
        }
    }

    private void Update()
    {
        if (isActivated)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100, placementLayerMask))
            {
                Vector3 position = hit.point + (hit.normal * .1f);
                Quaternion rotation = Quaternion.LookRotation(hit.normal);

                if (!placementPendingObject.activeInHierarchy)
                    placementPendingObject.SetActive(true);

                placementPendingObject.transform.position = position;
                placementPendingObject.transform.rotation = rotation;

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    ReActivateAbility();
                }
            }
        }
        
    }

    public override void ReActivateAbility()
    {
        GameObject trap = Instantiate(objectToPlace, placementPendingObject.transform.position, Quaternion.identity);
        trap.GetComponent<Trap>().SetUpTrap(enemyNamePlate, abilityMinDamage, abilityMaxDamage);

        if (placementPendingObject.activeInHierarchy)
            placementPendingObject.SetActive(false);

        isActivated = false;
        TriggerCooldown();
    }
}

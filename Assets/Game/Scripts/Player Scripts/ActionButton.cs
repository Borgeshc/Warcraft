using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionButton : MonoBehaviour
{
    public int actionButtonNumber;
    public Image icon;
    public Image cooldownProgress;
    public KeyCode keybind;

    AbilityLoadout abilityLoadout;

    bool showingCooldown;
    float cooldown;

    private void Start()
    {
        abilityLoadout = GameObject.Find("Player").GetComponent<AbilityLoadout>();
    }

    void Update ()
    {
	    if(Input.GetKeyDown(keybind))
        {
            abilityLoadout.ActionButtonPressed(actionButtonNumber);
        }
	}


    public void ActionButtonPressed()
    {
        abilityLoadout.ActionButtonPressed(actionButtonNumber);
    }

    public void SetIconImage(Sprite image)
    {
        icon.sprite = image;
        icon.enabled = true;
    }

    public void ShowCooldown(float _cooldown)
    {
        if(!showingCooldown)
        {
            showingCooldown = true;
            cooldown = _cooldown;
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown()
    {
        for(float i = 1; i > 0; i -= .1f)
        {
            cooldownProgress.fillAmount = i;
            yield return new WaitForSeconds(cooldown / 10);
            showingCooldown = false;
        }
        cooldownProgress.fillAmount = 0f;
    }

    public void DisableIconImage()
    {
        icon.enabled = false;
    }
}

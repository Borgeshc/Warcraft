using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionButton : MonoBehaviour
{
    public int actionButtonNumber;
    public Image icon;
    public KeyCode keybind;

    AbilityLoadout abilityLoadout;

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

    public void DisableIconImage()
    {
        icon.enabled = false;
    }
}

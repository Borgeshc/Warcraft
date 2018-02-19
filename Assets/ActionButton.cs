using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionButton : MonoBehaviour
{
    public Image icon;
    public KeyCode keybind;

    InputManager inputManager;

    private void Start()
    {
        inputManager = GameObject.Find("Player").GetComponent<InputManager>();
    }

    void Update ()
    {
	    if(Input.GetKeyDown(keybind))
        {
            inputManager.ActionButtonPressed();
        }
	}

    public void ActionButtonPressed()
    {
        inputManager.ActionButtonPressed();
    }

    public void SetIconImage(Sprite image)
    {
        icon.sprite = image;
    }
}

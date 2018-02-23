using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleObject : MonoBehaviour
{
    public KeyCode keyCode;
    public GameObject objectToToggle;

    private void Update()
    {
        if (Input.GetKeyDown(keyCode))
            objectToToggle.SetActive(!objectToToggle.activeInHierarchy);
    }
}

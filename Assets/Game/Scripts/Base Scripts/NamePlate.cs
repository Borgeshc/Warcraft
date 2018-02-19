using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NamePlate : MonoBehaviour
{
    public Text entityName;
    public Image entityImage;
    public Text entityLevel;
    public Image entityHealthBar;
    public Text entityHealth;
    public Image entityResourceBar;
    public Text entityResource;

    float maxHealth;
    float maxResource;

    public void SetUpBaseValues(float _maxHealth, float _maxResource)
    {
        maxHealth = _maxHealth;
        maxResource = _maxResource;
    }

    public void SetUpNamePlate(string _entityName, Sprite _entityImage, int _entityLevel, int _entityHealth, int _entityResource)
    {
        entityName.text = _entityName;
        entityImage.sprite = _entityImage;
        entityLevel.text = _entityLevel.ToString();
        entityHealthBar.fillAmount = _entityHealth;
        entityHealth.text = _entityHealth + " / " + maxHealth;
        entityResourceBar.fillAmount = _entityResource;
        entityResource.text = _entityResource + " / " + maxResource;
    }

    public void DisableNamePlate()
    {
        gameObject.SetActive(false);
    }

    public void UpdateHealth(int newHealth)
    {
        entityHealthBar.fillAmount = (newHealth / maxHealth);
        entityHealth.text = newHealth + " / " + maxHealth;
    }

    public void UpdateResource(int newResource)
    {
        entityResourceBar.fillAmount = newResource / maxResource;
        entityResource.text = newResource + " / " + maxResource;
    }
}

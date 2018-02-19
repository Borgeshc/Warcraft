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
    float currentHealth;

    float maxResource;
    float currentResource;

    public void SetUpNamePlate(string _entityName, Sprite _entityImage, int _entityLevel, int _entityHealth, int _entityResource)
    {
        maxHealth = _entityHealth;
        maxResource = _entityResource;

        entityName.text = _entityName;
        entityImage.sprite = _entityImage;
        entityLevel.text = _entityLevel.ToString();
        entityHealthBar.fillAmount = _entityHealth;
        entityHealth.text = _entityHealth + " / " + _entityHealth;
        entityResourceBar.fillAmount = _entityResource;
        entityResource.text = _entityResource + " / " + _entityResource;
    }

    public void UpdateHealth(int newHealth)
    {
        currentHealth = newHealth;
        entityHealthBar.fillAmount = (currentHealth / maxHealth);
        entityHealth.text = currentHealth + " / " + maxHealth;

        print("New Health: " + currentHealth);

        print("Max Health: " + maxHealth);
        print("Health Percent: " + (currentHealth / maxHealth));
    }

    public void UpdateMaxHealth(int newHealth)
    {
        maxHealth = newHealth;
        entityHealth.text = currentHealth + " / " + maxHealth;
    }

    public void UpdateResource(int newResource)
    {
        currentResource = newResource;
        entityResourceBar.fillAmount = currentResource / maxResource;
        entityResource.text = currentResource + " / " + maxResource;
    }

    public void UpdateMaxResource(int newResource)
    {
        maxResource = newResource;
        entityResource.text = currentResource + " / " + maxResource;
    }

}

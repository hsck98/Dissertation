using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthSystem : MonoBehaviour {

    //static events for adding health and removing health because we want to be able to trigger these events whenever a health bar is added or removed, not just this one
    public static event Action<HealthSystem> OnHealthAdded = delegate { };
    public static event Action<HealthSystem> OnHealthRemoved = delegate { };

    //this event is not static because changing the health should be a private event which only affects the current game object's health system and not all of them
    public event Action<float> OnHealthChanged = delegate { };
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;
    [SerializeField] private int regeneration = 1;

    private void OnEnable()
    {
        //set the current health to the maximum at the start
        currentHealth = maxHealth;
        OnHealthAdded(this);
        HandleRegeneration();
    }

    //this is a handler for regeneration
    private void HandleRegeneration()
    {
        StartCoroutine(RegenerateHealth());
    }

    //this is a coroutine for regerating health
    private IEnumerator RegenerateHealth()
    {
        while(true)
        {
            Heal(regeneration);
            //the waitforseconds() function simply forces the coroutine to occur only once per second
            yield return new WaitForSeconds(1);
        }
    }

    public int getCurrentHealth()
    {
        return currentHealth;
    }

    public int getMaxHealth()
    {
        return maxHealth;
    }

    //this function damanges the character
    public void Damage(int damageAmount)
    {
        //if the game object is still alive
        if (currentHealth > 0)
        {
            //reduce the current health by the damage received
            currentHealth -= damageAmount;

            //in the case reducing the current health results in going into negative health, reset the health to 0 as if you the game object was dead
            if(currentHealth < 0)
            {
                currentHealth = 0;
            }

            //calculate the percentage health to easily change the health bars (remember that the health bar images are of type "filled" which means they range from 0 to 1 representing how much of the image is visible)
            float currentHealthPct = (float)currentHealth / (float)maxHealth;
            OnHealthChanged(currentHealthPct);
        }
    }

    //this function heals the character
    public void Heal(int healAmount)
    {
        //check that the game object to be healed is a character (aka we do not want to be healing turrets; also remember we use this function for regeneration meaning that turrets would regenerate too if we did not specify the tag)
        if (transform.CompareTag("Allies") || transform.CompareTag("Enemies") || transform.CompareTag("Player"))
        {
            //if the character is alive and the current health is not at max
            if (currentHealth > 0 && currentHealth < maxHealth)
            {
                //heal the current health by the healing received
                currentHealth += healAmount;

                //if the current health exceeds the maximum health after healing, reset the health to the maximum health possible
                if (currentHealth > maxHealth)
                {
                    currentHealth = maxHealth;
                }

                float currentHealthPct = (float)currentHealth / (float)maxHealth;
                OnHealthChanged(currentHealthPct);
            }
        }
    }

    private void OnDisable()
    {
        OnHealthRemoved(this);
    }
}

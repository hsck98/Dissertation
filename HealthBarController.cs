using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : MonoBehaviour {

    [SerializeField] private HealthBar healthBarPrefab;
    [SerializeField] private GUIHealthBar guiHealthBarPrefab;

    private Dictionary<HealthSystem, HealthBar> healthBars = new Dictionary<HealthSystem, HealthBar>();
   
    private void Awake()
    {
        //handle the two events that are on the health systems
        HealthSystem.OnHealthAdded += AddHealthBar;
        HealthSystem.OnHealthRemoved += RemoveHealthBar;
    }

    //this function instantiates a health bar for every game object with a healthSystem script on it and adds it to the dictionary of healthbars
    private void AddHealthBar(HealthSystem healthSystem)
    {
        //first check if the game object in question is the player, in the case it is, do not instantiate a health bar for the player and instead set the GUI health system.
        if (healthSystem.CompareTag("Player"))
        {
            guiHealthBarPrefab.SetGUIHealthSystem(healthSystem);
            return;
        }

        //otherwise and only if there are no health bars with the same health system in the dictionary already (aka no game object is allowed to have more than one health bar), create a brand new health bar
        if (healthBars.ContainsKey(healthSystem) == false)
        {
            var healthBar = Instantiate(healthBarPrefab, transform);
            healthBars.Add(healthSystem, healthBar);
            healthBar.SetHealthSystem(healthSystem);
        }
    }

    //this function destroys the health bar and removes it from the dictionary of healthbars
    private void RemoveHealthBar(HealthSystem healthSystem)
    {
        if (healthBars.ContainsKey(healthSystem))
        {
            Destroy(healthBars[healthSystem].gameObject);
            healthBars.Remove(healthSystem);
        }
    }
}

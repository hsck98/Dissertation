using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIHealthBar : MonoBehaviour
{ 
    [SerializeField] private Image guiHealthBar;
    [SerializeField] private float updateSpeedSeconds = 0.5f;
    private HealthSystem healthSystem;

    //this function sets up the gui health system by handling the OnHealthChanged event and passing its parameters to the HandleHealthChanged handler
    public void SetGUIHealthSystem(HealthSystem healthSystem)
    {
        this.healthSystem = healthSystem;
        healthSystem.OnHealthChanged += HandleHealthChanged;
    }

    //Coroutine handler
    private void HandleHealthChanged(float pct)
    {
        StartCoroutine(ChangeToPct(pct));
    }

    //this is a coroutine function which will continue to repeat but the change of health will be gradual through a period of frames rather than changing in a single frame abruptly
    private IEnumerator ChangeToPct(float pct)
    {
        float preChangePct = guiHealthBar.fillAmount;
        float elapsed = 0f;

        //so while the elapsed time is less than 0.5seconds. Note that 1.0f in Unity time standards is 1 second.
        while (elapsed < updateSpeedSeconds)
        {
            elapsed += Time.deltaTime;
            //adjust the fill amount slowly with a slow animation by using linear interpolation between the character's health before getting hit and after getting hit
            guiHealthBar.fillAmount = Mathf.Lerp(preChangePct, pct, elapsed / updateSpeedSeconds);
            yield return null;
        }

        //this line is here in case the elapsed time in this code extends to longer than 0.5 seconds in which case the health bar will automatically 
        //set itself to the correct percentage without a gradual animation because there is no time for that
        guiHealthBar.fillAmount = pct;
    }
}

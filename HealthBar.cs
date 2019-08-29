using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    [SerializeField] private Image foregroundImage;
    [SerializeField] private Image backgroundImage;
    [SerializeField] private float updateSpeedSeconds = 0.5f;
    [SerializeField] private float regeneration = 1;
    private float positionOffset = 2.0f;

    private HealthSystem healthSystem;

    //set the health system
    public void SetHealthSystem(HealthSystem healthSystem)
    {
        this.healthSystem = healthSystem;
        healthSystem.OnHealthChanged += HandleHealthChanged;
    }

    //handler for OnHealthChanged()
    private void HandleHealthChanged(float pct)
    {
        StartCoroutine(ChangeToPct(pct));
    }

    //this is a coroutine function which will continue to repeat but the change of health will be gradual through a period of frames rather than changing in a single frame abruptly
    private IEnumerator ChangeToPct(float pct)
    {
        Debug.Log("Bar is changing");
        float preChangePct = foregroundImage.fillAmount;
        float elapsed = 0f;

        //so while the elapsed time is less than 0.5seconds. Note that 1.0f in Unity time standards is 1 second
        while (elapsed < updateSpeedSeconds)
        {
            elapsed += Time.deltaTime;
            //adjust the fill amount slowly with a slow animation by using linear interpolation between the character's health before getting hit and after getting hit
            foregroundImage.fillAmount = Mathf.Lerp(preChangePct, pct, elapsed / updateSpeedSeconds);
            yield return null;
        }

        foregroundImage.fillAmount = pct;
    }

    //LateUpdate() is used here to make sure that the change of orientation of the health bar considers any changes occuring in update in other scripts
    private void LateUpdate()
    {
        //Face the camera
        transform.LookAt(Camera.main.transform);
        //Rotate by 180 degrees so have the correct orientation
        transform.Rotate(0, 180, 0);
        //place an offset on the health bar's position so that the health bar isnt directly in the middle of the body of the characters
        transform.position = healthSystem.transform.position + (Vector3.up * positionOffset);
    }

    private void OnDestroy()
    {
        healthSystem.OnHealthChanged -= HandleHealthChanged;
    }
}

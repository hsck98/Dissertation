using UnityEngine;
using UnityEngine.EventSystems;

public class FixedJoystick : Joystick
{
    //remember we use vector2 because the joystick will be in the 2D plane as part of the UI
    Vector2 joystickPosition = Vector2.zero;
    private Camera cam = new Camera();

    void Start()
    {
        //upon starting, calculate the joystick's position in accordance to mapping of the world coordinates on the 2D screen.
        joystickPosition = RectTransformUtility.WorldToScreenPoint(cam, background.position);
    }

    //Event for when the joystick is dragged
    public override void OnDrag(PointerEventData eventData)
    {
        //calculate the direction in which the player is dragging the joystick ball towards
        Vector2 direction = eventData.position - joystickPosition;
        //displace the joystick by a distance determined by the resolution of the screen
        inputVector = (direction.magnitude > background.sizeDelta.x / 2f) ? direction.normalized : direction / (background.sizeDelta.x / 2f);
        ClampJoystick();
        handle.anchoredPosition = (inputVector * background.sizeDelta.x / 3f) * handleLimit;
    }

    //Event for when the joystick is pressed
    public override void OnPointerDown(PointerEventData eventData)
    {
        //when the player presses down on the joystick just run the OnDrag() event since they perform the same operation
        OnDrag(eventData);
    }

    //Event for when the joystick is no longer being pressed nor dragged
    public override void OnPointerUp(PointerEventData eventData)
    {
        //if the player is not touching the joystick then position it where it was originally
        inputVector = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;
    }
}
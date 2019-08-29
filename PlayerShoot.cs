using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour {

    [SerializeField]Shooter character;
    public Button button;

    void Start()
    {
        //listen to the button you have selected and whenever the onClick() event triggers, call ButtonClicked()
        button.onClick.AddListener(() => ButtonClicked(42));
    }

    void ButtonClicked(int buttonNo)
    {
        //fire whenever the button assigned to this script is clicked
        character.Fire();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour {

    public GameObject shopPanel;

    //Event used for triggering an event when another game object comes into contact or goes into the shop 
    private void OnTriggerEnter(Collider other)
    {
        //only open the shop panel if the collider is the player (aka dont open the panel for everyone if it is not themselves who come into contact with the shop
        if (other.gameObject.CompareTag("Player"))
        {
            OpenShop();
        }
    }

    private void OpenShop()
    {
        //this is just like the mesh renderer except for panels i.e. the panel is always there except the player can only see and interact with it if the character comes into contact with the shop
        shopPanel.SetActive(true);
    }

    public void CloseShop()
    {
        shopPanel.SetActive(false);
    }
}

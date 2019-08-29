using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseItem : MonoBehaviour
{

    private PlayerInventory playerInventory;
    private ItemDatabase database;
    public int slotIndex;

    // Use this for initialization
    void Start()
    {
        //obtain the player's inventory and the item database as soon as the game starts by checking for a game object with the right tag just like in ItemButton.cs
        playerInventory = GameObject.FindGameObjectWithTag("PlayerInventory").GetComponent<PlayerInventory>();
        //as of now, the game does not include any item effects so details on the item status information is not required thus the database does not need to be retrieved,
        //however, for future developments in the case we would like to implement something like adding the status of the items to the character, the database would be 
        //needed. The item in question would be retrieved in the onClick() function.
        //database = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();
    }

    public void OnClick()
    {
        //remove the item 
        playerInventory.RemoveItem(slotIndex);
    }
}

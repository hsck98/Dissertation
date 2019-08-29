using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour {

    private PlayerInventory playerInventory;
    private ItemDatabase database;
    public int itemID;
    public Text itemName;
    public Text itemCost;
    public Text itemDescription;

	// Use this for initialization
	void Start () {
        //obtain the player's inventory as soon as the game starts by checking for a game object with the tag 'PlayerInventory'
        playerInventory = GameObject.FindGameObjectWithTag("PlayerInventory").GetComponent<PlayerInventory>();
        //same process but for the item database
        database = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();
        SetButton();
    }
	
    //This function places the items in the item database on the shop buttons with the item's respective details 
    void SetButton()
    {
        //iterate through the item database and look for the item this button in the shop is supposed to sell
        //note that the button id has been kept the same as the item id that it is selling in order to be able to do a boolean check during the iteration of the item database
        for (int i = 0; i < database.items.Count; i++)
        {
            if (database.items[i].itemID == itemID)
            {
                string cost = database.items[i].itemCost.ToString();
                itemName.text = database.items[i].itemName;
                itemCost.text = cost;
                itemDescription.text = database.items[i].itemDescription;
            }
        }
    }

    public void OnClick()
    {
        //when the player clicks on this button, add the item it is supposed to be selling to the player's inventory
       playerInventory.AddItem(itemID);
    }
}

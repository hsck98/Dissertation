using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {

    public int numberSlots;
    public GUISkin skin;
    public List<Item> inventory = new List<Item>();
    public List<Item> slots = new List<Item>();
    private ItemDatabase database;

	// Use this for initialization
	private void Start ()
    {
        //iterates through the inventory and adds empty item objects to make them fill like the inventory is empty
        for (int i = 0; i < numberSlots; i++)
        {
            slots.Add(new Item());
            inventory.Add(new Item());
        }
        //retrieve the item database from the scene using the tag
        database = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();
    }

    private void OnGUI ()
    {
        GUI.skin = skin;
        DrawInventory();
	}

    //this is the current fixed size drawing of the inventory slots
    private void DrawInventory()
    {
        int i = 0;
        for (int x = 0; x < numberSlots; x++)
        {
            Rect slotRect = new Rect(288 + (x * 87.75f), 462, 70, 70);
            //Rect slotRect = new Rect(365 + (x * 112f), 582, 90, 90);
            //Rect slotRect = new Rect(315 + (x * 95.5f), 507, 70, 70);
            GUI.Box(slotRect, x.ToString(), skin.GetStyle("Slot"));
            //Rect resizedRect = ResizeGUI(slotRect);
            //GUI.Box(resizedRect, x.ToString(), skin.GetStyle("Slot"));
            slots[i] = inventory[i];

            if (slots[i].itemName != null)
            {
                GUI.DrawTexture(slotRect, slots[i].itemIcon);
            }

            i++;
        }
    }

    //this was a failed attempt at generating resizable inventory icons
    /*private Rect ResizeGUI(Rect rect)
    {
        Debug.Log("Resizing");
        float FilScreenWidth = rect.width / 1125;
        float rectWidth = FilScreenWidth * Screen.width;
        float FilScreenHeight = rect.height / 589;
        float rectHeight = FilScreenHeight * Screen.height;
        float rectX = (rect.x / 1237) * Screen.width;
        float rectY = (rect.y / 622) * Screen.height;

        return new Rect(rectX, rectY, rectWidth, rectHeight);
    }*/

    //this function adds the item to the inventory when an item is bought in itemButton.cs
    public void AddItem(int itemID)
    {
        //iterate through the inventory
        for (int i = 0; i < inventory.Count; i++)
        {
            //check if there is available space
            if(inventory[i].itemName == null)
            {
                //if there is space, iterate through the items database
                for (int j = 0; j < database.items.Count; j++)
                {
                    //once the item purchased is found in the database, add the item to the inventory slot that was empty
                    if (database.items[j].itemID == itemID)
                    {
                        inventory[i] = database.items[j];
                    }
                }
                break;
            }
        }
    }

    //this function removes an item from the inventory
    public void RemoveItem(int slotIndex)
    {
        //first checks that the slot that player wants to use it not emtpy already
        if (inventory[slotIndex].itemName != null)
        {
            //then instead of removing the item, just assign the slot to an empty item
            inventory[slotIndex] = new Item();
        }
    }
}

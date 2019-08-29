using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour {

    public List<Item> items = new List<Item>();

    private void Start()
    {
        //just add the items you want but remember to keep the same format as the item object created in the file item.cs
        items.Add(new Item("Cloak", 0, 50, "A cloak", 0, 5, 0, 5));
        items.Add(new Item("Duty", 1, 100, "A duty armor", 0, 5, 20, 0));
        items.Add(new Item("Ancient Staff", 2, 100, "An ancient staff from the ruins", 5, 0, 0, 20));
        items.Add(new Item("Axe", 3, 100, "A one-handed axe crafted by dwarfs", 10, 0, 0, 0));
        items.Add(new Item("Chainvest", 4, 75, "A chainvest to protect from blades", 0, 10, 20, 0));
        items.Add(new Item("Chestplate", 5, 150, "Prepared for battle", 5, 30, 0, 0));
        items.Add(new Item("Crimson Armor", 6, 200, "The highest knight class armor", 20, 30, 20, 0));
        items.Add(new Item("Dagger", 7, 25, "Small but deadly", 5, 0, 0, 0));
        items.Add(new Item("Demonic Armor", 8, 250, "Found in the Nether", 20, 20, 0, 30));
        items.Add(new Item("DoubleHanded Axe", 9, 150, "Swing swing to win win", 40, -5, 0, 0));
        items.Add(new Item("Flail", 10, 150, "Wing your weapon and deal huge damage", 30, 0, 0, 10));
        items.Add(new Item("Hatchet", 11, 50, "A quick buy", 10, 0, 0, 0));
        items.Add(new Item("Iron Chestplate", 12, 100, "Crafted with the finest iron", 0, 10, 10, 0));
        items.Add(new Item("Iron Hammer", 13, 100, "Simple but effective", 10, 0, 10, 0));
        items.Add(new Item("Knight Sword", 14, 200, "Enforce justice with this sword", 30, 0, 0, 20));
        items.Add(new Item("Knight Armor", 15, 200, "No wonder would dare attack a knight!", 0, 40, 0, 20));
        items.Add(new Item("Light Armor", 16, 75, "Be agile in the battlefield", 5, 10, 0, 0));
        items.Add(new Item("Longsword", 17, 125, "Classic sword", 20, 0, 0, 0));
        items.Add(new Item("Metallic Stick", 18, 100, "What the barbarians used", 20, 0, 0, -5));
        items.Add(new Item("Mystic Staff", 19, 200, "A staff made by Mother Nature", 30, 0, -10, 30));
        items.Add(new Item("Persuader", 20, 50, "Old but effective", 10, -5, -5, 0));
        items.Add(new Item("Robe", 21, 100, "What the wizards would use", 0, 5, 0, 20));
        items.Add(new Item("Scepter", 22, 175, "Paladins love this weapon!", 15, 0, 5, 10));
        items.Add(new Item("Silver Armor", 23, 125, "Shiny and light", 0, 10, 0, 30));
        items.Add(new Item("Sledgehammer", 24, 125, "Brute force", 30, -10, -5, -10));
        items.Add(new Item("Sleeveless Armor", 25, 75, "Feeling hot?", 0, 5, 5, 0));
        items.Add(new Item("Spiked Mace", 26, 125, "The spikes are not decoration", 25, -10, 0, 0));
        items.Add(new Item("Steel Hammer", 27, 150, "An improvement of previous hammers", 15, 0, 15, 0));
        items.Add(new Item("Sword", 28, 75, "Simple sword", 15, 0, 0, 0));
        items.Add(new Item("Heavy Armor", 29, 150, "Become a tank", -20, 30, 30, -5));
        items.Add(new Item("Weak Armor", 30, 50, "Any armor is better than none", 0, 10, 0, -5));
        items.Add(new Item("Wooden Bat", 31, 25, "Just a stick", 5, 0, 0, 0));
    }
}

































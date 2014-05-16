using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeAndTravel
{
    public class InteractionManagerExtented : InteractionManager
    {
        protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {
            switch (itemTypeString)
            {
                case "armor":
                    item = new Armor(itemNameString, itemLocation);
                    break;
                case "weapon":
                    item = new Weapon(itemNameString, itemLocation);
                    break;
                case "wood":
                    item = new WoodItem(itemNameString, itemLocation);
                    break;
                default:
                    break;
            }
            return item;
        }

        protected override Location CreateLocation(string locationTypeString, string locationName)
        {
            Location location = null;
            switch (locationTypeString)
            {
                case "town":
                    location = new Town(locationName);
                    break;
                case "mine":
                    location = new Mine(locationName);
                    break;
                case "forest":
                    location = new Forest(locationName);
                    break;
                default:
                    break;
            }
            return location;
        }


        /*
        protected virtual void HandlePersonCommand(string[] commandWords, Person actor)
        {
            List<Item> allItems = actor.ListInventory();
            switch (commandWords[1])
            {
                case "gather":

                    if (actor.Location.LocationType == LocationType.Mine)
                    {
                        foreach (var item in allItems)
                        {
                            if (item.ItemType == (actor.Location as Mine).RequiredItem)
                            {
                                actor.AddToInventory(((actor.Location as Mine).ProduceItem(commandWords[2])));
                                break;
                            }
                        }
                    }
                    else if (actor.Location.LocationType == LocationType.Forest)
                    {
                        foreach (var item in allItems)
                        {
                            if (item.ItemType == (actor.Location as Forest).RequiredItem)
                            {
                                actor.AddToInventory(((actor.Location as Forest).ProduceItem(commandWords[2])));
                                break;
                            }
                        }
                    }
                    break;

                case "craft":
                    if (commandWords[2].Equals("weapon"))
                    {
                        var requaredItemTypes = Weapon.GetComposingItems();
                        
                        if (CanCraft(requaredItemTypes, allItems))
                        {
                            actor.AddToInventory(new Weapon(commandWords[3]));
                            foreach (var item in requaredItemTypes)
                            {
                                actor.RemoveFromInventory(item);
                            }
                        }
                    }
                    else if (commandWords[2].Equals("armor"))
                    {
                        foreach (var item in allItems)
                        {
                            if (item.ItemType == ItemType.Iron)
                            {
                                actor.AddToInventory(new Armor(commandWords[3]));
                                actor.RemoveFromInventory(item);
                                break;
                            }
                        }

                    }
                    break;
                    
                default:
                    break;
            }
        }
        */
        private bool CanCraft(List<ItemType> requaredItemTypes, List<Item> allItems)
        {
            int wantedItems = requaredItemTypes.Count;
            foreach (var reqItemTypes in requaredItemTypes)
            {
                foreach (var invertoryItem in allItems)
                {
                    if (invertoryItem.ItemType == reqItemTypes)
                    {
                        wantedItems--;
                        break;
                    }
                }
            }
            if (wantedItems == 0)
            {
                return true;
            }
            return false;
        }

        protected override Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
            Person person = null;
            switch (personTypeString)
            {
                case "shopkeeper":
                    person = new Shopkeeper(personNameString, personLocation);
                    break;
                case "traveller":
                    person = new Traveller(personNameString, personLocation);
                    break;
                case "merchant":
                    person = new Merchant(personNameString, personLocation);
                    break;
                default:
                    break;
            }
            return person;
        }
    }
}

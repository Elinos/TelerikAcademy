using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeAndTravel
{
    public class ExtendedInteractionManager : InteractionManager
    {
        protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {
            switch (itemTypeString)
            {
                case "weapon":
                    item = new Weapon(itemNameString, itemLocation);
                    break;
                case "wood":
                    item = new Wood(itemNameString, itemLocation);
                    break;
                case "iron":
                    item = new Iron(itemNameString, itemLocation);
                    break;
                default:
                    item = base.CreateItem(itemTypeString, itemNameString, itemLocation, item);
                    break;
            }
            return item;
        }

        protected override Location CreateLocation(string locationTypeString, string locationName)
        {
            Location location = null;
            switch (locationTypeString)
            {
                case "mine":
                    location = new Mine(locationName);
                    break;
                case "forest":
                    location = new Forest(locationName);
                    break;
                default:
                    location = base.CreateLocation(locationTypeString, locationName);
                    break;
            }
            return location;
        }

        protected override void HandlePersonCommand(string[] commandWords, Person actor)
        {
            switch (commandWords[1])
            {

                case "gather":
                    HandleGatherInteraction(actor, commandWords[2]);
                    break;
                case "craft":
                    HandleCraftInteraction(actor, commandWords[2], commandWords[3]);
                    break;
                default:
                    base.HandlePersonCommand(commandWords, actor);
                    break;
            }
        }

        private void HandleCraftInteraction(Person actor, string itemType, string itemName)
        {
            if (actor.ListInventory().Count > 0)
            {
                if (itemType == "weapon" && actor.ListInventory().Any(x => x.ItemType == ItemType.Iron) && actor.ListInventory().Any(x => x.ItemType == ItemType.Wood))
                {
                    var weapon = new Weapon(itemName);
                    AddToPerson(actor, weapon);
                }
                else if (itemType == "armor" && actor.ListInventory().Any(x => x.ItemType == ItemType.Iron))
                {
                    var armor = new Armor(itemName);
                    AddToPerson(actor, armor);
                }

            }
        }

        private void HandleGatherInteraction(Person actor, string itemName)
        {
            if (actor.Location.LocationType == LocationType.Forest && actor.ListInventory().Any(x => x.ItemType == ItemType.Weapon))
            {
                var wood = new Wood(itemName);
                AddToPerson(actor, wood);
            }
            else if (actor.Location.LocationType == LocationType.Mine && actor.ListInventory().Any(x => x.ItemType == ItemType.Armor))
            {
                var iron = new Iron(itemName);
                AddToPerson(actor, iron);
            }
        }

        protected override Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
            Person person = null;
            switch (personTypeString)
            {
                case "merchant":
                    person = new Merchant(personNameString, personLocation);
                    break;
                default:
                    person = base.CreatePerson(personTypeString, personNameString, personLocation);
                    break;
            }
            return person;
        }
    }
}

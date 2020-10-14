using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Item
{
    public abstract class BaseItem
    {





    }


    public interface Weapon
    {
        float BaseDamage { get; }
        float BaseArmorPierce { get; }
        
    }

    public interface consumables
    {

    }

   public enum SlotOccupied
    {
        OneHand,TwoHand,Armor,Item

    }

}

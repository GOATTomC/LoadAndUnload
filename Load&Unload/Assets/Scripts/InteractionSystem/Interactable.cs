using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour {

    public PlayerOption playerOption;

    public enum PlayerOption
    {
        Pickup,
        Drag
    };

    public abstract void Equip(PlayerHand hand);

    public abstract void OnHoverEnter(PlayerHand hand);

    public abstract void OnHoverExit(PlayerHand hand);

    public abstract void Dequip(PlayerHand hand);


}

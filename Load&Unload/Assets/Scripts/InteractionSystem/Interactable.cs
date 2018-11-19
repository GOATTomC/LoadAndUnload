using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour {

    public abstract void Equip(PlayerHand hand);

    public abstract void Dequip(PlayerHand hand);


}

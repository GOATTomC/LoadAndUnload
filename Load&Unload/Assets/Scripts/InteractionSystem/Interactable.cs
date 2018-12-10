using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Interactable : MonoBehaviour {

    private Rigidbody m_myRigidbody;

    public Rigidbody GetRigidbody
    {
        get
        {
            return m_myRigidbody;
        }
    }

    protected virtual void Awake()
    {
        m_myRigidbody = GetComponent<Rigidbody>();
    }

    public abstract void Equip(PlayerHand hand);

    public abstract void OnHoverEnter(PlayerHand hand);

    public abstract void OnHoverExit(PlayerHand hand);

    public abstract void Dequip(PlayerHand hand);


}

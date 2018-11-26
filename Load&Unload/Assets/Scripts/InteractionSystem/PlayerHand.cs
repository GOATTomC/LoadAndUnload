using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour {


    [SerializeField] private Transform m_itemParent;

    [SerializeField] private float m_lerpToHandTime = 0.2f;


    private SteamVR_TrackedObject m_trackedObj;
    private SteamVR_Controller.Device m_controller
    {
        get { return SteamVR_Controller.Input((int)m_trackedObj.index); }
    }

    public Interactable ItemInHand
    {
        get
        {
            return m_itemInHand;
        }
    }

    private Interactable m_itemInHand;

    private Interactable m_lastHoverItem;

    private BoxCollider m_myCollider;

    void Awake()
    {
        m_trackedObj = GetComponent<SteamVR_TrackedObject>();
        m_myCollider = GetComponent<BoxCollider>();
    }


    private void Update()
    {
        if (m_controller.GetHairTriggerUp())
        {
            DequipInteractable();
        }
    }



    private void OnCollisionStay(Collision collision)
    {


        //check if we hit an interactable
        Interactable interactable = collision.transform.GetComponent<Interactable>();

        if (interactable)
        {
            if(interactable != m_lastHoverItem)
            {
                interactable.OnHoverEnter(this);
                if (m_lastHoverItem)
                {
                    m_lastHoverItem.OnHoverExit(this);
                }
            }


            //then equip item
            if (m_controller.GetHairTriggerDown())
            {

                EquipInteractable(interactable);
            }

            m_lastHoverItem = interactable;
        }
    


        }


    public void EquipInteractable(Interactable interactable)
    {
        if (m_itemInHand == null)
        {
            m_myCollider.enabled = false;
            interactable.Equip(this);
            m_itemInHand = interactable;

            if(interactable.playerOption == Interactable.PlayerOption.Pickup)
            {
                PutItemInHand(interactable);
            }
            Debug.Log("Equiping Item");
        }
    }


    public void DequipInteractable()
    {
        if (m_itemInHand != null)
        {
            m_myCollider.enabled = true;
            m_itemInHand.Dequip(this);

            //let go off interactable if you can pick it up
            if (m_itemInHand.playerOption == Interactable.PlayerOption.Pickup)
            {
                RemoveItemInHand();
            }
            m_itemInHand = null;
            Debug.Log("Dequiping Item");
        }
    }



    
    private void RemoveItemInHand()
    {
        if (m_itemInHand)
        {
            m_itemInHand.transform.parent = null;
        }
    }


    private void PutItemInHand(Interactable interactable)
    {
        interactable.transform.parent = m_itemParent;
     //   HelpClass.PositionLerp(interactable.transform, m_itemParent, m_lerpToHandTime);
       // HelpClass.RotationLerp(interactable.transform, m_itemParent, m_lerpToHandTime);
    }


}

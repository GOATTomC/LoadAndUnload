using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : Interactable
{

    [SerializeField] private Texture m_highlightTexture;
    private Texture m_standardTexture;

    private Rigidbody m_myRigidbody;
    [SerializeField] private MeshRenderer m_meshRenderer;


    private void Awake()
    {
        m_standardTexture = m_meshRenderer.material.mainTexture;
    }



    public override void Equip(PlayerHand hand)
    {
        m_myRigidbody = GetComponent<Rigidbody>();
        m_myRigidbody.isKinematic = true;

    }

    public override void OnHoverEnter(PlayerHand hand)
    {
        //set highlightcolor
        m_meshRenderer.material.mainTexture = m_highlightTexture;
    }

    public override void OnHoverExit(PlayerHand hand)
    {
        //set defaultcolor
        m_meshRenderer.material.mainTexture = m_standardTexture;
    }


    public override void Dequip(PlayerHand hand)
    {
        m_myRigidbody.isKinematic = false;
    }

}

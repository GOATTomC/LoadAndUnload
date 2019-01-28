using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : Interactable
{

    [SerializeField] private Texture m_highlightTexture;
    private Texture m_standardTexture;
    
    [SerializeField] private MeshRenderer m_meshRenderer;


    protected override void Awake()
    {
        base.Awake();
        m_standardTexture = m_meshRenderer.material.mainTexture;
    }



    public override void Equip(PlayerHand hand)
    {
       GetRigidbody.isKinematic = true;

    }

    public override void OnHoverEnter(PlayerHand hand)
    {
        //set highlightcolor
        if (m_highlightTexture)
        {
            m_meshRenderer.material.mainTexture = m_highlightTexture;
        }
    }

    public override void OnHoverExit(PlayerHand hand)
    {
        //set defaultcolor
            m_meshRenderer.material.mainTexture = m_standardTexture;
        
    }


    public override void Dequip(PlayerHand hand)
    {
        GetRigidbody.isKinematic = false;
    }

}

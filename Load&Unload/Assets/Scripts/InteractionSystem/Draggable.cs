using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable :Interactable {

    [SerializeField]private Axis useAxis;

    private PlayerHand m_handGrabbedBy;
    private Rigidbody m_myRigid;

    public override void Dequip(PlayerHand hand)
    {
        m_handGrabbedBy = null;   
    }

    public override void Equip(PlayerHand hand)
    {
        m_handGrabbedBy = hand;
    }

    private void Update()
    {
        if (m_handGrabbedBy)
        {
            Vector3 targetPos = m_handGrabbedBy.transform.position;

            Vector3 direction = (m_handGrabbedBy.transform.position - transform.position);
            direction.x = direction.x * (useAxis.X ? 1 : 0);
            direction.y = direction.y * (useAxis.Y ? 1 : 0);
            direction.z = direction.z * (useAxis.Z ? 1 : 0);

            m_myRigid.AddForceAtPosition(direction * 1000, m_handGrabbedBy.transform.position);
        }
    }

    public override void OnHoverEnter(PlayerHand hand)
    {

    }

    public override void OnHoverExit(PlayerHand hand)
    {
    
    }

    [System.Serializable]
    public class Axis
    {
        public bool X = true;
        public bool Y = true;
        public bool Z = true;
    }
}

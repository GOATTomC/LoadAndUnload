using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour {

    [SerializeField] private Transform m_playerCamera;

    private float m_fixedHeight = 13f;

    public Transform[] GetPoints
    {
        get
        {
            return m_points;
        }
    }
    [SerializeField] private Transform[] m_points;

	void Start () {
		
	}
	

	void Update () {
        transform.position = new Vector3(m_playerCamera.position.x, m_fixedHeight, m_playerCamera.position.z);
        Vector3 eulers = m_playerCamera.rotation.eulerAngles;
        eulers.x = 0;
        eulers.z = 0;

        transform.rotation = Quaternion.Euler(eulers);


	}

   



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mop : Pickup {

    [SerializeField] private float m_moppingSpeed = 0.01f;

    private bool m_insidePool;
    private Pool m_currentPool;

    [SerializeField]private float m_currentSpeed;
    private Vector3 m_lastPosition;

    private void OnTriggerEnter(Collider other)
    {
   
    Pool pool = other.transform.GetComponent<Pool>();
        if (pool)
        {
            m_currentPool = pool;
            m_insidePool = true;
            m_lastPosition = transform.position;

        }


    }


    private void Update()
    {
        if (m_insidePool)
        {
            if (m_currentPool)
            {
                m_currentSpeed = (transform.position - m_lastPosition).magnitude / Time.deltaTime;
                m_lastPosition = transform.position;

                m_currentPool.Subtract(m_currentSpeed * m_moppingSpeed * Time.deltaTime);

            }
        }
    }
    private void OnTriggerExit(Collider other)
    {

        Pool pool = other.transform.GetComponent<Pool>();
        if (pool)
        {
            m_currentPool = null;
              m_insidePool = false;
        }

        }



}

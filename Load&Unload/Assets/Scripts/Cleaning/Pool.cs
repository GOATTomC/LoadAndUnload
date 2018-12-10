using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour {

    public event Action OnCleaningFinished;
    [SerializeField]private float m_size = 100;
    private float m_startSize;

    private Vector3 m_startScale;

    private void Start()
    {
        m_startSize = m_size;
        m_startScale = transform.localScale;
    }

    public void Subtract(float amount)
    {
        float multiplier = m_startSize / m_size;
        m_size -= amount * multiplier;
        transform.localScale = m_startScale * (m_size / m_startSize);
        if(m_size < 0)
        {
            m_size = 0;
            if (OnCleaningFinished != null)
            {
                OnCleaningFinished();
            }
            Destroy(gameObject);
        }
    }
}

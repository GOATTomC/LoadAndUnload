using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Task : MonoBehaviour {

    public event Action OnComplete;
    public Shelf shelfToFill;

	// Use this for initialization
	void Start () {
        shelfToFill.OnFull += OnShelfDone;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnShelfDone()
    {
        if (OnComplete != null)
        {
            OnComplete.Invoke();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Task : MonoBehaviour {

    public event Action OnComplete;
    public Shelf shelfToFill;
    public Pool poolToCLean;


	// Use this for initialization
	void Start () {
        if (shelfToFill != null)
            shelfToFill.OnFull += OnShelfDone;
        if (poolToCLean != null)
            poolToCLean.OnCleaningFinished += OnShelfDone;
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

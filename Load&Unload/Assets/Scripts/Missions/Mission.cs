using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Mission : MonoBehaviour {

    public event Action OnMissionDone;

    public List<Task> Tasks = new List<Task>();

    private int CompletedTasks = 0;

	// Use this for initialization
	void Start () {
		foreach(Task task in Tasks)
        {
            task.OnComplete += OnTaskDone;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTaskDone()
    {
        CompletedTasks++;

        if (CompletedTasks == Tasks.Count)
        {
            if (OnMissionDone != null)
            {
                OnMissionDone.Invoke();
            }
        }
    }
}

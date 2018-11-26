using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class MissionManager : MonoBehaviour {

    public List<Mission> AllMissions = new List<Mission>();
    public Queue<Mission> RemainingMissions = new Queue<Mission>();

    [SerializeField]
    private Transform m_TasksLayoutGroup;
    [SerializeField]
    private Text m_TaskTextPrefab;

	// Use this for initialization
	void Start () {
		foreach (Mission mission in AllMissions)
        {
            mission.OnMissionDone += OnMissionDone;
            RemainingMissions.Enqueue(mission);
        }

        Mission Currentmission = RemainingMissions.Peek();
        UpdateUI(Currentmission);
	}

    private void OnMissionDone()
    {
        RemainingMissions.Dequeue();
        Mission Currentmission = RemainingMissions.Peek();
        UpdateUI(Currentmission);
    }

    void UpdateUI(Mission mission)
    {

    }
}

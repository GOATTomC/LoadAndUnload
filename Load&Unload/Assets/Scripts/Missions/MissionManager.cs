using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class MissionManager : MonoBehaviour {

    [SerializeField]
    public List<Mission> AllMissions;
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
        Mission Currentmission = null;
        if (RemainingMissions.Count > 0)
        {
            RemainingMissions.Peek();
        }
        UpdateUI(Currentmission);
    }

    void UpdateUI(Mission mission)
    {
        foreach(Transform child in m_TasksLayoutGroup.transform)
        {
            Destroy(child.gameObject);
        }

        if (mission == null)
            return;

        foreach (Task task in mission.Tasks)
        {
            Text text = Instantiate<Text>(m_TaskTextPrefab, m_TasksLayoutGroup);
            if (task.shelfToFill != null)
                text.text = "Fill: " + task.shelfToFill.name;
            else
            {
                text.text = "Clean: " + task.poolToCLean.name;
            }
        }
    }
}

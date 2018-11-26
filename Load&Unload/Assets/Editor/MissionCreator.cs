using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MissionCreator : EditorWindow {

    private string m_MissionName;

    private MissionManager m_MissionManager;

    private bool m_DrawError = false;

    [MenuItem("Window/Mission Creator")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(MissionCreator));
    }

    private void OnGUI()
    {
        m_MissionName = EditorGUILayout.TextField("Mission name: ", m_MissionName);
        EditorGUILayout.LabelField("Select shelfs to fill and press create.");

        if (GUILayout.Button("Create"))
        {
            if (GetMissionManager())
            {
                m_DrawError = false;
                CreateTasks();
            }
            else
            {
                m_DrawError = true;
            }

        }

        if (m_DrawError)
        {
            EditorGUILayout.LabelField("ERROR: There is no MissionManager in the scene.");
        }
    }

    private bool GetMissionManager()
    {
        m_MissionManager = GameObject.FindObjectOfType<MissionManager>();

        if (m_MissionManager != null)
        {
            return true;
        }

        return false;
    }

    private void CreateTasks()
    {
        GameObject[] selectedObjects = Selection.gameObjects;
        List<Shelf> selectedShelfs = new List<Shelf>();
        
        for (int i = 0; i < selectedObjects.Length; i++)
        {
            Shelf shelf = selectedObjects[i].GetComponent<Shelf>();
            if (shelf != null)
            {
                selectedShelfs.Add(shelf);
            }
        }

        GameObject missionParent = GameObject.Find(m_MissionName);
        if (missionParent == null)
        {
            missionParent = new GameObject();
            missionParent.name = m_MissionName;
            missionParent.AddComponent<Mission>();
        }

        foreach(Shelf shelf in selectedShelfs)
        {
            //Create task
            GameObject task = new GameObject();
            task.name = "Task";
            task.transform.parent = missionParent.transform;
            task.AddComponent<Task>();
            task.GetComponent<Task>().shelfToFill = shelf;

            //Add task to mission
            missionParent.GetComponent<Mission>().Tasks.Add(task.GetComponent<Task>());
        }

        //Put mission into mission manager
        missionParent.transform.parent = m_MissionManager.transform;
        m_MissionManager.AllMissions.Add(missionParent.GetComponent<Mission>());
        m_MissionManager.RemainingMissions.Enqueue(missionParent.GetComponent<Mission>());
    }
}

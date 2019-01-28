using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float m_speed = 10;
    [SerializeField] private SteamVR_TrackedObject m_trackedObj;

    [SerializeField] private PlayerCollider m_playerCollider;

    private SteamVR_Controller.Device m_controller
    {
        get { return SteamVR_Controller.Input((int)m_trackedObj.index); }
    }

    private Vector2 m_touchPadInput;

    void Start()
    {

    }

    void Update()
    {
        if (m_controller.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
        {

            m_touchPadInput = m_controller.GetAxis(EVRButtonId.k_EButton_SteamVR_Touchpad);

            Vector3 movement;
            float forward = m_touchPadInput.y;
            float sideways = m_touchPadInput.x;


            movement = GetDirection(forward, sideways);



            transform.position += movement * m_speed * Time.deltaTime;
        }

    }

    private Vector3 GetDirection(float forward, float sideways)
    {

        Vector3 dir = new Vector2();
        dir += m_playerCollider.transform.forward * forward;
        dir += (m_playerCollider.transform.right * sideways);

        RaycastHit hit;
        Transform[] points = m_playerCollider.GetPoints;

        for (int i = 0; i < points.Length; i++)
        {
            if (forward > 0)
            {


                if (Physics.Raycast(points[i].position, points[i].forward, out hit, 0.2f))
                {
                    dir.z = 0;

                }
            }

            if (forward < 0)
            {

                if (Physics.Raycast(points[i].position, -points[i].forward, out hit, 0.2f))
                {
                    dir.z = 0;

                }
            }

            if (sideways > 0)
            {

                if (Physics.Raycast(points[i].position, points[i].right, out hit, 0.2f))
                {
                    dir.x = 0;

                }
            }

            if (sideways < 0)
            {

                if (Physics.Raycast(points[i].position, -points[i].right, out hit, 0.2f))
                {
                    dir.x = 0;
                }
            }
        }

        return dir;

    }

}

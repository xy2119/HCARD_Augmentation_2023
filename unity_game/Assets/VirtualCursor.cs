using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System;

// this code is not used.
public class VirtualCursor : MonoBehaviour
{
    public bool mouseClicked = false;

    private PlayerController playerController;
    [SerializeField] Vector3 v_MousePosition;
    [SerializeField] GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    [SerializeField] EventSystem m_EventSystem;
    //[SerializeField] RectTransform canvasRect;


    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();

        m_Raycaster = GetComponent<GraphicRaycaster>();

        m_EventSystem = GetComponent<EventSystem>();
    }
    void Update()
    {
        //Check if the left Mouse button is clicked
        if (mouseClicked)
        {
            //Set up the new Pointer Event
            m_PointerEventData = new PointerEventData(m_EventSystem);
            //Set the Pointer Event Position to that of the mouse position
            v_MousePosition = new Vector2(playerController.mouse_x, playerController.mouse_y);
            m_PointerEventData.position = v_MousePosition;

            //Create a list of Raycast Results
            List<RaycastResult> results = new List<RaycastResult>();

            //Raycast using the Graphics Raycaster and mouse click position
            m_Raycaster.Raycast(m_PointerEventData, results);

            Debug.Log(results[3].gameObject.name);

            //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
            //for (int i = 0; i < results.Count; i++)
            //{
            //    Debug.Log(i + ". Hit " + results[i].gameObject.name);
            //}
        }

        //if (mouseClicked == true) {
        //    //Create a list of Raycast Results

        //    List<RaycastResult> results = new List<RaycastResult>();
        //    //Set up the new Pointer Event
        //    m_PointerEventData = new PointerEventData(m_EventSystem);

        //    v_MousePosition = this.transform.position;
        //    //Set the Pointer Event Position to that of the game object
        //    m_PointerEventData.position = v_MousePosition;
        //    m_Raycaster.Raycast(m_PointerEventData, results);

        //    if (results.Count > 0) Debug.Log("Hit " + results[0].gameObject.name);
        //}
        //Raycast using the Graphics Raycaster and mouse click position


    }

}
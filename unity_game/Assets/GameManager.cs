using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// this code is not working with virtual cursor.
public class GameManager : MonoBehaviour
{
    public GameObject _DrawingContainer;
    public RectTransform gameCursor;
    public Vector3 rectPos;
    public Button myButton;
    public bool isButtonPressed;

    public int FSR_Value = 0;
    public Vector3 map = Vector3.zero;
    public Vector2 projection;

    void Start()
    {
        gameCursor = GameObject.Find("GameCursor").GetComponent<RectTransform>();
        myButton= GetComponent<Button>();
        rectPos = gameCursor.anchoredPosition;
        map = new Vector2(293,1040);
    }

    // Update is called once per frame
    void Update()
    {
        // update the virtual cursor position
        
        projection = map + new Vector3(rectPos.x,0,0) - new Vector3(0,rectPos.y,0); // vector mapping
        //SimulateLeftClick.SetCursorPos((int)projection.x, (int)projection.y); // only works with integer

        // detect button
        if (isButtonPressed)
        {
            onButtonPressed();
            //isButtonPressed = false;
        }
    }

    private void onButtonPressed()
    {
        //myButton = detectButtonBelow(rectPos);

        // if yes, grab the button and invoke OnClick event
        // Button myButton = <buttonDetected>
        // myButton.Select() // this will focus a button but do not 'click'
        int x = (int) rectPos.x;
        int y = (int)rectPos.y;
        // SimulateLeftClick.SetCursorPos(x, y);
        // MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown | MouseOperations.MouseEventFlags.LeftUp);
        print("arduino button sending press comamand! we did it!");
    }

    //private Button detectButtonBelow(Vector3 rectPos)
    //{
    //    // raycast to check if there is a button at rectPos
    //    //
    //    // UnityEngine.UI.Button detectedButton = new Button();
    //    // return detectedButton;
    //}
}

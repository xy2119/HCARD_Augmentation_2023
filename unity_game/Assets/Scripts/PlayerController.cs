using extOSC;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(OSCReceiver))]
public class PlayerController : MonoBehaviour
{

    // this is the virtual mouse
    public Vector3 targetPosition;
    public int playerSpeed;
    public bool isButtonPressed;
    public bool virtualMouseDown;
    public bool virtualMouseUp;

    public CustomInputModule customInputModule;
    public KeyCode simulateClickKey = KeyCode.Space;
    public KeyCode simulateMouseDownKey = KeyCode.H;
    

    /// <summary>
    /// OSC receiver, listening for mouse position, and button state
    /// </summary>
    public string address_1;
    public string address_2;
    public string address_3;

    [SerializeField] public float mouse_x;
    [SerializeField] public float mouse_y;
    public RectTransform player;
    [SerializeField] private OSCReceiver receiver;


    void Start()
    {
        player = GetComponent<RectTransform>();

        isButtonPressed = false;
        virtualMouseDown = false;


        address_1 = "/mouse/position";
        address_2 = "/gripper/button/state"; // true/false
        // get the receiver
        receiver = GetComponent<OSCReceiver>();
        receiver.Bind(address_1, PositionMessageReceived);
        receiver.Bind(address_2, InputMessageReceived);
    }

    // Update is called once per frame
    void Update()
    {
        //targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(mouse_x, mouse_y, 0));
        targetPosition = new Vector3(mouse_x, mouse_y, 0);
        player.position = Vector3.MoveTowards(player.position, targetPosition, playerSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.M)) // simulate virtualMousePressedDown only
        {
            virtualMouseUp = false;
            customInputModule.simulateMouseDown = true;
        }

        if (isButtonPressed == true)
        {
            customInputModule.simulateMouseDown = true;
            virtualMouseDown = true;
            virtualMouseUp = false;
            ///isButtonPressed = false; // turn it off
        }
        ////////////////////////////////////////////
        if (isButtonPressed == false && virtualMouseDown == true) // stop holding
        {
            virtualMouseDown = false;
            virtualMouseUp = true;
            customInputModule.simulateMouseClick = true;
        }
        ////////////////////////////////////////////
    }

    void PositionMessageReceived(OSCMessage message)
    {
        // expecting an array of 2 element (mouse_x,mouse_y), 2 integers
        //Debug.Log(message.Values); // note that received python array is not OSCArray: [extOSC.OSCValue]
        if (message.Values != null) // Get all values from first array in message.
        {
            mouse_x = message.Values[0].FloatValue;
            mouse_y = message.Values[1].FloatValue;
            Debug.Log("X: "+mouse_x +"Y: " + mouse_y);
        }
        else
        {
            Debug.Log("Message type error. Array required.");
        }
    }

    void InputMessageReceived(OSCMessage message)
    {

        if (message.ToString(out var value))
        {
            Debug.Log(value);
            if (value == "0")
            {
                isButtonPressed = false;
            }
            if (value == "1")
            {
                isButtonPressed = true;
            }

        }
        else
        {
            Debug.Log("Message type error. String required.");
        }
    }
}

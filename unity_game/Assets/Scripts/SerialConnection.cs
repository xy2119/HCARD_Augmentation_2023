using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO.Ports;
using System.IO;

public class SerialConnection : MonoBehaviour
{
    public GameManager gameManager;
    private SerialPort port;
    public string receivedData;
    public bool ArduinoButtonDown;
    public string[] datas;

    private const int BAUD_RATE = 9600;

    public int readTimeOutTime = 50;

    private void OnEnable()
    {
        port = new SerialPort("COM6", 9600);
        if (!port.IsOpen)
        {
            //print("Opening " + the_com + ", baud 9600");
            port.Open();
            //port.Handshake = Handshake.None;
            //port.DtrEnable = true;
            //port.RtsEnable= true;
            if (port.IsOpen) { Debug.Log("opening port on Awark"); }

            port.ReadTimeout = readTimeOutTime;
        }
    }

    private void OnDisable()
    {
        port.Close();
    }
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        if (!port.IsOpen)
        {
            //print("Opening " + the_com + ", baud 9600");
            port.Open();
            port.ReadTimeout = readTimeOutTime;
            Debug.Log("opening port on start");
        }


    }
    private void Update()
    {
        //if (port != null)
        //{
        //    receivedString = port.ReadLine();

        //    string[] datas = receivedString.Split(',');
        //    bool isParsable = Int32.TryParse(datas[0], out int number);
        //    gameManager.FSR_Value = number;
        //}

        if (port.IsOpen)
        {
            try
            {
                receivedData = port.ReadLine();
                Debug.Log(receivedData);
                if (receivedData == "0")
                {
                    print("Button Down");
                    ArduinoButtonDown = false;
                }
                if (receivedData == "1")
                {
                    print("Button Up");
                    ArduinoButtonDown = true;
                }
            }
            catch (Exception)
            {
                //
            }
            
                
                // gameObject.FSRValue = TryParse(receivedData);
  

            //if (!string.IsNullOrEmpty(FSRdata)) // if there is data
            //{

            //    print(FSRdata);
                //string[] datas = receivedString.Split(',');
                //bool isParsable = Int32.TryParse(datas[0], out int number);
                //gameManager.FSR_Value = number;
                //char command = data.ToCharArray()[data.Length - 1]; // read the last string
                //bool pressed = (command == '1'); // reading from serial port is string
                //gameManager.isButtonPressed = pressed; // update gameManager state
                //print("Button pressed from serial port");
            //}
        }
    }

    //private void OnGUI()
    //{
    //    if(port== null)
    //    {
    //        foreach(string portName in SerialPort.GetPortNames())
    //        {
    //            if(GUILayout.Button(portName))
    //            {
    //                port = new SerialPort(portName, BAUD_RATE);
    //                port.Open();
    //                print("Opening " + portName + "with baud" + BAUD_RATE);
    //                port.ReadTimeout = 20; // pause for 20 ms
    //            }
    //        }
    //    }
    //}
    private void OnApplicationQuit()
    {
        port?.Close(); // if not null then close
    }
}

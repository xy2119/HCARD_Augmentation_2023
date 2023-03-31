// code from: http://answers.unity.com/answers/400249/view.html
// doesn't work

using UnityEngine;
using System.IO.Ports;
using System;

public class ArduinoConnect : MonoBehaviour
{
    private SerialPort sp;
    [SerializeField]private String COM_Number;
    [SerializeField] private int BAUD_RATE;
    [SerializeField] private string reading;
    public bool ArduinoButtonPressed;

    // Use t$$anonymous$$s for initialization
    private void OnEnable()
    {
        COM_Number = "COM6";
        BAUD_RATE = 9600;
        sp = new SerialPort(COM_Number, BAUD_RATE);
        try
        {
            print("Opening port on Awake");
            sp.Open();
            sp.DataReceived += DataReceivedHandler;
            sp.ErrorReceived += DataErrorReceivedHandler;
        }
        catch (Exception e)
        {
            Debug.Log("Could not open serial port: " + e.Message);

        }
        ArduinoButtonPressed = false;

    }

    private void DataReceivedHandler(
                        object sender,
                        SerialDataReceivedEventArgs e)
    {
        SerialPort sp = (SerialPort)sender;
        string reading = sp.ReadLine();
        Debug.Log(reading);

    }
 
 
     private void DataErrorReceivedHandler(object sender,
                                           SerialErrorReceivedEventArgs e)
    {
        Debug.Log("Serial port error:" + e.EventType.ToString("G"));
    }

}
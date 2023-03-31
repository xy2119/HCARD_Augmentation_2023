using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class ButtonClickDetector : MonoBehaviour
{
    /// <summary>
    /// ButtonClick Detector can be attached to the canvas, or as a stand-alone game object
    /// </summary>
    public Button button1;
    public Button button2;
    public Button button3;

    public TextMeshProUGUI textbox1;
    public TextMeshProUGUI textbox2;
    public TextMeshProUGUI textbox3;

    void OnEnable()
    {
        //Register Button Events
        button1.onClick.AddListener(() => buttonCallBack(button1));
        button2.onClick.AddListener(() => buttonCallBack(button2));
        button3.onClick.AddListener(() => buttonCallBack(button3));
    }

    private void buttonCallBack(Button buttonPressed)
    {
        if (buttonPressed == button1)
        {
            //Your code for button 1. E.g. switch UI canvas
            DisplayMessage(textbox1);
            Debug.Log("Clicked: " + button1.name);
        }

        if (buttonPressed == button2)
        {
            //Your code for button 2
            DisplayMessage(textbox2);
            Debug.Log("Clicked: " + button2.name);
        }

        if (buttonPressed == button3)
        {
            //Your code for button 3
            DisplayMessage(textbox3);
            Debug.Log("Clicked: " + button3.name);
        }
    }

    public void DisplayMessage(TextMeshProUGUI textbox)
    {
        textbox.gameObject.SetActive(true);
    }

    void OnDisable()
    {
        //Un-Register Button Events
        button1.onClick.RemoveAllListeners();
        button2.onClick.RemoveAllListeners();
        button3.onClick.RemoveAllListeners();
    }
}
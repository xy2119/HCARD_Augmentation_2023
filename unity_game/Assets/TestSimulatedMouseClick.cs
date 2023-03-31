using UnityEngine;

public class TestSimulatedMouseClick : MonoBehaviour
{
    public CustomInputModule customInputModule;
    public KeyCode simulateClickKey = KeyCode.Space;

    void Update()
    {
        if (Input.GetKeyDown(simulateClickKey))
        {
            customInputModule.simulateMouseClick = true;
        }
    }
}
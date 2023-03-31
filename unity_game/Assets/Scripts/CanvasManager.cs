using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


// reference: EngiGame: https://youtu.be/vmKxLibGrMo
// repo: 

public enum CanvasType
{
    MainMenu,
    FreeDraw,
    ForceCalibration
}

public class CanvasManager : MonoBehaviour//Singleton<CanvasManager>
{

    public List<CanvasController> canvasControllerList;
    public CanvasController lastActiveCanvas;

    private void Awake()
    {
        canvasControllerList = GetComponentsInChildren<CanvasController>().ToList();
        canvasControllerList.ForEach(x => x.gameObject.SetActive(false));
        SwitchCanvas(CanvasType.MainMenu);
    }


    public void SwitchCanvas(CanvasType _type)
    {
        if (lastActiveCanvas != null)
        {
            lastActiveCanvas.gameObject.SetActive(false);
        }

        CanvasController desiredCanvas = canvasControllerList.Find(x => x.canvasType == _type);
        if (desiredCanvas != null)
        {
            desiredCanvas.gameObject.SetActive(true);
            lastActiveCanvas = desiredCanvas;
        }
        else { Debug.LogWarning("The desired canvas was not found!"); }
    }
}

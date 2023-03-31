using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

[RequireComponent(typeof(Button))]
public class CanvasSwitcher : MonoBehaviour
{
    public CanvasType desiredCanvasType;
    public CanvasManager canvasManager;
    public Button _Button;
    

    private void Awake()
    {
        canvasManager = FindObjectOfType<CanvasManager>();
    }
    private void Start()
    {
        _Button = GetComponent<Button>();
        _Button.onClick.AddListener(OnButtonClicked);

    }

    void OnButtonClicked()
    {
        canvasManager.SwitchCanvas(desiredCanvasType);
    }

}
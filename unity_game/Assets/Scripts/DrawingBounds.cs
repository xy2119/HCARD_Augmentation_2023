using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DrawingBounds : MonoBehaviour//, IPointerEnterHandler, IPointerExitHandler
{

    public RectTransform m_RectTransform;


    void Start()
    {
        //Fetch the RectTransform from the GameObject
        m_RectTransform = GetComponent<RectTransform>();

    }

    //public void OnPointerEnter(PointerEventData eventData)
    //{
    //    Debug.Log("Entered the Drawing bounds");

    //    FindObjectOfType<DrawingController>().inDrawingBounds = true;
    //}

    //public void OnPointerExit(PointerEventData eventData)
    //{
    //    Debug.Log("Left the Drawing bounds");

    //    FindObjectOfType<DrawingController>().inDrawingBounds = false;
    //    FindObjectOfType<DrawingController>().EndDraw();

    //}
}
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class onMouseHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{

    public RectTransform m_RectTransform;
    public Vector2 initPos;
    public Vector2 displacement = new(0, 0);
    public Vector3 rotationAngle = new(0, 0, 0);

    public bool onUIelement = true;
    public bool isSelected = false;


    void Start()
    {
        //Fetch the RectTransform from the GameObject
        m_RectTransform = GetComponent<RectTransform>();
        initPos = m_RectTransform.anchoredPosition;

    }
    #region Pointer Events
    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("Entered the Paint Palettee");
        m_RectTransform.anchoredPosition += displacement;
        //m_RectTransform.Rotate(rotationAngle);
        onUIelement = true;
        FindObjectOfType<DrawingController>().EndDraw();

    }

    public void OnPointerExit(PointerEventData eventData)
    {

        Debug.Log("left Paint Palettee");
        m_RectTransform.anchoredPosition = initPos;
        //m_RectTransform.Rotate(-rotationAngle);
        onUIelement = false;

    }

    public void OnSelect(BaseEventData eventData)
    {
        //Debug.Log(this.gameObject.name + " was selected");
        m_RectTransform.anchoredPosition += new Vector2(0, -10f);
        isSelected = true;
        // set the cursor to the current selected object icon
    }

    public void OnDeselect(BaseEventData eventData)
    {
        //Debug.Log("deselected the palettee");
        m_RectTransform.anchoredPosition = initPos;
        isSelected = false;

    }
    #endregion
}
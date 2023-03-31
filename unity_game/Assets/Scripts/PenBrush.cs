using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Renderer))]
public class PenBrush : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{

    public RectTransform m_RectTransform;
    public Vector2 initPos;
    public Vector3 displacement = new Vector3(0, -60f, 0);
    public DrawingController _drawingController;
    [SerializeField] private GameObject brushType;
      
    
    private bool isSelected = false;

    private void Awake()
    {
        _drawingController = FindObjectOfType<DrawingController>();
    }
    void Start()
    {

        //Fetch the RectTransform from the GameObject
        m_RectTransform = GetComponent<RectTransform>();

        initPos = m_RectTransform.position;

        
    }
    private void Update()
    {
    }

    #region PointerEvents
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isSelected)
        {
            //Debug.Log("Entered the" + this.transform.name);
            m_RectTransform.position += displacement;

            FindObjectOfType<DrawingController>().EndDraw();
        }

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("left the" + this.transform.name);
        if (!isSelected)
        {
            // Transform return to initial position
            m_RectTransform.position = initPos;
        }

    }

    public void OnSelect(BaseEventData eventData)
    {
        //Debug.Log(this.gameObject.name + " was selected");
        m_RectTransform.position += displacement;
        isSelected = true;
        // set the cursor to the current selected object icon
        // update the selectedItem for lineManager
        FindObjectOfType<DrawingController>().linePrefab = brushType;
        FindObjectOfType<DrawingController>().isDrawing = true;
    }

    public void OnDeselect(BaseEventData eventData)
    {
        //Debug.Log(this.gameObject.name + " was Deselected");
        m_RectTransform.position = initPos;
        isSelected = false;

    }
    #endregion
}

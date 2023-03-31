using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DrawingController : MonoBehaviour
{
    #region public
    public PlayerController m_VirtualMouse;
    public GameObject linePrefab;
    public Transform drawnPicture;
    public DrawingBounds m_Bounds;
    public bool isDrawing;
    public bool inDrawingBounds;
    public Vector2 m_Mouse;

    #endregion

    #region private

    private Coroutine drawing;
    private Coroutine erasing;

    [SerializeField] private bool isErasing;
    [SerializeField] private Vector3 virtualMouseWorldPosition;

    private int sortOrder = 0;

    #endregion
    private void Start()
    {
        inDrawingBounds = true; // remember to change it back if everything else works
        isDrawing = false;
        m_Bounds = FindObjectOfType<DrawingBounds>();
        m_VirtualMouse = FindObjectOfType<PlayerController>();

    }

    void Update()
    {
        m_Mouse = m_VirtualMouse.player.position;
        inDrawingBounds = CheckBounds(m_Mouse); 
        //inDrawingBounds = IsPointerOverUIObject();
        if (inDrawingBounds)
        {
            //if (isDrawing)
            //{
            if (m_VirtualMouse.virtualMouseDown && !isDrawing)
            {
                StartDraw();
            }
            if (!inDrawingBounds || m_VirtualMouse.virtualMouseUp)
            {
                EndDraw();
            }
            //}
        }
        else
        {
            EndDraw();
            //EndErase();
        }

    }

    //public static bool IsPointerOverUIObject()
    //{
    //    PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
    //    eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    //    List<RaycastResult> results = new List<RaycastResult>();
    //    EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
    //    foreach (RaycastResult r in results)
    //        if (r.gameObject.CompareTag("Bounds"))
    //            return true;

    //    return false;
    //}

    private bool CheckBounds(Vector2 mousePosition)
    {

        RectTransform boundary = m_Bounds.m_RectTransform;
        Vector2 localMousePosition = boundary.InverseTransformPoint(mousePosition);
        //  Debug.Log(boundary.rect.Contains(localMousePosition));
        // if not on UI elements
        if (boundary.rect.Contains(localMousePosition))
        {
            return true;
        }
        return false;

    }
    #region drawing
    void StartDraw()
    {
        if (drawing != null) //the coroutine should not be empty
        {
            StopCoroutine(drawing);
        }

        drawing = StartCoroutine(Drawing());
        isDrawing = true;

    }
    IEnumerator Drawing()
    {

        isDrawing = true;
        GameObject lineObject = Instantiate(linePrefab, new Vector3(0, 0, 0), Quaternion.identity, drawnPicture);
        LineRenderer line = lineObject.GetComponent<LineRenderer>();
        //lineObject.transform.SetAsFirstSibling(); // new line object appear on top
        // used sorting layer in the end, increment sortOrder by 1
        line.sortingLayerName = "Top";
        line.sortingOrder = sortOrder;
        sortOrder += 1; // later lines will be rendered on top of older ones
        line.material = new Material(Shader.Find("Sprites/Default"));
        line.positionCount = 0;

        line.startColor = ColorPicker.m_SelectedColor;
        line.endColor = ColorPicker.m_SelectedColor;

        while (isDrawing)
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3 (m_Mouse.x, m_Mouse.y, 0));
            position.z = 10;
            line.positionCount++;

            // check distance, if greater than 0.05f, then set the position
            line.SetPosition(line.positionCount - 1, position);

            virtualMouseWorldPosition = position;
            yield return null;
        }
    }

    public void EndDraw()
    {
        if (drawing != null)
        {
            StopCoroutine(drawing);
        }

        isDrawing = false;
    }
    #endregion

    #region erase / clear

    // not used?
    void StartErase()
    {
        if (erasing != null)
        {
            StopCoroutine(erasing);
        }
        erasing = StartCoroutine(Erasing());

    }
    void EndErase()
    {
        if (drawing != null)
        {
            StopCoroutine(drawing);
        }

        isErasing = false;
    }



    IEnumerator Erasing()
    {
        isErasing = true;

        while (isErasing)
        {
            yield return null;
        }
    }
    #endregion
    //#region event handler
    //public void OnPointerEnter(PointerEventData eventData)
    //{
    //    Debug.Log("On UI Element");
    //    EndDraw();
    //    isDrawing = false;
    //}

    //public void OnPointerExit(PointerEventData eventData)
    //{
    //    if (enableDrawingToggle == true)
    //    {
    //        Debug.Log("You can draw now");
    //        isDrawing = true;
    //    }
    //}
    //#endregion
}
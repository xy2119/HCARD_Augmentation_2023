using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class LineManager : MonoBehaviour
{
    #region public

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

    private int sortOrder=0;

    #endregion
    private void Start()
    {
        inDrawingBounds = false;
        isDrawing = false;
        m_Bounds = FindObjectOfType<DrawingBounds>();
    }

    void Update()
    {
        //m_Mouse = Input.mousePosition;
        //inDrawingBounds = CheckBounds(m_Mouse); 
        inDrawingBounds = IsPointerOverUIObject();
        if (inDrawingBounds)
        {
            //if (isDrawing)
            //{
                if (Input.GetMouseButtonDown(0))
                {
                    StartDraw();
                }
                else if (!inDrawingBounds || Input.GetMouseButtonUp(0))
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

    public static bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        foreach (RaycastResult r in results)
            if (r.gameObject.CompareTag("Bounds"))
                return true;

        return false;
    }

    private bool CheckBounds(Vector2 mousePosition)
    {

        RectTransform boundary = m_Bounds.m_RectTransform;
        Vector2 localMousePosition = boundary.InverseTransformPoint(mousePosition);
        Debug.Log(boundary.rect.Contains(localMousePosition));
        return boundary.rect.Contains(localMousePosition);
        

    }
    #region drawing
    void StartDraw()
    {
        if (drawing != null) //why?
        {
            StopCoroutine(drawing);
        }

        drawing = StartCoroutine(Drawing());

    }
    IEnumerator Drawing()
    {

        isDrawing = true;
        GameObject lineObject = Instantiate(linePrefab, new Vector3(0, 0, 0), Quaternion.identity, drawnPicture);
        //lineObject.transform.SetAsFirstSibling(); // new line object appear on top
        LineRenderer line = lineObject.GetComponent<LineRenderer>();
        line.sortingLayerName = "Top";
        line.sortingOrder = sortOrder;
        sortOrder += 1; // later lines will be rendered on top of older ones
        line.material = new Material(Shader.Find("Sprites/Default"));
        line.positionCount = 0;

        while (isDrawing)
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0;
            line.positionCount++;
            line.SetPosition(line.positionCount - 1, position);
            yield return null;
        }
    }

    public void EndDraw()
    {
        if (drawing != null)
        {
            StopCoroutine(drawing);
        }

        //isDrawing = false;
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
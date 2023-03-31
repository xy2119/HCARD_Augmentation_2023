using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearDrawing : MonoBehaviour
{
    public Transform drawingContainer;

    private void Start()
    {
        drawingContainer = GetComponent<Transform>();
    }
    // button event
    public void OnClearButtonClicked()
    {
        while (transform.childCount > 0)
        {
            Debug.Log(transform.GetChild(0).name);
            DestroyImmediate(transform.GetChild(0).gameObject);
        }
    }

}

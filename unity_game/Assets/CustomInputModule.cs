using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class CustomInputModule : StandaloneInputModule
{
// this is attached to the EventSystem
    public bool simulateMouseClick = false;
    public bool simulateMouseDown = false;
    public bool isHoveringOverButton = false;

    public Image cursorSpriteImage;
    public Sprite defaultCursorSprite;
    public Sprite hoverCursorSprite;

    public PlayerController playerController;
    private GameObject lastHoveredButton = null;

    protected override void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }
    public override void Process()
    {
        isHoveringOverButton = ProcessSimulatedMouseHover();

        if (simulateMouseDown)
        {
            ProcessSimulatedMouseDown();
        }
        else if (simulateMouseClick)
        {
            ProcessSimulatedMouseClick();
        }
        else
        {
            base.Process();
        }
    }

    private void ProcessSimulatedMouseClick()
    {
        PointerEventData eventData = new PointerEventData(eventSystem)
        {
            //position = Input.mousePosition,
            position = playerController.player.position,
            button = PointerEventData.InputButton.Left
        };

        List<RaycastResult> raycastResults = new List<RaycastResult>();
        eventSystem.RaycastAll(eventData, raycastResults);

        GameObject target = null;
        foreach (RaycastResult result in raycastResults)
        {
            if (result.gameObject.GetComponent<Button>() != null) // check the first button
            {
                target = result.gameObject;
                //Debug.Log(result.gameObject.name);
                break;
            }
        }

        if (target != null)
        {
            ExecuteEvents.ExecuteHierarchy(target, eventData, ExecuteEvents.pointerUpHandler);
            ExecuteEvents.ExecuteHierarchy(target, eventData, ExecuteEvents.pointerClickHandler);
        }

        simulateMouseClick = false;
    }

    private void ProcessSimulatedMouseDown()
    {
        PointerEventData eventData = CreatePointerEventData();
        
        List<RaycastResult> raycastResults = new List<RaycastResult>();
        eventSystem.RaycastAll(eventData, raycastResults);
        GameObject target = null;
        foreach (RaycastResult result in raycastResults)
        {
            if (result.gameObject.GetComponent<Button>() != null) // check the first button
            {
                target = result.gameObject;
                //Debug.Log(result.gameObject.name);
                break;
            }
        }

        if (target != null)
        {
            ExecuteEvents.ExecuteHierarchy(target, eventData, ExecuteEvents.pointerDownHandler);
        }

        simulateMouseDown = false;
    }
    private PointerEventData CreatePointerEventData()
    {
        PointerEventData eventData = new PointerEventData(eventSystem)
        {
            position = playerController.player.position,
            button = PointerEventData.InputButton.Left
        };
        return eventData;
    }

    private bool ProcessSimulatedMouseHover()
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            position = playerController.player.position
        };

        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, raycastResults);
        GameObject target = null;

        foreach (RaycastResult result in raycastResults)
        {
            if (result.gameObject.GetComponent<Button>() != null)
            {
                target = result.gameObject;
                break;
            }
        }
        //
        if (target != null && target != lastHoveredButton)
        {
            if (lastHoveredButton != null)
            {
                ExecuteEvents.ExecuteHierarchy(lastHoveredButton, pointerData, ExecuteEvents.pointerExitHandler);
            }
            ExecuteEvents.ExecuteHierarchy(target, pointerData, ExecuteEvents.pointerEnterHandler);
            cursorSpriteImage.sprite = hoverCursorSprite;
            lastHoveredButton = target;
            return true;
        }
        else if (target == null && lastHoveredButton != null)
        {
            ExecuteEvents.ExecuteHierarchy(lastHoveredButton, pointerData, ExecuteEvents.pointerExitHandler);
            cursorSpriteImage.sprite = defaultCursorSprite;
            lastHoveredButton = null;
            return false;
        }
        return target != null;
        //if (target != null && target != lastHoveredButton)
        //{
        //    // bug not fixed yet...
        //    if (lastHoveredButton != null && !target.transform.IsChildOf(lastHoveredButton.transform) && !lastHoveredButton.transform.IsChildOf(target.transform))
        //    {
        //        ExecuteEvents.ExecuteHierarchy(lastHoveredButton, pointerData, ExecuteEvents.pointerExitHandler);
        //    }

        //    if (lastHoveredButton == null)
        //    {
        //        ExecuteEvents.ExecuteHierarchy(target, pointerData, ExecuteEvents.pointerEnterHandler);
        //    } 
        //    else if (!target.transform.IsChildOf(lastHoveredButton.transform))
        //    {
        //        ExecuteEvents.ExecuteHierarchy(target, pointerData, ExecuteEvents.pointerEnterHandler); // when do we want to execute?
        //    }
        //    lastHoveredButton = target;
        //    cursorSpriteImage.sprite = hoverCursorSprite;
        //    return true;

        //}
        //else if (target == null && lastHoveredButton != null)
        //{
        //    ExecuteEvents.ExecuteHierarchy(lastHoveredButton, pointerData, ExecuteEvents.pointerExitHandler);
        //    cursorSpriteImage.sprite = defaultCursorSprite;
        //    lastHoveredButton = null;
        //    return false;
        //}
        //return target != null;
    }
}


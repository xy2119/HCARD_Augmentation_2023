using UnityEngine;
using UnityEngine.EventSystems;

// code from https://stackoverflow.com/questions/69294323/how-to-simulate-touch-click-in-unity-with-script
public class MyVirtualCursor : StandaloneInputModule
{
    [SerializeField] private KeyCode left, right, up, down, click;
    [SerializeField] private RectTransform fakeCursor = null;

    private float moveSpeed = 5f;

    public void ClickAt(Vector2 pos, bool pressed)
    {
        Input.simulateMouseWithTouches = true;
        var pointerData = GetTouchPointerEventData(new Touch()
        {
            position = pos,
        }, out bool b, out bool bb);

        ProcessTouchPress(pointerData, pressed, !pressed);
    }

    void Update()
    {
        // instead of the specific input checks, you can use Input.GetAxis("Horizontal") and Input.GetAxis("Vertical")
        if (Input.GetKey(left))
        {
            fakeCursor.anchoredPosition += new Vector2(-1 * moveSpeed, 0f);
        }

        if (Input.GetKey(right))
        {
            fakeCursor.anchoredPosition += new Vector2(moveSpeed, 0f);
        }

        if (Input.GetKey(down))
        {
            fakeCursor.anchoredPosition += new Vector2(0f, -1 * moveSpeed);
        }

        if (Input.GetKey(up))
        {
            fakeCursor.anchoredPosition += new Vector2(0f, moveSpeed);
        }

        if (Input.GetKeyDown(click))
        {
            ClickAt(fakeCursor.position, true);
            print("click down");
        }

        if (Input.GetKeyUp(click))
        {
            ClickAt(fakeCursor.position, false);
            print("click up");
        }
    }
}
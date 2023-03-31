using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ColorPicker : MonoBehaviour
{
    public Button[] colorButtons;
    public PenBrush[] brushButtons;
    public Image selectedColor;
    public static Color m_SelectedColor { get; private set; } = Color.black;

    private void Start()
    {
        selectedColor = GetComponentInChildren<Image>();
        foreach (Button button in colorButtons)
        {
            button.onClick.AddListener(() => SelectCurrentColor(button.image.color));
        }
    }

    public void SelectCurrentColor(Color color)
    {
        m_SelectedColor = color;
        UpdateSelectedColor();
        UpdateBrushSprite();
    }

    private void UpdateSelectedColor()
    {
        selectedColor.color = m_SelectedColor;
    }

    private void UpdateBrushSprite()
    {
        foreach (PenBrush brush in brushButtons)
        {
            brush.GetComponentInChildren<Image>().color = m_SelectedColor;
        }
    }
}
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ScreenshotButton : MonoBehaviour
{
    public Button button;

    private void Start()
    {
        button.onClick.AddListener(TakeScreenshot);
    }

    private void TakeScreenshot()
    {
        StartCoroutine(CaptureScreenshot());
    }

    private IEnumerator CaptureScreenshot()
    {
        yield return new WaitForEndOfFrame();

        string screenshotPath = Application.dataPath + "/Screenshots/";
        if (!Directory.Exists(screenshotPath))
        {
            Directory.CreateDirectory(screenshotPath);
        }

        string fileName = "Screenshot_" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png";
        string fullPath = screenshotPath + fileName;

        ScreenCapture.CaptureScreenshot(fullPath);
        Debug.Log("Screenshot saved to: " + fullPath);
    }
}
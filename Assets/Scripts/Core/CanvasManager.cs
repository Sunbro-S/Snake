using UnityEngine;
using UnityEngine.EventSystems;

public abstract class CanvasManager: MonoBehaviour
{
    public Canvas ThisCanvas;
    public Canvas PreviusCanvas;
    public bool IsShown = false;
    public void ShowCanvas()
    {
            ThisCanvas.enabled = true;
            PreviusCanvas.enabled = false;
    }

    public void CloseCanvas()
    {
            ThisCanvas.enabled = false;
            PreviusCanvas.enabled = true;
    }
}

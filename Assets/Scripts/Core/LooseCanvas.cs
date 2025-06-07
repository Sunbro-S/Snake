using UnityEngine;

public class LooseCanvas : CanvasManager
{
    private void Start()
    {
        ThisCanvas.enabled = false;
    }
    private void Update()
    {

    }

    public void OnCanvas()
    {
        ShowCanvas();
    }
    public void OffCanvas()
    {
        CloseCanvas();
    }
}

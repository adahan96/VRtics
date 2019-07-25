using UnityEngine;

internal struct CanvasSpecifications
{
    private Vector2[] Size;
    private Vector3 MainCanvasPosition;
    public CanvasSpecifications(Vector2[] Size, Vector3 MainCanvasPosition)
    {
      
        this.Size = Size;
        this.MainCanvasPosition = MainCanvasPosition;

    }
}
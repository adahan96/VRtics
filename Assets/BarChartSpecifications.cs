using UnityEngine;

public struct BarChartSpecifications
{
    public string BarChartName { get; set; }
    public float BarSeperation { get; set; }
    public float BarSize { get; set; }
    public int ItemLabelsFontSize { get; set; }
    public int CategoryLabelsFontSize { get; set; }
    public int GroupLabelsFontSize { get; set; }
    public Vector2 Size { get; set; }
    public Vector3 Position { get; set; }
    public bool BarAnimation { get; set; }

    public BarChartSpecifications(Vector3 Position, Vector2 Size, string BarChartName, float BarSeperation, float BarSize, int ItemLabelsFontSize, int CategoryLabelsFontSize, int GroupLabelsFontSize, bool BarAnimation)
    {
        this.Position = Position;
        this.Size = Size;
        this.BarChartName = BarChartName;
        this.BarSeperation = BarSeperation;
        this.BarSize = BarSize;
        this.ItemLabelsFontSize = ItemLabelsFontSize;
        this.CategoryLabelsFontSize = CategoryLabelsFontSize;
        this.GroupLabelsFontSize = GroupLabelsFontSize;
        this.BarAnimation = BarAnimation;
    }

}
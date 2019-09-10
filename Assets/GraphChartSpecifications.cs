using ChartAndGraph;
using UnityEngine;

public struct GraphChartSpecifications
{
    public Vector2 Size { get; set; }
    public Vector3 Position { get; set; }
    public string GraphChartName { get; set; }
    public float VerticalAxisTextSeperation { get; set; }
    public int VerticalAxisFontSize { get; set; }
    public AxisFormat HorizontalAxisFormat { get; set; }
    public float HorizontalAxisTextSeperation { get; set; }
    public int HorizontalAxisFontSize { get; set; }
    public double LineThickness { get; set; }
    public double PointSize { get; set; }
    public string Parent { get; set; }
    public string Canvas { get; set; }

    public GraphChartSpecifications(Vector3 Position, Vector2 Size, string GraphChartName, float VerticalAxisTextSeperation, int VerticalAxisFontSize, AxisFormat HorizontalAxisFormat, float HorizontalAxisTextSeperation, int HorizontalAxisFontSize, double LineThickness, double PointSize, string Parent, string Canvas)
    {
        this.Position = Position;
        this.Size = Size;
        this.GraphChartName = GraphChartName;
        this.VerticalAxisTextSeperation = VerticalAxisTextSeperation;
        this.VerticalAxisFontSize = VerticalAxisFontSize;
        this.HorizontalAxisFormat = HorizontalAxisFormat;
        this.HorizontalAxisTextSeperation = HorizontalAxisTextSeperation;
        this.HorizontalAxisFontSize = HorizontalAxisFontSize;
        this.LineThickness = LineThickness;
        this.PointSize = PointSize;
        this.Parent = Parent;
        this.Canvas = Canvas;
    }
    public GraphChartSpecifications(Vector3 Position, Vector2 Size, string GraphChartName, float VerticalAxisTextSeperation, int VerticalAxisFontSize, AxisFormat HorizontalAxisFormat, float HorizontalAxisTextSeperation, int HorizontalAxisFontSize, double LineThickness, double PointSize, string Canvas)
    {
        this.Position = Position;
        this.Size = Size;
        this.GraphChartName = GraphChartName;
        this.VerticalAxisTextSeperation = VerticalAxisTextSeperation;
        this.VerticalAxisFontSize = VerticalAxisFontSize;
        this.HorizontalAxisFormat = HorizontalAxisFormat;
        this.HorizontalAxisTextSeperation = HorizontalAxisTextSeperation;
        this.HorizontalAxisFontSize = HorizontalAxisFontSize;
        this.LineThickness = LineThickness;
        this.PointSize = PointSize;
        this.Parent = null;
        this.Canvas = Canvas;
    }

}
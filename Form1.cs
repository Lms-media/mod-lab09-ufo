using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using ScottPlot;

namespace MovingStraightAhead;

public partial class Form1 : Form {
  private Point point1 = new Point(100, 100);
  private Point point2 = new Point(1500, 800);
  private float step = 1;
  private float radius = 2;
  private float dotSize = 15;
  private int accuracy = 2;
  private bool isAnalys = false;
  public Form1() {
    InitializeComponent();
    accuracyField.Value = accuracy;
    radiusField.Value = (decimal)radius;
  }
  private double factorial(int x) => x == 0 ? 1 : x * factorial(x - 1);
  private double sin(double x, int n) {
    double answer = 0;
    for (int i = 1; i <= n; i++)
      answer += Math.Pow(-1, i - 1) * Math.Pow(x, 2 * i - 1) / factorial(2 * i - 1);
    return answer;
  }
  private double cos(double x, int n) {
    double answer = 0;
    for (int i = 1; i <= n; i++)
      answer += Math.Pow(-1, i - 1) * Math.Pow(x, 2 * i - 2) / factorial(2 * i - 2);
    return answer;
  }
  public static double atn(double x, int n) {
    if (Math.Abs(x) > 1)
      return Math.Sign(x) * Math.PI / 2 - atn(1 / x, n);

    double result = 0;
    for (int i = 1; i <= n; i++)
      result += Math.Pow(-1, i - 1) * Math.Pow(x, 2 * i - 1) / (2 * i - 1);
    return result;
  }

  private void Form1_Paint(object sender, PaintEventArgs e) {
    Graphics g = e.Graphics;
    g.ScaleTransform(0.5f, 0.5f);

    g.FillEllipse(Brushes.Red, point1.X, point1.Y, dotSize, dotSize);
    g.FillEllipse(Brushes.Blue, point2.X, point2.Y, dotSize, dotSize);
    g.DrawEllipse(new Pen(System.Drawing.Color.Black, 1), point2.X + dotSize / 2 - radius / 2, point2.Y + dotSize / 2 - radius / 2, radius, radius);

    Line(g);
    if (isAnalys) {
      accuracy = 1;
      accuracyField.Value = accuracy;
      bool result = Angle(g, accuracy);
      while (!result) {
        accuracy++;
        accuracyField.Value = accuracy;
        result = Angle(g, accuracy);
      }
      isAnalys = false;
    }
    else
      Angle(g, accuracy);
  }
  private void Line(Graphics g) {
    double k = ((double)(point2.Y - point1.Y)) / (point2.X - point1.X);
    double b = point1.Y - k * point1.X;
    for (int x = point1.X; x <= point2.X; x++)
      g.FillEllipse(Brushes.Yellow, x, (float)(k * x + b), 3, 3);
  }
  private double calcDistance(float x, float y) => Math.Sqrt(Math.Pow(point2.X + dotSize / 2 - (x + 2.5), 2) + Math.Pow(point2.Y + dotSize / 2 - (y + 2.5), 2));
  private bool Angle(Graphics g, int n) {
    double angle = atn((double)Math.Abs(point2.Y - point1.Y) / Math.Abs(point2.X - point1.X), n);
    Console.WriteLine(angle);
    float x = point1.X;
    float y = point1.Y;
    double distance = calcDistance(x, y);
    while (distance > radius / 2) {
      x += step * (float)cos(angle, n);
      y += step * (float)sin(angle, n);
      g.FillEllipse(Brushes.Black, x, y, 5, 5);
      distance = calcDistance(x, y);
      if (x > point2.X + dotSize + 5 * radius)
        return false;
    }
    return true;
  }

  private void run_Click(object sender, EventArgs e) {
    accuracy = (int)accuracyField.Value;
    radius = (int)radiusField.Value;
    this.Invalidate();
  }

  private void analysis_Click(object sender, EventArgs e) {
    string basePath = AppContext.BaseDirectory;
    string projectPath = Path.GetFullPath(Path.Combine(basePath, "../../.."));
    string resultsPath = Path.Combine(projectPath, "result/data.txt");
    string plotPath = Path.Combine(projectPath, "result/plot.png");
    int[] radiuses = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
    foreach(int r in radiuses) {
      radius = r;
      radiusField.Value = (decimal)radius;
      isAnalys = true;
      this.Invalidate();
      this.Update();
      File.AppendAllText(resultsPath, $"{radius} {accuracy}\n");
    }

    string[] lines = File.ReadAllLines(resultsPath);
    int[] accuraces = new int[lines.Length];

    for (int i = 0; i < lines.Length; i++) {
      string[] parts = lines[i].Split(' ');
      accuraces[i] = int.Parse(parts[1]);
    }

    var plot = new Plot();
    plot.Title($"Зависимость точности от радиуса попадания", size: 16);
    plot.XLabel("Радиус попадания");
    plot.YLabel("Точность");

    var scatter = plot.Add.Scatter(radiuses, accuraces);
    scatter.Color = Colors.Blue;
    scatter.MarkerSize = 7;
    scatter.LineWidth = 2;

    plot.SavePng(plotPath, 1200, 800);
  }
}

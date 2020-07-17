// Decompiled with JetBrains decompiler
// Type: AlertsProject.Features
// Assembly: AlertsProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 01CC30A2-D287-482E-A95A-AE835F91B86F
// Assembly location: C:\Users\Ofek Mula\Desktop\AlertsProject.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Timers;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WinFormAnimation;

namespace AlertsProject
{
  public class Features : Form
  {
    private IContainer components = (IContainer) null;
    private Chart lastWeekDataChart;
    private Label label2;
    private CircularProgressBar.CircularProgressBar circularProgressBar;
    private Label label1;
    private Label label3;
    private Label label4;
    private Label label5;
    private Label label8;
    private Label numberOfComponentsLabel;
    private Label numberOfFaultsLabel;
    private Label avgNumOfAffectedComponentsLabel;
    private Label averageNumOfFaultsLabel;
    private MyPanel myPanel1;

    public Features()
    {
      this.InitializeComponent();
      this.DoubleBuffered = true;
    }

    private void Features_Load(object sender, EventArgs e)
    {
      Tools.writeStatsFile();
      this.loadChart();
      this.circularBarInitializer();
      this.loadLabelsValues();
    }

    private void circularBarInitializer()
    {
      this.circularProgressBar.Minimum = Tools.MINIMUM_VALUE_BAR;
      this.circularProgressBar.Maximum = Tools.MAXIMUM_VALUE_BAR;
      this.circularProgressBar.Value = Tools.FractionToPercents(Tools.componentDivisionRelativeToAll(Tools.numberOfComponentsWithFaultsInDB()));
      this.circularProgressBar.Text = this.circularProgressBar.Value.ToString() + Tools.BAR_MEASURE_BY;
    }

    private void loadLabelsValues()
    {
      Label ofComponentsLabel = this.numberOfComponentsLabel;
      int num = Tools.numberOfComponentsInDB();
      string str1 = num.ToString() ?? "";
      ofComponentsLabel.Text = str1;
      Label numberOfFaultsLabel = this.numberOfFaultsLabel;
      num = Tools.numberOfFaultsInDB();
      string str2 = num.ToString() ?? "";
      numberOfFaultsLabel.Text = str2;
      this.averageNumOfFaultsLabel.Text = string.Format("{0:0.00}", (object) Tools.avgNumOfFaultsPerComponent());
      this.avgNumOfAffectedComponentsLabel.Text = string.Format("{0:0.00}", (object) Tools.avgNumOfAffectedComponentPerFaults());
    }

    private void loadChart()
    {
      Dictionary<DateTime, Stats> dictionary = new Dictionary<DateTime, Stats>((IDictionary<DateTime, Stats>) Tools.statsForChart.getStatsRelativeToDate());
      while ((uint) dictionary.Count > 0U)
      {
        DateTime index = dictionary.Keys.Min<DateTime>();
        this.lastWeekDataChart.Series["מספר התקלות "].Points.AddXY((object) Tools.createDateLabelForChart(index), (object) dictionary[index].getNumberOfFaults());
        this.lastWeekDataChart.Series["מספר הרכיבים"].Points.AddXY((object) Tools.createDateLabelForChart(index), (object) dictionary[index].getNumberOfComponents());
        dictionary.Remove(index);
      }
    }

    private void timer_Elapsed(object sender, ElapsedEventArgs e)
    {
    }

    private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
    {
    }

    private void chart1_Click(object sender, EventArgs e)
    {
    }

    private void Features_FormClosed(object sender, FormClosedEventArgs e)
    {
    }

    private void lastWeekDataChart_Click(object sender, EventArgs e)
    {
    }

    private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
    {
    }

    private void circularProgressBar2_Click(object sender, EventArgs e)
    {
    }

    private void label4_Click(object sender, EventArgs e)
    {
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ChartArea chartArea = new ChartArea();
      Legend legend = new Legend();
      Series series1 = new Series();
      Series series2 = new Series();
      Title title1 = new Title();
      Title title2 = new Title();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Features));
      this.lastWeekDataChart = new Chart();
      this.label2 = new Label();
      this.circularProgressBar = new CircularProgressBar.CircularProgressBar();
      this.label1 = new Label();
      this.myPanel1 = new MyPanel();
      this.numberOfComponentsLabel = new Label();
      this.label5 = new Label();
      this.label8 = new Label();
      this.label4 = new Label();
      this.avgNumOfAffectedComponentsLabel = new Label();
      this.averageNumOfFaultsLabel = new Label();
      this.numberOfFaultsLabel = new Label();
      this.label3 = new Label();
      this.lastWeekDataChart.BeginInit();
      this.myPanel1.SuspendLayout();
      this.SuspendLayout();
      this.lastWeekDataChart.BackColor = Color.Transparent;
      this.lastWeekDataChart.BackSecondaryColor = Color.Transparent;
      chartArea.Area3DStyle.LightStyle = LightStyle.Realistic;
      chartArea.AxisX.LabelAutoFitStyle = LabelAutoFitStyles.IncreaseFont | LabelAutoFitStyles.StaggeredLabels | LabelAutoFitStyles.LabelsAngleStep30 | LabelAutoFitStyles.WordWrap;
      chartArea.AxisX.TitleFont = new Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      chartArea.AxisX.TitleForeColor = Color.White;
      chartArea.BackColor = Color.Transparent;
      chartArea.BorderColor = Color.Transparent;
      chartArea.Name = "ChartArea1";
      this.lastWeekDataChart.ChartAreas.Add(chartArea);
      legend.Name = "Legend1";
      legend.TitleAlignment = StringAlignment.Near;
      this.lastWeekDataChart.Legends.Add(legend);
      this.lastWeekDataChart.Location = new Point(64, 80);
      this.lastWeekDataChart.Name = "lastWeekDataChart";
      this.lastWeekDataChart.Palette = ChartColorPalette.Bright;
      this.lastWeekDataChart.RightToLeft = RightToLeft.Yes;
      series1.ChartArea = "ChartArea1";
      series1.Color = Color.FromArgb(0, 0, 64);
      series1.Font = new Font("Century Gothic", 24f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      series1.LabelBackColor = Color.Transparent;
      series1.Legend = "Legend1";
      series1.MarkerBorderColor = Color.FromArgb((int) byte.MaxValue, 192, 192);
      series1.Name = "מספר הרכיבים";
      series2.ChartArea = "ChartArea1";
      series2.Color = Color.Teal;
      series2.Font = new Font("Century Gothic", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      series2.Legend = "Legend1";
      series2.Name = "מספר התקלות ";
      this.lastWeekDataChart.Series.Add(series1);
      this.lastWeekDataChart.Series.Add(series2);
      this.lastWeekDataChart.Size = new Size(560, 314);
      this.lastWeekDataChart.TabIndex = 50;
      this.lastWeekDataChart.Text = "fgfgdgg";
      title1.Alignment = ContentAlignment.TopCenter;
      title1.BackColor = Color.Transparent;
      title1.Font = new Font("Century Gothic", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      title1.Name = "כמות";
      title1.Text = "כמות הרכיבים והתקלות הרשומים במערכת";
      title2.Name = "תאריך";
      this.lastWeekDataChart.Titles.Add(title1);
      this.lastWeekDataChart.Titles.Add(title2);
      this.lastWeekDataChart.Click += new EventHandler(this.lastWeekDataChart_Click);
      this.label2.AutoSize = true;
      this.label2.BackColor = Color.Transparent;
      this.label2.Font = new Font("Century Gothic", 39.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.Black;
      this.label2.Location = new Point(789, 9);
      this.label2.Name = "label2";
      this.label2.RightToLeft = RightToLeft.Yes;
      this.label2.Size = new Size(294, 63);
      this.label2.TabIndex = 51;
      this.label2.Text = "סטטיסטיקות";
      this.circularProgressBar.AnimationFunction = KnownAnimationFunctions.Liner;
      this.circularProgressBar.AnimationSpeed = 500;
      this.circularProgressBar.BackColor = Color.Transparent;
      this.circularProgressBar.Font = new Font("Century Gothic", 39.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.circularProgressBar.ForeColor = Color.White;
      this.circularProgressBar.InnerColor = SystemColors.MenuHighlight;
      this.circularProgressBar.InnerMargin = 2;
      this.circularProgressBar.InnerWidth = -1;
      this.circularProgressBar.Location = new Point(426, 396);
      this.circularProgressBar.MarqueeAnimationSpeed = 2000;
      this.circularProgressBar.Name = "circularProgressBar";
      this.circularProgressBar.OuterColor = Color.DimGray;
      this.circularProgressBar.OuterMargin = -25;
      this.circularProgressBar.OuterWidth = 26;
      this.circularProgressBar.ProgressColor = Color.FloralWhite;
      this.circularProgressBar.ProgressWidth = 25;
      this.circularProgressBar.SecondaryFont = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.circularProgressBar.Size = new Size(198, 199);
      this.circularProgressBar.StartAngle = 270;
      this.circularProgressBar.Style = ProgressBarStyle.Marquee;
      this.circularProgressBar.SubscriptColor = Color.FromArgb(166, 166, 166);
      this.circularProgressBar.SubscriptMargin = new Padding(10, -35, 0, 0);
      this.circularProgressBar.SubscriptText = "";
      this.circularProgressBar.SuperscriptColor = Color.FromArgb(166, 166, 166);
      this.circularProgressBar.SuperscriptMargin = new Padding(10, 35, 0, 0);
      this.circularProgressBar.SuperscriptText = "";
      this.circularProgressBar.TabIndex = 52;
      this.circularProgressBar.Text = "10%";
      this.circularProgressBar.TextMargin = new Padding(8, 8, 0, 0);
      this.circularProgressBar.Value = 80;
      this.circularProgressBar.Click += new EventHandler(this.circularProgressBar2_Click);
      this.label1.BackColor = Color.Transparent;
      this.label1.Font = new Font("Century Gothic", 24f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.Black;
      this.label1.Location = new Point(658, 400);
      this.label1.Name = "label1";
      this.label1.RightToLeft = RightToLeft.Yes;
      this.label1.Size = new Size(232, 195);
      this.label1.TabIndex = 53;
      this.label1.Text = "אחוז הרכיבים  במערכת שעבורם רשומות תקלות:";
      this.label1.TextAlign = ContentAlignment.MiddleCenter;
      this.myPanel1.BackColor = Color.Transparent;
      this.myPanel1.Controls.Add((Control) this.numberOfComponentsLabel);
      this.myPanel1.Controls.Add((Control) this.label5);
      this.myPanel1.Controls.Add((Control) this.label8);
      this.myPanel1.Controls.Add((Control) this.label4);
      this.myPanel1.Controls.Add((Control) this.avgNumOfAffectedComponentsLabel);
      this.myPanel1.Controls.Add((Control) this.averageNumOfFaultsLabel);
      this.myPanel1.Controls.Add((Control) this.numberOfFaultsLabel);
      this.myPanel1.Controls.Add((Control) this.label3);
      this.myPanel1.Location = new Point(640, 95);
      this.myPanel1.Name = "myPanel1";
      this.myPanel1.Size = new Size(432, 299);
      this.myPanel1.TabIndex = 62;
      this.numberOfComponentsLabel.AutoSize = true;
      this.numberOfComponentsLabel.BackColor = Color.Transparent;
      this.numberOfComponentsLabel.Font = new Font("Century Gothic", 27.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.numberOfComponentsLabel.ForeColor = Color.Black;
      this.numberOfComponentsLabel.Location = new Point(291, 22);
      this.numberOfComponentsLabel.Name = "numberOfComponentsLabel";
      this.numberOfComponentsLabel.RightToLeft = RightToLeft.Yes;
      this.numberOfComponentsLabel.Size = new Size(62, 44);
      this.numberOfComponentsLabel.TabIndex = 58;
      this.numberOfComponentsLabel.Text = "20";
      this.numberOfComponentsLabel.TextAlign = ContentAlignment.MiddleCenter;
      this.label5.AutoSize = true;
      this.label5.BackColor = Color.Transparent;
      this.label5.Font = new Font("Century Gothic", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label5.ForeColor = Color.Black;
      this.label5.Location = new Point(234, 184);
      this.label5.Name = "label5";
      this.label5.RightToLeft = RightToLeft.Yes;
      this.label5.Size = new Size(178, 24);
      this.label5.TabIndex = 56;
      this.label5.Text = "מספר התקלות במערכת";
      this.label5.TextAlign = ContentAlignment.MiddleCenter;
      this.label8.BackColor = Color.Transparent;
      this.label8.Font = new Font("Century Gothic", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label8.ForeColor = Color.Black;
      this.label8.Location = new Point(18, 184);
      this.label8.Name = "label8";
      this.label8.RightToLeft = RightToLeft.Yes;
      this.label8.Size = new Size(196, 55);
      this.label8.TabIndex = 57;
      this.label8.Text = "מספר הרכיבים המושפעים בממוצע לתקלה";
      this.label8.TextAlign = ContentAlignment.MiddleCenter;
      this.label4.AutoSize = true;
      this.label4.BackColor = Color.Transparent;
      this.label4.Font = new Font("Century Gothic", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label4.ForeColor = Color.Black;
      this.label4.Location = new Point(3, 66);
      this.label4.Name = "label4";
      this.label4.RightToLeft = RightToLeft.Yes;
      this.label4.Size = new Size(203, 24);
      this.label4.TabIndex = 55;
      this.label4.Text = "כמות תקלות ממוצעת לרכיב\r\n";
      this.label4.TextAlign = ContentAlignment.MiddleCenter;
      this.label4.Click += new EventHandler(this.label4_Click);
      this.avgNumOfAffectedComponentsLabel.AutoSize = true;
      this.avgNumOfAffectedComponentsLabel.BackColor = Color.Transparent;
      this.avgNumOfAffectedComponentsLabel.Font = new Font("Century Gothic", 27.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.avgNumOfAffectedComponentsLabel.ForeColor = Color.Black;
      this.avgNumOfAffectedComponentsLabel.Location = new Point(68, 140);
      this.avgNumOfAffectedComponentsLabel.Name = "avgNumOfAffectedComponentsLabel";
      this.avgNumOfAffectedComponentsLabel.RightToLeft = RightToLeft.Yes;
      this.avgNumOfAffectedComponentsLabel.Size = new Size(72, 44);
      this.avgNumOfAffectedComponentsLabel.TabIndex = 60;
      this.avgNumOfAffectedComponentsLabel.Text = "1.5";
      this.avgNumOfAffectedComponentsLabel.TextAlign = ContentAlignment.MiddleCenter;
      this.averageNumOfFaultsLabel.AutoSize = true;
      this.averageNumOfFaultsLabel.BackColor = Color.Transparent;
      this.averageNumOfFaultsLabel.Font = new Font("Century Gothic", 27.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.averageNumOfFaultsLabel.ForeColor = Color.Black;
      this.averageNumOfFaultsLabel.Location = new Point(68, 22);
      this.averageNumOfFaultsLabel.Name = "averageNumOfFaultsLabel";
      this.averageNumOfFaultsLabel.RightToLeft = RightToLeft.Yes;
      this.averageNumOfFaultsLabel.Size = new Size(72, 44);
      this.averageNumOfFaultsLabel.TabIndex = 61;
      this.averageNumOfFaultsLabel.Text = "2.0";
      this.averageNumOfFaultsLabel.TextAlign = ContentAlignment.MiddleCenter;
      this.numberOfFaultsLabel.AutoSize = true;
      this.numberOfFaultsLabel.BackColor = Color.Transparent;
      this.numberOfFaultsLabel.Font = new Font("Century Gothic", 27.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.numberOfFaultsLabel.ForeColor = Color.Black;
      this.numberOfFaultsLabel.Location = new Point(291, 140);
      this.numberOfFaultsLabel.Name = "numberOfFaultsLabel";
      this.numberOfFaultsLabel.RightToLeft = RightToLeft.Yes;
      this.numberOfFaultsLabel.Size = new Size(62, 44);
      this.numberOfFaultsLabel.TabIndex = 59;
      this.numberOfFaultsLabel.Text = "40";
      this.numberOfFaultsLabel.TextAlign = ContentAlignment.MiddleCenter;
      this.label3.AutoSize = true;
      this.label3.BackColor = Color.Transparent;
      this.label3.Font = new Font("Century Gothic", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label3.ForeColor = Color.Black;
      this.label3.Location = new Point(234, 66);
      this.label3.Name = "label3";
      this.label3.RightToLeft = RightToLeft.Yes;
      this.label3.Size = new Size(176, 24);
      this.label3.TabIndex = 54;
      this.label3.Text = "מספר הרכיבים במערכת";
      this.label3.TextAlign = ContentAlignment.MiddleCenter;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackgroundImage = (Image) componentResourceManager.GetObject("$this.BackgroundImage");
      this.BackgroundImageLayout = ImageLayout.Stretch;
      this.ClientSize = new Size(1084, 611);
      this.Controls.Add((Control) this.myPanel1);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.circularProgressBar);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.lastWeekDataChart);
      this.Name = nameof (Features);
      this.Text = nameof (Features);
      this.FormClosed += new FormClosedEventHandler(this.Features_FormClosed);
      this.Load += new EventHandler(this.Features_Load);
      this.lastWeekDataChart.EndInit();
      this.myPanel1.ResumeLayout(false);
      this.myPanel1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}

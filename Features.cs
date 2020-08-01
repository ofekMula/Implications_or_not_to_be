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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Features));
            this.lastWeekDataChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label2 = new System.Windows.Forms.Label();
            this.circularProgressBar = new CircularProgressBar.CircularProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.myPanel1 = new AlertsProject.MyPanel();
            this.numberOfComponentsLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.avgNumOfAffectedComponentsLabel = new System.Windows.Forms.Label();
            this.averageNumOfFaultsLabel = new System.Windows.Forms.Label();
            this.numberOfFaultsLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.lastWeekDataChart)).BeginInit();
            this.myPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lastWeekDataChart
            // 
            this.lastWeekDataChart.BackColor = System.Drawing.Color.Transparent;
            this.lastWeekDataChart.BackSecondaryColor = System.Drawing.Color.Transparent;
            chartArea1.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic;
            chartArea1.AxisX.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.BorderColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.lastWeekDataChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            legend1.TitleAlignment = System.Drawing.StringAlignment.Near;
            this.lastWeekDataChart.Legends.Add(legend1);
            this.lastWeekDataChart.Location = new System.Drawing.Point(96, 123);
            this.lastWeekDataChart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lastWeekDataChart.Name = "lastWeekDataChart";
            this.lastWeekDataChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            this.lastWeekDataChart.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            series1.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.LabelBackColor = System.Drawing.Color.Transparent;
            series1.Legend = "Legend1";
            series1.MarkerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            series1.Name = "מספר הרכיבים";
            series2.ChartArea = "ChartArea1";
            series2.Color = System.Drawing.Color.Teal;
            series2.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.Legend = "Legend1";
            series2.Name = "מספר התקלות ";
            this.lastWeekDataChart.Series.Add(series1);
            this.lastWeekDataChart.Series.Add(series2);
            this.lastWeekDataChart.Size = new System.Drawing.Size(840, 483);
            this.lastWeekDataChart.TabIndex = 50;
            this.lastWeekDataChart.Text = "fgfgdgg";
            title1.Alignment = System.Drawing.ContentAlignment.TopCenter;
            title1.BackColor = System.Drawing.Color.Transparent;
            title1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "כמות";
            title1.Text = "כמות הרכיבים והתקלות הרשומים במערכת";
            title2.Name = "תאריך";
            this.lastWeekDataChart.Titles.Add(title1);
            this.lastWeekDataChart.Titles.Add(title2);
            this.lastWeekDataChart.Click += new System.EventHandler(this.lastWeekDataChart_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(1184, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(450, 93);
            this.label2.TabIndex = 51;
            this.label2.Text = "סטטיסטיקות";
            // 
            // circularProgressBar
            // 
            this.circularProgressBar.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.circularProgressBar.AnimationSpeed = 500;
            this.circularProgressBar.BackColor = System.Drawing.Color.Transparent;
            this.circularProgressBar.Font = new System.Drawing.Font("Century Gothic", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.circularProgressBar.ForeColor = System.Drawing.Color.White;
            this.circularProgressBar.InnerColor = System.Drawing.SystemColors.MenuHighlight;
            this.circularProgressBar.InnerMargin = 2;
            this.circularProgressBar.InnerWidth = -1;
            this.circularProgressBar.Location = new System.Drawing.Point(639, 609);
            this.circularProgressBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.circularProgressBar.MarqueeAnimationSpeed = 2000;
            this.circularProgressBar.Name = "circularProgressBar";
            this.circularProgressBar.OuterColor = System.Drawing.Color.DimGray;
            this.circularProgressBar.OuterMargin = -25;
            this.circularProgressBar.OuterWidth = 26;
            this.circularProgressBar.ProgressColor = System.Drawing.Color.FloralWhite;
            this.circularProgressBar.ProgressWidth = 25;
            this.circularProgressBar.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.circularProgressBar.Size = new System.Drawing.Size(297, 306);
            this.circularProgressBar.StartAngle = 270;
            this.circularProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.circularProgressBar.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularProgressBar.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.circularProgressBar.SubscriptText = "";
            this.circularProgressBar.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularProgressBar.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.circularProgressBar.SuperscriptText = "";
            this.circularProgressBar.TabIndex = 52;
            this.circularProgressBar.Text = "10%";
            this.circularProgressBar.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.circularProgressBar.Value = 80;
            this.circularProgressBar.Click += new System.EventHandler(this.circularProgressBar2_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(987, 615);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(348, 300);
            this.label1.TabIndex = 53;
            this.label1.Text = "אחוז הרכיבים  במערכת שעבורם רשומות תקלות:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // myPanel1
            // 
            this.myPanel1.BackColor = System.Drawing.Color.Transparent;
            this.myPanel1.Controls.Add(this.numberOfComponentsLabel);
            this.myPanel1.Controls.Add(this.label5);
            this.myPanel1.Controls.Add(this.label8);
            this.myPanel1.Controls.Add(this.label4);
            this.myPanel1.Controls.Add(this.avgNumOfAffectedComponentsLabel);
            this.myPanel1.Controls.Add(this.averageNumOfFaultsLabel);
            this.myPanel1.Controls.Add(this.numberOfFaultsLabel);
            this.myPanel1.Controls.Add(this.label3);
            this.myPanel1.Location = new System.Drawing.Point(960, 146);
            this.myPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.myPanel1.Name = "myPanel1";
            this.myPanel1.Size = new System.Drawing.Size(648, 460);
            this.myPanel1.TabIndex = 62;
            // 
            // numberOfComponentsLabel
            // 
            this.numberOfComponentsLabel.AutoSize = true;
            this.numberOfComponentsLabel.BackColor = System.Drawing.Color.Transparent;
            this.numberOfComponentsLabel.Font = new System.Drawing.Font("Century Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberOfComponentsLabel.ForeColor = System.Drawing.Color.Black;
            this.numberOfComponentsLabel.Location = new System.Drawing.Point(436, 34);
            this.numberOfComponentsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.numberOfComponentsLabel.Name = "numberOfComponentsLabel";
            this.numberOfComponentsLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.numberOfComponentsLabel.Size = new System.Drawing.Size(90, 66);
            this.numberOfComponentsLabel.TabIndex = 58;
            this.numberOfComponentsLabel.Text = "20";
            this.numberOfComponentsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(351, 283);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(264, 39);
            this.label5.TabIndex = 56;
            this.label5.Text = "מספר התקלות במערכת";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(27, 283);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label8.Size = new System.Drawing.Size(294, 85);
            this.label8.TabIndex = 57;
            this.label8.Text = "מספר הרכיבים המושפעים בממוצע לתקלה";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(4, 102);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(302, 39);
            this.label4.TabIndex = 55;
            this.label4.Text = "כמות תקלות ממוצעת לרכיב\r\n";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // avgNumOfAffectedComponentsLabel
            // 
            this.avgNumOfAffectedComponentsLabel.AutoSize = true;
            this.avgNumOfAffectedComponentsLabel.BackColor = System.Drawing.Color.Transparent;
            this.avgNumOfAffectedComponentsLabel.Font = new System.Drawing.Font("Century Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.avgNumOfAffectedComponentsLabel.ForeColor = System.Drawing.Color.Black;
            this.avgNumOfAffectedComponentsLabel.Location = new System.Drawing.Point(102, 215);
            this.avgNumOfAffectedComponentsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.avgNumOfAffectedComponentsLabel.Name = "avgNumOfAffectedComponentsLabel";
            this.avgNumOfAffectedComponentsLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.avgNumOfAffectedComponentsLabel.Size = new System.Drawing.Size(106, 66);
            this.avgNumOfAffectedComponentsLabel.TabIndex = 60;
            this.avgNumOfAffectedComponentsLabel.Text = "1.5";
            this.avgNumOfAffectedComponentsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // averageNumOfFaultsLabel
            // 
            this.averageNumOfFaultsLabel.AutoSize = true;
            this.averageNumOfFaultsLabel.BackColor = System.Drawing.Color.Transparent;
            this.averageNumOfFaultsLabel.Font = new System.Drawing.Font("Century Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.averageNumOfFaultsLabel.ForeColor = System.Drawing.Color.Black;
            this.averageNumOfFaultsLabel.Location = new System.Drawing.Point(102, 34);
            this.averageNumOfFaultsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.averageNumOfFaultsLabel.Name = "averageNumOfFaultsLabel";
            this.averageNumOfFaultsLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.averageNumOfFaultsLabel.Size = new System.Drawing.Size(106, 66);
            this.averageNumOfFaultsLabel.TabIndex = 61;
            this.averageNumOfFaultsLabel.Text = "2.0";
            this.averageNumOfFaultsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numberOfFaultsLabel
            // 
            this.numberOfFaultsLabel.AutoSize = true;
            this.numberOfFaultsLabel.BackColor = System.Drawing.Color.Transparent;
            this.numberOfFaultsLabel.Font = new System.Drawing.Font("Century Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberOfFaultsLabel.ForeColor = System.Drawing.Color.Black;
            this.numberOfFaultsLabel.Location = new System.Drawing.Point(436, 215);
            this.numberOfFaultsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.numberOfFaultsLabel.Name = "numberOfFaultsLabel";
            this.numberOfFaultsLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.numberOfFaultsLabel.Size = new System.Drawing.Size(90, 66);
            this.numberOfFaultsLabel.TabIndex = 59;
            this.numberOfFaultsLabel.Text = "40";
            this.numberOfFaultsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(351, 102);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(264, 39);
            this.label3.TabIndex = 54;
            this.label3.Text = "מספר הרכיבים במערכת";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Features
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1626, 940);
            this.Controls.Add(this.myPanel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.circularProgressBar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lastWeekDataChart);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Features";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Features_FormClosed);
            this.Load += new System.EventHandler(this.Features_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lastWeekDataChart)).EndInit();
            this.myPanel1.ResumeLayout(false);
            this.myPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }
  }
}

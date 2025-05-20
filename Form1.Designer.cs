namespace MovingStraightAhead;

partial class Form1 {
  private System.ComponentModel.IContainer components = null;

  protected override void Dispose(bool disposing) {
    if (disposing && (components != null)) {
      components.Dispose();
    }
    base.Dispose(disposing);
  }

  #region Windows Form Designer generated code

  private void InitializeComponent() {
    accuracyField = new NumericUpDown();
    radiusField = new NumericUpDown();
    label1 = new Label();
    label2 = new Label();
    run = new Button();
    analysis = new Button();
    ((System.ComponentModel.ISupportInitialize)accuracyField).BeginInit();
    ((System.ComponentModel.ISupportInitialize)radiusField).BeginInit();
    SuspendLayout();
    // 
    // accuracyField
    // 
    accuracyField.Location = new Point(608, 12);
    accuracyField.Name = "accuracyField";
    accuracyField.Size = new Size(180, 31);
    accuracyField.TabIndex = 0;
    // 
    // radiusField
    // 
    radiusField.Location = new Point(608, 49);
    radiusField.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
    radiusField.Name = "radiusField";
    radiusField.Size = new Size(180, 31);
    radiusField.TabIndex = 1;
    // 
    // label1
    // 
    label1.AutoSize = true;
    label1.Location = new Point(523, 14);
    label1.Name = "label1";
    label1.Size = new Size(79, 25);
    label1.TabIndex = 2;
    label1.Text = "accuracy";
    // 
    // label2
    // 
    label2.AutoSize = true;
    label2.Location = new Point(542, 51);
    label2.Name = "label2";
    label2.Size = new Size(60, 25);
    label2.TabIndex = 3;
    label2.Text = "radius";
    // 
    // run
    // 
    run.Location = new Point(676, 86);
    run.Name = "run";
    run.Size = new Size(112, 34);
    run.TabIndex = 4;
    run.Text = "run";
    run.UseVisualStyleBackColor = true;
    run.Click += run_Click;
    // 
    // analysis
    // 
    analysis.Location = new Point(676, 126);
    analysis.Name = "analysis";
    analysis.Size = new Size(112, 34);
    analysis.TabIndex = 5;
    analysis.Text = "analysis";
    analysis.UseVisualStyleBackColor = true;
    analysis.Click += analysis_Click;
    // 
    // Form1
    // 
    AutoScaleDimensions = new SizeF(10F, 25F);
    AutoScaleMode = AutoScaleMode.Font;
    ClientSize = new Size(800, 450);
    Controls.Add(analysis);
    Controls.Add(run);
    Controls.Add(label2);
    Controls.Add(label1);
    Controls.Add(radiusField);
    Controls.Add(accuracyField);
    Name = "Form1";
    Text = "Form1";
    Paint += Form1_Paint;
    ((System.ComponentModel.ISupportInitialize)accuracyField).EndInit();
    ((System.ComponentModel.ISupportInitialize)radiusField).EndInit();
    ResumeLayout(false);
    PerformLayout();
  }

  #endregion

  private NumericUpDown accuracyField;
  private NumericUpDown radiusField;
  private Label label1;
  private Label label2;
  private Button run;
  private Button analysis;
}

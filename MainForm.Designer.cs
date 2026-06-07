namespace eyebreak;

partial class MainForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
        notifyIcon = new NotifyIcon(components);
        countdownTimer = new System.Windows.Forms.Timer(components);
        runAtStartupCheckBox = new CheckBox();
        playSoundCheckBox = new CheckBox();
        remindMeLabel = new Label();
        shortBreakEnabledCheckBox = new CheckBox();
        shortBreakIntervalNumericUpDown = new NumericUpDown();
        shortBreakMinutesLabel = new Label();
        nextShortBreakLabel = new Label();
        longBreakEnabledCheckBox = new CheckBox();
        longBreakIntervalNumericUpDown = new NumericUpDown();
        longBreakMinutesLabel = new Label();
        nextLongBreakLabel = new Label();
        ((System.ComponentModel.ISupportInitialize)shortBreakIntervalNumericUpDown).BeginInit();
        ((System.ComponentModel.ISupportInitialize)longBreakIntervalNumericUpDown).BeginInit();
        SuspendLayout();
        //
        // notifyIcon
        //
        notifyIcon.Icon = (Icon)resources.GetObject("notifyIcon.Icon");
        notifyIcon.Text = "eyebreak";
        notifyIcon.Visible = true;
        notifyIcon.DoubleClick += notifyIcon_DoubleClick;
        //
        // countdownTimer
        //
        countdownTimer.Interval = 1000;
        countdownTimer.Tick += countdownTimer_Tick;
        //
        // runAtStartupCheckBox
        //
        runAtStartupCheckBox.AutoSize = true;
        runAtStartupCheckBox.Location = new Point(16, 15);
        runAtStartupCheckBox.Name = "runAtStartupCheckBox";
        runAtStartupCheckBox.Size = new Size(100, 19);
        runAtStartupCheckBox.TabIndex = 0;
        runAtStartupCheckBox.Text = "Run at startup";
        runAtStartupCheckBox.UseVisualStyleBackColor = true;
        runAtStartupCheckBox.CheckedChanged += runAtStartupCheckBox_CheckedChanged;
        //
        // playSoundCheckBox
        //
        playSoundCheckBox.AutoSize = true;
        playSoundCheckBox.Location = new Point(16, 40);
        playSoundCheckBox.Name = "playSoundCheckBox";
        playSoundCheckBox.Size = new Size(170, 19);
        playSoundCheckBox.TabIndex = 1;
        playSoundCheckBox.Text = "Play a sound with reminders";
        playSoundCheckBox.UseVisualStyleBackColor = true;
        playSoundCheckBox.CheckedChanged += playSoundCheckBox_CheckedChanged;
        //
        // remindMeLabel
        //
        remindMeLabel.AutoSize = true;
        remindMeLabel.Location = new Point(16, 72);
        remindMeLabel.Name = "remindMeLabel";
        remindMeLabel.Size = new Size(103, 15);
        remindMeLabel.TabIndex = 2;
        remindMeLabel.Text = "Remind me every:";
        //
        // shortBreakEnabledCheckBox
        //
        shortBreakEnabledCheckBox.AutoSize = true;
        shortBreakEnabledCheckBox.Location = new Point(16, 96);
        shortBreakEnabledCheckBox.Name = "shortBreakEnabledCheckBox";
        shortBreakEnabledCheckBox.Size = new Size(120, 19);
        shortBreakEnabledCheckBox.TabIndex = 3;
        shortBreakEnabledCheckBox.Text = "Short break every";
        shortBreakEnabledCheckBox.UseVisualStyleBackColor = true;
        shortBreakEnabledCheckBox.CheckedChanged += shortBreakEnabledCheckBox_CheckedChanged;
        //
        // shortBreakIntervalNumericUpDown
        //
        shortBreakIntervalNumericUpDown.Location = new Point(175, 94);
        shortBreakIntervalNumericUpDown.Maximum = new decimal(new int[] { BreakDefaults.MaximumShortBreakIntervalMinutes, 0, 0, 0 });
        shortBreakIntervalNumericUpDown.Minimum = new decimal(new int[] { BreakDefaults.MinimumIntervalMinutes, 0, 0, 0 });
        shortBreakIntervalNumericUpDown.Name = "shortBreakIntervalNumericUpDown";
        shortBreakIntervalNumericUpDown.Size = new Size(55, 23);
        shortBreakIntervalNumericUpDown.TabIndex = 4;
        shortBreakIntervalNumericUpDown.Value = new decimal(new int[] { BreakDefaults.ShortBreakIntervalMinutes, 0, 0, 0 });
        shortBreakIntervalNumericUpDown.ValueChanged += shortBreakIntervalNumericUpDown_ValueChanged;
        //
        // shortBreakMinutesLabel
        //
        shortBreakMinutesLabel.AutoSize = true;
        shortBreakMinutesLabel.Location = new Point(236, 96);
        shortBreakMinutesLabel.Name = "shortBreakMinutesLabel";
        shortBreakMinutesLabel.Size = new Size(50, 15);
        shortBreakMinutesLabel.TabIndex = 5;
        shortBreakMinutesLabel.Text = "minutes";
        //
        // nextShortBreakLabel
        //
        nextShortBreakLabel.AutoSize = true;
        nextShortBreakLabel.ForeColor = SystemColors.GrayText;
        nextShortBreakLabel.Location = new Point(34, 119);
        nextShortBreakLabel.Name = "nextShortBreakLabel";
        nextShortBreakLabel.Size = new Size(140, 15);
        nextShortBreakLabel.TabIndex = 6;
        nextShortBreakLabel.Text = "Next short break in --:--";
        //
        // longBreakEnabledCheckBox
        //
        longBreakEnabledCheckBox.AutoSize = true;
        longBreakEnabledCheckBox.Location = new Point(16, 150);
        longBreakEnabledCheckBox.Name = "longBreakEnabledCheckBox";
        longBreakEnabledCheckBox.Size = new Size(120, 19);
        longBreakEnabledCheckBox.TabIndex = 7;
        longBreakEnabledCheckBox.Text = "Long break every";
        longBreakEnabledCheckBox.UseVisualStyleBackColor = true;
        longBreakEnabledCheckBox.CheckedChanged += longBreakEnabledCheckBox_CheckedChanged;
        //
        // longBreakIntervalNumericUpDown
        //
        longBreakIntervalNumericUpDown.Location = new Point(175, 148);
        longBreakIntervalNumericUpDown.Maximum = new decimal(new int[] { BreakDefaults.MaximumLongBreakIntervalMinutes, 0, 0, 0 });
        longBreakIntervalNumericUpDown.Minimum = new decimal(new int[] { BreakDefaults.MinimumIntervalMinutes, 0, 0, 0 });
        longBreakIntervalNumericUpDown.Name = "longBreakIntervalNumericUpDown";
        longBreakIntervalNumericUpDown.Size = new Size(55, 23);
        longBreakIntervalNumericUpDown.TabIndex = 8;
        longBreakIntervalNumericUpDown.Value = new decimal(new int[] { BreakDefaults.LongBreakIntervalMinutes, 0, 0, 0 });
        longBreakIntervalNumericUpDown.ValueChanged += longBreakIntervalNumericUpDown_ValueChanged;
        //
        // longBreakMinutesLabel
        //
        longBreakMinutesLabel.AutoSize = true;
        longBreakMinutesLabel.Location = new Point(236, 150);
        longBreakMinutesLabel.Name = "longBreakMinutesLabel";
        longBreakMinutesLabel.Size = new Size(50, 15);
        longBreakMinutesLabel.TabIndex = 9;
        longBreakMinutesLabel.Text = "minutes";
        //
        // nextLongBreakLabel
        //
        nextLongBreakLabel.AutoSize = true;
        nextLongBreakLabel.ForeColor = SystemColors.GrayText;
        nextLongBreakLabel.Location = new Point(34, 173);
        nextLongBreakLabel.Name = "nextLongBreakLabel";
        nextLongBreakLabel.Size = new Size(140, 15);
        nextLongBreakLabel.TabIndex = 10;
        nextLongBreakLabel.Text = "Next long break in --:--";
        //
        // MainForm
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(320, 210);
        Controls.Add(nextLongBreakLabel);
        Controls.Add(longBreakMinutesLabel);
        Controls.Add(longBreakIntervalNumericUpDown);
        Controls.Add(longBreakEnabledCheckBox);
        Controls.Add(nextShortBreakLabel);
        Controls.Add(shortBreakMinutesLabel);
        Controls.Add(shortBreakIntervalNumericUpDown);
        Controls.Add(shortBreakEnabledCheckBox);
        Controls.Add(remindMeLabel);
        Controls.Add(playSoundCheckBox);
        Controls.Add(runAtStartupCheckBox);
        Icon = (Icon)resources.GetObject("$this.Icon");
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "eyebreak";
        FormClosing += MainForm_FormClosing;
        ((System.ComponentModel.ISupportInitialize)shortBreakIntervalNumericUpDown).EndInit();
        ((System.ComponentModel.ISupportInitialize)longBreakIntervalNumericUpDown).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private NotifyIcon notifyIcon;
    private System.Windows.Forms.Timer countdownTimer;
    private CheckBox runAtStartupCheckBox;
    private CheckBox playSoundCheckBox;
    private Label remindMeLabel;
    private CheckBox shortBreakEnabledCheckBox;
    private NumericUpDown shortBreakIntervalNumericUpDown;
    private Label shortBreakMinutesLabel;
    private Label nextShortBreakLabel;
    private CheckBox longBreakEnabledCheckBox;
    private NumericUpDown longBreakIntervalNumericUpDown;
    private Label longBreakMinutesLabel;
    private Label nextLongBreakLabel;
}

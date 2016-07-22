﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace Doomtrain.Characters_Stats_Charts
{
    public partial class CharHP : Form
    {
        public CharHP(mainForm mainForm)
        {
            _mainForm = mainForm;
            InitializeComponent();
            HpChartWorker();

            _mainForm.numericUpDownCharHP1.ValueChanged += new EventHandler(this.numericUpDownCharHP_ValueChanged);
            _mainForm.numericUpDownCharHP2.ValueChanged += new EventHandler(this.numericUpDownCharHP_ValueChanged);
            _mainForm.numericUpDownCharHP3.ValueChanged += new EventHandler(this.numericUpDownCharHP_ValueChanged);
            _mainForm.numericUpDownCharHP4.ValueChanged += new EventHandler(this.numericUpDownCharHP_ValueChanged);

            numericUpDownMagicValue.ValueChanged += new EventHandler(numericUpDownCharHP_ValueChanged);
            numericUpDownMagicCount.ValueChanged += new EventHandler(numericUpDownCharHP_ValueChanged);
            numericUpDownStatBonus.ValueChanged += new EventHandler(numericUpDownCharHP_ValueChanged);
            numericUpDownPercent.ValueChanged += new EventHandler(numericUpDownCharHP_ValueChanged);

            checkBoxDefault.CheckedChanged += new EventHandler(Default_CheckedChanged);
        }

        private readonly mainForm _mainForm;


        #region Moving chart

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void chartHP_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void chartHP_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void chartHP_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        #endregion

        private void buttonHPClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The values here are only used for the chart and they have no connection to the kernel file.\n" +
                "You need to change the values manually.\n\n" +
                "Magic J-Value = The junction value of the junctioned magic.\n" + 
                "Magic Count = The amount of junctioned magic that the character holds.\n" + 
                "Stat Bonus = Permanent bonus gained from X bonus skills and Devour.\n" + 
                "Percent Modifier = Is 100 + any % bonuses added", "HP chart values info",
                MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }



        #region Read Chart Values        

        private void HpChartWorker()
        {
            KernelWorker.ReadCharacters(_mainForm.listBoxCharacters.SelectedIndex, KernelWorker.BackupKernel);
            try
            {
                chartHP.Series["Default"].Points.AddXY
                    (0, Math.Ceiling((((int)numericUpDownMagicValue.Value * (int)numericUpDownMagicCount.Value + (int)numericUpDownStatBonus.Value +
                    10 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(10, 2)) /
                    KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * (int)numericUpDownPercent.Value) / 100) * 100 / 100);

                chartHP.Series["Default"].Points.AddXY
                    (1, Math.Ceiling((((int)numericUpDownMagicValue.Value * (int)numericUpDownMagicCount.Value + (int)numericUpDownStatBonus.Value +
                    20 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(20, 2)) /
                    KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * (int)numericUpDownPercent.Value) / 100) * 100 / 100);

                chartHP.Series["Default"].Points.AddXY
                    (2, Math.Ceiling((((int)numericUpDownMagicValue.Value * (int)numericUpDownMagicCount.Value + (int)numericUpDownStatBonus.Value +
                    30 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(30, 2)) /
                    KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * (int)numericUpDownPercent.Value) / 100) * 100 / 100);

                chartHP.Series["Default"].Points.AddXY
                    (3, Math.Ceiling((((int)numericUpDownMagicValue.Value * (int)numericUpDownMagicCount.Value + (int)numericUpDownStatBonus.Value +
                    40 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(40, 2)) /
                    KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * (int)numericUpDownPercent.Value) / 100) * 100 / 100);

                chartHP.Series["Default"].Points.AddXY
                    (4, Math.Ceiling((((int)numericUpDownMagicValue.Value * (int)numericUpDownMagicCount.Value + (int)numericUpDownStatBonus.Value +
                    50 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(50, 2)) /
                    KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * (int)numericUpDownPercent.Value) / 100) * 100 / 100);

                chartHP.Series["Default"].Points.AddXY
                    (5, Math.Ceiling((((int)numericUpDownMagicValue.Value * (int)numericUpDownMagicCount.Value + (int)numericUpDownStatBonus.Value +
                    60 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(60, 2)) /
                    KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * (int)numericUpDownPercent.Value) / 100) * 100 / 100);

                chartHP.Series["Default"].Points.AddXY
                    (6, Math.Ceiling((((int)numericUpDownMagicValue.Value * (int)numericUpDownMagicCount.Value + (int)numericUpDownStatBonus.Value +
                    70 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(70, 2)) /
                    KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * (int)numericUpDownPercent.Value) / 100) * 100 / 100);

                chartHP.Series["Default"].Points.AddXY
                    (7, Math.Ceiling((((int)numericUpDownMagicValue.Value * (int)numericUpDownMagicCount.Value + (int)numericUpDownStatBonus.Value +
                    80 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(80, 2)) /
                    KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * (int)numericUpDownPercent.Value) / 100) * 100 / 100);

                chartHP.Series["Default"].Points.AddXY
                    (8, Math.Ceiling((((int)numericUpDownMagicValue.Value * (int)numericUpDownMagicCount.Value + (int)numericUpDownStatBonus.Value +
                    90 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(90, 2)) /
                    KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * (int)numericUpDownPercent.Value) / 100) * 100 / 100);

                chartHP.Series["Default"].Points.AddXY
                    (9, Math.Ceiling((((int)numericUpDownMagicValue.Value * (int)numericUpDownMagicCount.Value + (int)numericUpDownStatBonus.Value +
                    100 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(100, 2)) /
                    KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * (int)numericUpDownPercent.Value) / 100) * 100 / 100);
            }
            catch (Exception Exception)
            {
                MessageBox.Show(Exception.ToString());
            }


            KernelWorker.ReadCharacters(_mainForm.listBoxCharacters.SelectedIndex, KernelWorker.Kernel);
            try
            {
                chartHP.Series["Current"].Points.AddXY
                    (0, Math.Ceiling((((int)numericUpDownMagicValue.Value * (int)numericUpDownMagicCount.Value + (int)numericUpDownStatBonus.Value +
                    10 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(10, 2)) /
                    KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * (int)numericUpDownPercent.Value) / 100) * 100 / 100);

                chartHP.Series["Current"].Points.AddXY
                    (1, Math.Ceiling((((int)numericUpDownMagicValue.Value * (int)numericUpDownMagicCount.Value + (int)numericUpDownStatBonus.Value +
                    20 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(20, 2)) /
                    KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * (int)numericUpDownPercent.Value) / 100) * 100 / 100);

                chartHP.Series["Current"].Points.AddXY
                    (2, Math.Ceiling((((int)numericUpDownMagicValue.Value * (int)numericUpDownMagicCount.Value + (int)numericUpDownStatBonus.Value +
                    30 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(30, 2)) /
                    KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * (int)numericUpDownPercent.Value) / 100) * 100 / 100);

                chartHP.Series["Current"].Points.AddXY
                    (3, Math.Ceiling((((int)numericUpDownMagicValue.Value * (int)numericUpDownMagicCount.Value + (int)numericUpDownStatBonus.Value +
                    40 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(40, 2)) /
                    KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * (int)numericUpDownPercent.Value) / 100) * 100 / 100);

                chartHP.Series["Current"].Points.AddXY
                    (4, Math.Ceiling((((int)numericUpDownMagicValue.Value * (int)numericUpDownMagicCount.Value + (int)numericUpDownStatBonus.Value +
                    50 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(50, 2)) /
                    KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * (int)numericUpDownPercent.Value) / 100) * 100 / 100);

                chartHP.Series["Current"].Points.AddXY
                    (5, Math.Ceiling((((int)numericUpDownMagicValue.Value * (int)numericUpDownMagicCount.Value + (int)numericUpDownStatBonus.Value +
                    60 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(60, 2)) /
                    KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * (int)numericUpDownPercent.Value) / 100) * 100 / 100);

                chartHP.Series["Current"].Points.AddXY
                    (6, Math.Ceiling((((int)numericUpDownMagicValue.Value * (int)numericUpDownMagicCount.Value + (int)numericUpDownStatBonus.Value +
                    70 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(70, 2)) /
                    KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * (int)numericUpDownPercent.Value) / 100) * 100 / 100);

                chartHP.Series["Current"].Points.AddXY
                    (7, Math.Ceiling((((int)numericUpDownMagicValue.Value * (int)numericUpDownMagicCount.Value + (int)numericUpDownStatBonus.Value +
                    80 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(80, 2)) /
                    KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * (int)numericUpDownPercent.Value) / 100) * 100 / 100);

                chartHP.Series["Current"].Points.AddXY
                    (8, Math.Ceiling((((int)numericUpDownMagicValue.Value * (int)numericUpDownMagicCount.Value + (int)numericUpDownStatBonus.Value +
                    90 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(90, 2)) /
                    KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * (int)numericUpDownPercent.Value) / 100) * 100 / 100);

                chartHP.Series["Current"].Points.AddXY
                    (9, Math.Ceiling((((int)numericUpDownMagicValue.Value * (int)numericUpDownMagicCount.Value + (int)numericUpDownStatBonus.Value +
                    100 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(100, 2)) /
                    KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * (int)numericUpDownPercent.Value) / 100) * 100 / 100);
            }
            catch (Exception Exception)
            {
                MessageBox.Show(Exception.ToString());
            }
        }

        #endregion

        #region Change chart values

        private void numericUpDownCharHP_ValueChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                KernelWorker.ReadCharacters(_mainForm.listBoxCharacters.SelectedIndex, KernelWorker.BackupKernel);
                try
                {
                    if (checkBoxDefault.Checked == true)
                    {
                        chartHP.Series["Default"].Points.Clear();

                        chartHP.Series["Default"].Points.AddXY
                            (0, Math.Ceiling((((int)numericUpDownMagicValue.Value * (int)numericUpDownMagicCount.Value + (int)numericUpDownStatBonus.Value +
                            10 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(10, 2)) /
                            KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * (int)numericUpDownPercent.Value) / 100) * 100 / 100);

                        chartHP.Series["Default"].Points.AddXY
                            (1, Math.Ceiling((((int)numericUpDownMagicValue.Value * (int)numericUpDownMagicCount.Value + (int)numericUpDownStatBonus.Value +
                            20 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(20, 2)) /
                            KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * (int)numericUpDownPercent.Value) / 100) * 100 / 100);

                        chartHP.Series["Default"].Points.AddXY
                            (2, Math.Ceiling((((int)numericUpDownMagicValue.Value * (int)numericUpDownMagicCount.Value + (int)numericUpDownStatBonus.Value +
                            30 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(30, 2)) /
                            KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * (int)numericUpDownPercent.Value) / 100) * 100 / 100);

                        chartHP.Series["Default"].Points.AddXY
                            (3, Math.Ceiling((((int)numericUpDownMagicValue.Value * (int)numericUpDownMagicCount.Value + (int)numericUpDownStatBonus.Value +
                            40 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(40, 2)) /
                            KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * (int)numericUpDownPercent.Value) / 100) * 100 / 100);

                        chartHP.Series["Default"].Points.AddXY
                            (4, Math.Ceiling((((int)numericUpDownMagicValue.Value * (int)numericUpDownMagicCount.Value + (int)numericUpDownStatBonus.Value +
                            50 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(50, 2)) /
                            KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * (int)numericUpDownPercent.Value) / 100) * 100 / 100);

                        chartHP.Series["Default"].Points.AddXY
                            (5, Math.Ceiling((((int)numericUpDownMagicValue.Value * (int)numericUpDownMagicCount.Value + (int)numericUpDownStatBonus.Value +
                            60 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(60, 2)) /
                            KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * (int)numericUpDownPercent.Value) / 100) * 100 / 100);

                        chartHP.Series["Default"].Points.AddXY
                            (6, Math.Ceiling((((int)numericUpDownMagicValue.Value * (int)numericUpDownMagicCount.Value + (int)numericUpDownStatBonus.Value +
                            70 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(70, 2)) /
                            KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * (int)numericUpDownPercent.Value) / 100) * 100 / 100);

                        chartHP.Series["Default"].Points.AddXY
                            (7, Math.Ceiling((((int)numericUpDownMagicValue.Value * (int)numericUpDownMagicCount.Value + (int)numericUpDownStatBonus.Value +
                            80 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(80, 2)) /
                            KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * (int)numericUpDownPercent.Value) / 100) * 100 / 100);

                        chartHP.Series["Default"].Points.AddXY
                            (8, Math.Ceiling((((int)numericUpDownMagicValue.Value * (int)numericUpDownMagicCount.Value + (int)numericUpDownStatBonus.Value +
                            90 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(90, 2)) /
                            KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * (int)numericUpDownPercent.Value) / 100) * 100 / 100);

                        chartHP.Series["Default"].Points.AddXY
                            (9, Math.Ceiling((((int)numericUpDownMagicValue.Value * (int)numericUpDownMagicCount.Value + (int)numericUpDownStatBonus.Value +
                            100 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(100, 2)) /
                            KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * (int)numericUpDownPercent.Value) / 100) * 100 / 100);


                    }
                    else if (checkBoxDefault.Checked == false)
                    {
                        chartHP.Series["Default"].Points.Clear();

                        chartHP.Series["Default"].Points.AddXY
                            (0, Math.Ceiling(((0 * 0 + 0 +
                            10 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(10, 2)) /
                            KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * 100) / 100) * 100 / 100);

                        chartHP.Series["Default"].Points.AddXY
                            (1, Math.Ceiling(((0 * 0 + 0 +
                            20 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(20, 2)) /
                            KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * 100) / 100) * 100 / 100);

                        chartHP.Series["Default"].Points.AddXY
                            (2, Math.Ceiling(((0 * 0 + 0 +
                            30 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(30, 2)) /
                            KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * 100) / 100) * 100 / 100);

                        chartHP.Series["Default"].Points.AddXY
                            (3, Math.Ceiling(((0 * 0 + 0 +
                            40 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(40, 2)) /
                            KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * 100) / 100) * 100 / 100);

                        chartHP.Series["Default"].Points.AddXY
                            (4, Math.Ceiling(((0 * 0 + 0 +
                            50 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(50, 2)) /
                            KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * 100) / 100) * 100 / 100);

                        chartHP.Series["Default"].Points.AddXY
                            (5, Math.Ceiling(((0 * 0 + 0 +
                            60 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(60, 2)) /
                            KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * 100) / 100) * 100 / 100);

                        chartHP.Series["Default"].Points.AddXY
                            (6, Math.Ceiling(((0 * 0 + 0 +
                            70 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(70, 2)) /
                            KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * 100) / 100) * 100 / 100);

                        chartHP.Series["Default"].Points.AddXY
                            (7, Math.Ceiling(((0 * 0 + 0 +
                            80 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(80, 2)) /
                            KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * 100) / 100) * 100 / 100);

                        chartHP.Series["Default"].Points.AddXY
                            (8, Math.Ceiling(((0 * 0 + 0 +
                            90 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(90, 2)) /
                            KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * 100) / 100) * 100 / 100);

                        chartHP.Series["Default"].Points.AddXY
                            (9, Math.Ceiling(((0 * 0 + 0 +
                            100 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(100, 2)) /
                            KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * 100) / 100) * 100 / 100);
                    }

                }
                catch (Exception Exception)
                {
                    MessageBox.Show(Exception.ToString());
                }


                KernelWorker.ReadCharacters(_mainForm.listBoxCharacters.SelectedIndex, KernelWorker.Kernel);
                try
                {
                    chartHP.Series["Current"].Points.Clear();

                    chartHP.Series["Current"].Points.AddXY
                        (0, Math.Ceiling((((int)numericUpDownMagicValue.Value * (int)numericUpDownMagicCount.Value + (int)numericUpDownStatBonus.Value +
                        10 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(10, 2)) /
                        KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * (int)numericUpDownPercent.Value) / 100) * 100 / 100);

                    chartHP.Series["Current"].Points.AddXY
                        (1, Math.Ceiling((((int)numericUpDownMagicValue.Value * (int)numericUpDownMagicCount.Value + (int)numericUpDownStatBonus.Value +
                        20 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(20, 2)) /
                        KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * (int)numericUpDownPercent.Value) / 100) * 100 / 100);

                    chartHP.Series["Current"].Points.AddXY
                        (2, Math.Ceiling((((int)numericUpDownMagicValue.Value * (int)numericUpDownMagicCount.Value + (int)numericUpDownStatBonus.Value +
                        30 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(30, 2)) /
                        KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * (int)numericUpDownPercent.Value) / 100) * 100 / 100);

                    chartHP.Series["Current"].Points.AddXY
                        (3, Math.Ceiling((((int)numericUpDownMagicValue.Value * (int)numericUpDownMagicCount.Value + (int)numericUpDownStatBonus.Value +
                        40 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(40, 2)) /
                        KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * (int)numericUpDownPercent.Value) / 100) * 100 / 100);

                    chartHP.Series["Current"].Points.AddXY
                        (4, Math.Ceiling((((int)numericUpDownMagicValue.Value * (int)numericUpDownMagicCount.Value + (int)numericUpDownStatBonus.Value +
                        50 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(50, 2)) /
                        KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * (int)numericUpDownPercent.Value) / 100) * 100 / 100);

                    chartHP.Series["Current"].Points.AddXY
                        (5, Math.Ceiling((((int)numericUpDownMagicValue.Value * (int)numericUpDownMagicCount.Value + (int)numericUpDownStatBonus.Value +
                        60 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(60, 2)) /
                        KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * (int)numericUpDownPercent.Value) / 100) * 100 / 100);

                    chartHP.Series["Current"].Points.AddXY
                        (6, Math.Ceiling((((int)numericUpDownMagicValue.Value * (int)numericUpDownMagicCount.Value + (int)numericUpDownStatBonus.Value +
                        70 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(70, 2)) /
                        KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * (int)numericUpDownPercent.Value) / 100) * 100 / 100);

                    chartHP.Series["Current"].Points.AddXY
                        (7, Math.Ceiling((((int)numericUpDownMagicValue.Value * (int)numericUpDownMagicCount.Value + (int)numericUpDownStatBonus.Value +
                        80 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(80, 2)) /
                        KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * (int)numericUpDownPercent.Value) / 100) * 100 / 100);

                    chartHP.Series["Current"].Points.AddXY
                        (8, Math.Ceiling((((int)numericUpDownMagicValue.Value * (int)numericUpDownMagicCount.Value + (int)numericUpDownStatBonus.Value +
                        90 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(90, 2)) /
                        KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * (int)numericUpDownPercent.Value) / 100) * 100 / 100);

                    chartHP.Series["Current"].Points.AddXY
                        (9, Math.Ceiling((((int)numericUpDownMagicValue.Value * (int)numericUpDownMagicCount.Value + (int)numericUpDownStatBonus.Value +
                        100 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(100, 2)) /
                        KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * (int)numericUpDownPercent.Value) / 100) * 100 / 100);
                }
                catch (Exception Exception)
                {
                    MessageBox.Show(Exception.ToString());
                }
            }
        }

        #endregion

        #region Default checked changed

        private void Default_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                KernelWorker.ReadCharacters(_mainForm.listBoxCharacters.SelectedIndex, KernelWorker.BackupKernel);
                try
                {
                    if (checkBoxDefault.Checked == true)
                    {
                        chartHP.Series["Default"].Points.Clear();

                        chartHP.Series["Default"].Points.AddXY
                            (0, Math.Ceiling((((int)numericUpDownMagicValue.Value * (int)numericUpDownMagicCount.Value + (int)numericUpDownStatBonus.Value +
                            10 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(10, 2)) /
                            KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * (int)numericUpDownPercent.Value) / 100) * 100 / 100);

                        chartHP.Series["Default"].Points.AddXY
                            (1, Math.Ceiling((((int)numericUpDownMagicValue.Value * (int)numericUpDownMagicCount.Value + (int)numericUpDownStatBonus.Value +
                            20 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(20, 2)) /
                            KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * (int)numericUpDownPercent.Value) / 100) * 100 / 100);

                        chartHP.Series["Default"].Points.AddXY
                            (2, Math.Ceiling((((int)numericUpDownMagicValue.Value * (int)numericUpDownMagicCount.Value + (int)numericUpDownStatBonus.Value +
                            30 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(30, 2)) /
                            KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * (int)numericUpDownPercent.Value) / 100) * 100 / 100);

                        chartHP.Series["Default"].Points.AddXY
                            (3, Math.Ceiling((((int)numericUpDownMagicValue.Value * (int)numericUpDownMagicCount.Value + (int)numericUpDownStatBonus.Value +
                            40 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(40, 2)) /
                            KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * (int)numericUpDownPercent.Value) / 100) * 100 / 100);

                        chartHP.Series["Default"].Points.AddXY
                            (4, Math.Ceiling((((int)numericUpDownMagicValue.Value * (int)numericUpDownMagicCount.Value + (int)numericUpDownStatBonus.Value +
                            50 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(50, 2)) /
                            KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * (int)numericUpDownPercent.Value) / 100) * 100 / 100);

                        chartHP.Series["Default"].Points.AddXY
                            (5, Math.Ceiling((((int)numericUpDownMagicValue.Value * (int)numericUpDownMagicCount.Value + (int)numericUpDownStatBonus.Value +
                            60 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(60, 2)) /
                            KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * (int)numericUpDownPercent.Value) / 100) * 100 / 100);

                        chartHP.Series["Default"].Points.AddXY
                            (6, Math.Ceiling((((int)numericUpDownMagicValue.Value * (int)numericUpDownMagicCount.Value + (int)numericUpDownStatBonus.Value +
                            70 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(70, 2)) /
                            KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * (int)numericUpDownPercent.Value) / 100) * 100 / 100);

                        chartHP.Series["Default"].Points.AddXY
                            (7, Math.Ceiling((((int)numericUpDownMagicValue.Value * (int)numericUpDownMagicCount.Value + (int)numericUpDownStatBonus.Value +
                            80 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(80, 2)) /
                            KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * (int)numericUpDownPercent.Value) / 100) * 100 / 100);

                        chartHP.Series["Default"].Points.AddXY
                            (8, Math.Ceiling((((int)numericUpDownMagicValue.Value * (int)numericUpDownMagicCount.Value + (int)numericUpDownStatBonus.Value +
                            90 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(90, 2)) /
                            KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * (int)numericUpDownPercent.Value) / 100) * 100 / 100);

                        chartHP.Series["Default"].Points.AddXY
                            (9, Math.Ceiling((((int)numericUpDownMagicValue.Value * (int)numericUpDownMagicCount.Value + (int)numericUpDownStatBonus.Value +
                            100 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(100, 2)) /
                            KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * (int)numericUpDownPercent.Value) / 100) * 100 / 100);
                    }
                    else if (checkBoxDefault.Checked == false)
                    {
                        chartHP.Series["Default"].Points.Clear();

                        chartHP.Series["Default"].Points.AddXY
                            (0, Math.Ceiling(((0 * 0 + 0 +
                            10 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(10, 2)) /
                            KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * 100) / 100) * 100 / 100);

                        chartHP.Series["Default"].Points.AddXY
                            (1, Math.Ceiling(((0 * 0 + 0 +
                            20 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(20, 2)) /
                            KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * 100) / 100) * 100 / 100);

                        chartHP.Series["Default"].Points.AddXY
                            (2, Math.Ceiling(((0 * 0 + 0 +
                            30 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(30, 2)) /
                            KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * 100) / 100) * 100 / 100);

                        chartHP.Series["Default"].Points.AddXY
                            (3, Math.Ceiling(((0 * 0 + 0 +
                            40 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(40, 2)) /
                            KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * 100) / 100) * 100 / 100);

                        chartHP.Series["Default"].Points.AddXY
                            (4, Math.Ceiling(((0 * 0 + 0 +
                            50 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(50, 2)) /
                            KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * 100) / 100) * 100 / 100);

                        chartHP.Series["Default"].Points.AddXY
                            (5, Math.Ceiling(((0 * 0 + 0 +
                            60 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(60, 2)) /
                            KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * 100) / 100) * 100 / 100);

                        chartHP.Series["Default"].Points.AddXY
                            (6, Math.Ceiling(((0 * 0 + 0 +
                            70 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(70, 2)) /
                            KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * 100) / 100) * 100 / 100);

                        chartHP.Series["Default"].Points.AddXY
                            (7, Math.Ceiling(((0 * 0 + 0 +
                            80 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(80, 2)) /
                            KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * 100) / 100) * 100 / 100);

                        chartHP.Series["Default"].Points.AddXY
                            (8, Math.Ceiling(((0 * 0 + 0 +
                            90 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(90, 2)) /
                            KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * 100) / 100) * 100 / 100);

                        chartHP.Series["Default"].Points.AddXY
                            (9, Math.Ceiling(((0 * 0 + 0 +
                            100 * KernelWorker.GetSelectedCharactersData.HP1 - (10 * Math.Pow(100, 2)) /
                            KernelWorker.GetSelectedCharactersData.HP2 + KernelWorker.GetSelectedCharactersData.HP3) * 100) / 100) * 100 / 100);
                    }

                }
                catch (Exception Exception)
                {
                    MessageBox.Show(Exception.ToString());
                }
            }
        }

        #endregion
    }
}

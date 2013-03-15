/* This file is part of QRelectrial
 * Copyright (C) 2013 Rafael Bailón-Ruiz
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.

 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

/*
 * Copyright 2012 ZXing.Net authors
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

using AForge.Video;
using ZXing;

namespace QRelectrial
{
    public partial class QRelectrialForm : Form
    {
        System.Collections.Generic.List<Member> memberList = new System.Collections.Generic.List<Member>();


        private struct Device
        {
            public int Index;
            public string Name;
            public override string ToString()
            {
                return Name;
            }
        }

        private readonly CameraDevices camDevices;
        private Bitmap currentBitmapForDecoding;
        private readonly Thread decodingThread;
        private Result currentResult;
        private readonly Pen resultRectPen;

        public QRelectrialForm()
        {
            InitializeComponent();

            camDevices = new CameraDevices();

            decodingThread = new Thread(DecodeBarcode);
            decodingThread.Start();

            pictureBox1.Paint += pictureBox1_Paint;
            resultRectPen = new Pen(Color.Green, 10);
        }

        void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (currentResult == null)
                return;

            if (currentResult.ResultPoints != null && currentResult.ResultPoints.Length > 0)
            {
                var resultPoints = currentResult.ResultPoints;
                var rect = new Rectangle((int)resultPoints[0].X, (int)resultPoints[0].Y, 1, 1);
                foreach (var point in resultPoints)
                {
                    if (point.X < rect.Left)
                        rect = new Rectangle((int)point.X, rect.Y, rect.Width + rect.X - (int)point.X, rect.Height);
                    if (point.X > rect.Right)
                        rect = new Rectangle(rect.X, rect.Y, rect.Width + (int)point.X - rect.X, rect.Height);
                    if (point.Y < rect.Top)
                        rect = new Rectangle(rect.X, (int)point.Y, rect.Width, rect.Height + rect.Y - (int)point.Y);
                    if (point.Y > rect.Bottom)
                        rect = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height + (int)point.Y - rect.Y);
                }
                using (var g = pictureBox1.CreateGraphics())
                {
                    g.DrawRectangle(resultRectPen, rect);
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadDevicesToCombobox();
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
            if (!e.Cancel)
            {
                decodingThread.Abort();
                if (camDevices.Current != null)
                {
                    camDevices.Current.NewFrame -= Current_NewFrame;
                    if (camDevices.Current.IsRunning)
                    {
                        camDevices.Current.SignalToStop();
                    }
                }
            }
        }

        private void LoadDevicesToCombobox()
        {
            cmbDevice.Items.Clear();
            for (var index = 0; index < camDevices.Devices.Count; index++)
            {
                cmbDevice.Items.Add(new Device { Index = index, Name = camDevices.Devices[index].Name });
            }
        }

        private void cmbDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (camDevices.Current != null)
            {
                camDevices.Current.NewFrame -= Current_NewFrame;
                if (camDevices.Current.IsRunning)
                {
                    camDevices.Current.SignalToStop();
                }
            }

            camDevices.SelectCamera(((Device)(cmbDevice.SelectedItem)).Index);
            camDevices.Current.NewFrame += Current_NewFrame;
            camDevices.Current.Start();
        }

        private void Current_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if (IsDisposed)
            {
                return;
            }

            try
            {
                if (currentBitmapForDecoding == null)
                {
                    currentBitmapForDecoding = (Bitmap)eventArgs.Frame.Clone();
                }
                Invoke(new Action<Bitmap>(ShowFrame), eventArgs.Frame.Clone());
            }
            catch (ObjectDisposedException)
            {
                // not sure, why....
            }
        }

        private void ShowFrame(Bitmap frame)
        {
            if (pictureBox1.Width < frame.Width)
            {
                pictureBox1.Width = frame.Width;
            }
            if (pictureBox1.Height < frame.Height)
            {
                pictureBox1.Height = frame.Height;
            }
            pictureBox1.Image = frame;
        }

        private void DecodeBarcode()
        {
            var reader = new BarcodeReader();
            while (true)
            {
                if (currentBitmapForDecoding != null)
                {
                    var result = reader.Decode(currentBitmapForDecoding);
                    if (result != null)
                    {
                        Invoke(new Action<Result>(ShowResult), result);
                    }
                    currentBitmapForDecoding.Dispose();
                    currentBitmapForDecoding = null;
                }
                Thread.Sleep(200);
            }
        }

        private void ShowResult(Result result)
        {
            currentResult = result;
            txtBarcodeFormat.Text = result.BarcodeFormat.ToString();
            txtContent.Text = result.Text;

            string[] data = result.Text.Split(new Char[]{'\n','\r'}, StringSplitOptions.RemoveEmptyEntries);

            Member newMember = new Member(uint.Parse(data[0]), data[2], data[1]);
            if (!memberList.Contains(newMember))
            {
                memberList.Add(newMember);
                UpdateGUIList();
            }
        }

        private void UpdateGUIList()
        {
            dataGridView.Rows.Clear();
            foreach (Member m in memberList)
            {
                dataGridView.Rows.Add( m.ID.ToString(), m.FamilyName, m.GivenName);
            }
        }

        private static void SaveRollCall(System.Collections.Generic.List<Member> peopleList)
        {
            SaveFileDialog newFileDialog = new SaveFileDialog();
            newFileDialog.Filter = "Valores separados por comas (*.csv)|*.csv";
            newFileDialog.FileName = DateTime.Now.ToString().Replace('/','-').Replace(':','-').Replace(' ','_');
            if (newFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamWriter sw = null;
                try
                {
                    sw = new System.IO.StreamWriter(newFileDialog.FileName, false, System.Text.Encoding.UTF8);
                    foreach (Member m in peopleList)
	                {
                        sw.WriteLine("" + m.ID.ToString() + ";" + m.FamilyName + ";" + m.GivenName + "");
	                }
                }
                finally
                {
                    if (sw != null)
                    {
                        sw.Close();
                    }
                }
            }
        }

        private void aboutStripButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Application.ProductName + " " + Application.ProductVersion.ToString() + "\nCopyright (C) Rafael Bailón-Ruiz, Asociación Electrial\nThis program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.", Application.ProductName + " " + Application.ProductVersion.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void saveStripButton_Click(object sender, EventArgs e)
        {
            SaveRollCall(memberList);
        }

    }
}

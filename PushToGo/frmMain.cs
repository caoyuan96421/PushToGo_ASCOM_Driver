using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ASCOM.Controls;
using System.Diagnostics;
using ASCOM.DeviceInterface;

namespace ASCOM.PushToGo
{
    public partial class FrmMain : Form
    {
        private const double guideRate = 15.0 / 3600.0;       // sidereal - more or less

        delegate void SetTextCallback(string text);

        private Utilities.Util util = new ASCOM.Utilities.Util();
        private static int GuideDurationShort = 50;
        private static int GuideDurationMedium = 200;
        private static int GuideDurationLong = 1000;
        private static double SlewMedium = 1;
        private static double SlewSlow = 0.05;
        private static double SlewFast = 4;

        public FrmMain()
        {
            InitializeComponent();
            this.BringToFront();
            //this.BackColor = Color.Brown;
        }

        public void DoSetupDialog()
        {
            using (SetupDialogForm setupForm = new SetupDialogForm())
            {
                setupForm.CanFindHome = TelescopeHardware.CanFindHome;
                setupForm.CanPark = TelescopeHardware.CanPark;
                setupForm.NumberMoveAxis = TelescopeHardware.NumberMoveAxis;
                setupForm.OnTop = TelescopeHardware.OnTop;
                setupForm.CanPulseGuide = TelescopeHardware.CanPulseGuide;
                setupForm.CanSetEquatorialRates = TelescopeHardware.CanSetEquatorialRates;
                setupForm.CanSetGuideRates = TelescopeHardware.CanSetGuideRates;
                setupForm.CanSetPark = TelescopeHardware.CanSetPark;
                setupForm.CanSetPierSide = TelescopeHardware.CanSetPierSide;
                setupForm.CanSetTracking = TelescopeHardware.CanSetTracking;
                setupForm.CanSlew = TelescopeHardware.CanSlew;
                setupForm.CanAlignmentMode = TelescopeHardware.CanAlignmentMode;
                setupForm.AlignmentMode = TelescopeHardware.AlignmentMode;
                setupForm.CanOptics = TelescopeHardware.CanOptics;
                setupForm.ApertureArea = TelescopeHardware.ApertureArea;
                setupForm.ApertureDiameter = TelescopeHardware.ApertureDiameter;
                setupForm.FocalLength = TelescopeHardware.FocalLength;
                setupForm.CanSlewAltAz = TelescopeHardware.CanSlewAltAz;
                setupForm.CanSlewAltAzAsync = TelescopeHardware.CanSlewAltAzAsync;
                setupForm.CanSlewAsync = TelescopeHardware.CanSlewAsync;
                setupForm.CanSync = TelescopeHardware.CanSync;
                setupForm.CanSyncAltAz = TelescopeHardware.CanSyncAltAz;
                setupForm.CanUnpark = TelescopeHardware.CanUnpark;
                setupForm.CanAltAz = TelescopeHardware.CanAltAz;
                setupForm.CanDateTime = TelescopeHardware.CanDateTime;
                setupForm.CanDoesRefraction = TelescopeHardware.CanDoesRefraction;
                setupForm.CanEquatorial = TelescopeHardware.CanEquatorial;
                setupForm.CanLatLongElev = TelescopeHardware.CanLatLongElev;
                setupForm.CanPierSide = TelescopeHardware.CanPierSide;
                setupForm.CanDualAxisPulseGuide = TelescopeHardware.CanDualAxisPulseGuide;
                setupForm.Refraction = TelescopeHardware.Refraction;
                setupForm.CanTrackingRates = TelescopeHardware.CanTrackingRates;
                setupForm.CanSiderealTime = TelescopeHardware.CanSiderealTime;
                //setupForm.EquatorialSystem = TelescopeHardware.EquatorialSystem;
                setupForm.Elevation = TelescopeHardware.Elevation;
                setupForm.Latitude = TelescopeHardware.Latitude;
                setupForm.Longitude = TelescopeHardware.Longitude;
                setupForm.MaximumSlewRate = TelescopeHardware.MaximumSlewRate;
                setupForm.NoSyncPastMeridian = TelescopeHardware.NoSyncPastMeridian;
                setupForm.COMPort = TelescopeHardware.COMPort;
                this.BringToFront();
                DialogResult ans = setupForm.ShowDialog(this);

                if (ans == DialogResult.OK)
                {
                    try
                    {
                        //TelescopeHardware.CanFindHome = setupForm.CanFindHome;
                        //TelescopeHardware.CanPark = setupForm.CanPark;
                        //TelescopeHardware.NumberMoveAxis = setupForm.NumberMoveAxis;
                        TelescopeHardware.OnTop = setupForm.OnTop;
                        //TelescopeHardware.CanPulseGuide = setupForm.CanPulseGuide;
                        //TelescopeHardware.CanSetEquatorialRates = setupForm.CanSetEquatorialRates;
                        //TelescopeHardware.CanSetGuideRates = setupForm.CanSetGuideRates;
                        //TelescopeHardware.CanSetPark = setupForm.CanSetPark;
                        //TelescopeHardware.CanSetPierSide = setupForm.CanSetPierSide;
                        //TelescopeHardware.CanSetTracking = setupForm.CanSetTracking;
                        //TelescopeHardware.CanSlew = setupForm.CanSlew;
                        //TelescopeHardware.CanAlignmentMode = setupForm.CanAlignmentMode;
                        //TelescopeHardware.AlignmentMode = setupForm.AlignmentMode;
                        TelescopeHardware.ApertureArea = setupForm.ApertureArea;
                        TelescopeHardware.ApertureDiameter = setupForm.ApertureDiameter;
                        TelescopeHardware.FocalLength = setupForm.FocalLength;
                        //TelescopeHardware.CanSlewAltAzAsync = setupForm.CanSlewAltAzAsync;
                        //TelescopeHardware.CanSlewAltAz = setupForm.CanSlewAltAz;
                        //TelescopeHardware.CanSync = setupForm.CanSync;
                        //TelescopeHardware.CanSyncAltAz = setupForm.CanSyncAltAz;
                        //TelescopeHardware.CanUnpark = setupForm.CanUnpark;
                        //TelescopeHardware.CanAltAz = setupForm.CanAltAz;
                        //TelescopeHardware.CanDateTime = setupForm.CanDateTime;
                        //TelescopeHardware.CanDoesRefraction = setupForm.CanDoesRefraction;
                        //TelescopeHardware.CanEquatorial = setupForm.CanEquatorial;
                        //TelescopeHardware.CanLatLongElev = setupForm.CanLatLongElev;
                        //TelescopeHardware.CanPierSide = setupForm.CanPierSide;
                        //TelescopeHardware.CanDualAxisPulseGuide = setupForm.CanDualAxisPulseGuide;
                        //TelescopeHardware.AutoTrack = setupForm.AutoTrack;
                        //TelescopeHardware.DisconnectOnPark = setupForm.DisconnectOnPark;
                        TelescopeHardware.Refraction = setupForm.Refraction;
                        //TelescopeHardware.CanTrackingRates = setupForm.CanTrackingRates;
                        //TelescopeHardware.CanSiderealTime = setupForm.CanSiderealTime;
                        //TelescopeHardware.NoCoordinatesAtPark = setupForm.NoCoordinatesAtPark;
                        //TelescopeHardware.EquatorialSystem = setupForm.EquatorialSystem;
                        TelescopeHardware.Elevation = setupForm.Elevation;
                        TelescopeHardware.Latitude = setupForm.Latitude;
                        TelescopeHardware.Longitude = setupForm.Longitude;
                        TelescopeHardware.MaximumSlewRate = setupForm.MaximumSlewRate;
                        TelescopeHardware.NoSyncPastMeridian = setupForm.NoSyncPastMeridian;
                        TelescopeHardware.COMPort = setupForm.COMPort;

                        this.TopMost = setupForm.OnTop;
                    }
                    catch (Exception e)
                    {
                        TelescopeHardware.TL.LogMessage("MainFrame", e.ToString());
                    }
                }
            }
        }

        private void ButtonSetup_Click(object sender, EventArgs e)
        {
            DoSetupDialog();
            SetSlewButtons();
        }

        private void ButtonTraffic_Click(object sender, EventArgs e)
        {
            SharedResources.TrafficForm.Show();
        }

        private void SetSlewButtons()
        {
            if (TelescopeHardware.AlignmentMode == DeviceInterface.AlignmentModes.algAltAz)
            {
                buttonSlewUp.Text = "U";
                buttonSlewDown.Text = "D";
                buttonSlewRight.Text = "R";
                buttonSlewLeft.Text = "L";
            }
            else if (TelescopeHardware.SouthernHemisphere)
            {
                buttonSlewUp.Text = "S";
                buttonSlewDown.Text = "N";
                buttonSlewRight.Text = "E";
                buttonSlewLeft.Text = "W";
            }
            else
            {
                buttonSlewUp.Text = "N";
                buttonSlewDown.Text = "S";
                buttonSlewRight.Text = "E";
                buttonSlewLeft.Text = "W";
            }
        }


        public void SiderealTime(double value)
        {
            SetTextCallback setText = new SetTextCallback(SetLstText);
            string text = util.HoursToHMS(value);
            try { this.Invoke(setText, text); }
            catch { }
        }

        public void RightAscension(double value)
        {
            SetTextCallback setText = new SetTextCallback(SetRaText);
            string text = util.HoursToHMS(value);
            try { this.Invoke(setText, text); }
            catch { }
        }

        public void Declination(double value)
        {
            SetTextCallback setText = new SetTextCallback(SetDecText);
            string text = util.DegreesToDMS(value);
            try { this.Invoke(setText, text); }
            catch { }
        }

        public void Altitude(double value)
        {
            SetTextCallback setText = new SetTextCallback(SetAltitudeText);
            string text = util.DegreesToDMS(value);
            try { this.Invoke(setText, text); }
            catch { }
        }

        public void Azimuth(double value)
        {
            SetTextCallback setText = new SetTextCallback(SetAzimuthText);
            string text = util.DegreesToDMS(value);
            try { this.Invoke(setText, text); }
            catch { }
        }

        //public void ParkButton(string value)
        //{
        //    SetTextCallback setText = new SetTextCallback(SetParkButtonText);
        //    try { this.Invoke(setText, value); }
        //    catch { }
        //}

        private void FrmMain_Load(object sender, EventArgs e)
        {
            SetSlewButtons();
            //TelescopeHardware.Start();
        }

        #region Thread Safe Callback Functions
        private void SetLstText(string text)
        {
            labelLst.Text = text;
        }
        private void SetRaText(string text)
        {
            labelRa.Text = text;
        }
        private void SetDecText(string text)
        {
            labelDec.Text = text;
        }
        private void SetAltitudeText(string text)
        {
            labelAlt.Text = text;
        }
        private void SetAzimuthText(string text)
        {
            labelAz.Text = text;
        }

        private void SetParkButtonText(string text)
        {
            buttonPark.Text = text;
        }

        #endregion

        #region slew/guide control using buttons

        //private void SetPulseGuideParms(double guideRateDec, double guideRateRa)
        //{
        //    // stop an axis slew if that's what is enabled
        //    if (this.radioButtonMoveAxis.Checked)
        //    {
        //        TelescopeHardware.SlewDirection = SlewDirection.SlewNone;
        //        return;
        //    }
        //    Debug.Assert(guideRateDec != 0.0 || guideRateRa != 0.0);
        //    Debug.Assert(!(guideRateDec != 0.0 && guideRateRa != 0.0));

        //    if (guideRateDec != 0.0)
        //    {
        //        TelescopeHardware.GuideRateDeclination = guideRateDec;
        //        TelescopeHardware.isPulseGuidingDec = true;
        //        TelescopeHardware.guideDuration.Y = GuideDuration();
        //    }
        //    else
        //    {
        //        if (TelescopeHardware.SouthernHemisphere)
        //        {
        //            guideRateRa *= -1;
        //        }
        //        TelescopeHardware.GuideRateRightAscension = guideRateRa;
        //        TelescopeHardware.isPulseGuiding = true;
        //        TelescopeHardware.guideDuration.X = GuideDuration();
        //    }
        //}

        private static int GuideDuration()
        {
            int duration = GuideDurationShort;

            if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                duration = GuideDurationMedium;
            }
            else if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
            {
                duration = GuideDurationLong;
            }
            return duration;
        }

        private static double GetSlewSpeed()
        {
            if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                return SlewMedium;
            }
            else if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
            {
                return SlewSlow;
            }
            else
            {
                return SlewFast;
            }
        }

        private void StartSlewGuide(SlewDirection direction)
        {
            try
            {
                if (this.radioButtonPulseGuide.Checked)
                {
                    // Do Pulse Guiding instead
                    GuideDirections dir = GuideDirections.guideEast;
                    switch (direction)
                    {
                        case SlewDirection.SlewNorth:
                        case SlewDirection.SlewUp:
                            dir = GuideDirections.guideNorth;
                            break;
                        case SlewDirection.SlewSouth:
                        case SlewDirection.SlewDown:
                            dir = GuideDirections.guideSouth;
                            break;
                        case SlewDirection.SlewEast:
                        case SlewDirection.SlewRight:
                            dir = GuideDirections.guideEast;
                            break;
                        case SlewDirection.SlewWest:
                        case SlewDirection.SlewLeft:
                            dir = GuideDirections.guideWest;
                            break;
                        case SlewDirection.SlewNone:
                        default:
                            return;
                    }
                    TelescopeHardware.Guide(dir, GuideDuration());
                    return;
                }
                double rate = GetSlewSpeed();
                TelescopeAxes axes = TelescopeAxes.axisPrimary;
                //if (TelescopeHardware.AlignmentMode == DeviceInterface.AlignmentModes.algAltAz)
                //{
                //    slewDirection = direction;
                //}
                //else
                //{
                switch (direction)
                {
                    case SlewDirection.SlewEast:
                    case SlewDirection.SlewRight:
                        axes = TelescopeAxes.axisPrimary;
                        break;
                    case SlewDirection.SlewWest:
                    case SlewDirection.SlewLeft:
                        axes = TelescopeAxes.axisPrimary;
                        rate = -rate;
                        break;
                    case SlewDirection.SlewNorth:
                    case SlewDirection.SlewUp:
                        axes = TelescopeAxes.axisSecondary;
                        break;
                    case SlewDirection.SlewSouth:
                    case SlewDirection.SlewDown:
                        axes = TelescopeAxes.axisSecondary;
                        rate = -rate;
                        break;
                    case SlewDirection.SlewNone:
                    default:
                        return;
                }
                //}
                TelescopeHardware.MoveAxis(axes, rate);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.ToString(), MessageBoxButtons.OK);
            }
        }

        private void StopSlew(SlewDirection direction)
        {
            try
            {
                if (this.radioButtonPulseGuide.Checked)
                {
                    // Nothing to do for pulse guiding here.
                    return;
                }
                TelescopeAxes axes = TelescopeAxes.axisPrimary;
                switch (direction)
                {
                    case SlewDirection.SlewEast:
                    case SlewDirection.SlewRight:
                    case SlewDirection.SlewWest:
                    case SlewDirection.SlewLeft:
                        axes = TelescopeAxes.axisPrimary;
                        break;
                    case SlewDirection.SlewNorth:
                    case SlewDirection.SlewUp:
                    case SlewDirection.SlewSouth:
                    case SlewDirection.SlewDown:
                        axes = TelescopeAxes.axisSecondary;
                        break;
                    case SlewDirection.SlewNone:
                    default:
                        break;
                }
                TelescopeHardware.MoveAxis(axes, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.ToString(), MessageBoxButtons.OK);
            }
        }

        private void ButtonSlewUp_MouseDown(object sender, MouseEventArgs e)
        {
            StartSlewGuide(SlewDirection.SlewUp);
        }

        private void ButtonSlewUp_MouseUp(object sender, MouseEventArgs e)
        {
            //SetPulseGuideParms(guideRate, 0.0);
            StopSlew(SlewDirection.SlewUp);
        }

        private void ButtonSlewDown_MouseDown(object sender, MouseEventArgs e)
        {
            StartSlewGuide(SlewDirection.SlewDown);
        }

        private void ButtonSlewDown_MouseUp(object sender, MouseEventArgs e)
        {
            //SetPulseGuideParms(-guideRate, 0.0);
            StopSlew(SlewDirection.SlewDown);
        }

        private void ButtonSlewRight_MouseDown(object sender, MouseEventArgs e)
        {
            StartSlewGuide(SlewDirection.SlewRight);
        }

        private void ButtonSlewRight_MouseUp(object sender, MouseEventArgs e)
        {
            //SetPulseGuideParms(0.0, guideRate);
            StopSlew(SlewDirection.SlewRight);
        }

        private void ButtonSlewLeft_MouseDown(object sender, MouseEventArgs e)
        {
            StartSlewGuide(SlewDirection.SlewLeft);
        }

        private void ButtonSlewLeft_MouseUp(object sender, MouseEventArgs e)
        {
            //SetPulseGuideParms(0.0, -guideRate);
            StopSlew(SlewDirection.SlewLeft);
        }

        private void ButtonSlewStop_Click(object sender, EventArgs e)
        {
            try
            {
                TelescopeHardware.AbortSlew();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.ToString(), MessageBoxButtons.OK);
            }
        }
        #endregion

        private void CheckBoxTrack_CheckedChanged(object sender, EventArgs e)
        {
            if (TelescopeHardware.Tracking == checkBoxTrack.Checked)
                return;
            try
            {
                TelescopeHardware.Tracking = checkBoxTrack.Checked;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.ToString(), MessageBoxButtons.OK);
            }
        }

        public void Tracking()
        {
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    if (TelescopeHardware.Tracking == checkBoxTrack.Checked)
                        return;
                    // this avoids triggering the checked changed event
                    checkBoxTrack.CheckState = TelescopeHardware.Tracking ? CheckState.Checked : CheckState.Unchecked;
                });
            }
            catch { }
        }

        public void LedPier(ASCOM.DeviceInterface.PierSide sideOfPier)
        {
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    if (sideOfPier == ASCOM.DeviceInterface.PierSide.pierEast)
                    {
                        ledPierEast.Status = TrafficLight.Green;
                        ledPierEast.Visible = true;
                        ledPierWest.Visible = false;
                    }
                    else
                    {
                        ledPierWest.Status = TrafficLight.Red;
                        ledPierWest.Visible = true;
                        ledPierEast.Visible = false;
                    }
                });
            }
            catch
            { }
        }

        public void LabelState(Label label, bool state)
        {
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    label.ForeColor = state ? Color.Red : Color.SaddleBrown;
                });
            }
            catch { }
        }

        private void ButtonPark_Click(object sender, EventArgs e)
        {
            try
            {
                if (TelescopeHardware.AtPark)
                {
                    TelescopeHardware.AtPark = false;
                    TelescopeHardware.Tracking = true;
                    if (!TelescopeHardware.AtPark)
                        buttonPark.Text = "Park";
                }
                else
                {
                    TelescopeHardware.AtPark = true;
                    TelescopeHardware.Tracking = false;
                    if (TelescopeHardware.AtPark)
                        buttonPark.Text = "Unpark";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.ToString(), MessageBoxButtons.OK);
            }
        }

        private void ButtonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (SharedResources.Connected)
                {
                    SharedResources.Connected = false;
                    if (!SharedResources.Connected)
                        buttonConnect.Text = "Connect";
                }
                else
                {
                    if (buttonConnect.Text == "Disconn")
                    {
                        // Reset in case of error
                        buttonConnect.Text = "Connect";
                    }
                    else { 
                        SharedResources.Connected = true;
                        if (SharedResources.Connected)
                            buttonConnect.Text = "Disconn";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
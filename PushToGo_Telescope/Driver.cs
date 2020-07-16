//tabs=4
// --------------------------------------------------------------------------------
// TODO fill in this information for your driver, then remove this line!
//
// ASCOM Telescope driver for Telescope
//
// Description:	ASCOM Driver for Simulated Telescope 
//
// Implements:	ASCOM Telescope interface version: 2.0
// Author:		(rbt) Robert Turner <robert@robertturnerastro.com>
//
// Edit Log:
//
// Date			Who	Vers	Description
// -----------	---	-----	-------------------------------------------------------
// 07-JUL-2009	rbt	1.0.0	Initial edit, from ASCOM Telescope Driver template
// 29 Dec 2010  cdr         Extensive refactoring and bug fixes
// --------------------------------------------------------------------------------
//
using System;
using System.Collections;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using ASCOM.DeviceInterface;
using ASCOM.Utilities;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ASCOM.PushToGo
{
    //
    // Your driver's ID is ASCOM.Telescope.Telescope
    //
    // The Guid attribute sets the CLSID for ASCOM.Telescope.Telescope
    // The ClassInterface/None addribute prevents an empty interface called
    // _Telescope from being created and used as the [default] interface
    //

    [Guid("50680c9d-f589-4d28-9b7d-f8fff69ec40a")]
    [ProgId("ASCOM.PushToGo.Telescope")]
    [ServedClassName("PushToGo Mount Driver (Local Server)")]
    [ClassInterface(ClassInterfaceType.None)]
    public class Telescope : ReferenceCountedObjectBase, ITelescopeV3
    {
        //
        // Driver private data (rate collections)
        //
        private ASCOM.Utilities.Util m_Util;
        private string driverID;
        private long objectId;

        const string SlewToHA = "SlewToHA"; const string SlewToHAUpper = "SLEWTOHA";
        const string AssemblyVersionNumber = "AssemblyVersionNumber"; const string AssemblyVersionNumberUpper = "ASSEMBLYVERSIONNUMBER";
        const string TimeUntilPointingStateCanChange = "TIMEUNTILPOINTINGSTATECANCHANGE";
        const string AvailableTimeInThisPointingState = "AVAILABLETIMEINTHISPOINTINGSTATE";

        //
        // Constructor - Must be public for COM registration!
        //
        public Telescope()
        {
            try
            {
                driverID = Marshal.GenerateProgIdForType(this.GetType());
                m_Util = new ASCOM.Utilities.Util();
                // get a unique instance id
                objectId = TelescopeHardware.GetId();
                TelescopeHardware.TL.LogMessage("New", "Instance ID: " + objectId + ", new: " + "Driver ID: " + driverID);
            }
            catch (Exception ex)
            {
                //EventLogCode.LogEvent("ASCOM.Simulator.Telescope", "Exception on New", EventLogEntryType.Error, GlobalConstants.EventLogErrors.TelescopeSimulatorNew, ex.ToString());
                System.Windows.Forms.MessageBox.Show("Telescope New: " + ex.ToString());
            }

        }

        //
        // PUBLIC COM INTERFACE ITelescope IMPLEMENTATION
        //

        #region ITelescope Members

        public string Action(string ActionName, string ActionParameters)
        {
            //throw new MethodNotImplementedException("Action");
            string Response = "";
            if (ActionName == null)
                throw new InvalidValueException("no ActionName is provided");
            switch (ActionName.ToUpper(CultureInfo.InvariantCulture))
            {
                case AssemblyVersionNumberUpper:
                    Response = Assembly.GetExecutingAssembly().GetName().Version.ToString();
                    break;
                case SlewToHAUpper:
                    //Assume that we have just been supplied with an HA
                    //Let errors just go straight back to the caller
                    double HA = double.Parse(ActionParameters, CultureInfo.InvariantCulture);
                    double RA = this.SiderealTime - HA;
                    this.SlewToCoordinates(RA, 0.0);
                    Response = "Slew successful!";
                    break;
                //case AvailableTimeInThisPointingState:
                //    Response = TelescopeHardware.AvailableTimeInThisPointingState.ToString();
                //    break;
                //case TimeUntilPointingStateCanChange:
                //    Response = TelescopeHardware.TimeUntilPointingStateCanChange.ToString();
                //    break;
                default:
                    throw new ASCOM.InvalidOperationException("Command: '" + ActionName + "' is not recognised by the Scope Simulator .NET driver. " + AssemblyVersionNumberUpper + " " + SlewToHAUpper);
            }
            return Response;
        }

        /// <summary>
        /// Gets the supported actions.
        /// </summary>
        public ArrayList SupportedActions
        {
            // no supported actions, return empty array
            get
            {
                ArrayList sa = new ArrayList
                {
                    AssemblyVersionNumber, // Add a test action to return a value
                    SlewToHA, // Expects a numeric HA Parameter
                    //"AvailableTimeInThisPointingState",
                    //"TimeUntilPointingStateCanChange"
                };

                return sa;
            }
        }

        public void AbortSlew()
        {
            SharedResources.TrafficStart(SharedResources.MessageType.Slew, "AbortSlew: ");
            CheckParked("AbortSlew");
            TelescopeHardware.AbortSlew();

            SharedResources.TrafficEnd("(done)");
        }

        public AlignmentModes AlignmentMode
        {
            get
            {
                SharedResources.TrafficStart(SharedResources.MessageType.Capabilities, "AlignmentMode: ");
                CheckCapability(TelescopeHardware.CanAlignmentMode, "AlignmentMode");
                SharedResources.TrafficEnd(TelescopeHardware.AlignmentMode.ToString());

                switch (TelescopeHardware.AlignmentMode)
                {
                    case AlignmentModes.algAltAz:
                        return AlignmentModes.algAltAz;
                    case AlignmentModes.algGermanPolar:
                        return AlignmentModes.algGermanPolar;
                    case AlignmentModes.algPolar:
                        return AlignmentModes.algPolar;
                    default:
                        return AlignmentModes.algGermanPolar;
                }
            }
        }

        public double Altitude
        {
            get
            {
                SharedResources.TrafficStart(SharedResources.MessageType.Gets, "Altitude: ");
                CheckCapability(TelescopeHardware.CanAltAz, "Altitude", false);
                //if ((TelescopeHardware.AtPark || TelescopeHardware.SlewState == SlewType.SlewPark) && TelescopeHardware.NoCoordinatesAtPark)
                //{
                //    SharedResources.TrafficEnd("No coordinates at park!");
                //    throw new PropertyNotImplementedException("Altitude", false);
                //}
                SharedResources.TrafficEnd(m_Util.DegreesToDMS(TelescopeHardware.Altitude));
                return TelescopeHardware.Altitude;
            }
        }

        public double ApertureArea
        {
            get
            {
                SharedResources.TrafficStart(SharedResources.MessageType.Other, "ApertureArea: ");
                CheckCapability(TelescopeHardware.CanOptics, "ApertureArea", false);
                SharedResources.TrafficEnd(TelescopeHardware.ApertureArea.ToString(CultureInfo.InvariantCulture));
                return TelescopeHardware.ApertureArea;
            }
        }

        public double ApertureDiameter
        {
            get
            {
                SharedResources.TrafficStart(SharedResources.MessageType.Other, "ApertureDiameter: ");
                CheckCapability(TelescopeHardware.CanOptics, "ApertureDiameter", false);
                SharedResources.TrafficEnd(TelescopeHardware.ApertureDiameter.ToString(CultureInfo.InvariantCulture));
                return TelescopeHardware.ApertureDiameter;
            }
        }

        public bool AtHome
        {
            get
            {
                SharedResources.TrafficLine(SharedResources.MessageType.Polls, "AtHome: " + TelescopeHardware.AtHome);
                return TelescopeHardware.AtHome;
            }
        }

        public bool AtPark
        {
            get
            {
                SharedResources.TrafficLine(SharedResources.MessageType.Polls, "AtPark: " + TelescopeHardware.AtPark);
                return TelescopeHardware.AtPark;
            }
        }

        public IAxisRates AxisRates(TelescopeAxes Axis)
        {
            double maxRate = TelescopeHardware.MaximumSlewRate;
            return new AxisRates(Axis, maxRate);
        }

        public double Azimuth
        {
            get
            {
                SharedResources.TrafficStart(SharedResources.MessageType.Gets, "Azimuth: ");

                CheckCapability(TelescopeHardware.CanAltAz, "Azimuth", false);

                //if ((TelescopeHardware.AtPark || TelescopeHardware.SlewState == SlewType.SlewPark) && TelescopeHardware.NoCoordinatesAtPark)
                //{
                //    SharedResources.TrafficEnd("No coordinates at park!");
                //    throw new PropertyNotImplementedException("Azimuth", false);
                //}
                SharedResources.TrafficEnd(m_Util.DegreesToDMS(TelescopeHardware.Azimuth));
                return TelescopeHardware.Azimuth;
            }
        }

        public bool CanFindHome
        {
            get
            {
                SharedResources.TrafficLine(SharedResources.MessageType.Capabilities, "CanFindHome: " + TelescopeHardware.CanFindHome);
                return TelescopeHardware.CanFindHome;
            }
        }

        public bool CanMoveAxis(TelescopeAxes Axis)
        {
            SharedResources.TrafficStart(SharedResources.MessageType.Capabilities, string.Format(CultureInfo.CurrentCulture, "CanMoveAxis {0}: ", Axis.ToString()));
            SharedResources.TrafficEnd(TelescopeHardware.CanMoveAxis(Axis).ToString());

            return TelescopeHardware.CanMoveAxis(Axis);
        }

        public bool CanPark
        {
            get
            {
                SharedResources.TrafficLine(SharedResources.MessageType.Capabilities, "CanPark: " + TelescopeHardware.CanPark);
                return TelescopeHardware.CanPark;
            }
        }

        public bool CanPulseGuide
        {
            get
            {
                SharedResources.TrafficLine(SharedResources.MessageType.Capabilities, "CanPulseGuide: " + TelescopeHardware.CanPulseGuide);
                return TelescopeHardware.CanPulseGuide;
            }
        }

        public bool CanSetDeclinationRate
        {
            get
            {
                SharedResources.TrafficStart(SharedResources.MessageType.Capabilities, "CanSetDeclinationRate: ");
                SharedResources.TrafficEnd(TelescopeHardware.CanSetDeclinationRate.ToString());
                return TelescopeHardware.CanSetDeclinationRate;
            }
        }

        public bool CanSetGuideRates
        {
            get
            {
                SharedResources.TrafficLine(SharedResources.MessageType.Capabilities, "CanSetGuideRates: " + TelescopeHardware.CanSetGuideRates);
                return TelescopeHardware.CanSetGuideRates;
            }
        }

        public bool CanSetPark
        {
            get
            {
                SharedResources.TrafficLine(SharedResources.MessageType.Capabilities, "CanSetPark: " + TelescopeHardware.CanSetPark);
                return TelescopeHardware.CanSetPark;
            }
        }

        public bool CanSetPierSide
        {
            get
            {
                SharedResources.TrafficStart(SharedResources.MessageType.Capabilities, "CanSetPierSide: ");
                SharedResources.TrafficEnd(TelescopeHardware.CanSetPierSide.ToString());
                return TelescopeHardware.CanSetPierSide;
            }
        }

        public bool CanSetRightAscensionRate
        {
            get
            {
                SharedResources.TrafficStart(SharedResources.MessageType.Capabilities, "CanSetRightAscensionRate: ");
                SharedResources.TrafficEnd(TelescopeHardware.CanSetRightAscensionRate.ToString());
                return TelescopeHardware.CanSetRightAscensionRate;
            }
        }

        public bool CanSetTracking
        {
            get
            {
                SharedResources.TrafficLine(SharedResources.MessageType.Capabilities, "CanSetTracking: " + TelescopeHardware.CanSetTracking);
                return TelescopeHardware.CanSetTracking;
            }
        }

        public bool CanSlew
        {
            get
            {
                SharedResources.TrafficLine(SharedResources.MessageType.Capabilities, "CanSlew: " + TelescopeHardware.CanSlew);
                return TelescopeHardware.CanSlew;
            }
        }

        public bool CanSlewAltAz
        {
            get
            {
                SharedResources.TrafficStart(SharedResources.MessageType.Capabilities, "CanSlewAltAz: ");
                SharedResources.TrafficEnd(TelescopeHardware.CanSlewAltAz.ToString());
                return TelescopeHardware.CanSlewAltAz;
            }
        }

        public bool CanSlewAltAzAsync
        {
            get
            {
                SharedResources.TrafficStart(SharedResources.MessageType.Capabilities, "CanSlewAltAzAsync: ");
                SharedResources.TrafficEnd(TelescopeHardware.CanSlewAltAzAsync.ToString());
                return TelescopeHardware.CanSlewAltAzAsync;
            }
        }

        public bool CanSlewAsync
        {
            get
            {
                SharedResources.TrafficLine(SharedResources.MessageType.Capabilities, "CanSlewAsync: " + TelescopeHardware.CanSlewAsync);
                return TelescopeHardware.CanSlewAsync;
            }
        }

        public bool CanSync
        {
            get
            {
                SharedResources.TrafficLine(SharedResources.MessageType.Capabilities, "CanSync: " + TelescopeHardware.CanSync);
                return TelescopeHardware.CanSync;
            }
        }

        public bool CanSyncAltAz
        {
            get
            {
                SharedResources.TrafficStart(SharedResources.MessageType.Capabilities, "CanSyncAltAz: ");
                SharedResources.TrafficEnd(TelescopeHardware.CanSyncAltAz.ToString());
                return TelescopeHardware.CanSyncAltAz;
            }
        }

        public bool CanUnpark
        {
            get
            {
                SharedResources.TrafficLine(SharedResources.MessageType.Capabilities, "CanUnPark: " + TelescopeHardware.CanUnpark);
                return TelescopeHardware.CanUnpark;
            }
        }

        public void CommandBlind(string Command, bool Raw)
        {
            // TODO Replace this with your implementation
            throw new MethodNotImplementedException("CommandBlind");
        }

        public bool CommandBool(string Command, bool Raw)
        {
            // TODO Replace this with your implementation
            throw new MethodNotImplementedException("CommandBool");
        }

        public string CommandString(string Command, bool Raw)
        {
            // TODO Replace this with your implementation
            throw new MethodNotImplementedException("CommandString");
        }

        public bool Connected
        {
            get
            {
                var connected = TelescopeHardware.Connected;
                SharedResources.TrafficLine(SharedResources.MessageType.Other, "Connected = " + connected.ToString());
                TelescopeHardware.TL.LogMessage("Connected Get", connected.ToString());
                return connected;
            }
            set
            {
                SharedResources.TrafficLine(SharedResources.MessageType.Other, "Set Connected to " + value.ToString());
                TelescopeHardware.TL.LogMessage("Connected Set", value.ToString());
                if (value)
                    TelescopeHardware.Connect(objectId);
                else
                    TelescopeHardware.Disconnect(objectId);
            }
        }

        public double Declination
        {
            get
            {
                SharedResources.TrafficStart(SharedResources.MessageType.Gets, "Declination: ");

                CheckCapability(TelescopeHardware.CanEquatorial, "Declination", false);

                //if ((TelescopeHardware.AtPark || TelescopeHardware.SlewState == SlewType.SlewPark) && TelescopeHardware.NoCoordinatesAtPark)
                //{
                //    SharedResources.TrafficEnd("No coordinates at park!");
                //    throw new PropertyNotImplementedException("Declination", false);
                //}
                SharedResources.TrafficEnd(m_Util.DegreesToDMS(TelescopeHardware.Declination));
                return TelescopeHardware.Declination;
            }
        }

        public double DeclinationRate
        {
            get
            {
                SharedResources.TrafficLine(SharedResources.MessageType.Gets, "DeclinationRate: " + TelescopeHardware.DeclinationRate);
                return TelescopeHardware.DeclinationRate;
            }
            set
            {
                SharedResources.TrafficLine(SharedResources.MessageType.Gets, "DeclinationRate:-> " + value);
                TelescopeHardware.DeclinationRate = value;
            }
        }

        public string Description
        {
            get
            {
                var desc = ((ServedClassNameAttribute)Attribute.GetCustomAttribute(typeof(Telescope), typeof(ServedClassNameAttribute))).DisplayName;
                SharedResources.TrafficLine(SharedResources.MessageType.Gets, "Description: " + desc);
                return desc;
            }
        }

        public PierSide DestinationSideOfPier(double RightAscension, double Declination)
        {
            SharedResources.TrafficStart(SharedResources.MessageType.Other, "DestinationSideOfPier: ");
            SharedResources.TrafficStart(string.Format(CultureInfo.CurrentCulture, "Ra {0}, Dec {1} - ", RightAscension, Declination));

            double ha = SiderealTime - RightAscension; // Hour angle
            ha = Math.IEEERemainder(ha, 24.0); // -12h ~ 12h

            PierSide side;
            if (ha <= 0)
            {
                side = PierSide.pierWest;
            }
            else
            {
                side = PierSide.pierEast;
            }

            SharedResources.TrafficEnd(side.ToString());
            return side;
        }

        public bool DoesRefraction
        {
            get
            {
                SharedResources.TrafficStart(SharedResources.MessageType.Capabilities, "DoesRefraction: ");
                SharedResources.TrafficEnd(TelescopeHardware.Refraction.ToString());
                return TelescopeHardware.Refraction;
            }
            set
            {
                SharedResources.TrafficStart(SharedResources.MessageType.Capabilities, "DoesRefraction: ->");
                SharedResources.TrafficEnd(value.ToString());
                TelescopeHardware.Refraction = value;
            }
        }

        public string DriverInfo
        {
            get
            {
                Assembly asm = Assembly.GetExecutingAssembly();

                string driverinfo = asm.FullName;

                SharedResources.TrafficLine(SharedResources.MessageType.Other, "DriverInfo: " + driverinfo);
                return driverinfo;
            }
        }

        public string DriverVersion
        {
            get
            {
                SharedResources.TrafficStart(SharedResources.MessageType.Other, "DriverVersion: ");
                Assembly asm = Assembly.GetExecutingAssembly();

                string driverinfo = asm.GetName().Version.ToString();

                SharedResources.TrafficEnd(driverinfo);
                return driverinfo;
            }
        }

        public EquatorialCoordinateType EquatorialSystem
        {
            get
            {
                SharedResources.TrafficStart(SharedResources.MessageType.Other, "EquatorialSystem: ");
                string output = "";
                EquatorialCoordinateType eq = EquatorialCoordinateType.equOther;

                //switch (TelescopeHardware.EquatorialSystem)
                //{
                //    case 0:
                //        eq = EquatorialCoordinateType.equOther;
                //        output = "Other";
                //        break;

                //    case 1:
                //        eq = EquatorialCoordinateType.equTopocentric;
                //        output = "Local";
                //        break;
                //    case 2:
                eq = EquatorialCoordinateType.equJ2000;
                output = "J2000";
                //        break;
                //    case 3:
                //        eq = EquatorialCoordinateType.equJ2050;
                //        output = "J2050";
                //        break;
                //    case 4:
                //        eq = EquatorialCoordinateType.equB1950;
                //        output = "B1950";
                //        break;
                //}
                SharedResources.TrafficEnd(output);
                return eq;
            }
        }

        public void FindHome()
        {
            SharedResources.TrafficStart(SharedResources.MessageType.Slew, "FindHome: ");
            CheckCapability(TelescopeHardware.CanFindHome, "FindHome");

            CheckParked("FindHome");

            //TelescopeHardware.FindHome();

            //while (TelescopeHardware.SlewState == SlewType.SlewHome || TelescopeHardware.SlewState == SlewType.SlewSettle)
            //{
            //    System.Windows.Forms.Application.DoEvents();
            //}

            SharedResources.TrafficEnd(SharedResources.MessageType.Slew, "(done)");
        }

        public double FocalLength
        {
            get
            {
                SharedResources.TrafficStart(SharedResources.MessageType.Other, "FocalLength: ");
                CheckCapability(TelescopeHardware.CanOptics, "FocalLength", false);
                SharedResources.TrafficEnd(TelescopeHardware.FocalLength.ToString(CultureInfo.InvariantCulture));
                return TelescopeHardware.FocalLength;
            }
        }

        public double GuideRateDeclination
        {
            get
            {
                SharedResources.TrafficStart(SharedResources.MessageType.Gets, "GuideRateDeclination: ");
                SharedResources.TrafficEnd(TelescopeHardware.GuideRateDeclination.ToString(CultureInfo.InvariantCulture));
                return TelescopeHardware.GuideRateDeclination;
            }
            set
            {
                SharedResources.TrafficStart(SharedResources.MessageType.Gets, "GuideRateDeclination->: ");
                SharedResources.TrafficEnd(value.ToString(CultureInfo.InvariantCulture));
                TelescopeHardware.GuideRateDeclination = value;
            }
        }

        public double GuideRateRightAscension
        {
            get
            {
                SharedResources.TrafficStart(SharedResources.MessageType.Gets, "GuideRateRightAscension: ");
                SharedResources.TrafficEnd(TelescopeHardware.GuideRateRightAscension.ToString(CultureInfo.InvariantCulture));
                return TelescopeHardware.GuideRateRightAscension;
            }
            set
            {
                SharedResources.TrafficStart(SharedResources.MessageType.Gets, "GuideRateRightAscension->: ");
                SharedResources.TrafficEnd(value.ToString(CultureInfo.InvariantCulture));
                TelescopeHardware.GuideRateRightAscension = value;
            }
        }

        public short InterfaceVersion
        {
            get
            {
                SharedResources.TrafficLine(SharedResources.MessageType.Other, "InterfaceVersion: 3");
                return 3;
            }
        }

        public bool IsPulseGuiding
        {
            get
            {
                SharedResources.TrafficStart(SharedResources.MessageType.Polls, "IsPulseGuiding: ");
                // TODO Is this correct, should it just return false?
                CheckCapability(TelescopeHardware.CanPulseGuide, "IsPulseGuiding", false);
                SharedResources.TrafficEnd(TelescopeHardware.IsPulseGuiding.ToString());

                return TelescopeHardware.IsPulseGuiding;
            }
        }

        public void MoveAxis(TelescopeAxes Axis, double Rate)
        {
            SharedResources.TrafficStart(SharedResources.MessageType.Slew, string.Format(CultureInfo.CurrentCulture, "MoveAxis {0} {1}:  ", Axis.ToString(), Rate));
            CheckRate(Axis, Rate);

            if (!CanMoveAxis(Axis))
                throw new MethodNotImplementedException("CanMoveAxis " + Enum.GetName(typeof(TelescopeAxes), Axis));

            CheckParked("MoveAxis");

            TelescopeHardware.MoveAxis(Axis, Rate);

            SharedResources.TrafficEnd("(done)");
        }

        public string Name
        {
            get
            {
                SharedResources.TrafficLine(SharedResources.MessageType.Other, "Description: " + driverID);
                return driverID;
            }
        }

        public void Park()
        {
            SharedResources.TrafficStart(SharedResources.MessageType.Slew, "Park: ");
            CheckCapability(TelescopeHardware.CanPark, "Park");

            if (TelescopeHardware.AtPark)
            {
                SharedResources.TrafficEnd("(Is Parked)");
                return;
            }

            TelescopeHardware.Tracking = false;
            TelescopeHardware.AtPark = true;

            SharedResources.TrafficEnd("(done)");
        }

        public void PulseGuide(GuideDirections Direction, int Duration)
        {
            if (TelescopeHardware.AtPark) throw new ParkedException();

            SharedResources.TrafficStart(SharedResources.MessageType.Slew, string.Format(CultureInfo.CurrentCulture, "Pulse Guide: {0}, {1}", Direction, Duration.ToString(CultureInfo.InvariantCulture)));

            CheckCapability(TelescopeHardware.CanPulseGuide, "PulseGuide");
            CheckRange(Duration, 0, 30000, "PulseGuide", "Duration");
            TelescopeHardware.Guide(Direction, Duration);
            SharedResources.TrafficEnd(" (done) ");
        }

        public double RightAscension
        {
            get
            {
                SharedResources.TrafficStart(SharedResources.MessageType.Gets, "Right Ascension: ");

                CheckCapability(TelescopeHardware.CanEquatorial, "RightAscension", false);

                //if ((TelescopeHardware.AtPark || TelescopeHardware.SlewState == SlewType.SlewPark) && TelescopeHardware.NoCoordinatesAtPark)
                //{
                //    SharedResources.TrafficEnd("No coordinates at park!");
                //    throw new PropertyNotImplementedException("RightAscension", false);
                //}
                SharedResources.TrafficEnd(m_Util.HoursToHMS(TelescopeHardware.RightAscension));
                return TelescopeHardware.RightAscension;
            }
        }

        public double RightAscensionRate
        {
            get
            {
                SharedResources.TrafficLine(SharedResources.MessageType.Gets, "RightAscensionRate->: (done)");
                return TelescopeHardware.RightAscensionRate;
            }
            set
            {
                SharedResources.TrafficStart(SharedResources.MessageType.Gets, "RightAscensionRate =- ");
                CheckCapability(TelescopeHardware.CanSetEquatorialRates, "RightAscensionRate", true);
                TelescopeHardware.RightAscensionRate = value;
                SharedResources.TrafficEnd(value.ToString(CultureInfo.InvariantCulture));
            }
        }

        public void SetPark()
        {
            SharedResources.TrafficStart(SharedResources.MessageType.Other, "Set Park: ");
            CheckCapability(TelescopeHardware.CanSetPark, "SetPark");
            SharedResources.TrafficEnd("(done)");
        }

        public void SetupDialog()
        {
            if (TelescopeHardware.Connected)
                throw new InvalidOperationException("The hardware is connected, cannot do SetupDialog()");
            try
            {
                PushToGo.m_MainForm.DoSetupDialog();
            }
            catch (Exception ex)
            {
                //EventLogCode.LogEvent("ASCOM.Simulator.Telescope", "Exception on SetupDialog", EventLogEntryType.Error, GlobalConstants.EventLogErrors.TelescopeSimulatorSetup, ex.ToString());
                System.Windows.Forms.MessageBox.Show("Telescope SetUp: " + ex.ToString());
            }
        }

        public PierSide SideOfPier
        {
            get
            {
                SharedResources.TrafficLine(SharedResources.MessageType.Polls, string.Format("SideOfPier: {0}", TelescopeHardware.SideOfPier));
                return TelescopeHardware.SideOfPier;
            }
            set
            {
                SharedResources.TrafficStart(SharedResources.MessageType.Slew, "SideOfPier: ");
                CheckCapability(TelescopeHardware.CanSetPierSide, "SideOfPier", true);
                SharedResources.TrafficEnd("(started)");
            }
        }

        public double SiderealTime
        {
            get
            {
                SharedResources.TrafficStart(SharedResources.MessageType.Time, "Sidereal Time: ");
                CheckCapability(TelescopeHardware.CanSiderealTime, "SiderealTime", false);
                SharedResources.TrafficEnd(m_Util.HoursToHMS(TelescopeHardware.SiderealTime));
                return TelescopeHardware.SiderealTime;
            }
        }

        public double SiteElevation
        {
            get
            {
                SharedResources.TrafficStart(SharedResources.MessageType.Other, "SiteElevation: ");

                CheckCapability(TelescopeHardware.CanLatLongElev, "SiteElevation", false);
                SharedResources.TrafficEnd(TelescopeHardware.Elevation.ToString(CultureInfo.InvariantCulture));
                return TelescopeHardware.Elevation;
            }
            set
            {
                SharedResources.TrafficStart(SharedResources.MessageType.Other, "SiteElevation: ->");
                CheckCapability(TelescopeHardware.CanLatLongElev, "SiteElevation", true);
                CheckRange(value, -300, 10000, "SiteElevation");
                SharedResources.TrafficEnd(value.ToString(CultureInfo.InvariantCulture));
                TelescopeHardware.Elevation = value;
            }
        }

        public double SiteLatitude
        {
            get
            {
                SharedResources.TrafficStart(SharedResources.MessageType.Other, "SiteLatitude: ");

                CheckCapability(TelescopeHardware.CanLatLongElev, "SiteLatitude", false);
                SharedResources.TrafficEnd(TelescopeHardware.Latitude.ToString(CultureInfo.InvariantCulture));
                return TelescopeHardware.Latitude;
            }
            set
            {
                SharedResources.TrafficStart(SharedResources.MessageType.Other, "SiteLatitude: ->");
                CheckCapability(TelescopeHardware.CanLatLongElev, "SiteLatitude", true);
                CheckRange(value, -90, 90, "SiteLatitude");
                SharedResources.TrafficEnd(value.ToString(CultureInfo.InvariantCulture));
                TelescopeHardware.Latitude = value;
            }
        }

        public double SiteLongitude
        {
            get
            {
                SharedResources.TrafficStart(SharedResources.MessageType.Other, "SiteLongitude: ");
                CheckCapability(TelescopeHardware.CanLatLongElev, "SiteLongitude", false);
                SharedResources.TrafficEnd(TelescopeHardware.Longitude.ToString(CultureInfo.InvariantCulture));
                return TelescopeHardware.Longitude;
            }
            set
            {
                SharedResources.TrafficStart(SharedResources.MessageType.Other, "SiteLongitude: ->");
                CheckCapability(TelescopeHardware.CanLatLongElev, "SiteLongitude", true);
                CheckRange(value, -180, 180, "SiteLongitude");
                SharedResources.TrafficEnd(value.ToString(CultureInfo.InvariantCulture));
                TelescopeHardware.Longitude = value;
            }
        }

        public short SlewSettleTime
        {
            get
            {
                SharedResources.TrafficLine(SharedResources.MessageType.Other, "SlewSettleTime: " + (TelescopeHardware.SlewSettleTime * 1000).ToString(CultureInfo.InvariantCulture));
                return (short)(TelescopeHardware.SlewSettleTime * 1000);
            }
            set
            {
                SharedResources.TrafficStart(SharedResources.MessageType.Other, "SlewSettleTime:-> ");
                CheckRange(value, 0, 100, "SlewSettleTime");
                SharedResources.TrafficEnd(value + " (done)");
                TelescopeHardware.SlewSettleTime = value / 1000;
            }
        }

        public void SlewToAltAz(double Azimuth, double Altitude)
        {
            SharedResources.TrafficStart(SharedResources.MessageType.Slew, "SlewToAltAz: ");
            CheckCapability(TelescopeHardware.CanSlewAltAz, "SlewToAltAz");
            CheckParked("SlewToAltAz");
            CheckTracking(false, "SlewToAltAz");
            CheckRange(Azimuth, 0, 360, "SlewToltAz", "azimuth");
            CheckRange(Altitude, -90, 90, "SlewToAltAz", "Altitude");

            SharedResources.TrafficStart(" Alt " + m_Util.DegreesToDMS(Altitude) + " Az " + m_Util.DegreesToDMS(Azimuth));

            TelescopeHardware.SlewAltAz(Azimuth, Altitude, true);
            SharedResources.TrafficEnd(" done");
        }

        public void SlewToAltAzAsync(double Azimuth, double Altitude)
        {
            SharedResources.TrafficStart(SharedResources.MessageType.Slew, "SlewToAltAzAsync: ");
            CheckCapability(TelescopeHardware.CanSlewAltAzAsync, "SlewToAltAzAsync");
            CheckParked("SlewToAltAz");
            CheckTracking(false, "SlewToAltAzAsync");
            CheckRange(Azimuth, 0, 360, "SlewToAltAzAsync", "Azimuth");
            CheckRange(Altitude, -90, 90, "SlewToAltAzAsync", "Altitude");

            SharedResources.TrafficStart(" Alt " + m_Util.DegreesToDMS(Altitude) + " Az " + m_Util.DegreesToDMS(Azimuth));

            TelescopeHardware.SlewAltAz(Azimuth, Altitude, false);
            SharedResources.TrafficEnd(" started");
        }

        public void SlewToCoordinates(double RightAscension, double Declination)
        {
            SharedResources.TrafficStart(SharedResources.MessageType.Slew, "SlewToCoordinates: ");
            CheckCapability(TelescopeHardware.CanSlew, "SlewToCoordinates");
            CheckRange(RightAscension, 0, 24, "SlewToCoordinates", "RightAscension");
            CheckRange(Declination, -90, 90, "SlewToCoordinates", "Declination");
            CheckParked("SlewToCoordinates");
            CheckTracking(true, "SlewToCoordinates");

            SharedResources.TrafficStart(" RA " + m_Util.HoursToHMS(RightAscension) + " DEC " + m_Util.DegreesToDMS(Declination));

            TelescopeHardware.TargetRightAscension = RightAscension; // Set the Target RA and Dec prior to the Slew attempt per the ASCOM Telescope specification
            TelescopeHardware.TargetDeclination = Declination;

            TelescopeHardware.SlewTarget(true);

            SharedResources.TrafficEnd("done");
        }

        public void SlewToCoordinatesAsync(double RightAscension, double Declination)
        {
            SharedResources.TrafficStart(SharedResources.MessageType.Slew, "SlewToCoordinatesAsync: ");
            CheckCapability(TelescopeHardware.CanSlewAsync, "SlewToCoordinatesAsync");
            CheckRange(RightAscension, 0, 24, "SlewToCoordinatesAsync", "RightAscension");
            CheckRange(Declination, -90, 90, "SlewToCoordinatesAsync", "Declination");
            CheckParked("SlewToCoordinatesAsync");
            CheckTracking(true, "SlewToCoordinatesAsync");

            TelescopeHardware.TargetRightAscension = RightAscension; // Set the Target RA and Dec prior to the Slew attempt per the ASCOM Telescope specification
            TelescopeHardware.TargetDeclination = Declination;

            SharedResources.TrafficStart(" RA " + m_Util.HoursToHMS(RightAscension) + " DEC " + m_Util.DegreesToDMS(Declination));

            TelescopeHardware.SlewTarget(false);

            SharedResources.TrafficEnd("started");
        }

        public void SlewToTarget()
        {
            SharedResources.TrafficStart(SharedResources.MessageType.Slew, "SlewToTarget: ");
            CheckCapability(TelescopeHardware.CanSlew, "SlewToTarget");
            CheckRange(TelescopeHardware.TargetRightAscension, 0, 24, "SlewToTarget", "TargetRightAscension");
            CheckRange(TelescopeHardware.TargetDeclination, -90, 90, "SlewToTarget", "TargetDeclination");
            CheckParked("SlewToTarget");
            CheckTracking(true, "SlewToTarget");

            TelescopeHardware.SlewTarget(true);

            SharedResources.TrafficEnd("done");
        }

        public void SlewToTargetAsync()
        {
            SharedResources.TrafficStart(SharedResources.MessageType.Slew, "SlewToTargetAsync: ");
            CheckCapability(TelescopeHardware.CanSlewAsync, "SlewToTargetAsync");
            CheckRange(TelescopeHardware.TargetRightAscension, 0, 24, "SlewToTargetAsync", "TargetRightAscension");
            CheckRange(TelescopeHardware.TargetDeclination, -90, 90, "SlewToTargetAsync", "TargetDeclination");
            CheckParked("SlewToTargetAsync");
            CheckTracking(true, "SlewToTargetAsync");

            TelescopeHardware.SlewTarget(false);
        }

        public bool Slewing
        {
            get
            {
                SharedResources.TrafficLine(SharedResources.MessageType.Polls, string.Format(CultureInfo.CurrentCulture, "Slewing: {0}", TelescopeHardware.IsSlewing));
                return TelescopeHardware.IsSlewing;
            }
        }

        public void SyncToAltAz(double Azimuth, double Altitude)
        {
            SharedResources.TrafficStart(SharedResources.MessageType.Slew, "SyncToAltAz: ");
            CheckCapability(TelescopeHardware.CanSyncAltAz, "SyncToAltAz");
            CheckRange(Azimuth, 0, 360, "SyncToAltAz", "Azimuth");
            CheckRange(Altitude, -90, 90, "SyncToAltAz", "Altitude");
            CheckParked("SyncToAltAz");
            CheckTracking(false, "SyncToAltAz");

            SharedResources.TrafficStart(" Alt " + m_Util.DegreesToDMS(Altitude) + " Az " + m_Util.DegreesToDMS(Azimuth));
            SharedResources.TrafficEnd("done");
        }

        public void SyncToCoordinates(double RightAscension, double Declination)
        {
            SharedResources.TrafficStart(SharedResources.MessageType.Slew, "SyncToCoordinates: ");
            CheckCapability(TelescopeHardware.CanSync, "SyncToCoordinates");
            CheckRange(RightAscension, 0, 24, "SyncToCoordinates", "RightAscension");
            CheckRange(Declination, -90, 90, "SyncToCoordinates", "Declination");
            CheckParked("SyncToCoordinates");
            CheckTracking(true, "SyncToCoordinates");

            SharedResources.TrafficStart(string.Format(CultureInfo.CurrentCulture, " RA {0} DEC {1}", m_Util.HoursToHMS(RightAscension), m_Util.DegreesToDMS(Declination)));

            TelescopeHardware.TargetDeclination = Declination;
            TelescopeHardware.TargetRightAscension = RightAscension;
            //TelescopeHardware.Declination = Declination;

            //TelescopeHardware.CalculateAltAz();
            SharedResources.TrafficEnd("done");
        }

        public void SyncToTarget()
        {
            SharedResources.TrafficStart(SharedResources.MessageType.Slew, "SyncToTarget: ");
            CheckCapability(TelescopeHardware.CanSync, "SyncToTarget");
            CheckRange(TelescopeHardware.TargetRightAscension, 0, 24, "SyncToTarget", "TargetRightAscension");
            CheckRange(TelescopeHardware.TargetDeclination, -90, 90, "SyncToTarget", "TargetDeclination");

            SharedResources.TrafficStart(" RA " + m_Util.HoursToHMS(TelescopeHardware.TargetRightAscension) + " DEC " + m_Util.DegreesToDMS(TelescopeHardware.TargetDeclination));

            CheckParked("SyncToTarget");
            CheckTracking(true, "SyncToTarget");

            //TelescopeHardware.AtPark = ;

            //TelescopeHardware.RightAscension = TelescopeHardware.TargetRightAscension;
            //TelescopeHardware.Declination = TelescopeHardware.TargetDeclination;

            //TelescopeHardware.CalculateAltAz();
            SharedResources.TrafficEnd("done");
        }

        public double TargetDeclination
        {
            get
            {
                SharedResources.TrafficStart(SharedResources.MessageType.Gets, "TargetDeclination: ");
                CheckCapability(TelescopeHardware.CanSlew, "TargetDeclination", false);
                CheckRange(TelescopeHardware.TargetDeclination, -90, 90, "TargetDeclination");
                SharedResources.TrafficEnd(m_Util.DegreesToDMS(TelescopeHardware.TargetDeclination));
                return TelescopeHardware.TargetDeclination;
            }
            set
            {
                SharedResources.TrafficStart(SharedResources.MessageType.Gets, "TargetDeclination:-> ");
                CheckCapability(TelescopeHardware.CanSlew, "TargetDeclination", true);
                CheckRange(value, -90, 90, "TargetDeclination");
                SharedResources.TrafficEnd(m_Util.DegreesToDMS(value));
                TelescopeHardware.TargetDeclination = value;
            }
        }

        public double TargetRightAscension
        {
            get
            {
                SharedResources.TrafficStart(SharedResources.MessageType.Gets, "TargetRightAscension: ");
                CheckCapability(TelescopeHardware.CanSlew, "TargetRightAscension", false);
                CheckRange(TelescopeHardware.TargetRightAscension, 0, 24, "TargetRightAscension");
                SharedResources.TrafficEnd(m_Util.HoursToHMS(TelescopeHardware.TargetRightAscension));
                return TelescopeHardware.TargetRightAscension;
            }
            set
            {
                SharedResources.TrafficStart(SharedResources.MessageType.Gets, "TargetRightAscension:-> ");
                CheckCapability(TelescopeHardware.CanSlew, "TargetRightAscension", true);
                CheckRange(value, 0, 24, "TargetRightAscension");

                SharedResources.TrafficEnd(m_Util.HoursToHMS(value));
                TelescopeHardware.TargetRightAscension = value;
            }
        }

        public bool Tracking
        {
            get
            {
                SharedResources.TrafficLine(SharedResources.MessageType.Polls, "Tracking: " + TelescopeHardware.Tracking.ToString());
                return TelescopeHardware.Tracking;
            }
            set
            {
                SharedResources.TrafficLine(SharedResources.MessageType.Polls, "Tracking:-> " + value.ToString());
                TelescopeHardware.Tracking = value;
            }
        }

        public DriveRates TrackingRate
        {
            get
            {
                DriveRates rate = TelescopeHardware.TrackingRate;
                SharedResources.TrafficStart(SharedResources.MessageType.Other, "TrackingRate: ");
                SharedResources.TrafficEnd(rate.ToString());
                return rate;
            }
            set
            {
                SharedResources.TrafficStart(SharedResources.MessageType.Other, "TrackingRate: -> ");
                TelescopeHardware.TrackingRate = value;
                SharedResources.TrafficEnd(value.ToString() + "(done)");
            }
        }

        public ITrackingRates TrackingRates
        {
            get
            {
                SharedResources.TrafficLine(SharedResources.MessageType.Other, "TrackingRates: (done)");
                ITrackingRates trackingRates = new TrackingRates();
                return trackingRates;
            }
        }

        public DateTime UTCDate
        {
            get
            {
                SharedResources.TrafficLine(SharedResources.MessageType.Time, "UTCDate: " + DateTime.UtcNow.AddSeconds((double)TelescopeHardware.DateDelta).ToString());
                return DateTime.UtcNow.AddSeconds((double)TelescopeHardware.DateDelta);
            }
            set
            {
                SharedResources.TrafficLine(SharedResources.MessageType.Time, "UTCDate-> " + value.ToString());
                TelescopeHardware.DateDelta = (int)value.Subtract(DateTime.UtcNow).TotalSeconds;
            }
        }

        public void Unpark()
        {
            SharedResources.TrafficStart(SharedResources.MessageType.Slew, "UnPark: ");
            CheckCapability(TelescopeHardware.CanUnpark, "UnPark");

            TelescopeHardware.AtPark = false;
            TelescopeHardware.Tracking = true;

            SharedResources.TrafficEnd("(done)");
        }

        #endregion

        #region new pier side properties

        //public double AvailableTimeInThisPointingState
        //{
        //    get
        //    {
        //        if (AlignmentMode != AlignmentModes.algGermanPolar)
        //        {
        //            return 86400;
        //        }
        //        return TelescopeHardware.AvailableTimeInThisPointingState;
        //    }
        //}

        //public double TimeUntilPointingStateCanChange
        //{
        //    get
        //    {
        //        if (AlignmentMode != AlignmentModes.algGermanPolar)
        //        {
        //            return 0;
        //        }
        //        return TelescopeHardware.TimeUntilPointingStateCanChange;
        //    }
        //}

        #endregion

        #region private methods
        private void CheckRate(TelescopeAxes axis, double rate)
        {
            IAxisRates rates = AxisRates(axis);
            string ratesStr = string.Empty;
            foreach (Rate item in rates)
            {
                if (Math.Abs(rate) >= item.Minimum && Math.Abs(rate) <= item.Maximum)
                {
                    return;
                }
                ratesStr = string.Format("{0}, {1} to {2}", ratesStr, item.Minimum, item.Maximum);
            }
            throw new InvalidValueException("MoveAxis", rate.ToString(CultureInfo.InvariantCulture), ratesStr);
        }

        private static void CheckRange(double value, double min, double max, string propertyOrMethod, string valueName)
        {
            if (double.IsNaN(value))
            {
                SharedResources.TrafficEnd(string.Format(CultureInfo.CurrentCulture, "{0}:{1} value has not been set", propertyOrMethod, valueName));
                throw new ValueNotSetException(propertyOrMethod + ":" + valueName);
            }
            if (value < min || value > max)
            {
                SharedResources.TrafficEnd(string.Format(CultureInfo.CurrentCulture, "{0}:{4} {1} out of range {2} to {3}", propertyOrMethod, value, min, max, valueName));
                throw new InvalidValueException(propertyOrMethod, value.ToString(CultureInfo.CurrentCulture), string.Format(CultureInfo.CurrentCulture, "{0}, {1} to {2}", valueName, min, max));
            }
        }

        private static void CheckRange(double value, double min, double max, string propertyOrMethod)
        {
            if (double.IsNaN(value))
            {
                SharedResources.TrafficEnd(string.Format(CultureInfo.CurrentCulture, "{0} value has not been set", propertyOrMethod));
                throw new ValueNotSetException(propertyOrMethod);
            }
            if (value < min || value > max)
            {
                SharedResources.TrafficEnd(string.Format(CultureInfo.CurrentCulture, "{0} {1} out of range {2} to {3}", propertyOrMethod, value, min, max));
                throw new InvalidValueException(propertyOrMethod, value.ToString(CultureInfo.CurrentCulture), string.Format(CultureInfo.CurrentCulture, "{0} to {1}", min, max));
            }
        }

        private static void CheckCapability(bool capability, string method)
        {
            if (!capability)
            {
                SharedResources.TrafficEnd(string.Format(CultureInfo.CurrentCulture, "{0} not implemented in {1}", capability, method));
                throw new MethodNotImplementedException(method);
            }
        }

        private static void CheckCapability(bool capability, string property, bool setNotGet)
        {
            if (!capability)
            {
                SharedResources.TrafficEnd(string.Format(CultureInfo.CurrentCulture, "{2} {0} not implemented in {1}", capability, property, setNotGet ? "set" : "get"));
                throw new PropertyNotImplementedException(property, setNotGet);
            }
        }

        private static void CheckParked(string property)
        {
            if (TelescopeHardware.AtPark)
            {
                SharedResources.TrafficEnd(string.Format(CultureInfo.CurrentCulture, "{0} not possible when parked", property));
                throw new ParkedException(property);
            }
        }

        /// <summary>
        /// Checks the slew type and tracking state and raises an exception if they don't match.
        /// </summary>
        /// <param name="raDecSlew">if set to <c>true</c> this is a Ra Dec slew if  <c>false</c> an Alt Az slew.</param>
        /// <param name="method">The method name.</param>
        private static void CheckTracking(bool raDecSlew, string method)
        {
            if (raDecSlew != TelescopeHardware.Tracking)
            {
                SharedResources.TrafficEnd(string.Format(CultureInfo.CurrentCulture, "{0} not possible when tracking is {1}", method, TelescopeHardware.Tracking));
                throw new ASCOM.InvalidOperationException(string.Format("{0} is not allowed when tracking is {1}", method, TelescopeHardware.Tracking));
            }
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            Connected = false;
            m_Util.Dispose();
            m_Util = null;
        }

        #endregion
    }
    
}

//
// ================
// Shared Resources
// ================
//
// This class is a container for all shared resources that may be needed
// by the drivers served by the Local Server. 
//
// NOTES:
//
//	* ALL DECLARATIONS MUST BE STATIC HERE!! INSTANCES OF THIS CLASS MUST NEVER BE CREATED!
//
// Written by:	Bob Denny	29-May-2007
//
using ASCOM.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASCOM.PushToGo
{
    public enum SlewType
    {
        SlewNone,
        SlewSettle,
        SlewMoveAxis,
        SlewRaDec,
        SlewAltAz,
        SlewPark,
        SlewHome,
        SlewHandpad
    }
    //public enum SlewSpeed
    //{
    //    SlewSlow,
    //    SlewMedium,
    //    SlewFast
    //}
    public enum SlewDirection
    {
        SlewNorth,
        SlewSouth,
        SlewEast,
        SlewWest,
        SlewUp,
        SlewDown,
        SlewLeft,
        SlewRight,
        SlewNone
    }

    public static class SharedResources
    {
        
        //private static int s_z = 0;
        private static TrafficForm m_trafficForm;               // Traffic Form 

        //private SharedResources() { }							// Prevent creation of instances

        //static SharedResources()								// Static initialization
        //{
        //}

        //Constant Definitions
        public const string PROGRAM_ID = "ASCOM.PushToGo.Telescope";  //Key used to store the settings
        public const string REGISTRATION_VERSION = "1";

        //public static double DEG_RAD = 0.0174532925;
        public const double DEG_RAD = Math.PI / 180;
        public const double RAD_DEG =  180.0 / Math.PI;        //57.2957795;
        public const double HRS_RAD = 0.2617993881;
        public const double RAD_HRS = 3.81971863;
        public const double EARTH_ANG_ROT_DEG_MIN = 0.25068447733746215; //Angular rotation of earth in degrees/min

        public const double SIDRATE = 0.9972695677;

        public const double TIMER_INTERVAL = .25; //4 ticks per second

        // ---------------------
        // Simulation Parameters
        // ---------------------
        internal const double INSTRUMENT_APERTURE = 0.2;            // 8 inch = 20 cm
        internal const double INSTRUMENT_APERTURE_AREA = 0.0269;    // 3 inch obstruction
        internal const double INSTRUMENT_FOCAL_LENGTH = 1.26;      // f/6.3 instrument

        internal const uint ERROR_BASE = 0x80040400;
        internal static readonly uint SCODE_NO_TARGET_COORDS = (uint)ASCOM.ErrorCodes.InvalidOperationException; //ERROR_BASE + 0x404;
        internal const string MSG_NO_TARGET_COORDS = "Target coordinates have not yet been set";
        internal static uint SCODE_VAL_OUTOFRANGE = (uint)ASCOM.ErrorCodes.InvalidValue;// ERROR_BASE + 0x405;
        internal const string MSG_VAL_OUTOFRANGE = "The property value is out of range";
        internal static uint SCOPE_PROP_NOT_SET = (uint)ASCOM.ErrorCodes.ValueNotSet;// ERROR_BASE + 0x403;
        internal const string MSG_PROP_NOT_SET = "The property has not yet been set";
        internal static uint INVALID_AT_PARK = (uint)ASCOM.ErrorCodes.InvalidWhileParked; //ERROR_BASE + 0x404;
        internal const string MSG_INVALID_AT_PARK = "Invalid while parked";
        //
        // Public access to shared resources
        //

        //public static int z { get { return s_z++; } }

        public static TrafficForm TrafficForm
        { 
            get 
            {
                if (m_trafficForm == null)
                {
                    m_trafficForm = new TrafficForm();
                }
                
                return m_trafficForm; 
            }
            set
            {
                m_trafficForm = value;
            }
        }

        /// <summary>
        /// specifies the type of the traffic message, the message
        /// is only displayed if the corresponding checkbox is checked.
        /// </summary>
        public enum MessageType
        {
            none,
            /// <summary>
            /// Capabilities: Can Flags, Alignment Mode
            /// </summary>
            Capabilities,
            /// <summary>
            /// Slew, Sync, Park/Unpark, Find Home
            /// </summary>
            Slew,
            /// <summary>
            /// Get: Alt/Az, RA/Dec, Target RA/Dec
            /// </summary>
            Gets,
            /// <summary>
            /// Polls: Tracking, Slewing, At's
            /// </summary>
            Polls,
            /// <summary>
            /// UTC, Siderial Time
            /// </summary>
            Time,
            /// <summary>
            /// All Other messages
            /// </summary>
            Other
        }

        /// <summary>
        /// Write a line to the traffis form
        /// </summary>
        /// <param name="msgType"></param>
        /// <param name="msg"></param>
        public static void TrafficLine(MessageType msgType, string msg)
        {
            lastMsg = msgType;
            if (CheckMsg(msgType))
            {
                m_trafficForm.TrafficLine(msg);
            }
        }

        /// <summary>
        /// Start a line to the traffic form, must be finished by TrafficLine or TrafficEnd
        /// </summary>
        /// <param name="msgType"></param>
        /// <param name="msg"></param>
        public static void TrafficStart(MessageType msgType, string msg)
        {
            lastMsg = msgType;
            if (CheckMsg(msgType))
            {
                m_trafficForm.TrafficStart(msg);
            }
        }

        public static void TrafficStart(string msg)
        {
            if (CheckMsg(lastMsg))
            {
                m_trafficForm.TrafficStart(msg);
            }
        }

        /// <summary>
        /// Finish writing a line to the traffic form
        /// </summary>
        /// <param name="msgType"></param>
        /// <param name="msg"></param>
        public static void TrafficEnd(MessageType msgType, string msg)
        {
            if (CheckMsg(msgType))
            {
                m_trafficForm.TrafficEnd(msg);
            }
            lastMsg = msgType;
        }

        public static void TrafficEnd(string msg)
        {
            if (CheckMsg(lastMsg))
            {
                m_trafficForm.TrafficEnd(msg);
            }
            lastMsg = MessageType.none;
        }

        private static MessageType lastMsg = MessageType.none;

        /// <summary>
        /// Returns true if the message type has been checked
        /// </summary>
        /// <param name="msgType"></param>
        /// <returns></returns>
        private static bool CheckMsg(MessageType msgType)
        {
            if (TrafficForm == null)
                return false;
            switch (msgType)
            {
                case MessageType.Capabilities:
                    return m_trafficForm.Capabilities;
                case MessageType.Slew:
                    return m_trafficForm.Slew;
                case MessageType.Gets:
                    return m_trafficForm.Gets;
                case MessageType.Polls:
                    return m_trafficForm.Polls;
                case MessageType.Time:
                    return m_trafficForm.Time;
                case MessageType.Other:
                    return m_trafficForm.Other;
                default:
                    return false;
            }
        }

        // object used for locking to prevent multiple drivers accessing common code at the same time
        private static readonly object readLock = new object();
        private static readonly object writeLock = new object();

        // Shared serial port. This will allow multiple drivers to use one single serial port.
        private static Serial s_sharedSerial = new Serial();        // Shared serial port
        private static int s_z = 0;     // counter for the number of connections to the serial port

        //
        // Public access to shared resources
        //

        #region single serial port connector
        //
        // this region shows a way that a single serial port could be connected to by multiple 
        // drivers.
        //
        // Connected is used to handle the connections to the port.
        //
        // SendMessage is a way that messages could be sent to the hardware without
        // conflicts between different drivers.
        //
        // All this is for a single connection, multiple connections would need multiple ports
        // and a way to handle connecting and disconnection from them - see the
        // multi driver handling section for ideas.
        //

        /// <summary>
        /// Shared serial port
        /// </summary>
        public static ASCOM.Utilities.Serial SharedSerial { get { return s_sharedSerial; } }

        /// <summary>
        /// number of connections to the shared serial port
        /// </summary>
        public static int connections { get { return s_z; } set { s_z = value; } }

        internal static void CheckConnected(string str = "")
        {
            if (!Connected)
            {
                System.Windows.Forms.MessageBox.Show("Error: Serial port not connected.");
                throw new ASCOM.NotConnectedException(str);
            }
        }

        public static void SendCommand(string command)
        {
            try
            {
                CheckConnected();
                lock (writeLock)
                {
                    SharedSerial.Transmit(command + "\n");
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Error: " + e.Message);
            }
        }


        private static readonly char[] spchar = { ' ', '\n', '\r', '\t' };
        public static string SendCommandWithReturn(string command)
        {
            string ret = "";
            try
            {
                CheckConnected();
                lock (writeLock)
                {
                    SharedSerial.Transmit(command + "\n");
                }

                string cmd = command.Split(' ')[0];
                string response = "";
                lock (readLock)
                {
                    /// Read and Write are locked with different locks
                    /// Can Read/Write simultaneously, but only one instance and Read/Write at a time
                    response = SharedSerial.ReceiveTerminated("\n").TrimEnd(spchar);
                }

                if (response == "Unknown command")
                {
                    return "";
                }

                do
                {
                    //Console.WriteLine(">" + response + "<");
                    string[] s = response.Split(' ');
                    if (s.Length != 0)
                    {
                        // Empty string
                        int retCode;
                        if (int.TryParse(s[0], out retCode))
                        {
                            if (s.Length >= 2 && s[1] == cmd)
                            {
                                break;
                            }
                        }

                        if (s[0] == cmd)
                        {
                            // Message addressed to this command
                            // Append the rest of the response to the output
                            ret = ret + String.Join(" ", s.Skip(1).ToArray()) + "\n";
                        }
                    }
                    lock (readLock)
                    {
                        response = SharedSerial.ReceiveTerminated("\n").TrimEnd(spchar);
                    }
                } while (true);
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Error: " + e.Message);
            }
            finally
            {
                ret = ret.TrimEnd(spchar);
            }
            return ret;
        }

        public static string COMPort
        {
            set
            {
                lock (SharedSerial)
                {
                    if (SharedSerial.Connected)
                    {
                        throw new ASCOM.DriverException("COM port cannot be changed when it is already connected.");
                    }
                    SharedSerial.PortName = value;
                }
            }
            get
            {
                return SharedSerial.PortName;
            }
        }

        public static Object dummy = new object();
        /// <summary>
        /// Example of handling connecting to and disconnection from the
        /// shared serial port.
        /// Needs error handling
        /// the port name etc. needs to be set up first, this could be done by the driver
        /// checking Connected and if it's false setting up the port before setting connected to true.
        /// It could also be put here.
        /// </summary>
        public static bool Connected
        {
            set
            {
                TelescopeHardware.TL.LogMessage("SharedResources", "Connect - " + dummy.GetHashCode() + " " + value);
                lock (SharedSerial)
                {
                    if (value)
                    {
                        if (s_z == 0)
                        {
                            // COMPort must be set before connection
                            //SharedSerial.PortName = Settings.Default.comPort;
                            SharedSerial.Speed = SerialSpeed.ps115200;
                            SharedSerial.Parity = SerialParity.None;
                            SharedSerial.DataBits = 8;
                            SharedSerial.StopBits = SerialStopBits.One;
                            SharedSerial.Handshake = SerialHandshake.None;
                            SharedSerial.ReceiveTimeout = 300;
                            SharedSerial.ClearBuffers();
                            SharedSerial.Connected = true;
                        }
                        // If error occurs before here, no connection will be made
                        s_z++;
                    }
                    else
                    {
                        s_z--;
                        if (s_z <= 0)
                        {
                            SharedSerial.Connected = false;
                        }
                    }
                }
            }
            get { return SharedSerial.Connected; }
        }

        #endregion
    }
}

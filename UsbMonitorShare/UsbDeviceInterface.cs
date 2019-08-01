using System.ComponentModel;

namespace UsbMonitor
{
    /// <summary>
    /// Device interfaces
    /// </summary>
    public enum UsbDeviceInterface
    {
        /// <summary>
        /// Unknown
        /// </summary>
        [Description("Unknown")]
        [EnumGuidAttribute()]
        Unknown = 0,

        #region DEVINTERFACE

        /// <summary>
        /// Brightness
        /// </summary>
        [Description("Brightness")]
        [EnumGuidAttribute("FDE5BBA4-B3F9-46FB-BDAA-0728CE3100B4")]
        Brightness,

        /// <summary>
        /// CD Changer
        /// </summary>
        [Description("CD Changer")]
        [EnumGuidAttribute("53F56312-B6BF-11D0-94F2-00A0C91EFB8B")]
        CDChanger,

        /// <summary>
        /// CD ROM
        /// </summary>
        [Description("CD ROM")]
        [EnumGuidAttribute("53F56308-B6BF-11D0-94F2-00A0C91EFB8B")]
        CDROM,

        /// <summary>
        /// COM Port
        /// </summary>
        [Description("COM Port")]
        [EnumGuidAttribute("86E0D1E0-8089-11D0-9CE4-08003E301F73")]
        COMPort,

        /// <summary>
        /// Disk
        /// </summary>
        [Description("Disk")]
        [EnumGuidAttribute("53F56307-B6BF-11D0-94F2-00A0C91EFB8B")]
        Disk,

        /// <summary>
        /// Display Adapter
        /// </summary>
        [Description("Display Adapter")]
        [EnumGuidAttribute("5B45201D-F2F2-4F3B-85BB-30FF1F953599")]
        DisplayAdapter,

        /// <summary>
        /// Floppy
        /// </summary>
        [Description("Floppy")]
        [EnumGuidAttribute("53F56311-B6BF-11D0-94F2-00A0C91EFB8B")]
        Floppy,

        /// <summary>
        /// HID
        /// </summary>
        [Description("HID")]
        [EnumGuidAttribute("4D1E55B2-F16F-11CF-88CB-001111000030")]
        HID,

        /// <summary>
        /// I2C
        /// </summary>
        [Description("I2C")]
        [EnumGuidAttribute("2564AA4F-DDDB-4495-B497-6AD4A84163D7")]
        I2C,

        /// <summary>
        /// Image
        /// </summary>
        [Description("Image")]
        [EnumGuidAttribute("6BDD1FC6-810F-11D0-BEC7-08002BE2092F")]
        Image,

        /// <summary>
        /// Keyboard
        /// </summary>
        [Description("Keyboard")]
        [EnumGuidAttribute("884b96c3-56ef-11d1-bc8c-00a0c91405dd")]
        Keyboard,

        /// <summary>
        /// Medium Changer
        /// </summary>
        [Description("Medium Changer")]
        [EnumGuidAttribute("53F56310-B6BF-11D0-94F2-00A0C91EFB8B")]
        MediumChanger,

        /// <summary>
        /// Modem
        /// </summary>
        [Description("Modem")]
        [EnumGuidAttribute("2C7089AA-2E0E-11D1-B114-00C04FC2AAE4")]
        Modem,

        /// <summary>
        /// Monitor
        /// </summary>
        [Description("Monitor")]
        [EnumGuidAttribute("E6F07B5F-EE97-4a90-B076-33F57BF4EAA7")]
        Monitor,

        /// <summary>
        /// Mouse
        /// </summary>
        [Description("Mouse")]
        [EnumGuidAttribute("378DE44C-56EF-11D1-BC8C-00A0C91405DD")]
        Mouse,

        /// <summary>
        /// Network
        /// </summary>
        [Description("Network")]
        [EnumGuidAttribute("CAC88484-7515-4C03-82E6-71A87ABAC361")]
        Net,

        /// <summary>
        /// Output Protection Management 
        /// </summary>
        [Description("Output Protection Management")]
        [EnumGuidAttribute("BF4672DE-6B4E-4BE4-A325-68A91EA49C09")]
        OPM,

        /// <summary>
        /// Parallel Port IEEE 1284
        /// </summary>
        [Description("Parallel Port IEEE 1284")]
        [EnumGuidAttribute("97F76EF0-F883-11D0-AF1F-0000F800845C")]
        Parallel,

        /// <summary>
        /// Parallel Class
        /// </summary>
        [Description("Parallel Class")]
        [EnumGuidAttribute("811FC6A5-F728-11D0-A537-0000F8753ED1")]
        ParClass,

        /// <summary>
        /// Partition Device
        /// </summary>
        [Description("Partition Device")]
        [EnumGuidAttribute("53F5630A-B6BF-11D0-94F2-00A0C91EFB8B")]
        Partition,

        /// <summary>
        /// Serial Bus Enumerator
        /// </summary>
        [Description("Serial Bus Enumerator")]
        [EnumGuidAttribute("4D36E978-E325-11CE-BFC1-08002BE10318")]
        SerenumBusEnumerator,

        /// <summary>
        /// Side Show
        /// </summary>
        [Description("Side Show")]
        [EnumGuidAttribute("152E5811-FEB9-4B00-90F4-D32947AE1681")]
        SideShow,

        /// <summary>
        /// Storage Port
        /// </summary>
        [Description("Storage Port")]
        [EnumGuidAttribute("2ACCFE60-C130-11D2-B082-00A0C91EFB8B")]
        StoragePort,

        /// <summary>
        /// Tape
        /// </summary>
        [Description("Tape")]
        [EnumGuidAttribute("53F5630B-B6BF-11D0-94F2-00A0C91EFB8B")]
        Tape,
        
        /// <summary>
        /// USB Device
        /// </summary>
        [Description("USB Device")]
        [EnumGuidAttribute("A5DCBF10-6530-11D2-901F-00C04FB951ED")]
        UsbDevice,

        /// <summary>
        /// USB Host Controller
        /// </summary>
        [Description("USB Host Controller")]
        [EnumGuidAttribute("3ABF6F2D-71C4-462A-8A92-1E6861E6AF27")]
        UsbHostController,

        /// <summary>
        /// USB Hub
        /// </summary>
        [Description("USB Hub")]
        [EnumGuidAttribute("F18A0E88-C30C-11D0-8815-00A0C906BED8")]
        UsbHub,

        /// <summary>
        /// Video Output Arrival
        /// </summary>
        [Description("Video Output Arrival")]
        [EnumGuidAttribute("1AD9E4F0-F88D-4360-BAB9-4C2D55E564CD")]
        VideoOutputArrival,

        /// <summary>
        /// Volume
        /// </summary>
        [Description("Volume")]
        [EnumGuidAttribute("53F5630D-B6BF-11D0-94F2-00A0C91EFB8B")]
        Volume,

        /// <summary>
        /// Windows Portable Devices
        /// </summary>
        [Description("Windows Portable Devices")]
        [EnumGuidAttribute("6AC27878-A6FA-4155-BA85-F98F491D4F33")]
        WPD,

        /// <summary>
        /// Private Windows Portable Devices
        /// </summary>
        [Description("Private Windows Portable Devices")]
        [EnumGuidAttribute("BA0C718F-4DED-49B7-BDD3-FABE28661211")]
        WPDPrivate,

        /// <summary>
        /// Write on CE Disk
        /// </summary>
        [Description("Write on CE Disk")]
        [EnumGuidAttribute("53F5630C-B6BF-11D0-94F2-00A0C91EFB8B")]
        WriteOnCeDisk,

        #endregion

        #region Kernel Streaming Category

        // https://docs.microsoft.com/en-us/windows-hardware/drivers/install/kscategory-acoustic-echo-cancel

        /// <summary>
        /// Acoustic Echo Cancel
        /// </summary>
        [Description("Acoustic Echo Cancel")]
        [EnumGuidAttribute("BF963D80-C559-11D0-8A2B-00A0C9255AC1")]
        AcousticEchoCancel,

        /// <summary>
        /// Audio
        /// </summary>
        [Description("Audio")]
        [EnumGuidAttribute("6994AD04-93EF-11D0-A3CC-00A0C9223196")]
        Audio,

        /// <summary>
        /// Audio Device
        /// </summary>
        [Description("Audio Device")]
        [EnumGuidAttribute("FBF6F530-07B9-11D2-A71E-0000F8004788")]
        AudioDevice,

        /// <summary>
        /// Audio GFX
        /// </summary>
        [Description("Audio GFX")]
        [EnumGuidAttribute("9BAF9572-340C-11D3-ABDC-00A0C90AB16F")]
        AudioGFX,

        /// <summary>
        /// Audio Splitter
        /// </summary>
        [Description("Audio Splitter")]
        [EnumGuidAttribute("9EA331FA-B91B-45F8-9285-BD2BC77AFCDE")]
        AudioSplitter,

        /// <summary>
        /// Broadcast Driver Architecture sink filter
        /// </summary>
        [Description("BDA IP Sink")]
        [EnumGuidAttribute("71985F4A-1CA1-11d3-9CC8-00C04F7971E0")]
        BDAIPSink,

        /// <summary>
        /// Broadcast Driver Architecture for an electronic program guide (EPG) 
        /// </summary>
        [Description("BDA Network EPG")]
        [EnumGuidAttribute("71985F49-1CA1-11d3-9CC8-00C04F7971E0")]
        BDANetworkEPG,

        /// <summary>
        /// Broadcast Driver Architecture Network Provider
        /// </summary>
        [Description("BDA Network Provider")]
        [EnumGuidAttribute("71985F4B-1CA1-11d3-9CC8-00C04F7971E0")]
        BDANetworkProvider,

        /// <summary>
        /// Broadcast Driver Architecture Network Tuner
        /// </summary>
        [Description("BDA Network Tuner")]
        [EnumGuidAttribute("71985F48-1CA1-11d3-9CC8-00C04F7971E0")]
        BDANetworkTuner,

        /// <summary>
        /// Broadcast Driver Architecture Receiver Component
        /// </summary>
        [Description("BDA Receiver Component")]
        [EnumGuidAttribute("FD0A5AF4-B41D-11d2-9C95-00C04F7971E0")]
        BDAReceiverComponent,

        /// <summary>
        /// Broadcast Driver Architecture Transport Information
        /// </summary>
        [Description("BDA Transport Information")]
        [EnumGuidAttribute("A2E3074F-6C3D-11d3-B653-00C04F79498E")]
        BDATransportInformation,

        /// <summary>
        /// Bridge
        /// </summary>
        [Description("Bridge")]
        [EnumGuidAttribute("085AFF00-62CE-11CF-A5D6-28DB04C10000")]
        Bridge,

        /// <summary>
        /// Capture WAV and MIDI data
        /// </summary>
        [Description("Capture")]
        [EnumGuidAttribute("65E8773D-8F56-11D0-A3B9-00A0C9223196")]
        Capture,

        /// <summary>
        /// Clock
        /// </summary>
        [Description("Clock")]
        [EnumGuidAttribute("53172480-4791-11D0-A5D6-28DB04C10000")]
        Clock,

        /// <summary>
        /// Communications Transform
        /// </summary>
        [Description("Communications Transform")]
        [EnumGuidAttribute("CF1DDA2C-9743-11D0-A3EE-00A0C9223196")]
        CommunicationsTransform,

        /// <summary>
        /// Crossbar
        /// </summary>
        [Description("Crossbar")]
        [EnumGuidAttribute("A799A801-A46D-11D0-A18C-00A02401DCD4")]
        Crossbar,

        /// <summary>
        /// Data Compressor
        /// </summary>
        [Description("Data Compressor")]
        [EnumGuidAttribute("1E84C900-7E70-11D0-A5D6-28DB04C10000")]
        DataCompressor,

        /// <summary>
        /// Data Decompressor
        /// </summary>
        [Description("Data Decompressor")]
        [EnumGuidAttribute("2721AE20-7E70-11D0-A5D6-28DB04C10000")]
        DataDecompressor,

        /// <summary>
        /// Data Transform
        /// </summary>
        [Description("Data Transform")]
        [EnumGuidAttribute("2EB07EA0-7E70-11D0-A5D6-28DB04C10000")]
        DataTransform,

        /// <summary>
        /// DRM Descramble
        /// </summary>
        [Description("DRM Descramble")]
        [EnumGuidAttribute("FFBB6E3F-CCFE-4D84-90D9-421418B03A8E")]
        DRMDescramble,

        /// <summary>
        /// Encoder
        /// </summary>
        [Description("Encoder")]
        [EnumGuidAttribute("19689BF6-C384-48fd-AD51-90E58C79F70B")]
        Encoder,

        /// <summary>
        /// Escalante Platform Driver
        /// </summary>
        [Description("Escalante Platform Driver")]
        [EnumGuidAttribute("74F3AEA8-9768-11D1-8E07-00A0C95EC22E")]
        EscalantePlatformDriver,

        /// <summary>
        /// Filesystem
        /// </summary>
        [Description("Filesystem")]
        [EnumGuidAttribute("760FED5E-9357-11D0-A3CC-00A0C9223196")]
        Filesystem,

        /// <summary>
        /// Interface Transform
        /// </summary>
        [Description("Interface Transform")]
        [EnumGuidAttribute("CF1DDA2D-9743-11D0-A3EE-00A0C9223196")]
        InterfaceTransform,

        /// <summary>
        /// Medium Transform
        /// </summary>
        [Description("Medium Transform")]
        [EnumGuidAttribute("CF1DDA2E-9743-11D0-A3EE-00A0C9223196")]
        MediumTransform,

        /// <summary>
        /// Microphone Array Processor
        /// </summary>
        [Description("Microphone Array Processor")]
        [EnumGuidAttribute("830A44F2-A32D-476B-BE97-42845673B35A")]
        MicrophoneArrayProcessor,
        
        /// <summary>
        /// Mixer
        /// </summary>
        [Description("Mixer")]
        [EnumGuidAttribute("AD809C00-7B88-11D0-A5D6-28DB04C10000")]
        Mixer,

        /// <summary>
        /// Multiplexer
        /// </summary>
        [Description("Multiplexer")]
        [EnumGuidAttribute("7A5DE1D3-01A1-452c-B481-4FA2B96271E8")]
        Multiplexer,
        
        /// <summary>
        /// Network
        /// </summary>
        [Description("Network")]
        [EnumGuidAttribute("67C9CC3C-69C4-11D2-8759-00A0C9223196")]
        Network,

        /// <summary>
        /// Preferred Midi Out Device
        /// </summary>
        [Description("Preferred Midi Out Device")]
        [EnumGuidAttribute("D6C50674-72C1-11D2-9755-0000F8004788")]
        PreferredMidiOutDevice,

        /// <summary>
        /// Preferred Wave In Device
        /// </summary>
        [Description("Preferred Wave In Device")]
        [EnumGuidAttribute("D6C50671-72C1-11D2-9755-0000F8004788")]
        PreferredWaveInDevice,

        /// <summary>
        /// Preferred Wave Out Device
        /// </summary>
        [Description("Preferred Wave Out Device")]
        [EnumGuidAttribute("D6C5066E-72C1-11D2-9755-0000F8004788")]
        PreferredWaveOutDevice,

        /// <summary>
        /// Proxy
        /// </summary>
        [Description("Proxy")]
        [EnumGuidAttribute("97EBAACA-95BD-11D0-A3EA-00A0C9223196")]
        Proxy,

        /// <summary>
        /// Quality
        /// </summary>
        [Description("Quality")]
        [EnumGuidAttribute("97EBAACB-95BD-11D0-A3EA-00A0C9223196")]
        Quality,

        /// <summary>
        /// Realtime
        /// </summary>
        [Description("Realtime")]
        [EnumGuidAttribute("EB115FFC-10C8-4964-831D-6DCB02E6F23F")]
        Realtime,

        /// <summary>
        /// Render WAV and MIDI data
        /// </summary>
        [Description("Render")]
        [EnumGuidAttribute("65E8773E-8F56-11D0-A3B9-00A0C9223196")]
        Render,

        /// <summary>
        /// Sensor Camera
        /// </summary>
        [Description("Sensor Camera")]
        [EnumGuidAttribute("24E552D7-6523-47F7-A647-D3465BF1F5CA")]
        SensorCamera,

        /// <summary>
        /// Splitter
        /// </summary>
        [Description("Splitter")]
        [EnumGuidAttribute("0A4252A0-7E70-11D0-A5D6-28DB04C10000")]
        Splitter,

        /// <summary>
        /// Synthesizer
        /// </summary>
        [Description("Synthesizer")]
        [EnumGuidAttribute("DFF220F3-F70F-11D0-B917-00A0C9223196")]
        Synthesizer,

        /// <summary>
        /// Sys Audio
        /// </summary>
        [Description("Sys Audio")]
        [EnumGuidAttribute("A7C7A5B1-5AF3-11D1-9CED-00A024BF0407")]
        SysAudio,

        /// <summary>
        /// Text
        /// </summary>
        [Description("Text")]
        [EnumGuidAttribute("6994AD06-93EF-11D0-A3CC-00A0C9223196")]
        Text,

        /// <summary>
        /// Topology
        /// </summary>
        [Description("Topology")]
        [EnumGuidAttribute("DDA54A40-1E4C-11D1-A050-405705C10000")]
        Topology,

        /// <summary>
        /// TV Audio
        /// </summary>
        [Description("TV Audio")]
        [EnumGuidAttribute("A799A802-A46D-11D0-A18C-00A02401DCD4")]
        TVAudio,

        /// <summary>
        /// TV Tuner
        /// </summary>
        [Description("TV Tuner")]
        [EnumGuidAttribute("A799A800-A46D-11D0-A18C-00A02401DCD4")]
        TVTuner,

        /// <summary>
        /// VBI Codec
        /// </summary>
        [Description("VBI Codec")]
        [EnumGuidAttribute("07DAD660-22F1-11D1-A9F4-00C04FBBDE8F")]
        VBICodec,

        /// <summary>
        /// Video
        /// </summary>
        [Description("Video")]
        [EnumGuidAttribute("6994AD05-93EF-11D0-A3CC-00A0C9223196")]
        Video,

        /// <summary>
        /// Video Camera
        /// </summary>
        [Description("Video Camera")]
        [EnumGuidAttribute("E5323777-F976-4f5b-9B55-B94699C46E44")]
        VideoCamera,

        /// <summary>
        /// Virtual
        /// </summary>
        [Description("Virtual")]
        [EnumGuidAttribute("3503EAC4-1F26-11D1-8AB0-00A0C9223196")]
        Virtual,

        /// <summary>
        /// Video Multiplexing
        /// </summary>
        [Description("Video Multiplexing")]
        [EnumGuidAttribute("A799A803-A46D-11D0-A18C-00A02401DCD4")]
        VPMux,

        /// <summary>
        /// WD Audio
        /// </summary>
        [Description("WD Audio")]
        [EnumGuidAttribute("3E227E76-690D-11D2-8161-0000F8775BF1")]
        WDAudio,

        #endregion

        #region non official

        /// <summary>
        /// Windows Portable Devices 2
        /// </summary>
        [Description("Windows Portable Devices 2")]
        [EnumGuidAttribute("F33FDC04-D1AC-4E8E-9A30-19BBD4B108AE")]
        WPD2,

        /// <summary>
        /// Microsoft UMBus Root Bus Enumerator generic
        /// </summary>
        [Description("Microsoft UMBus Root Bus Enumerator generic")]
        [EnumGuidAttribute("65a9a6cf-64cd-480b-843e-32c86e1ba19f")]
        UMBus,

        /// <summary>
        /// Rendering Control
        /// </summary>
        [Description("Rendering Control")]
        [EnumGuidAttribute("8660e926-ff3d-580c-959e-8b8af44d7cde")]
        RenderingControl,

        /// <summary>
        /// Connection Manager
        /// </summary>
        [Description("Connection Manager")]
        [EnumGuidAttribute("ae9eb9c4-8819-51d8-879d-9a42ffb89d4e")]
        ConnectionManager,

        /// <summary>
        /// AV Transport
        /// </summary>
        [Description("AV Transport")]
        [EnumGuidAttribute("4c38e836-6a2f-5949-9406-1788ea20d1d5")]
        AVTransport,

        /// <summary>
        /// Content Directory
        /// </summary>
        [Description("Content Directory")]
        [EnumGuidAttribute("575d078a-63b9-5bc0-958b-87cc35b279cc")]
        ContentDirectory,


        // ???? unknown 57edcd85-0281-4893-a224-6719f892b1a4 

        #endregion

        
    }
}

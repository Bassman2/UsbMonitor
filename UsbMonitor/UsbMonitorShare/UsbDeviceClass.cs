using System.ComponentModel;

namespace UsbMonitor
{
    /// <summary>
    /// USB device class
    /// </summary>
    public enum UsbDeviceClass
    {
        /// <summary>
        /// Unknown
        /// </summary>
        [Description("Unknown")]
        [EnumGuidAttribute()]
        Unknown = 0,

        /// <summary>
        /// Windows Portable Devices
        /// </summary>
        [Description("Windows Portable Devices")]
        [EnumGuidAttribute("eec5ad98-8080-425f-922a-dabf3de3f69a")]
        WPD,

        /// <summary>
        /// CD/DVD/Blu-ray drives
        /// </summary>
        [Description("CD/DVD/Blu-ray drives")]
        [EnumGuidAttribute("4D36E965-E325-11CE-BFC1-08002BE10318")]
        CDROM,

        /// <summary>
        /// Hard drives
        /// </summary>
        [Description("Hard drives")]
        [EnumGuidAttribute("4D36E967-E325-11CE-BFC1-08002BE10318")]
        DiskDrive,

        /// <summary>
        /// Video adapters
        /// </summary>
        [Description("Video adapters")]
        [EnumGuidAttribute("4D36E968-E325-11CE-BFC1-08002BE10318")]
        Display,

        /// <summary>
        /// Floppy controllers
        /// </summary>
        [Description("Floppy controllers")]
        [EnumGuidAttribute("4D36E969-E325-11CE-BFC1-08002BE10318")]
        FDC,

        /// <summary>
        /// Floppy drives
        /// </summary>
        [Description("Floppy drives")]
        [EnumGuidAttribute("4D36E980-E325-11CE-BFC1-08002BE10318")]
        FloppyDisk,

        /// <summary>
        /// Hard drive controllers
        /// </summary>
        [Description("Hard drive controllers")]
        [EnumGuidAttribute("4D36E96A-E325-11CE-BFC1-08002BE10318")]
        HDC,

        /// <summary>
        /// Some USB devices
        /// </summary>
        [Description("Some USB devices")]
        [EnumGuidAttribute("745A17A0-74D3-11D0-B6FE-00A0C90F57DA")]
        HIDClass,

        /// <summary>
        /// IEEE 1394 host controller
        /// </summary>
        [Description("IEEE 1394 host controller")]
        [EnumGuidAttribute("6BDD1FC1-810F-11D0-BEC7-08002BE2092F")]
        IEEE1394,

        /// <summary>
        /// Cameras and scanners
        /// </summary>
        [Description("Cameras and scanners")]
        [EnumGuidAttribute("6BDD1FC6-810F-11D0-BEC7-08002BE2092F")]
        Image,

        /// <summary>
        /// Keyboards
        /// </summary>
        [Description("Keyboards")]
        [EnumGuidAttribute("4D36E96B-E325-11CE-BFC1-08002BE10318")]
        Keyboard,

        /// <summary>
        /// Modems
        /// </summary>
        [Description("Modems")]
        [EnumGuidAttribute("4D36E96D-E325-11CE-BFC1-08002BE10318")]
        Modem,

        /// <summary>
        /// Mice and pointing devices
        /// </summary>
        [Description("Mice and pointing devices")]
        [EnumGuidAttribute("4D36E96F-E325-11CE-BFC1-08002BE10318")]
        Mouse,

        /// <summary>
        /// Audio and video devices
        /// </summary>
        [Description("Audio and video devices")]
        [EnumGuidAttribute("4D36E96C-E325-11CE-BFC1-08002BE10318")]
        Media,

        /// <summary>
        /// Network adapters
        /// </summary>
        [Description("Network adapters")]
        [EnumGuidAttribute("4D36E972-E325-11CE-BFC1-08002BE10318")]
        Net,

        /// <summary>
        /// Serial and parallel ports
        /// </summary>
        [Description("Serial and parallel ports")]
        [EnumGuidAttribute("4D36E978-E325-11CE-BFC1-08002BE10318")]
        Ports,

        /// <summary>
        /// SCSI and RAID controllers
        /// </summary>
        [Description("SCSI and RAID controllers")]
        [EnumGuidAttribute("4D36E97B-E325-11CE-BFC1-08002BE10318")]
        SCSIAdapter,

        /// <summary>
        /// System buses, bridges, etc.
        /// </summary>
        [Description("System buses, bridges, etc.")]
        [EnumGuidAttribute("4D36E97D-E325-11CE-BFC1-08002BE10318")]
        System,

        /// <summary>
        /// USB host controllers and hubs
        /// </summary>
        [Description("USB host controllers and hubs")]
        [EnumGuidAttribute("36FC9E60-C465-11CF-8056-444553540000")]
        USB,

        /// <summary>
        /// Printers
        /// </summary>
        [Description("Printers")]
        [EnumGuidAttribute("4d36e979-e325-11ce-bfc1-08002be10318")]
        Printer,

        /// <summary>
        /// MTP Contact Service
        /// </summary>
        [Description("MTP Contact Service")]
        [EnumGuidAttribute("DD04D5FC-9D6E-4F76-9DCF-ECA6339B7389")]
        MTPContactService,

        /// <summary>
        /// MTP Calendar Service
        /// </summary>
        [Description("MTP Calendar Service")]
        [EnumGuidAttribute("E4DFDBD3-7F04-45E9-9FA1-5CA0EAEB0AE3")]
        MTPCalendarService,

        /// <summary>
        /// MTP Notes Service
        /// </summary>
        [Description("MTP Notes Service")]
        [EnumGuidAttribute("5c017aea-e706-4719-8cc0-a303836fd321")]
        MTPNotesService,

        /// <summary>
        /// MTP Task Service
        /// </summary>
        [Description("MTP Task Service")]
        [EnumGuidAttribute("BB340C54-B5C6-491D-8827-28D0E7631903")]
        MTPTaskService,

        /// <summary>
        /// MTP Status Service
        /// </summary>
        [Description("MTP Status Service")]
        [EnumGuidAttribute("0B9F1048-B94B-DC9A-4ED7-FE4FED3A0DEB")]
        MTPStatusService,

        /// <summary>
        /// MTP Hints Service
        /// </summary>
        [Description("MTP Hints Service")]
        [EnumGuidAttribute("c8a98b1f-6b19-4e79-a414-67ea4c39eec2")]
        MTPHintsService,

        /// <summary>
        /// MTP Device Metadata Service
        /// </summary>
        [Description("MTP Device Metadata Service")]
        [EnumGuidAttribute("332ffe6a-af65-41e1-a0af-d3e2627bdf54")]
        MTPDeviceMetadataService,

        /// <summary>
        /// MTP Ringtone Service
        /// </summary>
        [Description("MTP Ringtone Service")]
        [EnumGuidAttribute("d0eace0e-707d-4106-8d38-4f560e6a9f8e")]
        MTPRingtoneService,

        /// <summary>
        /// MTP Enumeration Synchronization Service
        /// </summary>
        [Description("MTP Enumeration Synchronization Service")]
        [EnumGuidAttribute("28d3aac9-c075-44be-8881-65f38d305909")]
        MTPEnumerationSynchronizationService,

        /// <summary>
        /// MTP Anchor Synchronization Service
        /// </summary>
        [Description("MTP Anchor Synchronization Service")]
        [EnumGuidAttribute("056d8b9e-ad7a-44fc-946f-1d63a25cda9a")]
        MTPAnchorSynchronizationService,
    }
}

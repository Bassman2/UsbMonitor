namespace UsbMonitor
{
    /// <summary>
    /// Device action
    /// </summary>
    public enum UsbDeviceChangeEvent : uint
    {
        /// <summary>
        /// A device or piece of media has been inserted and is now available.
        /// </summary>
        /// <remarks>DBT_DEVICEARRIVAL</remarks>
        Arrival = 0x8000,

        /// <summary>
        /// Permission is requested to remove a device or piece of media. Any application can deny this request and cancel the removal.
        /// </summary>
        /// <remarks>DBT_DEVICEQUERYREMOVE</remarks>
        QueryRemove = 0x8001,

        /// <summary>
        /// A request to remove a device or piece of media has been canceled.
        /// </summary>
        /// <remarks>DBT_DEVICEQUERYREMOVEFAILED</remarks>
        QueryRemoveFailed = 0x8002,

        /// <summary>
        /// A device or piece of media is about to be removed. Cannot be denied.
        /// </summary>
        /// <remarks> DBT_DEVICEREMOVEPENDING</remarks>
        RemovePending = 0x8003,

        /// <summary>
        /// A device or piece of media has been removed.
        /// </summary>
        /// <remarks>DBT_DEVICEREMOVECOMPLETE</remarks>
        RemoveComplete = 0x8004,
        
        /// <summary>
        /// A device has been added to or removed from the system.
        /// </summary>
        ///<remarks>DBT_DEVNODES_CHANGED</remarks>
        Changed = 0x0007
    }
}

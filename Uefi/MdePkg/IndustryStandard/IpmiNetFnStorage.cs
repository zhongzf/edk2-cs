using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  IPMI 2.0 definitions from the IPMI Specification Version 2.0, Revision 1.1.

  This file contains all NetFn Storage commands, including:
    FRU Inventory Commands (Chapter 34)
    SDR Repository (Chapter 33)
    System Event Log(SEL) Commands (Chapter 31)
    SEL Record Formats (Chapter 32)

  See IPMI specification, Appendix G, Command Assignments
  and Appendix H, Sub-function Assignments.

  Copyright (c) 1999 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent
**/

// #ifndef _IPMI_NET_FN_STORAGE_H_
// #define _IPMI_NET_FN_STORAGE_H_

public unsafe partial class EFI
{
  // #pragma pack(1)
  //
  // Net function definition for Storage command
  //
  public const ulong IPMI_NETFN_STORAGE = 0x0A;

  //
  // All Storage commands and their structure definitions to follow here
  //

  //
  //  Below is Definitions for FRU Inventory Commands (Chapter 34)
  //

  //
  //  Definitions for Get Fru Inventory Area Info command
  //
  public const ulong IPMI_STORAGE_GET_FRU_INVENTORY_AREAINFO = 0x10;
}

//
//  Constants and Structure definitions for "Get Fru Inventory Area Info" command to follow here
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_GET_FRU_INVENTORY_AREA_INFO_REQUEST
{
  public byte DeviceId;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_GET_FRU_INVENTORY_AREA_INFO_RESPONSE
{
  public byte CompletionCode;
  public ushort InventoryAreaSize;
  public byte AccessType;
}

public unsafe partial class EFI
{
  //
  //  Definitions for Read Fru Data command
  //
  public const ulong IPMI_STORAGE_READ_FRU_DATA = 0x11;
}

//
//  Constants and Structure definitions for "Read Fru Data" command to follow here
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_FRU_COMMON_DATA
{
  public byte FruDeviceId;
  public ushort FruOffset;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_FRU_READ_COMMAND
{
  public IPMI_FRU_COMMON_DATA Data;
  public byte Count;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_READ_FRU_DATA_REQUEST
{
  public byte DeviceId;
  public ushort InventoryOffset;
  public byte CountToRead;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_READ_FRU_DATA_RESPONSE
{
  public byte CompletionCode;
  public byte CountReturned;
  public byte[] Data;
}

public unsafe partial class EFI
{
  //
  //  Definitions for Write Fru Data command
  //
  public const ulong IPMI_STORAGE_WRITE_FRU_DATA = 0x12;
}

//
//  Constants and Structure definitions for "Write Fru Data" command to follow here
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_FRU_WRITE_COMMAND
{
  public IPMI_FRU_COMMON_DATA Data;
  public fixed byte FruData[16];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_WRITE_FRU_DATA_REQUEST
{
  public byte DeviceId;
  public ushort InventoryOffset;
  public byte[] Data;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_WRITE_FRU_DATA_RESPONSE
{
  public byte CompletionCode;
  public byte CountWritten;
}

//
//  Below is Definitions for SDR Repository (Chapter 33)
//

public unsafe partial class EFI
{
  //
  //  Definitions for Get SDR Repository Info command
  //
  public const ulong IPMI_STORAGE_GET_SDR_REPOSITORY_INFO = 0x20;
}

//
//  Constants and Structure definitions for "Get SDR Repository Info" command to follow here
//
[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_SDR_OPERATION_SUPPORT
{
  /*   struct { */
  [FieldOffset(0)] public byte SdrRepAllocInfoCmd; // = 1;
  [FieldOffset(0)] public byte SdrRepReserveCmd; // = 1;
  [FieldOffset(0)] public byte PartialAddSdrCmd; // = 1;
  [FieldOffset(0)] public byte DeleteSdrRepCmd; // = 1;
  [FieldOffset(0)] public byte Reserved; // = 1;
  [FieldOffset(0)] public byte SdrRepUpdateOp; // = 2;
  [FieldOffset(0)] public byte Overflow; // = 1;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_GET_SDR_REPOSITORY_INFO_RESPONSE
{
  public byte CompletionCode;
  public byte Version;
  public ushort RecordCount;
  public ushort FreeSpace;
  public uint RecentAdditionTimeStamp;
  public uint RecentEraseTimeStamp;
  public IPMI_SDR_OPERATION_SUPPORT OperationSupport;
}

public unsafe partial class EFI
{
  //
  //  Definitions for Get SDR Repository Allocateion Info command
  //
  public const ulong IPMI_STORAGE_GET_SDR_REPOSITORY_ALLOCATION_INFO = 0x21;

  //
  //  Constants and Structure definitions for "Get SDR Repository Allocateion Info" command to follow here
  //

  //
  //  Definitions for Reserve SDR Repository command
  //
  public const ulong IPMI_STORAGE_RESERVE_SDR_REPOSITORY = 0x22;
}

//
//  Constants and Structure definitions for "Reserve SDR Repository" command to follow here
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_RESERVE_SDR_REPOSITORY_RESPONSE
{
  public byte CompletionCode;
  public fixed byte ReservationId[2]; // Reservation ID. LS byte first.
}

public unsafe partial class EFI
{
  //
  //  Definitions for Get SDR command
  //
  public const ulong IPMI_STORAGE_GET_SDR = 0x23;
}

//
//  Constants and Structure definitions for "Get SDR" command to follow here
//
[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_SDR_RECORD_SENSOR_INIT
{
  /*   struct { */
  [FieldOffset(0)] public byte EventScanningEnabled; // = 1;
  [FieldOffset(0)] public byte EventScanningDisabled; // = 1;
  [FieldOffset(0)] public byte InitSensorType; // = 1;
  [FieldOffset(0)] public byte InitHysteresis; // = 1;
  [FieldOffset(0)] public byte InitThresholds; // = 1;
  [FieldOffset(0)] public byte InitEvent; // = 1;
  [FieldOffset(0)] public byte InitScanning; // = 1;
  [FieldOffset(0)] public byte SettableSensor; // = 1;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_SDR_RECORD_SENSOR_CAP
{
  /*   struct { */
  [FieldOffset(0)] public byte EventMessageControl; // = 2;
  [FieldOffset(0)] public byte ThresholdAccessSupport; // = 2;
  [FieldOffset(0)] public byte HysteresisSupport; // = 2;
  [FieldOffset(0)] public byte ReArmSupport; // = 1;
  [FieldOffset(0)] public byte IgnoreSensor; // = 1;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_SDR_RECORD_LINEARIZATION
{
  /*   struct { */
  [FieldOffset(0)] public byte Linearization; // = 7;
  [FieldOffset(0)] public byte Reserved; // = 1;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_SDR_RECORD_M_TOLERANCE
{
  /*   struct { */
  [FieldOffset(0)] public byte Toleremce; // = 6;
  [FieldOffset(0)] public byte MHi; // = 2;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_SDR_RECORD_B_ACCURACY
{
  /*   struct { */
  [FieldOffset(0)] public byte AccuracyLow; // = 6;
  [FieldOffset(0)] public byte BHi; // = 2;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_SDR_RECORD_ACCURACY_SENSOR_DIR
{
  /*   struct { */
  [FieldOffset(0)] public byte Reserved; // = 2;
  [FieldOffset(0)] public byte AccuracyExp; // = 2;
  [FieldOffset(0)] public byte AccuracyHi; // = 4;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_SDR_RECORD_R_EXP_B_EXP
{
  /*   struct { */
  [FieldOffset(0)] public byte BExp; // = 4;
  [FieldOffset(0)] public byte RExp; // = 4;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_SDR_RECORD_ANALOG_FLAGS
{
  /*   struct { */
  [FieldOffset(0)] public byte NominalReadingSpscified; // = 1;
  [FieldOffset(0)] public byte NominalMaxSpscified; // = 1;
  [FieldOffset(0)] public byte NominalMinSpscified; // = 1;
  [FieldOffset(0)] public byte Reserved; // = 5;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_SDR_RECORD_STRUCT_1
{
  public ushort RecordId;                  // 1
  public byte Version;                   // 3
  public byte RecordType;                // 4
  public byte RecordLength;              // 5
  public byte OwnerId;                   // 6
  public byte OwnerLun;                  // 7
  public byte SensorNumber;              // 8
  public byte EntityId;                  // 9
  public byte EntityInstance;            // 10
  public IPMI_SDR_RECORD_SENSOR_INIT SensorInitialization;      // 11
  public IPMI_SDR_RECORD_SENSOR_CAP SensorCapabilities;        // 12
  public byte SensorType;                // 13
  public byte EventType;                 // 14
  public fixed byte Reserved1[7];              // 15
  public byte UnitType;                  // 22
  public byte Reserved2;                 // 23
  public IPMI_SDR_RECORD_LINEARIZATION Linearization;             // 24
  public byte MLo;                       // 25
  public IPMI_SDR_RECORD_M_TOLERANCE MHiTolerance;              // 26
  public byte BLo;                       // 27
  public IPMI_SDR_RECORD_B_ACCURACY BHiAccuracyLo;             // 28
  public IPMI_SDR_RECORD_ACCURACY_SENSOR_DIR AccuracySensorDirection;   // 29
  public IPMI_SDR_RECORD_R_EXP_B_EXP RExpBExp;                  // 30
  public IPMI_SDR_RECORD_ANALOG_FLAGS AnalogFlags;               // 31
  public byte NominalReading;            // 32
  public fixed byte Reserved3[4];              // 33
  public byte UpperNonRecoverThreshold;  // 37
  public byte UpperCriticalThreshold;    // 38
  public byte UpperNonCriticalThreshold; // 39
  public byte LowerNonRecoverThreshold;  // 40
  public byte LowerCriticalThreshold;    // 41
  public byte LowerNonCriticalThreshold; // 42
  public fixed byte Reserved4[5];              // 43
  public byte IdStringLength;            // 48
  public fixed byte AsciiIdString[16];         // 49 - 64
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_SDR_RECORD_STRUCT_2
{
  public ushort RecordId;             // 1
  public byte Version;              // 3
  public byte RecordType;           // 4
  public byte RecordLength;         // 5
  public byte OwnerId;              // 6
  public byte OwnerLun;             // 7
  public byte SensorNumber;         // 8
  public byte EntityId;             // 9
  public byte EntityInstance;       // 10
  public IPMI_SDR_RECORD_SENSOR_INIT SensorInitialization; // 11
  public IPMI_SDR_RECORD_SENSOR_CAP SensorCapabilities;   // 12
  public byte SensorType;           // 13
  public byte EventType;            // 14
  public fixed byte Reserved1[7];         // 15
  public byte UnitType;             // 22
  public fixed byte Reserved2[9];         // 23
  public byte IdStringLength;       // 32
  public fixed byte AsciiIdString[16];    // 33 - 48
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_FRU_DATA_INFO
{
  /*   struct { */
  [FieldOffset(0)] public byte Reserved1; // = 1;
  [FieldOffset(0)] public byte ControllerSlaveAddress; // = 7;
  [FieldOffset(0)] public byte FruDeviceId;
  [FieldOffset(0)] public byte BusId; // = 3;
  [FieldOffset(0)] public byte Lun; // = 2;
  [FieldOffset(0)] public byte Reserved2; // = 2;
  [FieldOffset(0)] public byte LogicalFruDevice; // = 1;
  [FieldOffset(0)] public byte Reserved3; // = 4;
  [FieldOffset(0)] public byte ChannelNumber; // = 4;
  /*   } Bits; */
  [FieldOffset(0)] public uint Uint32;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_SDR_RECORD_DEV_ID_STR_TYPE_LENGTH
{
  /*   struct { */
  [FieldOffset(0)] public byte Length; // = 4;
  [FieldOffset(0)] public byte Reserved; // = 1;
  [FieldOffset(0)] public byte StringType; // = 3;
  /*   } Bits; */
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_SDR_RECORD_STRUCT_11
{
  public ushort RecordId;           // 1
  public byte Version;            // 3
  public byte RecordType;         // 4
  public byte RecordLength;       // 5
  public IPMI_FRU_DATA_INFO FruDeviceData;      // 6
  public byte Reserved;           // 10
  public byte DeviceType;         // 11
  public byte DeviceTypeModifier; // 12
  public byte FruEntityId;        // 13
  public byte FruEntityInstance;  // 14
  public byte OemReserved;        // 15
  public IPMI_SDR_RECORD_DEV_ID_STR_TYPE_LENGTH StringTypeLength;   // 16
  public fixed byte String[16];         // 17
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_SDR_RECORD_STRUCT_C0
{
  public ushort RecordId;                     // 1
  public byte Version;                      // 3
  public byte RecordType;                   // 4
  public byte RecordLength;                 // 5
  public fixed byte ManufacturerId[3];            // 6
  public fixed byte StringChars[20];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_SDR_RECORD_STRUCT_HEADER
{
  public ushort RecordId;                     // 1
  public byte Version;                      // 3
  public byte RecordType;                   // 4
  public byte RecordLength;                 // 5
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_SENSOR_RECORD_STRUCT
{
  [FieldOffset(0)] public IPMI_SDR_RECORD_STRUCT_1 SensorType1;
  [FieldOffset(0)] public IPMI_SDR_RECORD_STRUCT_2 SensorType2;
  [FieldOffset(0)] public IPMI_SDR_RECORD_STRUCT_11 SensorType11;
  [FieldOffset(0)] public IPMI_SDR_RECORD_STRUCT_C0 SensorTypeC0;
  [FieldOffset(0)] public IPMI_SDR_RECORD_STRUCT_HEADER SensorHeader;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_GET_SDR_REQUEST
{
  public ushort ReservationId;
  public ushort RecordId;
  public byte RecordOffset;
  public byte BytesToRead;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_GET_SDR_RESPONSE
{
  public byte CompletionCode;
  public ushort NextRecordId;
  public IPMI_SENSOR_RECORD_STRUCT RecordData;
}

public unsafe partial class EFI
{
  //
  //  Definitions for Add SDR command
  //
  public const ulong IPMI_STORAGE_ADD_SDR = 0x24;

  //
  //  Constants and Structure definitions for "Add SDR" command to follow here
  //

  //
  //  Definitions for Partial Add SDR command
  //
  public const ulong IPMI_STORAGE_PARTIAL_ADD_SDR = 0x25;

  //
  //  Constants and Structure definitions for "Partial Add SDR" command to follow here
  //

  //
  //  Definitions for Delete SDR command
  //
  public const ulong IPMI_STORAGE_DELETE_SDR = 0x26;

  //
  //  Constants and Structure definitions for "Delete SDR" command to follow here
  //

  //
  //  Definitions for Clear SDR Repository command
  //
  public const ulong IPMI_STORAGE_CLEAR_SDR = 0x27;

  //
  //  Constants and Structure definitions for "Clear SDR Repository" command to follow here
  //

  //
  //  Definitions for Get SDR Repository Time command
  //
  public const ulong IPMI_STORAGE_GET_SDR_REPOSITORY_TIME = 0x28;

  //
  //  Constants and Structure definitions for "Get SDR Repository Time" command to follow here
  //

  //
  //  Definitions for Set SDR Repository Time command
  //
  public const ulong IPMI_STORAGE_SET_SDR_REPOSITORY_TIME = 0x29;

  //
  //  Constants and Structure definitions for "Set SDR Repository Time" command to follow here
  //

  //
  //  Definitions for Enter SDR Repository Update Mode command
  //
  public const ulong IPMI_STORAGE_ENTER_SDR_UPDATE_MODE = 0x2A;

  //
  //  Constants and Structure definitions for "Enter SDR Repository Update Mode" command to follow here
  //

  //
  //  Definitions for Exit SDR Repository Update Mode command
  //
  public const ulong IPMI_STORAGE_EXIT_SDR_UPDATE_MODE = 0x2B;

  //
  //  Constants and Structure definitions for "Exit SDR Repository Update Mode" command to follow here
  //

  //
  //  Definitions for Run Initialize Agent command
  //
  public const ulong IPMI_STORAGE_RUN_INIT_AGENT = 0x2C;

  //
  //  Constants and Structure definitions for "Run Initialize Agent" command to follow here
  //

  //
  //  Below is Definitions for System Event Log(SEL) Commands (Chapter 31)
  //

  //
  //  Definitions for Get SEL Info command
  //
  public const ulong IPMI_STORAGE_GET_SEL_INFO = 0x40;

  //
  //  Constants and Structure definitions for "Get SEL Info" command to follow here
  //
  public const ulong IPMI_GET_SEL_INFO_OPERATION_SUPPORT_GET_SEL_ALLOCATION_INFO_CMD = BIT0;
  public const ulong IPMI_GET_SEL_INFO_OPERATION_SUPPORT_RESERVE_SEL_CMD = BIT1;
  public const ulong IPMI_GET_SEL_INFO_OPERATION_SUPPORT_PARTIAL_ADD_SEL_ENTRY_CMD = BIT2;
  public const ulong IPMI_GET_SEL_INFO_OPERATION_SUPPORT_DELETE_SEL_CMD = BIT3;
  public const ulong IPMI_GET_SEL_INFO_OPERATION_SUPPORT_OVERFLOW_FLAG = BIT7;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_GET_SEL_INFO_RESPONSE
{
  public byte CompletionCode;
  public byte Version;              // Version of SEL
  public ushort NoOfEntries;          // No of Entries in the SEL
  public ushort FreeSpace;            // Free space in Bytes
  public uint RecentAddTimeStamp;   // Most Recent Addition of Time Stamp
  public uint RecentEraseTimeStamp; // Most Recent Erasure of Time Stamp
  public byte OperationSupport;     // Operation Support
}

public unsafe partial class EFI
{
  //
  //  Definitions for Get SEL Allocation Info command
  //
  public const ulong IPMI_STORAGE_GET_SEL_ALLOCATION_INFO = 0x41;

  //
  //  Constants and Structure definitions for "Get SEL Allocation Info" command to follow here
  //

  //
  //  Definitions for Reserve SEL command
  //
  public const ulong IPMI_STORAGE_RESERVE_SEL = 0x42;
}

//
//  Constants and Structure definitions for "Reserve SEL" command to follow here
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_RESERVE_SEL_RESPONSE
{
  public byte CompletionCode;
  public fixed byte ReservationId[2]; // Reservation ID. LS byte first.
}

public unsafe partial class EFI
{
  //
  //  Definitions for Get SEL Entry command
  //
  public const ulong IPMI_STORAGE_GET_SEL_ENTRY = 0x43;

  //
  //  Constants and Structure definitions for "Get SEL Entry" command to follow here
  //
}

//
//  Below is Definitions for SEL Record Formats (Chapter 32)
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_SEL_EVENT_RECORD_DATA
{
  public ushort RecordId;
  public byte RecordType;
  public uint TimeStamp;
  public ushort GeneratorId;
  public byte EvMRevision;
  public byte SensorType;
  public byte SensorNumber;
  public byte EventDirType;
  public byte OEMEvData1;
  public byte OEMEvData2;
  public byte OEMEvData3;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_TIMESTAMPED_OEM_SEL_RECORD_DATA
{
  public ushort RecordId;
  public byte RecordType; // C0h-DFh = OEM system event record
  public uint TimeStamp;
  public fixed byte ManufacturerId[3];
  public fixed byte OEMDefined[6];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_NON_TIMESTAMPED_OEM_SEL_RECORD_DATA
{
  public ushort RecordId;
  public byte RecordType; // E0h-FFh = OEM system event record
  public fixed byte OEMDefined[13];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_GET_SEL_ENTRY_REQUEST
{
  public fixed byte ReserveId[2]; // Reservation ID, LS Byte First
  public fixed byte SelRecID[2];  // Sel Record ID, LS Byte First
  public byte Offset;       // Offset Into Record
  public byte BytesToRead;  // Bytes to be Read, 0xFF for entire record
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_GET_SEL_ENTRY_RESPONSE
{
  public byte CompletionCode;
  public ushort NextSelRecordId; // Next SEL Record ID, LS Byte first
  public IPMI_SEL_EVENT_RECORD_DATA RecordData;
}

public unsafe partial class EFI
{
  //
  //  Definitions for Add SEL Entry command
  //
  public const ulong IPMI_STORAGE_ADD_SEL_ENTRY = 0x44;
}

//
//  Constants and Structure definitions for "Add SEL Entry" command to follow here
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_ADD_SEL_ENTRY_REQUEST
{
  public IPMI_SEL_EVENT_RECORD_DATA RecordData;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_ADD_SEL_ENTRY_RESPONSE
{
  public byte CompletionCode;
  public ushort RecordId; // Record ID for added record, LS Byte first
}

public unsafe partial class EFI
{
  //
  //  Definitions for Partial Add SEL Entry command
  //
  public const ulong IPMI_STORAGE_PARTIAL_ADD_SEL_ENTRY = 0x45;
}

//
//  Constants and Structure definitions for "Partial Add SEL Entry" command to follow here
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_PARTIAL_ADD_SEL_ENTRY_REQUEST
{
  public ushort ReservationId;
  public ushort RecordId;
  public byte OffsetIntoRecord;
  public byte InProgress;
  public byte[] RecordData;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_PARTIAL_ADD_SEL_ENTRY_RESPONSE
{
  public byte CompletionCode;
  public ushort RecordId;
}

public unsafe partial class EFI
{
  //
  //  Definitions for Delete SEL Entry command
  //
  public const ulong IPMI_STORAGE_DELETE_SEL_ENTRY = 0x46;
}

//
//  Constants and Structure definitions for "Delete SEL Entry" command to follow here
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_DELETE_SEL_ENTRY_REQUEST
{
  public fixed byte ReserveId[2];      // Reservation ID, LS byte first
  public fixed byte RecordToDelete[2]; // Record to Delete, LS Byte First
}

public unsafe partial class EFI
{
  public const ulong IPMI_DELETE_SEL_ENTRY_RESPONSE_TYPE_UNSUPPORTED = 0x80;
  public const ulong IPMI_DELETE_SEL_ENTRY_RESPONSE_ERASE_IN_PROGRESS = 0x81;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_DELETE_SEL_ENTRY_RESPONSE
{
  public byte CompletionCode;
  public ushort RecordId; // Record ID added. LS byte first
}

public unsafe partial class EFI
{
  //
  //  Definitions for Clear SEL command
  //
  public const ulong IPMI_STORAGE_CLEAR_SEL = 0x47;

  //
  //  Constants and Structure definitions for "Clear SEL" command to follow here
  //
  public const ulong IPMI_CLEAR_SEL_REQUEST_C_CHAR_ASCII = 0x43;
  public const ulong IPMI_CLEAR_SEL_REQUEST_L_CHAR_ASCII = 0x4C;
  public const ulong IPMI_CLEAR_SEL_REQUEST_R_CHAR_ASCII = 0x52;
  public const ulong IPMI_CLEAR_SEL_REQUEST_INITIALIZE_ERASE = 0xAA;
  public const ulong IPMI_CLEAR_SEL_REQUEST_GET_ERASE_STATUS = 0x00;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_CLEAR_SEL_REQUEST
{
  public fixed byte Reserve[2]; // Reserve ID, LSB first
  public byte AscC;       // Ascii for 'C' (0x43)
  public byte AscL;       // Ascii for 'L' (0x4c)
  public byte AscR;       // Ascii for 'R' (0x52)
  public byte Erase;      // 0xAA, Initiate Erase, 0x00 Get Erase Status
}

public unsafe partial class EFI
{
  public const ulong IPMI_CLEAR_SEL_RESPONSE_ERASURE_IN_PROGRESS = 0x00;
  public const ulong IPMI_CLEAR_SEL_RESPONSE_ERASURE_COMPLETED = 0x01;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_CLEAR_SEL_RESPONSE
{
  public byte CompletionCode;
  public byte ErasureProgress;
}

public unsafe partial class EFI
{
  //
  //  Definitions for Get SEL Time command
  //
  public const ulong IPMI_STORAGE_GET_SEL_TIME = 0x48;
}

//
//  Constants and Structure definitions for "Get SEL Time" command to follow here
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_GET_SEL_TIME_RESPONSE
{
  public byte CompletionCode;
  public uint Timestamp; // Present Timestamp clock reading. LS byte first.
}

public unsafe partial class EFI
{
  //
  //  Definitions for Set SEL Time command
  //
  public const ulong IPMI_STORAGE_SET_SEL_TIME = 0x49;
}

//
//  Constants and Structure definitions for "Set SEL Time" command to follow here
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_SET_SEL_TIME_REQUEST
{
  public uint Timestamp;
}

public unsafe partial class EFI
{
  //
  //  Definitions for Get Auxillary Log Status command
  //
  public const ulong IPMI_STORAGE_GET_AUXILLARY_LOG_STATUS = 0x5A;

  //
  //  Constants and Structure definitions for "Get Auxillary Log Status" command to follow here
  //

  //
  //  Definitions for Set Auxillary Log Status command
  //
  public const ulong IPMI_STORAGE_SET_AUXILLARY_LOG_STATUS = 0x5B;

  //
  //  Constants and Structure definitions for "Set Auxillary Log Status" command to follow here
  //

  //
  //  Definitions for Get SEL Time UTC Offset command
  //
  public const ulong IPMI_STORAGE_GET_SEL_TIME_UTC_OFFSET = 0x5C;
}

//
//  Constants and Structure definitions for "Get SEL Time UTC Offset" command to follow here
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_GET_SEL_TIME_UTC_OFFSET_RESPONSE
{
  public byte CompletionCode;
  //
  // 16-bit, 2s-complement signed integer for the offset in minutes from UTC to SEL Time.
  // LS-byte first. (ranges from -1440 to 1440)
  //
  public short UtcOffset;
}

public unsafe partial class EFI
{
  //
  //  Definitions for Set SEL Time UTC Offset command
  //
  public const ulong IPMI_STORAGE_SET_SEL_TIME_UTC_OFFSET = 0x5D;

  //
  //  Constants and Structure definitions for "Set SEL Time UTC Offset" command to follow here
  //

  public const ulong IPMI_COMPLETE_SEL_RECORD = 0xFF;

  public const ulong IPMI_SEL_SYSTEM_RECORD = 0x02;
  public const ulong IPMI_SEL_OEM_TIME_STAMP_RECORD_START = 0xC0;
  public const ulong IPMI_SEL_OEM_TIME_STAMP_RECORD_END = 0xDF;
  public const ulong IPMI_SEL_OEM_NO_TIME_STAMP_RECORD_START = 0xE0;
  public const ulong IPMI_SEL_OEM_NO_TIME_STAMP_RECORD_END = 0xFF;

  //public const ulong IPMI_SEL_EVENT_DIR = (EventDirType)(EventDirType >> 7);
  public const ulong IPMI_SEL_EVENT_DIR_ASSERTION_EVENT = 0x00;
  public const ulong IPMI_SEL_EVENT_DIR_DEASSERTION_EVENT = 0x01;

  //public const ulong IPMI_SEL_EVENT_TYPE = (EventDirType)(EventDirType & 0x7F);
  //
  // Event/Reading Type Code Ranges (Chapter 42)
  //
  public const ulong IPMI_SEL_EVENT_TYPE_UNSPECIFIED = 0x00;
  public const ulong IPMI_SEL_EVENT_TYPE_THRESHOLD = 0x01;
  public const ulong IPMI_SEL_EVENT_TYPE_GENERIC_START = 0x02;
  public const ulong IPMI_SEL_EVENT_TYPE_GENERIC_END = 0x0C;
  public const ulong IPMI_SEL_EVENT_TYPE_SENSOR_SPECIFIC = 0x6F;
  public const ulong IPMI_SEL_EVENT_TYPE_OEM_START = 0x70;
  public const ulong IPMI_SEL_EVENT_TYPE_OEM_END = 0x7F;

  //public const ulong SOFTWARE_ID_FROM_GENERATOR_ID = (GeneratorId)((GeneratorId & 0xFF) >> 1);
  //
  // System Software IDs definitions (Section 5.5)
  //
  public const ulong IPMI_SWID_BIOS_RANGE_START = 0x00;
  public const ulong IPMI_SWID_BIOS_RANGE_END = 0x0F;
  public const ulong IPMI_SWID_SMI_HANDLER_RANGE_START = 0x10;
  public const ulong IPMI_SWID_SMI_HANDLER_RANGE_END = 0x1F;
  public const ulong IPMI_SWID_SMS_RANGE_START = 0x20;
  public const ulong IPMI_SWID_SMS_RANGE_END = 0x2F;
  public const ulong IPMI_SWID_OEM_RANGE_START = 0x30;
  public const ulong IPMI_SWID_OEM_RANGE_END = 0x3F;
  public const ulong IPMI_SWID_REMOTE_CONSOLE_RANGE_START = 0x40;
  public const ulong IPMI_SWID_REMOTE_CONSOLE_RANGE_END = 0x46;
  public const ulong IPMI_SWID_TERMINAL_REMOTE_CONSOLE_ID = 0x47;

  //public const ulong SLAVE_ADDRESS_FROM_GENERATOR_ID = (GeneratorId)((GeneratorId & 0xFF) >> 1);
  //public const ulong LUN_FROM_GENERATOR_ID = (GeneratorId)((GeneratorId >> 8) & 0x03);
  //public const ulong CHANNEL_NUMBER_FROM_GENERATOR_ID = (GeneratorId)((GeneratorId >> 12) & 0x0F);

  public const ulong IPMI_EVM_REVISION = 0x04;
  public const ulong IPMI_BIOS_ID = 0x18;
  public const ulong IPMI_FORMAT_REV = 0x00;
  public const ulong IPMI_FORMAT_REV1 = 0x01;
  public const ulong IPMI_SOFTWARE_ID = 0x01;
  public const ulong IPMI_PLATFORM_VAL_ID = 0x01;
  //public const ulong IPMI_GENERATOR_ID = (i, f)((i << 1) | (f << 1) | IPMI_SOFTWARE_ID);

  public const ulong IPMI_SENSOR_TYPE_EVENT_CODE_DISCRETE = 0x6F;

  public const ulong IPMI_OEM_SPECIFIC_DATA = 0x02;
  public const ulong IPMI_SENSOR_SPECIFIC_DATA = 0x03;
}

// #pragma pack()
// #endif

using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  This file contains definitions for SPD LPDDR.

  Copyright (c) 2016, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
    - Serial Presence Detect (SPD) for LPDDR3 and LPDDR4 SDRAM Modules Document Release 2
      http://www.jedec.org/standards-documents/docs/spd412m-2
**/

// #ifndef _SDRAM_SPD_LPDDR_H_
// #define _SDRAM_SPD_LPDDR_H_

// #pragma pack (push, 1)

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD_LPDDR_DEVICE_DESCRIPTION_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte BytesUsed = 4;                       ///< Bits 3:0
  [FieldOffset(0)] public byte BytesTotal = 3;                       ///< Bits 6:4
  [FieldOffset(0)] public byte CrcCoverage = 1;                       ///< Bits 7:7
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD_LPDDR_REVISION_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte Minor = 4;                             ///< Bits 3:0
  [FieldOffset(0)] public byte Major = 4;                             ///< Bits 7:4
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD_LPDDR_DRAM_DEVICE_TYPE_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte Type = 8;                              ///< Bits 7:0
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD_LPDDR_MODULE_TYPE_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte ModuleType = 4;                       ///< Bits 3:0
  [FieldOffset(0)] public byte HybridMedia = 3;                       ///< Bits 6:4
  [FieldOffset(0)] public byte Hybrid = 1;                       ///< Bits 7:7
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD_LPDDR_SDRAM_DENSITY_BANKS_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte Density = 4;                       ///< Bits 3:0
  [FieldOffset(0)] public byte BankAddress = 2;                       ///< Bits 5:4
  [FieldOffset(0)] public byte BankGroup = 2;                       ///< Bits 7:6
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD_LPDDR_SDRAM_ADDRESSING_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte ColumnAddress = 3;                     ///< Bits 2:0
  [FieldOffset(0)] public byte RowAddress = 3;                     ///< Bits 5:3
  [FieldOffset(0)] public byte Reserved = 2;                     ///< Bits 7:6
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD_LPDDR_SDRAM_PACKAGE_TYPE_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte SignalLoading = 2;                  ///< Bits 1:0
  [FieldOffset(0)] public byte ChannelsPerDie = 2;                  ///< Bits 3:2
  [FieldOffset(0)] public byte DieCount = 3;                  ///< Bits 6:4
  [FieldOffset(0)] public byte SdramPackageType = 1;                  ///< Bits 7:7
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD_LPDDR_SDRAM_OPTIONAL_FEATURES_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte MaximumActivateCount = 4;             ///< Bits 3:0
  [FieldOffset(0)] public byte MaximumActivateWindow = 2;             ///< Bits 5:4
  [FieldOffset(0)] public byte Reserved = 2;             ///< Bits 7:6
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD_LPDDR_SDRAM_THERMAL_REFRESH_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte Reserved = 8;                          ///< Bits 7:0
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD_LPDDR_OTHER_SDRAM_OPTIONAL_FEATURES_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte Reserved = 5;                 ///< Bits 4:0
  [FieldOffset(0)] public byte SoftPPR = 1;                 ///< Bits 5:5
  [FieldOffset(0)] public byte PostPackageRepair = 2;                 ///< Bits 7:6
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD_LPDDR_MODULE_NOMINAL_VOLTAGE_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte OperationAt1_20 = 1;                  ///< Bits 0:0
  [FieldOffset(0)] public byte EndurantAt1_20 = 1;                  ///< Bits 1:1
  [FieldOffset(0)] public byte OperationAt1_10 = 1;                  ///< Bits 2:2
  [FieldOffset(0)] public byte EndurantAt1_10 = 1;                  ///< Bits 3:3
  [FieldOffset(0)] public byte OperationAtTBD2V = 1;                  ///< Bits 4:4
  [FieldOffset(0)] public byte EndurantAtTBD2V = 1;                  ///< Bits 5:5
  [FieldOffset(0)] public byte Reserved = 2;                  ///< Bits 7:6
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD_LPDDR_MODULE_ORGANIZATION_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte SdramDeviceWidth = 3;                  ///< Bits 2:0
  [FieldOffset(0)] public byte RankCount = 3;                  ///< Bits 5:3
  [FieldOffset(0)] public byte Reserved = 2;                  ///< Bits 7:6
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD_LPDDR_MODULE_MEMORY_BUS_WIDTH_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte PrimaryBusWidth = 3;                 ///< Bits 2:0
  [FieldOffset(0)] public byte BusWidthExtension = 2;                 ///< Bits 4:3
  [FieldOffset(0)] public byte NumberofChannels = 3;                 ///< Bits 7:5
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD_LPDDR_MODULE_THERMAL_SENSOR_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte Reserved = 7;             ///< Bits 6:0
  [FieldOffset(0)] public byte ThermalSensorPresence = 1;             ///< Bits 7:7
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD_LPDDR_EXTENDED_MODULE_TYPE_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte ExtendedBaseModuleType = 4;            ///< Bits 3:0
  [FieldOffset(0)] public byte Reserved = 4;            ///< Bits 7:4
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD_LPDDR_SIGNAL_LOADING_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte ChipSelectLoading = 3; ///< Bits 2:0
  [FieldOffset(0)] public byte CommandAddressControlClockLoading = 3; ///< Bits 5:3
  [FieldOffset(0)] public byte DataStrobeMaskLoading = 2; ///< Bits 7:6
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD_LPDDR_TIMEBASE_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte Fine = 2;                          ///< Bits 1:0
  [FieldOffset(0)] public byte Medium = 2;                          ///< Bits 3:2
  [FieldOffset(0)] public byte Reserved = 4;                          ///< Bits 7:4
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD_LPDDR_TCK_MIN_MTB_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte tCKmin = 8;                            ///< Bits 7:0
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD_LPDDR_TCK_MAX_MTB_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte tCKmax = 8;                            ///< Bits 7:0
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD_LPDDR_CAS_LATENCIES_SUPPORTED_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public uint Cl3 = 1;                         ///< Bits 0:0
  [FieldOffset(0)] public uint Cl6 = 1;                         ///< Bits 1:1
  [FieldOffset(0)] public uint Cl8 = 1;                         ///< Bits 2:2
  [FieldOffset(0)] public uint Cl9 = 1;                         ///< Bits 3:3
  [FieldOffset(0)] public uint Cl10 = 1;                         ///< Bits 4:4
  [FieldOffset(0)] public uint Cl11 = 1;                         ///< Bits 5:5
  [FieldOffset(0)] public uint Cl12 = 1;                         ///< Bits 6:6
  [FieldOffset(0)] public uint Cl14 = 1;                         ///< Bits 7:7
  [FieldOffset(0)] public uint Cl16 = 1;                         ///< Bits 8:8
  [FieldOffset(0)] public uint Reserved0 = 1;                         ///< Bits 9:9
  [FieldOffset(0)] public uint Cl20 = 1;                         ///< Bits 10:10
  [FieldOffset(0)] public uint Cl22 = 1;                         ///< Bits 11:11
  [FieldOffset(0)] public uint Cl24 = 1;                         ///< Bits 12:12
  [FieldOffset(0)] public uint Reserved1 = 1;                         ///< Bits 13:13
  [FieldOffset(0)] public uint Cl28 = 1;                         ///< Bits 14:14
  [FieldOffset(0)] public uint Reserved2 = 1;                         ///< Bits 15:15
  [FieldOffset(0)] public uint Cl32 = 1;                         ///< Bits 16:16
  [FieldOffset(0)] public uint Reserved3 = 1;                         ///< Bits 17:17
  [FieldOffset(0)] public uint Cl36 = 1;                         ///< Bits 18:18
  [FieldOffset(0)] public uint Reserved4 = 1;                         ///< Bits 19:19
  [FieldOffset(0)] public uint Cl40 = 1;                         ///< Bits 20:20
  [FieldOffset(0)] public uint Reserved5 = 11;                        ///< Bits 31:21
/*   } Bits; */
  [FieldOffset(0)] public uint Data;
  [FieldOffset(0)] public fixed ushort Data16[2];
  [FieldOffset(0)] public fixed byte Data8[4];
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD_LPDDR_TAA_MIN_MTB_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte tAAmin = 8;                            ///< Bits 7:0
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD_LPDDR_RW_LATENCY_OPTION_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte ReadLatencyMode = 2;                   ///< Bits 1:0
  [FieldOffset(0)] public byte WriteLatencySet = 2;                   ///< Bits 3:2
  [FieldOffset(0)] public byte Reserved = 4;                   ///< Bits 7:4
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD_LPDDR_TRCD_MIN_MTB_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte tRCDmin = 8;                           ///< Bits 7:0
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD_LPDDR_TRP_AB_MTB_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte tRPab = 8;                             ///< Bits 7:0
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD_LPDDR_TRP_PB_MTB_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte tRPpb = 8;                             ///< Bits 7:0
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD_LPDDR_TRFC_AB_MTB_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public ushort tRFCab = 16;                           ///< Bits 15:0
/*   } Bits; */
  [FieldOffset(0)] public ushort Data;
  [FieldOffset(0)] public fixed byte Data8[2];
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD_LPDDR_TRFC_PB_MTB_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public ushort tRFCpb = 16;                           ///< Bits 15:0
/*   } Bits; */
  [FieldOffset(0)] public ushort Data;
  [FieldOffset(0)] public fixed byte Data8[2];
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD_LPDDR_CONNECTOR_BIT_MAPPING_BYTE_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte BitOrderatSDRAM = 5;           ///< Bits 4:0
  [FieldOffset(0)] public byte WiredtoUpperLowerNibble = 1;           ///< Bits 5:5
  [FieldOffset(0)] public byte PackageRankMap = 2;           ///< Bits 7:6
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD_LPDDR_TRP_PB_FTB_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public sbyte tRPpbFine = 8;                          ///< Bits 7:0
/*   } Bits; */
  [FieldOffset(0)] public sbyte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD_LPDDR_TRP_AB_FTB_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public sbyte tRPabFine = 8;                          ///< Bits 7:0
/*   } Bits; */
  [FieldOffset(0)] public sbyte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD_LPDDR_TRCD_MIN_FTB_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public sbyte tRCDminFine = 8;                        ///< Bits 7:0
/*   } Bits; */
  [FieldOffset(0)] public sbyte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD_LPDDR_TAA_MIN_FTB_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public sbyte tAAminFine = 8;                         ///< Bits 7:0
/*   } Bits; */
  [FieldOffset(0)] public sbyte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD_LPDDR_TCK_MAX_FTB_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public sbyte tCKmaxFine = 8;                         ///< Bits 7:0
/*   } Bits; */
  [FieldOffset(0)] public sbyte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD_LPDDR_TCK_MIN_FTB_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public sbyte tCKminFine = 8;                         ///< Bits 7:0
/*   } Bits; */
  [FieldOffset(0)] public sbyte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD_LPDDR_MANUFACTURER_ID_CODE
{
  /*   struct { */
  [FieldOffset(0)] public ushort ContinuationCount = 7;               ///< Bits 6:0
  [FieldOffset(0)] public ushort ContinuationParity = 1;               ///< Bits 7:7
  [FieldOffset(0)] public ushort LastNonZeroByte = 8;               ///< Bits 15:8
/*   } Bits; */
  [FieldOffset(0)] public ushort Data;
  [FieldOffset(0)] public fixed byte Data8[2];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPD_LPDDR_MANUFACTURING_LOCATION
{
  public byte Location;                           ///< Module Manufacturing Location
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPD_LPDDR_MANUFACTURING_DATE
{
  public byte Year;                               ///< Year represented in BCD (00h = 2000)
  public byte Week;                               ///< Year represented in BCD (47h = week 47)
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD_LPDDR_MANUFACTURER_SERIAL_NUMBER
{
  [FieldOffset(0)] public uint Data;
  [FieldOffset(0)] public fixed ushort SerialNumber16[2];
  [FieldOffset(0)] public fixed byte SerialNumber8[4];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPD_LPDDR_UNIQUE_MODULE_ID
{
  public SPD_LPDDR_MANUFACTURER_ID_CODE IdCode;                     ///< Module Manufacturer ID Code
  public SPD_LPDDR_MANUFACTURING_LOCATION Location;                   ///< Module Manufacturing Location
  public SPD_LPDDR_MANUFACTURING_DATE Date;                       ///< Module Manufacturing Year, in BCD (range: 2000-2255)
  public SPD_LPDDR_MANUFACTURER_SERIAL_NUMBER SerialNumber;               ///< Module Serial Number
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD_LPDDR_MODULE_MAXIMUM_THICKNESS
{
  /*   struct { */
  [FieldOffset(0)] public byte FrontThickness = 4;                    ///< Bits 3:0
  [FieldOffset(0)] public byte BackThickness = 4;                    ///< Bits 7:4
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD_LPDDR_MODULE_NOMINAL_HEIGHT
{
  /*   struct { */
  [FieldOffset(0)] public byte Height = 5;                  ///< Bits 4:0
  [FieldOffset(0)] public byte RawCardExtension = 3;                  ///< Bits 7:5
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD_LPDDR_REFERENCE_RAW_CARD
{
  /*   struct { */
  [FieldOffset(0)] public byte Card = 5;                         ///< Bits 4:0
  [FieldOffset(0)] public byte Revision = 2;                         ///< Bits 6:5
  [FieldOffset(0)] public byte Extension = 1;                         ///< Bits 7:7
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD_LPDDR_CYCLIC_REDUNDANCY_CODE
{
  [FieldOffset(0)] public fixed ushort Crc[1];
  [FieldOffset(0)] public fixed byte Data8[2];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPD_LPDDR_BASE_SECTION
{
  public SPD_LPDDR_DEVICE_DESCRIPTION_STRUCT Description;              ///< 0       Number of Serial PD Bytes Written / SPD Device Size / CRC Coverage 1, 2
  public SPD_LPDDR_REVISION_STRUCT Revision;                 ///< 1       SPD Revision
  public SPD_LPDDR_DRAM_DEVICE_TYPE_STRUCT DramDeviceType;           ///< 2       DRAM Device Type
  public SPD_LPDDR_MODULE_TYPE_STRUCT ModuleType;               ///< 3       Module Type
  public SPD_LPDDR_SDRAM_DENSITY_BANKS_STRUCT SdramDensityAndBanks;     ///< 4       SDRAM Density and Banks
  public SPD_LPDDR_SDRAM_ADDRESSING_STRUCT SdramAddressing;          ///< 5       SDRAM Addressing
  public SPD_LPDDR_SDRAM_PACKAGE_TYPE_STRUCT SdramPackageType;         ///< 6       SDRAM Package Type
  public SPD_LPDDR_SDRAM_OPTIONAL_FEATURES_STRUCT SdramOptionalFeatures;    ///< 7       SDRAM Optional Features
  public SPD_LPDDR_SDRAM_THERMAL_REFRESH_STRUCT ThermalAndRefreshOptions; ///< 8       SDRAM Thermal and Refresh Options
  public SPD_LPDDR_OTHER_SDRAM_OPTIONAL_FEATURES_STRUCT OtherOptionalFeatures;    ///< 9      Other SDRAM Optional Features
  public byte Reserved0;                ///< 10      Reserved
  public SPD_LPDDR_MODULE_NOMINAL_VOLTAGE_STRUCT ModuleNominalVoltage;     ///< 11      Module Nominal Voltage, VDD
  public SPD_LPDDR_MODULE_ORGANIZATION_STRUCT ModuleOrganization;       ///< 12      Module Organization
  public SPD_LPDDR_MODULE_MEMORY_BUS_WIDTH_STRUCT ModuleMemoryBusWidth;     ///< 13      Module Memory Bus Width
  public SPD_LPDDR_MODULE_THERMAL_SENSOR_STRUCT ModuleThermalSensor;      ///< 14      Module Thermal Sensor
  public SPD_LPDDR_EXTENDED_MODULE_TYPE_STRUCT ExtendedModuleType;       ///< 15      Extended Module Type
  public SPD_LPDDR_SIGNAL_LOADING_STRUCT SignalLoading;            ///< 16      Signal Loading
  public SPD_LPDDR_TIMEBASE_STRUCT Timebase;                 ///< 17      Timebases
  public SPD_LPDDR_TCK_MIN_MTB_STRUCT tCKmin;                   ///< 18      SDRAM Minimum Cycle Time (tCKmin)
  public SPD_LPDDR_TCK_MAX_MTB_STRUCT tCKmax;                   ///< 19      SDRAM Maximum Cycle Time (tCKmax)
  public SPD_LPDDR_CAS_LATENCIES_SUPPORTED_STRUCT CasLatencies;             ///< 20-23   CAS Latencies Supported
  public SPD_LPDDR_TAA_MIN_MTB_STRUCT tAAmin;                   ///< 24      Minimum CAS Latency Time (tAAmin)
  public SPD_LPDDR_RW_LATENCY_OPTION_STRUCT LatencySetOptions;        ///< 25      Read and Write Latency Set Options
  public SPD_LPDDR_TRCD_MIN_MTB_STRUCT tRCDmin;                  ///< 26      Minimum RAS# to CAS# Delay Time (tRCDmin)
  public SPD_LPDDR_TRP_AB_MTB_STRUCT tRPab;                    ///< 27      Minimum Row Precharge Delay Time (tRPab), all banks
  public SPD_LPDDR_TRP_PB_MTB_STRUCT tRPpb;                    ///< 28      Minimum Row Precharge Delay Time (tRPpb), per bank
  public SPD_LPDDR_TRFC_AB_MTB_STRUCT tRFCab;                   ///< 29-30   Minimum Refresh Recovery Delay Time (tRFCab), all banks
  public SPD_LPDDR_TRFC_PB_MTB_STRUCT tRFCpb;                   ///< 31-32   Minimum Refresh Recovery Delay Time (tRFCpb), per bank
  public fixed byte Reserved1[59 - 33 + 1];   ///< 33-59   Reserved
  public fixed SPD_LPDDR_CONNECTOR_BIT_MAPPING_BYTE_STRUCT BitMapping[77 - 60 + 1];  ///< 60-77   Connector to SDRAM Bit Mapping
  public fixed byte Reserved2[119 - 78 + 1];  ///< 78-119  Reserved
  public SPD_LPDDR_TRP_PB_FTB_STRUCT tRPpbFine;                ///< 120     Fine Offset for Minimum Row Precharge Delay Time (tRPpbFine), per bank
  public SPD_LPDDR_TRP_AB_FTB_STRUCT tRPabFine;                ///< 121     Fine Offset for Minimum Row Precharge Delay Time (tRPabFine), all ranks
  public SPD_LPDDR_TRCD_MIN_FTB_STRUCT tRCDminFine;              ///< 122     Fine Offset for Minimum RAS# to CAS# Delay Time (tRCDmin)
  public SPD_LPDDR_TAA_MIN_FTB_STRUCT tAAminFine;               ///< 123     Fine Offset for Minimum CAS Latency Time (tAAmin)
  public SPD_LPDDR_TCK_MAX_FTB_STRUCT tCKmaxFine;               ///< 124     Fine Offset for SDRAM Maximum Cycle Time (tCKmax)
  public SPD_LPDDR_TCK_MIN_FTB_STRUCT tCKminFine;               ///< 125     Fine Offset for SDRAM Minimum Cycle Time (tCKmin)
  public SPD_LPDDR_CYCLIC_REDUNDANCY_CODE Crc;                      ///< 126-127 Cyclical Redundancy Code (CRC)
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPD_LPDDR_MODULE_LPDIMM
{
  public SPD_LPDDR_MODULE_NOMINAL_HEIGHT ModuleNominalHeight;        ///< 128     Module Nominal Height
  public SPD_LPDDR_MODULE_MAXIMUM_THICKNESS ModuleMaximumThickness;     ///< 129     Module Maximum Thickness
  public SPD_LPDDR_REFERENCE_RAW_CARD ReferenceRawCardUsed;       ///< 130     Reference Raw Card Used
  public fixed byte Reserved[253 - 131 + 1];    ///< 131-253 Reserved
  public SPD_LPDDR_CYCLIC_REDUNDANCY_CODE Crc;                        ///< 254-255 Cyclical Redundancy Code (CRC)
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPD_LPDDR_MODULE_SPECIFIC
{
  public SPD_LPDDR_MODULE_LPDIMM LpDimm;                                ///< 128-255 Unbuffered Memory Module Types
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPD_LPDDR_MODULE_PART_NUMBER
{
  public fixed byte ModulePartNumber[348 - 329 + 1];                                ///< 329-348 Module Part Number
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPD_LPDDR_MANUFACTURER_SPECIFIC
{
  public fixed byte ManufacturerSpecificData[381 - 353 + 1];                                ///< 353-381 Manufacturer's Specific Data
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPD_LPDDR_MODULE_REVISION_CODE { byte Value; public static implicit operator SPD_LPDDR_MODULE_REVISION_CODE(byte value) => new SPD_LPDDR_MODULE_REVISION_CODE() { Value = value }; public static implicit operator byte(SPD_LPDDR_MODULE_REVISION_CODE value) => value.Value; }
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPD_LPDDR_DRAM_STEPPING { byte Value; public static implicit operator SPD_LPDDR_DRAM_STEPPING(byte value) => new SPD_LPDDR_DRAM_STEPPING() { Value = value }; public static implicit operator byte(SPD_LPDDR_DRAM_STEPPING value) => value.Value; }

[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPD_LPDDR_MANUFACTURING_DATA
{
  public SPD_LPDDR_UNIQUE_MODULE_ID ModuleId;                      ///< 320-328 Unique Module ID
  public SPD_LPDDR_MODULE_PART_NUMBER ModulePartNumber;              ///< 329-348 Module Part Number
  public SPD_LPDDR_MODULE_REVISION_CODE ModuleRevisionCode;            ///< 349     Module Revision Code
  public SPD_LPDDR_MANUFACTURER_ID_CODE DramIdCode;                    ///< 350-351 Dram Manufacturer ID Code
  public SPD_LPDDR_DRAM_STEPPING DramStepping;                  ///< 352     Dram Stepping
  public SPD_LPDDR_MANUFACTURER_SPECIFIC ManufacturerSpecificData;      ///< 353-381 Manufacturer's Specific Data
  public fixed byte Reserved[383 - 382 + 1];       ///< 382-383 Reserved
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPD_LPDDR_END_USER_SECTION
{
  public fixed byte Reserved[511 - 384 + 1];                                 ///< 384-511 End User Programmable
}

///
/// LPDDR Serial Presence Detect structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPD_LPDDR
{
  public SPD_LPDDR_BASE_SECTION Base;                             ///< 0-127   Base Configuration and DRAM Parameters
  public SPD_LPDDR_MODULE_SPECIFIC Module;                           ///< 128-255 Module-Specific Section
  public fixed byte Reserved[319 - 256 + 1];          ///< 256-319 Hybrid Memory Parameters
  public SPD_LPDDR_MANUFACTURING_DATA ManufactureInfo;                  ///< 320-383 Manufacturing Information
  public SPD_LPDDR_END_USER_SECTION EndUser;                          ///< 384-511 End User Programmable
}

// #pragma pack (pop)
// #endif

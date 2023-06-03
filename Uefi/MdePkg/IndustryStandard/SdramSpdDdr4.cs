using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  This file contains definitions for SPD DDR4.

  Copyright (c) 2016, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
    - Serial Presence Detect (SPD) for DDR4 SDRAM Modules Document Release 4
      http://www.jedec.org/standards-documents/docs/spd412l-4
**/

// #ifndef _SDRAM_SPD_DDR4_H_
// #define _SDRAM_SPD_DDR4_H_

// #pragma pack (push, 1)

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_DEVICE_DESCRIPTION_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte BytesUsed = 4;                       ///< Bits 3:0
  [FieldOffset(0)] public byte BytesTotal = 3;                       ///< Bits 6:4
  [FieldOffset(0)] public byte CrcCoverage = 1;                       ///< Bits 7:7
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_REVISION_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte Minor = 4;                             ///< Bits 3:0
  [FieldOffset(0)] public byte Major = 4;                             ///< Bits 7:4
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_DRAM_DEVICE_TYPE_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte Type = 8;                              ///< Bits 7:0
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_MODULE_TYPE_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte ModuleType = 4;                       ///< Bits 3:0
  [FieldOffset(0)] public byte HybridMedia = 3;                       ///< Bits 6:4
  [FieldOffset(0)] public byte Hybrid = 1;                       ///< Bits 7:7
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_SDRAM_DENSITY_BANKS_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte Density = 4;                       ///< Bits 3:0
  [FieldOffset(0)] public byte BankAddress = 2;                       ///< Bits 5:4
  [FieldOffset(0)] public byte BankGroup = 2;                       ///< Bits 7:6
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_SDRAM_ADDRESSING_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte ColumnAddress = 3;                     ///< Bits 2:0
  [FieldOffset(0)] public byte RowAddress = 3;                     ///< Bits 5:3
  [FieldOffset(0)] public byte Reserved = 2;                     ///< Bits 7:6
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_PRIMARY_SDRAM_PACKAGE_TYPE_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte SignalLoading = 2;                  ///< Bits 1:0
  [FieldOffset(0)] public byte Reserved = 2;                  ///< Bits 3:2
  [FieldOffset(0)] public byte DieCount = 3;                  ///< Bits 6:4
  [FieldOffset(0)] public byte SdramPackageType = 1;                  ///< Bits 7:7
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_SDRAM_OPTIONAL_FEATURES_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte MaximumActivateCount = 4;             ///< Bits 3:0
  [FieldOffset(0)] public byte MaximumActivateWindow = 2;             ///< Bits 5:4
  [FieldOffset(0)] public byte Reserved = 2;             ///< Bits 7:6
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_SDRAM_THERMAL_REFRESH_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte Reserved = 8;                          ///< Bits 7:0
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_OTHER_SDRAM_OPTIONAL_FEATURES_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte Reserved = 5;                 ///< Bits 4:0
  [FieldOffset(0)] public byte SoftPPR = 1;                 ///< Bits 5:5
  [FieldOffset(0)] public byte PostPackageRepair = 2;                 ///< Bits 7:6
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_SECONDARY_SDRAM_PACKAGE_TYPE_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte SignalLoading = 2;                  ///< Bits 1:0
  [FieldOffset(0)] public byte DRAMDensityRatio = 2;                  ///< Bits 3:2
  [FieldOffset(0)] public byte DieCount = 3;                  ///< Bits 6:4
  [FieldOffset(0)] public byte SdramPackageType = 1;                  ///< Bits 7:7
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_MODULE_NOMINAL_VOLTAGE_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte OperationAt1_20 = 1;                   ///< Bits 0:0
  [FieldOffset(0)] public byte EndurantAt1_20 = 1;                   ///< Bits 1:1
  [FieldOffset(0)] public byte Reserved = 6;                   ///< Bits 7:2
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_MODULE_ORGANIZATION_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte SdramDeviceWidth = 3;                  ///< Bits 2:0
  [FieldOffset(0)] public byte RankCount = 3;                  ///< Bits 5:3
  [FieldOffset(0)] public byte RankMix = 1;                  ///< Bits 6:6
  [FieldOffset(0)] public byte Reserved = 1;                  ///< Bits 7:7
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_MODULE_MEMORY_BUS_WIDTH_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte PrimaryBusWidth = 3;                 ///< Bits 2:0
  [FieldOffset(0)] public byte BusWidthExtension = 2;                 ///< Bits 4:3
  [FieldOffset(0)] public byte Reserved = 3;                 ///< Bits 7:5
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_MODULE_THERMAL_SENSOR_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte Reserved = 7;             ///< Bits 6:0
  [FieldOffset(0)] public byte ThermalSensorPresence = 1;             ///< Bits 7:7
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_EXTENDED_MODULE_TYPE_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte ExtendedBaseModuleType = 4;            ///< Bits 3:0
  [FieldOffset(0)] public byte Reserved = 4;            ///< Bits 7:4
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_TIMEBASE_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte Fine = 2;                          ///< Bits 1:0
  [FieldOffset(0)] public byte Medium = 2;                          ///< Bits 3:2
  [FieldOffset(0)] public byte Reserved = 4;                          ///< Bits 7:4
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_TCK_MIN_MTB_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte tCKmin = 8;                            ///< Bits 7:0
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_TCK_MAX_MTB_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte tCKmax = 8;                            ///< Bits 7:0
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_CAS_LATENCIES_SUPPORTED_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public uint Cl7 = 1;                         ///< Bits 0:0
  [FieldOffset(0)] public uint Cl8 = 1;                         ///< Bits 1:1
  [FieldOffset(0)] public uint Cl9 = 1;                         ///< Bits 2:2
  [FieldOffset(0)] public uint Cl10 = 1;                         ///< Bits 3:3
  [FieldOffset(0)] public uint Cl11 = 1;                         ///< Bits 4:4
  [FieldOffset(0)] public uint Cl12 = 1;                         ///< Bits 5:5
  [FieldOffset(0)] public uint Cl13 = 1;                         ///< Bits 6:6
  [FieldOffset(0)] public uint Cl14 = 1;                         ///< Bits 7:7
  [FieldOffset(0)] public uint Cl15 = 1;                         ///< Bits 8:8
  [FieldOffset(0)] public uint Cl16 = 1;                         ///< Bits 9:9
  [FieldOffset(0)] public uint Cl17 = 1;                         ///< Bits 10:10
  [FieldOffset(0)] public uint Cl18 = 1;                         ///< Bits 11:11
  [FieldOffset(0)] public uint Cl19 = 1;                         ///< Bits 12:12
  [FieldOffset(0)] public uint Cl20 = 1;                         ///< Bits 13:13
  [FieldOffset(0)] public uint Cl21 = 1;                         ///< Bits 14:14
  [FieldOffset(0)] public uint Cl22 = 1;                         ///< Bits 15:15
  [FieldOffset(0)] public uint Cl23 = 1;                         ///< Bits 16:16
  [FieldOffset(0)] public uint Cl24 = 1;                         ///< Bits 17:17
  [FieldOffset(0)] public uint Cl25 = 1;                         ///< Bits 18:18
  [FieldOffset(0)] public uint Cl26 = 1;                         ///< Bits 19:19
  [FieldOffset(0)] public uint Cl27 = 1;                         ///< Bits 20:20
  [FieldOffset(0)] public uint Cl28 = 1;                         ///< Bits 21:21
  [FieldOffset(0)] public uint Cl29 = 1;                         ///< Bits 22:22
  [FieldOffset(0)] public uint Cl30 = 1;                         ///< Bits 23:23
  [FieldOffset(0)] public uint Cl31 = 1;                         ///< Bits 24:24
  [FieldOffset(0)] public uint Cl32 = 1;                         ///< Bits 25:25
  [FieldOffset(0)] public uint Cl33 = 1;                         ///< Bits 26:26
  [FieldOffset(0)] public uint Cl34 = 1;                         ///< Bits 27:27
  [FieldOffset(0)] public uint Cl35 = 1;                         ///< Bits 28:28
  [FieldOffset(0)] public uint Cl36 = 1;                         ///< Bits 29:29
  [FieldOffset(0)] public uint Reserved = 1;                         ///< Bits 30:30
  [FieldOffset(0)] public uint ClRange = 1;                         ///< Bits 31:31
  /*   } Bits; */
  /*   struct { */
  [FieldOffset(0)] public uint Cl23 = 1;                         ///< Bits 0:0
  [FieldOffset(0)] public uint Cl24 = 1;                         ///< Bits 1:1
  [FieldOffset(0)] public uint Cl25 = 1;                         ///< Bits 2:2
  [FieldOffset(0)] public uint Cl26 = 1;                         ///< Bits 3:3
  [FieldOffset(0)] public uint Cl27 = 1;                         ///< Bits 4:4
  [FieldOffset(0)] public uint Cl28 = 1;                         ///< Bits 5:5
  [FieldOffset(0)] public uint Cl29 = 1;                         ///< Bits 6:6
  [FieldOffset(0)] public uint Cl30 = 1;                         ///< Bits 7:7
  [FieldOffset(0)] public uint Cl31 = 1;                         ///< Bits 8:8
  [FieldOffset(0)] public uint Cl32 = 1;                         ///< Bits 9:9
  [FieldOffset(0)] public uint Cl33 = 1;                         ///< Bits 10:10
  [FieldOffset(0)] public uint Cl34 = 1;                         ///< Bits 11:11
  [FieldOffset(0)] public uint Cl35 = 1;                         ///< Bits 12:12
  [FieldOffset(0)] public uint Cl36 = 1;                         ///< Bits 13:13
  [FieldOffset(0)] public uint Cl37 = 1;                         ///< Bits 14:14
  [FieldOffset(0)] public uint Cl38 = 1;                         ///< Bits 15:15
  [FieldOffset(0)] public uint Cl39 = 1;                         ///< Bits 16:16
  [FieldOffset(0)] public uint Cl40 = 1;                         ///< Bits 17:17
  [FieldOffset(0)] public uint Cl41 = 1;                         ///< Bits 18:18
  [FieldOffset(0)] public uint Cl42 = 1;                         ///< Bits 19:19
  [FieldOffset(0)] public uint Cl43 = 1;                         ///< Bits 20:20
  [FieldOffset(0)] public uint Cl44 = 1;                         ///< Bits 21:21
  [FieldOffset(0)] public uint Cl45 = 1;                         ///< Bits 22:22
  [FieldOffset(0)] public uint Cl46 = 1;                         ///< Bits 23:23
  [FieldOffset(0)] public uint Cl47 = 1;                         ///< Bits 24:24
  [FieldOffset(0)] public uint Cl48 = 1;                         ///< Bits 25:25
  [FieldOffset(0)] public uint Cl49 = 1;                         ///< Bits 26:26
  [FieldOffset(0)] public uint Cl50 = 1;                         ///< Bits 27:27
  [FieldOffset(0)] public uint Cl51 = 1;                         ///< Bits 28:28
  [FieldOffset(0)] public uint Cl52 = 1;                         ///< Bits 29:29
  [FieldOffset(0)] public uint Reserved = 1;                         ///< Bits 30:30
  [FieldOffset(0)] public uint ClRange = 1;                         ///< Bits 31:31
/*   } HighRangeBits; */
  [FieldOffset(0)] public uint Data;
  [FieldOffset(0)] public fixed ushort Data16[2];
  [FieldOffset(0)] public fixed byte Data8[4];
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_TAA_MIN_MTB_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte tAAmin = 8;                            ///< Bits 7:0
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_TRCD_MIN_MTB_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte tRCDmin = 8;                           ///< Bits 7:0
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_TRP_MIN_MTB_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte tRPmin = 8;                            ///< Bits 7:0
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_TRAS_TRC_MIN_MTB_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte tRASminUpper = 4;                      ///< Bits 3:0
  [FieldOffset(0)] public byte tRCminUpper = 4;                      ///< Bits 7:4
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_TRAS_MIN_MTB_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte tRASmin = 8;                           ///< Bits 7:0
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_TRC_MIN_MTB_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte tRCmin = 8;                            ///< Bits 7:0
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_TRFC_MIN_MTB_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public ushort tRFCmin = 16;                          ///< Bits 15:0
/*   } Bits; */
  [FieldOffset(0)] public ushort Data;
  [FieldOffset(0)] public fixed byte Data8[2];
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_TFAW_MIN_MTB_UPPER_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte tFAWminUpper = 4;                      ///< Bits 3:0
  [FieldOffset(0)] public byte Reserved = 4;                      ///< Bits 7:4
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_TFAW_MIN_MTB_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte tFAWmin = 8;                           ///< Bits 7:0
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_TRRD_MIN_MTB_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte tRRDmin = 8;                           ///< Bits 7:0
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_TCCD_MIN_MTB_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte tCCDmin = 8;                           ///< Bits 7:0
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_TWR_UPPER_NIBBLE_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte tWRminMostSignificantNibble = 4;       ///< Bits 3:0
  [FieldOffset(0)] public byte Reserved = 4;       ///< Bits 7:4
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_TWR_MIN_MTB_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte tWRmin = 8;                            ///< Bits 7:0
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_TWTR_UPPER_NIBBLE_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte tWTR_SminMostSignificantNibble = 4;    ///< Bits 3:0
  [FieldOffset(0)] public byte tWTR_LminMostSignificantNibble = 4;    ///< Bits 7:4
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_TWTR_MIN_MTB_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte tWTRmin = 8;                           ///< Bits 7:0
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_CONNECTOR_BIT_MAPPING_BYTE_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public byte BitOrderatSDRAM = 5;           ///< Bits 4:0
  [FieldOffset(0)] public byte WiredtoUpperLowerNibble = 1;           ///< Bits 5:5
  [FieldOffset(0)] public byte PackageRankMap = 2;           ///< Bits 7:6
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_TCCD_MIN_FTB_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public sbyte tCCDminFine = 8;                        ///< Bits 7:0
/*   } Bits; */
  [FieldOffset(0)] public sbyte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_TRRD_MIN_FTB_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public sbyte tRRDminFine = 8;                        ///< Bits 7:0
/*   } Bits; */
  [FieldOffset(0)] public sbyte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_TRC_MIN_FTB_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public sbyte tRCminFine = 8;                         ///< Bits 7:0
/*   } Bits; */
  [FieldOffset(0)] public sbyte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_TRP_MIN_FTB_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public sbyte tRPminFine = 8;                         ///< Bits 7:0
/*   } Bits; */
  [FieldOffset(0)] public sbyte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_TRCD_MIN_FTB_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public sbyte tRCDminFine = 8;                        ///< Bits 7:0
/*   } Bits; */
  [FieldOffset(0)] public sbyte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_TAA_MIN_FTB_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public sbyte tAAminFine = 8;                         ///< Bits 7:0
/*   } Bits; */
  [FieldOffset(0)] public sbyte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_TCK_MAX_FTB_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public sbyte tCKmaxFine = 8;                         ///< Bits 7:0
/*   } Bits; */
  [FieldOffset(0)] public sbyte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_TCK_MIN_FTB_STRUCT
{
  /*   struct { */
  [FieldOffset(0)] public sbyte tCKminFine = 8;                         ///< Bits 7:0
/*   } Bits; */
  [FieldOffset(0)] public sbyte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_UNBUF_MODULE_NOMINAL_HEIGHT
{
  /*   struct { */
  [FieldOffset(0)] public byte Height = 5;                  ///< Bits 4:0
  [FieldOffset(0)] public byte RawCardExtension = 3;                  ///< Bits 7:5
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_UNBUF_MODULE_NOMINAL_THICKNESS
{
  /*   struct { */
  [FieldOffset(0)] public byte FrontThickness = 4;                    ///< Bits 3:0
  [FieldOffset(0)] public byte BackThickness = 4;                    ///< Bits 7:4
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_UNBUF_REFERENCE_RAW_CARD
{
  /*   struct { */
  [FieldOffset(0)] public byte Card = 5;                         ///< Bits 4:0
  [FieldOffset(0)] public byte Revision = 2;                         ///< Bits 6:5
  [FieldOffset(0)] public byte Extension = 1;                         ///< Bits 7:7
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_UNBUF_ADDRESS_MAPPING
{
  /*   struct { */
  [FieldOffset(0)] public byte MappingRank1 = 1;                      ///< Bits 0:0
  [FieldOffset(0)] public byte Reserved = 7;                      ///< Bits 7:1
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_RDIMM_MODULE_NOMINAL_HEIGHT
{
  /*   struct { */
  [FieldOffset(0)] public byte Height = 5;                          ///< Bits 4:0
  [FieldOffset(0)] public byte Reserved = 3;                          ///< Bits 7:5
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_RDIMM_MODULE_NOMINAL_THICKNESS
{
  /*   struct { */
  [FieldOffset(0)] public byte FrontThickness = 4;                    ///< Bits 3:0
  [FieldOffset(0)] public byte BackThickness = 4;                    ///< Bits 7:4
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_RDIMM_REFERENCE_RAW_CARD
{
  /*   struct { */
  [FieldOffset(0)] public byte Card = 5;                         ///< Bits 4:0
  [FieldOffset(0)] public byte Revision = 2;                         ///< Bits 6:5
  [FieldOffset(0)] public byte Extension = 1;                         ///< Bits 7:7
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_RDIMM_MODULE_ATTRIBUTES
{
  /*   struct { */
  [FieldOffset(0)] public byte RegisterCount = 2;                     ///< Bits 1:0
  [FieldOffset(0)] public byte DramRowCount = 2;                     ///< Bits 3:2
  [FieldOffset(0)] public byte RegisterType = 4;                     ///< Bits 7:4
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_RDIMM_THERMAL_HEAT_SPREADER_SOLUTION
{
  /*   struct { */
  [FieldOffset(0)] public byte HeatSpreaderThermalCharacteristics = 7; ///< Bits 6:0
  [FieldOffset(0)] public byte HeatSpreaderSolution = 1; ///< Bits 7:7
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_MANUFACTURER_ID_CODE
{
  /*   struct { */
  [FieldOffset(0)] public ushort ContinuationCount = 7;               ///< Bits 6:0
  [FieldOffset(0)] public ushort ContinuationParity = 1;               ///< Bits 7:7
  [FieldOffset(0)] public ushort LastNonZeroByte = 8;               ///< Bits 15:8
/*   } Bits; */
  [FieldOffset(0)] public ushort Data;
  [FieldOffset(0)] public fixed byte Data8[2];
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_RDIMM_REGISTER_REVISION_NUMBER
{
  /*   struct { */
  [FieldOffset(0)] public byte RegisterRevisionNumber;           ///< Bits 7:0
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_RDIMM_ADDRESS_MAPPING_FROM_REGISTER_TO_DRAM
{
  /*   struct { */
  [FieldOffset(0)] public byte Rank1Mapping = 1;                     ///< Bits 0:0
  [FieldOffset(0)] public byte Reserved = 7;                     ///< Bits 7:1
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_RDIMM_REGISTER_OUTPUT_DRIVE_STRENGTH_FOR_CONTROL_COMMAND_ADDRESS
{
  /*   struct { */
  [FieldOffset(0)] public byte Cke = 2;                   ///< Bits 1:0
  [FieldOffset(0)] public byte Odt = 2;                   ///< Bits 3:2
  [FieldOffset(0)] public byte CommandAddress = 2;                   ///< Bits 5:4
  [FieldOffset(0)] public byte ChipSelect = 2;                   ///< Bits 7:6
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_RDIMM_REGISTER_OUTPUT_DRIVE_STRENGTH_FOR_CLOCK
{
  /*   struct { */
  [FieldOffset(0)] public byte Y0Y2 = 2;         ///< Bits 1:0
  [FieldOffset(0)] public byte Y1Y3 = 2;         ///< Bits 3:2
  [FieldOffset(0)] public byte Reserved0 = 2;         ///< Bits 5:4
  [FieldOffset(0)] public byte RcdOutputSlewRateControl = 1;         ///< Bits 6:6
  [FieldOffset(0)] public byte Reserved1 = 1;         ///< Bits 7:7
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_LRDIMM_MODULE_NOMINAL_HEIGHT
{
  /*   struct { */
  [FieldOffset(0)] public byte Height = 5;                         ///< Bits 4:0
  [FieldOffset(0)] public byte Reserved = 3;                         ///< Bits 7:5
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_LRDIMM_MODULE_NOMINAL_THICKNESS
{
  /*   struct { */
  [FieldOffset(0)] public byte FrontThickness = 4;                   ///< Bits 3:0
  [FieldOffset(0)] public byte BackThickness = 4;                   ///< Bits 7:4
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_LRDIMM_REFERENCE_RAW_CARD
{
  /*   struct { */
  [FieldOffset(0)] public byte Card = 5;                        ///< Bits 4:0
  [FieldOffset(0)] public byte Revision = 2;                        ///< Bits 6:5
  [FieldOffset(0)] public byte Extension = 1;                        ///< Bits 7:7
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_LRDIMM_MODULE_ATTRIBUTES
{
  /*   struct { */
  [FieldOffset(0)] public byte RegisterCount = 2;                    ///< Bits 1:0
  [FieldOffset(0)] public byte DramRowCount = 2;                    ///< Bits 3:2
  [FieldOffset(0)] public byte RegisterType = 4;                    ///< Bits 7:4
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_LRDIMM_THERMAL_HEAT_SPREADER_SOLUTION
{
  /*   struct { */
  [FieldOffset(0)] public byte HeatSpreaderThermalCharacteristics = 7; ///< Bits 6:0
  [FieldOffset(0)] public byte HeatSpreaderSolution = 1; ///< Bits 7:7
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_LRDIMM_REGISTER_REVISION_NUMBER
{
  /*   struct { */
  [FieldOffset(0)] public byte RegisterRevisionNumber;                ///< Bits 7:0
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_LRDIMM_ADDRESS_MAPPING_FROM_REGISTER_TO_DRAM
{
  /*   struct { */
  [FieldOffset(0)] public byte Rank1Mapping = 1;                     ///< Bits 0:0
  [FieldOffset(0)] public byte Reserved = 7;                     ///< Bits 7:1
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_LRDIMM_REGISTER_OUTPUT_DRIVE_STRENGTH_FOR_CONTROL_COMMAND_ADDRESS
{
  /*   struct { */
  [FieldOffset(0)] public byte Cke = 2;                   ///< Bits 1:0
  [FieldOffset(0)] public byte Odt = 2;                   ///< Bits 3:2
  [FieldOffset(0)] public byte CommandAddress = 2;                   ///< Bits 5:4
  [FieldOffset(0)] public byte ChipSelect = 2;                   ///< Bits 7:6
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_LRDIMM_REGISTER_OUTPUT_DRIVE_STRENGTH_FOR_CLOCK
{
  /*   struct { */
  [FieldOffset(0)] public byte Y0Y2 = 2;         ///< Bits 1:0
  [FieldOffset(0)] public byte Y1Y3 = 2;         ///< Bits 3:2
  [FieldOffset(0)] public byte Reserved0 = 2;         ///< Bits 5:4
  [FieldOffset(0)] public byte RcdOutputSlewRateControl = 1;         ///< Bits 6:6
  [FieldOffset(0)] public byte Reserved1 = 1;         ///< Bits 7:7
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPD4_LRDIMM_DATA_BUFFER_REVISION_NUMBER
{
  public byte DataBufferRevisionNumber;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_LRDIMM_DRAM_VREFDQ_FOR_PACKAGE_RANK
{
  /*   struct { */
  [FieldOffset(0)] public byte DramVrefDQForPackageRank0 = 6;        ///< Bits 5:0
  [FieldOffset(0)] public byte Reserved = 2;        ///< Bits 7:6
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPD4_LRDIMM_DATA_BUFFER_VREFDQ_FOR_DRAM_INTERFACE
{
  public byte DataBufferVrefDQforDramInterface;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_LRDIMM_DATA_BUFFER_MDQ_DRIVE_STRENGTH_RTT_FOR_DATA_RATE
{
  /*   struct { */
  [FieldOffset(0)] public byte DramInterfaceMdqDriveStrength = 4; ///< Bits 3:0
  [FieldOffset(0)] public byte DramInterfaceMdqReadTerminationStrength = 4; ///< Bits 7:4
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_LRDIMM_DRAM_DRIVE_STRENGTH
{
  /*   struct { */
  [FieldOffset(0)] public byte DataRateLe1866 = 2;                         ///< Bits 1:0
  [FieldOffset(0)] public byte DataRateLe2400 = 2;                         ///< Bits 3:2
  [FieldOffset(0)] public byte DataRateLe3200 = 2;                         ///< Bits 5:4
  [FieldOffset(0)] public byte Reserved = 2;                         ///< Bits 7:6
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_LRDIMM_DRAM_ODT_RTT_WR_RTT_NOM_FOR_DATA_RATE
{
  /*   struct { */
  [FieldOffset(0)] public byte Rtt_Nom = 3;                               ///< Bits 2:0
  [FieldOffset(0)] public byte Rtt_WR = 3;                               ///< Bits 5:3
  [FieldOffset(0)] public byte Reserved = 2;                               ///< Bits 7:6
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_LRDIMM_DRAM_ODT_RTT_PARK_FOR_DATA_RATE
{
  /*   struct { */
  [FieldOffset(0)] public byte PackageRanks0_1 = 3;                        ///< Bits 2:0
  [FieldOffset(0)] public byte PackageRanks2_3 = 3;                        ///< Bits 5:3
  [FieldOffset(0)] public byte Reserved = 2;                        ///< Bits 7:6
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_LRDIMM_DATA_BUFFER_VREFDQ_FOR_DRAM_INTERFACE_RANGE
{
  /*   struct { */
  [FieldOffset(0)] public byte Rank0 = 1;                             ///< Bits 0:0
  [FieldOffset(0)] public byte Rank1 = 1;                             ///< Bits 1:1
  [FieldOffset(0)] public byte Rank2 = 1;                             ///< Bits 2:2
  [FieldOffset(0)] public byte Rank3 = 1;                             ///< Bits 3:3
  [FieldOffset(0)] public byte DataBuffer = 1;                             ///< Bits 4:4
  [FieldOffset(0)] public byte Reserved = 3;                             ///< Bits 7:5
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_LRDIMM_DATA_BUFFER_DQ_DECISION_FEEDBACK_EQUALIZATION
{
  /*   struct { */
  [FieldOffset(0)] public byte DataBufferGainAdjustment = 1;               ///< Bits 0:0
  [FieldOffset(0)] public byte DataBufferDfe = 1;               ///< Bits 1:1
  [FieldOffset(0)] public byte Reserved = 6;               ///< Bits 7:2
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPD4_NVDIMM_MODULE_PRODUCT_IDENTIFIER { ushort Value; public static implicit operator SPD4_NVDIMM_MODULE_PRODUCT_IDENTIFIER(ushort value) => new SPD4_NVDIMM_MODULE_PRODUCT_IDENTIFIER() { Value = value }; public static implicit operator ushort(SPD4_NVDIMM_MODULE_PRODUCT_IDENTIFIER value) => value.Value; }

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_NVDIMM_SUBSYSTEM_CONTROLLER_MANUFACTURER_ID_CODE
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
public unsafe struct SPD4_NVDIMM_SUBSYSTEM_CONTROLLER_IDENTIFIER { ushort Value; public static implicit operator SPD4_NVDIMM_SUBSYSTEM_CONTROLLER_IDENTIFIER(ushort value) => new SPD4_NVDIMM_SUBSYSTEM_CONTROLLER_IDENTIFIER() { Value = value }; public static implicit operator ushort(SPD4_NVDIMM_SUBSYSTEM_CONTROLLER_IDENTIFIER value) => value.Value; }

[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPD4_NVDIMM_SUBSYSTEM_CONTROLLER_REVISION_CODE { byte Value; public static implicit operator SPD4_NVDIMM_SUBSYSTEM_CONTROLLER_REVISION_CODE(byte value) => new SPD4_NVDIMM_SUBSYSTEM_CONTROLLER_REVISION_CODE() { Value = value }; public static implicit operator byte(SPD4_NVDIMM_SUBSYSTEM_CONTROLLER_REVISION_CODE value) => value.Value; }

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_NVDIMM_REFERENCE_RAW_CARD
{
  /*   struct { */
  [FieldOffset(0)] public byte Card = 5;                         ///< Bits 4:0
  [FieldOffset(0)] public byte Revision = 2;                         ///< Bits 6:5
  [FieldOffset(0)] public byte Extension = 1;                         ///< Bits 7:7
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_NVDIMM_MODULE_CHARACTERISTICS
{
  /*   struct { */
  [FieldOffset(0)] public byte Reserved = 4;                         ///< Bits 3:0
  [FieldOffset(0)] public byte Extension = 4;                         ///< Bits 7:4
/*   } Bits; */
  [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPD4_NVDIMM_HYBRID_MODULE_MEDIA_TYPES
{
  public byte Reserved;
  public byte MediaType;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPD4_NVDIMM_MAXIMUM_NONVOLATILE_MEMORY_INITIALIZATION_TIME { byte Value; public static implicit operator SPD4_NVDIMM_MAXIMUM_NONVOLATILE_MEMORY_INITIALIZATION_TIME(byte value) => new SPD4_NVDIMM_MAXIMUM_NONVOLATILE_MEMORY_INITIALIZATION_TIME() { Value = value }; public static implicit operator byte(SPD4_NVDIMM_MAXIMUM_NONVOLATILE_MEMORY_INITIALIZATION_TIME value) => value.Value; }

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_NVDIMM_FUNCTION_INTERFACE_DESCRIPTOR
{
  /*   struct { */
  [FieldOffset(0)] public ushort FunctionInterface = 5;                ///< Bits 4:0
  [FieldOffset(0)] public ushort FunctionClass = 5;                ///< Bits 9:5
  [FieldOffset(0)] public ushort BlockOffset = 4;                ///< Bits 13:10
  [FieldOffset(0)] public ushort Reserved = 1;                ///< Bits 14:14
  [FieldOffset(0)] public ushort Implemented = 1;                ///< Bits 15:15
/*   } Bits; */
  [FieldOffset(0)] public ushort Data;
  [FieldOffset(0)] public fixed byte Data8[2];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPD4_MANUFACTURING_DATE
{
  public byte Year;                               ///< Year represented in BCD (00h = 2000)
  public byte Week;                               ///< Year represented in BCD (47h = week 47)
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_MANUFACTURER_SERIAL_NUMBER
{
  [FieldOffset(0)] public uint Data;
  [FieldOffset(0)] public fixed ushort SerialNumber16[2];
  [FieldOffset(0)] public fixed byte SerialNumber8[4];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPD4_MANUFACTURING_LOCATION
{
  public byte Location;                           ///< Module Manufacturing Location
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPD4_UNIQUE_MODULE_ID
{
  public SPD4_MANUFACTURER_ID_CODE IdCode;                     ///< Module Manufacturer ID Code
  public SPD4_MANUFACTURING_LOCATION Location;                   ///< Module Manufacturing Location
  public SPD4_MANUFACTURING_DATE Date;                       ///< Module Manufacturing Year, in BCD (range: 2000-2255)
  public SPD4_MANUFACTURER_SERIAL_NUMBER SerialNumber;               ///< Module Serial Number
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_CYCLIC_REDUNDANCY_CODE
{
  [FieldOffset(0)] public fixed ushort Crc[1];
  [FieldOffset(0)] public fixed byte Data8[2];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPD4_BASE_SECTION
{
  public SPD4_DEVICE_DESCRIPTION_STRUCT Description;               ///< 0       Number of Serial PD Bytes Written / SPD Device Size / CRC Coverage 1, 2
  public SPD4_REVISION_STRUCT Revision;                  ///< 1       SPD Revision
  public SPD4_DRAM_DEVICE_TYPE_STRUCT DramDeviceType;            ///< 2       DRAM Device Type
  public SPD4_MODULE_TYPE_STRUCT ModuleType;                ///< 3       Module Type
  public SPD4_SDRAM_DENSITY_BANKS_STRUCT SdramDensityAndBanks;      ///< 4       SDRAM Density and Banks
  public SPD4_SDRAM_ADDRESSING_STRUCT SdramAddressing;           ///< 5       SDRAM Addressing
  public SPD4_PRIMARY_SDRAM_PACKAGE_TYPE_STRUCT PrimarySdramPackageType;   ///< 6       Primary SDRAM Package Type
  public SPD4_SDRAM_OPTIONAL_FEATURES_STRUCT SdramOptionalFeatures;     ///< 7       SDRAM Optional Features
  public SPD4_SDRAM_THERMAL_REFRESH_STRUCT ThermalAndRefreshOptions;  ///< 8       SDRAM Thermal and Refresh Options
  public SPD4_OTHER_SDRAM_OPTIONAL_FEATURES_STRUCT OtherOptionalFeatures;     ///< 9       Other SDRAM Optional Features
  public SPD4_SECONDARY_SDRAM_PACKAGE_TYPE_STRUCT SecondarySdramPackageType; ///< 10      Secondary SDRAM Package Type
  public SPD4_MODULE_NOMINAL_VOLTAGE_STRUCT ModuleNominalVoltage;      ///< 11      Module Nominal Voltage, VDD
  public SPD4_MODULE_ORGANIZATION_STRUCT ModuleOrganization;        ///< 12      Module Organization
  public SPD4_MODULE_MEMORY_BUS_WIDTH_STRUCT ModuleMemoryBusWidth;      ///< 13      Module Memory Bus Width
  public SPD4_MODULE_THERMAL_SENSOR_STRUCT ModuleThermalSensor;       ///< 14      Module Thermal Sensor
  public SPD4_EXTENDED_MODULE_TYPE_STRUCT ExtendedModuleType;        ///< 15      Extended Module Type
  public byte Reserved0;                 ///< 16      Reserved
  public SPD4_TIMEBASE_STRUCT Timebase;                  ///< 17      Timebases
  public SPD4_TCK_MIN_MTB_STRUCT tCKmin;                    ///< 18      SDRAM Minimum Cycle Time (tCKmin)
  public SPD4_TCK_MAX_MTB_STRUCT tCKmax;                    ///< 19      SDRAM Maximum Cycle Time (tCKmax)
  public SPD4_CAS_LATENCIES_SUPPORTED_STRUCT CasLatencies;              ///< 20-23   CAS Latencies Supported
  public SPD4_TAA_MIN_MTB_STRUCT tAAmin;                    ///< 24      Minimum CAS Latency Time (tAAmin)
  public SPD4_TRCD_MIN_MTB_STRUCT tRCDmin;                   ///< 25      Minimum RAS# to CAS# Delay Time (tRCDmin)
  public SPD4_TRP_MIN_MTB_STRUCT tRPmin;                    ///< 26      Minimum Row Precharge Delay Time (tRPmin)
  public SPD4_TRAS_TRC_MIN_MTB_STRUCT tRASMintRCMinUpper;        ///< 27      Upper Nibbles for tRAS and tRC
  public SPD4_TRAS_MIN_MTB_STRUCT tRASmin;                   ///< 28      Minimum Active to Precharge Delay Time (tRASmin), Least Significant Byte
  public SPD4_TRC_MIN_MTB_STRUCT tRCmin;                    ///< 29      Minimum Active to Active/Refresh Delay Time (tRCmin), Least Significant Byte
  public SPD4_TRFC_MIN_MTB_STRUCT tRFC1min;                  ///< 30-31   Minimum Refresh Recovery Delay Time (tRFC1min)
  public SPD4_TRFC_MIN_MTB_STRUCT tRFC2min;                  ///< 32-33   Minimum Refresh Recovery Delay Time (tRFC2min)
  public SPD4_TRFC_MIN_MTB_STRUCT tRFC4min;                  ///< 34-35   Minimum Refresh Recovery Delay Time (tRFC4min)
  public SPD4_TFAW_MIN_MTB_UPPER_STRUCT tFAWMinUpper;              ///< 36      Upper Nibble for tFAW
  public SPD4_TFAW_MIN_MTB_STRUCT tFAWmin;                   ///< 37      Minimum Four Activate Window Delay Time (tFAWmin)
  public SPD4_TRRD_MIN_MTB_STRUCT tRRD_Smin;                 ///< 38      Minimum Activate to Activate Delay Time (tRRD_Smin), different bank group
  public SPD4_TRRD_MIN_MTB_STRUCT tRRD_Lmin;                 ///< 39      Minimum Activate to Activate Delay Time (tRRD_Lmin), same bank group
  public SPD4_TCCD_MIN_MTB_STRUCT tCCD_Lmin;                 ///< 40      Minimum CAS to CAS Delay Time (tCCD_Lmin), Same Bank Group
  public SPD4_TWR_UPPER_NIBBLE_STRUCT tWRUpperNibble;            ///< 41      Upper Nibble for tWRmin
  public SPD4_TWR_MIN_MTB_STRUCT tWRmin;                    ///< 42      Minimum Write Recovery Time (tWRmin)
  public SPD4_TWTR_UPPER_NIBBLE_STRUCT tWTRUpperNibble;           ///< 43      Upper Nibbles for tWTRmin
  public SPD4_TWTR_MIN_MTB_STRUCT tWTR_Smin;                 ///< 44      Minimum Write to Read Time (tWTR_Smin), Different Bank Group
  public SPD4_TWTR_MIN_MTB_STRUCT tWTR_Lmin;                 ///< 45      Minimum Write to Read Time (tWTR_Lmin), Same Bank Group
  public fixed byte Reserved1[59 - 46 + 1];    ///< 46-59   Reserved
  public fixed SPD4_CONNECTOR_BIT_MAPPING_BYTE_STRUCT BitMapping[77 - 60 + 1];   ///< 60-77   Connector to SDRAM Bit Mapping
  public fixed byte Reserved2[116 - 78 + 1];   ///< 78-116  Reserved
  public SPD4_TCCD_MIN_FTB_STRUCT tCCD_LminFine;             ///< 117     Fine Offset for Minimum CAS to CAS Delay Time (tCCD_Lmin), same bank group
  public SPD4_TRRD_MIN_FTB_STRUCT tRRD_LminFine;             ///< 118     Fine Offset for Minimum Activate to Activate Delay Time (tRRD_Lmin), different bank group
  public SPD4_TRRD_MIN_FTB_STRUCT tRRD_SminFine;             ///< 119     Fine Offset for Minimum Activate to Activate Delay Time (tRRD_Smin), same bank group
  public SPD4_TRC_MIN_FTB_STRUCT tRCminFine;                ///< 120     Fine Offset for Minimum Active to Active/Refresh Delay Time (tRCmin)
  public SPD4_TRP_MIN_FTB_STRUCT tRPminFine;                ///< 121     Fine Offset for Minimum Row Precharge Delay Time (tRPabmin)
  public SPD4_TRCD_MIN_FTB_STRUCT tRCDminFine;               ///< 122     Fine Offset for Minimum RAS# to CAS# Delay Time (tRCDmin)
  public SPD4_TAA_MIN_FTB_STRUCT tAAminFine;                ///< 123     Fine Offset for Minimum CAS Latency Time (tAAmin)
  public SPD4_TCK_MAX_FTB_STRUCT tCKmaxFine;                ///< 124     Fine Offset for SDRAM Minimum Cycle Time (tCKmax)
  public SPD4_TCK_MIN_FTB_STRUCT tCKminFine;                ///< 125     Fine Offset for SDRAM Maximum Cycle Time (tCKmin)
  public SPD4_CYCLIC_REDUNDANCY_CODE Crc;                       ///< 126-127 Cyclical Redundancy Code (CRC)
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPD4_MODULE_UNBUFFERED
{
  public SPD4_UNBUF_MODULE_NOMINAL_HEIGHT ModuleNominalHeight;     ///< 128     Module Nominal Height
  public SPD4_UNBUF_MODULE_NOMINAL_THICKNESS ModuleMaximumThickness;  ///< 129     Module Maximum Thickness
  public SPD4_UNBUF_REFERENCE_RAW_CARD ReferenceRawCardUsed;    ///< 130     Reference Raw Card Used
  public SPD4_UNBUF_ADDRESS_MAPPING AddressMappingEdgeConn;  ///< 131     Address Mapping from Edge Connector to DRAM
  public fixed byte Reserved[253 - 132 + 1]; ///< 132-253 Reserved
  public SPD4_CYCLIC_REDUNDANCY_CODE Crc;                     ///< 254-255 Cyclical Redundancy Code (CRC)
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPD4_MODULE_REGISTERED
{
  public SPD4_RDIMM_MODULE_NOMINAL_HEIGHT ModuleNominalHeight;                                 ///< 128     Module Nominal Height
  public SPD4_RDIMM_MODULE_NOMINAL_THICKNESS ModuleMaximumThickness;                              ///< 129     Module Maximum Thickness
  public SPD4_RDIMM_REFERENCE_RAW_CARD ReferenceRawCardUsed;                                ///< 130     Reference Raw Card Used
  public SPD4_RDIMM_MODULE_ATTRIBUTES DimmModuleAttributes;                                ///< 131     DIMM Module Attributes
  public SPD4_RDIMM_THERMAL_HEAT_SPREADER_SOLUTION DimmThermalHeatSpreaderSolution;                     ///< 132     RDIMM Thermal Heat Spreader Solution
  public SPD4_MANUFACTURER_ID_CODE RegisterManufacturerIdCode;                          ///< 133-134 Register Manufacturer ID Code
  public SPD4_RDIMM_REGISTER_REVISION_NUMBER RegisterRevisionNumber;                              ///< 135     Register Revision Number
  public SPD4_RDIMM_ADDRESS_MAPPING_FROM_REGISTER_TO_DRAM AddressMappingFromRegisterToDRAM;                    ///< 136     Address Mapping from Register to DRAM
  public SPD4_RDIMM_REGISTER_OUTPUT_DRIVE_STRENGTH_FOR_CONTROL_COMMAND_ADDRESS RegisterOutputDriveStrengthForControlCommandAddress; ///< 137 Register Output Drive Strength for Control and Command Address
  public SPD4_RDIMM_REGISTER_OUTPUT_DRIVE_STRENGTH_FOR_CLOCK RegisterOutputDriveStrengthForClock;                 ///< 138     Register Output Drive Strength for Clock
  public fixed byte Reserved[253 - 139 + 1];                             ///< 253-139 Reserved
  public SPD4_CYCLIC_REDUNDANCY_CODE Crc;                                                 ///< 254-255 Cyclical Redundancy Code (CRC)
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPD4_MODULE_LOADREDUCED
{
  public SPD4_LRDIMM_MODULE_NOMINAL_HEIGHT ModuleNominalHeight;                                 ///< 128     Module Nominal Height
  public SPD4_LRDIMM_MODULE_NOMINAL_THICKNESS ModuleMaximumThickness;                              ///< 129     Module Maximum Thickness
  public SPD4_LRDIMM_REFERENCE_RAW_CARD ReferenceRawCardUsed;                                ///< 130     Reference Raw Card Used
  public SPD4_LRDIMM_MODULE_ATTRIBUTES DimmModuleAttributes;                                ///< 131     DIMM Module Attributes
  public SPD4_LRDIMM_THERMAL_HEAT_SPREADER_SOLUTION ThermalHeatSpreaderSolution;                         ///< 132     RDIMM Thermal Heat Spreader Solution
  public SPD4_MANUFACTURER_ID_CODE RegisterManufacturerIdCode;                          ///< 133-134 Register Manufacturer ID Code
  public SPD4_LRDIMM_REGISTER_REVISION_NUMBER RegisterRevisionNumber;                              ///< 135     Register Revision Number
  public SPD4_LRDIMM_ADDRESS_MAPPING_FROM_REGISTER_TO_DRAM AddressMappingFromRegisterToDram;                    ///< 136 Address Mapping from Register to DRAM
  public SPD4_LRDIMM_REGISTER_OUTPUT_DRIVE_STRENGTH_FOR_CONTROL_COMMAND_ADDRESS RegisterOutputDriveStrengthForControlCommandAddress; ///< 137 Register Output Drive Strength for Control and Command Address
  public SPD4_LRDIMM_REGISTER_OUTPUT_DRIVE_STRENGTH_FOR_CLOCK RegisterOutputDriveStrengthForClock;                 ///< 138 Register Output Drive Strength for Clock
  public SPD4_LRDIMM_DATA_BUFFER_REVISION_NUMBER DataBufferRevisionNumber;                            ///< 139     Data Buffer Revision Number
  public SPD4_LRDIMM_DRAM_VREFDQ_FOR_PACKAGE_RANK DramVrefDQForPackageRank0;                           ///< 140     DRAM VrefDQ for Package Rank 0
  public SPD4_LRDIMM_DRAM_VREFDQ_FOR_PACKAGE_RANK DramVrefDQForPackageRank1;                           ///< 141     DRAM VrefDQ for Package Rank 1
  public SPD4_LRDIMM_DRAM_VREFDQ_FOR_PACKAGE_RANK DramVrefDQForPackageRank2;                           ///< 142     DRAM VrefDQ for Package Rank 2
  public SPD4_LRDIMM_DRAM_VREFDQ_FOR_PACKAGE_RANK DramVrefDQForPackageRank3;                           ///< 143     DRAM VrefDQ for Package Rank 3
  public SPD4_LRDIMM_DATA_BUFFER_VREFDQ_FOR_DRAM_INTERFACE DataBufferVrefDQForDramInterface;                    ///< 144     Data Buffer VrefDQ for DRAM Interface
  public SPD4_LRDIMM_DATA_BUFFER_MDQ_DRIVE_STRENGTH_RTT_FOR_DATA_RATE DataBufferMdqDriveStrengthRttForDataRateLe1866;      ///< 145     Data Buffer MDQ Drive Strength and RTT for data rate <= 1866
  public SPD4_LRDIMM_DATA_BUFFER_MDQ_DRIVE_STRENGTH_RTT_FOR_DATA_RATE DataBufferMdqDriveStrengthRttForDataRateLe2400;      ///< 146     Data Buffer MDQ Drive Strength and RTT for data rate <=2400
  public SPD4_LRDIMM_DATA_BUFFER_MDQ_DRIVE_STRENGTH_RTT_FOR_DATA_RATE DataBufferMdqDriveStrengthRttForDataRateLe3200;      ///< 147     Data Buffer MDQ Drive Strength and RTT for data rate <=3200
  public SPD4_LRDIMM_DRAM_DRIVE_STRENGTH DramDriveStrength;                                   ///< 148     DRAM Drive Strength
  public SPD4_LRDIMM_DRAM_ODT_RTT_WR_RTT_NOM_FOR_DATA_RATE DramOdtRttWrRttNomForDataRateLe1866;                 ///< 149     DRAM ODT (RTT_WR and RTT_NOM) for data rate <= 1866
  public SPD4_LRDIMM_DRAM_ODT_RTT_WR_RTT_NOM_FOR_DATA_RATE DramOdtRttWrRttNomForDataRateLe2400;                 ///< 150     DRAM ODT (RTT_WR and RTT_NOM) for data rate <= 2400
  public SPD4_LRDIMM_DRAM_ODT_RTT_WR_RTT_NOM_FOR_DATA_RATE DramOdtRttWrRttNomForDataRateLe3200;                 ///< 151     DRAM ODT (RTT_WR and RTT_NOM) for data rate <= 3200
  public SPD4_LRDIMM_DRAM_ODT_RTT_PARK_FOR_DATA_RATE DramOdtRttParkForDataRateLe1866;                     ///< 152     DRAM ODT (RTT_PARK) for data rate <= 1866
  public SPD4_LRDIMM_DRAM_ODT_RTT_PARK_FOR_DATA_RATE DramOdtRttParkForDataRateLe2400;                     ///< 153     DRAM ODT (RTT_PARK) for data rate <= 2400
  public SPD4_LRDIMM_DRAM_ODT_RTT_PARK_FOR_DATA_RATE DramOdtRttParkForDataRateLe3200;                     ///< 154     DRAM ODT (RTT_PARK) for data rate <= 3200
  public SPD4_LRDIMM_DATA_BUFFER_VREFDQ_FOR_DRAM_INTERFACE_RANGE DataBufferVrefDQForDramInterfaceRange;               ///< 155     Data Buffer VrefDQ for DRAM Interface Range
  public SPD4_LRDIMM_DATA_BUFFER_DQ_DECISION_FEEDBACK_EQUALIZATION DataBufferDqDecisionFeedbackEqualization;            ///< 156     Data Buffer DQ Decision Feedback Equalization
  public fixed byte Reserved[253 - 157 + 1];                             ///< 253-132 Reserved
  public SPD4_CYCLIC_REDUNDANCY_CODE Crc;                                                 ///< 254-255 Cyclical Redundancy Code (CRC)
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPD4_MODULE_NVDIMM
{
  public fixed byte Reserved0[191 - 128 + 1];                   ///< 128-191  Reserved
  public SPD4_NVDIMM_MODULE_PRODUCT_IDENTIFIER ModuleProductIdentifier;                    ///< 192-193  Module Product Identifier
  public SPD4_NVDIMM_SUBSYSTEM_CONTROLLER_MANUFACTURER_ID_CODE SubsystemControllerManufacturerIdCode;      ///< 194-195  Subsystem Controller Manufacturer's ID Code
  public SPD4_NVDIMM_SUBSYSTEM_CONTROLLER_IDENTIFIER SubsystemControllerIdentifier;              ///< 196-197  Subsystem Controller Identifier
  public SPD4_NVDIMM_SUBSYSTEM_CONTROLLER_REVISION_CODE SubsystemControllerRevisionCode;            ///< 198      Subsystem Controller Revision Code
  public SPD4_NVDIMM_REFERENCE_RAW_CARD ReferenceRawCardUsed;                       ///< 199      Reference Raw Card Used
  public SPD4_NVDIMM_MODULE_CHARACTERISTICS ModuleCharacteristics;                      ///< 200      Module Characteristics
  public SPD4_NVDIMM_HYBRID_MODULE_MEDIA_TYPES HybridModuleMediaTypes;                     ///< 201-202  Hybrid Module Media Types
  public SPD4_NVDIMM_MAXIMUM_NONVOLATILE_MEMORY_INITIALIZATION_TIME MaximumNonVolatileMemoryInitializationTime; ///< 203 Maximum Non-Volatile Memory Initialization Time
  public fixed SPD4_NVDIMM_FUNCTION_INTERFACE_DESCRIPTOR FunctionInterfaceDescriptors[8];            ///< 204-219  Function Interface Descriptors
  public fixed byte Reserved[253 - 220 + 1];                    ///< 220-253  Reserved
  public SPD4_CYCLIC_REDUNDANCY_CODE Crc;                                        ///< 254-255  Cyclical Redundancy Code (CRC)
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD4_MODULE_SPECIFIC
{
  [FieldOffset(0)] public SPD4_MODULE_UNBUFFERED Unbuffered;                        ///< 128-255 Unbuffered Memory Module Types
  [FieldOffset(0)] public SPD4_MODULE_REGISTERED Registered;                        ///< 128-255 Registered Memory Module Types
  [FieldOffset(0)] public SPD4_MODULE_LOADREDUCED LoadReduced;                       ///< 128-255 Load Reduced Memory Module Types
  [FieldOffset(0)] public SPD4_MODULE_NVDIMM NonVolatile;                       ///< 128-255 Non-Volatile (NVDIMM-N) Hybrid Memory Parameters
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPD4_MODULE_PART_NUMBER
{
  public fixed byte ModulePartNumber[348 - 329 + 1];                            ///< 329-348 Module Part Number
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPD4_MANUFACTURER_SPECIFIC
{
  public fixed byte ManufacturerSpecificData[381 - 353 + 1];                            ///< 353-381 Manufacturer's Specific Data
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPD4_MODULE_REVISION_CODE { byte Value; public static implicit operator SPD4_MODULE_REVISION_CODE(byte value) => new SPD4_MODULE_REVISION_CODE() { Value = value }; public static implicit operator byte(SPD4_MODULE_REVISION_CODE value) => value.Value; }
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPD4_DRAM_STEPPING { byte Value; public static implicit operator SPD4_DRAM_STEPPING(byte value) => new SPD4_DRAM_STEPPING() { Value = value }; public static implicit operator byte(SPD4_DRAM_STEPPING value) => value.Value; }

[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPD4_MANUFACTURING_DATA
{
  public SPD4_UNIQUE_MODULE_ID ModuleId;                       ///< 320-328 Unique Module ID
  public SPD4_MODULE_PART_NUMBER ModulePartNumber;               ///< 329-348 Module Part Number
  public SPD4_MODULE_REVISION_CODE ModuleRevisionCode;             ///< 349     Module Revision Code
  public SPD4_MANUFACTURER_ID_CODE DramIdCode;                     ///< 350-351 Dram Manufacturer ID Code
  public SPD4_DRAM_STEPPING DramStepping;                   ///< 352     Dram Stepping
  public SPD4_MANUFACTURER_SPECIFIC ManufacturerSpecificData;       ///< 353-381 Manufacturer's Specific Data
  public fixed byte Reserved[2];                    ///< 382-383 Reserved
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPD4_END_USER_SECTION
{
  public fixed byte Reserved[511 - 384 + 1];                             ///< 384-511 Unbuffered Memory Module Types
}

///
/// DDR4 Serial Presence Detect structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPD_DDR4
{
  public SPD4_BASE_SECTION Base;                              ///< 0-127   Base Configuration and DRAM Parameters
  public SPD4_MODULE_SPECIFIC Module;                            ///< 128-255 Module-Specific Section
  public fixed byte Reserved[319 - 256 + 1];           ///< 256-319 Reserved
  public SPD4_MANUFACTURING_DATA ManufactureInfo;                   ///< 320-383 Manufacturing Information
  public SPD4_END_USER_SECTION EndUser;                           ///< 384-511 End User Programmable
}

// #pragma pack (pop)
// #endif

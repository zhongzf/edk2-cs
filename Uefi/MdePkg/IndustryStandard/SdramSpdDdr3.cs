using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  This file contains definitions for SPD DDR3.

  Copyright (c) 2016, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
    - Serial Presence Detect (SPD) for DDR3 SDRAM Modules Document Release 6
      http://www.jedec.org/sites/default/files/docs/4_01_02_11R21A.pdf
**/

// #ifndef _SDRAM_SPD_DDR3_H_
// #define _SDRAM_SPD_DDR3_H_

// #pragma pack (push, 1)

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte BytesUsed = 4;                       ///< Bits 3:0
  [FieldOffset(0)] public byte BytesTotal = 3;                       ///< Bits 6:4
  [FieldOffset(0)] public byte CrcCoverage = 1;                       ///< Bits 7:7
}
byte Data;
} SPD3_DEVICE_DESCRIPTION_STRUCT;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte Minor = 4;                             ///< Bits 3:0
  [FieldOffset(0)] public byte Major = 4;                             ///< Bits 7:4
}
byte Data;
} SPD3_REVISION_STRUCT;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte Type = 8;                              ///< Bits 7:0
}
byte Data;
} SPD3_DRAM_DEVICE_TYPE_STRUCT;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte ModuleType = 4;                        ///< Bits 3:0
  [FieldOffset(0)] public byte Reserved = 4;                        ///< Bits 7:4
}
byte Data;
} SPD3_MODULE_TYPE_STRUCT;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte Density = 4;                       ///< Bits 3:0
  [FieldOffset(0)] public byte BankAddress = 3;                       ///< Bits 6:4
  [FieldOffset(0)] public byte Reserved = 1;                       ///< Bits 7:7
}
byte Data;
} SPD3_SDRAM_DENSITY_BANKS_STRUCT;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte ColumnAddress = 3;                     ///< Bits 2:0
  [FieldOffset(0)] public byte RowAddress = 3;                     ///< Bits 5:3
  [FieldOffset(0)] public byte Reserved = 2;                     ///< Bits 7:6
}
byte Data;
} SPD3_SDRAM_ADDRESSING_STRUCT;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte OperationAt1_50 = 1;                   ///< Bits 0:0
  [FieldOffset(0)] public byte OperationAt1_35 = 1;                   ///< Bits 1:1
  [FieldOffset(0)] public byte OperationAt1_25 = 1;                   ///< Bits 2:2
  [FieldOffset(0)] public byte Reserved = 5;                   ///< Bits 7:3
}
byte Data;
} SPD3_MODULE_NOMINAL_VOLTAGE_STRUCT;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte SdramDeviceWidth = 3;                  ///< Bits 2:0
  [FieldOffset(0)] public byte RankCount = 3;                  ///< Bits 5:3
  [FieldOffset(0)] public byte Reserved = 2;                  ///< Bits 7:6
}
byte Data;
} SPD3_MODULE_ORGANIZATION_STRUCT;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte PrimaryBusWidth = 3;                 ///< Bits 2:0
  [FieldOffset(0)] public byte BusWidthExtension = 2;                 ///< Bits 4:3
  [FieldOffset(0)] public byte Reserved = 3;                 ///< Bits 7:5
}
byte Data;
} SPD3_MODULE_MEMORY_BUS_WIDTH_STRUCT;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte Divisor = 4;                          ///< Bits 3:0
  [FieldOffset(0)] public byte Dividend = 4;                          ///< Bits 7:4
}
byte Data;
} SPD3_FINE_TIMEBASE_STRUCT;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte Dividend = 8;                          ///< Bits 7:0
}
byte Data;
} SPD3_MEDIUM_TIMEBASE_DIVIDEND_STRUCT;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte Divisor = 8;                           ///< Bits 7:0
}
byte Data;
} SPD3_MEDIUM_TIMEBASE_DIVISOR_STRUCT;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPD3_MEDIUM_TIMEBASE
{
  public SPD3_MEDIUM_TIMEBASE_DIVIDEND_STRUCT Dividend; ///< Medium Timebase (MTB) Dividend
  public SPD3_MEDIUM_TIMEBASE_DIVISOR_STRUCT Divisor;  ///< Medium Timebase (MTB) Divisor
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte tCKmin = 8;                            ///< Bits 7:0
}
byte Data;
} SPD3_TCK_MIN_MTB_STRUCT;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public ushort Cl4 = 1;                         ///< Bits 0:0
  [FieldOffset(0)] public ushort Cl5 = 1;                         ///< Bits 1:1
  [FieldOffset(0)] public ushort Cl6 = 1;                         ///< Bits 2:2
  [FieldOffset(0)] public ushort Cl7 = 1;                         ///< Bits 3:3
  [FieldOffset(0)] public ushort Cl8 = 1;                         ///< Bits 4:4
  [FieldOffset(0)] public ushort Cl9 = 1;                         ///< Bits 5:5
  [FieldOffset(0)] public ushort Cl10 = 1;                         ///< Bits 6:6
  [FieldOffset(0)] public ushort Cl11 = 1;                         ///< Bits 7:7
  [FieldOffset(0)] public ushort Cl12 = 1;                         ///< Bits 8:8
  [FieldOffset(0)] public ushort Cl13 = 1;                         ///< Bits 9:9
  [FieldOffset(0)] public ushort Cl14 = 1;                         ///< Bits 10:10
  [FieldOffset(0)] public ushort Cl15 = 1;                         ///< Bits 11:11
  [FieldOffset(0)] public ushort Cl16 = 1;                         ///< Bits 12:12
  [FieldOffset(0)] public ushort Cl17 = 1;                         ///< Bits 13:13
  [FieldOffset(0)] public ushort Cl18 = 1;                         ///< Bits 14:14
  [FieldOffset(0)] public ushort Reserved = 1;                         ///< Bits 15:15
}
ushort Data;
byte Data8[2];
} SPD3_CAS_LATENCIES_SUPPORTED_STRUCT;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte tAAmin = 8;                            ///< Bits 7:0
}
byte Data;
} SPD3_TAA_MIN_MTB_STRUCT;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte tWRmin = 8;                            ///< Bits 7:0
}
byte Data;
} SPD3_TWR_MIN_MTB_STRUCT;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte tRCDmin = 8;                           ///< Bits 7:0
}
byte Data;
} SPD3_TRCD_MIN_MTB_STRUCT;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte tRRDmin = 8;                           ///< Bits 7:0
}
byte Data;
} SPD3_TRRD_MIN_MTB_STRUCT;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte tRPmin = 8;                            ///< Bits 7:0
}
byte Data;
} SPD3_TRP_MIN_MTB_STRUCT;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte tRASminUpper = 4;                      ///< Bits 3:0
  [FieldOffset(0)] public byte tRCminUpper = 4;                      ///< Bits 7:4
}
byte Data;
} SPD3_TRAS_TRC_MIN_MTB_STRUCT;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte tRASmin = 8;                           ///< Bits 7:0
}
byte Data;
} SPD3_TRAS_MIN_MTB_STRUCT;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte tRCmin = 8;                            ///< Bits 7:0
}
byte Data;
} SPD3_TRC_MIN_MTB_STRUCT;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public ushort tRFCmin = 16;                          ///< Bits 15:0
}
ushort Data;
byte Data8[2];
} SPD3_TRFC_MIN_MTB_STRUCT;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte tWTRmin = 8;                           ///< Bits 7:0
}
byte Data;
} SPD3_TWTR_MIN_MTB_STRUCT;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte tRTPmin = 8;                           ///< Bits 7:0
}
byte Data;
} SPD3_TRTP_MIN_MTB_STRUCT;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte tFAWminUpper = 4;                      ///< Bits 3:0
  [FieldOffset(0)] public byte Reserved = 4;                      ///< Bits 7:4
}
byte Data;
} SPD3_TFAW_MIN_MTB_UPPER_STRUCT;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte tFAWmin = 8;                           ///< Bits 7:0
}
byte Data;
} SPD3_TFAW_MIN_MTB_STRUCT;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte Rzq6 = 1;                          ///< Bits 0:0
  [FieldOffset(0)] public byte Rzq7 = 1;                          ///< Bits 1:1
  [FieldOffset(0)] public byte Reserved = 5;                          ///< Bits 6:2
  [FieldOffset(0)] public byte DllOff = 1;                          ///< Bits 7:7
}
byte Data;
} SPD3_SDRAM_OPTIONAL_FEATURES_STRUCT;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte ExtendedTemperatureRange = 1;    ///< Bits 0:0
  [FieldOffset(0)] public byte ExtendedTemperatureRefreshRate = 1;    ///< Bits 1:1
  [FieldOffset(0)] public byte AutoSelfRefresh = 1;    ///< Bits 2:2
  [FieldOffset(0)] public byte OnDieThermalSensor = 1;    ///< Bits 3:3
  [FieldOffset(0)] public byte Reserved = 3;    ///< Bits 6:4
  [FieldOffset(0)] public byte PartialArraySelfRefresh = 1;    ///< Bits 7:7
}
byte Data;
} SPD3_SDRAM_THERMAL_REFRESH_STRUCT;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte ThermalSensorAccuracy = 7;             ///< Bits 6:0
  [FieldOffset(0)] public byte ThermalSensorPresence = 1;             ///< Bits 7:7
}
byte Data;
} SPD3_MODULE_THERMAL_SENSOR_STRUCT;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte SignalLoading = 2;                   ///< Bits 1:0
  [FieldOffset(0)] public byte Reserved = 2;                   ///< Bits 3:2
  [FieldOffset(0)] public byte DieCount = 3;                   ///< Bits 6:4
  [FieldOffset(0)] public byte SdramDeviceType = 1;                   ///< Bits 7:7
}
byte Data;
} SPD3_SDRAM_DEVICE_TYPE_STRUCT;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public sbyte tCKminFine = 8;                         ///< Bits 7:0
}
sbyte Data;
} SPD3_TCK_MIN_FTB_STRUCT;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public sbyte tAAminFine = 8;                         ///< Bits 7:0
}
sbyte Data;
} SPD3_TAA_MIN_FTB_STRUCT;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public sbyte tRCDminFine = 8;                        ///< Bits 7:0
}
sbyte Data;
} SPD3_TRCD_MIN_FTB_STRUCT;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public sbyte tRPminFine = 8;                         ///< Bits 7:0
}
sbyte Data;
} SPD3_TRP_MIN_FTB_STRUCT;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public sbyte tRCminFine = 8;                         ///< Bits 7:0
}
sbyte Data;
} SPD3_TRC_MIN_FTB_STRUCT;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte MaximumActivateCount = 4;             ///< Bits 3:0
  [FieldOffset(0)] public byte MaximumActivateWindow = 2;             ///< Bits 5:4
  [FieldOffset(0)] public byte VendorSpecific = 2;             ///< Bits 7:6
}
byte Data;
} SPD3_MAXIMUM_ACTIVE_COUNT_STRUCT;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte Height = 5;                  ///< Bits 4:0
  [FieldOffset(0)] public byte RawCardExtension = 3;                  ///< Bits 7:5
}
byte Data;
} SPD3_UNBUF_MODULE_NOMINAL_HEIGHT;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte FrontThickness = 4;                    ///< Bits 3:0
  [FieldOffset(0)] public byte BackThickness = 4;                    ///< Bits 7:4
}
byte Data;
} SPD3_UNBUF_MODULE_NOMINAL_THICKNESS;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte Card = 5;                         ///< Bits 4:0
  [FieldOffset(0)] public byte Revision = 2;                         ///< Bits 6:5
  [FieldOffset(0)] public byte Extension = 1;                         ///< Bits 7:7
}
byte Data;
} SPD3_UNBUF_REFERENCE_RAW_CARD;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte MappingRank1 = 1;                      ///< Bits 0:0
  [FieldOffset(0)] public byte Reserved = 7;                      ///< Bits 7:1
}
byte Data;
} SPD3_UNBUF_ADDRESS_MAPPING;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte Height = 5;                          ///< Bits 4:0
  [FieldOffset(0)] public byte Reserved = 3;                          ///< Bits 7:5
}
byte Data;
} SPD3_RDIMM_MODULE_NOMINAL_HEIGHT;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte FrontThickness = 4;                    ///< Bits 3:0
  [FieldOffset(0)] public byte BackThickness = 4;                    ///< Bits 7:4
}
byte Data;
} SPD3_RDIMM_MODULE_NOMINAL_THICKNESS;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte Card = 5;                         ///< Bits 4:0
  [FieldOffset(0)] public byte Revision = 2;                         ///< Bits 6:5
  [FieldOffset(0)] public byte Extension = 1;                         ///< Bits 7:7
}
byte Data;
} SPD3_RDIMM_REFERENCE_RAW_CARD;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte RegisterCount = 2;                     ///< Bits 1:0
  [FieldOffset(0)] public byte DramRowCount = 2;                     ///< Bits 3:2
  [FieldOffset(0)] public byte RegisterType = 4;                     ///< Bits 7:4
}
byte Data;
} SPD3_RDIMM_MODULE_ATTRIBUTES;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte HeatSpreaderThermalCharacteristics = 7; ///< Bits 6:0
  [FieldOffset(0)] public byte HeatSpreaderSolution = 1; ///< Bits 7:7
}
byte Data;
} SPD3_RDIMM_THERMAL_HEAT_SPREADER_SOLUTION;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public ushort ContinuationCount = 7;               ///< Bits 6:0
  [FieldOffset(0)] public ushort ContinuationParity = 1;               ///< Bits 7:7
  [FieldOffset(0)] public ushort LastNonZeroByte = 8;               ///< Bits 15:8
}
ushort Data;
byte Data8[2];
} SPD3_MANUFACTURER_ID_CODE;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte RegisterRevisionNumber;           ///< Bits 7:0
}
byte Data;
} SPD3_RDIMM_REGISTER_REVISION_NUMBER;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte Bit0 = 1;                         ///< Bits 0:0
  [FieldOffset(0)] public byte Bit1 = 1;                         ///< Bits 1:1
  [FieldOffset(0)] public byte Bit2 = 1;                         ///< Bits 2:2
  [FieldOffset(0)] public byte Reserved = 5;                         ///< Bits 7:3
}
byte Data;
} SPD3_RDIMM_REGISTER_TYPE;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte Reserved = 4;           ///< Bits 0:3
  [FieldOffset(0)] public byte CommandAddressAOutputs = 2;           ///< Bits 5:4
  [FieldOffset(0)] public byte CommandAddressBOutputs = 2;           ///< Bits 7:6
}
byte Data;
} SPD3_RDIMM_REGISTER_CONTROL_COMMAND_ADDRESS;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte ControlSignalsAOutputs = 2;           ///< Bits 0:1
  [FieldOffset(0)] public byte ControlSignalsBOutputs = 2;           ///< Bits 3:2
  [FieldOffset(0)] public byte Y1Y3ClockOutputs = 2;           ///< Bits 5:4
  [FieldOffset(0)] public byte Y0Y2ClockOutputs = 2;           ///< Bits 7:6
}
byte Data;
} SPD3_RDIMM_REGISTER_CONTROL_CONTROL_CLOCK;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte Reserved0 = 4;                        ///< Bits 0:3
  [FieldOffset(0)] public byte Reserved1 = 4;                        ///< Bits 7:4
}
byte Data;
} SPD3_RDIMM_REGISTER_CONTROL_RESERVED;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte Height = 5;                         ///< Bits 4:0
  [FieldOffset(0)] public byte Reserved = 3;                         ///< Bits 7:5
}
byte Data;
} SPD3_LRDIMM_MODULE_NOMINAL_HEIGHT;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte FrontThickness = 4;                   ///< Bits 3:0
  [FieldOffset(0)] public byte BackThickness = 4;                   ///< Bits 7:4
}
byte Data;
} SPD3_LRDIMM_MODULE_NOMINAL_THICKNESS;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte Card = 5;                        ///< Bits 4:0
  [FieldOffset(0)] public byte Revision = 2;                        ///< Bits 6:5
  [FieldOffset(0)] public byte Extension = 1;                        ///< Bits 7:7
}
byte Data;
} SPD3_LRDIMM_REFERENCE_RAW_CARD;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte RegisterCount = 2;                    ///< Bits 1:0
  [FieldOffset(0)] public byte DramRowCount = 2;                    ///< Bits 3:2
  [FieldOffset(0)] public byte RegisterType = 4;                    ///< Bits 7:4
}
byte Data;
} SPD3_LRDIMM_MODULE_ATTRIBUTES;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte AddressCommandPrelaunch = 1;          ///< Bits 0:0
  [FieldOffset(0)] public byte Rank1Rank5Swap = 1;          ///< Bits 1:1
  [FieldOffset(0)] public byte Reserved0 = 1;          ///< Bits 2:2
  [FieldOffset(0)] public byte Reserved1 = 1;          ///< Bits 3:3
  [FieldOffset(0)] public byte AddressCommandOutputs = 2;          ///< Bits 5:4
  [FieldOffset(0)] public byte QxCS_nOutputs = 2;          ///< Bits 7:6
}
byte Data;
} SPD3_LRDIMM_TIMING_CONTROL_DRIVE_STRENGTH;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte QxOdtOutputs = 2;                 ///< Bits 1:0
  [FieldOffset(0)] public byte QxCkeOutputs = 2;                 ///< Bits 3:2
  [FieldOffset(0)] public byte Y1Y3ClockOutputs = 2;                 ///< Bits 5:4
  [FieldOffset(0)] public byte Y0Y2ClockOutputs = 2;                 ///< Bits 7:6
}
byte Data;
} SPD3_LRDIMM_TIMING_DRIVE_STRENGTH;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte YExtendedDelay = 2;                   ///< Bits 1:0
  [FieldOffset(0)] public byte QxCS_n = 2;                   ///< Bits 3:2
  [FieldOffset(0)] public byte QxOdt = 2;                   ///< Bits 5:4
  [FieldOffset(0)] public byte QxCke = 2;                   ///< Bits 7:6
}
byte Data;
} SPD3_LRDIMM_EXTENDED_DELAY;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte DelayY = 3;                         ///< Bits 2:0
  [FieldOffset(0)] public byte Reserved = 1;                         ///< Bits 3:3
  [FieldOffset(0)] public byte QxCS_n = 4;                         ///< Bits 7:4
}
byte Data;
} SPD3_LRDIMM_ADDITIVE_DELAY_FOR_QXCS_N_QXCA;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte QxCS_n = 4;                           ///< Bits 3:0
  [FieldOffset(0)] public byte QxOdt = 4;                           ///< Bits 7:4
}
byte Data;
} SPD3_LRDIMM_ADDITIVE_DELAY_FOR_QXODT_QXCKE;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte RC8MdqOdtStrength = 3;                ///< Bits 2:0
  [FieldOffset(0)] public byte RC8Reserved = 1;                ///< Bits 3:3
  [FieldOffset(0)] public byte RC9MdqOdtStrength = 3;                ///< Bits 6:4
  [FieldOffset(0)] public byte RC9Reserved = 1;                ///< Bits 7:7
}
byte Data;
} SPD3_LRDIMM_MDQ_TERMINATION_DRIVE_STRENGTH;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte RC10DA3ValueR0 = 1;                   ///< Bits 0:0
  [FieldOffset(0)] public byte RC10DA4ValueR0 = 1;                   ///< Bits 1:1
  [FieldOffset(0)] public byte RC10DA3ValueR1 = 1;                   ///< Bits 2:2
  [FieldOffset(0)] public byte RC10DA4ValueR1 = 1;                   ///< Bits 3:3
  [FieldOffset(0)] public byte RC11DA3ValueR0 = 1;                   ///< Bits 4:4
  [FieldOffset(0)] public byte RC11DA4ValueR0 = 1;                   ///< Bits 5:5
  [FieldOffset(0)] public byte RC11DA3ValueR1 = 1;                   ///< Bits 6:6
  [FieldOffset(0)] public byte RC11DA4ValueR1 = 1;                   ///< Bits 7:7
}
byte Data;
} SPD3_LRDIMM_RANK_READ_WRITE_QXODT_CONTROL;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte Driver_Impedance = 2;                 ///< Bits 1:0
  [FieldOffset(0)] public byte Rtt_Nom = 3;                 ///< Bits 4:2
  [FieldOffset(0)] public byte Reserved = 1;                 ///< Bits 5:5
  [FieldOffset(0)] public byte Rtt_WR = 2;                 ///< Bits 7:6
}
byte Data;
} SPD3_LRDIMM_MR_1_2;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public byte MinimumDelayTime = 7;                 ///< Bits 0:6
  [FieldOffset(0)] public byte Reserved = 1;                 ///< Bits 7:7
}
byte Data;
} SPD3_LRDIMM_MODULE_DELAY_TIME;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPD3_MANUFACTURING_DATE
{
  public byte Year;                               ///< Year represented in BCD (00h = 2000)
  public byte Week;                               ///< Year represented in BCD (47h = week 47)
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD3_MANUFACTURER_SERIAL_NUMBER
{
  [FieldOffset(0)] public uint Data;
  [FieldOffset(0)] public fixed ushort SerialNumber16[2];
  [FieldOffset(0)] public fixed byte SerialNumber8[4];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPD3_MANUFACTURING_LOCATION
{
  public byte Location;                           ///< Module Manufacturing Location
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPD3_UNIQUE_MODULE_ID
{
  public SPD3_MANUFACTURER_ID_CODE IdCode;                     ///< Module Manufacturer ID Code
  public SPD3_MANUFACTURING_LOCATION Location;                   ///< Module Manufacturing Location
  public SPD3_MANUFACTURING_DATE Date;                       ///< Module Manufacturing Year, in BCD (range: 2000-2255)
  public SPD3_MANUFACTURER_SERIAL_NUMBER SerialNumber;               ///< Module Serial Number
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD3_CYCLIC_REDUNDANCY_CODE
{
  [FieldOffset(0)] public fixed ushort Crc[1];
  [FieldOffset(0)] public fixed byte Data8[2];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPD3_BASE_SECTION
{
  public SPD3_DEVICE_DESCRIPTION_STRUCT Description;              ///< 0   Number of Serial PD Bytes Written / SPD Device Size / CRC Coverage 1, 2
  public SPD3_REVISION_STRUCT Revision;                 ///< 1   SPD Revision
  public SPD3_DRAM_DEVICE_TYPE_STRUCT DramDeviceType;           ///< 2   DRAM Device Type
  public SPD3_MODULE_TYPE_STRUCT ModuleType;               ///< 3   Module Type
  public SPD3_SDRAM_DENSITY_BANKS_STRUCT SdramDensityAndBanks;     ///< 4   SDRAM Density and Banks
  public SPD3_SDRAM_ADDRESSING_STRUCT SdramAddressing;          ///< 5   SDRAM Addressing
  public SPD3_MODULE_NOMINAL_VOLTAGE_STRUCT ModuleNominalVoltage;     ///< 6   Module Nominal Voltage, VDD
  public SPD3_MODULE_ORGANIZATION_STRUCT ModuleOrganization;       ///< 7   Module Organization
  public SPD3_MODULE_MEMORY_BUS_WIDTH_STRUCT ModuleMemoryBusWidth;     ///< 8   Module Memory Bus Width
  public SPD3_FINE_TIMEBASE_STRUCT FineTimebase;             ///< 9   Fine Timebase (FTB) Dividend / Divisor
  public SPD3_MEDIUM_TIMEBASE MediumTimebase;           ///< 10-11 Medium Timebase (MTB) Dividend
  public SPD3_TCK_MIN_MTB_STRUCT tCKmin;                   ///< 12  SDRAM Minimum Cycle Time (tCKmin)
  public byte Reserved0;                ///< 13  Reserved
  public SPD3_CAS_LATENCIES_SUPPORTED_STRUCT CasLatencies;             ///< 14-15 CAS Latencies Supported
  public SPD3_TAA_MIN_MTB_STRUCT tAAmin;                   ///< 16  Minimum CAS Latency Time (tAAmin)
  public SPD3_TWR_MIN_MTB_STRUCT tWRmin;                   ///< 17  Minimum Write Recovery Time (tWRmin)
  public SPD3_TRCD_MIN_MTB_STRUCT tRCDmin;                  ///< 18  Minimum RAS# to CAS# Delay Time (tRCDmin)
  public SPD3_TRRD_MIN_MTB_STRUCT tRRDmin;                  ///< 19  Minimum Row Active to Row Active Delay Time (tRRDmin)
  public SPD3_TRP_MIN_MTB_STRUCT tRPmin;                   ///< 20  Minimum Row Precharge Delay Time (tRPmin)
  public SPD3_TRAS_TRC_MIN_MTB_STRUCT tRASMintRCMinUpper;       ///< 21  Upper Nibbles for tRAS and tRC
  public SPD3_TRAS_MIN_MTB_STRUCT tRASmin;                  ///< 22  Minimum Active to Precharge Delay Time (tRASmin), Least Significant Byte
  public SPD3_TRC_MIN_MTB_STRUCT tRCmin;                   ///< 23  Minimum Active to Active/Refresh Delay Time (tRCmin), Least Significant Byte
  public SPD3_TRFC_MIN_MTB_STRUCT tRFCmin;                  ///< 24-25  Minimum Refresh Recovery Delay Time (tRFCmin)
  public SPD3_TWTR_MIN_MTB_STRUCT tWTRmin;                  ///< 26  Minimum Internal Write to Read Command Delay Time (tWTRmin)
  public SPD3_TRTP_MIN_MTB_STRUCT tRTPmin;                  ///< 27  Minimum Internal Read to Precharge Command Delay Time (tRTPmin)
  public SPD3_TFAW_MIN_MTB_UPPER_STRUCT tFAWMinUpper;             ///< 28  Upper Nibble for tFAW
  public SPD3_TFAW_MIN_MTB_STRUCT tFAWmin;                  ///< 29  Minimum Four Activate Window Delay Time (tFAWmin)
  public SPD3_SDRAM_OPTIONAL_FEATURES_STRUCT SdramOptionalFeatures;    ///< 30  SDRAM Optional Features
  public SPD3_SDRAM_THERMAL_REFRESH_STRUCT ThermalAndRefreshOptions; ///< 31  SDRAM Thermal And Refresh Options
  public SPD3_MODULE_THERMAL_SENSOR_STRUCT ModuleThermalSensor;      ///< 32  Module Thermal Sensor
  public SPD3_SDRAM_DEVICE_TYPE_STRUCT SdramDeviceType;          ///< 33  SDRAM Device Type
  public SPD3_TCK_MIN_FTB_STRUCT tCKminFine;               ///< 34  Fine Offset for SDRAM Minimum Cycle Time (tCKmin)
  public SPD3_TAA_MIN_FTB_STRUCT tAAminFine;               ///< 35  Fine Offset for Minimum CAS Latency Time (tAAmin)
  public SPD3_TRCD_MIN_FTB_STRUCT tRCDminFine;              ///< 36  Fine Offset for Minimum RAS# to CAS# Delay Time (tRCDmin)
  public SPD3_TRP_MIN_FTB_STRUCT tRPminFine;               ///< 37  Minimum Row Precharge Delay Time (tRPmin)
  public SPD3_TRC_MIN_FTB_STRUCT tRCminFine;               ///< 38  Fine Offset for Minimum Active to Active/Refresh Delay Time (tRCmin)
  public bytepublic public public public public public public public public public public public public public public public public Reserved1[40 - 39 + 1];public   ///< 39 - 40 Reserved
   public SPD3_MAXIMUM_ACTIVE_COUNT_STRUCT MacValue;                 ///< 41  SDRAM Maximum Active Count (MAC) Value
  public bytepublic public public public public public public public public public public public public public public public public Reserved2[59 - 42 + 1];public   ///< 42 - 59 Reserved
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPD3_MODULE_UNBUFFERED
{
  public SPD3_UNBUF_MODULE_NOMINAL_HEIGHT ModuleNominalHeight;    ///< 60  Module Nominal Height
  public SPD3_UNBUF_MODULE_NOMINAL_THICKNESS ModuleMaximumThickness; ///< 61  Module Maximum Thickness
  public SPD3_UNBUF_REFERENCE_RAW_CARD ReferenceRawCardUsed;   ///< 62  Reference Raw Card Used
  public SPD3_UNBUF_ADDRESS_MAPPING AddressMappingEdgeConn; ///< 63  Address Mapping from Edge Connector to DRAM
  public bytepublic public public public public public public public public public public public public public public public public Reserved[116 - 64 + 1]; ///< 64-116 Reserved
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPD3_MODULE_REGISTERED
{
  public SPD3_RDIMM_MODULE_NOMINAL_HEIGHT ModuleNominalHeight;         ///< 60  Module Nominal Height
  public SPD3_RDIMM_MODULE_NOMINAL_THICKNESS ModuleMaximumThickness;      ///< 61  Module Maximum Thickness
  public SPD3_RDIMM_REFERENCE_RAW_CARD ReferenceRawCardUsed;        ///< 62  Reference Raw Card Used
  public SPD3_RDIMM_MODULE_ATTRIBUTES DimmModuleAttributes;        ///< 63  DIMM Module Attributes
  public SPD3_RDIMM_THERMAL_HEAT_SPREADER_SOLUTION ThermalHeatSpreaderSolution; ///< 64     RDIMM Thermal Heat Spreader Solution
  public SPD3_MANUFACTURER_ID_CODE RegisterManufacturerIdCode;  ///< 65-66  Register Manufacturer ID Code
  public SPD3_RDIMM_REGISTER_REVISION_NUMBER RegisterRevisionNumber;      ///< 67     Register Revision Number
  public SPD3_RDIMM_REGISTER_TYPE RegisterType;                ///< 68  Register Type
  public SPD3_RDIMM_REGISTER_CONTROL_RESERVED Rc1Rc0;                      ///< 69  RC1 (MS Nibble) / RC0 (LS Nibble) - Reserved
  public SPD3_RDIMM_REGISTER_CONTROL_COMMAND_ADDRESS Rc3Rc2;                      ///< 70  RC3 (MS Nibble) / RC2 (LS Nibble) - Drive Strength, Command/Address
  public SPD3_RDIMM_REGISTER_CONTROL_CONTROL_CLOCK Rc5Rc4;                      ///< 71  RC5 (MS Nibble) / RC4 (LS Nibble) - Drive Strength, Control and Clock
  public SPD3_RDIMM_REGISTER_CONTROL_RESERVED Rc7Rc6;                      ///< 72  RC7 (MS Nibble) / RC6 (LS Nibble) - Reserved for Register Vendor
  public SPD3_RDIMM_REGISTER_CONTROL_RESERVED Rc9Rc8;                      ///< 73  RC9 (MS Nibble) / RC8 (LS Nibble) - Reserved
  public SPD3_RDIMM_REGISTER_CONTROL_RESERVED Rc11Rc10;                    ///< 74  RC11 (MS Nibble) / RC10 (LS Nibble) - Reserved
  public SPD3_RDIMM_REGISTER_CONTROL_RESERVED Rc13Rc12;                    ///< 75  RC12 (MS Nibble) / RC12 (LS Nibble) - Reserved
  public SPD3_RDIMM_REGISTER_CONTROL_RESERVED Rc15Rc14;                    ///< 76  RC15 (MS Nibble) / RC14 (LS Nibble) - Reserved
  public bytepublic public public public public public public public public public public public public public public public public public public public public Reserved[116 - 77 + 1];public public public  ///< 77-116 Reserved
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPD3_MODULE_CLOCKED
{
  public SPD3_UNBUF_MODULE_NOMINAL_HEIGHT ModuleNominalHeight;    ///< 60  Module Nominal Height
  public SPD3_UNBUF_MODULE_NOMINAL_THICKNESS ModuleMaximumThickness; ///< 61  Module Maximum Thickness
  public SPD3_UNBUF_REFERENCE_RAW_CARD ReferenceRawCardUsed;   ///< 62  Reference Raw Card Used
  public bytepublic public public public public public public public public public public public public public public public public Reserved[116 - 63 + 1]; ///< 63-116 Reserved
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPD3_MODULE_LOADREDUCED
{
  public SPD3_LRDIMM_MODULE_NOMINAL_HEIGHT ModuleNominalHeight;                     ///< 60  Module Nominal Height
  public SPD3_LRDIMM_MODULE_NOMINAL_THICKNESS ModuleMaximumThickness;                  ///< 61  Module Maximum Thickness
  public SPD3_LRDIMM_REFERENCE_RAW_CARD ReferenceRawCardUsed;                    ///< 62  Reference Raw Card Used
  public SPD3_LRDIMM_MODULE_ATTRIBUTES DimmModuleAttributes;                    ///< 63  Module Attributes
  public byte MemoryBufferRevisionNumber;              ///< 64    Memory Buffer Revision Number
  public SPD3_MANUFACTURER_ID_CODE ManufacturerIdCode;                      ///< 65-66 Memory Buffer Manufacturer ID Code
  public SPD3_LRDIMM_TIMING_CONTROL_DRIVE_STRENGTH TimingControlDriveStrengthCaCs;          ///< 67    F0RC3 / F0RC2 - Timing Control & Drive Strength, CA & CS
  public SPD3_LRDIMM_TIMING_DRIVE_STRENGTH DriveStrength;                           ///< 68    F0RC5 / F0RC4 - Drive Strength, ODT & CKE and Y
  public SPD3_LRDIMM_EXTENDED_DELAY ExtendedDelay;                           ///< 69    F1RC11 / F1RC8 - Extended Delay for Y, CS and ODT & CKE
  public SPD3_LRDIMM_ADDITIVE_DELAY_FOR_QXCS_N_QXCA AdditiveDelayForCsCa;                    ///< 70    F1RC13 / F1RC12 - Additive Delay for CS and CA
  public SPD3_LRDIMM_ADDITIVE_DELAY_FOR_QXODT_QXCKE AdditiveDelayForOdtCke;                  ///< 71    F1RC15 / F1RC14 - Additive Delay for ODT & CKE
  public SPD3_LRDIMM_MDQ_TERMINATION_DRIVE_STRENGTH MdqTerminationDriveStrengthFor800_1066;  ///< 72    F1RC15 / F1RC14 - Additive Delay for ODT & CKE
  public SPD3_LRDIMM_RANK_READ_WRITE_QXODT_CONTROL Rank_0_1QxOdtControlFor800_1066;         ///< 73    F[3,4]RC11 / F[3,4]RC10 - Rank 0 & 1 RD & WR QxODT Control for 800 & 1066
  public SPD3_LRDIMM_RANK_READ_WRITE_QXODT_CONTROL Rank_2_3QxOdtControlFor800_1066;         ///< 74    F[5,6]RC11 / F[5,6]RC10 - Rank 2 & 3 RD & WR QxODT Control for 800 & 1066
  public SPD3_LRDIMM_RANK_READ_WRITE_QXODT_CONTROL Rank_4_5QxOdtControlFor800_1066;         ///< 75    F[7,8]RC11 / F[7,8]RC10 - Rank 4 & 5 RD & WR QxODT Control for 800 & 1066
  public SPD3_LRDIMM_RANK_READ_WRITE_QXODT_CONTROL Rank_6_7QxOdtControlFor800_1066;         ///< 76    F[9,10]RC11 / F[9,10]RC10 - Rank 6 & 7 RD & WR QxODT Control for 800 & 1066
  public SPD3_LRDIMM_MR_1_2 MR_1_2RegistersFor800_1066;              ///< 77    MR1,2 Registers for 800 & 1066
  public SPD3_LRDIMM_MDQ_TERMINATION_DRIVE_STRENGTH MdqTerminationDriveStrengthFor1333_1600; ///< 78    F1RC15 / F1RC14 - Additive Delay for ODT & CKE
  public SPD3_LRDIMM_RANK_READ_WRITE_QXODT_CONTROL Rank_0_1QxOdtControlFor1333_1600;        ///< 79    F[3,4]RC11 / F[3,4]RC10 - Rank 0 & 1 RD & WR QxODT Control for 800 & 1066
  public SPD3_LRDIMM_RANK_READ_WRITE_QXODT_CONTROL Rank_2_3QxOdtControlFor1333_1600;        ///< 80    F[5,6]RC11 / F[5,6]RC10 - Rank 2 & 3 RD & WR QxODT Control for 800 & 1066
  public SPD3_LRDIMM_RANK_READ_WRITE_QXODT_CONTROL Rank_4_5QxOdtControlFor1333_1600;        ///< 81    F[7,8]RC11 / F[7,8]RC10 - Rank 4 & 5 RD & WR QxODT Control for 800 & 1066
  public SPD3_LRDIMM_RANK_READ_WRITE_QXODT_CONTROL Rank_6_7QxOdtControlFor1333_1600;        ///< 82    F[9,10]RC11 / F[9,10]RC10 - Rank 6 & 7 RD & WR QxODT Control for 800 & 1066
  public SPD3_LRDIMM_MR_1_2 MR_1_2RegistersFor1333_1600;             ///< 83    MR1,2 Registers for 800 & 1066
  public SPD3_LRDIMM_MDQ_TERMINATION_DRIVE_STRENGTH MdqTerminationDriveStrengthFor1866_2133; ///< 84    F1RC15 / F1RC14 - Additive Delay for ODT & CKE
  public SPD3_LRDIMM_RANK_READ_WRITE_QXODT_CONTROL Rank_0_1QxOdtControlFor1866_2133;        ///< 85    F[3,4]RC11 / F[3,4]RC10 - Rank 0 & 1 RD & WR QxODT Control for 800 & 1066
  public SPD3_LRDIMM_RANK_READ_WRITE_QXODT_CONTROL Rank_2_3QxOdtControlFor1866_2133;        ///< 86    F[5,6]RC11 / F[5,6]RC10 - Rank 2 & 3 RD & WR QxODT Control for 800 & 1066
  public SPD3_LRDIMM_RANK_READ_WRITE_QXODT_CONTROL Rank_4_5QxOdtControlFor1866_2133;        ///< 87    F[7,8]RC11 / F[7,8]RC10 - Rank 4 & 5 RD & WR QxODT Control for 800 & 1066
  public SPD3_LRDIMM_RANK_READ_WRITE_QXODT_CONTROL Rank_6_7QxOdtControlFor1866_2133;        ///< 88    F[9,10]RC11 / F[9,10]RC10 - Rank 6 & 7 RD & WR QxODT Control for 800 & 1066
  public SPD3_LRDIMM_MR_1_2 MR_1_2RegistersFor1866_2133;             ///< 89    MR1,2 Registers for 800 & 1066
  public SPD3_LRDIMM_MODULE_DELAY_TIME MinimumModuleDelayTimeFor1_5V;           ///< 90    Minimum Module Delay Time for 1.5 V
  public SPD3_LRDIMM_MODULE_DELAY_TIME MaximumModuleDelayTimeFor1_5V;           ///< 91    Maximum Module Delay Time for 1.5 V
  public SPD3_LRDIMM_MODULE_DELAY_TIME MinimumModuleDelayTimeFor1_35V;          ///< 92    Minimum Module Delay Time for 1.35 V
  public SPD3_LRDIMM_MODULE_DELAY_TIME MaximumModuleDelayTimeFor1_35V;          ///< 93    Maximum Module Delay Time for 1.35 V
  public SPD3_LRDIMM_MODULE_DELAY_TIME MinimumModuleDelayTimeFor1_25V;          ///< 94    Minimum Module Delay Time for 1.25 V
  public SPD3_LRDIMM_MODULE_DELAY_TIME MaximumModuleDelayTimeFor1_25V;          ///< 95    Maximum Module Delay Time for 1.25 V
  public bytepublic public public public public public public public public public public public public public public public public public public public Reserved[101 - 96 + 1];public public public public public public public public public  ///< 96-101public  Reserved
  public bytepublic public public public public public public public public public public public public public public public public public public public PersonalityByte[116 - 102 + 1];public public public public public  ///< 102-116 Memory Buffer Personality Bytes
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct SPD3_MODULE_SPECIFIC
{
  [FieldOffset(0)] public SPD3_MODULE_UNBUFFERED Unbuffered;                        ///< 128-255 Unbuffered Memory Module Types
  [FieldOffset(0)] public SPD3_MODULE_REGISTERED Registered;                        ///< 128-255 Registered Memory Module Types
  [FieldOffset(0)] public SPD3_MODULE_CLOCKED Clocked;                           ///< 128-255 Registered Memory Module Types
  [FieldOffset(0)] public SPD3_MODULE_LOADREDUCED LoadReduced;                       ///< 128-255 Load Reduced Memory Module Types
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPD3_MODULE_PART_NUMBER
{
  public bytepublic public ModulePartNumber[145 - 128 + 1];public public public public public public public public public public public public public public public  ///< 128-145 Module Part Number
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPD3_MODULE_REVISION_CODE
{
  public bytepublic public ModuleRevisionCode[147 - 146 + 1];public public public public public public public public public public public public public public  ///< 146-147 Module Revision Code
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPD3_MANUFACTURER_SPECIFIC
{
  public bytepublic public ManufacturerSpecificData[175 - 150 + 1];public public public public public public public public public public public  ///< 150-175 Manufacturer's Specific Data
}

///
/// DDR3 Serial Presence Detect structure
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SPD_DDR3
{
  public SPD3_BASE_SECTION General;                             ///< 0-59    General Section
  public SPD3_MODULE_SPECIFIC Module;                              ///< 60-116  Module-Specific Section
  public SPD3_UNIQUE_MODULE_ID ModuleId;                            ///< 117-125 Unique Module ID
  public SPD3_CYCLIC_REDUNDANCY_CODE Crc;                                 ///< 126-127 Cyclical Redundancy Code (CRC)
  public SPD3_MODULE_PART_NUMBER ModulePartNumber;                    ///< 128-145 Module Part Number
  public SPD3_MODULE_REVISION_CODE ModuleRevisionCode;                  ///< 146-147 Module Revision Code
  public SPD3_MANUFACTURER_ID_CODE DramIdCode;                          ///< 148-149 Dram Manufacturer ID Code
  public SPD3_MANUFACTURER_SPECIFIC ManufacturerSpecificData;            ///< 150-175 Manufacturer's Specific Data
  public bytepublic public public public public public public public public public public public public Reserved[255 - 176 + 1];public public public public public public   ///< 176-255 Open for Customer Use
}

// #pragma pack (pop)
// #endif

using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  Support for the latest PCI standard.

  Copyright (c) 2006 - 2021, Intel Corporation. All rights reserved.<BR>
  (C) Copyright 2016 Hewlett Packard Enterprise Development LP<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef _PCIEXPRESS21_H_
// #define _PCIEXPRESS21_H_

// #include <IndustryStandard/Pci30.h>

/**
  Macro that converts PCI Bus, PCI Device, PCI Function and PCI Register to an
  ECAM (Enhanced Configuration Access Mechanism) address. The unused upper bits
  of Bus, Device, Function and Register are stripped prior to the generation of
  the address.

  @param  Bus       PCI Bus number. Range 0..255.
  @param  Device    PCI Device number. Range 0..31.
  @param  Function  PCI Function number. Range 0..7.
  @param  Register  PCI Register number. Range 0..4095.

  @return The encode ECAM address.

**/
public const ulong PCI_ECAM_ADDRESS = (Bus, Device, Function, Offset) \;
  (((Offset) & 0xfff) | (((Function) & 0x07) << 12) | (((Device) & 0x1f) << 15) | (((Bus) & 0xff) << 20))

// #pragma pack(1)
///
/// PCI Express Capability Structure
///
[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public ushort Version = 4;
  [FieldOffset(0)] public ushort DevicePortType = 4;
  [FieldOffset(0)] public ushort SlotImplemented = 1;
  [FieldOffset(0)] public ushort InterruptMessageNumber = 5;
  [FieldOffset(0)] public ushort Undefined = 1;
  [FieldOffset(0)] public ushort Reserved = 1;
}
ushort Uint16;
} PCI_REG_PCIE_CAPABILITY;

public const ulong PCIE_DEVICE_PORT_TYPE_PCIE_ENDPOINT = 0;
public const ulong PCIE_DEVICE_PORT_TYPE_LEGACY_PCIE_ENDPOINT = 1;
public const ulong PCIE_DEVICE_PORT_TYPE_ROOT_PORT = 4;
public const ulong PCIE_DEVICE_PORT_TYPE_UPSTREAM_PORT = 5;
public const ulong PCIE_DEVICE_PORT_TYPE_DOWNSTREAM_PORT = 6;
public const ulong PCIE_DEVICE_PORT_TYPE_PCIE_TO_PCI_BRIDGE = 7;
public const ulong PCIE_DEVICE_PORT_TYPE_PCI_TO_PCIE_BRIDGE = 8;
public const ulong PCIE_DEVICE_PORT_TYPE_ROOT_COMPLEX_INTEGRATED_ENDPOINT = 9;
public const ulong PCIE_DEVICE_PORT_TYPE_ROOT_COMPLEX_EVENT_COLLECTOR = 10;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public uint MaxPayloadSize = 3;
  [FieldOffset(0)] public uint PhantomFunctions = 2;
  [FieldOffset(0)] public uint ExtendedTagField = 1;
  [FieldOffset(0)] public uint EndpointL0sAcceptableLatency = 3;
  [FieldOffset(0)] public uint EndpointL1AcceptableLatency = 3;
  [FieldOffset(0)] public uint Undefined = 3;
  [FieldOffset(0)] public uint RoleBasedErrorReporting = 1;
  [FieldOffset(0)] public uint Reserved = 2;
  [FieldOffset(0)] public uint CapturedSlotPowerLimitValue = 8;
  [FieldOffset(0)] public uint CapturedSlotPowerLimitScale = 2;
  [FieldOffset(0)] public uint FunctionLevelReset = 1;
  [FieldOffset(0)] public uint Reserved2 = 3;
}
uint Uint32;
} PCI_REG_PCIE_DEVICE_CAPABILITY;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public ushort CorrectableError = 1;
  [FieldOffset(0)] public ushort NonFatalError = 1;
  [FieldOffset(0)] public ushort FatalError = 1;
  [FieldOffset(0)] public ushort UnsupportedRequest = 1;
  [FieldOffset(0)] public ushort RelaxedOrdering = 1;
  [FieldOffset(0)] public ushort MaxPayloadSize = 3;
  [FieldOffset(0)] public ushort ExtendedTagField = 1;
  [FieldOffset(0)] public ushort PhantomFunctions = 1;
  [FieldOffset(0)] public ushort AuxPower = 1;
  [FieldOffset(0)] public ushort NoSnoop = 1;
  [FieldOffset(0)] public ushort MaxReadRequestSize = 3;
  [FieldOffset(0)] public ushort BridgeConfigurationRetryOrFunctionLevelReset = 1;
}
ushort Uint16;
} PCI_REG_PCIE_DEVICE_CONTROL;

public const ulong PCIE_MAX_PAYLOAD_SIZE_128B = 0;
public const ulong PCIE_MAX_PAYLOAD_SIZE_256B = 1;
public const ulong PCIE_MAX_PAYLOAD_SIZE_512B = 2;
public const ulong PCIE_MAX_PAYLOAD_SIZE_1024B = 3;
public const ulong PCIE_MAX_PAYLOAD_SIZE_2048B = 4;
public const ulong PCIE_MAX_PAYLOAD_SIZE_4096B = 5;
public const ulong PCIE_MAX_PAYLOAD_SIZE_RVSD1 = 6;
public const ulong PCIE_MAX_PAYLOAD_SIZE_RVSD2 = 7;

public const ulong PCIE_MAX_READ_REQ_SIZE_128B = 0;
public const ulong PCIE_MAX_READ_REQ_SIZE_256B = 1;
public const ulong PCIE_MAX_READ_REQ_SIZE_512B = 2;
public const ulong PCIE_MAX_READ_REQ_SIZE_1024B = 3;
public const ulong PCIE_MAX_READ_REQ_SIZE_2048B = 4;
public const ulong PCIE_MAX_READ_REQ_SIZE_4096B = 5;
public const ulong PCIE_MAX_READ_REQ_SIZE_RVSD1 = 6;
public const ulong PCIE_MAX_READ_REQ_SIZE_RVSD2 = 7;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public ushort CorrectableError = 1;
  [FieldOffset(0)] public ushort NonFatalError = 1;
  [FieldOffset(0)] public ushort FatalError = 1;
  [FieldOffset(0)] public ushort UnsupportedRequest = 1;
  [FieldOffset(0)] public ushort AuxPower = 1;
  [FieldOffset(0)] public ushort TransactionsPending = 1;
  [FieldOffset(0)] public ushort Reserved = 10;
}
ushort Uint16;
} PCI_REG_PCIE_DEVICE_STATUS;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public uint MaxLinkSpeed = 4;
  [FieldOffset(0)] public uint MaxLinkWidth = 6;
  [FieldOffset(0)] public uint Aspm = 2;
  [FieldOffset(0)] public uint L0sExitLatency = 3;
  [FieldOffset(0)] public uint L1ExitLatency = 3;
  [FieldOffset(0)] public uint ClockPowerManagement = 1;
  [FieldOffset(0)] public uint SurpriseDownError = 1;
  [FieldOffset(0)] public uint DataLinkLayerLinkActive = 1;
  [FieldOffset(0)] public uint LinkBandwidthNotification = 1;
  [FieldOffset(0)] public uint AspmOptionalityCompliance = 1;
  [FieldOffset(0)] public uint Reserved = 1;
  [FieldOffset(0)] public uint PortNumber = 8;
}
uint Uint32;
} PCI_REG_PCIE_LINK_CAPABILITY;

public const ulong PCIE_LINK_ASPM_L0S = BIT0;
public const ulong PCIE_LINK_ASPM_L1 = BIT1;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public ushort AspmControl = 2;
  [FieldOffset(0)] public ushort Reserved = 1;
  [FieldOffset(0)] public ushort ReadCompletionBoundary = 1;
  [FieldOffset(0)] public ushort LinkDisable = 1;
  [FieldOffset(0)] public ushort RetrainLink = 1;
  [FieldOffset(0)] public ushort CommonClockConfiguration = 1;
  [FieldOffset(0)] public ushort ExtendedSynch = 1;
  [FieldOffset(0)] public ushort ClockPowerManagement = 1;
  [FieldOffset(0)] public ushort HardwareAutonomousWidthDisable = 1;
  [FieldOffset(0)] public ushort LinkBandwidthManagementInterrupt = 1;
  [FieldOffset(0)] public ushort LinkAutonomousBandwidthInterrupt = 1;
}
ushort Uint16;
} PCI_REG_PCIE_LINK_CONTROL;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public ushort CurrentLinkSpeed = 4;
  [FieldOffset(0)] public ushort NegotiatedLinkWidth = 6;
  [FieldOffset(0)] public ushort Undefined = 1;
  [FieldOffset(0)] public ushort LinkTraining = 1;
  [FieldOffset(0)] public ushort SlotClockConfiguration = 1;
  [FieldOffset(0)] public ushort DataLinkLayerLinkActive = 1;
  [FieldOffset(0)] public ushort LinkBandwidthManagement = 1;
  [FieldOffset(0)] public ushort LinkAutonomousBandwidth = 1;
}
ushort Uint16;
} PCI_REG_PCIE_LINK_STATUS;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public uint AttentionButton = 1;
  [FieldOffset(0)] public uint PowerController = 1;
  [FieldOffset(0)] public uint MrlSensor = 1;
  [FieldOffset(0)] public uint AttentionIndicator = 1;
  [FieldOffset(0)] public uint PowerIndicator = 1;
  [FieldOffset(0)] public uint HotPlugSurprise = 1;
  [FieldOffset(0)] public uint HotPlugCapable = 1;
  [FieldOffset(0)] public uint SlotPowerLimitValue = 8;
  [FieldOffset(0)] public uint SlotPowerLimitScale = 2;
  [FieldOffset(0)] public uint ElectromechanicalInterlock = 1;
  [FieldOffset(0)] public uint NoCommandCompleted = 1;
  [FieldOffset(0)] public uint PhysicalSlotNumber = 13;
}
uint Uint32;
} PCI_REG_PCIE_SLOT_CAPABILITY;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public ushort AttentionButtonPressed = 1;
  [FieldOffset(0)] public ushort PowerFaultDetected = 1;
  [FieldOffset(0)] public ushort MrlSensorChanged = 1;
  [FieldOffset(0)] public ushort PresenceDetectChanged = 1;
  [FieldOffset(0)] public ushort CommandCompletedInterrupt = 1;
  [FieldOffset(0)] public ushort HotPlugInterrupt = 1;
  [FieldOffset(0)] public ushort AttentionIndicator = 2;
  [FieldOffset(0)] public ushort PowerIndicator = 2;
  [FieldOffset(0)] public ushort PowerController = 1;
  [FieldOffset(0)] public ushort ElectromechanicalInterlock = 1;
  [FieldOffset(0)] public ushort DataLinkLayerStateChanged = 1;
  [FieldOffset(0)] public ushort Reserved = 3;
}
ushort Uint16;
} PCI_REG_PCIE_SLOT_CONTROL;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public ushort AttentionButtonPressed = 1;
  [FieldOffset(0)] public ushort PowerFaultDetected = 1;
  [FieldOffset(0)] public ushort MrlSensorChanged = 1;
  [FieldOffset(0)] public ushort PresenceDetectChanged = 1;
  [FieldOffset(0)] public ushort CommandCompleted = 1;
  [FieldOffset(0)] public ushort MrlSensor = 1;
  [FieldOffset(0)] public ushort PresenceDetect = 1;
  [FieldOffset(0)] public ushort ElectromechanicalInterlock = 1;
  [FieldOffset(0)] public ushort DataLinkLayerStateChanged = 1;
  [FieldOffset(0)] public ushort Reserved = 7;
}
ushort Uint16;
} PCI_REG_PCIE_SLOT_STATUS;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public ushort SystemErrorOnCorrectableError = 1;
  [FieldOffset(0)] public ushort SystemErrorOnNonFatalError = 1;
  [FieldOffset(0)] public ushort SystemErrorOnFatalError = 1;
  [FieldOffset(0)] public ushort PmeInterrupt = 1;
  [FieldOffset(0)] public ushort CrsSoftwareVisibility = 1;
  [FieldOffset(0)] public ushort Reserved = 11;
}
ushort Uint16;
} PCI_REG_PCIE_ROOT_CONTROL;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public ushort CrsSoftwareVisibility = 1;
  [FieldOffset(0)] public ushort Reserved = 15;
}
ushort Uint16;
} PCI_REG_PCIE_ROOT_CAPABILITY;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public uint PmeRequesterId = 16;
  [FieldOffset(0)] public uint PmeStatus = 1;
  [FieldOffset(0)] public uint PmePending = 1;
  [FieldOffset(0)] public uint Reserved = 14;
}
uint Uint32;
} PCI_REG_PCIE_ROOT_STATUS;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public uint CompletionTimeoutRanges = 4;
  [FieldOffset(0)] public uint CompletionTimeoutDisable = 1;
  [FieldOffset(0)] public uint AriForwarding = 1;
  [FieldOffset(0)] public uint AtomicOpRouting = 1;
  [FieldOffset(0)] public uint AtomicOp32Completer = 1;
  [FieldOffset(0)] public uint AtomicOp64Completer = 1;
  [FieldOffset(0)] public uint Cas128Completer = 1;
  [FieldOffset(0)] public uint NoRoEnabledPrPrPassing = 1;
  [FieldOffset(0)] public uint LtrMechanism = 1;
  [FieldOffset(0)] public uint TphCompleter = 2;
  [FieldOffset(0)] public uint LnSystemCLS = 2;
  [FieldOffset(0)] public uint TenBitTagCompleterSupported = 1;
  [FieldOffset(0)] public uint TenBitTagRequesterSupported = 1;
  [FieldOffset(0)] public uint Obff = 2;
  [FieldOffset(0)] public uint ExtendedFmtField = 1;
  [FieldOffset(0)] public uint EndEndTlpPrefix = 1;
  [FieldOffset(0)] public uint MaxEndEndTlpPrefixes = 2;
  [FieldOffset(0)] public uint EmergencyPowerReductionSupported = 2;
  [FieldOffset(0)] public uint EmergencyPowerReductionInitializationRequired = 1;
  [FieldOffset(0)] public uint Reserved3 = 4;
  [FieldOffset(0)] public uint FrsSupported = 1;
}
uint Uint32;
} PCI_REG_PCIE_DEVICE_CAPABILITY2;

public const ulong PCIE_COMPLETION_TIMEOUT_NOT_SUPPORTED = 0;
public const ulong PCIE_COMPLETION_TIMEOUT_RANGE_A_SUPPORTED = 1;
public const ulong PCIE_COMPLETION_TIMEOUT_RANGE_B_SUPPORTED = 2;
public const ulong PCIE_COMPLETION_TIMEOUT_RANGE_A_B_SUPPORTED = 3;
public const ulong PCIE_COMPLETION_TIMEOUT_RANGE_B_C_SUPPORTED = 6;
public const ulong PCIE_COMPLETION_TIMEOUT_RANGE_A_B_C_SUPPORTED = 7;
public const ulong PCIE_COMPLETION_TIMEOUT_RANGE_B_C_D_SUPPORTED = 14;
public const ulong PCIE_COMPLETION_TIMEOUT_RANGE_A_B_C_D_SUPPORTED = 15;

public const ulong PCIE_DEVICE_CAPABILITY_OBFF_MESSAGE = BIT0;
public const ulong PCIE_DEVICE_CAPABILITY_OBFF_WAKE = BIT1;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public ushort CompletionTimeoutValue = 4;
  [FieldOffset(0)] public ushort CompletionTimeoutDisable = 1;
  [FieldOffset(0)] public ushort AriForwarding = 1;
  [FieldOffset(0)] public ushort AtomicOpRequester = 1;
  [FieldOffset(0)] public ushort AtomicOpEgressBlocking = 1;
  [FieldOffset(0)] public ushort IdoRequest = 1;
  [FieldOffset(0)] public ushort IdoCompletion = 1;
  [FieldOffset(0)] public ushort LtrMechanism = 1;
  [FieldOffset(0)] public ushort EmergencyPowerReductionRequest = 1;
  [FieldOffset(0)] public ushort TenBitTagRequesterEnable = 1;
  [FieldOffset(0)] public ushort Obff = 2;
  [FieldOffset(0)] public ushort EndEndTlpPrefixBlocking = 1;
}
ushort Uint16;
} PCI_REG_PCIE_DEVICE_CONTROL2;

public const ulong PCIE_COMPLETION_TIMEOUT_50US_50MS = 0;
public const ulong PCIE_COMPLETION_TIMEOUT_50US_100US = 1;
public const ulong PCIE_COMPLETION_TIMEOUT_1MS_10MS = 2;
public const ulong PCIE_COMPLETION_TIMEOUT_16MS_55MS = 5;
public const ulong PCIE_COMPLETION_TIMEOUT_65MS_210MS = 6;
public const ulong PCIE_COMPLETION_TIMEOUT_260MS_900MS = 9;
public const ulong PCIE_COMPLETION_TIMEOUT_1S_3_5S = 10;
public const ulong PCIE_COMPLETION_TIMEOUT_4S_13S = 13;
public const ulong PCIE_COMPLETION_TIMEOUT_17S_64S = 14;

public const ulong PCIE_DEVICE_CONTROL_OBFF_DISABLED = 0;
public const ulong PCIE_DEVICE_CONTROL_OBFF_MESSAGE_A = 1;
public const ulong PCIE_DEVICE_CONTROL_OBFF_MESSAGE_B = 2;
public const ulong PCIE_DEVICE_CONTROL_OBFF_WAKE = 3;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public uint Reserved = 1;
  [FieldOffset(0)] public uint LinkSpeedsVector = 7;
  [FieldOffset(0)] public uint Crosslink = 1;
  [FieldOffset(0)] public uint Reserved2 = 23;
}
uint Uint32;
} PCI_REG_PCIE_LINK_CAPABILITY2;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public ushort TargetLinkSpeed = 4;
  [FieldOffset(0)] public ushort EnterCompliance = 1;
  [FieldOffset(0)] public ushort HardwareAutonomousSpeedDisable = 1;
  [FieldOffset(0)] public ushort SelectableDeemphasis = 1;
  [FieldOffset(0)] public ushort TransmitMargin = 3;
  [FieldOffset(0)] public ushort EnterModifiedCompliance = 1;
  [FieldOffset(0)] public ushort ComplianceSos = 1;
  [FieldOffset(0)] public ushort CompliancePresetDeemphasis = 4;
}
ushort Uint16;
} PCI_REG_PCIE_LINK_CONTROL2;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public ushort CurrentDeemphasisLevel = 1;
  [FieldOffset(0)] public ushort EqualizationComplete = 1;
  [FieldOffset(0)] public ushort EqualizationPhase1Successful = 1;
  [FieldOffset(0)] public ushort EqualizationPhase2Successful = 1;
  [FieldOffset(0)] public ushort EqualizationPhase3Successful = 1;
  [FieldOffset(0)] public ushort LinkEqualizationRequest = 1;
  [FieldOffset(0)] public ushort Reserved = 10;
}
ushort Uint16;
} PCI_REG_PCIE_LINK_STATUS2;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct PCI_CAPABILITY_PCIEXP
{
  public EFI_PCI_CAPABILITY_HDR Hdr;
  public PCI_REG_PCIE_CAPABILITY Capability;
  public PCI_REG_PCIE_DEVICE_CAPABILITY DeviceCapability;
  public PCI_REG_PCIE_DEVICE_CONTROL DeviceControl;
  public PCI_REG_PCIE_DEVICE_STATUS DeviceStatus;
  public PCI_REG_PCIE_LINK_CAPABILITY LinkCapability;
  public PCI_REG_PCIE_LINK_CONTROL LinkControl;
  public PCI_REG_PCIE_LINK_STATUS LinkStatus;
  public PCI_REG_PCIE_SLOT_CAPABILITY SlotCapability;
  public PCI_REG_PCIE_SLOT_CONTROL SlotControl;
  public PCI_REG_PCIE_SLOT_STATUS SlotStatus;
  public PCI_REG_PCIE_ROOT_CONTROL RootControl;
  public PCI_REG_PCIE_ROOT_CAPABILITY RootCapability;
  public PCI_REG_PCIE_ROOT_STATUS RootStatus;
  public PCI_REG_PCIE_DEVICE_CAPABILITY2 DeviceCapability2;
  public PCI_REG_PCIE_DEVICE_CONTROL2 DeviceControl2;
  public ushort DeviceStatus2;
  public PCI_REG_PCIE_LINK_CAPABILITY2 LinkCapability2;
  public PCI_REG_PCIE_LINK_CONTROL2 LinkControl2;
  public PCI_REG_PCIE_LINK_STATUS2 LinkStatus2;
  public uint SlotCapability2;
  public ushort SlotControl2;
  public ushort SlotStatus2;
}

public const ulong EFI_PCIE_CAPABILITY_BASE_OFFSET = 0x100;
public const ulong EFI_PCIE_CAPABILITY_ID_SRIOV_CONTROL_ARI_HIERARCHY = 0x10;
public const ulong EFI_PCIE_CAPABILITY_DEVICE_CAPABILITIES_2_OFFSET = 0x24;
public const ulong EFI_PCIE_CAPABILITY_DEVICE_CAPABILITIES_2_ARI_FORWARDING = 0x20;
public const ulong EFI_PCIE_CAPABILITY_DEVICE_CONTROL_2_OFFSET = 0x28;
public const ulong EFI_PCIE_CAPABILITY_DEVICE_CONTROL_2_ARI_FORWARDING = 0x20;

//
// for SR-IOV
//
public const ulong EFI_PCIE_CAPABILITY_ID_ARI = 0x0E;
public const ulong EFI_PCIE_CAPABILITY_ID_ATS = 0x0F;
public const ulong EFI_PCIE_CAPABILITY_ID_SRIOV = 0x10;
public const ulong EFI_PCIE_CAPABILITY_ID_MRIOV = 0x11;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct SR_IOV_CAPABILITY_REGISTER
{
  public uint CapabilityHeader;
  public uint Capability;
  public ushort Control;
  public ushort Status;
  public ushort InitialVFs;
  public ushort TotalVFs;
  public ushort NumVFs;
  public byte FunctionDependencyLink;
  public byte Reserved0;
  public ushort FirstVFOffset;
  public ushort VFStride;
  public ushort Reserved1;
  public ushort VFDeviceID;
  public uint SupportedPageSize;
  public uint SystemPageSize;
  public fixed uint VFBar[6];
  public uint VFMigrationStateArrayOffset;
}

public const ulong EFI_PCIE_CAPABILITY_ID_SRIOV_CAPABILITIES = 0x04;
public const ulong EFI_PCIE_CAPABILITY_ID_SRIOV_CONTROL = 0x08;
public const ulong EFI_PCIE_CAPABILITY_ID_SRIOV_STATUS = 0x0A;
public const ulong EFI_PCIE_CAPABILITY_ID_SRIOV_INITIALVFS = 0x0C;
public const ulong EFI_PCIE_CAPABILITY_ID_SRIOV_TOTALVFS = 0x0E;
public const ulong EFI_PCIE_CAPABILITY_ID_SRIOV_NUMVFS = 0x10;
public const ulong EFI_PCIE_CAPABILITY_ID_SRIOV_FUNCTION_DEPENDENCY_LINK = 0x12;
public const ulong EFI_PCIE_CAPABILITY_ID_SRIOV_FIRSTVF = 0x14;
public const ulong EFI_PCIE_CAPABILITY_ID_SRIOV_VFSTRIDE = 0x16;
public const ulong EFI_PCIE_CAPABILITY_ID_SRIOV_VFDEVICEID = 0x1A;
public const ulong EFI_PCIE_CAPABILITY_ID_SRIOV_SUPPORTED_PAGE_SIZE = 0x1C;
public const ulong EFI_PCIE_CAPABILITY_ID_SRIOV_SYSTEM_PAGE_SIZE = 0x20;
public const ulong EFI_PCIE_CAPABILITY_ID_SRIOV_BAR0 = 0x24;
public const ulong EFI_PCIE_CAPABILITY_ID_SRIOV_BAR1 = 0x28;
public const ulong EFI_PCIE_CAPABILITY_ID_SRIOV_BAR2 = 0x2C;
public const ulong EFI_PCIE_CAPABILITY_ID_SRIOV_BAR3 = 0x30;
public const ulong EFI_PCIE_CAPABILITY_ID_SRIOV_BAR4 = 0x34;
public const ulong EFI_PCIE_CAPABILITY_ID_SRIOV_BAR5 = 0x38;
public const ulong EFI_PCIE_CAPABILITY_ID_SRIOV_VF_MIGRATION_STATE = 0x3C;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct PCI_EXPRESS_EXTENDED_CAPABILITIES_HEADER
{
  public uint CapabilityId = 16;
  public uint CapabilityVersion = 4;
  public uint NextCapabilityOffset = 12;
}

public const ulong PCI_EXP_EXT_HDR = PCI_EXPRESS_EXTENDED_CAPABILITIES_HEADER;

public const ulong PCI_EXPRESS_EXTENDED_CAPABILITY_ADVANCED_ERROR_REPORTING_ID = 0x0001;
public const ulong PCI_EXPRESS_EXTENDED_CAPABILITY_ADVANCED_ERROR_REPORTING_VER1 = 0x1;
public const ulong PCI_EXPRESS_EXTENDED_CAPABILITY_ADVANCED_ERROR_REPORTING_VER2 = 0x2;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public uint Undefined = 1;
  [FieldOffset(0)] public uint Reserved = 3;
  [FieldOffset(0)] public uint DataLinkProtocolError = 1;
  [FieldOffset(0)] public uint SurpriseDownError = 1;
  [FieldOffset(0)] public uint Reserved2 = 6;
  [FieldOffset(0)] public uint PoisonedTlp = 1;
  [FieldOffset(0)] public uint FlowControlProtocolError = 1;
  [FieldOffset(0)] public uint CompletionTimeout = 1;
  [FieldOffset(0)] public uint CompleterAbort = 1;
  [FieldOffset(0)] public uint UnexpectedCompletion = 1;
  [FieldOffset(0)] public uint ReceiverOverflow = 1;
  [FieldOffset(0)] public uint MalformedTlp = 1;
  [FieldOffset(0)] public uint EcrcError = 1;
  [FieldOffset(0)] public uint UnsupportedRequestError = 1;
  [FieldOffset(0)] public uint AcsVoilation = 1;
  [FieldOffset(0)] public uint UncorrectableInternalError = 1;
  [FieldOffset(0)] public uint McBlockedTlp = 1;
  [FieldOffset(0)] public uint AtomicOpEgressBlocked = 1;
  [FieldOffset(0)] public uint TlpPrefixBlockedError = 1;
  [FieldOffset(0)] public uint Reserved3 = 6;
}
uint Uint32;
} PCI_EXPRESS_REG_UNCORRECTABLE_ERROR;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct PCI_EXPRESS_EXTENDED_CAPABILITIES_ADVANCED_ERROR_REPORTING
{
  public PCI_EXPRESS_EXTENDED_CAPABILITIES_HEADER Header;
  public PCI_EXPRESS_REG_UNCORRECTABLE_ERROR UncorrectableErrorStatus;
  public PCI_EXPRESS_REG_UNCORRECTABLE_ERROR UncorrectableErrorMask;
  public PCI_EXPRESS_REG_UNCORRECTABLE_ERROR UncorrectableErrorSeverity;
  public uint CorrectableErrorStatus;
  public uint CorrectableErrorMask;
  public uint AdvancedErrorCapabilitiesAndControl;
  public fixed uint HeaderLog[4];
  public uint RootErrorCommand;
  public uint RootErrorStatus;
  public ushort ErrorSourceIdentification;
  public ushort CorrectableErrorSourceIdentification;
  public fixed uint TlpPrefixLog[4];
}

public const ulong PCI_EXPRESS_EXTENDED_CAPABILITY_VIRTUAL_CHANNEL_ID = 0x0002;
public const ulong PCI_EXPRESS_EXTENDED_CAPABILITY_VIRTUAL_CHANNEL_MFVC = 0x0009;
public const ulong PCI_EXPRESS_EXTENDED_CAPABILITY_VIRTUAL_CHANNEL_VER1 = 0x1;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct PCI_EXPRESS_EXTENDED_CAPABILITIES_VIRTUAL_CHANNEL_VC
{
  public uint VcResourceCapability = 24;
  public uint PortArbTableOffset = 8;
  public uint VcResourceControl;
  public ushort Reserved1;
  public ushort VcResourceStatus;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct PCI_EXPRESS_EXTENDED_CAPABILITIES_VIRTUAL_CHANNEL_CAPABILITY
{
  public PCI_EXPRESS_EXTENDED_CAPABILITIES_HEADER Header;
  public uint ExtendedVcCount = 3;
  public uint PortVcCapability1 = 29;
  public uint PortVcCapability2 = 24;
  public uint VcArbTableOffset = 8;
  public ushort PortVcControl;
  public ushort PortVcStatus;
  public fixed PCI_EXPRESS_EXTENDED_CAPABILITIES_VIRTUAL_CHANNEL_VC Capability[1];
}

public const ulong PCI_EXPRESS_EXTENDED_CAPABILITY_SERIAL_NUMBER_ID = 0x0003;
public const ulong PCI_EXPRESS_EXTENDED_CAPABILITY_SERIAL_NUMBER_VER1 = 0x1;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct PCI_EXPRESS_EXTENDED_CAPABILITIES_SERIAL_NUMBER
{
  public PCI_EXPRESS_EXTENDED_CAPABILITIES_HEADER Header;
  public ulong SerialNumber;
}

public const ulong PCI_EXPRESS_EXTENDED_CAPABILITY_LINK_DECLARATION_ID = 0x0005;
public const ulong PCI_EXPRESS_EXTENDED_CAPABILITY_LINK_DECLARATION_VER1 = 0x1;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct PCI_EXPRESS_EXTENDED_CAPABILITIES_LINK_DECLARATION
{
  public PCI_EXPRESS_EXTENDED_CAPABILITIES_HEADER Header;
  public uint ElementSelfDescription;
  public uint Reserved;
  public fixed uint LinkEntry[1];
}

public const ulong PCI_EXPRESS_EXTENDED_CAPABILITY_LINK_DECLARATION_GET_LINK_COUNT = (LINK_DECLARATION)(byte)(((LINK_DECLARATION->ElementSelfDescription) & 0x0000ff00) >> 8);

public const ulong PCI_EXPRESS_EXTENDED_CAPABILITY_LINK_CONTROL_ID = 0x0006;
public const ulong PCI_EXPRESS_EXTENDED_CAPABILITY_LINK_CONTROL_VER1 = 0x1;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct PCI_EXPRESS_EXTENDED_CAPABILITIES_INTERNAL_LINK_CONTROL
{
  public PCI_EXPRESS_EXTENDED_CAPABILITIES_HEADER Header;
  public uint RootComplexLinkCapabilities;
  public ushort RootComplexLinkControl;
  public ushort RootComplexLinkStatus;
}

public const ulong PCI_EXPRESS_EXTENDED_CAPABILITY_POWER_BUDGETING_ID = 0x0004;
public const ulong PCI_EXPRESS_EXTENDED_CAPABILITY_POWER_BUDGETING_VER1 = 0x1;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct PCI_EXPRESS_EXTENDED_CAPABILITIES_POWER_BUDGETING
{
  public PCI_EXPRESS_EXTENDED_CAPABILITIES_HEADER Header;
  public uint DataSelect = 8;
  public uint Reserved = 24;
  public uint Data;
  public uint PowerBudgetCapability = 1;
  public uint Reserved2 = 7;
  public uint Reserved3 = 24;
}

public const ulong PCI_EXPRESS_EXTENDED_CAPABILITY_ACS_EXTENDED_ID = 0x000D;
public const ulong PCI_EXPRESS_EXTENDED_CAPABILITY_ACS_EXTENDED_VER1 = 0x1;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct PCI_EXPRESS_EXTENDED_CAPABILITIES_ACS_EXTENDED
{
  public PCI_EXPRESS_EXTENDED_CAPABILITIES_HEADER Header;
  public ushort AcsCapability;
  public ushort AcsControl;
  public fixed byte EgressControlVectorArray[1];
}

public const ulong PCI_EXPRESS_EXTENDED_CAPABILITY_ACS_EXTENDED_GET_EGRES_CONTROL = (ACS_EXTENDED)(byte)(((ACS_EXTENDED->AcsCapability) & 0x00000020));
public const ulong PCI_EXPRESS_EXTENDED_CAPABILITY_ACS_EXTENDED_GET_EGRES_VECTOR_SIZE = (ACS_EXTENDED)(byte)(((ACS_EXTENDED->AcsCapability) & 0x0000FF00));

public const ulong PCI_EXPRESS_EXTENDED_CAPABILITY_EVENT_COLLECTOR_ENDPOINT_ASSOCIATION_ID = 0x0007;
public const ulong PCI_EXPRESS_EXTENDED_CAPABILITY_EVENT_COLLECTOR_ENDPOINT_ASSOCIATION_VER1 = 0x1;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct PCI_EXPRESS_EXTENDED_CAPABILITIES_EVENT_COLLECTOR_ENDPOINT_ASSOCIATION
{
  public PCI_EXPRESS_EXTENDED_CAPABILITIES_HEADER Header;
  public uint AssociationBitmap;
}

public const ulong PCI_EXPRESS_EXTENDED_CAPABILITY_MULTI_FUNCTION_VIRTUAL_CHANNEL_ID = 0x0008;
public const ulong PCI_EXPRESS_EXTENDED_CAPABILITY_MULTI_FUNCTION_VIRTUAL_CHANNEL_VER1 = 0x1;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct PCI_EXPRESS_EXTENDED_CAPABILITIES_MULTI_FUNCTION_VIRTUAL_CHANNEL_CAPABILITY { PCI_EXPRESS_EXTENDED_CAPABILITIES_VIRTUAL_CHANNEL_CAPABILITY Value; public static implicit operator PCI_EXPRESS_EXTENDED_CAPABILITIES_MULTI_FUNCTION_VIRTUAL_CHANNEL_CAPABILITY(PCI_EXPRESS_EXTENDED_CAPABILITIES_VIRTUAL_CHANNEL_CAPABILITY value) => new PCI_EXPRESS_EXTENDED_CAPABILITIES_MULTI_FUNCTION_VIRTUAL_CHANNEL_CAPABILITY() { Value = value }; public static implicit operator PCI_EXPRESS_EXTENDED_CAPABILITIES_VIRTUAL_CHANNEL_CAPABILITY(PCI_EXPRESS_EXTENDED_CAPABILITIES_MULTI_FUNCTION_VIRTUAL_CHANNEL_CAPABILITY value) => value.Value; }

public const ulong PCI_EXPRESS_EXTENDED_CAPABILITY_VENDOR_SPECIFIC_ID = 0x000B;
public const ulong PCI_EXPRESS_EXTENDED_CAPABILITY_VENDOR_SPECIFIC_VER1 = 0x1;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct PCI_EXPRESS_EXTENDED_CAPABILITIES_VENDOR_SPECIFIC
{
  public PCI_EXPRESS_EXTENDED_CAPABILITIES_HEADER Header;
  public uint VendorSpecificHeader;
  public fixed byte VendorSpecific[1];
}

public const ulong PCI_EXPRESS_EXTENDED_CAPABILITY_VENDOR_SPECIFIC_GET_SIZE = (VENDOR)(ushort)(((VENDOR->VendorSpecificHeader) & 0xFFF00000) >> 20);

public const ulong PCI_EXPRESS_EXTENDED_CAPABILITY_RCRB_HEADER_ID = 0x000A;
public const ulong PCI_EXPRESS_EXTENDED_CAPABILITY_RCRB_HEADER_VER1 = 0x1;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct PCI_EXPRESS_EXTENDED_CAPABILITIES_RCRB_HEADER
{
  public PCI_EXPRESS_EXTENDED_CAPABILITIES_HEADER Header;
  public ushort VendorId;
  public ushort DeviceId;
  public uint RcrbCapabilities;
  public uint RcrbControl;
  public uint Reserved;
}

public const ulong PCI_EXPRESS_EXTENDED_CAPABILITY_MULTICAST_ID = 0x0012;
public const ulong PCI_EXPRESS_EXTENDED_CAPABILITY_MULTICAST_VER1 = 0x1;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct PCI_EXPRESS_EXTENDED_CAPABILITIES_MULTICAST
{
  public PCI_EXPRESS_EXTENDED_CAPABILITIES_HEADER Header;
  public ushort MultiCastCapability;
  public ushort MulticastControl;
  public ulong McBaseAddress;
  public ulong McReceiveAddress;
  public ulong McBlockAll;
  public ulong McBlockUntranslated;
  public ulong McOverlayBar;
}

public const ulong PCI_EXPRESS_EXTENDED_CAPABILITY_RESIZABLE_BAR_ID = 0x0015;
public const ulong PCI_EXPRESS_EXTENDED_CAPABILITY_RESIZABLE_BAR_VER1 = 0x1;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public uint Reserved = 4;
  [FieldOffset(0)] public uint BarSizeCapability = 28;
}
uint Uint32;
} PCI_EXPRESS_EXTENDED_CAPABILITIES_RESIZABLE_BAR_CAPABILITY;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct Bits
{
  struct {
   [FieldOffset(0)] public uint BarIndex = 3;
  [FieldOffset(0)] public uint Reserved = 2;
  [FieldOffset(0)] public uint ResizableBarNumber = 3;
  [FieldOffset(0)] public uint BarSize = 6;
  [FieldOffset(0)] public uint Reserved2 = 2;
  [FieldOffset(0)] public uint BarSizeCapability = 16;
}
uint Uint32;
} PCI_EXPRESS_EXTENDED_CAPABILITIES_RESIZABLE_BAR_CONTROL;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct PCI_EXPRESS_EXTENDED_CAPABILITIES_RESIZABLE_BAR_ENTRY
{
  public PCI_EXPRESS_EXTENDED_CAPABILITIES_RESIZABLE_BAR_CAPABILITY ResizableBarCapability;
  public PCI_EXPRESS_EXTENDED_CAPABILITIES_RESIZABLE_BAR_CONTROL ResizableBarControl;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct PCI_EXPRESS_EXTENDED_CAPABILITIES_RESIZABLE_BAR
{
  public PCI_EXPRESS_EXTENDED_CAPABILITIES_HEADER Header;
  public fixed PCI_EXPRESS_EXTENDED_CAPABILITIES_RESIZABLE_BAR_ENTRY Capability[1];
}

public const ulong GET_NUMBER_RESIZABLE_BARS = (x)(x->Capability[0].ResizableBarControl.Bits.ResizableBarNumber);

public const ulong PCI_EXPRESS_EXTENDED_CAPABILITY_ARI_CAPABILITY_ID = 0x000E;
public const ulong PCI_EXPRESS_EXTENDED_CAPABILITY_ARI_CAPABILITY_VER1 = 0x1;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct PCI_EXPRESS_EXTENDED_CAPABILITIES_ARI_CAPABILITY
{
  public PCI_EXPRESS_EXTENDED_CAPABILITIES_HEADER Header;
  public ushort AriCapability;
  public ushort AriControl;
}

public const ulong PCI_EXPRESS_EXTENDED_CAPABILITY_DYNAMIC_POWER_ALLOCATION_ID = 0x0016;
public const ulong PCI_EXPRESS_EXTENDED_CAPABILITY_DYNAMIC_POWER_ALLOCATION_VER1 = 0x1;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct PCI_EXPRESS_EXTENDED_CAPABILITIES_DYNAMIC_POWER_ALLOCATION
{
  public PCI_EXPRESS_EXTENDED_CAPABILITIES_HEADER Header;
  public uint DpaCapability;
  public uint DpaLatencyIndicator;
  public ushort DpaStatus;
  public ushort DpaControl;
  public fixed byte DpaPowerAllocationArray[1];
}

public const ulong PCI_EXPRESS_EXTENDED_CAPABILITY_DYNAMIC_POWER_ALLOCATION_GET_SUBSTATE_MAX = (POWER)(ushort)(((POWER->DpaCapability) & 0x0000000F));

public const ulong PCI_EXPRESS_EXTENDED_CAPABILITY_LATENCE_TOLERANCE_REPORTING_ID = 0x0018;
public const ulong PCI_EXPRESS_EXTENDED_CAPABILITY_LATENCE_TOLERANCE_REPORTING_VER1 = 0x1;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct PCI_EXPRESS_EXTENDED_CAPABILITIES_LATENCE_TOLERANCE_REPORTING
{
  public PCI_EXPRESS_EXTENDED_CAPABILITIES_HEADER Header;
  public ushort MaxSnoopLatency;
  public ushort MaxNoSnoopLatency;
}

public const ulong PCI_EXPRESS_EXTENDED_CAPABILITY_TPH_ID = 0x0017;
public const ulong PCI_EXPRESS_EXTENDED_CAPABILITY_TPH_VER1 = 0x1;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct PCI_EXPRESS_EXTENDED_CAPABILITIES_TPH
{
  public PCI_EXPRESS_EXTENDED_CAPABILITIES_HEADER Header;
  public uint TphRequesterCapability;
  public uint TphRequesterControl;
  public fixed ushort TphStTable[1];
}

public const ulong GET_TPH_TABLE_SIZE = (x)((x->TphRequesterCapability & 0x7FF0000) >> 16) * sizeof(ushort);

// #pragma pack()

// #endif

using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  This file contains just some basic definitions that are needed by drivers
  that dealing with ATA/ATAPI interface.

Copyright (c) 2007 - 2018, Intel Corporation. All rights reserved.<BR>
SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef _ATAPI_H_
// #define _ATAPI_H_

// #pragma pack(1)

///
/// ATA5_IDENTIFY_DATA is defined in ATA-5.
/// (This structure is provided mainly for backward-compatibility support.
/// Old drivers may reference fields that are marked "obsolete" in
/// ATA_IDENTIFY_DATA, which currently conforms to ATA-8.)
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct ATA5_IDENTIFY_DATA
{
  public ushort config;           ///< General Configuration.
  public ushort cylinders;        ///< Number of Cylinders.
  public ushort reserved_2;
  public ushort heads;            ///< Number of logical heads.
  public ushort vendor_data1;
  public ushort vendor_data2;
  public ushort sectors_per_track;
  public fixed ushort vendor_specific_7_9[3];
  public fixed byte SerialNo[20];     ///< ASCII
  public fixed ushort vendor_specific_20_21[2];
  public ushort ecc_bytes_available;
  public fixed byte FirmwareVer[8];   ///< ASCII
  public fixed byte ModelName[40];    ///< ASCII
  public ushort multi_sector_cmd_max_sct_cnt;
  public ushort reserved_48;
  public ushort capabilities;
  public ushort reserved_50;
  public ushort pio_cycle_timing;
  public ushort reserved_52;
  public ushort field_validity;
  public ushort current_cylinders;
  public ushort current_heads;
  public ushort current_sectors;
  public ushort CurrentCapacityLsb;
  public ushort CurrentCapacityMsb;
  public ushort reserved_59;
  public ushort user_addressable_sectors_lo;
  public ushort user_addressable_sectors_hi;
  public ushort reserved_62;
  public ushort multi_word_dma_mode;
  public ushort advanced_pio_modes;
  public ushort min_multi_word_dma_cycle_time;
  public ushort rec_multi_word_dma_cycle_time;
  public ushort min_pio_cycle_time_without_flow_control;
  public ushort min_pio_cycle_time_with_flow_control;
  public fixed ushort reserved_69_79[11];
  public ushort major_version_no;
  public ushort minor_version_no;
  public ushort command_set_supported_82;    ///< word 82
  public ushort command_set_supported_83;    ///< word 83
  public ushort command_set_feature_extn;    ///< word 84
  public ushort command_set_feature_enb_85;  ///< word 85
  public ushort command_set_feature_enb_86;  ///< word 86
  public ushort command_set_feature_default; ///< word 87
  public ushort ultra_dma_mode;              ///< word 88
  public fixed ushort reserved_89_127[39];
  public ushort security_status;
  public fixed ushort vendor_data_129_159[31];
  public fixed ushort reserved_160_255[96];
}

///
/// ATA_IDENTIFY_DATA strictly complies with ATA/ATAPI-8 Spec
/// to define the data returned by an ATA device upon successful
/// completion of the ATA IDENTIFY_DEVICE command.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct ATA_IDENTIFY_DATA
{
  public ushort config;                                ///< General Configuration.
  public ushort obsolete_1;
  public ushort specific_config;                       ///< Specific Configuration.
  public ushort obsolete_3;
  public fixed ushort retired_4_5[2];
  public ushort obsolete_6;
  public fixed ushort cfa_reserved_7_8[2];
  public ushort retired_9;
  public fixed byte SerialNo[20];                          ///< word 10~19
  public fixed ushort retired_20_21[2];
  public ushort obsolete_22;
  public fixed byte FirmwareVer[8];                        ///< word 23~26
  public fixed byte ModelName[40];                         ///< word 27~46
  public ushort multi_sector_cmd_max_sct_cnt;
  public ushort trusted_computing_support;
  public ushort capabilities_49;
  public ushort capabilities_50;
  public fixed ushort obsolete_51_52[2];
  public ushort field_validity;
  public fixed ushort obsolete_54_58[5];
  public ushort multi_sector_setting;
  public ushort user_addressable_sectors_lo;
  public ushort user_addressable_sectors_hi;
  public ushort obsolete_62;
  public ushort multi_word_dma_mode;
  public ushort advanced_pio_modes;
  public ushort min_multi_word_dma_cycle_time;
  public ushort rec_multi_word_dma_cycle_time;
  public ushort min_pio_cycle_time_without_flow_control;
  public ushort min_pio_cycle_time_with_flow_control;
  public ushort additional_supported;                  ///< word 69
  public ushort reserved_70;
  public fixed ushort reserved_71_74[4];                     ///< Reserved for IDENTIFY PACKET DEVICE cmd.
  public ushort queue_depth;
  public ushort serial_ata_capabilities;
  public ushort reserved_77;                           ///< Reserved for Serial ATA
  public ushort serial_ata_features_supported;
  public ushort serial_ata_features_enabled;
  public ushort major_version_no;
  public ushort minor_version_no;
  public ushort command_set_supported_82;              ///< word 82
  public ushort command_set_supported_83;              ///< word 83
  public ushort command_set_feature_extn;              ///< word 84
  public ushort command_set_feature_enb_85;            ///< word 85
  public ushort command_set_feature_enb_86;            ///< word 86
  public ushort command_set_feature_default;           ///< word 87
  public ushort ultra_dma_mode;                        ///< word 88
  public ushort time_for_security_erase_unit;
  public ushort time_for_enhanced_security_erase_unit;
  public ushort advanced_power_management_level;
  public ushort master_password_identifier;
  public ushort hardware_configuration_test_result;
  public ushort obsolete_94;
  public ushort stream_minimum_request_size;
  public ushort streaming_transfer_time_for_dma;
  public ushort streaming_access_latency_for_dma_and_pio;
  public fixed ushort streaming_performance_granularity[2];  ///< word 98~99
  public fixed ushort maximum_lba_for_48bit_addressing[4];   ///< word 100~103
  public ushort streaming_transfer_time_for_pio;
  public ushort max_no_of_512byte_blocks_per_data_set_cmd;
  public ushort phy_logic_sector_support;              ///< word 106
  public ushort interseek_delay_for_iso7779;
  public fixed ushort world_wide_name[4];                    ///< word 108~111
  public fixed ushort reserved_for_128bit_wwn_112_115[4];
  public ushort reserved_for_technical_report;
  public ushort logic_sector_size_lo;                    ///< word 117
  public ushort logic_sector_size_hi;                    ///< word 118
  public ushort features_and_command_sets_supported_ext; ///< word 119
  public ushort features_and_command_sets_enabled_ext;   ///< word 120
  public fixed ushort reserved_121_126[6];
  public ushort obsolete_127;
  public ushort security_status;                       ///< word 128
  public fixed ushort vendor_specific_129_159[31];
  public ushort cfa_power_mode;                        ///< word 160
  public fixed ushort reserved_for_compactflash_161_167[7];
  public ushort device_nominal_form_factor;
  public ushort is_data_set_cmd_supported;
  public fixed byte additional_product_identifier[8];
  public fixed ushort reserved_174_175[2];
  public fixed byte media_serial_number[60];               ///< word 176~205
  public ushort sct_command_transport;                 ///< word 206
  public fixed ushort reserved_207_208[2];
  public ushort alignment_logic_in_phy_blocks;           ///< word 209
  public fixed ushort write_read_verify_sector_count_mode3[2]; ///< word 210~211
  public fixed ushort verify_sector_count_mode2[2];
  public ushort nv_cache_capabilities;
  public ushort nv_cache_size_in_logical_block_lsw;    ///< word 215
  public ushort nv_cache_size_in_logical_block_msw;    ///< word 216
  public ushort nominal_media_rotation_rate;
  public ushort reserved_218;
  public ushort nv_cache_options;                      ///< word 219
  public ushort write_read_verify_mode;                ///< word 220
  public ushort reserved_221;
  public ushort transport_major_revision_number;
  public ushort transport_minor_revision_number;
  public fixed ushort reserved_224_229[6];
  public ulong extended_no_of_addressable_sectors;
  public ushort min_number_per_download_microcode_mode3; ///< word 234
  public ushort max_number_per_download_microcode_mode3; ///< word 235
  public fixed ushort reserved_236_254[19];
  public ushort integrity_word;
}

///
/// ATAPI_IDENTIFY_DATA strictly complies with ATA/ATAPI-8 Spec
/// to define the data returned by an ATAPI device upon successful
/// completion of the ATA IDENTIFY_PACKET_DEVICE command.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct ATAPI_IDENTIFY_DATA
{
  public ushort config;                                ///< General Configuration.
  public ushort reserved_1;
  public ushort specific_config;                       ///< Specific Configuration.
  public fixed ushort reserved_3_9[7];
  public fixed byte SerialNo[20];                          ///< word 10~19
  public fixed ushort reserved_20_22[3];
  public fixed byte FirmwareVer[8];                        ///< word 23~26
  public fixed byte ModelName[40];                         ///< word 27~46
  public fixed ushort reserved_47_48[2];
  public ushort capabilities_49;
  public ushort capabilities_50;
  public ushort obsolete_51;
  public ushort reserved_52;
  public ushort field_validity;                        ///< word 53
  public fixed ushort reserved_54_61[8];
  public ushort dma_dir;
  public ushort multi_word_dma_mode;                   ///< word 63
  public ushort advanced_pio_modes;                    ///< word 64
  public ushort min_multi_word_dma_cycle_time;
  public ushort rec_multi_word_dma_cycle_time;
  public ushort min_pio_cycle_time_without_flow_control;
  public ushort min_pio_cycle_time_with_flow_control;
  public fixed ushort reserved_69_70[2];
  public fixed ushort obsolete_71_72[2];
  public fixed ushort reserved_73_74[2];
  public ushort obsolete_75;
  public ushort serial_ata_capabilities;
  public ushort reserved_77;                           ///< Reserved for Serial ATA
  public ushort serial_ata_features_supported;
  public ushort serial_ata_features_enabled;
  public ushort major_version_no;                      ///< word 80
  public ushort minor_version_no;                      ///< word 81
  public ushort cmd_set_support_82;
  public ushort cmd_set_support_83;
  public ushort cmd_feature_support;
  public ushort cmd_feature_enable_85;
  public ushort cmd_feature_enable_86;
  public ushort cmd_feature_default;
  public ushort ultra_dma_select;
  public ushort time_required_for_sec_erase;           ///< word 89
  public ushort time_required_for_enhanced_sec_erase;  ///< word 90
  public ushort advanced_power_management_level;
  public ushort master_pwd_revison_code;
  public ushort hardware_reset_result;                 ///< word 93
  public ushort obsolete_94;
  public fixed ushort reserved_95_107[13];
  public fixed ushort world_wide_name[4];                    ///< word 108~111
  public fixed ushort reserved_for_128bit_wwn_112_115[4];
  public fixed ushort reserved_116_118[3];
  public ushort command_and_feature_sets_supported;    ///< word 119
  public ushort command_and_feature_sets_supported_enabled;
  public fixed ushort reserved_121_124[4];
  public ushort atapi_byte_count_0_behavior;           ///< word 125
  public fixed ushort obsolete_126_127[2];
  public ushort security_status;
  public fixed ushort reserved_129_159[31];
  public fixed ushort cfa_reserved_160_175[16];
  public fixed ushort reserved_176_221[46];
  public ushort transport_major_version;
  public ushort transport_minor_version;
  public fixed ushort reserved_224_254[31];
  public ushort integrity_word;
}

///
/// Standard Quiry Data format, defined in SFF-8070i(ATAPI Removable Rewritable Specification).
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct ATAPI_INQUIRY_DATA
{
  public byte peripheral_type;
  public byte RMB;
  public byte version;
  public byte response_data_format;
  public byte addnl_length;  ///< n - 4, Numbers of bytes following this one.
  public byte reserved_5;
  public byte reserved_6;
  public byte reserved_7;
  public fixed byte vendor_info[8];
  public fixed byte product_id[16];
  public fixed byte product_revision_level[4];
  public fixed byte vendor_specific_36_55[55 - 36 + 1];
  public fixed byte reserved_56_95[95 - 56 + 1];
  ///
  /// Vendor-specific parameters fields. The sizeof (ATAPI_INQUIRY_DATA) is 254
  /// since allocation_length is one byte in ATAPI_INQUIRY_CMD.
  ///
  public fixed byte vendor_specific_96_253[253 - 96 + 1];
}

///
/// Request Sense Standard Data, defined in SFF-8070i(ATAPI Removable Rewritable Specification).
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct ATAPI_REQUEST_SENSE_DATA
{
  public byte error_code; // = 7;
  public byte valid; // = 1;
  public byte reserved_1;
  public byte sense_key; // = 4;
  public byte reserved_2; // = 1;
  public byte Vendor_specifc_1; // = 3;
  public byte vendor_specific_3;
  public byte vendor_specific_4;
  public byte vendor_specific_5;
  public byte vendor_specific_6;
  public byte addnl_sense_length;        ///< n - 7
  public byte vendor_specific_8;
  public byte vendor_specific_9;
  public byte vendor_specific_10;
  public byte vendor_specific_11;
  public byte addnl_sense_code;            ///< mandatory
  public byte addnl_sense_code_qualifier;  ///< mandatory
  public byte field_replaceable_unit_code; ///< optional
  public byte sense_key_specific_15; // = 7;
  public byte SKSV; // = 1;
  public byte sense_key_specific_16;
  public byte sense_key_specific_17;
}

///
/// READ CAPACITY Data, defined in SFF-8070i(ATAPI Removable Rewritable Specification).
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct ATAPI_READ_CAPACITY_DATA
{
  public byte LastLba3;
  public byte LastLba2;
  public byte LastLba1;
  public byte LastLba0;
  public byte BlockSize3;
  public byte BlockSize2;
  public byte BlockSize1;
  public byte BlockSize0;
}

///
/// Capacity List Header + Current/Maximum Capacity Descriptor,
/// defined in SFF-8070i(ATAPI Removable Rewritable Specification).
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct ATAPI_READ_FORMAT_CAPACITY_DATA
{
  public byte reserved_0;
  public byte reserved_1;
  public byte reserved_2;
  public byte Capacity_Length;
  public byte LastLba3;
  public byte LastLba2;
  public byte LastLba1;
  public byte LastLba0;
  public byte DesCode; // = 2;
  public byte reserved_9; // = 6;
  public byte BlockSize2;
  public byte BlockSize1;
  public byte BlockSize0;
}

///
/// Test Unit Ready Command, defined in SFF-8070i(ATAPI Removable Rewritable Specification).
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct ATAPI_TEST_UNIT_READY_CMD
{
  public byte opcode;
  public byte reserved_1;
  public byte reserved_2;
  public byte reserved_3;
  public byte reserved_4;
  public byte reserved_5;
  public byte reserved_6;
  public byte reserved_7;
  public byte reserved_8;
  public byte reserved_9;
  public byte reserved_10;
  public byte reserved_11;
}

///
/// INQUIRY Command, defined in SFF-8070i(ATAPI Removable Rewritable Specification).
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct ATAPI_INQUIRY_CMD
{
  public byte opcode;
  public byte reserved_1; // = 5;
  public byte lun; // = 3;
  public byte page_code;     ///< defined in SFF8090i, V6
  public byte reserved_3;
  public byte allocation_length;
  public byte reserved_5;
  public byte reserved_6;
  public byte reserved_7;
  public byte reserved_8;
  public byte reserved_9;
  public byte reserved_10;
  public byte reserved_11;
}

///
/// REQUEST SENSE Command, defined in SFF-8070i(ATAPI Removable Rewritable Specification).
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct ATAPI_REQUEST_SENSE_CMD
{
  public byte opcode;
  public byte reserved_1; // = 5;
  public byte lun; // = 3;
  public byte reserved_2;
  public byte reserved_3;
  public byte allocation_length;
  public byte reserved_5;
  public byte reserved_6;
  public byte reserved_7;
  public byte reserved_8;
  public byte reserved_9;
  public byte reserved_10;
  public byte reserved_11;
}

///
/// READ (10) Command, defined in SFF-8070i(ATAPI Removable Rewritable Specification).
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct ATAPI_READ10_CMD
{
  public byte opcode;
  public byte reserved_1; // = 5;
  public byte lun; // = 3;
  public byte Lba0;
  public byte Lba1;
  public byte Lba2;
  public byte Lba3;
  public byte reserved_6;
  public byte TranLen0;
  public byte TranLen1;
  public byte reserved_9;
  public byte reserved_10;
  public byte reserved_11;
}

///
/// READ Format Capacity Command, defined in SFF-8070i(ATAPI Removable Rewritable Specification).
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct ATAPI_READ_FORMAT_CAP_CMD
{
  public byte opcode;
  public byte reserved_1; // = 5;
  public byte lun; // = 3;
  public byte reserved_2;
  public byte reserved_3;
  public byte reserved_4;
  public byte reserved_5;
  public byte reserved_6;
  public byte allocation_length_hi;
  public byte allocation_length_lo;
  public byte reserved_9;
  public byte reserved_10;
  public byte reserved_11;
}

///
/// MODE SENSE Command, defined in SFF-8070i(ATAPI Removable Rewritable Specification).
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct ATAPI_MODE_SENSE_CMD
{
  public byte opcode;
  public byte reserved_1; // = 5;
  public byte lun; // = 3;
  public byte page_code; // = 6;
  public byte page_control; // = 2;
  public byte reserved_3;
  public byte reserved_4;
  public byte reserved_5;
  public byte reserved_6;
  public byte parameter_list_length_hi;
  public byte parameter_list_length_lo;
  public byte reserved_9;
  public byte reserved_10;
  public byte reserved_11;
}

///
/// ATAPI_PACKET_COMMAND is not defined in the ATA specification.
/// We add it here for the convenience of ATA/ATAPI module writers.
///
[StructLayout(LayoutKind.Explicit)]
public unsafe struct ATAPI_PACKET_COMMAND
{
  [FieldOffset(0)] public fixed ushort Data16[6];
  [FieldOffset(0)] public ATAPI_TEST_UNIT_READY_CMD TestUnitReady;
  [FieldOffset(0)] public ATAPI_READ10_CMD Read10;
  [FieldOffset(0)] public ATAPI_REQUEST_SENSE_CMD RequestSence;
  [FieldOffset(0)] public ATAPI_INQUIRY_CMD Inquiry;
  [FieldOffset(0)] public ATAPI_MODE_SENSE_CMD ModeSense;
  [FieldOffset(0)] public ATAPI_READ_FORMAT_CAP_CMD ReadFormatCapacity;
}

// #pragma pack()

public unsafe partial class EFI
{
  public const ulong ATAPI_MAX_DMA_EXT_CMD_SECTORS = 0x10000;
  public const ulong ATAPI_MAX_DMA_CMD_SECTORS = 0x100;

  //  ATA/ATAPI Signature equates
  public const ulong ATA_SIGNATURE = 0x0101; /// < defined in ACS-3
  public const ulong ATAPI_SIGNATURE = 0xeb14; /// < defined in ACS-3
  public const ulong ATAPI_SIGNATURE_32 = 0xeb140101; /// < defined in ACS-3

  //  Spin Up Configuration definitions
  public const ulong ATA_SPINUP_CFG_REQUIRED_IDD_INCOMPLETE = 0x37c8; /// < defined in ACS-3
  public const ulong ATA_SPINUP_CFG_REQUIRED_IDD_COMPLETE = 0x738c; /// < defined in ACS-3
  public const ulong ATA_SPINUP_CFG_NOT_REQUIRED_IDD_INCOMPLETE = 0x8c73; /// < defined in ACS-3
  public const ulong ATA_SPINUP_CFG_NOT_REQUIRED_IDD_COMPLETE = 0xc837; /// < defined in ACS-3

  //
  // ATA Packet Command Code
  //
  public const ulong ATA_CMD_FORMAT_UNIT = 0x04; /// < defined in ATAPI Removable Rewritable Media Devices
  public const ulong ATA_CMD_SOFT_RESET = 0x08; /// < defined from ATA-3
  public const ulong ATA_CMD_PACKET = 0xA0; /// < defined from ATA-3
  public const ulong ATA_CMD_IDENTIFY_DEVICE = 0xA1; /// < defined from ATA-3
  public const ulong ATA_CMD_SERVICE = 0xA2; /// < defined from ATA-3
  public const ulong ATA_CMD_TEST_UNIT_READY = 0x00; /// < defined from ATA-1
  public const ulong ATA_CMD_REQUEST_SENSE = 0x03; /// < defined from ATA-4
  public const ulong ATA_CMD_INQUIRY = 0x12; /// < defined in ATAPI Removable Rewritable Media Devices
  public const ulong ATA_CMD_READ_FORMAT_CAPACITY = 0x23; /// < defined in ATAPI Removable Rewritable Media Devices
  public const ulong ATA_CMD_READ_CAPACITY = 0x25; /// < defined in ATAPI Removable Rewritable Media Devices
  public const ulong ATA_CMD_READ_10 = 0x28; /// < defined in ATAPI Removable Rewritable Media Devices
  public const ulong ATA_CMD_WRITE_10 = 0x2A; /// < defined in ATAPI Removable Rewritable Media Devices
  public const ulong ATA_CMD_ATAPI_SEEK = 0x2B; /// < defined in ATAPI Removable Rewritable Media Devices
  public const ulong ATA_CMD_WRITE_AND_VERIFY = 0x2E; /// < defined in ATAPI Removable Rewritable Media Devices
  public const ulong ATA_CMD_VERIFY = 0x2F; /// < defined in ATAPI Removable Rewritable Media Devices
  public const ulong ATA_CMD_READ_12 = 0xA8; /// < defined in ATAPI Removable Rewritable Media Devices
  public const ulong ATA_CMD_WRITE_12 = 0xAA; /// < defined in ATAPI Removable Rewritable Media Devices
  public const ulong ATA_CMD_START_STOP_UNIT = 0x1B; /// < defined in ATAPI Removable Rewritable Media Devices
  public const ulong ATA_CMD_PREVENT_ALLOW_MEDIA_REMOVAL = 0x1E; /// < defined in ATAPI Removable Rewritable Media Devices
  public const ulong ATA_CMD_MODE_SELECT = 0x55; /// < defined in ATAPI Removable Rewritable Media Devices

  public const ulong ATA_CMD_MODE_SENSE = 0x5A; /// < defined in ATAPI Removable Rewritable Media Devices
  public const ulong ATA_PAGE_CODE_READ_WRITE_ERROR = 0x01; /// < defined in ATAPI Removable Rewritable Media Devices
  public const ulong ATA_PAGE_CODE_CACHING_PAGE = 0x08; /// < defined in ATAPI Removable Rewritable Media Devices
  public const ulong ATA_PAGE_CODE_REMOVABLE_BLOCK_CAPABILITIES = 0x1B; /// < defined in ATAPI Removable Rewritable Media Devices
  public const ulong ATA_PAGE_CODE_TIMER_PROTECT_PAGE = 0x1C; /// < defined in ATAPI Removable Rewritable Media Devices
  public const ulong ATA_PAGE_CODE_RETURN_ALL_PAGES = 0x3F; /// < defined in ATAPI Removable Rewritable Media Devices

  public const ulong ATA_CMD_GET_CONFIGURATION = 0x46; /// < defined in ATAPI Multimedia Devices
  public const ulong ATA_GCCD_RT_FIELD_VALUE_ALL = 0x00; /// < defined in ATAPI Multimedia Devices
  public const ulong ATA_GCCD_RT_FIELD_VALUE_CURRENT = 0x01; /// < defined in ATAPI Multimedia Devices
  public const ulong ATA_GCCD_RT_FIELD_VALUE_SINGLE = 0x02; /// < defined in ATAPI Multimedia Devices
  public const ulong ATA_GCCD_RT_FIELD_VALUE_RESERVED = 0x03; /// < defined in ATAPI Multimedia Devices

  public const ulong ATA_FEATURE_LIST_PROFILE_LIST = 0x0000; /// < defined in ATAPI Multimedia Devices
  public const ulong ATA_FEATURE_LIST_CORE = 0x0001; /// < defined in ATAPI Multimedia Devices
  public const ulong ATA_FEATURE_LIST_MORPHING = 0x0002; /// < defined in ATAPI Multimedia Devices
  public const ulong ATA_FEATURE_LIST_REMOVEABLE_MEDIUM = 0x0003; /// < defined in ATAPI Multimedia Devices
  public const ulong ATA_FEATURE_LIST_WRITE_PROTECT = 0x0004; /// < defined in ATAPI Multimedia Devices

                                                              ///
                                                              /// Start/Stop and Eject Operations
                                                              ///
                                                              ///@{
  public const ulong ATA_CMD_SUBOP_STOP_DISC = 0x00; /// < Stop the Disc
  public const ulong ATA_CMD_SUBOP_START_DISC = 0x01; /// < Start the Disc and acquire the format type
  public const ulong ATA_CMD_SUBOP_EJECT_DISC = 0x02; /// < Eject the Disc if possible
  public const ulong ATA_CMD_SUBOP_CLOSE_TRAY = 0x03; /// < Load the Disc (Close Tray)
                                                      ///@}

  //
  // ATA Commands Code
  //

  //
  // Class 1: PIO Data-In Commands
  //
  public const ulong ATA_CMD_IDENTIFY_DRIVE = 0xec; /// < defined from ATA-3
  public const ulong ATA_CMD_READ_BUFFER = 0xe4; /// < defined from ATA-1
  public const ulong ATA_CMD_READ_SECTORS = 0x20; /// < defined from ATA-1
  public const ulong ATA_CMD_READ_SECTORS_WITH_RETRY = 0x21; /// < defined from ATA-1, obsoleted from ATA-5
  public const ulong ATA_CMD_READ_LONG = 0x22; /// < defined from ATA-1, obsoleted from ATA-5
  public const ulong ATA_CMD_READ_LONG_WITH_RETRY = 0x23; /// < defined from ATA-1, obsoleted from ATA-5
  public const ulong ATA_CMD_READ_SECTORS_EXT = 0x24; /// < defined from ATA-6
  public const ulong ATA_CMD_READ_MULTIPLE = 0xc4; /// < defined in ACS-3
  public const ulong ATA_CMD_READ_MULTIPLE_EXT = 0x29; /// < defined in ACS-3
  public const ulong ATA_CMD_READ_LOG_EXT = 0x2f; /// < defined in ACS-3

  //
  // Class 2: PIO Data-Out Commands
  //
  public const ulong ATA_CMD_FORMAT_TRACK = 0x50; /// < defined from ATA-1, obsoleted from ATA-4
  public const ulong ATA_CMD_WRITE_BUFFER = 0xe8; /// < defined from ATA-1
  public const ulong ATA_CMD_WRITE_SECTORS = 0x30; /// < defined from ATA-1
  public const ulong ATA_CMD_WRITE_SECTORS_WITH_RETRY = 0x31; /// < defined from ATA-1, obsoleted from ATA-5
  public const ulong ATA_CMD_WRITE_LONG = 0x32; /// < defined from ATA-1, obsoleted from ATA-5
  public const ulong ATA_CMD_WRITE_LONG_WITH_RETRY = 0x33; /// < defined from ATA-1, obsoleted from ATA-5
  public const ulong ATA_CMD_WRITE_VERIFY = 0x3c; /// < defined from ATA-1, obsoleted from ATA-5
  public const ulong ATA_CMD_WRITE_SECTORS_EXT = 0x34; /// < defined from ATA-6
  public const ulong ATA_CMD_WRITE_MULTIPLE = 0xc5; /// < defined in ACS-3
  public const ulong ATA_CMD_WRITE_MULTIPLE_EXT = 0x39; /// < defined in ACS-3

  //
  // Class 3 No Data Command
  //
  public const ulong ATA_CMD_ACK_MEDIA_CHANGE = 0xdb; /// < defined from ATA-1, obsoleted from ATA-5
  public const ulong ATA_CMD_BOOT_POST_BOOT = 0xdc; /// < defined from ATA-1, obsoleted from ATA-3
  public const ulong ATA_CMD_BOOT_PRE_BOOT = 0xdd; /// < defined from ATA-1, obsoleted from ATA-3
  public const ulong ATA_CMD_CHECK_POWER_MODE = 0x98; /// < defined from ATA-1, obsoleted from ATA-4
  public const ulong ATA_CMD_CHECK_POWER_MODE_ALIAS = 0xe5; /// < defined from ATA-1
  public const ulong ATA_CMD_DOOR_LOCK = 0xde; /// < defined from ATA-1
  public const ulong ATA_CMD_DOOR_UNLOCK = 0xdf; /// < defined from ATA-1
  public const ulong ATA_CMD_EXEC_DRIVE_DIAG = 0x90; /// < defined from ATA-1
  public const ulong ATA_CMD_IDLE_ALIAS = 0x97; /// < defined from ATA-1, obsoleted from ATA-4
  public const ulong ATA_CMD_IDLE = 0xe3; /// < defined from ATA-1
  public const ulong ATA_CMD_IDLE_IMMEDIATE = 0x95; /// < defined from ATA-1, obsoleted from ATA-4
  public const ulong ATA_CMD_IDLE_IMMEDIATE_ALIAS = 0xe1; /// < defined from ATA-1
  public const ulong ATA_CMD_INIT_DRIVE_PARAM = 0x91; /// < defined from ATA-1, obsoleted from ATA-6
  public const ulong ATA_CMD_RECALIBRATE = 0x10; /// < defined from ATA-1, obsoleted from ATA-4
  public const ulong ATA_CMD_READ_DRIVE_STATE = 0xe9; /// < defined from ATA-1, obsoleted from ATA-3
  public const ulong ATA_CMD_SET_MULTIPLE_MODE = 0xC6; /// < defined from ATA-2
  public const ulong ATA_CMD_READ_VERIFY = 0x40; /// < defined from ATA-1
  public const ulong ATA_CMD_READ_VERIFY_WITH_RETRY = 0x41; /// < defined from ATA-1, obsoleted from ATA-5
  public const ulong ATA_CMD_SEEK = 0x70; /// < defined from ATA-1
  public const ulong ATA_CMD_SET_FEATURES = 0xef; /// < defined from ATA-1
  public const ulong ATA_CMD_STANDBY = 0x96; /// < defined from ATA-1, obsoleted from ATA-4
  public const ulong ATA_CMD_STANDBY_ALIAS = 0xe2; /// < defined from ATA-1
  public const ulong ATA_CMD_STANDBY_IMMEDIATE = 0x94; /// < defined from ATA-1, obsoleted from ATA-4
  public const ulong ATA_CMD_STANDBY_IMMEDIATE_ALIAS = 0xe0; /// < defined from ATA-1
  public const ulong ATA_CMD_SLEEP = 0xe6; /// < defined in ACS-3
  public const ulong ATA_CMD_READ_NATIVE_MAX_ADDRESS = 0xf8; /// < defined in ATA-6
  public const ulong ATA_CMD_READ_NATIVE_MAX_ADDRESS_EXT = 0x27; /// < defined in ATA-6

  //
  // Set Features Sub Command
  //
  public const ulong ATA_SUB_CMD_ENABLE_VOLATILE_WRITE_CACHE = 0x02; /// < defined in ACS-3
  public const ulong ATA_SUB_CMD_SET_TRANSFER_MODE = 0x03; /// < defined in ACS-3
  public const ulong ATA_SUB_CMD_ENABLE_APM = 0x05; /// < defined in ACS-3
  public const ulong ATA_SUB_CMD_ENABLE_PUIS = 0x06; /// < defined in ACS-3
  public const ulong ATA_SUB_CMD_PUIS_SET_DEVICE_SPINUP = 0x07; /// < defined in ACS-3
  public const ulong ATA_SUB_CMD_ENABLE_WRITE_READ_VERIFY = 0x0b; /// < defined in ACS-3
  public const ulong ATA_SUB_CMD_ENABLE_SATA_FEATURE = 0x10; /// < defined in ACS-3
  public const ulong ATA_SUB_CMD_DISABLE_MEDIA_STATUS_NOTIFICATION = 0x31; /// < defined in ACS-3
  public const ulong ATA_SUB_CMD_ENABLE_FREE_FALL_CONTROL = 0x41; /// < defined in ACS-3
  public const ulong ATA_SUB_CMD_ACOUSTIC_MANAGEMENT_ENABLE = 0x42; /// < defined in ACS-3
  public const ulong ATA_SUB_CMD_SET_MAX_HOST_INTERFACE_SECTOR_TIMES = 0x43; /// < defined in ACS-3
  public const ulong ATA_SUB_CMD_EXTENDED_POWER_CONDITIONS = 0x4a; /// < defined in ACS-3
  public const ulong ATA_SUB_CMD_DISABLE_READ_LOOK_AHEAD = 0x55; /// < defined in ACS-3
  public const ulong ATA_SUB_CMD_EN_DIS_DSN_FEATURE = 0x63; /// < defined in ACS-3
  public const ulong ATA_SUB_CMD_DISABLE_REVERT_TO_POWER_ON_DEFAULTS = 0x66; /// < defined in ACS-3
  public const ulong ATA_SUB_CMD_DISABLE_VOLATILE_WRITE_CACHE = 0x82; /// < defined in ACS-3
  public const ulong ATA_SUB_CMD_DISABLE_APM = 0x85; /// < defined in ACS-3
  public const ulong ATA_SUB_CMD_DISABLE_PUIS = 0x86; /// < defined in ACS-3
  public const ulong ATA_SUB_CMD_DISABLE_WRITE_READ_VERIFY = 0x8b; /// < defined in ACS-3
  public const ulong ATA_SUB_CMD_DISABLE_SATA_FEATURE = 0x90; /// < defined in ACS-3
  public const ulong ATA_SUB_CMD_ENABLE_MEDIA_STATUS_NOTIFICATION = 0x95; /// < defined in ACS-3
  public const ulong ATA_SUB_CMD_ENABLE_READ_LOOK_AHEAD = 0xaa; /// < defined in ACS-3
  public const ulong ATA_SUB_CMD_DISABLE_FREE_FALL_CONTROL = 0xc1; /// < defined in ACS-3
  public const ulong ATA_SUB_CMD_ACOUSTIC_MANAGEMENT_DISABLE = 0xc2; /// < defined in ACS-3
  public const ulong ATA_SUB_CMD_EN_DIS_SENSE_DATA_REPORTING = 0xc3; /// < defined in ACS-3
  public const ulong ATA_SUB_CMD_ENABLE_REVERT_TO_POWER_ON_DEFAULTS = 0xcc; /// < defined in ACS-3

  //
  // S.M.A.R.T
  //
  public const ulong ATA_CMD_SMART = 0xb0; /// < defined from ATA-3
  public const ulong ATA_CONSTANT_C2 = 0xc2; /// < reserved
  public const ulong ATA_CONSTANT_4F = 0x4f; /// < reserved

  public const ulong ATA_SMART_READ_DATA = 0xd0; /// < defined in ACS-3

  public const ulong ATA_SMART_AUTOSAVE = 0xd2; /// < defined in ACS-3
  public const ulong ATA_AUTOSAVE_DISABLE_ATTR = 0x00;
  public const ulong ATA_AUTOSAVE_ENABLE_ATTR = 0xf1;

  public const ulong ATA_SMART_EXECUTE_OFFLINE_IMMEDIATE = 0xd4; /// < defined in ACS-3
  public const ulong ATA_EXECUTE_SMART_OFFLINE_ROUTINE = 0x00; /// < defined in ACS-3
  public const ulong ATA_EXECUTE_SMART_OFFLINE_SHORT_SELFTEST = 0x01; /// < defined in ACS-3
  public const ulong ATA_EXECUTE_SMART_OFFLINE_EXTENDED_SELFTEST = 0x02; /// < defined in ACS-3
  public const ulong ATA_EXECUTE_SMART_OFFLINE_CONVEYANCE_SELFTEST = 0x03; /// < defined in ACS-3
  public const ulong ATA_EXECUTE_SMART_OFFLINE_SELECTIVE_SELFTEST = 0x04; /// < defined in ACS-3
  public const ulong ATA_SMART_ABORT_SELF_TEST_SUBROUTINE = 0x7f; /// < defined in ACS-3
  public const ulong ATA_EXECUTE_SMART_CAPTIVE_SHORT_SELFTEST = 0x81; /// < defined in ACS-3
  public const ulong ATA_EXECUTE_SMART_CAPTIVE_EXTENDED_SELFTEST = 0x82; /// < defined in ACS-3
  public const ulong ATA_EXECUTE_SMART_CAPTIVE_CONVEYANCE_SELFTEST = 0x83; /// < defined in ACS-3
  public const ulong ATA_EXECUTE_SMART_CAPTIVE_SELECTIVE_SELFTEST = 0x84; /// < defined in ACS-3

  public const ulong ATA_SMART_READLOG = 0xd5; /// < defined in ACS-3
  public const ulong ATA_SMART_WRITELOG = 0xd6; /// < defined in ACS-3
  public const ulong ATA_SMART_ENABLE_OPERATION = 0xd8; /// < reserved
  public const ulong ATA_SMART_DISABLE_OPERATION = 0xd9; /// < defined in ACS-3
  public const ulong ATA_SMART_RETURN_STATUS = 0xda; /// < defined from ATA-3

  public const ulong ATA_SMART_THRESHOLD_NOT_EXCEEDED_VALUE = 0xc24f; /// < defined in ACS-3
  public const ulong ATA_SMART_THRESHOLD_EXCEEDED_VALUE = 0x2cf4; /// < defined in ACS-3

  // SMART Log Definitions
  public const ulong ATA_SMART_LOG_DIRECTORY = 0x00; /// < defined in ACS-3
  public const ulong ATA_SMART_SUM_SMART_ERROR_LOG = 0x01; /// < defined in ACS-3
  public const ulong ATA_SMART_COMP_SMART_ERROR_LOG = 0x02; /// < defined in ACS-3
  public const ulong ATA_SMART_EXT_COMP_SMART_ERROR_LOG = 0x03; /// < defined in ACS-3
  public const ulong ATA_SMART_SMART_SELFTEST_LOG = 0x06; /// < defined in ACS-3
  public const ulong ATA_SMART_EXT_SMART_SELFTEST_LOG = 0x07; /// < defined in ACS-3
  public const ulong ATA_SMART_SELECTIVE_SELFTEST_LOG = 0x09; /// < defined in ACS-3
  public const ulong ATA_SMART_HOST_VENDOR_SPECIFIC = 0x80; /// < defined in ACS-3
  public const ulong ATA_SMART_DEVICE_VENDOR_SPECIFIC = 0xa0; /// < defined in ACS-3

  //
  // Class 4: DMA Command
  //
  public const ulong ATA_CMD_READ_DMA = 0xc8; /// < defined from ATA-1
  public const ulong ATA_CMD_READ_DMA_WITH_RETRY = 0xc9; /// < defined from ATA-1, obsoleted from ATA-5
  public const ulong ATA_CMD_READ_DMA_EXT = 0x25; /// < defined from ATA-6
  public const ulong ATA_CMD_WRITE_DMA = 0xca; /// < defined from ATA-1
  public const ulong ATA_CMD_WRITE_DMA_WITH_RETRY = 0xcb; /// < defined from ATA-1, obsoleted from ATA-
  public const ulong ATA_CMD_WRITE_DMA_EXT = 0x35; /// < defined from ATA-6

  //
  //  ATA Security commands
  //
  public const ulong ATA_CMD_SECURITY_SET_PASSWORD = 0xf1; /// < defined in ACS-3
  public const ulong ATA_CMD_SECURITY_UNLOCK = 0xf2; /// < defined in ACS-3
  public const ulong ATA_CMD_SECURITY_ERASE_PREPARE = 0xf3; /// < defined in ACS-3
  public const ulong ATA_CMD_SECURITY_ERASE_UNIT = 0xf4; /// < defined in ACS-3
  public const ulong ATA_CMD_SECURITY_FREEZE_LOCK = 0xf5; /// < defined in ACS-3
  public const ulong ATA_CMD_SECURITY_DISABLE_PASSWORD = 0xf6; /// < defined in ACS-3

  public const ulong ATA_SECURITY_BUFFER_LENGTH = 512; /// < defined in ACS-3

  //
  //  ATA Device Config Overlay
  //
  public const ulong ATA_CMD_DEV_CONFIG_OVERLAY = 0xb1; /// < defined from ATA-6
  public const ulong ATA_CMD_DEV_CONFIG_RESTORE_FEATURE = 0xc0; /// < defined from ATA-6
  public const ulong ATA_CMD_DEV_CONFIG_FREEZELOCK_FEATURE = 0xc1; /// < defined from ATA-6
  public const ulong ATA_CMD_DEV_CONFIG_IDENTIFY_FEATURE = 0xc2; /// < defined from ATA-6
  public const ulong ATA_CMD_DEV_CONFIG_SET_FEATURE = 0xc3; /// < defined from ATA-6

  //
  //  ATA Trusted Computing Feature Set Commands
  //
  public const ulong ATA_CMD_TRUSTED_NON_DATA = 0x5b; /// < defined in ACS-3
  public const ulong ATA_CMD_TRUSTED_RECEIVE = 0x5c; /// < defined in ACS-3
  public const ulong ATA_CMD_TRUSTED_RECEIVE_DMA = 0x5d; /// < defined in ACS-3
  public const ulong ATA_CMD_TRUSTED_SEND = 0x5e; /// < defined in ACS-3
  public const ulong ATA_CMD_TRUSTED_SEND_DMA = 0x5f; /// < defined in ACS-3

  //
  //  ATA Trusted Receive Fields
  //
  public const ulong ATA_TR_RETURN_SECURITY_PROTOCOL_INFORMATION = 0x00; /// < defined in ACS-3
  public const ulong ATA_TR_SECURITY_PROTOCOL_JEDEC_RESERVED = 0xec; /// < defined in ACS-3
  public const ulong ATA_TR_SECURITY_PROTOCOL_SDCARD_RESERVED = 0xed; /// < defined in ACS-3
  public const ulong ATA_TR_SECURITY_PROTOCOL_IEEE1667_RESERVED = 0xee; /// < defined in ACS-3

  //
  //  Equates used for Acoustic Flags
  //
  public const ulong ATA_ACOUSTIC_LEVEL_BYPASS = 0xff; /// < defined from ATA-6
  public const ulong ATA_ACOUSTIC_LEVEL_MAXIMUM_PERFORMANCE = 0xfe; /// < defined from ATA-6
  public const ulong ATA_ACOUSTIC_LEVEL_QUIET = 0x80; /// < defined from ATA-6

  //
  //  Equates used for DiPM Support
  //
  public const ulong ATA_CMD_DIPM_SUB = 0x03; //  defined in ACS-3 : Count value in SetFeature identification : 03h  Device-initiated interface power state transitions
  public const ulong ATA_DIPM_ENABLE = 0x10; //  defined in ACS-3
  public const ulong ATA_DIPM_DISABLE = 0x90; //  defined in ACS-3

  //
  //  Equates used for DevSleep Support
  //
  public const ulong ATA_CMD_DEVSLEEP_SUB = 0x09; //  defined in SATA 3.2 Gold Spec :  Count value in SetFeature identification : 09h  Device Sleep
  public const ulong ATA_DEVSLEEP_ENABLE = 0x10; //  defined in SATA 3.2 Gold Spec
  public const ulong ATA_DEVSLEEP_DISABLE = 0x90; //  defined in SATA 3.2 Gold Spec

  public const ulong ATA_DEVSLP_EXIT_TIMEOUT = 20; //  MDAT - 20 ms
  public const ulong ATA_DEVSLP_MINIMUM_DETECTION_TIME = 10; //  DMDT - 10 us
  public const ulong ATA_DEVSLP_MINIMUM_ASSERTION_TIME = 10; //  DETO - 10 ms

  //
  //  Set MAX Commands
  //
  public const ulong ATA_CMD_SET_MAX_ADDRESS_EXT = 0x37; /// < defined from ATA-6
  public const ulong ATA_CMD_SET_MAX_ADDRESS = 0xf9; /// < defined from ATA-6
  public const ulong ATA_SET_MAX_SET_PASSWORD = 0x01; /// < defined from ATA-6
  public const ulong ATA_SET_MAX_LOCK = 0x02; /// < defined from ATA-6
  public const ulong ATA_SET_MAX_UNLOCK = 0x03; /// < defined from ATA-6
  public const ulong ATA_SET_MAX_FREEZE_LOCK = 0x04; /// < defined from ATA-6

                                                     ///
                                                     /// Default content of device control register, disable INT,
                                                     /// Bit3 is set to 1 according ATA-1
                                                     ///
  public const ulong ATA_DEFAULT_CTL = (0x0a);
  ///
  /// Default context of Device/Head Register,
  /// Bit7 and Bit5 are set to 1 for back-compatibilities.
  ///
  public const ulong ATA_DEFAULT_CMD = (0xa0);

  public const ulong ATAPI_MAX_BYTE_COUNT = (0xfffe);

  public const ulong ATA_REQUEST_SENSE_ERROR = (0x70); /// < defined in SFF-8070i

  //
  // Sense Key, Additional Sense Codes and Additional Sense Code Qualifier
  // defined in MultiMedia Commands (MMC, MMC-2)
  //
  // Sense Key
  //
  public const ulong ATA_SK_NO_SENSE = (0x0);
  public const ulong ATA_SK_RECOVERY_ERROR = (0x1);
  public const ulong ATA_SK_NOT_READY = (0x2);
  public const ulong ATA_SK_MEDIUM_ERROR = (0x3);
  public const ulong ATA_SK_HARDWARE_ERROR = (0x4);
  public const ulong ATA_SK_ILLEGAL_REQUEST = (0x5);
  public const ulong ATA_SK_UNIT_ATTENTION = (0x6);
  public const ulong ATA_SK_DATA_PROTECT = (0x7);
  public const ulong ATA_SK_BLANK_CHECK = (0x8);
  public const ulong ATA_SK_VENDOR_SPECIFIC = (0x9);
  public const ulong ATA_SK_RESERVED_A = (0xA);
  public const ulong ATA_SK_ABORT = (0xB);
  public const ulong ATA_SK_RESERVED_C = (0xC);
  public const ulong ATA_SK_OVERFLOW = (0xD);
  public const ulong ATA_SK_MISCOMPARE = (0xE);
  public const ulong ATA_SK_RESERVED_F = (0xF);

  //
  // Additional Sense Codes
  //
  public const ulong ATA_ASC_NOT_READY = (0x04);
  public const ulong ATA_ASC_MEDIA_ERR1 = (0x10);
  public const ulong ATA_ASC_MEDIA_ERR2 = (0x11);
  public const ulong ATA_ASC_MEDIA_ERR3 = (0x14);
  public const ulong ATA_ASC_MEDIA_ERR4 = (0x30);
  public const ulong ATA_ASC_MEDIA_UPSIDE_DOWN = (0x06);
  public const ulong ATA_ASC_INVALID_CMD = (0x20);
  public const ulong ATA_ASC_LBA_OUT_OF_RANGE = (0x21);
  public const ulong ATA_ASC_INVALID_FIELD = (0x24);
  public const ulong ATA_ASC_WRITE_PROTECTED = (0x27);
  public const ulong ATA_ASC_MEDIA_CHANGE = (0x28);
  public const ulong ATA_ASC_RESET = (0x29); /// < Power On Reset or Bus Reset occurred.
  public const ulong ATA_ASC_ILLEGAL_FIELD = (0x26);
  public const ulong ATA_ASC_NO_MEDIA = (0x3A);
  public const ulong ATA_ASC_ILLEGAL_MODE_FOR_THIS_TRACK = (0x64);

  //
  // Additional Sense Code Qualifier
  //
  public const ulong ATA_ASCQ_IN_PROGRESS = (0x01);

  //
  // Error Register
  //
  public const ulong ATA_ERRREG_BBK = BIT7; /// < Bad block detected      defined from ATA-1, obsoleted from ATA-2
  public const ulong ATA_ERRREG_UNC = BIT6; /// < Uncorrectable Data      defined from ATA-1, obsoleted from ATA-4
  public const ulong ATA_ERRREG_MC = BIT5; /// < Media Change            defined from ATA-1, obsoleted from ATA-4
  public const ulong ATA_ERRREG_IDNF = BIT4; /// < ID Not Found            defined from ATA-1, obsoleted from ATA-4
  public const ulong ATA_ERRREG_MCR = BIT3; /// < Media Change Requested  defined from ATA-1, obsoleted from ATA-4
  public const ulong ATA_ERRREG_ABRT = BIT2; /// < Aborted Command         defined from ATA-1
  public const ulong ATA_ERRREG_TK0NF = BIT1; /// < Track 0 Not Found       defined from ATA-1, obsoleted from ATA-4
  public const ulong ATA_ERRREG_AMNF = BIT0; /// < Address Mark Not Found  defined from ATA-1, obsoleted from ATA-4

  //
  // Status Register
  //
  public const ulong ATA_STSREG_BSY = BIT7; /// < Controller Busy         defined from ATA-1
  public const ulong ATA_STSREG_DRDY = BIT6; /// < Drive Ready             defined from ATA-1
  public const ulong ATA_STSREG_DWF = BIT5; /// < Drive Write Fault       defined from ATA-1, obsoleted from ATA-4
  public const ulong ATA_STSREG_DF = BIT5; /// < Drive Fault             defined from ATA-6
  public const ulong ATA_STSREG_DSC = BIT4; /// < Disk Seek Complete      defined from ATA-1, obsoleted from ATA-4
  public const ulong ATA_STSREG_DRQ = BIT3; /// < Data Request            defined from ATA-1
  public const ulong ATA_STSREG_CORR = BIT2; /// < Corrected Data          defined from ATA-1, obsoleted from ATA-4
  public const ulong ATA_STSREG_IDX = BIT1; /// < Index                   defined from ATA-1, obsoleted from ATA-4
  public const ulong ATA_STSREG_ERR = BIT0; /// < Error                   defined from ATA-1

  //
  // Device Control Register
  //
  public const ulong ATA_CTLREG_SRST = BIT2; /// < Software Reset.
  public const ulong ATA_CTLREG_IEN_L = BIT1; /// < Interrupt Enable #.
}

// #endif

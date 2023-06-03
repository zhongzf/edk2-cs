using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  EFI image format for PE32, PE32+ and TE. Please note some data structures are
  different for PE32 and PE32+. EFI_IMAGE_NT_HEADERS32 is for PE32 and
  EFI_IMAGE_NT_HEADERS64 is for PE32+.

  This file is coded to the Visual Studio, Microsoft Portable Executable and
  Common Object File Format Specification, Revision 8.3 - February 6, 2013.
  This file also includes some definitions in PI Specification, Revision 1.0.

Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
Portions copyright (c) 2008 - 2009, Apple Inc. All rights reserved.<BR>
Portions Copyright (c) 2016 - 2020, Hewlett Packard Enterprise Development LP. All rights reserved.<BR>
Portions Copyright (c) 2022, Loongson Technology Corporation Limited. All rights reserved.<BR>

SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef __PE_IMAGE_H__
// #define __PE_IMAGE_H__

public unsafe partial class EFI
{
  //
  // PE32+ Subsystem type for EFI images
  //
  public const ulong EFI_IMAGE_SUBSYSTEM_EFI_APPLICATION = 10;
  public const ulong EFI_IMAGE_SUBSYSTEM_EFI_BOOT_SERVICE_DRIVER = 11;
  public const ulong EFI_IMAGE_SUBSYSTEM_EFI_RUNTIME_DRIVER = 12;
  public const ulong EFI_IMAGE_SUBSYSTEM_SAL_RUNTIME_DRIVER = 13; /// < defined PI Specification, 1.0

  //
  // PE32+ Machine type for EFI images
  //
  public const ulong IMAGE_FILE_MACHINE_I386 = 0x014c;
  public const ulong IMAGE_FILE_MACHINE_IA64 = 0x0200;
  public const ulong IMAGE_FILE_MACHINE_EBC = 0x0EBC;
  public const ulong IMAGE_FILE_MACHINE_X64 = 0x8664;
  public const ulong IMAGE_FILE_MACHINE_ARMTHUMB_MIXED = 0x01c2;
  public const ulong IMAGE_FILE_MACHINE_ARM64 = 0xAA64;
  public const ulong IMAGE_FILE_MACHINE_RISCV32 = 0x5032;
  public const ulong IMAGE_FILE_MACHINE_RISCV64 = 0x5064;
  public const ulong IMAGE_FILE_MACHINE_RISCV128 = 0x5128;
  public const ulong IMAGE_FILE_MACHINE_LOONGARCH32 = 0x6232;
  public const ulong IMAGE_FILE_MACHINE_LOONGARCH64 = 0x6264;

  //
  // EXE file formats
  //
  public const ulong EFI_IMAGE_DOS_SIGNATURE = SIGNATURE_16('M', 'Z');
  public const ulong EFI_IMAGE_OS2_SIGNATURE = SIGNATURE_16('N', 'E');
  public const ulong EFI_IMAGE_OS2_SIGNATURE_LE = SIGNATURE_16('L', 'E');
  public const ulong EFI_IMAGE_NT_SIGNATURE = SIGNATURE_32('P', 'E', '\0', '\0');
}

///
/// PE images can start with an optional DOS header, so if an image is run
/// under DOS it can print an error message.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IMAGE_DOS_HEADER
{
  public ushort e_magic;    ///< Magic number.
  public ushort e_cblp;     ///< Bytes on last page of file.
  public ushort e_cp;       ///< Pages in file.
  public ushort e_crlc;     ///< Relocations.
  public ushort e_cparhdr;  ///< Size of header in paragraphs.
  public ushort e_minalloc; ///< Minimum extra paragraphs needed.
  public ushort e_maxalloc; ///< Maximum extra paragraphs needed.
  public ushort e_ss;       ///< Initial (relative) SS value.
  public ushort e_sp;       ///< Initial SP value.
  public ushort e_csum;     ///< Checksum.
  public ushort e_ip;       ///< Initial IP value.
  public ushort e_cs;       ///< Initial (relative) CS value.
  public ushort e_lfarlc;   ///< File address of relocation table.
  public ushort e_ovno;     ///< Overlay number.
  public fixed ushort e_res[4];   ///< Reserved words.
  public ushort e_oemid;    ///< OEM identifier (for e_oeminfo).
  public ushort e_oeminfo;  ///< OEM information; e_oemid specific.
  public fixed ushort e_res2[10]; ///< Reserved words.
  public uint e_lfanew;   ///< File address of new exe header.
}

///
/// COFF File Header (Object and Image).
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IMAGE_FILE_HEADER
{
  public ushort Machine;
  public ushort NumberOfSections;
  public uint TimeDateStamp;
  public uint PointerToSymbolTable;
  public uint NumberOfSymbols;
  public ushort SizeOfOptionalHeader;
  public ushort Characteristics;
}

public unsafe partial class EFI
{
  ///
  /// Size of EFI_IMAGE_FILE_HEADER.
  ///
  public const ulong EFI_IMAGE_SIZEOF_FILE_HEADER = 20;

  //
  // Characteristics
  //
  public const ulong EFI_IMAGE_FILE_RELOCS_STRIPPED = BIT0; /// < 0x0001  Relocation info stripped from file.
  public const ulong EFI_IMAGE_FILE_EXECUTABLE_IMAGE = BIT1; /// < 0x0002  File is executable  (i.e. no unresolved externel references).
  public const ulong EFI_IMAGE_FILE_LINE_NUMS_STRIPPED = BIT2; /// < 0x0004  Line numbers stripped from file.
  public const ulong EFI_IMAGE_FILE_LOCAL_SYMS_STRIPPED = BIT3; /// < 0x0008  Local symbols stripped from file.
  public const ulong EFI_IMAGE_FILE_BYTES_REVERSED_LO = BIT7; /// < 0x0080  Bytes of machine word are reversed.
  public const ulong EFI_IMAGE_FILE_32BIT_MACHINE = BIT8; /// < 0x0100  32 bit word machine.
  public const ulong EFI_IMAGE_FILE_DEBUG_STRIPPED = BIT9; /// < 0x0200  Debugging info stripped from file in .DBG file.
  public const ulong EFI_IMAGE_FILE_SYSTEM = BIT12; /// < 0x1000  System File.
  public const ulong EFI_IMAGE_FILE_DLL = BIT13; /// < 0x2000  File is a DLL.
  public const ulong EFI_IMAGE_FILE_BYTES_REVERSED_HI = BIT15; /// < 0x8000  Bytes of machine word are reversed.
}

///
/// Header Data Directories.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IMAGE_DATA_DIRECTORY
{
  public uint VirtualAddress;
  public uint Size;
}

public unsafe partial class EFI
{
  //
  // Directory Entries
  //
  public const ulong EFI_IMAGE_DIRECTORY_ENTRY_EXPORT = 0;
  public const ulong EFI_IMAGE_DIRECTORY_ENTRY_IMPORT = 1;
  public const ulong EFI_IMAGE_DIRECTORY_ENTRY_RESOURCE = 2;
  public const ulong EFI_IMAGE_DIRECTORY_ENTRY_EXCEPTION = 3;
  public const ulong EFI_IMAGE_DIRECTORY_ENTRY_SECURITY = 4;
  public const ulong EFI_IMAGE_DIRECTORY_ENTRY_BASERELOC = 5;
  public const ulong EFI_IMAGE_DIRECTORY_ENTRY_DEBUG = 6;
  public const ulong EFI_IMAGE_DIRECTORY_ENTRY_COPYRIGHT = 7;
  public const ulong EFI_IMAGE_DIRECTORY_ENTRY_GLOBALPTR = 8;
  public const ulong EFI_IMAGE_DIRECTORY_ENTRY_TLS = 9;
  public const ulong EFI_IMAGE_DIRECTORY_ENTRY_LOAD_CONFIG = 10;

  public const ulong EFI_IMAGE_NUMBER_OF_DIRECTORY_ENTRIES = 16;

  ///
  /// @attention
  /// EFI_IMAGE_NT_OPTIONAL_HDR32_MAGIC means PE32 and
  /// EFI_IMAGE_OPTIONAL_HEADER32 must be used. The data structures only vary
  /// after NT additional fields.
  ///
  public const ulong EFI_IMAGE_NT_OPTIONAL_HDR32_MAGIC = 0x10b;
}

///
/// Optional Header Standard Fields for PE32.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IMAGE_OPTIONAL_HEADER32
{
  ///
  /// Standard fields.
  ///
  public ushort Magic;
  public byte MajorLinkerVersion;
  public byte MinorLinkerVersion;
  public uint SizeOfCode;
  public uint SizeOfInitializedData;
  public uint SizeOfUninitializedData;
  public uint AddressOfEntryPoint;
  public uint BaseOfCode;
  public uint BaseOfData; ///< PE32 contains this additional field, which is absent in PE32+.
                          ///
                          /// Optional Header Windows-Specific Fields.
                          ///
  public uint ImageBase;
  public uint SectionAlignment;
  public uint FileAlignment;
  public ushort MajorOperatingSystemVersion;
  public ushort MinorOperatingSystemVersion;
  public ushort MajorImageVersion;
  public ushort MinorImageVersion;
  public ushort MajorSubsystemVersion;
  public ushort MinorSubsystemVersion;
  public uint Win32VersionValue;
  public uint SizeOfImage;
  public uint SizeOfHeaders;
  public uint CheckSum;
  public ushort Subsystem;
  public ushort DllCharacteristics;
  public uint SizeOfStackReserve;
  public uint SizeOfStackCommit;
  public uint SizeOfHeapReserve;
  public uint SizeOfHeapCommit;
  public uint LoaderFlags;
  public uint NumberOfRvaAndSizes;
  public fixed EFI_IMAGE_DATA_DIRECTORY DataDirectory[EFI_IMAGE_NUMBER_OF_DIRECTORY_ENTRIES];
}

public unsafe partial class EFI
{
  ///
  /// @attention
  /// EFI_IMAGE_NT_OPTIONAL_HDR64_MAGIC means PE32+ and
  /// EFI_IMAGE_OPTIONAL_HEADER64 must be used. The data structures only vary
  /// after NT additional fields.
  ///
  public const ulong EFI_IMAGE_NT_OPTIONAL_HDR64_MAGIC = 0x20b;
}

///
/// Optional Header Standard Fields for PE32+.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IMAGE_OPTIONAL_HEADER64
{
  ///
  /// Standard fields.
  ///
  public ushort Magic;
  public byte MajorLinkerVersion;
  public byte MinorLinkerVersion;
  public uint SizeOfCode;
  public uint SizeOfInitializedData;
  public uint SizeOfUninitializedData;
  public uint AddressOfEntryPoint;
  public uint BaseOfCode;
  ///
  /// Optional Header Windows-Specific Fields.
  ///
  public ulong ImageBase;
  public uint SectionAlignment;
  public uint FileAlignment;
  public ushort MajorOperatingSystemVersion;
  public ushort MinorOperatingSystemVersion;
  public ushort MajorImageVersion;
  public ushort MinorImageVersion;
  public ushort MajorSubsystemVersion;
  public ushort MinorSubsystemVersion;
  public uint Win32VersionValue;
  public uint SizeOfImage;
  public uint SizeOfHeaders;
  public uint CheckSum;
  public ushort Subsystem;
  public ushort DllCharacteristics;
  public ulong SizeOfStackReserve;
  public ulong SizeOfStackCommit;
  public ulong SizeOfHeapReserve;
  public ulong SizeOfHeapCommit;
  public uint LoaderFlags;
  public uint NumberOfRvaAndSizes;
  public fixed EFI_IMAGE_DATA_DIRECTORY DataDirectory[EFI_IMAGE_NUMBER_OF_DIRECTORY_ENTRIES];
}

///
/// @attention
/// EFI_IMAGE_NT_HEADERS32 is for use ONLY by tools.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IMAGE_NT_HEADERS32
{
  public uint Signature;
  public EFI_IMAGE_FILE_HEADER FileHeader;
  public EFI_IMAGE_OPTIONAL_HEADER32 OptionalHeader;
}

public unsafe partial class EFI
{
  public const ulong EFI_IMAGE_SIZEOF_NT_OPTIONAL32_HEADER = sizeof(EFI_IMAGE_NT_HEADERS32);
}

///
/// @attention
/// EFI_IMAGE_HEADERS64 is for use ONLY by tools.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IMAGE_NT_HEADERS64
{
  public uint Signature;
  public EFI_IMAGE_FILE_HEADER FileHeader;
  public EFI_IMAGE_OPTIONAL_HEADER64 OptionalHeader;
}

public unsafe partial class EFI
{
  public const ulong EFI_IMAGE_SIZEOF_NT_OPTIONAL64_HEADER = sizeof(EFI_IMAGE_NT_HEADERS64);

  //
  // Other Windows Subsystem Values
  //
  public const ulong EFI_IMAGE_SUBSYSTEM_UNKNOWN = 0;
  public const ulong EFI_IMAGE_SUBSYSTEM_NATIVE = 1;
  public const ulong EFI_IMAGE_SUBSYSTEM_WINDOWS_GUI = 2;
  public const ulong EFI_IMAGE_SUBSYSTEM_WINDOWS_CUI = 3;
  public const ulong EFI_IMAGE_SUBSYSTEM_OS2_CUI = 5;
  public const ulong EFI_IMAGE_SUBSYSTEM_POSIX_CUI = 7;

  ///
  /// Length of ShortName.
  ///
  public const ulong EFI_IMAGE_SIZEOF_SHORT_NAME = 8;
}

///
/// Section Table. This table immediately follows the optional header.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct Misc
{
  public fixed byte Name[EFI_IMAGE_SIZEOF_SHORT_NAME];
  union {
    public uint PhysicalAddress;
  public uint VirtualSize;
}
uint VirtualAddress;
uint SizeOfRawData;
uint PointerToRawData;
uint PointerToRelocations;
uint PointerToLinenumbers;
ushort NumberOfRelocations;
ushort NumberOfLinenumbers;
uint Characteristics;
} EFI_IMAGE_SECTION_HEADER;

public unsafe partial class EFI
{
  ///
  /// Size of EFI_IMAGE_SECTION_HEADER.
  ///
  public const ulong EFI_IMAGE_SIZEOF_SECTION_HEADER = 40;

  //
  // Section Flags Values
  //
  public const ulong EFI_IMAGE_SCN_TYPE_NO_PAD = BIT3; /// < 0x00000008  / /// < Reserved.
  public const ulong EFI_IMAGE_SCN_CNT_CODE = BIT5; /// < 0x00000020
  public const ulong EFI_IMAGE_SCN_CNT_INITIALIZED_DATA = BIT6; /// < 0x00000040
  public const ulong EFI_IMAGE_SCN_CNT_UNINITIALIZED_DATA = BIT7; /// < 0x00000080

  public const ulong EFI_IMAGE_SCN_LNK_OTHER = BIT8; /// < 0x00000100  / /// < Reserved.
  public const ulong EFI_IMAGE_SCN_LNK_INFO = BIT9; /// < 0x00000200  / /// < Section contains comments or some other type of information.
  public const ulong EFI_IMAGE_SCN_LNK_REMOVE = BIT11; /// < 0x00000800  / /// < Section contents will not become part of image.
  public const ulong EFI_IMAGE_SCN_LNK_COMDAT = BIT12; /// < 0x00001000

  public const ulong EFI_IMAGE_SCN_ALIGN_1BYTES = BIT20; /// < 0x00100000
  public const ulong EFI_IMAGE_SCN_ALIGN_2BYTES = BIT21; /// < 0x00200000
  public const ulong EFI_IMAGE_SCN_ALIGN_4BYTES = (BIT20 | BIT21); /// < 0x00300000
  public const ulong EFI_IMAGE_SCN_ALIGN_8BYTES = BIT22; /// < 0x00400000
  public const ulong EFI_IMAGE_SCN_ALIGN_16BYTES = (BIT20 | BIT22); /// < 0x00500000
  public const ulong EFI_IMAGE_SCN_ALIGN_32BYTES = (BIT21 | BIT22); /// < 0x00600000
  public const ulong EFI_IMAGE_SCN_ALIGN_64BYTES = (BIT20 | BIT21 | BIT22); /// < 0x00700000

  public const ulong EFI_IMAGE_SCN_MEM_DISCARDABLE = BIT25; /// < 0x02000000
  public const ulong EFI_IMAGE_SCN_MEM_NOT_CACHED = BIT26; /// < 0x04000000
  public const ulong EFI_IMAGE_SCN_MEM_NOT_PAGED = BIT27; /// < 0x08000000
  public const ulong EFI_IMAGE_SCN_MEM_SHARED = BIT28; /// < 0x10000000
  public const ulong EFI_IMAGE_SCN_MEM_EXECUTE = BIT29; /// < 0x20000000
  public const ulong EFI_IMAGE_SCN_MEM_READ = BIT30; /// < 0x40000000
  public const ulong EFI_IMAGE_SCN_MEM_WRITE = BIT31; /// < 0x80000000

                                                      ///
                                                      /// Size of a Symbol Table Record.
                                                      ///
  public const ulong EFI_IMAGE_SIZEOF_SYMBOL = 18;

  //
  // Symbols have a section number of the section in which they are
  // defined. Otherwise, section numbers have the following meanings:
  //
  public const ulong EFI_IMAGE_SYM_UNDEFINED = (ushort)0; /// < Symbol is undefined or is common.
  public const ulong EFI_IMAGE_SYM_ABSOLUTE = (ushort)-1; /// < Symbol is an absolute value.
  public const ulong EFI_IMAGE_SYM_DEBUG = (ushort)-2; /// < Symbol is a special debug item.

  //
  // Symbol Type (fundamental) values.
  //
  public const ulong EFI_IMAGE_SYM_TYPE_NULL = 0; /// < no type.
  public const ulong EFI_IMAGE_SYM_TYPE_VOID = 1; /// < no valid type.
  public const ulong EFI_IMAGE_SYM_TYPE_CHAR = 2; /// < type character.
  public const ulong EFI_IMAGE_SYM_TYPE_SHORT = 3; /// < type short integer.
  public const ulong EFI_IMAGE_SYM_TYPE_INT = 4;
  public const ulong EFI_IMAGE_SYM_TYPE_LONG = 5;
  public const ulong EFI_IMAGE_SYM_TYPE_FLOAT = 6;
  public const ulong EFI_IMAGE_SYM_TYPE_DOUBLE = 7;
  public const ulong EFI_IMAGE_SYM_TYPE_STRUCT = 8;
  public const ulong EFI_IMAGE_SYM_TYPE_UNION = 9;
  public const ulong EFI_IMAGE_SYM_TYPE_ENUM = 10; /// < enumeration.
  public const ulong EFI_IMAGE_SYM_TYPE_MOE = 11; /// < member of enumeration.
  public const ulong EFI_IMAGE_SYM_TYPE_BYTE = 12;
  public const ulong EFI_IMAGE_SYM_TYPE_WORD = 13;
  public const ulong EFI_IMAGE_SYM_TYPE_UINT = 14;
  public const ulong EFI_IMAGE_SYM_TYPE_DWORD = 15;

  //
  // Symbol Type (derived) values.
  //
  public const ulong EFI_IMAGE_SYM_DTYPE_NULL = 0; /// < no derived type.
  public const ulong EFI_IMAGE_SYM_DTYPE_POINTER = 1;
  public const ulong EFI_IMAGE_SYM_DTYPE_FUNCTION = 2;
  public const ulong EFI_IMAGE_SYM_DTYPE_ARRAY = 3;

  //
  // Storage classes.
  //
  public const ulong EFI_IMAGE_SYM_CLASS_END_OF_FUNCTION = ((byte)-1);
  public const ulong EFI_IMAGE_SYM_CLASS_NULL = 0;
  public const ulong EFI_IMAGE_SYM_CLASS_AUTOMATIC = 1;
  public const ulong EFI_IMAGE_SYM_CLASS_EXTERNAL = 2;
  public const ulong EFI_IMAGE_SYM_CLASS_STATIC = 3;
  public const ulong EFI_IMAGE_SYM_CLASS_REGISTER = 4;
  public const ulong EFI_IMAGE_SYM_CLASS_EXTERNAL_DEF = 5;
  public const ulong EFI_IMAGE_SYM_CLASS_LABEL = 6;
  public const ulong EFI_IMAGE_SYM_CLASS_UNDEFINED_LABEL = 7;
  public const ulong EFI_IMAGE_SYM_CLASS_MEMBER_OF_STRUCT = 8;
  public const ulong EFI_IMAGE_SYM_CLASS_ARGUMENT = 9;
  public const ulong EFI_IMAGE_SYM_CLASS_STRUCT_TAG = 10;
  public const ulong EFI_IMAGE_SYM_CLASS_MEMBER_OF_UNION = 11;
  public const ulong EFI_IMAGE_SYM_CLASS_UNION_TAG = 12;
  public const ulong EFI_IMAGE_SYM_CLASS_TYPE_DEFINITION = 13;
  public const ulong EFI_IMAGE_SYM_CLASS_UNDEFINED_STATIC = 14;
  public const ulong EFI_IMAGE_SYM_CLASS_ENUM_TAG = 15;
  public const ulong EFI_IMAGE_SYM_CLASS_MEMBER_OF_ENUM = 16;
  public const ulong EFI_IMAGE_SYM_CLASS_REGISTER_PARAM = 17;
  public const ulong EFI_IMAGE_SYM_CLASS_BIT_FIELD = 18;
  public const ulong EFI_IMAGE_SYM_CLASS_BLOCK = 100;
  public const ulong EFI_IMAGE_SYM_CLASS_FUNCTION = 101;
  public const ulong EFI_IMAGE_SYM_CLASS_END_OF_STRUCT = 102;
  public const ulong EFI_IMAGE_SYM_CLASS_FILE = 103;
  public const ulong EFI_IMAGE_SYM_CLASS_SECTION = 104;
  public const ulong EFI_IMAGE_SYM_CLASS_WEAK_EXTERNAL = 105;

  //
  // type packing constants
  //
  public const ulong EFI_IMAGE_N_BTMASK = 017;
  public const ulong EFI_IMAGE_N_TMASK = 060;
  public const ulong EFI_IMAGE_N_TMASK1 = 0300;
  public const ulong EFI_IMAGE_N_TMASK2 = 0360;
  public const ulong EFI_IMAGE_N_BTSHFT = 4;
  public const ulong EFI_IMAGE_N_TSHIFT = 2;

  //
  // Communal selection types.
  //
  public const ulong EFI_IMAGE_COMDAT_SELECT_NODUPLICATES = 1;
  public const ulong EFI_IMAGE_COMDAT_SELECT_ANY = 2;
  public const ulong EFI_IMAGE_COMDAT_SELECT_SAME_SIZE = 3;
  public const ulong EFI_IMAGE_COMDAT_SELECT_EXACT_MATCH = 4;
  public const ulong EFI_IMAGE_COMDAT_SELECT_ASSOCIATIVE = 5;

  //
  // the following values only be referred in PeCoff, not defined in PECOFF.
  //
  public const ulong EFI_IMAGE_WEAK_EXTERN_SEARCH_NOLIBRARY = 1;
  public const ulong EFI_IMAGE_WEAK_EXTERN_SEARCH_LIBRARY = 2;
  public const ulong EFI_IMAGE_WEAK_EXTERN_SEARCH_ALIAS = 3;
}

///
/// Relocation format.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IMAGE_RELOCATION
{
  public uint VirtualAddress;
  public uint SymbolTableIndex;
  public ushort Type;
}

public unsafe partial class EFI
{
  ///
  /// Size of EFI_IMAGE_RELOCATION
  ///
  public const ulong EFI_IMAGE_SIZEOF_RELOCATION = 10;

  //
  // I386 relocation types.
  //
  public const ulong EFI_IMAGE_REL_I386_ABSOLUTE = 0x0000; /// < Reference is absolute, no relocation is necessary.
  public const ulong EFI_IMAGE_REL_I386_DIR16 = 0x0001; /// < Direct 16-bit reference to the symbols virtual address.
  public const ulong EFI_IMAGE_REL_I386_REL16 = 0x0002; /// < PC-relative 16-bit reference to the symbols virtual address.
  public const ulong EFI_IMAGE_REL_I386_DIR32 = 0x0006; /// < Direct 32-bit reference to the symbols virtual address.
  public const ulong EFI_IMAGE_REL_I386_DIR32NB = 0x0007; /// < Direct 32-bit reference to the symbols virtual address, base not included.
  public const ulong EFI_IMAGE_REL_I386_SEG12 = 0x0009; /// < Direct 16-bit reference to the segment-selector bits of a 32-bit virtual address.
  public const ulong EFI_IMAGE_REL_I386_SECTION = 0x000A;
  public const ulong EFI_IMAGE_REL_I386_SECREL = 0x000B;
  public const ulong EFI_IMAGE_REL_I386_REL32 = 0x0014; /// < PC-relative 32-bit reference to the symbols virtual address.

  //
  // x64 processor relocation types.
  //
  public const ulong IMAGE_REL_AMD64_ABSOLUTE = 0x0000;
  public const ulong IMAGE_REL_AMD64_ADDR64 = 0x0001;
  public const ulong IMAGE_REL_AMD64_ADDR32 = 0x0002;
  public const ulong IMAGE_REL_AMD64_ADDR32NB = 0x0003;
  public const ulong IMAGE_REL_AMD64_REL32 = 0x0004;
  public const ulong IMAGE_REL_AMD64_REL32_1 = 0x0005;
  public const ulong IMAGE_REL_AMD64_REL32_2 = 0x0006;
  public const ulong IMAGE_REL_AMD64_REL32_3 = 0x0007;
  public const ulong IMAGE_REL_AMD64_REL32_4 = 0x0008;
  public const ulong IMAGE_REL_AMD64_REL32_5 = 0x0009;
  public const ulong IMAGE_REL_AMD64_SECTION = 0x000A;
  public const ulong IMAGE_REL_AMD64_SECREL = 0x000B;
  public const ulong IMAGE_REL_AMD64_SECREL7 = 0x000C;
  public const ulong IMAGE_REL_AMD64_TOKEN = 0x000D;
  public const ulong IMAGE_REL_AMD64_SREL32 = 0x000E;
  public const ulong IMAGE_REL_AMD64_PAIR = 0x000F;
  public const ulong IMAGE_REL_AMD64_SSPAN32 = 0x0010;
}

///
/// Based relocation format.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IMAGE_BASE_RELOCATION
{
  public uint VirtualAddress;
  public uint SizeOfBlock;
}

public unsafe partial class EFI
{
  ///
  /// Size of EFI_IMAGE_BASE_RELOCATION.
  ///
  public const ulong EFI_IMAGE_SIZEOF_BASE_RELOCATION = 8;

  //
  // Based relocation types.
  //
  public const ulong EFI_IMAGE_REL_BASED_ABSOLUTE = 0;
  public const ulong EFI_IMAGE_REL_BASED_HIGH = 1;
  public const ulong EFI_IMAGE_REL_BASED_LOW = 2;
  public const ulong EFI_IMAGE_REL_BASED_HIGHLOW = 3;
  public const ulong EFI_IMAGE_REL_BASED_HIGHADJ = 4;
  public const ulong EFI_IMAGE_REL_BASED_MIPS_JMPADDR = 5;
  public const ulong EFI_IMAGE_REL_BASED_ARM_MOV32A = 5;
  public const ulong EFI_IMAGE_REL_BASED_ARM_MOV32T = 7;
  public const ulong EFI_IMAGE_REL_BASED_IA64_IMM64 = 9;
  public const ulong EFI_IMAGE_REL_BASED_MIPS_JMPADDR16 = 9;
  public const ulong EFI_IMAGE_REL_BASED_DIR64 = 10;

  ///
  /// Relocation types of RISC-V processor.
  ///
  public const ulong EFI_IMAGE_REL_BASED_RISCV_HI20 = 5;
  public const ulong EFI_IMAGE_REL_BASED_RISCV_LOW12I = 7;
  public const ulong EFI_IMAGE_REL_BASED_RISCV_LOW12S = 8;

  //
  // Relocation types of LoongArch processor.
  //
  public const ulong EFI_IMAGE_REL_BASED_LOONGARCH32_MARK_LA = 8;
  public const ulong EFI_IMAGE_REL_BASED_LOONGARCH64_MARK_LA = 8;
}

///
/// Line number format.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct Type
{
  union {
    public uint SymbolTableIndex; ///< Symbol table index of function name if Linenumber is 0.
  public uint VirtualAddress;   ///< Virtual address of line number.
}
ushort Linenumber;       ///< Line number.
} EFI_IMAGE_LINENUMBER;

public unsafe partial class EFI
{
  ///
  /// Size of EFI_IMAGE_LINENUMBER.
  ///
  public const ulong EFI_IMAGE_SIZEOF_LINENUMBER = 6;

  //
  // Archive format.
  //
  public const ulong EFI_IMAGE_ARCHIVE_START_SIZE = 8;
  public const ulong EFI_IMAGE_ARCHIVE_START = "!<arch>\n";
  public const ulong EFI_IMAGE_ARCHIVE_END = "`\n";
  public const ulong EFI_IMAGE_ARCHIVE_PAD = "\n";
  public const ulong EFI_IMAGE_ARCHIVE_LINKER_MEMBER = "/               ";
  public const ulong EFI_IMAGE_ARCHIVE_LONGNAMES_MEMBER = "; //               "
}

///
/// Archive Member Headers
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IMAGE_ARCHIVE_MEMBER_HEADER
{
  public fixed byte Name[16];     ///< File member name - `/' terminated.
  public fixed byte Date[12];     ///< File member date - decimal.
  public fixed byte UserID[6];    ///< File member user id - decimal.
  public fixed byte GroupID[6];   ///< File member group id - decimal.
  public fixed byte Mode[8];      ///< File member mode - octal.
  public fixed byte Size[10];     ///< File member size - decimal.
  public fixed byte EndHeader[2]; ///< String to end header. (0x60 0x0A).
}

public unsafe partial class EFI
{
  ///
  /// Size of EFI_IMAGE_ARCHIVE_MEMBER_HEADER.
  ///
  public const ulong EFI_IMAGE_SIZEOF_ARCHIVE_MEMBER_HDR = 60;

  //
  // DLL Support
  //
}

///
/// Export Directory Table.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IMAGE_EXPORT_DIRECTORY
{
  public uint Characteristics;
  public uint TimeDateStamp;
  public ushort MajorVersion;
  public ushort MinorVersion;
  public uint Name;
  public uint Base;
  public uint NumberOfFunctions;
  public uint NumberOfNames;
  public uint AddressOfFunctions;
  public uint AddressOfNames;
  public uint AddressOfNameOrdinals;
}

///
/// Hint/Name Table.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IMAGE_IMPORT_BY_NAME
{
  public ushort Hint;
  public fixed byte Name[1];
}

///
/// Import Address Table RVA (Thunk Table).
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct u1
{
  union {
    public uint Function;
  public uint Ordinal;
  public EFI_IMAGE_IMPORT_BY_NAME* AddressOfData;
}
} EFI_IMAGE_THUNK_DATA;

public unsafe partial class EFI
{
  public const ulong EFI_IMAGE_ORDINAL_FLAG = BIT31; /// < Flag for PE32.
  public const ulong EFI_IMAGE_SNAP_BY_ORDINAL = (Ordinal)((Ordinal & EFI_IMAGE_ORDINAL_FLAG) != 0);
  public const ulong EFI_IMAGE_ORDINAL = (Ordinal)(Ordinal & 0xffff);
}

///
/// Import Directory Table
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IMAGE_IMPORT_DESCRIPTOR
{
  public uint Characteristics;
  public uint TimeDateStamp;
  public uint ForwarderChain;
  public uint Name;
  public EFI_IMAGE_THUNK_DATA* FirstThunk;
}

///
/// Debug Directory Format.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IMAGE_DEBUG_DIRECTORY_ENTRY
{
  public uint Characteristics;
  public uint TimeDateStamp;
  public ushort MajorVersion;
  public ushort MinorVersion;
  public uint Type;
  public uint SizeOfData;
  public uint RVA;         ///< The address of the debug data when loaded, relative to the image base.
  public uint FileOffset;  ///< The file pointer to the debug data.
}

public unsafe partial class EFI
{
  public const ulong EFI_IMAGE_DEBUG_TYPE_CODEVIEW = 2; /// < The Visual C++ debug information.
  public const ulong EFI_IMAGE_DEBUG_TYPE_EX_DLLCHARACTERISTICS = 20;
}

///
/// Debug Data Structure defined in Microsoft C++.
///
public const ulong CODEVIEW_SIGNATURE_NB10 = SIGNATURE_32('N', 'B', '1', '0');
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IMAGE_DEBUG_CODEVIEW_NB10_ENTRY
{
  public uint Signature;                      ///< "NB10"
  public uint Unknown;
  public uint Unknown2;
  public uint Unknown3;
  //
  // Filename of .PDB goes here
  //
}

public unsafe partial class EFI
{
  ///
  /// Debug Data Structure defined in Microsoft C++.
  ///
  public const ulong CODEVIEW_SIGNATURE_RSDS = SIGNATURE_32('R', 'S', 'D', 'S');
}
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IMAGE_DEBUG_CODEVIEW_RSDS_ENTRY
{
  public uint Signature;                      ///< "RSDS".
  public uint Unknown;
  public uint Unknown2;
  public uint Unknown3;
  public uint Unknown4;
  public uint Unknown5;
  //
  // Filename of .PDB goes here
  //
}

public unsafe partial class EFI
{
  ///
  /// Debug Data Structure defined by Apple Mach-O to Coff utility.
  ///
  public const ulong CODEVIEW_SIGNATURE_MTOC = SIGNATURE_32('M', 'T', 'O', 'C');
}
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IMAGE_DEBUG_CODEVIEW_MTOC_ENTRY
{
  public uint Signature;                       ///< "MTOC".
  public GUID MachOUuid;
  //
  //  Filename of .DLL (Mach-O with debug info) goes here
  //
}

public unsafe partial class EFI
{
  ///
  /// Extended DLL Characteristics
  ///
  public const ulong EFI_IMAGE_DLLCHARACTERISTICS_EX_CET_COMPAT = 0x0001;
  public const ulong EFI_IMAGE_DLLCHARACTERISTICS_EX_FORWARD_CFI_COMPAT = 0x0040;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IMAGE_DEBUG_EX_DLLCHARACTERISTICS_ENTRY
{
  public uint DllCharacteristicsEx;
}

///
/// Resource format.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IMAGE_RESOURCE_DIRECTORY
{
  public uint Characteristics;
  public uint TimeDateStamp;
  public ushort MajorVersion;
  public ushort MinorVersion;
  public ushort NumberOfNamedEntries;
  public ushort NumberOfIdEntries;
  //
  // Array of EFI_IMAGE_RESOURCE_DIRECTORY_ENTRY entries goes here.
  //
}

///
/// Resource directory entry format.
///
//[StructLayout(LayoutKind.Sequential)]
//public unsafe struct s
//{
//  union {
//    struct {
//      public uint NameOffset = 31;
//  public uint NameIsString = 1;
//}
//uint Id;
//  } u1;
//union {
//    uint    OffsetToData;
//struct {
//      uint OffsetToDirectory : 31;
//uint DataIsDirectory   : 1;
//    } s;
//  } u2;
//} EFI_IMAGE_RESOURCE_DIRECTORY_ENTRY;

///
/// Resource directory entry for string.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IMAGE_RESOURCE_DIRECTORY_STRING
{
  public ushort Length;
  public fixed char String[1];
}

///
/// Resource directory entry for data array.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_IMAGE_RESOURCE_DATA_ENTRY
{
  public uint OffsetToData;
  public uint Size;
  public uint CodePage;
  public uint Reserved;
}

///
/// Header format for TE images, defined in the PI Specification, 1.0.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_TE_IMAGE_HEADER
{
  public ushort Signature;           ///< The signature for TE format = "VZ".
  public ushort Machine;             ///< From the original file header.
  public byte NumberOfSections;    ///< From the original file header.
  public byte Subsystem;           ///< From original optional header.
  public ushort StrippedSize;        ///< Number of bytes we removed from the header.
  public uint AddressOfEntryPoint; ///< Offset to entry point -- from original optional header.
  public uint BaseOfCode;          ///< From original image -- required for ITP debug.
  public ulong ImageBase;           ///< From original file header.
  public fixed EFI_IMAGE_DATA_DIRECTORY DataDirectory[2];    ///< Only base relocation and debug directory.
}

public unsafe partial class EFI
{
  public const ulong EFI_TE_IMAGE_HEADER_SIGNATURE = SIGNATURE_16('V', 'Z');

  //
  // Data directory indexes in our TE image header
  //
  public const ulong EFI_TE_IMAGE_DIRECTORY_ENTRY_BASERELOC = 0;
  public const ulong EFI_TE_IMAGE_DIRECTORY_ENTRY_DEBUG = 1;
}

///
/// Union of PE32, PE32+, and TE headers.
///
[StructLayout(LayoutKind.Explicit)]
public unsafe struct EFI_IMAGE_OPTIONAL_HEADER_UNION
{
  [FieldOffset(0)] public EFI_IMAGE_NT_HEADERS32 Pe32;
  [FieldOffset(0)] public EFI_IMAGE_NT_HEADERS64 Pe32Plus;
  [FieldOffset(0)] public EFI_TE_IMAGE_HEADER Te;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct EFI_IMAGE_OPTIONAL_HEADER_PTR_UNION
{
  [FieldOffset(0)] public EFI_IMAGE_NT_HEADERS32* Pe32;
  [FieldOffset(0)] public EFI_IMAGE_NT_HEADERS64* Pe32Plus;
  [FieldOffset(0)] public EFI_TE_IMAGE_HEADER* Te;
  [FieldOffset(0)] public EFI_IMAGE_OPTIONAL_HEADER_UNION* Union;
}

// #endif

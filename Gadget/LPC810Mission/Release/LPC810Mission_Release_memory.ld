/*
 * GENERATED FILE - DO NOT EDIT
 * (c) Code Red Technologies Ltd, 2008-2013
 * (c) NXP Semiconductors 2013-2017
 * Generated linker script file for LPC810
 * Created from memory.ldt by FMCreateLinkMemory
 * Using Freemarker v2.3.23
 * LPCXpresso v8.2.2 [Build 650] [2016-09-09]  on 2017/08/15 15:47:51
 */

MEMORY
{
  /* Define each memory region */
  MFlash4 (rx) : ORIGIN = 0x0, LENGTH = 0x1000 /* 4K bytes (alias Flash) */  
  RamLoc1 (rwx) : ORIGIN = 0x10000000, LENGTH = 0x400 /* 1K bytes (alias RAM) */  
}

  /* Define a symbol for the top of each memory region */
  __base_MFlash4 = 0x0  ; /* MFlash4 */  
  __base_Flash = 0x0 ; /* Flash */  
  __top_MFlash4 = 0x0 + 0x1000 ; /* 4K bytes */  
  __top_Flash = 0x0 + 0x1000 ; /* 4K bytes */  
  __base_RamLoc1 = 0x10000000  ; /* RamLoc1 */  
  __base_RAM = 0x10000000 ; /* RAM */  
  __top_RamLoc1 = 0x10000000 + 0x400 ; /* 1K bytes */  
  __top_RAM = 0x10000000 + 0x400 ; /* 1K bytes */  

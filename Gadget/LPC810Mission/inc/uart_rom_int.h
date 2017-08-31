/*
 * uart_rom_int.h
 *
 *  Created on: 2017/07/25
 *      Author: kayasuga
 */

#ifndef UART_ROM_INT_H_
#define UART_ROM_INT_H_
#ifdef __cplusplus
extern "C" {
#endif

void Init_UART_PinMux(void);
void setupUART(uint32_t baudrate);
void putCharUART(uint8_t c);
uint8_t getCharUART();
void putLineUART(const char *send_data);

#ifdef __cplusplus
}
#endif
#endif /* UART_ROM_INT_H_ */

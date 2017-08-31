/*
===============================================================================
 Name        : LPC810RecordClocker.c
 Author      : $(author)
 Version     :
 Copyright   : $(copyright)
 Description : main definition
===============================================================================
*/

#if defined (__USE_LPCOPEN)
#if defined(NO_BOARD_LIB)
#include "chip.h"
#else
#include "board.h"
#endif
#endif

#include <cr_section_macros.h>

// TODO: insert other include files here
#include "uart_rom_int.h"
#include "form.h"
// TODO: insert other definitions and declarations here
#define SYSTICK_INTERVAL 2

#define TIMER_NUM 3

#define START	0
#define END		1

#define HOUR	0
#define MINUTE	1
#define SECOND	2

//#define START_BYTE	0xFE
//#define END_BYTE	0xFF
#define START_BYTE	's'
#define END_BYTE	'e'

uint8_t counter;
uint8_t recodeTime[TIMER_NUM][2][3];	// number of timer / start & end / hour & minute & second
uint8_t nowTime[3];						// hour & minute & second
uint8_t state;

void SysTick_Handler(void)
{
	uint8_t i;
	__disable_irq();
	counter++;
	if(counter >= SYSTICK_INTERVAL) {
		counter = 0;
		nowTime[SECOND]++;
		if(nowTime[SECOND] >= 60) {
			nowTime[SECOND] = 0;
			nowTime[MINUTE]++;
			if(nowTime[MINUTE] >= 60) {
				nowTime[MINUTE] = 0;
				nowTime[HOUR]++;
				if(nowTime[HOUR] >= 24) {
					nowTime[HOUR] = 0;
				}
			}
		}
	}
	for(i = 0; i < TIMER_NUM; i++) {
		if(nowTime[HOUR] == recodeTime[i][START][HOUR] && nowTime[MINUTE] == recodeTime[i][START][MINUTE] && nowTime[SECOND] == recodeTime[i][START][SECOND]) {
			Chip_GPIO_SetPinOutHigh(LPC_GPIO_PORT, 0, 2);
			state = 1;
		}
		if(nowTime[HOUR] == recodeTime[i][END][HOUR] && nowTime[MINUTE] == recodeTime[i][END][MINUTE] && nowTime[SECOND] == recodeTime[i][END][SECOND]) {
			Chip_GPIO_SetPinOutLow(LPC_GPIO_PORT, 0, 2);
			state = 0;
		}
	}
	__enable_irq();
}

int main(void) {

	uint8_t cmd, setting_flag, data_flag;
	uint8_t rx_packet[32], index;
	uint8_t i, j, k;

    // TODO: insert code here
    SystemCoreClockUpdate();

	Chip_Clock_EnablePeriphClock(SYSCTL_CLOCK_SWM);
	Chip_SWM_DisableFixedPin(SWM_FIXED_SWDIO);
	Chip_Clock_DisablePeriphClock(SYSCTL_CLOCK_SWM);

    // Initialize switching pin
    Chip_GPIO_Init(LPC_GPIO_PORT);
    Chip_GPIO_SetPinDIROutput(LPC_GPIO_PORT, 0, 2);
    Chip_GPIO_SetPinOutLow(LPC_GPIO_PORT, 0, 2);
    state = 0;

    Init_UART_PinMux();

	/* Allocate UART handle, setup UART parameters, and initialize UART
	   clocking */
	setupUART(9600);
	putLineUART("HELLOWORLD\r\n");

	// Initialize
	for(i = 0; i < 3; i++) {
		nowTime[i] = 0;
	}

	for(i = 0; i < TIMER_NUM; i++) {
		for(j = 0; j < 2; j++) {
			for(k = 0; k < 3; k++) {
				recodeTime[i][j][k] = 0;
			}
		}
	}
	recodeTime[0][START][MINUTE] = 1;
	recodeTime[0][END][MINUTE] = 3;
	recodeTime[1][START][MINUTE] = 4;
	recodeTime[1][END][MINUTE] = 6;
	recodeTime[2][START][MINUTE] = 7;
	recodeTime[2][END][MINUTE] = 9;
	// Setting operation
	setting_flag = 1;
	data_flag = 0;
	index = 0;
	while(setting_flag) {
		cmd = getCharUART();
		switch(cmd) {
		case START_BYTE:
			data_flag = 1;
			index = 0;
			putCharUART(START_BYTE);
			break;
		case END_BYTE:
			setting_flag = 0;
			putCharUART(END_BYTE);
			break;
		default:
			if(data_flag == 1) {
				rx_packet[index] = cmd;
				index++;
				if(index > 32) {
					setting_flag = 0;
				}
			}
			break;
		}
	}
	if(data_flag == 1) {
		nowTime[HOUR] = rx_packet[0];
		nowTime[MINUTE] = rx_packet[1];
		nowTime[SECOND] = rx_packet[2];

		putLineUART("NOW TIME\r\n");
		putLineUART(formItoa((int)nowTime[HOUR]));
		putCharUART(':');
		putLineUART(formItoa((int)nowTime[MINUTE]));
		putCharUART(':');
		putLineUART(formItoa((int)nowTime[SECOND]));
		putLineUART("\r\n");

		for(i = 0; i < TIMER_NUM; i++) {
			putLineUART(formItoa(i));
			putLineUART("TIMER\r\n");
			for(j = 0; j < 2; j++) {
				for(k = 0; k < 3; k++) {
					recodeTime[i][j][k] = rx_packet[2 * 3 * i  + 3 * j + k + 3];
					putCharUART(recodeTime[i][j][k]);
					putCharUART(':');
				}
				putCharUART(' ');
			}
			putLineUART("\r\n");
		}
	}

	/* Enable the IRQ for the UART */
	//NVIC_DisableIRQ(UART0_IRQn);

	putLineUART("START\r\n");
	/* Enable SysTick Timer */
	SysTick_Config(SystemCoreClock / SYSTICK_INTERVAL);

	while(1) {
    	__WFI();

    	putLineUART(formItoa((int)nowTime[HOUR]));
    	putCharUART(':');
    	putLineUART(formItoa((int)nowTime[MINUTE]));
    	putCharUART(':');
    	putLineUART(formItoa((int)nowTime[SECOND]));
    	putLineUART("\r\nSTATE = ");
    	putLineUART(formItoa((int)state));
    	putLineUART("\r\n");

    }
    return 0 ;
}

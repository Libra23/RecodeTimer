/*
 * uart_rom_int.c
 *
 *  Created on: 2017/07/25
 *      Author: kayasuga
 */

#include "chip.h"
#include <string.h>

#include "uart_rom_int.h"

/* Use a buffer size larger than the expected return value of
   uart_get_mem_size() for the static UART handle type */
static uint32_t uartHandleMEM[0x10];

/* ASCII code for escape key */
#define ESCKEY			27
#define	UART_CLOCK_DIV	1

/* Flag used to indicate callback fired */
static volatile bool gotCallback;


/* UART handle and memory for ROM API */
static UART_HANDLE_T *uartHandle;


/**
 * @brief	Handle UART interrupt
 * @return	Nothing
 */
void UART0_IRQHandler(void)
{
	LPC_UARTD_API->uart_isr(uartHandle);
}


/* UART Pin mux function - note that SystemInit() may already setup your
   pin muxing at system startup */
void Init_UART_PinMux(void)
{
	/* Enable the clock to the Switch Matrix */
	Chip_Clock_EnablePeriphClock(SYSCTL_CLOCK_SWM);

	Chip_Clock_SetUARTClockDiv(UART_CLOCK_DIV);
	/* Connect the U0_TXD_O and U0_RXD_I signals to port pins(P0.4, P0.0) */
	Chip_SWM_DisableFixedPin(SWM_FIXED_ACMP_I1);
	Chip_SWM_MovablePinAssign(SWM_U0_TXD_O, 4);
	Chip_SWM_MovablePinAssign(SWM_U0_RXD_I, 0);

	/* Disable the clock to the Switch Matrix to save power */
	Chip_Clock_DisablePeriphClock(SYSCTL_CLOCK_SWM);
}

/* Turn on LED to indicate an error */
void errorUART(void)
{
	while (1) {}
}

/* Setup UART handle and parameters */
void setupUART(uint32_t baudrate)
{
	uint32_t frg_mult;

    Chip_UART_Init(LPC_USART0);

	/* 115.2KBPS, 8N1, ASYNC mode, no errors, clock filled in later */
	UART_CONFIG_T cfg = {
		0,				/* U_PCLK frequency in Hz */
		baudrate,			/* Baud Rate in Hz */
		1,				/* 8N1 */
		0,				/* Asynchronous Mode */
		NO_ERR_EN		/* Enable No Errors */
	};

	/* Perform a sanity check on the storage allocation */
	if (LPC_UARTD_API->uart_get_mem_size() > sizeof(uartHandleMEM)) {
		/* Example only: this should never happen and probably isn't needed for
		   most UART code. */
		errorUART();
	}

	/* Setup the UART handle */
	uartHandle = LPC_UARTD_API->uart_setup((uint32_t) LPC_USART0, (uint8_t *) &uartHandleMEM);
	if (uartHandle == NULL) {
		errorUART();
	}

	/* Need to tell UART ROM API function the current UART peripheral clock speed */
	cfg.sys_clk_in_hz = Chip_Clock_GetMainClockRate()/UART_CLOCK_DIV;

	/* Initialize the UART with the configuration parameters */
	frg_mult = LPC_UARTD_API->uart_init(uartHandle, &cfg);
	if (frg_mult) {
		Chip_SYSCTL_SetUSARTFRGDivider(0xFF);	/* value 0xFF should be always used */
		Chip_SYSCTL_SetUSARTFRGMultiplier(frg_mult);
	}

	/* Enable the IRQ for the UART */
	NVIC_EnableIRQ(UART0_IRQn);
}

/* UART callback */
void waitCallback(uint32_t err_code, uint32_t n)
{
	gotCallback = true;
}

/* Sleep until callback is called */
void sleepUntilCB(void)
{
	/* Wait until the transmit callback occurs. When it hits, the
	     transfer is complete. */
	while (gotCallback == false) {
		/* Sleep until the callback signals transmit completion */
		__WFI();
	}
}

/* Send a char on the UART */
void putCharUART(uint8_t c){
	LPC_UARTD_API->uart_put_char(uartHandle, c);
}

/* Receive a string on the UART */
uint8_t getCharUART(){
	return LPC_UARTD_API->uart_get_char(uartHandle);
}

/* Send a string on the UART terminated by a NULL character using
   polling mode. */
void putLineUART(const char *send_data)
{
	UART_PARAM_T param;

	param.buffer = (uint8_t *) send_data;
	param.size = strlen(send_data);

	/* Interrupt mode, do not append CR/LF to sent data */
	param.transfer_mode = TX_MODE_SZERO;
	param.driver_mode = DRIVER_MODE_INTERRUPT;

	/* Setup the transmit callback, this will get called when the
	   transfer is complete */
	param.callback_func_pt = (UART_CALLBK_T) waitCallback;

	/* Transmit the data using interrupt mode, the function will
	   return */
	gotCallback = false;
	if (LPC_UARTD_API->uart_put_line(uartHandle, &param)) {
		errorUART();
	}

	/* Wait until the transmit callback occurs. When it hits, the
	   transfer is complete. */
	sleepUntilCB();
}

/* Receive a string on the UART terminated by a LF character using
   polling mode. */
void getLineUART(char *receive_buffer, uint32_t length)
{
	UART_PARAM_T param;

	param.buffer = (uint8_t *) receive_buffer;
	param.size = length;

	/* Receive data up to the CR/LF character in polling mode. Will
	   truncate at length if too long.	*/
	param.transfer_mode = RX_MODE_CRLF_RECVD;
	param.driver_mode = DRIVER_MODE_INTERRUPT;

	/* Setup the receive callback, this will get called when the
	   transfer is complete */
	param.callback_func_pt = (UART_CALLBK_T) waitCallback;

	/* Receive the data */
	gotCallback = false;
	if (LPC_UARTD_API->uart_get_line(uartHandle, &param)) {
		errorUART();
	}

	/* Wait until the transmit callback occurs. When it hits, the
	   transfer is complete. */
	sleepUntilCB();
}

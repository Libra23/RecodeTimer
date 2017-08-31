################################################################################
# Automatically-generated file. Do not edit!
################################################################################

# Add inputs and outputs from these tool invocations to the build variables 
C_SRCS += \
../src/LPC810Mission.c \
../src/cr_startup_lpc8xx.c \
../src/crp.c \
../src/form.c \
../src/mtb.c \
../src/sysinit.c \
../src/uart_rom_int.c 

OBJS += \
./src/LPC810Mission.o \
./src/cr_startup_lpc8xx.o \
./src/crp.o \
./src/form.o \
./src/mtb.o \
./src/sysinit.o \
./src/uart_rom_int.o 

C_DEPS += \
./src/LPC810Mission.d \
./src/cr_startup_lpc8xx.d \
./src/crp.d \
./src/form.d \
./src/mtb.d \
./src/sysinit.d \
./src/uart_rom_int.d 


# Each subdirectory must supply rules for building sources it contributes
src/%.o: ../src/%.c
	@echo 'Building file: $<'
	@echo 'Invoking: MCU C Compiler'
	arm-none-eabi-gcc -DDEBUG -D__CODE_RED -DCORE_M0PLUS -D__MTB_DISABLE -D__MTB_BUFFER_SIZE=0 -D__USE_LPCOPEN -DNO_BOARD_LIB -D__LPC8XX__ -D__REDLIB__ -I"C:\Users\kayasuga\Documents\LPCXpresso_8.2.2_650\workspace\LPC810Mission\inc" -I"C:\Users\kayasuga\Documents\LPCXpresso_8.2.2_650\workspace\lpc_chip_8xx\inc" -O0 -g3 -Wall -c -fmessage-length=0 -fno-builtin -ffunction-sections -fdata-sections -mcpu=cortex-m0 -mthumb -specs=redlib.specs -MMD -MP -MF"$(@:%.o=%.d)" -MT"$(@:%.o=%.o)" -MT"$(@:%.o=%.d)" -o "$@" "$<"
	@echo 'Finished building: $<'
	@echo ' '



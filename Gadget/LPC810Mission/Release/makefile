################################################################################
# Automatically-generated file. Do not edit!
################################################################################

-include ../makefile.init

RM := rm -rf

# All of the sources participating in the build are defined here
-include sources.mk
-include src/subdir.mk
-include subdir.mk
-include objects.mk

ifneq ($(MAKECMDGOALS),clean)
ifneq ($(strip $(C_DEPS)),)
-include $(C_DEPS)
endif
endif

-include ../makefile.defs

# Add inputs and outputs from these tool invocations to the build variables 

# All Target
all: LPC810Mission.axf

# Tool invocations
LPC810Mission.axf: $(OBJS) $(USER_OBJS)
	@echo 'Building target: $@'
	@echo 'Invoking: MCU Linker'
	arm-none-eabi-gcc -nostdlib -L"C:\Users\kayasuga\Documents\LPCXpresso_8.2.2_650\workspace\lpc_chip_8xx\Release" -Xlinker -Map="LPC810Mission.map" -Xlinker --gc-sections -mcpu=cortex-m0 -mthumb -T "LPC810Mission_Release.ld" -o "LPC810Mission.axf" $(OBJS) $(USER_OBJS) $(LIBS)
	@echo 'Finished building target: $@'
	@echo ' '
	$(MAKE) --no-print-directory post-build

# Other Targets
clean:
	-$(RM) $(EXECUTABLES)$(OBJS)$(C_DEPS) LPC810Mission.axf
	-@echo ' '

post-build:
	-@echo 'Performing post-build steps'
	-arm-none-eabi-size "LPC810Mission.axf" ; arm-none-eabi-objcopy -v -O ihex "LPC810Mission.axf" "LPC810Mission.hex" ; # checksum -p LPC810 -d "LPC810Mission.bin"
	-@echo ' '

.PHONY: all clean dependents
.SECONDARY: post-build

-include ../makefile.targets

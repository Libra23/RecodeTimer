/*
 * form.c
 *
 *  Created on: 2014/10/12
 *      Author: Tetsuya Suzuki
 */

#include <stdint.h>

char formBuf[13];

char *formHex(uint32_t n, int dig) {
	static const char hex[] = {
		'0', '1', '2', '3', '4', '5', '6', '7',
		'8', '9', 'A', 'B', 'C', 'D', 'E', 'F'
	};

	formBuf[dig--] = '\0';
	while (dig >= 0) {
		formBuf[dig--] = hex[n % 0x10];
		n /= 0x10;
	}
	return formBuf;
}

char *formDec(int n, int ip, int dp) {
	int index;
	int sign;

	if (n < 0) {
		sign = 1;
		n *= -1;
	} else
		sign = 0;

	if (dp > 0) {
		index = ip + dp + 1;
		formBuf[index--] = '\0';
		while (dp--) {
			formBuf[index--] = (n % 10) + '0';
			n /= 10;
		}
		formBuf[index--] = '.';
	} else {
		index = ip;
		formBuf[index--] = '\0';
	}

	while (index >= 0) {
		formBuf[index--] = (n % 10) + '0';
		n /= 10;
		if (n <= 0)
			break;
	}
	if (sign)
		formBuf[index--] = '-';

	while (index >= 0)
		formBuf[index--] = ' ';

	return formBuf;
}

char *formItoa(int n) {
	int tmp;
	int ip;

	tmp = n;
	for (ip = 1; tmp /= 10; ip++);
	if (n < 0)
		ip++;

	return formDec(n, ip, 0);
}

char *formFloat(float f, int ip, int dp) {
	int n;
	static const float p[] =
			{ 1, 10, 100, 1000, 10000, 100000, 1000000, 1000000 };

	n = (int) (f * p[dp]);
	return formDec(n, ip, dp);
}

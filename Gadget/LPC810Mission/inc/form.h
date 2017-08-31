/*
 * form.h
 *
 *  Created on: 2014/10/12
 *      Author: Tetsuya
 */

#ifndef FORM_H_
#define FORM_H_
#ifdef __cplusplus
extern "C" {
#endif

char *formItoa(int n);
char *formHex(uint32_t n, int dig);
char *formDec(int n, int ip, int dp);
char *formFloat(float f, int ip, int dp);

#ifdef __cplusplus
}
#endif
#endif /* FORM_H_ */

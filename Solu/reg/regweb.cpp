 
#include <string.h>
 
extern "C" __declspec(dllexport) int mySum(int a,int b,int *c){
	*c=a+b;
	return *c;
}

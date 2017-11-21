// test.cpp : 定义控制台应用程序的入口点。
//

#include "stdafx.h"
//#include "afx.h"
#include "windows.h"

int _tmain(int argc, _TCHAR* argv[])
{
	return 0;
}

void WINAPI WriteWebBrowserRegKey(LPCTSTR lpKey,DWORD dwValue)  
{  
	
		//HKEY hk;  	
		//CString str = "Software\\Microsoft\\Internet Explorer\\Main\\FeatureControl\\";  
		//str += lpKey;  
		//if (RegCreateKey(HKEY_LOCAL_MACHINE,str,&hk)!=0)  
		//{  
		//	MessageBox(NULL,"打开注册表失败!","Error",0);  
		//	ExitProcess(-1);  
		//}  
		//if (RegSetValueEx(hk,"Test.exe", NULL, REG_DWORD,(const byte*)&dwValue,4)!=0)  
		//{  
		//	RegCloseKey(hk);  
		//	MessageBox(NULL,"写注册表失败!","Error",0);  
		//	ExitProcess(-1);  
		//}  
		//RegCloseKey(hk);  
}  
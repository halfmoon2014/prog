// test.cpp : �������̨Ӧ�ó������ڵ㡣
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
		//	MessageBox(NULL,"��ע���ʧ��!","Error",0);  
		//	ExitProcess(-1);  
		//}  
		//if (RegSetValueEx(hk,"Test.exe", NULL, REG_DWORD,(const byte*)&dwValue,4)!=0)  
		//{  
		//	RegCloseKey(hk);  
		//	MessageBox(NULL,"дע���ʧ��!","Error",0);  
		//	ExitProcess(-1);  
		//}  
		//RegCloseKey(hk);  
}  
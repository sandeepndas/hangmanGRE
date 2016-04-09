
using System;

public static class TextUtils  {

	public static bool isUAlpha(char c){
	
		return c >= 'A' && c <= 'Z';
	
	}
	public static bool isLAlpha(char c){
	
		return c >= 'a' && c <= 'z';
	
	}
	
	public static bool isAlpha(char c){
	
		return isUAlpha (c) || isLAlpha(c);
	
	}
}

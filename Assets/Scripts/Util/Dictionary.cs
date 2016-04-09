

using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class Dictionary  {

	private static Dictionary s_instance;
	private string[] words;
	
	
	public static Dictionary instance {
		
		get { return s_instance == null ? load () : s_instance;}
	
	}
	
	private Dictionary (string[] words){
	
		this.words = words;
	
	}
	
	private static bool isWordOK(string word){
	
		if(word.Length < 1){
			return false;
		}
	
		foreach (char c in word) {
		
			if(!TextUtils.isAlpha(c)){
				return false;
			}
		
		}

		return true;
	}
	
	

	public static Dictionary load(){
	
			if(s_instance != null){
				return s_instance;
			}
	
	
		HashSet<string> wordList = new HashSet<string> ();
		//loading word list
		TextAsset asset = Resources.Load ("words") as TextAsset;
		TextReader src = new StringReader(asset.text);
		//reading lines
		while(src.Peek() != -1){
			string word = src.ReadLine();
			if(isWordOK(word)){
				wordList.Add(word);
			}
		}
		//unloading assets
		Resources.UnloadAsset(asset);
		//setup dict
		string[] words = new string[wordList.Count];
		wordList.CopyTo (words);
		s_instance = new Dictionary(words);
		
		return s_instance;
	}


	public string next(int limit){
		int index = (int) (Random.value * (words.Length-1));
		return words[index];
	}


}

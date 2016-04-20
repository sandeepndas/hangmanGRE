using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GreQuestions : MonoBehaviour
{
	
	public static GreQuestions s_instance;

	public TextAsset file;

	void Start(){
		Load(file);
	}

	public string next(){
		int index = (int) (Random.value * (rowList.Count));
		string i = (string)index.ToString ();
		string word = Find_id (i).Word;
		Debug.Log(Find_id (i).Word);
		Debug.Log(Find_Word (word).Meaning);
		return (Find_id (i).Word);
	}

	public class Row
	{
		public string id;
		public string Word;
		public string Meaning;

	}

	List<Row> rowList = new List<Row>();
	bool isLoaded = false;

	public bool IsLoaded()
	{
		return isLoaded;
	}

	public List<Row> GetRowList()
	{
		return rowList;
	}

	public void Load(TextAsset csv)
	{
		rowList.Clear();
		string[][] grid = CsvParser2.Parse(csv.text);
		for(int i = 1 ; i < grid.Length ; i++)
		{
			Row row = new Row();
			row.id = grid[i][0];
			row.Word = grid[i][1];
			row.Meaning = grid[i][2];

			rowList.Add(row);
		}
		isLoaded = true;
	}

	public int NumRows()
	{
		return rowList.Count;
	}

	public Row GetAt(int i)
	{
		if(rowList.Count <= i)
			return null;
		return rowList[i];
	}

	public Row Find_id(string find)
	{
		return rowList.Find(x => x.id == find);
	}
	public List<Row> FindAll_id(string find)
	{
		return rowList.FindAll(x => x.id == find);
	}
	public Row Find_Word(string find)
	{
		return rowList.Find(x => x.Word == find);
	}
	public List<Row> FindAll_Word(string find)
	{
		return rowList.FindAll(x => x.Word == find);
	}
	public Row Find_Meaning(string find)
	{
		return rowList.Find(x => x.Meaning == find);
	}
	public List<Row> FindAll_Meaning(string find)
	{
		return rowList.FindAll(x => x.Meaning == find);
	}
}
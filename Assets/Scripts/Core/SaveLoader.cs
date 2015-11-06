using UnityEngine;
using System.Collections;
using System.Collections.Generic; 
using System.Runtime.Serialization.Formatters.Binary; 
using System.IO;

public static class SaveLoader {
	public static List<Game> saves = new List<Game>();

	public static void Save() {
		saves.Add(Game.Current);
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create (Application.persistentDataPath + "/saves.cordy");
		bf.Serialize(file, SaveLoader.saves);
		file.Close();
	}

	public static void Load() {
		if(File.Exists(Application.persistentDataPath + "/saves.cordy")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/saves.cordy", FileMode.Open);
			SaveLoader.saves = (List<Game>)bf.Deserialize(file);
			file.Close();
		}
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic; 
using System.Runtime.Serialization.Formatters.Binary; 
using System.IO;

public static class SaveLoader {
	public static List<Game> saves = new List<Game>();

	public static void Save() {
		saves.Clear ();
		saves.Add(Game.Current);
		BinaryFormatter bf = new BinaryFormatter();

		FileStream file;

		if (Application.isEditor || Application.isWebPlayer) {
			file = File.Create (Application.dataPath + "/saves.xml");
		}
		else {
			file = File.Create (Application.persistentDataPath + "/saves.cordy");
		}
		bf.Serialize(file, SaveLoader.saves);
		file.Close();
	}

	public static void Load() {

		BinaryFormatter bf;
		FileStream file;

		if (Application.isEditor || Application.isWebPlayer) {
			if (File.Exists (Application.dataPath + "/saves.xml")) {
				bf = new BinaryFormatter ();
				file = File.Open (Application.dataPath + "/saves.xml", FileMode.Open);
				SaveLoader.saves = (List<Game>)bf.Deserialize (file);
				file.Close ();
			}
			else {
				Game.Current = new Game(6.0f, 1);
				Save ();
			}
		}
		else {
			if (File.Exists (Application.persistentDataPath + "/saves.cordy")) {
				bf = new BinaryFormatter ();
				file = File.Open (Application.persistentDataPath + "/saves.cordy", FileMode.Open);
				SaveLoader.saves = (List<Game>)bf.Deserialize (file);
				file.Close ();
			}
			else {
				Game.Current = new Game(6.0f, 1);
				Save ();
			}
		}
	}
}

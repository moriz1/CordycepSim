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
			file = File.Create (Application.dataPath + "/SaveData/GameConfig.xml");
		}
		else {
			file = File.Create (Application.persistentDataPath + "/GameConfig.cordy");
		}
		bf.Serialize(file, SaveLoader.saves);
		file.Close();
	}

	public static void CreateGame() {
		if (Application.isEditor || Application.isWebPlayer) {
			if (!File.Exists (Application.dataPath + "/SaveData/GameConfig.xml")) {
				Game.Current = new Game(6.0f, 0);
				Save();
			}
			else {
				Load();
			}
		}
		else {
			if (File.Exists (Application.persistentDataPath + "/GameConfig.cordy")) {
				Game.Current = new Game(6.0f, 0);
				Save();
			}
			else {
				Load();
			}
		}
	}

	public static void Load() {

		BinaryFormatter bf;
		FileStream file;

		if (Application.isEditor || Application.isWebPlayer) {
			if (File.Exists (Application.dataPath + "/SaveData/GameConfig.xml")) {
				bf = new BinaryFormatter ();
				file = File.Open (Application.dataPath + "/SaveData/GameConfig.xml", FileMode.Open);
				SaveLoader.saves = (List<Game>)bf.Deserialize (file);
				file.Close ();
			}
			else {
				Game.Current = new Game(6.0f, 1);
				Save ();
			}
		}
		else {
			if (File.Exists (Application.persistentDataPath + "/GameConfig.cordy")) {
				bf = new BinaryFormatter ();
				file = File.Open (Application.persistentDataPath + "/GameConfig.cordy", FileMode.Open);
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

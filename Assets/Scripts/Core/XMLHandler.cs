using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("CordycepSimRoot")]
public class XMLContainer {
	[XmlArray("CSObjects"), XmlArrayItem("CSObject")]
	public GameObject[] CSObjects;

	public static XMLContainer LoadData(string path) {
		var serializer = new XmlSerializer(typeof(XMLContainer));
		using(var stream = new FileStream(path, FileMode.Open)) {
			return serializer.Deserialize(stream) as XMLContainer;
		}
	}
	
	public static string LoadDataXML(string name) {
		XmlDocument doc = new XmlDocument();
		TextAsset myXmlAsset = Resources.Load<TextAsset>(name);
		doc.LoadXml(myXmlAsset.text);
		
		return doc.OuterXml;
	}
	
	public static string LoadDataString(string s) {
		XmlDocument doc = new XmlDocument ();
		doc.LoadXml (s);
		
		return doc.OuterXml;
	}
	
	public static XMLContainer LoadDataFromText(string text) {
		var serializer = new XmlSerializer(typeof(XMLContainer));
		return serializer.Deserialize(new StringReader(text)) as XMLContainer;
	}
}

public class XMLHandler : MonoBehaviour {
	public static XMLHandler Instance = null;

	void Awake() {
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad (gameObject);
		}
		else if (Instance != null) {
			Destroy(gameObject);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("dialogue")]
public class Dialogue_Settings
{
    [XmlElement("node")]
    public Node[] nodes;

    public static Dialogue_Settings Load(TextAsset _xml)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Dialogue_Settings));
        StringReader reader = new StringReader(_xml.text);
        Dialogue_Settings dial = serializer.Deserialize(reader) as Dialogue_Settings;
        return dial;
    }
}

[System.Serializable]
public class Node
{
    [XmlElement("text")]
    public string text;

    [XmlElement("endnode")]
    public string end;

    [XmlArray("answers")]
    [XmlArrayItem("answer")]
    public Answer[] answers;
}

[System.Serializable]
public class Answer
{
    [XmlAttribute("tonode")]
    public int n;

    [XmlElement ("ans_text")]
    public string anstext;

    [XmlElement("end")]
    public string end;

    [XmlElement("tolevel")]
    public string level;
}

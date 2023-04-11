using System.Xml.Serialization;

namespace TestDemo.Models.Values;

[XmlRoot(ElementName = "item")]
public class Item
{
    [XmlElement(ElementName = "fullname")] public string Fullname { get; set; }

    [XmlElement(ElementName = "title")] public string Title { get; set; }

    [XmlElement(ElementName = "description")]
    public double Description { get; set; }

    [XmlElement(ElementName = "quant")] public int Quant { get; set; }

    [XmlElement(ElementName = "index")] public string Index { get; set; }

    [XmlElement(ElementName = "change")] public double Change { get; set; }
}
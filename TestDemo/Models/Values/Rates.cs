using System.Xml.Serialization;
using TestDemo.Models.Entities;

namespace TestDemo.Models.Values;

[XmlRoot(ElementName="rates")]
public class Rates {

    [XmlElement(ElementName="generator")] 
    public string Generator { get; set; } 

    [XmlElement(ElementName="title")] 
    public string Title { get; set; } 

    [XmlElement(ElementName="link")] 
    public string Link { get; set; } 

    [XmlElement(ElementName="description")] 
    public string Description { get; set; } 

    [XmlElement(ElementName="copyright")] 
    public string Copyright { get; set; } 

    [XmlElement(ElementName="date")] 
    public string Date  { get; set; } 

    [XmlElement(ElementName="item")] 
    public List<Item> Items { get; set; } 
}
namespace Powerumc.RssFeeds.Domain.Responses.V1
{
	using System.Xml.Serialization;
	using System.Collections.Generic;

	[XmlRoot(ElementName = "image")]
	public class Image
	{
		[XmlElement(ElementName = "title")] public string Title { get; set; }
		[XmlElement(ElementName = "url")] public string Url { get; set; }
		[XmlElement(ElementName = "link")] public string Link { get; set; }

		[XmlElement(ElementName = "description")]
		public string Description { get; set; }
	}

	[XmlRoot(ElementName = "item")]
	public class Item
	{
		[XmlElement(ElementName = "title")] public string Title { get; set; }
		[XmlElement(ElementName = "link")] public string Link { get; set; }

		[XmlElement(ElementName = "description")]
		public string Description { get; set; }

		[XmlElement(ElementName = "category")] public List<string> Category { get; set; }
		[XmlElement(ElementName = "author")] public string Author { get; set; }
		[XmlElement(ElementName = "guid")] public string Guid { get; set; }
		[XmlElement(ElementName = "comments")] public string Comments { get; set; }
		[XmlElement(ElementName = "pubDate")] public string PubDate { get; set; }
	}

	[XmlRoot(ElementName = "channel")]
	public class Channel
	{
		[XmlElement(ElementName = "title")] public string Title { get; set; }
		[XmlElement(ElementName = "link")] public string Link { get; set; }

		[XmlElement(ElementName = "description")]
		public string Description { get; set; }

		[XmlElement(ElementName = "language")] public string Language { get; set; }
		[XmlElement(ElementName = "pubDate")] public string PubDate { get; set; }

		[XmlElement(ElementName = "generator")]
		public string Generator { get; set; }

		[XmlElement(ElementName = "managingEditor")]
		public string ManagingEditor { get; set; }

		[XmlElement(ElementName = "image")] public Image Image { get; set; }
		[XmlElement(ElementName = "item")] public List<Item> Item { get; set; }
	}

	[XmlRoot(ElementName = "rss")]
	public class Rss
	{
		[XmlElement(ElementName = "channel")] public Channel Channel { get; set; }

		[XmlAttribute(AttributeName = "version")]
		public string Version { get; set; }
	}

}
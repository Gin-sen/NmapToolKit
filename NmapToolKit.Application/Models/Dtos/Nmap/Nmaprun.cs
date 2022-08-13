using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NmapToolKit.Application.Models.Dtos.Nmap
{

	[XmlRoot(ElementName = "nmaprun")]
	public class Nmaprun
	{

		[XmlElement(ElementName = "verbose")]
		public Verbose? Verbose { get; set; }

		[XmlElement(ElementName = "debugging")]
		public Debugging? Debugging { get; set; }

		[XmlElement(ElementName = "host")]
		public Host? Host { get; set; }

		[XmlElement(ElementName = "runstats")]
		public Runstats? Runstats { get; set; }

		[XmlAttribute(AttributeName = "scanner")]
		public string? Scanner { get; set; }

		[XmlAttribute(AttributeName = "args")]
		public string? Args { get; set; }

		[XmlAttribute(AttributeName = "start")]
		public int Start { get; set; }

		[XmlAttribute(AttributeName = "startstr")]
		public string? Startstr { get; set; }

		[XmlAttribute(AttributeName = "version")]
		public double Version { get; set; }

		[XmlAttribute(AttributeName = "xmloutputversion")]
		public double Xmloutputversion { get; set; }
	}


	[XmlRoot(ElementName = "verbose")]
	public class Verbose
	{

		[XmlAttribute(AttributeName = "level")]
		public int Level { get; set; }
	}

	[XmlRoot(ElementName = "debugging")]
	public class Debugging
	{

		[XmlAttribute(AttributeName = "level")]
		public int Level { get; set; }
	}

	[XmlRoot(ElementName = "status")]
	public class Status
	{

		[XmlAttribute(AttributeName = "state")]
		public string? State { get; set; }

		[XmlAttribute(AttributeName = "reason")]
		public string? Reason { get; set; }

		[XmlAttribute(AttributeName = "reason_ttl")]
		public int ReasonTtl { get; set; }
	}

	[XmlRoot(ElementName = "address")]
	public class Address
	{

		[XmlAttribute(AttributeName = "addr")]
		public string? Addr { get; set; }

		[XmlAttribute(AttributeName = "addrtype")]
		public string? Addrtype { get; set; }
	}

	[XmlRoot(ElementName = "hostname")]
	public class Hostname
	{

		[XmlAttribute(AttributeName = "name")]
		public string? Name { get; set; }

		[XmlAttribute(AttributeName = "type")]
		public string? Type { get; set; }
	}

	[XmlRoot(ElementName = "hostnames")]
	public class Hostnames
	{

		[XmlElement(ElementName = "hostname")]
		public List<Hostname>? Hostname { get; set; }
	}

	[XmlRoot(ElementName = "host")]
	public class Host
	{

		[XmlElement(ElementName = "status")]
		public Status? Status { get; set; }

		[XmlElement(ElementName = "address")]
		public Address? Address { get; set; }

		[XmlElement(ElementName = "hostnames")]
		public Hostnames? Hostnames { get; set; }
	}

	[XmlRoot(ElementName = "finished")]
	public class Finished
	{

		[XmlAttribute(AttributeName = "time")]
		public int Time { get; set; }

		[XmlAttribute(AttributeName = "timestr")]
		public string? Timestr { get; set; }

		[XmlAttribute(AttributeName = "elapsed")]
		public double Elapsed { get; set; }

		[XmlAttribute(AttributeName = "summary")]
		public string? Summary { get; set; }

		[XmlAttribute(AttributeName = "exit")]
		public string? Exit { get; set; }
	}

	[XmlRoot(ElementName = "hosts")]
	public class Hosts
	{

		[XmlAttribute(AttributeName = "up")]
		public int Up { get; set; }

		[XmlAttribute(AttributeName = "down")]
		public int Down { get; set; }

		[XmlAttribute(AttributeName = "total")]
		public int Total { get; set; }
	}

	[XmlRoot(ElementName = "runstats")]
	public class Runstats
	{

		[XmlElement(ElementName = "finished")]
		public Finished? Finished { get; set; }

		[XmlElement(ElementName = "hosts")]
		public Hosts? Hosts { get; set; }
	}




}

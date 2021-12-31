using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using topology_op_CSharp;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Dynamic;

namespace topology_op_CSharp
{
    public class Topology
    {
		public Topology()
		{
			id = "";
		}
		[JsonProperty("id")]
		private string id { get; set; }

		[JsonProperty("components")]
		private List<Component2> components = new List<Component2>();
		public void AddDevice(string type, int max, int min, int defal, string id, List<string> pino)
		{
			if (type == "resistor")
			{
				Resistor r = new Resistor(max, min, defal, id, pino);
				components.Add(r);
			}
			else if (type == "inductor")
			{
				Inductor i = new Inductor(max, min, defal, id, pino);
				components.Add(i);
			}
			else if (type == "capacitor")
			{
				Capacitor c = new Capacitor(max, min, defal, id, pino);
				components.Add(c);
			}
			else if (type == "nmos")
			{
				Nmos r = new Nmos(max, min, defal, id, pino);
				components.Add(r);
			}
			else if (type == "pmos")
			{
				Pmos p = new Pmos(max, min, defal, id, pino);
				components.Add(p);
			}
		}

		public List<Component2> GetDevices()
		{
			return this.components;
		}

		public void Setid(string d)
		{
			this.id = d;
		}
		public string Getid()
		{
			return this.id;
		}
	}
}

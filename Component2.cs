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
    public abstract class Component2 
    {
		public Component2()
		{
			max = 0;
			min = 0;
			defal = 0;
			id = "";
		}
		public Component2(Component2 c)
		{
			max = c.max;
			min = c.min;
			defal = c.defal;
			id = c.id;
		}
		public new string GetType()
		{
			return type;
		}
		public int Getmin()
		{
			return min;
		}
		public int Getmax()
		{
			return max;
		}
		public int Getdefal()
		{
			return defal;
		}
		public string Getid()
		{
			return id;
		}
		public List<string> GetpinsValue()
		{
			return pins;
		}

		public void Setmin(int x)
		{
			min = x;
		}
		public void Setmax(int x)
		{
			max = x;
		}
		public void Setdefal(int x)
		{
			defal = x;
		}
		public void Setid(string d)
		{
			id = d;
		}
		public void Settype(string t)
		{
			type = t;
		}
		void SetPinsValue(List<string> pino)
		{
			;
		}
		[JsonProperty("netlist")]
		protected List<string> pins = new List<string>();

		[JsonProperty("type")]
		protected string type { set; get; }

		[JsonProperty("id")]
		protected string id { set; get; }

		[JsonProperty("default")]
		protected int defal { set; get; }

		[JsonProperty("min")]
		protected int min { set; get; }

		[JsonProperty("max")]
		protected int max { set; get; }

		protected int num_of_pins { set; get; }
	}
}

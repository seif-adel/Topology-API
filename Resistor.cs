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
	public class Resistor : Component2
	{
		public Resistor(int maxo, int mino, int defalo, string ido, List<string> pino)
		{
			max = maxo;
			min = mino;
			defal = defalo;
			id = ido;
			SetPinsValue(pino);
			Settype("resistor");
		}

		public void SetPinsValue(List<string> p)
		{
			num_of_pins = 2;
			for (int i = 0; i < 2; i++)
			{
				pins.Add(p[i]);
			}
		}
		public List<string> GetPinsValue()
		{
			return pins;
		}
	}

}

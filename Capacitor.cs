using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace topology_op_CSharp
{
	public class Capacitor : Component2
	{
		public Capacitor(int maxo, int mino, int defalo, string ido, List<string> pino)
		{
			max = maxo;
			min = mino;
			defal = defalo;
			id = ido;
			SetPinsValue(pino);
			Settype("capacitor");
		}

		public void SetPinsValue(List<string> p)
		{
			num_of_pins = 2;
			for (int i = 0; i < 2; i++)
			{
				pins[i] = p[i];
			}
		}
		public List<string> GetPinsValue()
		{
			return pins;
		}
	}
}

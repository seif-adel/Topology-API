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
	internal class Program
	{
		static void Main(string[] args)
		{
			APIS a = new APIS();
			a.readJSON(@"C:\Users\HP\Desktop\quarantine\micro task2\New folder\file1.json");
			a.readJSON(@"C:\Users\HP\Desktop\quarantine\micro task2\New folder\file2.json");
			List<Topology> loc = a.querytopologies();
			List<Component2> loc2 = a.QueryDevices("top2");
			List<Component2> loc3 = a.queryDevicesWithNetListNode("top2", "n3");
			a.writeJSON("top2",@"C:\Users\HP\Desktop\quarantine\micro task2\topology_op_CSharp\topology_op_CSharp\json files\file5.json");
		}
	}
}

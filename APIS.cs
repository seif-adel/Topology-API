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
    internal class APIS
    {

		/// 
		/// ////////////// the main array of topologies which represent the memory of the program
		/// </summary>
		private List<Topology> memtopologies = new List<Topology>();

		/// 1)
		/// /////////// first API to take path of json file and convert it into topology and add it to the memory
		/// </summary>
		public void readJSON(string filepath)
		{
			var jsonstring = File.ReadAllText(filepath);
			dynamic jsonFile = JsonConvert.DeserializeObject(jsonstring);
			JArray j = jsonFile["components"];
			Topology t = new Topology();
			t.Setid((string)jsonFile["id"]);
			foreach (JObject item in j)
			{
				string type_of_item = item.GetValue("type").ToString();
				if (type_of_item == "resistor")
				{
					int max_item = (int)(item.SelectToken("resistance.max"));
					int min_item = (int)(item.SelectToken("resistance.min"));
					int defal_item = (int)(item.SelectToken("resistance.default"));
					string id_item = (string)(item.SelectToken("id"));
					List<string> arrr = new List<string>() { (string)(item.SelectToken("netlist.t1")), (string)(item.SelectToken("netlist.t2")) };
					t.AddDevice(type_of_item, max_item, min_item, defal_item, id_item, arrr);
				}
				else if (type_of_item == "inductor")
				{
					int max_item = (int)(item.SelectToken("inductor.max"));
					int min_item = (int)(item.SelectToken("inductor.min"));
					int defal_item = (int)(item.SelectToken("inductor.default"));
					string id_item = (string)(item.SelectToken("id"));
					List<string> arrr = new List<string>() { (string)(item.SelectToken("netlist.t1")), (string)(item.SelectToken("netlist.t2")) };
					t.AddDevice(type_of_item, max_item, min_item, defal_item, id_item, arrr);
				}

				else if (type_of_item == "capacitor")
				{
					int max_item = (int)(item.SelectToken("capacitor.max"));
					int min_item = (int)(item.SelectToken("capacitor.min"));
					int defal_item = (int)(item.SelectToken("capacitor.default"));
					string id_item = (string)(item.SelectToken("id"));
					List<string> arrr = new List<string>() { (string)(item.SelectToken("netlist.t1")), (string)(item.SelectToken("netlist.t2")) };
					t.AddDevice(type_of_item, max_item, min_item, defal_item, id_item, arrr);
				}

				else if (type_of_item == "nmos")
				{
					string id_item = (string)(item.SelectToken("id"));
					string temp = id_item[0] + "-" + id_item[1] + "-";
					JToken temp2 = item.SelectToken(temp);
					int max_item = (int)(temp2.SelectToken("max"));
					int min_item = (int)(temp2.SelectToken("min"));
					float defal_item = (float)(temp2.SelectToken("default"));
					List<string> arrr = new List<string>() { (string)(item.SelectToken("netlist.drain")), (string)(item.SelectToken("netlist.gate")), (string)(item.SelectToken("netlist.source")) };
					t.AddDevice(type_of_item, max_item, min_item, (int)defal_item, id_item, arrr);
				}
				else if (type_of_item == "pmos")
				{
					string id_item = (string)(item.SelectToken("id"));
					string temp = id_item[0] + "-" + id_item[1] + "-";
					JToken temp2 = item.SelectToken(temp);
					int max_item = (int)(temp2.SelectToken("max"));
					int min_item = (int)(temp2.SelectToken("min"));
					float defal_item = (float)(temp2.SelectToken("default"));
					List<string> arrr = new List<string>() { (string)(item.SelectToken("netlist.drain")), (string)(item.SelectToken("netlist.gate")), (string)(item.SelectToken("netlist.source")) };
					t.AddDevice(type_of_item, max_item, min_item, (int)defal_item, id_item, arrr);
				}
			}
			memtopologies.Add(t);
		}

		/// 2) 
		/// //////////// second API to return the whole topologies stored in memory
		/// </summary>
		/// <returns></returns>
		public List<Topology> querytopologies()
		{
			return memtopologies;
		}
		/// 3)
		/// ////////// third API to delete specific topology from the memory and return it to the user if found 
		/// otherwise return null 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Topology deletetopology(string id)
		{
			Topology t = null;
			for (int i = 0; i < memtopologies.Count; i++)
			{
				if (memtopologies[i].Getid() == id)
				{
					t = memtopologies[i];
					memtopologies.RemoveAt(i);
					return t;
				}
			}
			return t;
		}
		/// 4)
		/// ///////////// fourth API to get all the devices in specific topology
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public List<Component2> QueryDevices(string id)
		{
			List<Component2> res = new List<Component2>();
			Topology t = new Topology();
			for (int i = 0; i < memtopologies.Count; i++)
			{
				if (memtopologies[i].Getid() == id)
				{
					t = memtopologies[i];
					res = t.GetDevices();
					break;
				}
			}
			return res;
		}
		/// 5) fifth API to return list of fevices in specific topology which connected to specific node
		/// ///////
		/// </summary>
		/// <param name="topologyID"></param>
		/// <param name="netlistnodeID"></param>
		/// <returns></returns>
		public List<Component2> queryDevicesWithNetListNode(string topologyID, string netlistnodeID)
		{
			List<Component2> res = new List<Component2>();
			Topology t = new Topology();
			for (int i = 0; i < memtopologies.Count; i++)
			{
				if (memtopologies[i].Getid() == topologyID)
				{
					t = memtopologies[i];
					break;
				}
			}

			for (int i = 0; i < t.GetDevices().Count; i++)
			{
				List<string> temp = t.GetDevices()[i].GetpinsValue();
				for (int j = 0; j < temp.Count; j++)
				{
					if (temp[j] == netlistnodeID)
						res.Add(t.GetDevices()[i]);
				}
			}
			return res;
		}
		/// 6) write specific topology in json file 
		/// ////////////////
		/// </summary>
		/// <param name="topologyID"></param>
		public void writeJSON(string topologyID, string path)
		{

			Topology t = new Topology();
			for (int i = 0; i < memtopologies.Count; i++)
			{
				if (memtopologies[i].Getid() == topologyID)
				{
					t = memtopologies[i];
					break;
				}
			}
			dynamic obj = new ExpandoObject();
			obj.id = t.Getid();
			obj.components = new dynamic[t.GetDevices().Count];
			for (int i = 0; i < t.GetDevices().Count; i++)
			{
				obj.components[i] = new ExpandoObject();
				obj.components[i].type = t.GetDevices()[i].GetType();
				obj.components[i].id = t.GetDevices()[i].Getid();
				if (t.GetDevices()[i].GetType() == "resistor")
				{
					obj.components[i].resistance = new ExpandoObject();
					obj.components[i].resistance.defaul = t.GetDevices()[i].Getdefal();
					obj.components[i].resistance.min = t.GetDevices()[i].Getmin();
					obj.components[i].resistance.max = t.GetDevices()[i].Getmax();
					obj.components[i].netlist = new ExpandoObject();
					obj.components[i].netlist.t1 = t.GetDevices()[i].GetpinsValue()[0];
					obj.components[i].netlist.t2 = t.GetDevices()[i].GetpinsValue()[1];
				}
				else if (t.GetDevices()[i].GetType() == "inductor")
				{
					obj.components[i].inductor = new ExpandoObject();
					obj.components[i].inductor.defaul = t.GetDevices()[i].Getdefal();
					obj.components[i].inductor.min = t.GetDevices()[i].Getmin();
					obj.components[i].inductor.max = t.GetDevices()[i].Getmax();
					obj.components[i].netlist = new ExpandoObject();
					obj.components[i].netlist.t1 = t.GetDevices()[i].GetpinsValue()[0];
					obj.components[i].netlist.t2 = t.GetDevices()[i].GetpinsValue()[1];
				}
				else if (t.GetDevices()[i].GetType() == "capacitor")
				{
					obj.components[i].capacitor = new ExpandoObject();
					obj.components[i].capacitor.defaul = t.GetDevices()[i].Getdefal();
					obj.components[i].capacitor.min = t.GetDevices()[i].Getmin();
					obj.components[i].capacitor.max = t.GetDevices()[i].Getmax();
					obj.components[i].netlist = new ExpandoObject();
					obj.components[i].netlist.t1 = t.GetDevices()[i].GetpinsValue()[0];
					obj.components[i].netlist.t2 = t.GetDevices()[i].GetpinsValue()[1];
				}
				else if (t.GetDevices()[i].GetType() == "nmos")
				{
					obj.components[i].nmos = new ExpandoObject();
					obj.components[i].nmos.defaul = t.GetDevices()[i].Getdefal();
					obj.components[i].nmos.min = t.GetDevices()[i].Getmin();
					obj.components[i].nmos.max = t.GetDevices()[i].Getmax();
					obj.components[i].netlist = new ExpandoObject();
					obj.components[i].netlist.drain = t.GetDevices()[i].GetpinsValue()[0];
					obj.components[i].netlist.gate = t.GetDevices()[i].GetpinsValue()[1];
					obj.components[i].netlist.source = t.GetDevices()[i].GetpinsValue()[2];
				}
				else if (t.GetDevices()[i].GetType() == "pmos")
				{
					obj.components[i].pmos = new ExpandoObject();
					obj.components[i].pmos.defaul = t.GetDevices()[i].Getdefal();
					obj.components[i].pmos.min = t.GetDevices()[i].Getmin();
					obj.components[i].pmos.max = t.GetDevices()[i].Getmax();
					obj.components[i].netlist = new ExpandoObject();
					obj.components[i].netlist.drain = t.GetDevices()[i].GetpinsValue()[0];
					obj.components[i].netlist.gate = t.GetDevices()[i].GetpinsValue()[1];
					obj.components[i].netlist.source = t.GetDevices()[i].GetpinsValue()[2];
				}
			}
			string res = JsonConvert.SerializeObject(obj);
			System.IO.File.WriteAllText(path, res);
		}
	}
}


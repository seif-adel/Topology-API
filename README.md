# Topology-API
The project is aim to develop some APIs which facilitate the dealing with JSON files in c#

introduction:
1) the project is implemented in object oriented manner
2) the project is implemented using c# as it provied easy way to treat with json libraries and it facillitate the process of developing program in object oriented manner

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

instructions: 
1) you need to download visual studio using c# with .NET version 4.7.2 or more 
2) you need to download Newtonsoft.Json to run this project 
3) you must enter json file with format like the sample downloaded in repo otherwies the data will not saved correctly 
4) the project support the devices [ resistor - inductor - capacitor - nmos - pmos ] only to be in topologies but you can edit it and add any other component 

////////////////////////// documentaions of APIS //////////////////////////////////////////////////////////////////////////////

 /************************************************************************************
1)
* Service Name: readJSON
* Parameters (in): string filepath --> which represent the path of json file you want to fetch 
* Return value: None
* Description: Function to fetch data from json file and save this data in array of topologies which represent memory in our project.
************************************************************************************/
2)
* Service Name: writeJSON
* Parameters (in): string filepath --> which represent the path of JSON file you want to write the data in it 
                   string TopologyID --> which represent the ID of specific topology you want to save it's data in JSON file                
* Return value: None
* Description: Function to write data of specific topology in JSON file .
************************************************************************************/
3)
* Service Name: querytopologies
* Parameters (in): None
* Return value: List of topologies found in memory 
* Description: Function to return list of topologies which stored in our memory which represented in list
************************************************************************************/
4)
* Service Name: deletetopology
* Parameters (in): string id --> which represent the id of topology you want to delete from memory
* Return value: the topology which has been deleted from memory
* Description: Function to take specific id of topology and then search about this topology in memory then delete it and return it to the user.
************************************************************************************/
5)
* Service Name: QueryDevices
* Parameters (in): string id --> which represent the ID of topology you want to know it's devices
* Return value: List of devices found in this topology
* Description: Function to fetch return all the devices stored in specific topology 
************************************************************************************/
6)
* Service Name: queryDevicesWithNetListNode
* Parameters (in): string id --> which represent the ID of topology
                   string netlistnodeID --> which represent the name of node                 
* Return value: List of devices
* Description: Function to return all the devices found in specific topology and connected to specific node 
************************************************************************************/

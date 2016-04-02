using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IH_Restaurant_POS
{
    public class Server
    {
        /// <summary>
        /// Server's Name
        /// </summary>
        string name;

        /// <summary>
        /// Server's Number
        /// </summary>
        int number;

        /// <summary>
        /// List of Tables assigned to Server
        /// </summary>
        List<Table> tables;

        /// <summary>
        /// List of Daily Sales
        /// </summary>
        List<Bill> Sales;

        /// <summary>
        /// Server Class Consturctor
        /// </summary>
        /// <param name="name">Server Name</param>
        /// <param name="number">Server Number</param>
        public Server(string name, int number)
        {
            this.name = name;
            this.number = number;

            tables = new List<Table>();
            Sales = new List<Bill>();
        }
           
        /// <summary>
        /// Add a Table to Server's List
        /// </summary>
        /// <param name="newTable"></param>
        public void AddTable(Table newTable)
        {
            tables.Add(newTable);
        }
        
        /// <summary>
        /// Return Server's Name
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
        } 
    }
}

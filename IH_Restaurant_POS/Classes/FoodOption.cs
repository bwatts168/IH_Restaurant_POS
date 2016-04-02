using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IH_Restaurant_POS
{
    /// <summary>
    /// Food Item Options 
    /// Changes to the Food per Customer
    /// </summary>
    public class FoodOption
    {
        /// <summary>
        /// Food Option's Name
        /// </summary>
        string name;

        /// <summary>
        /// Food Option's Cost
        /// </summary>
        double cost;
        
        /// <summary>
        /// Food Options Class Consturtor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="cost"></param>
        public FoodOption(string name, double cost)
        {
            this.name = name;
            this.cost = cost;
        }
        
        /// <summary>
        /// Return Food Option's Name
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
        }

        /// <summary>
        /// Return Food Option's Cost
        /// </summary>
        public double Cost
        {
            get
            {
                return cost;
            }
        }
    }
}

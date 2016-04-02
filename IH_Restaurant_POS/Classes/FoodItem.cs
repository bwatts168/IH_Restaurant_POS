using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IH_Restaurant_POS
{
    /// <summary>
    /// Food Item on Menu per Category
    /// </summary>
    public class FoodItem
    {
        /// <summary>
        /// Food Item's Name
        /// </summary>
        List<string> name;

        /// <summary>
        /// Food Item's Cost
        /// </summary>
        List<double> cost;

        /// <summary>
        /// List of Options for Food Item
        /// </summary>
        List<FoodOption> options;

        //Food Item's Class Constructor
        public FoodItem(string name, double cost)
        {
            this.name = new List<string>();
            this.cost = new List<double>();
            this.name.Add(name);
            this.cost.Add(cost);
            options = new List<FoodOption>(); //Prepare List of Food Options
        }

        /// <summary>
        /// Add Options to Food Item
        /// </summary>
        /// <param name="option"></param>
        public void AddFoodOption(FoodOption newOption)
        {
            options.Add(newOption);
            name.Add("  - " + options[options.Count -1].Name);
            cost.Add(options[options.Count -1].Cost);
        }

        /// <summary>
        /// Return Food Item's Name
        /// </summary>
        public List<string> FoodandOptionsName()
        {
            return name;            
        }

        /// <summary>
        /// Return Food Item's Cost
        /// </summary>
        /// <returns></returns>
        public List<double> Cost()
        {
            return cost;
        }
    }
}

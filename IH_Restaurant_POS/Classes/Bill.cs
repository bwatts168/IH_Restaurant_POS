using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IH_Restaurant_POS
{
    /// <summary>
    /// Customers Bill
    /// </summary>
    public class Bill
    {
        /// <summary>
        /// Guest Number of the table
        /// </summary>
        int guestNumber;
                
        /// <summary>
        /// Bill subtotal
        /// </summary>
        double subtotal;

        /// <summary>
        /// Array of Food ordered by Customer
        /// </summary>
        List<FoodItem> foodItems;
                
        /// <summary>
        /// Bill Class Constructor
        /// </summary>
        public Bill(int guestNumber)
        {
            this.subtotal = 0;                        
            this.guestNumber = guestNumber;
            foodItems = new List<FoodItem>(); //Prepares Food Items List
        }
        
        /// <summary>
        /// Add Food Item to Bill
        /// </summary>
        /// <param name="newFoodItem"></param>
        /// <param name="cost"></param>
        public void AddFoodToBill(FoodItem newFoodItem)
        {
            foodItems.Add(newFoodItem);
            CalculateTotalBill();     
        }
        
        /// <summary>
        ///Calculates Total Bill
        /// </summary>
        /// <returns>Subtotal, tax, and Bill Total</returns>
        private void CalculateTotalBill()
        {
            if (subtotal != 0)
            {
                subtotal = 0;
            }
            foreach (FoodItem fo in foodItems)
            {
                foreach (double d in fo.Cost())
                {
                    subtotal += d;
                }
            }  
        }

        /// <summary>
        /// Itemize Bill for Table
        /// </summary>
        /// <returns></returns>
        public string ItemizedBill()
        {
            string bill;

            //Header            
            bill = String.Format("{0, 19}\n\n", "Guest " + guestNumber);


            foreach (FoodItem fo in foodItems)
            {
                for (int i = 0; i < fo.FoodandOptionsName().Count; i++)
                {
                    if (fo.Cost()[i] == 0)
                    {
                        bill += String.Format("{0, -20} {1, 10}\n", fo.FoodandOptionsName()[i], " ");
                    }
                    else
                    {
                        bill += String.Format("{0, -20} {1, 10}\n", fo.FoodandOptionsName()[i], fo.Cost()[i].ToString("c"));
                    }
                    
                }
            }

            bill += "-------------------------------\n";
            bill += String.Format("{0, -20} {1, 10}\n\n", "Subtotal:", subtotal.ToString("c"));
            

            return bill;
        }
        
        /// <summary>
        /// Return Subtotal of Guest's Bill
        /// </summary>
        public double Subtotal
        {
            get
            {
                return subtotal;
            }
        }
    }
}

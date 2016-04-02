using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IH_Restaurant_POS 
{
    /// <summary>
    /// Tables in Restaurant
    /// </summary>
    public class Table
    {
        /// <summary>
        /// Table Number
        /// </summary>
        int number;

        /// <summary>
        /// Bills Sequencal Number
        /// </summary>
        int billNumber;

        /// <summary>
        /// List of Bills per Customer 
        /// </summary>
        List<Bill> guests;

        /// <summary>
        /// Tables Total Bill Amount
        /// </summary>
        double totalBill;

        /// <summary>
        /// Table Class Consturctor
        /// </summary>
        /// <param name="number"></param>
        public Table(int number)
        {            
            this.number = number;
            guests = new List<Bill>(); //Prepares Guest's Bill List
        }

        /// <summary>
        /// Add Guest to table
        /// </summary>
        /// <param name="newGuest"></param>
        public void AddGuest(Bill newGuest)
        {
            guests.Add(newGuest);
        }
        
        /// <summary>
        /// Prints Recipt
        /// Options - Full Table, Divided, or Single
        /// </summary>
        /// <param name="guestNumbers"></param>
        /// <returns></returns>
        public List<string> PrintRecipt(int[] guestNumbers)
        {
            Properties.Settings.Default.BillNumber++;
            billNumber = Properties.Settings.Default.BillNumber;

            double subtotal = 0;

            List<string> recipt = new List<string>();

            recipt.Add(printHeader());
                        
            foreach (int i in guestNumbers)
            {
                subtotal += guests[i -1].Subtotal;
                recipt.Add(getGuestRecipt(i - 1));                
            }

            totalBill = (subtotal * (1.055));

            string reciptEnd = "\n-------------------------------\n";
            reciptEnd += String.Format("{0, -20} {1, 10}\n\n", "Subtotal:", subtotal.ToString("c"));
            reciptEnd += String.Format("{0, -20} {1, 10}\n\n", "Tax:", (subtotal * .055).ToString("c"));
            reciptEnd += String.Format("{0, -20} {1, 10}\n\n", "Total:", totalBill.ToString("c"));

            recipt.Add(reciptEnd);

            return recipt;

        }

        /// <summary>
        /// Print Single Guest Recipt
        /// </summary>
        /// <param name="guest">Enter Guest Number</param>
        /// <returns>Guest Ordered Bill</returns>
        private string getGuestRecipt(int guest)
        {
            return guests[guest].ItemizedBill();
        }

        /// <summary>
        /// Creates Company Header and Table Number to All Recipts
        /// </summary>
        /// <returns></returns>
        private string printHeader()
        {
            string header = String.Format("{0, 22}\n", "IH POS Systems");
            header += String.Format("{0, 19}\n", "Table " + number);
            header += String.Format("{0, 25}\n", "Recipt Number: " + billNumber);

            return header;
        }

        /// <summary>
        /// Calculates Total for Entire Table
        /// </summary>
        /// <returns></returns>
        private double[] CalculateTotals()
        {
            double subTotal = 0;
            double tax = .055;
            double billtax;
            double total;

            foreach (Bill b in guests)
            {
                subTotal += b.Subtotal;
            }

            billtax = subTotal * tax;
            total = subTotal + billtax;
            totalBill = total;

            return new double[] { subTotal, billtax, total };          
        }

        /// <summary>
        /// Return Tables Total Bill 
        /// </summary>
        public double TotalBill
        {
            get
            {
                return totalBill;
            }
        }

        /// <summary>
        /// Return Tables Number
        /// </summary>
        public int Number
        {
            get
            {
                return number;
            }
        }

        /// <summary>
        /// Returns Tables Bill Number
        /// </summary>
        public int BillNumber
        {
            get
            {
                return billNumber;
            }
        }
      
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book_Using_Linq
{
    class AddressBookDataTable
    {
        //Creating DataTable for addressbook problem UC1
        DataTable dataTable = new DataTable();

        /// Create the Address Book table and add attributes.

        public void createAddressBookTable()
        {
            dataTable.Columns.Add("FirstName", typeof(string));
            dataTable.Columns.Add("LastName", typeof(string));
            dataTable.Columns.Add("Address", typeof(string));
            dataTable.Columns.Add("City", typeof(string));
            dataTable.Columns.Add("State", typeof(string));
            dataTable.Columns.Add("ZipCode", typeof(int));
            dataTable.Columns.Add("PhoneNumber", typeof(long));
            dataTable.Columns.Add("Email", typeof(string));
            dataTable.Rows.Add("Himanshu", "Kholiya", "Pune", "Pune", "Maharashtra", 400705, 9987932434, "kholiyahimanshu2@gmail.com");
            dataTable.Rows.Add("Om", "Kawasaki", "Pune", "Pune", "Maharashtra", 400701, 9987932434, "omprakash@gmail.com");
            dataTable.Rows.Add("Vishal", "Singh", "Bhandup", "Navimumbai", "Maharashtra", 400703, 9987932434, "vishal@gmail.com");
            dataTable.Rows.Add("Krunal", "Kamble", "Sangli", "Karad", "Maharashtra", 400710, 9987932434, "krunal@gmail.com");
            dataTable.Rows.Add("Harshpal", "Singh", "Chamoli", "Chamoli", "Uttrakhand", 400703, 9987932434, "harshpal@gmail.com");
            dataTable.Rows.Add("Gaurav", "Kholiya", "Didihat", "Pithoragarh", "Uttrakhand", 400701, 9987932434, "gaurav@gmail.com");
            dataTable.Rows.Add("Ankita", "Patil", "Pune", "pune", "Maharashtra", 400701, 9987932434, "patil@gmail.com");
            displayAddressBook();
        }

        public void displayAddressBook()
        {
            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine("\nFirstName:-" + row.Field<string>("FirstName"));
                Console.WriteLine("LastName:-" + row.Field<string>("LastName"));
                Console.WriteLine("Address:-" + row.Field<string>("Address"));
                Console.WriteLine("City:-" + row.Field<string>("City"));
                Console.WriteLine("State:-" + row.Field<string>("State"));
                Console.WriteLine("ZipCode:-" + row.Field<int>("ZipCode"));
                Console.WriteLine("PhoneNumber:-" + row.Field<long>("PhoneNumber"));
                Console.WriteLine("Email:-" + row.Field<string>("Email"));
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***************Welcome To AddressBook Using Linq*************");
            AddressBookDataTable addressBookDataTable = new AddressBookDataTable();
            addressBookDataTable.createAddressBookTable();
            Console.Read();
        }
    }

}
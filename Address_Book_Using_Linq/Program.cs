using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book_Using_Linq
{
    public class AddressBookDataTable
    {
        //Creating DataTable for addressbook problem UC1
        DataTable dataTable = new DataTable();

        /// Create the Address Book table and add attributes.

        public DataTable createAddressBookTable()
        {
            dataTable.Columns.Add("FirstName", typeof(string));
            dataTable.Columns.Add("LastName", typeof(string));
            dataTable.Columns.Add("Address", typeof(string));
            dataTable.Columns.Add("City", typeof(string));
            dataTable.Columns.Add("State", typeof(string));
            dataTable.Columns.Add("ZipCode", typeof(int));
            dataTable.Columns.Add("PhoneNumber", typeof(long));
            dataTable.Columns.Add("Email", typeof(string));

            /*UC3:-Ability to insert new Contacts to Address Book */
            dataTable.Rows.Add("Himanshu", "Kholiya", "Pune", "Pune", "Maharashtra", 400705, 9987932434, "kholiyahimanshu2@gmail.com");
            dataTable.Rows.Add("Om", "Kawasaki", "Pune", "Pune", "Maharashtra", 400701, 9987932434, "omprakash@gmail.com");
            dataTable.Rows.Add("Vishal", "Singh", "Bhandup", "Navimumbai", "Maharashtra", 400703, 9987932434, "vishal@gmail.com");
            dataTable.Rows.Add("Krunal", "Kamble", "Sangli", "Karad", "Maharashtra", 400710, 9987932434, "krunal@gmail.com");
            dataTable.Rows.Add("Harshpal", "Singh", "Chamoli", "Chamoli", "Uttrakhand", 400703, 9987932434, "harshpal@gmail.com");
            dataTable.Rows.Add("Gaurav", "Kholiya", "Didihat", "Pithoragarh", "Uttrakhand", 400701, 9987932434, "gaurav@gmail.com");
            dataTable.Rows.Add("Ankita", "Patil", "Pune", "pune", "Maharashtra", 400701, 9987932434, "patil@gmail.com");
            // displayAddressBook();
            return dataTable;
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
        public void addContact(Contact contact)
        {
            dataTable.Rows.Add(contact.FirstName, contact.LastName, contact.Address, contact.City,
            contact.State, contact.ZipCode, contact.PhoneNumber, contact.Email);
            Console.WriteLine("Added contact successfully");
        }

           /*UC4:- Ability to edit existing contact person using their name*/
        public void editContact(DataTable dataTable)
        {
            var recordData = dataTable.AsEnumerable().Where(data => data.Field<string>("FirstName") == "Himanshu");
            foreach (var contact in recordData)
            {
                contact.SetField("LastName", "Pandey");
                contact.SetField("Address", "Seawoods");
                Console.WriteLine("Updated contact");
                displayAddressBook();
            }
        }
        
         /* UC5:- Ability to delete a person using person's name.*/
         
        public void deleteParticularContact(Contact contact)
        {
            var recordData = dataTable.AsEnumerable().Where(data => data.Field<string>("FirstName") == contact.FirstName).First();
            if (recordData != null)
            {
                recordData.Delete();
                Console.WriteLine("Delete contact successfully");
                displayAddressBook();

            }
        }
    }

    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***************Welcome To AddressBook Using Linq*************");
            AddressBookDataTable addressBookDataTable = new AddressBookDataTable();
            DataTable table = addressBookDataTable.createAddressBookTable();
            Contact contact = new Contact();

            Console.WriteLine("Enter the first name = ");
            contact.FirstName = Console.ReadLine();
            addressBookDataTable.deleteParticularContact(contact);

            Console.Read();
        }
    }
}



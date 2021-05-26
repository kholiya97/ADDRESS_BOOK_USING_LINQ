using Address_Book_Using_Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookUsingLinq
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

        /*UC6:- Ability to Retrieve Person belonging to a City or State from the Address Book*/
        public void retrieveContactByState(Contact contact)
        {
            var records = from dataTable in dataTable.AsEnumerable().Where(dataTable => dataTable.Field<string>("State") == contact.State) select dataTable;
            foreach (var record in records.AsEnumerable())
            {
                Console.WriteLine("\nFirstName:-" + record.Field<string>("FirstName"));
                Console.WriteLine("LastName:-" + record.Field<string>("LastName"));
                Console.WriteLine("Address:-" + record.Field<string>("Address"));
                Console.WriteLine("City:-" + record.Field<string>("City"));
                Console.WriteLine("State:-" + record.Field<string>("State"));
                Console.WriteLine("ZipCode:-" + record.Field<int>("ZipCode"));
                Console.WriteLine("PhoneNumber:-" + record.Field<long>("PhoneNumber"));
                Console.WriteLine("Email:-" + record.Field<string>("Email"));
                displayAddressBook();

            }
        }

        /*UC6:- SORT_BY_CITY */
        public void retrieveContactByCity(Contact contact)
        {
            var records = from dataTable in dataTable.AsEnumerable().Where(dataTable => dataTable.Field<string>("City") == contact.City) select dataTable;
            foreach (var record in records.AsEnumerable())
            {
                Console.WriteLine("\nFirstName:-" + record.Field<string>("FirstName"));
                Console.WriteLine("LastName:-" + record.Field<string>("LastName"));
                Console.WriteLine("Address:-" + record.Field<string>("Address"));
                Console.WriteLine("City:-" + record.Field<string>("City"));
                Console.WriteLine("State:-" + record.Field<string>("State"));
                Console.WriteLine("ZipCode:-" + record.Field<int>("ZipCode"));
                Console.WriteLine("PhoneNumber:-" + record.Field<long>("PhoneNumber"));
                Console.WriteLine("Email:-" + record.Field<string>("Email"));
                displayAddressBook();

            }
        }
        public void sortContactByGivenCity(Contact contact)
        {
            var records = dataTable.AsEnumerable().Where(x => x.Field<string>("City") == contact.City).OrderBy(x => x.Field<string>("FirstName")).ThenBy(x => x.Field<string>("LastName"));
            foreach (var record in records)
            {
                Console.WriteLine("\nFirstName:-" + record.Field<string>("FirstName"));
                Console.WriteLine("LastName:-" + record.Field<string>("LastName"));
                Console.WriteLine("Address:-" + record.Field<string>("Address"));
                Console.WriteLine("City:-" + record.Field<string>("City"));
                Console.WriteLine("State:-" + record.Field<string>("State"));
                Console.WriteLine("ZipCode:-" + record.Field<int>("ZipCode"));
                Console.WriteLine("PhoneNumber:-" + record.Field<long>("PhoneNumber"));
                Console.WriteLine("Email:-" + record.Field<string>("Email"));
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
            Console.WriteLine("Enter the City ");
            contact.City = Console.ReadLine();
            addressBookDataTable.sortContactByGivenCity(contact);

            Console.Read();
        }
    }
}


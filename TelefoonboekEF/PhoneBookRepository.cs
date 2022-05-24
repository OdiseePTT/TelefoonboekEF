using System.Collections.Generic;
using System.Linq;

namespace Telefoonboek
{
    internal class PhoneBookRepository
    {
        PhoneBookDB phoneBook = new PhoneBookDB();

        internal List<PhoneBookItem> GetAllPhoneBookItems()
        {
            return phoneBook.Items.ToList();
        }

        internal void SaveItem(PhoneBookItem item)
        {
            phoneBook.Items.Add(item);
            phoneBook.SaveChanges();
        }

        internal void UpdateItem(PhoneBookItem item)
        {
            PhoneBookItem itemToUpdate = phoneBook.Items.First(i => i.ID == item.ID);
            itemToUpdate.Firstname = item.Firstname;
            itemToUpdate.Lastname = item.Lastname;
            itemToUpdate.Email = item.Email;
            itemToUpdate.PhoneNumber = item.PhoneNumber;

            //Bovenstaande code is hier niet nodig.
            //Deze is er bij geplaats wanneer we ooit uitbreiding zouden doen met een 2de repository class.
            //In dat geval zou het kunnen dat de parameter item afkomstig is van een andere DbContext, waardoor de update niet mogelijk is.

            phoneBook.SaveChanges();
        }

        internal void DeleteItem(PhoneBookItem item)
        {

            PhoneBookItem itemToDelete = phoneBook.Items.First(i => i.ID == item.ID);
            phoneBook.Items.Remove(itemToDelete);

            //Bovenstaande code is hier niet nodig.
            //Deze is er bij geplaats wanneer we ooit uitbreiding zouden doen met een 2de repository class.
            //In dat geval zou het kunnen dat de parameter item afkomstig is van een andere DbContext, waardoor de delete niet mogelijk is.

            phoneBook.SaveChanges();
        }
    }
}

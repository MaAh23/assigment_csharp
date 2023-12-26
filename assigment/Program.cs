using System.Xml.Serialization;
using assigment.Models;


namespace assigment
{
    internal class Program
    {
        /// <summary>
        /// Här skapar man en lisa för hela programmet
        /// </summary>
        static List<Contact> contacts  = new List<Contact>();
      static void Main()
        {

            /// en While loop för att loopa hela menyn.
            while (true)
            {
                Console.WriteLine("-------------------------Meny-------------------------");
                Console.WriteLine("");
                Console.WriteLine("Välje ett alternativ");
                Console.WriteLine("1. Lägg till nya kontakt information ");
                Console.WriteLine("2. Vissa alla aparade kontakt information");
                Console.WriteLine("3. Ta bort kontank information");
                Console.WriteLine("q. Avsluta");

                string option = Console.ReadLine()!;

                Console.Clear();


                switch (option)
                {
                    case "1":
                        AddContact();
                        break;

                    case "2":
                        ShowContact();
                        break;

                    case "3":   
                        DeleteContact();
                        break;
                    case "q":
                        Environment.Exit(0);
                     
                        break;

                    default:
                        Console.WriteLine("var vänligt och kontrollera ditt svar igen!!");
                        break;
;                }
                Console.ReadKey(); 
            }
        }
        

        static void AddContact()
        {
            /// färsta metod i switch för att kunna spara våran kontakt infomation
            Console.Write("Ange ditt förnamn:   ");
            string FirstName = Console.ReadLine()!;  

            Console.Write("Ange ditt efternam:  ");
            string LastName = Console.ReadLine()!;

            Console.Write("Ange ditt telefonnummer:     ");
            int.Parse(Console.ReadLine()!);

            Console.Write("Ange ditt epost address:     ");
            var Epost = Console.ReadLine()!;    

            Console.Write("Ange ditt address:     ");
            var Address = Console.ReadLine()!;

            Contact newContact = new Contact { Firstname = FirstName, LastName = LastName, Epost = Epost, Address = Address  };
            contacts.Add(newContact);

            Console.WriteLine("Kontakten tillagt ");

        }

        static void ShowContact()
        {
            /// en metod där beroende på användarens val visar alla sparade kontakt infomation med alla detalier.
            if (contacts.Count == 0 )
            {
                Console.WriteLine("det finns ingen kontakt tillgängliga!");
                return;
            }
            Console.WriteLine("Alla kontakter som finns:");
            Console.WriteLine("");
            foreach (var contact in contacts)
            {
                Console.WriteLine($"fullständigt namn: {contact.Firstname} {contact.LastName}");
                Console.WriteLine($"E-post address: <{contact.Epost}>");
                Console.WriteLine($"Address: {contact.Address}");

            }
            Console.WriteLine("");
  

        }

        static void DeleteContact()         
        {
            /// sista metod i switch där användaren kan ta bort en kontakt inforamtion md hjälp av E-post address.
            if (contacts.Count == 0)
            {
                Console.WriteLine("Det finns inga kontakter tillgängliga för att kunna ta bort!!");
                return;
            }
            for( int i = 0; i < contacts.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {contacts[i].Epost}");
            }
            if (int.TryParse(Console.ReadLine(),out int index) && index >= 1 && index <= contacts.Count)
            {
                contacts.RemoveAt(index -1);
                Console.WriteLine("Kontakten som du valde är borttagen.");
            }
            else
            {
                Console.WriteLine("OBS! Ogiltigt val; kontrollera ditt svar och försök igen");
            }
        }
    }
}


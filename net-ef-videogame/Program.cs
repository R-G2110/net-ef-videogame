using System;
using System.Threading.Channels;

namespace net_ef_videogame
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new ApplicationDbContext();
            var videogameManager = new VideogameManager(dbContext);

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Aggiungi Videogioco");
                Console.WriteLine("2. Aggiungi Software House");
                Console.WriteLine("3. Visualizza tutti i Videogiochi");
                Console.WriteLine("4. Visualizza tutte le Software House");
                Console.WriteLine("5. Cerca Videogioco per Nome");
                Console.WriteLine("6. Cerca Software House per Nome");
                Console.WriteLine("7. Cerca Videogioco per Id");
                Console.WriteLine("8. Cerca Software House per Id");
                Console.WriteLine("9. Elimina Videogioco per Id");
                Console.WriteLine("10. Elimina Software House per Id");
                Console.WriteLine("11. Elimina Videogioco per Nome");
                Console.WriteLine("12. Elimina Software House per Nome");
                Console.WriteLine("0. Esci");

                Console.Write("Scelta: ");
                string choice = Console.ReadLine();

                if (int.TryParse(choice, out int menuChoice))
                {
                    switch (menuChoice)
                    {
                        case 1:
                            // Aggiungi Videogioco
                            Console.Clear();
                            Console.Write("Inserisci il nome del Videogioco: ");
                            string videogameName = Console.ReadLine();
                            Console.Write("Inserisci la descrizione del Videogioco: ");
                            string overview = Console.ReadLine();
                            Console.Write("Inserisci la data di rilascio del Videogioco: ");
                            string releaseDate = Console.ReadLine();
                            var newVideogame = new Videogame(videogameName, overview, releaseDate, DateTime.Now, DateTime.Now);
                            videogameManager.AddVideogame(newVideogame);
                            Console.WriteLine("Videogioco aggiunto con successo!");
                            break;
                        case 2:
                            // Aggiungi Software House
                            Console.Clear();
                            Console.Write("Inserisci il nome della Software House: ");
                            string softwareHouseName = Console.ReadLine();
                            Console.Write("Inserisci la Partita IVA della Software House: ");
                            string pIva = Console.ReadLine();
                            Console.Write("Inserisci la città della Software House: ");
                            string city = Console.ReadLine();
                            Console.Write("Inserisci il  paese della Software House: ");
                            string country = Console.ReadLine();
                            var newSoftwareHouse = new SoftwareHouse(softwareHouseName, pIva, city, country);
                            videogameManager.AddSoftwareHouse(newSoftwareHouse);
                            Console.WriteLine("Casa di Software aggiunta con successo!");
                            break;
                        case 3:
                            // Mostra tutti i Videogiochi
                            Console.Clear();
                            var allVideogames = videogameManager.GetAllVideogames();
                            Console.WriteLine("Lista di tutti i Videogiochi:");
                            foreach (var videogame in allVideogames)
                            {
                                Console.WriteLine($"Id: {videogame.Id}, Nome: {videogame.Name}, Descrizione: {videogame.Overview}, Data di rilascio: {videogame.ReleaseDate}");
                            }
                            break;
                        case 4:
                            // Mostra tutte le Software House
                            Console.Clear();
                            var allSoftwareHouses = videogameManager.GetAllSoftwareHouses();
                            Console.WriteLine("Lista di tutte le Software House:");
                            foreach (var softwareHouse in allSoftwareHouses)
                            {
                                Console.WriteLine($"Id: {softwareHouse.Id}, Nome: {softwareHouse.Name}, Partita IVA: {softwareHouse.PIva}, Città: {softwareHouse.City}, Paese: {softwareHouse.Country}");
                            }
                            break;
                        case 5:
                            // Cerca Videogioco per Nome
                            Console.Clear();
                            Console.WriteLine("Ricerca videogioco per nome");
                            Console.Write("Inserisci il nome del Videogioco: ");
                            string searchVideogameName = Console.ReadLine();
                            var foundVideogames = videogameManager.GetVideogameByName(searchVideogameName);
                            Console.WriteLine($"Videogiochi con il nome '{searchVideogameName}':");
                            foreach (var videogame in foundVideogames)
                            {
                                Console.WriteLine($"Id: {videogame.Id}, Nome: {videogame.Name}, Descrizione: {videogame.Overview}, Data di rilascio: {videogame.ReleaseDate}");
                            }
                            break;
                        case 6:
                            // Cerca Software House per Nome
                            Console.Clear();
                            Console.Write("Inserisci il nome della Software House: ");
                            string searchSoftwareHouseName = Console.ReadLine();
                            var foundSoftwareHouses = videogameManager.GetSoftwareHouseByName(searchSoftwareHouseName);
                            Console.WriteLine($"Software House con il nome '{searchSoftwareHouseName}':");
                            foreach (var softwareHouse in foundSoftwareHouses)
                            {
                                Console.WriteLine($"Id: {softwareHouse.Id}, Nome: {softwareHouse.Name}, Partita IVA: {softwareHouse.PIva}, Città: {softwareHouse.City}, Paese: {softwareHouse.Country}");
                            }
                            break;
                        case 7:
                            // Cerca Videogioco per Id
                            Console.Clear();
                            Console.Write("Inserisci l'id del Videogioco: ");
                            if (int.TryParse(Console.ReadLine(), out int searchVideogameId))
                            {
                                var videogame = videogameManager.GetVideogameById(searchVideogameId);
                                if (videogame != null)
                                {
                                    Console.WriteLine($"Videogioco trovato:");
                                    Console.WriteLine($"Id: {videogame.Id}, Nome: {videogame.Name}, Descrizione: {videogame.Overview}, Data di rilascio: {videogame.ReleaseDate}");
                                }
                                else
                                {
                                    Console.WriteLine("Nessun videogioco trovato con questo Id.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Id non valido.");
                            }
                            break;
                        case 8:
                            // Cerca Software House per Id
                            Console.Clear();
                            Console.Write("Inserisci l'id della Software House: ");
                            if (int.TryParse(Console.ReadLine(), out int searchSoftwareHouseId))
                            {
                                var softwareHouse = videogameManager.GetSoftwareHouseById(searchSoftwareHouseId);
                                if (softwareHouse != null)
                                {
                                    Console.WriteLine($"Casa di Software trovata:");
                                    Console.WriteLine($"Id: {softwareHouse.Id}, Nome: {softwareHouse.Name}, Partita IVA: {softwareHouse.PIva}, Città: {softwareHouse.City}, Paese: {softwareHouse.Country}");
                                }
                                else
                                {
                                    Console.WriteLine("Nessuna casa di software trovata con questo Id.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Id non valido.");
                            }
                            break;
                        case 9:
                            // Elimina Videogioco per Id
                            Console.Clear();
                            Console.Write("Inserisci l'id del Videogioco da eliminare: ");
                            if (int.TryParse(Console.ReadLine(), out int deleteVideogameId))
                            {
                                videogameManager.DeleteVideogamebyId(deleteVideogameId);
                                Console.WriteLine("Videogioco eliminato con successo.");
                            }
                            else
                            {
                                Console.WriteLine("Id non valido.");
                            }
                            break;
                        case 10:
                            // Elimina Software House per Id
                            Console.Clear();
                            Console.Write("Inserisci l'id della Software House da eliminare: ");
                            if (int.TryParse(Console.ReadLine(), out int deleteSoftwareHouseId))
                            {
                                videogameManager.DeleteSoftwareHousebyId(deleteSoftwareHouseId);
                                Console.WriteLine("Software House eliminata con successo.");
                            }
                            else
                            {
                                Console.WriteLine("Id non valido.");
                            }
                            break;
                        case 11:
                            // Elimina Videogioco per Nome
                            Console.Clear();
                            Console.Write("Inserisci il nome del Videogioco da eliminare: ");
                            string deleteVideogameName = Console.ReadLine();
                            videogameManager.DeleteVideogamebyName(deleteVideogameName);
                            Console.WriteLine("Videogioco eliminato con successo.");
                            break;
                        case 12:
                            // Elimina Software House per Nome
                            Console.Clear();
                            Console.Write("Inserisci il nome della Software House da eliminare: ");
                            string deleteSoftwareHouseName = Console.ReadLine();
                            videogameManager.DeleteSoftwareHousebyName(deleteSoftwareHouseName);
                            Console.WriteLine("Software House eliminata con successo.");
                            break;
                        case 0:
                            // Esci
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Scelta non valida. Riprova.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Input non valido. Riprova.");
                }

                Console.WriteLine();
            }
        }
    }
}

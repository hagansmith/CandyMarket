using System;
using System.Collections.Generic;
using System.Linq;

namespace CandyMarket
{
	class Program
	{
		static void Main(string[] args)
		{
			// wanna be a l33t h@x0r? skip all this console menu nonsense and go with straight command line arguments. something like `candy-market add taffy "blueberry cheesecake" yesterday`
			var db = SetupNewApp();
            var me = new User("Adam", db);
            var sigOth = new User("Micah", db);

            var run = true;
			while (run)
			{
				ConsoleKeyInfo userInput = MainMenu();

				switch (userInput.KeyChar)
				{
					case '0':
						run = false;
						break;
					case '1': // add candy to your bag

                        AddCandy(db);
                        //CandyBag(db);

                        break;

					case '2':
                        /** eat candy */
                        RemoveCandy(db);
                        //CandyBag(db);
                        /* select specific candy details to eat from list filtered to selected candy type
                        * 
                        * enjoy candy
                        */

                        break;

					case '3':
                        /** throw away candy
						 * select a candy type*/
                        RemoveCandy(db);
                        //CandyBag(db);
                        break;

					case '4':
                        /** give candy **/
                        SelectFriend(db);
                        RemoveCandy(db);
                        //CandyBag(db);
                        break;

					case '5':
                        /** trade candy */
                        SelectFriend(db);
                        RemoveCandy(db);
                        AddCandy(db);
                        //CandyBag(db);

                        break;

					default: // what about requesting candy? like a wishlist. that would be cool.
						break;
				}
			}
		}

         static void AddCandy(DatabaseContext db)
        {
            
            // select a candy type
            var selectedCandyType = AddNewCandyType(db);
            /** MORE DIFFICULT DATA MODEL
				* show a new menu to enter candy details
				* it would be convenient to show the menu in stages e.g. press enter to go to next detail stage, but write the whole screen again with responses populated so far.
		    */
            var selectedCandyFlavor = AddNewCandyFlavor(db);
            // if(moreDifficultDataModel) bug - this is passing candy type right now (which just increments in our DatabaseContext), but should also be passing candy details
            // todo: fix this == db.SaveNewCandy(selectedCandyFlavor.KeyChar);
            var candyType = (CandyType)int.Parse(selectedCandyType.KeyChar.ToString());
            //me.AddCandy(candyType, 1);
            //sigOth.AddCandy(candyType, 1);

        }

        static void RemoveCandy(DatabaseContext db)
        {
            //select a candy type 
            var selectedCandyType = RemoveCandyType(db);
            // Remove selected candy
            var candyType = (CandyType)int.Parse(selectedCandyType.KeyChar.ToString());
            //me.RemoveNewCandy(candyType, 1);
        }

        static void SelectFriend(DatabaseContext db)
        {
            var selectedFriend = TradeWithFriend(db);
        }

        static DatabaseContext SetupNewApp()
		{
			Console.Title = "Cross Confectioneries Incorporated";

			var db = new DatabaseContext();

			Console.SetWindowSize(60, 30);
			Console.SetBufferSize(60, 30);
			Console.BackgroundColor = ConsoleColor.White;
			Console.ForegroundColor = ConsoleColor.Black;
			return db;
		}

		static ConsoleKeyInfo MainMenu()
		{
			View mainMenu = new View()
					.AddMenuOption("Did you just get some new candy? Add it here.")
					.AddMenuOption("Do you want to eat some candy? Take it here.")
                    .AddMenuOption("Did you throw candy away? Remove it here.")
                    .AddMenuOption("Did you give candy away? Remove it here")
                    .AddMenuOption("Would you like to trade some candy? Trade here")
                    .AddMenuText("Press 0 to exit.");

			Console.Write(mainMenu.GetFullMenu());
			ConsoleKeyInfo userOption = Console.ReadKey();
			return userOption;
		}

		static ConsoleKeyInfo AddNewCandyType(DatabaseContext db)
		{
			var candyTypes = db.GetCandyTypes();

			var newCandyMenu = new View()
					.AddMenuText("What type of candy did you get?")
					.AddMenuOptions(candyTypes);

			Console.Write(newCandyMenu.GetFullMenu());

			ConsoleKeyInfo selectedCandyType = Console.ReadKey();
			return selectedCandyType;
		}

        static ConsoleKeyInfo AddNewCandyFlavor(DatabaseContext db)
        {
            var candyFlavors = db.GetCandyFlavors();
            var selectedCandy = "taffy";
            var newCandyMenu = new View()
                .AddMenuText($"What flavor {selectedCandy} did you get")
                .AddMenuOptions(candyFlavors);

            Console.Write(newCandyMenu.GetFullMenu());
            ConsoleKeyInfo selectedCandyFlavor = Console.ReadKey();
            return selectedCandyFlavor;
        }

        static ConsoleKeyInfo TradeWithFriend(DatabaseContext db)
        {
            var friends = db.GetFriends();
            var friendMenu = new View()
                .AddMenuText($"Which friend do you want to trade with?")
                .AddMenuOptions(friends);

            Console.Write(friendMenu.GetFullMenu());
            ConsoleKeyInfo selectedFriend = Console.ReadKey();
            return selectedFriend;
        }

        static ConsoleKeyInfo RemoveCandyType(DatabaseContext db)
        {
            var candyTypes = db.GetCandyTypes();

            var newCandyMenu = new View()
                    .AddMenuText("What type of candy is gone?")
                    .AddMenuOptions(candyTypes);

            Console.Write(newCandyMenu.GetFullMenu());

            ConsoleKeyInfo selectedCandyType = Console.ReadKey();
            return selectedCandyType;
        }

        //static ConsoleKeyInfo CandyBag(DatabaseContext db)
        //{
        //    var candyCounts = db;

        //    var newCandyMenu = new View()
        //            .AddMenuText("Your candy bag");

        //    foreach (var candy in candyCounts) {
        //        newCandyMenu.AddMenuText($"{candy.Key } --- {candy.Value}");
        //         }   
        //     newCandyMenu.AddMenuText("Press enter to return");

        //    Console.Write(newCandyMenu.GetFullMenu());

        //    ConsoleKeyInfo selectedCandyType = Console.ReadKey();
        //    return selectedCandyType;
        //}
    }
}

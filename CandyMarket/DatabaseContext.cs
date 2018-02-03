using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CandyMarket
{
    internal class DatabaseContext
    {
        private int _countOfTaffy = 3;
        private int _countOfCandyCoated = 2;
        private int _countOfChocolateBar = 1;
        private int _countOfZagnut;

        /**
		 * this is just an example.
		 * feel free to modify the definition of this collection "BagOfCandy" if you choose to implement the more difficult data model.
		 * Dictionary<CandyType, List<Candy>> BagOfCandy { get; set; }
		 */

        public DatabaseContext(int tone) => Console.Beep(tone, 2500);

        internal List<string> GetCandyTypes()
        {
            return Enum
                .GetNames(typeof(CandyType))
                .Select(candyType =>
                    candyType.Humanize(LetterCasing.Title))
                .ToList();
        }

        internal List<string> GetCandyFlavors()
        {
            return Enum
                .GetNames(typeof(CandyFlavor))
                .Select(candyFlavor =>
                    candyFlavor.Humanize(LetterCasing.Title))
                .ToList();
        }

        internal List<string> GetFriends()
        {
            return Enum
                .GetNames(typeof(Friends))
                .Select(Friends =>
                    Friends.Humanize(LetterCasing.Title))
                .ToList();
        }

        internal Dictionary<string, int> CandyBag()
        {
            var contents = new Dictionary<string, int>();
            contents.Add ("Taffy", _countOfTaffy);
            contents.Add ("Candy Coated", _countOfCandyCoated);
            contents.Add ("Chocolate Bar", _countOfChocolateBar);
            contents.Add("Zagnut", _countOfZagnut);
            
            return contents;
        }

        internal void SaveNewCandy(char selectedCandyMenuOption)
		{
			var candyOption = int.Parse(selectedCandyMenuOption.ToString());

			var maybeCandyMaybeNot = (CandyType)selectedCandyMenuOption;
			var forRealTheCandyThisTime = (CandyType)candyOption;

			switch (forRealTheCandyThisTime)
			{
				case CandyType.TaffyNotLaffy:
					++_countOfTaffy;
					break;
				case CandyType.CandyCoated:
					++_countOfCandyCoated;
					break;
				case CandyType.CompressedSugar:
					++_countOfChocolateBar;
					break;
				case CandyType.ZagnutStyle:
					++_countOfZagnut;
					break;
				default:
					break;
			}
		}

        internal void RemoveNewCandy(char selectedCandyMenuOption)
        {
            var candyOption = int.Parse(selectedCandyMenuOption.ToString());

            var maybeCandyMaybeNot = (CandyType)selectedCandyMenuOption;
            var forRealTheCandyThisTime = (CandyType)candyOption;

            switch (forRealTheCandyThisTime)
            {
                case CandyType.TaffyNotLaffy:
                    --_countOfTaffy;
                    break;
                case CandyType.CandyCoated:
                    --_countOfCandyCoated;
                    break;
                case CandyType.CompressedSugar:
                    --_countOfChocolateBar;
                    break;
                case CandyType.ZagnutStyle:
                    --_countOfZagnut;
                    break;
                default:
                    break;
            }
        }
    }
}
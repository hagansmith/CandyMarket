using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CandyMarket
{
    public class DatabaseContext
    {
        Dictionary<string, int> _taffy = new Dictionary<string, int>();
        Dictionary<string, int> _candyCoated = new Dictionary<string, int>();
        Dictionary<string, int> _chocolateBar = new Dictionary<string, int>();
        Dictionary<string, int> _zagnut = new Dictionary<string, int>();

        //Dictionary<string, Dictionary<string, int>> CandyBag = new Dictionary<string, Dictionary<string, int>>();


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
                .ToList();
        }

        internal List<string> GetFriends()
        {
            return Enum
                .GetNames(typeof(Friends))
                .ToList();
        }

        //internal Dictionary<string, int> CandyBag()
        //{
        //    var contents = new Dictionary<string, int>();
        //    contents.Add("Taffy", _countOfTaffy);
        //    contents.Add("Candy Coated", _countOfCandyCoated);
        //    contents.Add("Chocolate Bar", _countOfChocolateBar);
        //    contents.Add("Zagnut", _countOfZagnut);

        //    return contents;
        //}



        internal void SaveNewCandy(string userName, CandyType candyType, int howMany)
		{
            if (!_taffy.ContainsKey(userName))
            {
                _taffy.Add(userName, 0);
                _candyCoated.Add(userName, 0);
                _chocolateBar.Add(userName, 0);
                _zagnut.Add(userName, 0);
            }

			switch (candyType)
			{
				case CandyType.TaffyNotLaffy:
					_taffy[userName] += howMany;
					break;
				case CandyType.CandyCoated:
					_candyCoated[userName] += howMany;
					break;
				case CandyType.CompressedSugar:
					_chocolateBar[userName] += howMany;
					break;
				case CandyType.ZagnutStyle:
					_zagnut[userName] += howMany;
					break;
				default:
					break;
			}
		}

        internal void RemoveNewCandy(string userName, CandyType candyType, int howMany)
        {
            switch (candyType)
            {
                case CandyType.TaffyNotLaffy:
                    if (_taffy[userName] > 0)
                    {
                        _taffy[userName] -= howMany; 
                    }
                    break;
                case CandyType.CandyCoated:
                    if (_candyCoated[userName] > 0)
                    {
                        _candyCoated[userName] -= howMany; 
                    }
                    break;
                case CandyType.CompressedSugar:
                    if (_chocolateBar[userName] > 0)
                    {
                        _chocolateBar[userName] -= howMany; 
                    }
                    break;
                case CandyType.ZagnutStyle:
                    if (_zagnut[userName] > 0)
                    {
                        _zagnut[userName] -= howMany; 
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
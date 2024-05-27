using System;
using System.Collections.Generic;
using GPSRouteOptimization;

public class Program
{

	private static List<Place> getInitialListOfPlaces() {
		var place1 = new Place("test1", 0, 1, 2);
		var place2 = new Place("test2", 0, 1, 2);
		var place3 = new Place("test3", 0, 1, 2);
		var place4 = new Place("test4", 0, 1, 2);
		var place5 = new Place("test5", 0, 1, 2);
		var places = new List<Place>();
		places.Add(place1);
		places.Add(place2);
		places.Add(place3);
		places.Add(place4);
		places.Add(place5);
		return places;
	}

	private static List<List<Place>> getInitialPossibleSteps(List<Place> places)
	{
		List<List<Place>> listOfListOfPlaces = new List<List<Place>>();

		listOfListOfPlaces.Add(places);
		for (int i = 1; i < places.Count; i++)
		{
			var newPlaces = Extensions.Swap(places, 0, i);
			listOfListOfPlaces.Add(newPlaces);
		}
		return listOfListOfPlaces;
	}

	private static List<List<Place>> getAdditionalSteps(List<List<Place>> listOfListOfPlaces)
	{
		var secondListOfListOfPlaces = new List<List<Place>>(listOfListOfPlaces);

		listOfListOfPlaces.ForEach(tplaces =>
		{
			for (int i = 1; i < tplaces.Count; i++)
			{
				secondListOfListOfPlaces.Add(Extensions.Swap(tplaces, 0, 1));
			}
		});

		return secondListOfListOfPlaces;
	}

	private static void writeResults(List<List<Place>> secondListOfListOfPlaces)
	{
		int counter = 0;
		secondListOfListOfPlaces.ForEach(listOfPlaces =>
		{
			listOfPlaces.ForEach(p =>
			{
				counter++;
				Console.WriteLine(counter.ToString() + " " + p.Name);
			});
			Console.WriteLine();
		});
	}

	public static void Main()
	{
		var places = getInitialListOfPlaces();
		var listOfListOfPlaces = getInitialPossibleSteps(places);
		var allSteps = getAdditionalSteps(listOfListOfPlaces);
		writeResults(allSteps);
	}
}




using System;
using System.Collections.Generic;

public class Program
{
	public static void Main()
	{
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
		List<List<Place>> listOfListOfPlaces = new List<List<Place>>();
		List<List<Place>> secondListOfListOfPlaces = new List<List<Place>>();
		listOfListOfPlaces.Add(places);
		for (int i = 1; i < places.Count; i++)
		{
			var newPlaces = Extensions.Swap(places, 0, i);
			listOfListOfPlaces.Add(newPlaces);
		}

		secondListOfListOfPlaces = new List<List<Place>>(listOfListOfPlaces);
		listOfListOfPlaces.ForEach(tplaces =>
		{
			for (int i = 1; i < tplaces.Count; i++)
			{
				secondListOfListOfPlaces.Add(Extensions.Swap(tplaces, 0, 1));
			}
		});
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
}

public static class Extensions
{
	public static List<Place> Swap(List<Place> list, int indexA, int indexB)
	{
		var tmpList = new List<Place>(list);
		Place tmp = tmpList[indexA];
		tmpList[indexA] = tmpList[indexB];
		tmpList[indexB] = tmp;
		return tmpList;
	}
}

public class GPSLocation
{
	public decimal Latitude { get; set; }
	public decimal Longitude { get; set; }
	public decimal Elevation { get; set; }

	public GPSLocation(decimal lat, decimal lon, decimal elev)
	{
		Latitude = lat;
		Longitude = lon;
		Elevation = elev;
	}
}

public class Place
{
	public GPSLocation GPSLocation { get; set; }
	public string Name { get; set; }

	public Place(string name, decimal lat, decimal lon, decimal elev)
	{
		Name = name;
		GPSLocation = new GPSLocation(lat, lon, elev);
	}
} /*
		foreach (Place p in places)
		{
			Console.WriteLine(p.Name);
		}

		places.Swap(0, 3);
		Console.WriteLine();
		foreach (Place p in places)
		{
			Console.WriteLine(p.Name);
		}*/
using System;
using System.Collections.Generic;
using GPSRouteOptimization;
using Newtonsoft.Json;

public class Program
{

	private static List<Place> getInitialListOfPlaces()
	{
		var place1 = new Place("test1", 33.94, 67.71, 2);
		var place2 = new Place("test2", 60.18, 19.92, 2);
		var place3 = new Place("test3", 41.15, 20.17, 2);
		var place4 = new Place("test4", 28.03, 1.66, 2);
		var place5 = new Place("test5", -14.27, -170.3, 2);
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
		for (int j = 0; j < places.Count; j++)
		{
			for (int i = 0; i < places.Count; i++)
			{
				var newPlaces = Extensions.Swap(places, i, j);
				listOfListOfPlaces.Add(newPlaces);
			}
		}
		return listOfListOfPlaces;
	}

	private static List<List<Place>> getAdditionalSteps(List<List<Place>> listOfListOfPlaces)
	{
		var secondListOfListOfPlaces = new List<List<Place>>(listOfListOfPlaces);

		listOfListOfPlaces.ForEach(tplaces =>
		{
			for (int i = 0; i < tplaces.Count; i++)
			{
				//secondListOfListOfPlaces.Add(Extensions.Swap(tplaces, 0, 1));
				var first = tplaces[0];
				tplaces.RemoveAt(0);
				tplaces.Add(first);
				secondListOfListOfPlaces.Add(tplaces);
			}
		});

		return secondListOfListOfPlaces;
	}

	private static List<Route> getRoutes(List<List<Place>> secondListOfListOfPlaces)
	{
		double distance = 0;

		List<Route> routes = new List<Route>();

		secondListOfListOfPlaces.ForEach(listOfPlaces =>
		{
			for (int i = 0; i < listOfPlaces.Count - 1; i++)
			{
				distance += Extensions.GetDistanceBetweenGPSPoints(listOfPlaces[i].GPSLocation.Longitude, listOfPlaces[i].GPSLocation.Latitude,
				listOfPlaces[i + 1].GPSLocation.Longitude, listOfPlaces[i + 1].GPSLocation.Latitude);
			}

			Route route = new Route(listOfPlaces, distance);
			routes.Add(route);
			distance = 0;
		});
		return routes;
	}

	private static void writeOutSortedRouteInfo(List<Route> routes)
	{
		var routesSorted = routes.OrderBy(r => r.Distance).ToList();
		routesSorted.ForEach(r =>
		{
			Console.WriteLine("Name Path: " + r.ConcatUniqueRouteName());
			Console.WriteLine("Distance: " + r.Distance);
			Console.WriteLine();
		});
	}

	public static void Main()
	{
		var places = getInitialListOfPlaces();
		var listOfListOfPlaces = getInitialPossibleSteps(places);
		var allSteps = getAdditionalSteps(listOfListOfPlaces);
		var routes = getRoutes(allSteps);
				Console.WriteLine(routes.Count());

		Console.WriteLine(routes.Distinct().Count());
		//writeOutSortedRouteInfo(routes);
	}
}




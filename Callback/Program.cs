using System;
using System.Collections.Generic;

public class EventManager
{
	// Define a delegate for the callback function
	public delegate void EventHandler(string message);

	// Define an event based on the delegate
	public event EventHandler EventOccurred;

	// Method to trigger the event
	public void TriggerEvent(string message)
	{
		Console.WriteLine($"Event Triggered: {message}");

		// Check if there are any subscribers
		if (EventOccurred != null)
		{
			// Notify subscribers
			EventOccurred(message);
		}
	}
}

public class Subscriber
{
	private string name;

	public Subscriber(string name)
	{
		this.name = name;
	}

	// Callback method that will be invoked when the event occurs
	public void HandleEvent(string message)
	{
		Console.WriteLine($"{name} received event notification: {message}");
	}
}

class Program
{
	static void Main()
	{
		// Create an instance of EventManager
		EventManager eventManager = new EventManager();

		// Create two subscribers
		Subscriber subscriber1 = new Subscriber("Subscriber 1");
		Subscriber subscriber2 = new Subscriber("Subscriber 2");

		// Subscribe subscribers to the event
		eventManager.EventOccurred += subscriber1.HandleEvent;
		eventManager.EventOccurred += subscriber2.HandleEvent;

		// Trigger the event
		eventManager.TriggerEvent("Sample Event");

		// Unsubscribe one subscriber
		eventManager.EventOccurred -= subscriber1.HandleEvent;

		// Trigger the event again
		eventManager.TriggerEvent("Another Event");
	}
}

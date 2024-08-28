while (true)
{
	Console.Write("Write unix seconds:");
	string? read = Console.ReadLine();
	if (read is null)
		return;

	if (!long.TryParse(read, out var unixSeconds))
	{
		Console.WriteLine("Not a number");
		continue;
	}

	try
	{
		Console.WriteLine(DateTimeOffset.FromUnixTimeSeconds(unixSeconds).ToLocalTime().ToString());
	}
	catch (ArgumentOutOfRangeException)
	{
		try
		{
			Console.WriteLine($"Too long, maybe you wrote in milliseconds: {DateTimeOffset.FromUnixTimeMilliseconds(unixSeconds).ToLocalTime()}");
		}
		catch (ArgumentOutOfRangeException)
		{
			Console.WriteLine("Not a date or not a unix time");
		}
	}
}
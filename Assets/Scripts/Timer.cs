using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;
using System.IO;
using UnityEditor.Overlays;
using UnityEngine;


public static class Timer
{
	private static readonly Stopwatch stopwatch = new();
	public static  List<long> steps = new();


	public static bool IsRunning
	{
		get => stopwatch.IsRunning;
	}

	public static double ElapsedSeconds
	{
		get => stopwatch.ElapsedMilliseconds * 0.001f;
	}

	public static int StepsCount
	{
		get => steps.Count;
	}

	public static double GetStepElapsedSeconds(int index)
	{
		return steps[index] * 0.001f;
	}


	/// <summary>
	/// Reset the timer and remove any steps.
	/// </summary>
	public static void Reset()
	{
		stopwatch.Reset();
		steps.Clear();
	}

	public static void Start()
	{
		stopwatch.Start();
	}

	public static void Stop()
	{
		stopwatch.Stop();
	}

	public static void Step()
	{
		steps.Add(stopwatch.ElapsedMilliseconds);
	}

	public static void Save()
	{
        // TODO : save our time steps (line 7 of this script) inside a file.
        string saveLocation = "D:\\CastaingMolinJulie\\oui\\RC-You-Later_CastaingMolinJulie" + "/Score.txt";

        //Timer dataScore = new Timer();
        FileStream stream = new FileStream(saveLocation, FileMode.Create);
		StreamWriter writer = new StreamWriter(stream);
		foreach(long step in steps)
		{
			writer.WriteLine(step);
		}
		writer.Close();
		stream.Close();

		UnityEngine.Debug.Log("Score saved at" + saveLocation);
	}

	public static void Load()
	{
		// TODO : load our time steps from a file (if we have any)
		// and store them inside our steps variable (line 7 of this script)
		// to show them to the player before starting a race.
		string saveLocation = "D:\\CastaingMolinJulie\\oui\\RC-You-Later_CastaingMolinJulie" + "/Score.txt";

		if (File.Exists(saveLocation))
		{

            FileStream stream = new FileStream(saveLocation, FileMode.Create);
            StreamReader reader = new StreamReader(stream);

			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (long.TryParse(line, out long value))
				{
					steps.Add(value);
				}
			}

			reader.Close();
			stream.Close();

			string debugText = "";
			foreach (long step in steps)
			{
				debugText += step + "\n";
			}

            UnityEngine.Debug.Log("Score charged from" + saveLocation + "\n voici les données: \n" + debugText);
            steps.Clear();

        }
		else
		{
            UnityEngine.Debug.Log("Aucune données");
        }

	}
}

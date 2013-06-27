using System;

namespace AgeDayCalculator
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Settings mySettings = new Settings ();

			bool isOk = false;

			while (!isOk) {
				Console.Write ("Please enter your name: >");
				string nameFromSettings = mySettings.Name;
				if (!string.IsNullOrEmpty(nameFromSettings))
					Console.Write(string.Format(" [{0}] ", nameFromSettings));
				string name = Console.ReadLine ();
				if (string.IsNullOrEmpty(name))
					name = nameFromSettings;
				if (!string.IsNullOrEmpty(name)) {
					Console.Write ("Please enter your date of birth: >");
					string dobFromSettings = mySettings.DateOfBirthString;
					if (!string.IsNullOrEmpty(dobFromSettings))
						Console.Write (string.Format(" [{0}] ", dobFromSettings));
					string dobString = Console.ReadLine ();
					if (string.IsNullOrEmpty(dobString))
						dobString = dobFromSettings;
					DateTime dob;
					bool isValidDob = DateTime.TryParse (dobString, out dob);
					if (isValidDob) {
						int ageInDays = (int)DateTime.Now.Subtract (dob).TotalDays;
						DisplayAge(name, dob, ageInDays);
						isOk = true;
						mySettings.Name = name;
						mySettings.DateOfBirthString = dobString;
						mySettings.Save ();
					} else
						Console.WriteLine ("Invalid Date Entered!");
				}
			}

			Console.ReadKey ();
		}

		public static void DisplayAge(string name, DateTime dob, int ageInDays)
		{
			Console.WriteLine (string.Format("Hello, {0}. You are {1} day{2} old!", name, ageInDays, ageInDays == 1 ? string.Empty : "s"));
		}
	}
}

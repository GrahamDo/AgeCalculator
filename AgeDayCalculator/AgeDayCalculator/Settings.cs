using System;
using System.IO;

namespace AgeDayCalculator
{
	public class Settings
	{
		private string _fileName = string.Format("{0}{1}Settings.txt", 
		                                         Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
		                                         Path.DirectorySeparatorChar);

		public string Name { get; set; }
		public string DateOfBirthString { get; set; }

		public Settings ()
		{
			if (File.Exists (_fileName)) {
				string[] allText = File.ReadAllLines(_fileName);
				Name = allText[0];
				DateOfBirthString = allText[1];
			}
		}

		public void Save()
		{
			File.WriteAllText(_fileName, string.Format("{0}\r\n{1}", Name, DateOfBirthString));
		}
	}
}


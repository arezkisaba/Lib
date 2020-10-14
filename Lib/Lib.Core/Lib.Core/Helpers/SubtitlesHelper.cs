using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Lib.Core
{
	public static class SubtitlesHelper
	{
		public static List<Tuple<long, string>> GetSubtitlesFromString(string srt)
		{
			var subtitles = new List<Tuple<long, string>>();

			srt = srt.Replace("\r\n", "\n");
			srt = srt.Replace("\n", "\r\n");
			srt = srt.Replace("\r\n\r\n\r\n\r\n", "\r\n\r\n\r\n");
			srt = srt.Replace("\r\n\r\n\r\n", "\r\n\r\n");

			var parts = srt.Split(new[] { "\r\n\r\n" }, StringSplitOptions.None);
			foreach(var part in parts)
			{
				try
				{
					var array = part.Split(new[] { "\r\n" }, StringSplitOptions.None);
					if(array.Length < 3)
					{
						continue;
					}

					var duration = array[1];
					var text = string.Empty;

					for(var i = 2; i < array.Length; i++)
					{
						text += array[i] + " ";
					}

					var durationRaw = duration.Replace(" --> ", "\t");
					var durationRawArray = durationRaw.Split('\t');
					var startRaw = durationRawArray[0];
					startRaw = durationRawArray[0].Substring(0, startRaw.LastIndexOf(','));
					var startHour = Convert.ToInt32(startRaw.Split(':')[0]);
					var startMinute = Convert.ToInt32(startRaw.Split(':')[1]);
					var startSecond = Convert.ToInt32(startRaw.Split(':')[2]);
					var startMillisecond = Convert.ToInt32(durationRawArray[0].Split(',')[1]);
					var startDateTime = new DateTime().AddHours(startHour).AddMinutes(startMinute).AddSeconds(startSecond).AddMilliseconds(startMillisecond);

					var tuple = Tuple.Create<long, string>((startDateTime.Hour * 3600 * 1000) + (startDateTime.Minute * 60 * 1000) + (startDateTime.Second * 1000) + startDateTime.Millisecond, text);
					subtitles.Add(tuple);
				}
				catch(Exception)
				{
				}
			}

			return subtitles;
		}

		public static string RemoveHtml(string srt)
		{
			return Regex.Replace(srt, @"<[^>]*>", string.Empty);
		}
	}
}
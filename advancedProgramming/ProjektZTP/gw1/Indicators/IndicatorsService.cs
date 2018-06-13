using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektZTP.gw1.Indicators
{
	public class IndicatorsService : IIndicatorsService
	{
		public IndicatorsService()
		{
		}

		public struct MST
		{

			public string Ticker;
			public string Date;
			public float Open;
			public float High;
			public float Low;
			public float Close;
			public int Vol;
		}



		private List<MST> ParseMst(string path)
		{
			List<string> lines = File.ReadAllLines(path).ToList();
			List<MST> rec = new List<MST>();

			for (int i = 1; i < lines.Count; i++)
			{
				List<string> s = lines[i].Split(',').ToList();
				try
				{

					rec.Add(new MST
					{
						Ticker = s[0],
						Date = s[1],
						Open = float.Parse(s[2]),
						High = float.Parse(s[3]),
						Low = float.Parse(s[4]),
						Close = float.Parse(s[5]),
						Vol = int.Parse(s[6])
					});
				}
				catch (Exception)
				{


				}
			}

			return rec;

		}

		private List<float> MovingAverage(List<float> values, int period)
		{
			List<float> avg = new List<float>();

			for (int i = period; i < values.Count(); i++)
			{
				float sum = 0;
				for (int j = i - period; j < i; j++)
					sum += values[j];

				avg.Add((sum / period));
			}

			return avg;

		}

		public Dictionary<string, string> Wskazniki(int period, string path)
		{

			System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
			customCulture.NumberFormat.NumberDecimalSeparator = ".";

			System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

			List<float> f = new List<float>();
			List<MST> m = ParseMst(path);
			foreach (var item in m)
			{
				f.Add(item.High);
			}

			List<float> av = MovingAverage(f, period);
			Dictionary<string, string> dc = new Dictionary<string, string>();

			period = period >= m.Count ? Math.Abs(m.Count - 1) : period;

			bool trend = m[period].Close >= f[period];

			for (int i = period; i < f.Count; i++)
			{

				if (trend != (m[i].Close >= f[i]))
				{
					try
					{

						trend = !trend;
						dc.Add(FormatDate(m[i].Date), trend ? "Sygnal kupna" : "Sygnal sprzedazy");
					}
					catch (Exception)
					{


					}

				}

			}

			return dc;

		}

		static string FormatDate(string date)
		{
			return date.Substring(0, 4) + "." + date.Substring(4, 2) + "." + date.Substring(6, 2);
		}



	}
}

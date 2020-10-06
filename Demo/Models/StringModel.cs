using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Models
{
	public class StringModel
	{
		public StringModel()
		{
		}

		public StringModel(string value)
		{
			Value = value;
		}

		public string Value { get; set; }

		public static implicit operator StringModel(string value)
		{
			return new StringModel { Value = value };
		}
	}

	public static class StringExtensions
	{
		public static IEnumerable<StringModel> Label<T>(this IEnumerable<T> data, Func<T, string> selector)
		{
			return data
				.Select(p => new StringModel(selector(p)))
				.ToArray();
		}
	}

	
}

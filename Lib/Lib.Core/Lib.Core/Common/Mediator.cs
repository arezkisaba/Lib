using System;
using System.Collections.Generic;

namespace Lib.Core
{
	public static class Mediator
	{
		private static readonly IDictionary<string, object> Actions = new Dictionary<string, object>();

		public static void Clear()
		{
			Actions.Clear();
		}

		public static void Notify(string token)
		{
			if (Actions.ContainsKey(token))
			{
				var callback = Actions[token] as Action;
				if (callback != null)
				{
					callback();
				}
			}
		}

		public static void Notify<T>(string token, T args)
		{
			if (Actions.ContainsKey(token))
			{
				var callback = Actions[token] as Action<T>;
				if (callback != null)
				{
					callback(args);
				}
			}
		}

		public static void Register(string token, Action callback)
		{
			if (Actions.ContainsKey(token))
			{
				Actions.Remove(token);
			}

			Actions.Add(token, callback);
		}

		public static void Register<T>(string token, Action<T> callback)
		{
			if (Actions.ContainsKey(token))
			{
				Actions.Remove(token);
			}

			Actions.Add(token, callback);
		}

		public static void Unregister(string token, Action callback)
		{
			if (Actions.ContainsKey(token))
			{
				Actions.Remove(token);
			}
		}

		public static void Unregister<T>(string token, Action<T> callback)
		{
			if (Actions.ContainsKey(token))
			{
				Actions.Remove(token);
			}
		}
	}
}
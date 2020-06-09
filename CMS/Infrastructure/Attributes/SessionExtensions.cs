using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Infrastructure.Attributes
{
	public static class SessionExtensions
	{ //tip dönüştürme işlemleri yapacak.
		public static void SetJson(this ISession session, string key, object value)
		{ 
			
			session.SetString(key, JsonConvert.SerializeObject(value));//serializeobject=.net objemi value'yü json tipine dönüştürüyor.Verilen value'yu convert edicek.
			//json tipine dönüştürdüdk. Apı için hazırlık yaptık. çarta eklemek için ajax ile yapıcağız.
		}
		public static T GetJson<T>(this ISession session,string key)
		{
			
			var sessionData = session.GetString(key);//(key)anahtarı verdik session datanın içine attık.
			return sessionData == null ? default(T) : JsonConvert.DeserializeObject<T>
				(sessionData);
		}
	}
}

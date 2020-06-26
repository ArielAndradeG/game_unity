using LitJson;
using System.Collections.Generic;
using BestHTTP.SocketIO.JsonEncoders;

public sealed class json : IJsonEncoder
{
	public List<object> Decode(string json)
	{
		JsonReader reader = new JsonReader(json);
		return JsonMapper.ToObject<List<object>>(reader);
	}

	public string Encode(List<object> obj)
	{
		JsonWriter writer = new JsonWriter();
		JsonMapper.ToJson(obj, writer);
		return writer.ToString();
	}
}
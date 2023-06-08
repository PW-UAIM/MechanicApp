//===============================================================================
//
// PlaZa System Platform
//
//===============================================================================
//
// Warsaw University of Technology
// Computer Networks and Services Division
// Copyright © 2020 PlaZa Creators
// All rights reserved.
//
//===============================================================================

namespace majumi.MechanicApp.Model;

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using System.Text;

public class ServiceClient
{
	private static readonly HttpClient httpClient = new HttpClient();

	private readonly string serviceHost;
	private readonly ushort servicePort;

	public ServiceClient(string serviceHost, int servicePort)
	{
		Debug.Assert(condition: !string.IsNullOrEmpty(serviceHost) && servicePort > 0);

		this.serviceHost = serviceHost;
		this.servicePort = (ushort)servicePort;
	}

	public R CallWebService<R>(string webServiceUri)
	{
		Task<string> webServiceCall = CallWebService(webServiceUri);

		webServiceCall.Wait();

		string jsonResponseContent = webServiceCall.Result;

		R result = ConvertFromJson<R>(jsonResponseContent);

		return result;
	}
	public R CallWebService<R, T>(string webServiceUri, T bodyData)
	{
		Task<string> webServiceCall = CallWebService(webServiceUri, bodyData);

		webServiceCall.Wait();

		string jsonResponseContent = webServiceCall.Result;

		R result = ConvertFromJson<R>(jsonResponseContent);

		return result;
	}

	private async Task<string> CallWebService(string callUri)
	{
		string httpUri = String.Format("http://{0}:{1}/{2}", serviceHost, servicePort, callUri);

		HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(httpUri);
		httpResponseMessage.EnsureSuccessStatusCode();

		string httpResponseContent = await httpResponseMessage.Content.ReadAsStringAsync();

		return httpResponseContent;
	}

	private async Task<string> CallWebService<T>(string callUri, T bodyData)
	{
		string httpUri = String.Format("http://{0}:{1}/{2}", this.serviceHost, this.servicePort, callUri);

		string JSON = ConvertToJson(bodyData);
		HttpContent httpContent = new StringContent(JSON, Encoding.UTF8, "application/json");

		HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(httpUri, httpContent);
		httpResponseMessage.EnsureSuccessStatusCode();

		string httpResponseContent = await httpResponseMessage.Content.ReadAsStringAsync();

		return httpResponseContent;
	}

	private T ConvertFromJson<T>(string json)
	{
		JsonSerializerOptions jsonSerializerOptions = new()
		{
			PropertyNameCaseInsensitive = true
		};

		return JsonSerializer.Deserialize<T>(json, jsonSerializerOptions);
	}

	private string ConvertToJson<T>(T obj)
	{
		JsonSerializerOptions jsonSerializerOptions = new()
		{
			PropertyNameCaseInsensitive = true
		};

		return JsonSerializer.Serialize(obj, jsonSerializerOptions);
	}
}

using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace UTrack.V1;

public class ApiClient(HttpClient httpClient)
{

    public async Task<(ShipmentTrack? track, string error)> ShipmentSearchAsync(SearchFilter filter)
    {
        ShipmentTrack? _track = null;
        string _error = string.Empty;

        {
            using var request = await CreateRequest(filter, "label");
            using var response = await httpClient.SendAsync(request);
            (_track, _error) = await ProcessResult(response);
        }

        if (_error == string.Empty && _track == null)
        {
            using var request = await CreateRequest(filter, "bl_number");
            using var response = await httpClient.SendAsync(request);
            (_track, _error) = await ProcessResult(response);
        }

        return (_track, _error);

    }

    private static readonly JsonSerializerOptions _jsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
        Converters = { new JsonStringEnumConverter(JsonNamingPolicy.SnakeCaseLower) }
    };

    private static async Task<HttpRequestMessage> CreateRequest(SearchFilter filter, string searchBy = "label")
    {
        var queryParams = new Dictionary<string, string?>
        {
            { "search_by", searchBy },
            { "cargo_flow", filter.CargoFlow.ToString().ToLower() },
            { "is_container_unit", filter.IsContainerUnit.ToString().ToLower() },
            { "is_empty_container_unit", filter.IsEmptyContainerUnit.ToString().ToLower() }
        };
        var queryString = await new FormUrlEncodedContent(queryParams).ReadAsStringAsync();
        var body = new[] { filter.SearchString };
        var request = new HttpRequestMessage(HttpMethod.Post, $"shipment/search?{queryString}")
        {
            Content = JsonContent.Create(body)
        };
        request.Headers.Add("x-api-key", "QPUGvnCqzJSyisAMwCescyrz");
        return request;
    }

    private static async Task<(ShipmentTrack? track, string error)> ProcessResult(HttpResponseMessage response)
    {
        if (response.StatusCode == HttpStatusCode.OK)
        {
            var items = await response.Content.ReadFromJsonAsync<IEnumerable<ShipmentTrack>>(_jsonOptions);
            return (items?.FirstOrDefault(), string.Empty);
        }
        else if (response.IsSuccessStatusCode)
        {
            return (null, string.Empty);
        }
        else
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            return (null, $"There is some problem occurred: {response.StatusCode}, Content: {errorContent}");
        }
    }
}

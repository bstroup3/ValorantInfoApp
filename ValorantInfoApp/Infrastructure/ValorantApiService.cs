using Microsoft.AspNetCore.WebUtilities;
using ValorantInfoApp.Infrastructure.Weapons;
using ValorantInfoApp.Infrastructure.Agents;
using ValorantInfoApp.Infrastructure.Maps;
using ValorantInfoApp.Infrastructure.Armor;

namespace ValorantInfoApp.Shared;
public interface IValorantApiService
{
    public Task<Agent[]> GetAgentsAsync(GetDataRequest request, CancellationToken cancellationToken);
    public Task<Map[]> GetMapsAsync(GetDataRequest request, CancellationToken cancellationToken);
    public Task<Weapon[]> GetWeaponsAsync(GetDataRequest request, CancellationToken cancellationToken);
    public Task<Armor[]> GetArmorAsync(GetDataRequest request, CancellationToken cancellationToken);
}
public class ValorantApiService(ValorantApiSettings valorantApiSettings, HttpClient httpClient) : IValorantApiService
{
    public async Task<Agent[]> GetAgentsAsync(GetDataRequest request, CancellationToken cancellationToken)
    {
        var requestUrl = QueryHelpers.AddQueryString(valorantApiSettings.BaseUrl + $"agents/", nameof(GetDataRequest.Limit), request.Limit.ToString());
        var json = await httpClient.GetStringAsync(requestUrl, cancellationToken);
        var getAgentResponse = GetAgentsResponse.FromJson(json);

        return getAgentResponse!.Data;
    }

    public async Task<Map[]> GetMapsAsync(GetDataRequest request, CancellationToken cancellationToken)
    {
        var requestUrl = QueryHelpers.AddQueryString(valorantApiSettings.BaseUrl + $"maps/", nameof(GetDataRequest.Limit), request.Limit.ToString());
        var json = await httpClient.GetStringAsync(requestUrl, cancellationToken);
        var getMapResponse = GetMapResponse.FromJson(json);

        return getMapResponse!.Data;
    }

    public async Task<Weapon[]> GetWeaponsAsync(GetDataRequest request, CancellationToken cancellationToken)
    {
        var requestUrl = QueryHelpers.AddQueryString(valorantApiSettings.BaseUrl + $"weapons/", nameof(GetDataRequest.Limit), request.Limit.ToString());
        var json = await httpClient.GetStringAsync(requestUrl, cancellationToken);
        var getWeaponResponse = GetWeaponResponse.FromJson(json);

        return getWeaponResponse!.Data;
    }

        public async Task<Armor[]> GetArmorAsync(GetDataRequest request, CancellationToken cancellationToken)
    {
        var requestUrl = QueryHelpers.AddQueryString(valorantApiSettings.BaseUrl + $"gear/", nameof(GetDataRequest.Limit), request.Limit.ToString());
        var json = await httpClient.GetStringAsync(requestUrl, cancellationToken);
        var getArmorResponse = GetArmorResponse.FromJson(json);

        return getArmorResponse!.Data;
    }
}

public class ValorantApiSettings
{
    public const string ValorantApi = nameof(ValorantApi);
    public string BaseUrl => "https://valorant-api.com/v1/";
}

public class GetDataRequest
{
    public int Limit { get; set; } = int.MaxValue;
}
using MediatR;
using Microsoft.AspNetCore.Components;
using ValorantInfoApp.Shared;
using ValorantInfoApp.Infrastructure.Maps;

namespace ValorantInfoApp.Features.Pages;

public partial class Maps : IDisposable
{
    [Inject] private IMediator Mediator {get; set;} = null!;

    private readonly CancellationTokenSource _cts = new();
    private readonly MapRequest _request = new();
    private MapResponse _response = new();
    private bool _isLoading;

    protected override async Task OnInitializedAsync()
    {
        _isLoading = true;
    try
    {
        _response = await Mediator.Send(_request, _cts.Token);
    }
    catch (Exception ex)
    {
        // Handle any errors here, e.g., logging or displaying an error message
        Console.WriteLine($"Error fetching data: {ex.Message}");
    }
    finally
    {
        _isLoading = false;
    }
    }

    public void Dispose()
    {
        _cts.Cancel();
        _cts.Dispose();
    }
}

public class MapRequest : IRequest<MapResponse>
{
}

public class MapRequestHandler(IValorantApiService valorantApiService) : IRequestHandler<MapRequest, MapResponse>
{
    public async Task<MapResponse> Handle(MapRequest request, CancellationToken cancellationToken = default)
    {
        var maps = await valorantApiService.GetMapsAsync(new GetDataRequest(), cancellationToken);
        maps = maps.Where(m => !(m.DisplayName == "The Range")).OrderBy(a => a.DisplayName).ToArray();

        return new MapResponse { Maps = maps };
    }
}

public class MapResponse
{
    public IEnumerable<Map> Maps { get; set; } = [];
}
using MediatR;
using Microsoft.AspNetCore.Components;
using ValorantInfoApp.Infrastructure.Maps;
using ValorantInfoApp.Shared;

namespace ValorantInfoApp.Features.Pages;

public partial class MapDetails
{
    [Parameter]
    public string Id { get; set; } = string.Empty;
    [Inject] private IMediator Mediator { get; set; } = null!;

    private readonly CancellationTokenSource _cts = new();
    private readonly MapDetailsRequest _request = new();
    private MapDetailsResponse _response = new();
    private bool _isLoading;

    protected async override Task OnInitializedAsync()
    {
        _isLoading = true;
        try
        {
            _request.Id = Id;
            _response = await Mediator.Send(_request, _cts.Token);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching data: {ex.Message}");
        }
        finally
        {
            _isLoading = false;
        }
    }

    public class MapDetailsRequestHandler(IValorantApiService valorantApiService) : IRequestHandler<MapDetailsRequest, MapDetailsResponse>
    {
        public async Task<MapDetailsResponse> Handle(MapDetailsRequest request, CancellationToken cancellationToken)
        {
            var map = await valorantApiService.GetMapByUuidAsync(new GetDataRequest { Uuid = new Guid(request.Id) }, cancellationToken);

            return new MapDetailsResponse { Map = map };
        }
    }

    public class MapDetailsRequest : IRequest<MapDetailsResponse>
    {
        public string Id { get; set; } = null!;
    }

    public class MapDetailsResponse
    {
        public IEnumerable<string> MapsNeededRotated = ["Ascent", "Abyss", "Haven", "Icebox", "Split"];
        public Map Map { get; set; } = null!;

        public double GetRelativeX(double x, double multiplier, double scalar)
        {
            var coords = (x * multiplier) + scalar*1.1;
            return coords * 600;
        }

        public double GetRelativeY(double y, double multiplier, double scalar)
        {
            var coords =  (-y * multiplier) + scalar*1.3;

            return coords * 700;
        }
    }
}
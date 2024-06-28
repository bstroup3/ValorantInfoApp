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
        public IEnumerable<string> MapsNeededRotated = ["Ascent", "Abyss", "Haven", "Icebox", "Split", "Bind", "Breeze", "Fracture", "Lotus", "Pearl", "Sunset"];
        public Map Map { get; set; } = null!;        
        public static readonly Dictionary<string, double> MapXModifier = new()
        {
            {"Ascent", 1.1},
            {"Abyss", 2d},
            {"Bind", 0.9d},
            {"Breeze", 1.5d},
            {"District", 1.5d},
            {"Drift", 1.5d},
            {"Fracture", 0.6d},
            {"Haven", 0.77d},
            {"Icebox", 2.6d},
            {"Kasbah", 2.6d},
            {"Lotus", 1.2d},
            {"Pearl", 1.2d},
            {"Piazza", 1.2d},
            {"Split", 0.95d},
            {"Sunset", 2d},
        };

        public static readonly Dictionary<string, double> MapYModifier = new()
        {
            {"Ascent", 1.4},
            {"Abyss", 1d},
            {"Bind", 0.57d},
            {"Breeze", 0.5d},
            {"District", 0.5d},
            {"Drift", 0.5d},
            {"Fracture", 0.5d},
            {"Haven", 1.7d},
            {"Icebox", 1.5d},
            {"Kasbah", 1.5d},
            {"Lotus", 0.45d},
            {"Pearl", 0.5d},
            {"Piazza", 0.5d},
            {"Split", 1.2d},
            {"Sunset", 1.1d},
        };
        public double GetRelativeX(double x, double multiplier, double scalar, string name)
        {
            var coords = (x * multiplier) + scalar * MapXModifier[$"{name}"];
            return coords * 600;
        }

        public double GetRelativeY(double y, double multiplier, double scalar, string name)
        {
            var coords = (-y * multiplier) + scalar * MapYModifier[$"{name}"];

            return coords * 600;
        }
    }
}
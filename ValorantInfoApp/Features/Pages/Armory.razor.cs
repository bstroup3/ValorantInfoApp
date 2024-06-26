using MediatR;
using Microsoft.AspNetCore.Components;
using ValorantInfoApp.Shared;
using ValorantInfoApp.Infrastructure.Weapons;
using ValorantInfoApp.Infrastructure.Armor;

namespace ValorantInfoApp.Features.Pages;

public partial class Armory : IDisposable
{
    [Inject] private IMediator Mediator {get; set;} = null!;

    private readonly CancellationTokenSource _cts = new();
    private readonly ArmoryRequest _request = new();
    private ArmoryResponse _response = new();
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

public class ArmoryRequest : IRequest<ArmoryResponse>
{
}

public class ArmoryRequestHandler(IValorantApiService valorantApiService) : IRequestHandler<ArmoryRequest, ArmoryResponse>
{
    public async Task<ArmoryResponse> Handle(ArmoryRequest request, CancellationToken cancellationToken = default)
    {
        var weapons = await valorantApiService.GetWeaponsAsync(new GetDataRequest(), cancellationToken);
        var armor = await valorantApiService.GetArmorAsync(new GetDataRequest(), cancellationToken);

        var sidearms = weapons.Where(w => w.Category.Contains("Sidearm")).OrderBy(w => w.ShopData.Cost);
        var shotguns = weapons.Where(w => w.Category.Contains("Shotgun"));
        var rifles = weapons.Where(w => w.Category.Contains("Rifle"));
        var smgs = weapons.Where(w => w.Category.Contains("SMG"));
        var snipers = weapons.Where(w => w.Category.Contains("Sniper"));
        var heavys = weapons.Where(w => w.Category.Contains("Heavy"));

        return new ArmoryResponse {
            Sidearms = sidearms,
            Shotguns = shotguns,
            Rifles = rifles,
            Smgs = smgs,
            Snipers = snipers,
            Heavys = heavys,
            Armor = armor
        };
    }
}

public class ArmoryResponse
{
    public IEnumerable<Weapon> Sidearms { get; set; } = [];
    public IEnumerable<Weapon> Shotguns { get; set; } = [];
    public IEnumerable<Weapon> Rifles { get; set; } = [];
    public IEnumerable<Weapon> Smgs { get; set; } = [];
    public IEnumerable<Weapon> Snipers { get; set; } = [];
    public IEnumerable<Weapon> Heavys { get; set; } = [];
    public IEnumerable<Armor> Armor {get; set; } = [];
}
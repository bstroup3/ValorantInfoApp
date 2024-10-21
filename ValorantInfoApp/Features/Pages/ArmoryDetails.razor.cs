using MediatR;
using Microsoft.AspNetCore.Components;
using ValorantInfoApp.Infrastructure.Agents;
using ValorantInfoApp.Infrastructure.Weapons;
using ValorantInfoApp.Shared;

namespace ValorantInfoApp.Features.Pages;

public partial class ArmoryDetails
{
    [Parameter]
    public string Id { get; set; } = string.Empty;
    [Inject] private IMediator Mediator { get; set; } = null!;

    private readonly CancellationTokenSource _cts = new();
    private readonly ArmoryDetailsRequest _request = new();
    private ArmoryDetailsResponse _response = new();
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

    public class ArmoryDetailsRequestHandler(IValorantApiService valorantApiService) : IRequestHandler<ArmoryDetailsRequest, ArmoryDetailsResponse>
    {
        public async Task<ArmoryDetailsResponse> Handle(ArmoryDetailsRequest request, CancellationToken cancellationToken)
        {
            var weapon = await valorantApiService.GetWeaponByUuidAsync(new GetDataRequest { Uuid = new Guid(request.Id) }, cancellationToken);

            return new ArmoryDetailsResponse { Weapon = weapon };
        }
    }

    public class ArmoryDetailsRequest : IRequest<ArmoryDetailsResponse>
    {
        public string Id { get; set; } = null!;
    }

    public class ArmoryDetailsResponse
    {
        public Weapon Weapon { get; set; } = null!;
    }
}
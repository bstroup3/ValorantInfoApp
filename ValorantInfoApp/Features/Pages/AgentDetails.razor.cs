using MediatR;
using Microsoft.AspNetCore.Components;
using ValorantInfoApp.Infrastructure.Agents;
using ValorantInfoApp.Shared;

namespace ValorantInfoApp.Features.Pages;

public partial class AgentDetails
{
    [Parameter]
    public string Id { get; set; } = string.Empty;
    [Inject] private IMediator Mediator { get; set; } = null!;

    private readonly CancellationTokenSource _cts = new();
    private readonly AgentDetailsRequest _request = new();
    private AgentDetailsResponse _response = new();
    private bool _isLoading;
    private Ability _currentAbility = new();

    protected async override Task OnInitializedAsync()
    {
        _isLoading = true;
        try
        {
            _request.Id = Id;
            _response = await Mediator.Send(_request, _cts.Token);
            _currentAbility = _response.Agent.Abilities.First();
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

    public class AgentDetailsRequestHandler(IValorantApiService valorantApiService) : IRequestHandler<AgentDetailsRequest, AgentDetailsResponse>
    {
        public async Task<AgentDetailsResponse> Handle(AgentDetailsRequest request, CancellationToken cancellationToken)
        {
            var agent = await valorantApiService.GetAgentByUuidAsync(new GetDataRequest { Uuid = new Guid(request.Id) }, cancellationToken);

            return new AgentDetailsResponse { Agent = agent };
        }
    }

    public class AgentDetailsRequest : IRequest<AgentDetailsResponse>
    {
        public string Id { get; set; } = null!;
    }

    public class AgentDetailsResponse
    {
        public Agent Agent { get; set; } = null!;
    }

    public void UpdateCurrentAbility(Ability ability)
    {
        _currentAbility = ability;
        Console.Write("The code has gotten to here");
        StateHasChanged();
    }
}
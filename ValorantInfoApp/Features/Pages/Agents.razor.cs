using MediatR;
using Microsoft.AspNetCore.Components;
using ValorantInfoApp.Shared;
using ValorantInfoApp.Infrastructure.Agents;

namespace ValorantInfoApp.Features.Pages;

public partial class Agents : IDisposable
{
    [Inject] private IMediator Mediator {get; set;} = null!;

    private readonly CancellationTokenSource _cts = new();
    private readonly AgentRequest _request = new();
    private AgentResponse _response = new();
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

public class AgentRequest : IRequest<AgentResponse>
{
}

public class AgentRequestHandler(IValorantApiService valorantApiService) : IRequestHandler<AgentRequest, AgentResponse>
{
    public async Task<AgentResponse> Handle(AgentRequest request, CancellationToken cancellationToken = default)
    {
        var agents = await valorantApiService.GetAgentsAsync(new GetDataRequest(), cancellationToken);
        agents = agents.Where(a => !a.DeveloperName.Contains("NPE")).OrderBy(a => a.DisplayName).ToArray(); //removes tutorial Sova

        return new AgentResponse { Agents = agents };
    }
}

public class AgentResponse
{
    public IEnumerable<Agent> Agents { get; set; } = [];
}
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace HealthCheck;

public class HealthChecks : IHealthCheck
{
    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        string descriptionHealthy = "My API is healthy";
        string descriptionNotHealthy = "My API is not healthy";
        try
        {
            return HealthCheckResult.Healthy(descriptionHealthy);

        }
        catch (Exception ex)
        {
            return HealthCheckResult.Unhealthy(descriptionNotHealthy);
        }
    }
}
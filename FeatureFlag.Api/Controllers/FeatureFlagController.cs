using Microsoft.AspNetCore.Mvc;
using FeatureFlag.Contracts.Requests;
using FeatureFlag.Application.Services;

namespace FeatureFlag.Api.Controllers;

[ApiController]
public class FeatureFlagController(IFeatureFlagService _featureFlagService) : ControllerBase
{


    [HttpPost(Endpoints.FeatureFlag.Create)]
    public async Task<IActionResult> Create(
        [FromBody] CreateFeatureFlagRequest request,
        CancellationToken token)
    {
        var featureToggle = request.MapToFeatureToggle();
        await _featureFlagService.CreateAsync(featureToggle, token);

        var featureFlagResponse = featureToggle.MapCreatedResponse();
        return CreatedAtAction(nameof(Get), new { idOrName = featureToggle.Id }, featureFlagResponse);
    }

    [HttpGet(Endpoints.FeatureFlag.GetAll)]
    public async Task<IActionResult> GetAll(CancellationToken token)
    {
        var featureFlags = await _featureFlagService.GetAllAsync(token);
        return Ok(featureFlags);
    }

    [HttpGet(Endpoints.FeatureFlag.Get)]
    public async Task<IActionResult> Get(
        [FromRoute] string idOrName,
        CancellationToken token)
    {
        var featureFlag = await _featureFlagService.GetByIdOrNameAsync(idOrName, token);
        if (featureFlag is null)
        {
            return NotFound();
        }
        
        return Ok(featureFlag.MapToSingleResponse());
    }

    [HttpPut(Endpoints.FeatureFlag.Update)]
    public async Task<IActionResult> Update(
        [FromRoute] Guid id,
        [FromBody] UpdateFeatureFlagRequest request,
        CancellationToken token)
    {
        var updatedFeatureFlag = await _featureFlagService.ToggleActivationAsync(token);
        if (updatedFeatureFlag is null)
        {
            return NotFound();
        }
        
        return Ok();
    }

    [HttpDelete(Endpoints.FeatureFlag.Delete)]
    public async Task<IActionResult> Delete(
        [FromRoute] Guid id,
        CancellationToken token)
    {
        var deleted = await _featureFlagService.DeleteByIdAsync(id, token);
        if (!deleted)
        {
            return NotFound();
        }
        return Ok();
    }

    
    [HttpPut(Endpoints.FeatureFlag.UpdatePartially)]
    public async Task<IActionResult> SetPartialActivation(
        [FromRoute] Guid id,
        [FromBody] UpdatePartiallyRequest request,
        CancellationToken token)
    {       
        throw await Task.FromException<NotImplementedException>(new NotImplementedException());
    }
}

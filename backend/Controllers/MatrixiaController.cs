using Microsoft.AspNetCore.Mvc;
using MatrixiaApi.Contracts;
using MatrixiaApi.Services;

namespace MatrixiaApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MatrixiaController : ControllerBase
{
    [HttpPost("determinant")]
    public IActionResult CalculateDeterminant([FromBody] DeterminantRequest request)
    {
        try
        {
            var result = MatrixService.CalculateDeterminant(request.Matrix, request.ShowSteps);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest($"Error calculating determinant: {ex.Message}");
        }
    }

    [HttpPost("rank")]
    public IActionResult CalculateRank([FromBody] RankRequest request)
    {
        try
        {
            int rank = MatrixService.CalculateRank(request.Matrix);
            return Ok(new { Rank = rank });
        }
        catch (ArgumentException ex)
        {
            return BadRequest($"Error calculating rank: {ex.Message}");
        }
    }

    [HttpPost("inverse")]
    public IActionResult CalculateInverse([FromBody] InverseRequest request)
    {
        try
        {
            double[][] inverse = MatrixService.CalculateInverse(request.Matrix);
            return Ok(inverse);
        }
        catch (ArgumentException ex)
        {
            return BadRequest($"Error calculating inverse: {ex.Message}");
        }
    }
}


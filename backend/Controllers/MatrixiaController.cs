using Microsoft.AspNetCore.Mvc;
using MatrixiaApi.Contracts;
using MatrixiaApi.Services;

namespace MatrixiaApi.Controllers;

/// <summary>
/// Controller for performing matrix operations for e.g.: determinant, rank, inverse, transpose, and adjoint.
/// </summary>
[ApiController]
[Route("[controller]")]
public class MatrixiaController : ControllerBase
{
    /// <summary>
    /// Calculates the determinant of a matrix.
    /// </summary>
    /// <param name="request">The request containing the matrix and a flag indicating whether to show steps.</param>
    /// <returns>The determinant of the matrix and the steps if requested.</returns>
    [HttpPost("determinant")]
    public IActionResult CalculateDeterminant([FromBody] DeterminantRequest request)
    {
        try
        {
            var result = MatrixService.CalculateDeterminant(request.Matrix, request.ShowSteps ?? false);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest($"Error calculating determinant: {ex.Message}");
        }
    }

    /// <summary>
    /// Calculates the rank of a matrix.
    /// </summary>
    /// <param name="request">The request containing the matrix.</param>
    /// <returns>The rank of the matrix.</returns>
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

    /// <summary>
    /// Calculates the inverse of a matrix.
    /// </summary>
    /// <param name="request">The request containing the matrix.</param>
    /// <returns>The inverse of the matrix.</returns>
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

    /// <summary>
    /// Calculates the transpose of a matrix.
    /// </summary>
    /// <param name="request">The request containing the matrix.</param>
    /// <returns>The transposed matrix.</returns>
    [HttpPost("transpose")]
    public IActionResult CalculateTranspose([FromBody] TransposeRequest request)
    {
        try
        {
            double[][] transposedMatrix = MatrixService.CalculateTranspose(request.Matrix);
            return Ok(transposedMatrix);
        }
        catch (ArgumentException ex)
        {
            return BadRequest($"Error calculating transposed matrix: {ex.Message}");
        }
    }

    /// <summary>
    /// Calculates the adjoint (or adjugate) of a matrix.
    /// </summary>
    /// <param name="request">The request containing the matrix.</param>
    /// <returns>The adjoint of the matrix.</returns>
    [HttpPost("adjugate")]
    public IActionResult CalculateAdjoint([FromBody] AdjointRequest request)
    {
        try
        {
            double[][] adjointMatrix = MatrixService.CalculateAdjoint(request.Matrix);
            return Ok(adjointMatrix);
        }
        catch (ArgumentException ex)
        {
            return BadRequest($"Error calculating adjugate of the matrix: {ex.Message}");
        }
    }
}
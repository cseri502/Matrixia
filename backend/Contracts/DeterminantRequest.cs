namespace MatrixiaApi.Contracts;

public record class DeterminantRequest(double[][] Matrix, bool? ShowSteps, bool? UseFractions);

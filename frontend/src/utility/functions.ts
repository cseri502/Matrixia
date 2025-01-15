export const formatNumber = (value: number): string => {
  return value % 1 === 0
    ? value.toString()
    : parseFloat(value.toFixed(2)).toString();
};

export function wait(ms: number): Promise<void> {
  return new Promise((resolve) => setTimeout(resolve, ms));
}

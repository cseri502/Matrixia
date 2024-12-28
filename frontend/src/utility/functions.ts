export const formatNumber = (value: number): string => {
    return value % 1 === 0 ? value.toString() : parseFloat(value.toFixed(2)).toString();
};

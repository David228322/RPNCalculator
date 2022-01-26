using System;

namespace BLL
{
    /// <summary>
    /// Calculate operation.
    /// </summary>
    public class CalculatorService
    {
        private readonly double operand1;
        private readonly double operand2;

        /// <summary>
        /// Initializes a new instance of the <see cref="CalculatorService"/> class.
        /// </summary>
        /// <param name="operand1">First operand for operation.</param>
        /// <param name="operand2">Second operand for operation.</param>
        public CalculatorService(double operand1, double operand2)
        {
            this.operand1 = operand1;
            this.operand2 = operand2;
        }
        public double Sum() => this.operand1 + this.operand2;

        public double Sub() => this.operand2 - this.operand1;

        public double Multiply() => this.operand1 * this.operand2;

        public double Divide() => this.operand1 != 0 ? this.operand2 / this.operand1 : 0;

        public double Remainder() => this.operand2 % this.operand1;

        public double Power() => Math.Pow(this.operand2, this.operand1);
    }
}

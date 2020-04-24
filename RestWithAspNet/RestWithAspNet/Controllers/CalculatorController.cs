using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RestWithAspNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {

        // GET api/{Plus,Minus,Times,Divided,Square/Mean}/5/5
        [HttpGet("{operation}/{firstNumber}/{secondNumber}")]
        public ActionResult<string> Calc(string operation, string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                List<String> checkOperation = new List<String>
                {
                    "plus",
                    "minus",
                    "times",
                    "divided",
                    "squared",
                    "mean",
                    "square-root"
                };
                
                if (checkOperation.Contains(operation.ToLower()))
                {
                    double result = 0;
                    if (operation.ToLower() == "plus".ToLower())
                    {
                        result = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                    }
                    else if (operation.ToLower() == "minus".ToLower())
                    {
                        result = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                    }
                    else if (operation.ToLower() == "times".ToLower())
                    {
                        result = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                    }
                    else if (operation.ToLower() == "divided".ToLower())
                    {
                        result = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                    }
                    else if (operation.ToLower() == "squared".ToLower())
                    {
                        result = ConvertToDecimal(firstNumber) * ConvertToDecimal(firstNumber);
                    }
                    else if (operation.ToLower() == "mean".ToLower())
                    {
                        result = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;
                    }
                    else if (operation.ToLower() == "square-root".ToLower())
                    {
                        result = Math.Sqrt((double)ConvertToDecimal(firstNumber));
                    }

                    return Ok(result.ToString());
                }

            }
            return BadRequest("Invalid Input");
        }

        private double ConvertToDecimal(string number)
        {
            return double.TryParse(number, out double decimalValue) ? decimalValue : 0;
        }

        private bool IsNumeric(string strNumber)
        {
            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out double number);
            return isNumber;
        }
    }
}

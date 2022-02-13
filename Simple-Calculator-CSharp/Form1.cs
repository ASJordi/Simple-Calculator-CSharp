using System;
using System.Linq;
using System.Windows.Forms;

namespace Simple_Calculator_CSharp
{
    public partial class frmCalculator : Form
    {
        #region variables
        //only support this operations
        string[] _operatorList = new string[] { "+", "-", "*", "/" };

        //_reservedNumber1 is before operator entered, _reservedNumber2 will be set after = 
        double? _reservedNumber1 = null, _reservedNumber2 = null;

        // Operator selected
        string _operator = null;

        //clear all results after operation
        bool _clearText = false;
        #endregion

        public frmCalculator()
        {
            InitializeComponent();
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            // all buttons will be handled here.

            var text = ((Button)sender).Text;

            //if the button is an operator i need store the first value

            var isOperator = _operatorList.Any(p => p == text);
            if (isOperator)
            {
                if (double.TryParse(txtInput.Text, out double temp))
                {
                    _reservedNumber1 = temp;
                    txtInput.Clear();
                    lblResult.Text = $"{_reservedNumber1} {text}";
                    _operator = text;
                }
            }
            else
            if (text == "=")
            {
                if (double.TryParse(txtInput.Text, out double temp))
                {
                    _reservedNumber2 = temp;
                }

                Calculate();
                _clearText = true;
            }
            else
            {
                if (_clearText)
                {
                    txtInput.Text = text;
                    // only once will be clreader then rest will be the same flow
                    _clearText = false;
                }
                else
                {
                    txtInput.Text += text;
                }
            }
        }

        private void Calculate()
        {
            double? result = 0;

            switch (_operator)
            {
                case "+":
                    result = _reservedNumber2 + _reservedNumber1;
                    break;
                case "-":
                    result = _reservedNumber1 - _reservedNumber2;
                    break;
                case "*":
                    result = _reservedNumber2 * _reservedNumber1;
                    break;
                case "/":
                    result = _reservedNumber1 / _reservedNumber2;
                    break;
                default:
                    break;
            }

            lblResult.Text = result.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtInput.Clear();
            lblResult.Text = string.Empty;
        }
    }
}
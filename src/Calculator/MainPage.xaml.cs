using System.Diagnostics;
using System.Threading.Tasks;

namespace Calculator;

public partial class MainPage : ContentPage
{
    /// <summary>
    /// Inicializa los componentes de la calculadora y ejecuta un metodo clear para limpiar los resultados
    /// </summary>
    public MainPage()
    {
        InitializeComponent();
          
        OnClear(this, null);

    }

    //Variables que establecen el numero en el que nos encontarmos, el numero que estamos metiendo, el operador, el formato decimal y los numeros en double
    string currentEntry = "";
    int currentState = 1;
    string mathOperator;
    double firstNumber, secondNumber;
    string decimalFormat = "N2";
    
    
    /// <summary>
    /// Metodo que se aplica cuando introduces un numero mediante un boton
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void OnSelectNumber(object sender, EventArgs e)
    {
    
        Button button = (Button)sender;
        string pressed = button.Text;

        currentEntry += pressed;

        if ((this.resultText.Text == "0" && pressed == "0")
            || (currentEntry.Length <= 1 && pressed != "0")
            || currentState < 0)
        {
            this.resultText.Text = "";
            if (currentState < 0)
                currentState *= -1;
        }

        if (pressed == "." && decimalFormat != "N2")
        {
            decimalFormat = "N2";
        }

        this.resultText.Text += pressed;
    }
    /// <summary>
    /// Metodo para seleccionar el operador
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void OnSelectOperator(object sender, EventArgs e)
    {
        //Se guarda el numero en su slot correspondiente
        LockNumberValue(resultText.Text);

        currentState = -2;
        Button button = (Button)sender;
        string pressed = button.Text;
        //Seteo el operador
        mathOperator = pressed;            
    }

    private void LockNumberValue(string text)
    {
        double number;
        if (double.TryParse(text, out number))
        {
            if (currentState == 1)
            {
                firstNumber = number;
            }
            else
            {
                secondNumber = number;
            }

            currentEntry = string.Empty;
        }
    }
    /// <summary>
    /// Este metodo borra los dos numeros que tenemos guardados y limpia la pantalla
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void OnClear(object sender, EventArgs e)
    {
        firstNumber = 0;
        secondNumber = 0;
        currentState = 1;
        decimalFormat = "N2";
        this.resultText.Text = "0";
        currentEntry = string.Empty;
    }
    /// <summary>
    /// Este metodo realiza el calculo cuando se pulsa el igual
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void OnCalculate(object sender, EventArgs e)
    {
        if (currentState == 2)
        {
           
                //Se guarda el segundo numero
                LockNumberValue(resultText.Text);
            //Se realiza el calculo
            double result = Calculator.Calculate(firstNumber, secondNumber, mathOperator);

            this.CurrentCalculation.Text = $"{firstNumber} {mathOperator} {secondNumber}";
      
            this.resultText.Text = result.ToTrimmedString(decimalFormat);
            
               
            firstNumber = result;
            secondNumber = 0;
            currentState = -1;
            currentEntry = string.Empty;
        }
    }    

    /// <summary>
    /// Met6do para convertir un numero a negativo. No funciona bien
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void OnNegative(object sender, EventArgs e)
    {
        if (currentState == 1)
        {
            secondNumber = -1;
            mathOperator = "×";
            currentState = 2;
            OnCalculate(sender, e);
        }
    }




    /// <summary>
    /// Metodo para calcular porcentajes. No funciona bien
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void OnPercentage(object sender, EventArgs e)
    {
        if (currentState == 1)
        {
            //Se guarda el numero, se establece un segundo numero 0.01 y 2 decimales de formato
            LockNumberValue(resultText.Text);
            decimalFormat = "N2";
            secondNumber = 0.01;
            mathOperator = "×";
            currentState = 2;
            //Se multiplican los 2 numeros para obtener el porcenataje. La operación no tiene mucho sentido, pues no nos deja
            //Calcular el porcentaje de un numero respecto a otro. 
            OnCalculate(sender, e);
        }
    }
}

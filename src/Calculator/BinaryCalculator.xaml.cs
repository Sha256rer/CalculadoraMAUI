using System.Diagnostics;

namespace Calculator;

public partial class BinaryCalculator : ContentPage
{

    string currentEntry = "";
    bool mode;
    int number;
    bool binCalculado;

    public BinaryCalculator()
	{
		InitializeComponent();
        mode = true;
        binCalculado = false;
	}
    void OnClear(object sender, EventArgs e)
    {
        number = 0;
      
        
        this.resultText.Text = "0";
        currentEntry = string.Empty;
    }
    private void LockNumberValue(string text)
    {
        int n = 0 ;
        if (int.TryParse(text, out n))
        {
            number = n;
            currentEntry = string.Empty;
        }
    }
    /// <summary>
    /// Metodo para modificar la interfaz de un metdodo de conversion al otro
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Button_Clicked(object sender, EventArgs e)
    {
        //Mode inicia en verdadero(decimal to bin) si es asi, false.
        if (mode)
        {
            mode = false;
        }
        //True si no
        else {
            mode = true;
        }
        //El modo de decimal a bin tiene 4 cols. Si tenemos 3, añadimos una y si no nos cargamos la útlima
        if (LayoutDecimal.ColumnDefinitions.Count == 3)
        {
            LayoutDecimal.ColumnDefinitions.Add(new ColumnDefinition());
        }
        else
        {

            LayoutDecimal.ColumnDefinitions.Remove(LayoutDecimal.ColumnDefinitions.Last());
        }
        //Este bucle recorre todos los elementos del layout y si son botones los ponemos en el modo contrario al que se encuentran
        //Por defecto, empiezan visibles los de Decimal to bin

            for (int i = 0; i < LayoutDecimal.Count; i++)
            {
                if (LayoutDecimal.Children[i] is Button)
                {

                    Button b = (Button)LayoutDecimal.Children[i];
                    if (b.IsVisible)
                    {
                        b.IsVisible = false;
                    }
                    else
                    {
                        b.IsVisible = true;
                    }

                }
            }
        OnClear(sender, e);


       // BinCalcContent.Content =  ;
           
    }
    /// <summary>
    /// Metodo para el calculo de binario a decimal
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void BinToDecimal(object sender, EventArgs e)
    {
        //Metodo que convierte el texto a un numero
        LockNumberValue(resultText.Text);
        //Pasamos el método a la calculadora para que lo transforme a decimal
        String res = Calculator.TransformDec(number);
        Debug.WriteLine("Resultado: " + res);
        //Establecemos el result como el dato que acabamos de meter.
        this.resultText.Text = res;
        //Como quiero que se pueda empezar por 0 los numeros binarios, utilizo una booleana para llevar la cuenta
        //De cuando he calculado un resultado
        binCalculado = true;
    }
    /// <summary>
    /// Transformación de binario a decimal
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void DecimalToBin(object sender, EventArgs e)
    { //Guarda el numero que hay en el result text en number
        LockNumberValue(resultText.Text);
        //Lo mando al metodo estatico de la calculadora 
        String res =  Calculator.TransformBin(number);
        Debug.WriteLine("Resultado: " + res);
        this.resultText.Text = res;
    }

    void OnSelectNumber(object sender, EventArgs e)
    {

        Button button = (Button)sender;
        string pressed = button.Text;
        if (pressed != "0"  && mode) { 
        currentEntry += pressed;
        }

        if ((currentEntry.Length <= 1 ) && mode )//Esto solo lo hago en la parte decimal porque quiero poder empezar los binarios con 0
            
        {
            this.resultText.Text = "";
          
        }
        //Utilizo este if para hacer lo mismo que hace el de arriba. Pero aqui tengo la intencion
        //De que el usuario pueda empezar con 0 las cadenas 
        if (binCalculado && !mode) {
            this.resultText.Text = "";
            binCalculado = false;
        }

        if (this.resultText.Text.Length > 8)
        {
            this.resultText.Text += "";
        }

        else {
            this.resultText.Text += pressed;
        }
    }
}
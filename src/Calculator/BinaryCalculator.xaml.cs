using System.Diagnostics;

namespace Calculator;

public partial class BinaryCalculator : ContentPage
{

    string currentEntry = "";
    //Controla modo de la calculadora
    bool mode;
    //Parametro numerico para el n decimal o binario que pasemos
    int number;


    public BinaryCalculator()
	{
		InitializeComponent();
        //Por defecto en modo decimal to bin
        mode = true;
  
	}
    /// <summary>
    /// On clear, establece a 0 el string y su version numerica
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void OnClear(object sender, EventArgs e)
    {
        number = 0;
        this.resultText.Text = "0";
        currentEntry = string.Empty;
    }

    /// <summary>
    /// Guarda el valor de un string en el numero 
    /// </summary>
    /// <param name="text"></param>
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
    private void Change_Mode(object sender, EventArgs e)
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

    /// <summary>
    /// Metodo que se ejecuta cada vez que presionamos un numero en la calculadora
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void OnSelectNumber(object sender, EventArgs e)
    {
    
        //capturamos el boton del evento
        Button button = (Button)sender;
        //Obtenemos su valor en texto
        string pressed = button.Text;
        //Si es distinto de 0 y estamos en modo decimal to bin se añade
        //Esto es para que no me empiecen los n decimales por 0
        if (pressed != "0" && mode)
        {
            currentEntry += pressed;
        }
        //Si es binario, da igual que sea 0, se añade
        else if(!mode) {
            currentEntry += pressed;
        }
        //Elimina el 0 inicial y pone el texto en blanco antes de poner el 1 caracter que indiques
        if ((currentEntry.Length <= 1))

        {
            this.resultText.Text = "";

        }

        //Limite de la calculadora, solo le ponemos poner 8 cifras
        if (this.resultText.Text.Length > 8)
        {
            this.resultText.Text += "";
        }
        //Si no añado el numero.
        else {
            this.resultText.Text += pressed;
        }
    }
}
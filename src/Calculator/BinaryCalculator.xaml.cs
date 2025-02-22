using System.Diagnostics;

namespace Calculator;

public partial class BinaryCalculator : ContentPage
{

    string currentEntry = "";
    bool mode;
    string mathOperator;
    int number;
   

    public BinaryCalculator()
	{
		InitializeComponent();
        mode = true;
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
    private void Button_Clicked(object sender, EventArgs e)
    {
        if (mode)
        {
            mode = false;
        }
        else {
            mode = true;
        }

        if (LayoutDecimal.ColumnDefinitions.Count == 3)
        {
            LayoutDecimal.ColumnDefinitions.Add(new ColumnDefinition());
        }
        else
        {

            LayoutDecimal.ColumnDefinitions.Remove(LayoutDecimal.ColumnDefinitions.Last());
        }

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

    private void BinToDecimal(object sender, EventArgs e)
    {
        LockNumberValue(resultText.Text);
        String res = Calculator.TransformDec(number);
        Debug.WriteLine("Resultado: " + res);
        this.resultText.Text = res;
    }

    private void DecimalToBin(object sender, EventArgs e)
    {
        LockNumberValue(resultText.Text);
        String res =  Calculator.TransformBin(number);
        Debug.WriteLine("Resultado: " + res);
        this.resultText.Text = res;
    }

    void OnSelectNumber(object sender, EventArgs e)
    {

        Button button = (Button)sender;
        string pressed = button.Text;

        currentEntry += pressed;

        if (
            (
            (this.resultText.Text == "0" && pressed == "0")
            || 
            (currentEntry.Length <= 1 && pressed != "0")
            )
            && mode
            )
        {
            this.resultText.Text = "";
          
        }

    

        this.resultText.Text += pressed;
    }
}
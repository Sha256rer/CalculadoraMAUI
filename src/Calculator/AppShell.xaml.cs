namespace Calculator
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("BinaryCalculator", typeof(BinaryCalculator));

        }
    }
}

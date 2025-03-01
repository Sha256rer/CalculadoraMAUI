namespace Calculator
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {

            InitializeComponent();
            Application.Current.UserAppTheme = AppTheme.Dark;
            Routing.RegisterRoute("BinaryCalculator", typeof(BinaryCalculator));
       

        }

        /// <summary>
        /// Metodo para cambiar de tema diurno a nocturno. Cambioo la imagen del ImageButton que establezco en el xaml.
        /// Y el Application.Current.UserTheme. Este a su vez cambia muchas etiquetas xaml vinculadas a application theme
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThemeChange(object sender, EventArgs e)
        {

            if (Application.Current.UserAppTheme != AppTheme.Dark)
            {
                Application.Current.UserAppTheme = AppTheme.Dark;
                botonTheme.Source = "brightness.png";
            }
            else {
                Application.Current.UserAppTheme = AppTheme.Light;
                botonTheme.Source = "sleepmode.png";
            }
           
        }
    }
}

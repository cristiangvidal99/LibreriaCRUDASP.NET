namespace proyecto.Data
{
    public class Connection
    {
        // propiedad

        private string cadenaSQL = string.Empty; // empty para que inicie vacio a proposito

        // constructor de la clase

        public Connection()
        {
            // accediendo a ese script
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            // guarda el valor de cadenasql
            cadenaSQL = builder.GetSection("ConnectionStrings:cadenaSQL").Value;
        }
        public string CadenaSQL() { return cadenaSQL; } // getter de la clase
    }
}
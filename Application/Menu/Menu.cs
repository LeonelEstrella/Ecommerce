using Application.Interfaces.Menu;

namespace Application.Menu
{
    public class Menu : IMenu
    {
        private bool exit = false;
        public void ShowOptions()
        {
            Console.WriteLine("Que desea realizar? \n" +
                "1- Registar cliente. \n" +
                "2- Registrar ventas del día. \n" +
                "3- Reporte de ventas del día. \n" +
                "4- Búsqueda de producto en ventas. \n" +
                "5- Salir.");
            Console.WriteLine("Que desea realizar: ");
        }
        public int ChooseOption()
        {
            return Convert.ToInt32(Console.ReadLine());
        }

        public void SelectedOption(int option)
        {
            while (!exit) 
            {
                switch (option) 
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opción incorrecta, ingrese opción válida.");
                        Console.ReadKey(true);
                        Console.Clear();
                        this.ShowOptions();
                        this.SelectedOption(ChooseOption());
                        break;
                }
            }
        }

        public int SelectOption()
        {
            throw new NotImplementedException();
        }
    }
}

namespace Application.Interfaces.Menu
{
    public interface IMenu
    {
        void ShowOptions();
        int ChooseOption();
        void SelectedOption(int option);
    }
}

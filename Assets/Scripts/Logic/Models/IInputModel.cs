namespace Assets.Scripts.Logic.Models
{
    public interface IInputModel
    {
        bool HasNewInput { get; }
        void ClearInput();
    }
}
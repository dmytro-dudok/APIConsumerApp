using System.Threading.Tasks;

namespace WpfUI.Library
{
    public interface IFoxProcessor
    {
        Task<RandomFoxModel> LoadRandomFox();
    }
}
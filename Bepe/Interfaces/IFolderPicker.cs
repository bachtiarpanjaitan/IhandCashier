namespace IhandCashier.Bepe.Interfaces;

public interface IFolderPicker
{
    Task<string> PickFolder();
    Task SaveFileToFolder(string filename, string folder, string fileName);
}